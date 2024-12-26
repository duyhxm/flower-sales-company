using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL.Models;
using DTO;

namespace DL.Repositories.Interfaces
{
    public interface IStoreRepository
    {
        //Create
        int AddStore(Store store);
        //Read
        Task<List<Store>> GetAllStoresAsync(string criteria);
        //Update
        int UpdateStore(Store store);
        //Delete
        int DeleteStore(Store store);

    }
}
