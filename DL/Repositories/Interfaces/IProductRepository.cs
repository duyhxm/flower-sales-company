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
        Product? FindById(Product product);
        Task<List<Product>> GetAllProductsAsync();
        Task AddProductAsync(Product product);
    }
}
