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

        public async Task<List<StoreInventoryDTO>> GetStoreInventoryAsync(string storeId)
        {
            try
            {
                return await _storeRepository.GetStoreInventoryAsync(storeId);
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
