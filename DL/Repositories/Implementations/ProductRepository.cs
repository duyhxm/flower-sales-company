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

        public ProductRepository()
        {
            _context = new FlowerSalesCompanyDbContext();
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
    }
}
