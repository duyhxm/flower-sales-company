using Microsoft.VisualStudio.TestTools.UnitTesting;
using DL.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using DTO.Store;

namespace DL.Repositories.Implementations.Tests
{
    [TestClass()]
    public class StoreRepositoryTests
    {
        [TestMethod()]
        public async Task GetStoreInventoryAsyncTest()
        {
            var repo = new StoreRepository();
            string storeId = "S001";

            List<MaterialInventoryDTO> result = await repo.GetMaterialInventoryByStoreAsync(storeId);

            Debug.WriteLine("MaterialId | MaterialName | StockMaterialQuantity | UnitPrice");

            foreach (var i in result)
            {
                Debug.WriteLine($"{i.MaterialId} | {i.MaterialName} | {i.StockMaterialQuantity} | {i.UnitPrice}");
            }

            Debug.WriteLine("-------Completed-------");
        }

        [TestMethod()]
        public void UpdateProductInventoryAsyncTest()
        {
            Assert.Fail();
        }
    }
}