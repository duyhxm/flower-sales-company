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

        public async Task<List<MaterialInventoryDTO>> GetMaterialInventoryAsync(string storeId)
        {
            try
            {
                return await _storeRepository.GetMaterialInventoryAsync(storeId);
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
                return await _storeRepository.GetProductInventoryAsync(storeId);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
