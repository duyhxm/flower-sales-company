using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL.Models;
using DTO;
using DL.Repositories.Interfaces;

namespace DL.Repositories.Implementations
{
    public class StoreRepository : IStoreRepository
    {
        public int AddStore(Store store)
        {
            return 1;
        }
        //Read
        public Task<List<Store>> GetAllStoresAsync(string criteria)
        {
            return null;
        }
        //Update
        public int UpdateStore(Store store)
        {
            return 1;
        }
        //Delete
        public int DeleteStore(Store store)
        {
            return 1;
            
        }
    }
}
