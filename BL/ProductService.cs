using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Product;
using DL.Repositories.Implementations;
using DTO.Store;

namespace BL
{
    public class ProductService
    {
        private ProductRepository _productRepository;

        public ProductService()
        {
            _productRepository = new ProductRepository();
        }

        public async Task<ReturnedProductDTO> AddProductAsync(ProductDTO product, ProductCreationHistoryDTO productCreationHistory, string storeId)
        {
            try
            {
                return await _productRepository.AddProductAsync(product, productCreationHistory, storeId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<decimal> CalculateUnitPriceAsync(Dictionary<string, int> materialQuantities, List<MaterialInventoryDTO>? storeInventory = null)
        {
            decimal totalPrice = 0;
           
            if (storeInventory != null)
            {
                var joinedData = from inventory in storeInventory
                                    join material in materialQuantities
                                    on inventory.MaterialId equals material.Key
                                    select new
                                    {
                                        inventory.UnitPrice,
                                        Quantity = material.Value
                                    };

                foreach (var item in joinedData)
                {
                    totalPrice += item.UnitPrice * item.Quantity;
                }
            }
            else
            {
                totalPrice = await _productRepository.CalculateUnitPriceAsync(materialQuantities);
            }
            return totalPrice;
        }

        public async Task<ReturnedProductDTO> AddAbstractProductAsync(ProductDTO product)
        {
            try
            {
                return await _productRepository.AddAbstractProductAsync(product);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<DetailedProductMaterialNameDTO>> GetDetailedProductsByProductIdAsync(string productId)
        {
            try
            {
                return await _productRepository.GetDetailedProductsByProductIdAsync(productId);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
