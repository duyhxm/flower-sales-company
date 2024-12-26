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

        //public async Task<StoreDTO> GetStoreInfoAsync(string storeId)
        //{
        //    try
        //    {

        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

    }
}
