using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL.Models;
using DTO.Store;

namespace DL.Repositories.Interfaces
{
    public interface IStoreRepository
    {
        //Create
        int AddStore(StoreDTO store);
        //Read
        Task<List<StoreDTO>> GetAllStoresAsync();
        //Update
        int UpdateStore(StoreDTO store);
        //Delete
        int DeleteStore(StoreDTO store);

    }
}
