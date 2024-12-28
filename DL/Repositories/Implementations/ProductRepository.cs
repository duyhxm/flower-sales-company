using DL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using DTO.Product;
using AutoMapper;
using DL.Repositories.Implementations;

namespace DL.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly FlowerSalesCompanyDbContext _context;
        private IMapper _mapper;
        public ProductRepository()
        {
            _context = new FlowerSalesCompanyDbContext();
            _mapper = SystemRepository.Instance.Mapper;
        }

        public async Task<Product?> FindByIdAsync(string productId)
        {
            try
            {
                return await _context.Products.FindAsync(productId);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<Product>> GetAllProductsAsync()
        {
            try
            {
                return await _context.Products.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public int AddProduct(Product product)
        {
            int affectedRows = 0;
            try
            {
                 affectedRows = _context.Database.ExecuteSqlInterpolated($"EXECUTE dbo.uspAddProduct {product.ProductName}, {product.FrepresentationId}");
                _context.SaveChanges();
            }
            catch(Exception)
            {
                throw;
            }

            return affectedRows;
        }

        public void RemoveProduct(Product product)
        {
            try
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            catch(Exception)
            {
                throw;
            }
        }

        public string? GetLastestProductId()
        {
            try
            {
                return _context.Products
                    .OrderByDescending(p => p.ProductId)
                    .Select(p => p.ProductId)
                    .FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string GenerateId(string currentId)
        {
            int index = 0;
            while (index < currentId.Length && !char.IsDigit(currentId[index]))
            {
                index++;
            }

            StringBuilder letters = new StringBuilder(currentId.Substring(0, index));
            StringBuilder numbers = new StringBuilder(currentId.Substring(index));

            // Chuyển đổi phần số sang dạng số và cộng thêm 1
            int number;
            if (!int.TryParse(numbers.ToString(), out number))
            {
                throw new ArgumentException("Invalid number format in input string.");
            }

            number++;

            // Chuyển lại số thành chuỗi và ghép vào phần chữ
            StringBuilder newNumbers = new StringBuilder(number.ToString());
            while (newNumbers.Length < numbers.Length)
            {
                newNumbers.Insert(0, '0');
            }

            // Kiểm tra độ dài của chuỗi mới
            if (letters.Length + newNumbers.Length > currentId.Length)
            {
                throw new InvalidOperationException("Resulting string exceeds the original length.");
            }

            letters.Append(newNumbers);
            return letters.ToString();
        }

        public async Task<ReturnedProductDTO> AddProductAsync(ProductDTO product, ProductCreationHistoryDTO productCreationHistory, string storeId)
        {
            bool hasExisted = false;
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                //Tìm kiếm sản phẩm xem đã tồn tại chưa, để tránh trùng lắp
                var existingProductInfo = await CheckProductExistence(product);

                //sản phẩm đã tồn tại trong database
                if (existingProductInfo != null)
                {
                    hasExisted = true;
                    await HandleExistingProduct(existingProductInfo, productCreationHistory, storeId);
                }
                else
                {
                    await HandleNewProduct(product, productCreationHistory, storeId);
                }

                await UpdateMaterialInventoryAsync(product, storeId, (int)productCreationHistory.CreatedQuantity!);

                await UpdateProductInventoryAsync(productCreationHistory.CreatedDateTime, storeId, product.ProductId, (int)productCreationHistory.CreatedQuantity!);

                await transaction.CommitAsync();

                return new ReturnedProductDTO()
                {
                    Product = product,
                    HasExisted = hasExisted
                };
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception("An error occurred while adding the product.", ex);
            }
        }

        public async Task UpdateMaterialInventoryAsync(ProductDTO product, string? storeId, int createdQuantity)
        {
            foreach (var detailedProduct in product.DetailedProducts)
            {
                var materialInventory = await _context.MaterialInventories
                    .FirstOrDefaultAsync(mi => mi.MaterialId == detailedProduct.MaterialId && mi.StoreId == storeId);

                if (materialInventory != null)
                {
                    materialInventory.StockMaterialQuantity -= detailedProduct.UsedQuantity * createdQuantity ?? 0;
                    _context.Entry(materialInventory).Property(mi => mi.StockMaterialQuantity).IsModified = true;
                }
                else
                {
                    throw new Exception($"Material with ID {detailedProduct.MaterialId} not found in store {storeId}.");
                }
            }

            await _context.SaveChangesAsync();
        }

        private async Task UpdateProductInventoryAsync(DateTimeOffset createdDateTime, string storeId, string productId, int createdQuantity)
        {
            try
            {
                _context.Database.ExecuteSqlInterpolated($"EXECUTE dbo.uspUpdateProductInventory @creationDateTime = {createdDateTime}, @storeId = {storeId}, @productId = {productId}, @createdQuantity = {createdQuantity}");

                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task HandleExistingProduct(Dictionary<string, string> existingProductInfo, ProductCreationHistoryDTO productCreationHistory, string? storeId)
        {
            short? createdQuantity = productCreationHistory.CreatedQuantity;
            var existingProductAtStore = await _context.ProductInventories
                                          .FirstOrDefaultAsync(pi => pi.ProductId == existingProductInfo.First().Key && pi.StoreId == storeId);

            if (existingProductAtStore != null)
            {
                existingProductAtStore.StockProductQuantity += Convert.ToInt32(createdQuantity);
                _context.Entry(existingProductAtStore).Property(p => p.StockProductQuantity).IsModified = true;
            }
            else
            {
                ProductInventory pi = new ProductInventory()
                {
                    ProductId = existingProductInfo.First().Key,
                    StoreId = storeId!,
                    StockProductQuantity = Convert.ToInt32(createdQuantity)
                };

                _context.ProductInventories.Add(pi);
            }

            productCreationHistory.ProductId = existingProductInfo.First().Key;
            var createdHistory = _mapper.Map<ProductCreationHistory>(productCreationHistory);
            _context.ProductCreationHistories.Add(createdHistory);

            await _context.SaveChangesAsync();
        }

        private async Task HandleNewProduct(ProductDTO product, ProductCreationHistoryDTO productCreationHistory, string? storeId)
        {
            string? currentProductId = GetLastestProductId();
            string newProductId = currentProductId == null ? "P000000001" : GenerateId(currentProductId);

            productCreationHistory.ProductId = newProductId;
            product.ProductId = newProductId;

            foreach (var detailedProduct in product.DetailedProducts)
            {
                detailedProduct.ProductId = newProductId;
            }

            var convertedProduct = _mapper.Map<Product>(product);
            var createdHistory = _mapper.Map<ProductCreationHistory>(productCreationHistory);

            ProductInventory pi = new ProductInventory()
            {
                ProductId = convertedProduct.ProductId,
                StoreId = storeId!,
                StockProductQuantity = productCreationHistory.CreatedQuantity
            };

            _context.Products.Add(convertedProduct);
            _context.ProductCreationHistories.Add(createdHistory);
            _context.ProductInventories.Add(pi);

            await _context.SaveChangesAsync();
        }

        private async Task<Dictionary<string, string>?> CheckProductExistence(ProductDTO product)
        {
            Dictionary<string, string>? result = new Dictionary<string, string>();

            try
            {
                // Map ProductDTO to Product
                Product testedProduct = _mapper.Map<Product>(product);

                // Get the FrepresentationId and DetailedProducts from the tested product
                string? fRepresentationId = testedProduct.FrepresentationId;
                ICollection<DetailedProduct> detailedProducts = testedProduct.DetailedProducts;

                // Check if there are any products in the database
                if (await _context.Products.CountAsync() == 0)
                {
                    return null;
                }

                // Find products with the same FrepresentationId
                var matchingProducts = await _context.Products
                    .Where(p => p.FrepresentationId == fRepresentationId)
                    .Include(p => p.DetailedProducts)
                    .ToListAsync();

                foreach (var dbProduct in matchingProducts)
                {
                    // Step 1: Check if the number of DetailedProducts is the same
                    if (dbProduct.DetailedProducts.Count != detailedProducts.Count)
                    {
                        continue;
                    }

                    // Step 2: Compare each DetailedProduct
                    bool isMatch = true;
                    foreach (var detailedProduct in detailedProducts)
                    {
                        var matchingDetailedProduct = dbProduct.DetailedProducts
                            .FirstOrDefault(dp => dp.MaterialId == detailedProduct.MaterialId && dp.UsedQuantity == detailedProduct.UsedQuantity);

                        if (matchingDetailedProduct == null)
                        {
                            isMatch = false;
                            break;
                        }
                    }

                    // Step 3: If all DetailedProducts match, return the ProductId and ProductName
                    if (isMatch)
                    {
                        result.Add(dbProduct.ProductId, dbProduct.ProductName!);
                        break;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return result.Count > 0 ? result : null;
        }

    }
}
