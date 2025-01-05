using DL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Product;

namespace DL.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<ProductDTO?> FindProductByIdAsync(string productId);
        Task<List<ProductDTO>> GetAllProductsAsync();
        void RemoveProduct(ProductDTO product);
    }
}
