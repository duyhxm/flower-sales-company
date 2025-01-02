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
using DTO.Enum;

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
                if (!string.IsNullOrEmpty(product.ProductId) && !string.IsNullOrEmpty(product.ProductName))
                {
                    // Product already has an ID and Name, proceed with inventory updates
                    await UpdateMaterialInventoryAsync(product, storeId, (int)productCreationHistory.CreatedQuantity!);
                    await UpdateProductInventoryAsync(productCreationHistory.CreatedDateTime, storeId, product.ProductId, (int)productCreationHistory.CreatedQuantity!);
                }
                else
                {
                    // Check if the product already exists in the database
                    var existingProductInfo = await CheckProductExistence(product);

                    if (existingProductInfo != null)
                    {
                        // Product exists, update its ID and proceed with inventory updates
                        hasExisted = true;
                        product.ProductId = existingProductInfo.First().Key;
                        await UpdateMaterialInventoryAsync(product, storeId, (int)productCreationHistory.CreatedQuantity!);
                        await UpdateProductInventoryAsync(productCreationHistory.CreatedDateTime, storeId, product.ProductId, (int)productCreationHistory.CreatedQuantity!);
                    }
                    else
                    {
                        // Product does not exist, handle as a new product
                        ProductDTO newProduct = await HandleNewProduct(product, productCreationHistory, storeId);
                        product.ProductId = newProduct.ProductId;
                        await UpdateMaterialInventoryAsync(product, storeId, (int)productCreationHistory.CreatedQuantity!);
                        await UpdateProductInventoryAsync(productCreationHistory.CreatedDateTime, storeId, product.ProductId, (int)productCreationHistory.CreatedQuantity!);
                    }
                }

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
                throw new Exception("Đã xảy ra lỗi trong quá trình thêm sản phẩm. Vui lòng thử lại hoặc liên hệ bộ phận kỹ thuật", ex);
            }
        }


        //Update kho vật liệu của cửa hàng, có kiểm tra xem liệu kho có đủ số lượng vật liệu để tạo sản phẩm hay không
        public async Task UpdateMaterialInventoryAsync(ProductDTO product, string? storeId, int createdQuantity)
        {
            foreach (var detailedProduct in product.DetailedProducts)
            {
                var materialInventory = await _context.MaterialInventories
                    .FirstOrDefaultAsync(mi => mi.MaterialId == detailedProduct.MaterialId && mi.StoreId == storeId);

                if (materialInventory != null)
                {
                    materialInventory.StockMaterialQuantity -= detailedProduct.UsedQuantity * createdQuantity;

                    if (materialInventory.StockMaterialQuantity < 0)
                    {
                        throw new Exception($"Số lượng vật liệu {detailedProduct.MaterialId} không đủ để tạo mới sản phẩm.");
                    }

                    _context.Entry(materialInventory).Property(mi => mi.StockMaterialQuantity).IsModified = true;
                }
                else
                {
                    throw new Exception($"Vật liệu với ID {detailedProduct.MaterialId} không được tìm thấy ở cửa hàng {storeId}.");
                }
            }

            await _context.SaveChangesAsync();
        }

        //Sử dụng hàm này để update kho sản phẩm của cửa hàng
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


        //Xử lý thêm mới sản phẩm khi mà sản phẩm này đã tồn tại trong database
        private async Task HandleExistingProduct(Dictionary<string, string> existingProductInfo, ProductCreationHistoryDTO productCreationHistory, string? storeId)
        {
            //Lấy ra số tượng sản phẩm đã được tạo
            short? createdQuantity = productCreationHistory.CreatedQuantity;

            //Kiểm tra xem sản phẩm này có tồn tại ở kho của cửa hàng chưa
            var existingProductAtStore = await _context.ProductInventories
                                          .FirstOrDefaultAsync(pi => pi.ProductId == existingProductInfo.First().Key && pi.StoreId == storeId);

            //Nếu sản phẩm đã tồn tại ở cửa hàng, chỉ cần cập nhật cột StockProductQuantity (số lượng sản phẩm tồn kho)
            if (existingProductAtStore != null)
            {
                existingProductAtStore.StockProductQuantity += Convert.ToInt32(createdQuantity);
                _context.Entry(existingProductAtStore).Property(p => p.StockProductQuantity).IsModified = true;
            }
            else //Trường hợp sản phẩm chưa tồn tại ở cửa hàng, thì sẽ thêm mới một row
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

        //Xử lý thêm mới một sản phẩm khi mà chưa tồn tại trong database. Hàm này chỉ có thêm mới vô trong Product, DetailedProduct, và ProductCreationHistory
        private async Task<ProductDTO> HandleNewProduct(ProductDTO product, ProductCreationHistoryDTO productCreationHistory, string? storeId)
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
            return product;
        }


        //Hàm này sẽ kiểm tra xem sản phẩm có tồn tại ở trong bảng Product hay chưa
        private async Task<Dictionary<string, string>?> CheckProductExistence(ProductDTO product)
        {
            //Khai báo kết quả trả về của hàm này. Kết quả trả về sẽ chỉ có đúng 1 item nếu product này có tồn tại trong database hoặc trả về null nếu sản phẩm này chưa tồn tại trong database hoặc bảng Product trong database chưa có dữ liệu
            Dictionary<string, string>? result = new Dictionary<string, string>();

            try
            {
                // Map ProductDTO sang Product
                Product testedProduct = _mapper.Map<Product>(product);

                //Lấy ra hình thức sản phẩm và chi tiết sản phẩm để đi kiểm tra
                string? fRepresentationId = testedProduct.FrepresentationId;
                ICollection<DetailedProduct> detailedProducts = testedProduct.DetailedProducts;

                // Nếu mà bảng Product trong database rỗng, nghĩa là số lượng dòng bằng 0, thì trả về null. Biểu thị rằng không có sản phẩm nào cả.
                if (await _context.Products.CountAsync() == 0)
                {
                    return null;
                }

                //Lọc ra những product mà có cùng hình thức sản phẩm
                var matchingProducts = await _context.Products
                    .Where(p => p.FrepresentationId == fRepresentationId)
                    .Include(p => p.DetailedProducts)
                    .ToListAsync();

                //Sau khi lọc, ta sẽ có được một danh sách những sản phẩm có cùng hình thức sản phẩm. Bắt đầu duyệt từng sản phẩm, mình sẽ so sánh các vật liệu mà sản phẩm đó sử dụng
                foreach (var dbProduct in matchingProducts)
                {
                    //Bước 1: Kiểm tra xem nếu mà số lượng vật liệu của sản phẩm có trong database và sản phẩm được kiểm tra mà khác nhau, thì chuyển qua sản phẩm kế tiếp.
                    if (dbProduct.DetailedProducts.Count != detailedProducts.Count)
                    {
                        continue;
                    }

                    //Bước 2: Khi mà đã tìm thấy sản phẩm có cùng số lượng vật liệu với sản phẩm đang được kiểm tra, thì bắt đầu kiểm tra tiếp từng chi tiết vật liệu.
                    bool isMatch = true;

                    //Duyệt qua từng vật liệu mà sản phẩm đang được kiểm tra đã sử dụng và so sánh với vật liệu của sản phẩm mà có cùng số lượng vừa match
                    foreach (var detailedProduct in detailedProducts)
                    {
                        var matchingDetailedProduct = dbProduct.DetailedProducts
                            .FirstOrDefault(dp => dp.MaterialId == detailedProduct.MaterialId && dp.UsedQuantity == detailedProduct.UsedQuantity);

                        //Nếu chỉ cần tồn tại ít nhất một item trong chi tiết sản phẩm mà không match, thì lập tức kết thúc vòng lặp và tìm tiếp sản phẩm mà có cùng số lượng vật liệu để kiểm tra tiếp tục.
                        if (matchingDetailedProduct == null)
                        {
                            isMatch = false;
                            break;
                        }
                    }

                    //Bước 3: Nếu mà biến isMatch có giá trị true, nghĩa là đã tìm thấy một sản phẩm có cùng số lượng vật liệu, mỗi vật liệu đều có số lượng được dùng như sau, thì có nghĩa là sản phẩm đang được kiểm tra đã tồn tại trong database, thì trả về kết quả là ProductId và ProductName và kết thúc vòng lặp.
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


        //Thêm mới một sản phẩm trừu tượng. Method này được sử dụng 
        public async Task<ReturnedProductDTO> AddAbstractProductAsync(ProductDTO product)
        {
            try
            {
                var existedProduct = await CheckProductExistence(product);

                if (existedProduct != null)
                {
                    product.ProductId = existedProduct.First().Key;
                    product.ProductName = existedProduct.First().Value;
                    return new ReturnedProductDTO()
                    {
                        Product = product,
                        HasExisted = true
                    };
                }
                else
                {
                    string? currentProductId = GetLastestProductId();
                    string newProductId = currentProductId == null ? "P000000001" : GenerateId(currentProductId);

                    product.ProductId = newProductId;

                    foreach (var detailedProduct in product.DetailedProducts)
                    {
                        detailedProduct.ProductId = newProductId;
                    }

                    var convertedProduct = _mapper.Map<Product>(product);
                    
                    _context.Products.Add(convertedProduct);

                    await _context.SaveChangesAsync();

                    return new ReturnedProductDTO()
                    {
                        Product = product,
                        HasExisted = false
                    };
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        //Tính toán UnitPrice (giá bán) của một sản phẩm. Hàm này sẽ chỉ cần danh sách chứa các MaterialId và số lượng mà vật liệu này sử dụng 
        public async Task<decimal> CalculateUnitPriceAsync(Dictionary<string, int> materialQuantities)
        {
            decimal totalCost = 0;

            //Duyệt qua từng material
            foreach (var material in materialQuantities)
            {
                string materialId = material.Key;
                int quantity = material.Value;

                decimal costPrice = 0;
                decimal profitRate = 0;

                //Về vật liệu, thì sẽ chia làm 'hoa' và 'phụ liệu'. Cả hai đều có bảng riêng để set tỉ lệ lợi nhuận riêng. MaterialID của phụ liệu bắt đầu bằng ký tự 'A', còn MaterialID của hoa bắt đầu bằng ký tự 'F'
                if (materialId.StartsWith("A"))
                {
                    //Lấy tỉ lệ lợi nhuận cho phụ liệu.
                    var accessoryProfitRate = await _context.AccessoryProfitRates
                        .Where(apr => apr.StartDate <= DateOnly.FromDateTime(DateTime.Now) && apr.EndDate >= DateOnly.FromDateTime(DateTime.Now))
                        .FirstOrDefaultAsync();

                    //Nếu tỉ lệ lợi nhuận khác null, nghĩa là đã có dữ liệu cho tỉ lệ lợi nhuận tại thời điểm hiện tại. Lúc này, truy cập vô bảng lịch sử tỉ lệ lợi nhuận của phụ liệu tương ứng với material
                    if (accessoryProfitRate != null)
                    {
                        var accessoryProfitRateHistory = await _context.AccessoryProfitRateHistories
                            .Where(aprh => aprh.AccessoryProfitRateId == accessoryProfitRate.AccessoryProfitRateId && aprh.AccessoryId == materialId)
                            .FirstOrDefaultAsync();

                        //Nếu mà có tồn tại một record, thì kiểm tra xem cột ProfitRate (tỉ lệ lợi nhuận) có null không. Nếu null thì trả về 0.
                        if (accessoryProfitRateHistory != null)
                        {
                            profitRate = accessoryProfitRateHistory.ProfitRate ?? 0;
                        }
                    }

                    //Lấy giá gốc mua vào của vật liệu này từ bảng PurchaseOrder bằng cách tìm PurchaseOrder có thời gian nhập trong thời gian hiện tại.
                    var purchaseOrder = await _context.PurchaseOrders
                        .Where(po => po.OrderType == MaterialType.Accessory && po.PurchasedDateTime.HasValue)
                        .OrderByDescending(po => po.PurchasedDateTime)
                        .FirstOrDefaultAsync(po => po.PurchasedDateTime!.Value.Month == DateTime.Now.Month && po.PurchasedDateTime.Value.Year == DateTime.Now.Year);

                    //Tuy nhiên, đôi khi có thể đơn hàng nhập không trong thời điểm hiện tại. Nhất là đối với phụ liệu, thì mình có thể nhập mà bán tận trong vài tháng hơn, nên lúc này thời gian mua hàng sẽ khác với thời gian hiện tại. Để xử lý trường hợp này, mình sẽ lấy PurchaseOrder có thời gian nhập gần nhất.
                    if (purchaseOrder == null)
                    {
                        purchaseOrder = await _context.PurchaseOrders
                            .Where(po => po.OrderType == MaterialType.Accessory && po.PurchasedDateTime.HasValue)
                            .OrderByDescending(po => po.PurchasedDateTime)
                            .FirstOrDefaultAsync();
                    }

                    //Nếu PurchaseOrder khác null, nghĩa là có đơn hàng nhập trong thời điểm hiện tại. Khi này, chỉ việc lấy ra record tương ứng với MaterialID, rồi lấy ra CostPrice (giá gốc). Nếu trường hợp CostPrice bằng null, thì gán mặc định bằng 0.
                    if (purchaseOrder != null)
                    {
                        var detailedPurchaseOrder = await _context.DetailedPurchaseOrders
                            .Where(dpo => dpo.PurchaseOrderId == purchaseOrder.PurchaseOrderId && dpo.MaterialId == materialId)
                            .FirstOrDefaultAsync();

                        if (detailedPurchaseOrder != null)
                        {
                            costPrice = detailedPurchaseOrder.CostPrice ?? 0;
                        }
                    }
                }
                else //Trường hợp vật liệu là hoa
                {
                    var currentMonth = DateTime.Now.Month;
                    var currentYear = DateTime.Now.Year;

                    var flowerSalesTarget = await _context.FlowerSalesTargets
                        .Where(fst => fst.ApplyMonth == currentMonth && fst.ApplyYear == currentYear)
                        .FirstOrDefaultAsync();

                    if (flowerSalesTarget != null)
                    {
                        var flowerSalesTargetHistory = await _context.FlowerSalesTargetHistories
                            .Where(fsth => fsth.TargetId == flowerSalesTarget.TargetId && fsth.FlowerId == materialId)
                            .FirstOrDefaultAsync();

                        if (flowerSalesTargetHistory != null)
                        {
                            profitRate = flowerSalesTargetHistory.ProfitRate ?? 0;
                        }
                    }

                    // Get cost price from purchase order for flower
                    var purchaseOrder = await _context.PurchaseOrders
                        .Where(po => po.OrderType == MaterialType.Flower && po.PurchasedDateTime.HasValue)
                        .OrderByDescending(po => po.PurchasedDateTime)
                        .FirstOrDefaultAsync(po => po.PurchasedDateTime!.Value.Month == DateTime.Now.Month && po.PurchasedDateTime.Value.Year == DateTime.Now.Year);

                    if (purchaseOrder == null)
                    {
                        purchaseOrder = await _context.PurchaseOrders
                            .Where(po => po.OrderType == MaterialType.Flower && po.PurchasedDateTime.HasValue)
                            .OrderByDescending(po => po.PurchasedDateTime)
                            .FirstOrDefaultAsync();
                    }

                    if (purchaseOrder != null)
                    {
                        var detailedPurchaseOrder = await _context.DetailedPurchaseOrders
                            .Where(dpo => dpo.PurchaseOrderId == purchaseOrder.PurchaseOrderId && dpo.MaterialId == materialId)
                            .FirstOrDefaultAsync();

                        if (detailedPurchaseOrder != null)
                        {
                            costPrice = detailedPurchaseOrder.CostPrice ?? 0;
                        }
                    }
                }

                //Tính toán Unit Price bằng cách lấy giá gốc nhân với (1 + tỉ lệ lợi nhuận) của vật liệu đó.
                decimal unitPrice = costPrice * (1 + profitRate);
                totalCost += unitPrice * quantity;
            }

            return totalCost;
        }

       
        public async Task<List<DetailedProductMaterialNameDTO>> GetDetailedProductsByProductIdAsync(string productId)
        {
            try
            {
                var detailedProducts = await (from dp in _context.DetailedProducts
                                              join m in _context.Materials on dp.MaterialId equals m.MaterialId
                                              where dp.ProductId == productId
                                              select new DetailedProductMaterialNameDTO
                                              {
                                                  MaterialId = m.MaterialId,
                                                  MaterialName = m.MaterialName!,
                                                  UsedQuantity = dp.UsedQuantity
                                              }).ToListAsync();

                return detailedProducts;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
