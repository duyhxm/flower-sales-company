using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Product;
using DL.Repositories.Implementations;

namespace BL
{
    public class ProductService
    {
        private ProductRepository? _productRepository;

        public ProductService()
        {
            _productRepository = new ProductRepository();
        }
        private ProductDTO? AddProduct(ProductDTO product)
        {
            return null;
        }

        private async Task AddDetailedProduct(List<DetailedProductDTO> detailedProductList)
        {

        }

        private async Task CreateProductCreationHistory(ProductCreationHistoryDTO productCreationHistory)
        {

        }

        public async Task AddCompleteProduct(ProductDTO product, List<DetailedProductDTO> detailedProductList, ProductCreationHistoryDTO productCreationHistory)
        {
            ProductDTO? productDTO = AddProduct(product);
            await AddDetailedProduct(detailedProductList);
            await CreateProductCreationHistory(productCreationHistory);
        }

        public string? GetLastestProductId()
        {
            try
            {
                return _productRepository!.GetLastestProductId();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
