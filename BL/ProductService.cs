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

        public async Task AddProductAsync(ProductDTO product, ProductCreationHistoryDTO productCreationHistory, string? storeId)
        {
            try
            {
                await _productRepository.AddProductAsync(product, productCreationHistory, storeId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<decimal> CalculateUnitPriceAsync(List<StoreInventoryDTO> storeInventory, Dictionary<string, int> materialQuantities)
        {
            return await Task.Run(() =>
            {
                decimal totalPrice = 0;

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

                return totalPrice;
            });
        }
    }
}
