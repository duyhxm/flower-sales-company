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

        public async Task<List<MaterialInventoryDTO>> GetMaterialInventoryAsync(string storeId)
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

        public async Task<List<ProductInventoryDTO>?> GetProductInventoryAsync(string storeId)
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
    }
}
