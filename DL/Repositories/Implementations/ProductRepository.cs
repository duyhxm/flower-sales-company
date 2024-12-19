using DL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DL.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly FlowerSalesCompanyDbContext _context;

        public ProductRepository(FlowerSalesCompanyDbContext context)
        {
            _context = context;
        }

        public Product? FindById(Product product)
        {
            return new Product();
        }
        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }
        public async Task AddProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }
    }
}
