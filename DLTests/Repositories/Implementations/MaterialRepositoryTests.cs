using Microsoft.VisualStudio.TestTools.UnitTesting;
using DL.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Diagnostics;

namespace DL.Repositories.Implementations.Tests
{
    [TestClass()]
    public class MaterialRepositoryTests
    {
        //[TestMethod()]
        //public async Task GetAllAccessoryByStoreAsyncTest()
        //{
        //    MaterialRepository repository = new MaterialRepository();

        //    List<MaterialInventoryDTO> accessoryList = await repository.GetAllMaterialByStoreAsync("S001");

        //    foreach (var a in accessoryList)
        //    {
        //        Debug.WriteLine($"Id: {a.MaterialID}; name: {a.MaterialName}; q: {a.StockMaterialQuantity}");
        //    }
        //}

        [TestMethod()]
        public async Task GetAllFlowerByStoreAsyncTest()
        {
            MaterialRepository repository = new MaterialRepository();

            List<DTO.Material.FlowerDTO> flowerList = await repository.GetAllFlowerByStoreAsync("S001");

            foreach (var a in flowerList)
            {
                Debug.WriteLine($"Id: {a.FlowerID}; name: {a.FlowerName}; type name: {a.FTypeName}; color name: {a.FColorName}; characteristic name: {a.FCharacteristicName}");
            }
        }
    }
}