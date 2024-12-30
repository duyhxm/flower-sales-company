using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL.Models;
using DTO;
using DL.Repositories.Interfaces;
using DTO.Store;
using DTO.Material;
using Microsoft.EntityFrameworkCore;
using DTO.SalesOrder;

namespace DL.Repositories.Implementations
{
    public class StoreRepository : IStoreRepository
    {
        private FlowerSalesCompanyDbContext _context;

        public StoreRepository()
        {
            _context = new FlowerSalesCompanyDbContext();
        }
        public int AddStore(StoreDTO store)
        {
            return 1;
        }
        //Read
        public Task<List<StoreDTO>> GetAllStoresAsync(string criteria)
        {
            return null;
        }
        //Update
        public int UpdateStore(StoreDTO store)
        {
            return 1;
        }
        //Delete
        public int DeleteStore(StoreDTO store)
        {
            return 1;
            
        }

        //Các method trên hiện tại chưa dùng đến

        public async Task<List<MaterialInventoryDTO>> GetMaterialInventoryByStoreAsync(string storeId)
        {
            try
            {
                //Hàm này sẽ lấy toàn bộ các material của cửa hàng có trong bảng MaterialInventory
                return await _context.Database.SqlQuery<MaterialInventoryDTO>($"SELECT * FROM dbo.fnGetMaterialInventory({storeId})").ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<ProductInventoryDTO>?> GetProductInventoryByStoreAsync(string storeId)
        {
            try
            {
                return await _context.Database.SqlQuery<ProductInventoryDTO>($"SELECT * FROM dbo.fnGetProductStockDetails({storeId})").ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateProductInventoryByStoreAsync(string storeId, Dictionary<string, Tuple<DateTime, int>> usedProducts)
        {
            try
            {
                foreach (var product in usedProducts)
                {
                    var productId = product.Key;
                    var stockDate = product.Value.Item1;
                    var usedQuantity = product.Value.Item2;

                    var productInventory = await _context.ProductInventories
                        .FirstOrDefaultAsync(pi => pi.StoreId == storeId && pi.ProductId == productId && pi.StockDate == stockDate);

                    if (productInventory == null)
                    {
                        throw new Exception($"Product inventory not found for StoreId: {storeId}, ProductId: {productId}, StockDate: {stockDate}");
                    }

                    if (productInventory.StockProductQuantity < usedQuantity)
                    {
                        throw new Exception($"Insufficient stock for ProductId: {productId} on StockDate: {stockDate}");
                    }

                    productInventory.StockProductQuantity -= usedQuantity;

                    _context.ProductInventories.Attach(productInventory);
                    _context.Entry(productInventory).Property(pi => pi.StockProductQuantity).IsModified = true;
                }

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating product inventory", ex);
            }
        }
    }
}
