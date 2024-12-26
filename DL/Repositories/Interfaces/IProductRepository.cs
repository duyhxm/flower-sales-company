using DL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<Product?> FindByIdAsync(string id);
        Task<List<Product>> GetAllProductsAsync();
        int AddProduct(Product product);
        void RemoveProduct(Product product);
    }
}
