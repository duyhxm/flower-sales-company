using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL.Repositories.Implementations;
using DTO.Store;

namespace BL
{
    public class StoreService
    {
        StoreRepository _storeRepository;

        public StoreService()
        {
            _storeRepository = new StoreRepository();
        }

        //Lấy vật liệu có trong cửa hàng
        public async Task<List<MaterialInventoryDTO>> GetMaterialInventoryByStoreAsync(string storeId)
        {
            try
            {
                return await _storeRepository.GetMaterialInventoryByStoreAsync(storeId);
            }
            catch (Exception)
            {
                throw;
            }

        }

        //Lấy các product có trong kho của cửa hàng
        public async Task<List<ProductInventoryDTO>?> GetProductInventoryByStoreAsync(string storeId)
        {
            try
            {
                return await _storeRepository.GetProductInventoryByStoreAsync(storeId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Update các product có trong kho của cửa hàng
        public async Task UpdateProductInventoryByStoreAsync
        (string storeId, Dictionary<string, Tuple<DateTime, int>> usedProducts)
        {
            try
            {
                await _storeRepository.UpdateProductInventoryByStoreAsync(storeId, usedProducts);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
