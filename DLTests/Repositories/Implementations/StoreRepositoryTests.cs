using Microsoft.VisualStudio.TestTools.UnitTesting;
using DL.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using DTO.Store;
using DTO;

namespace DL.Repositories.Implementations.Tests
{
    [TestClass()]
    public class StoreRepositoryTests
    {
        //[TestMethod()]
        //public async Task GetStoreInventoryAsyncTest()
        //{
        //    var repo = new StoreRepository();
        //    string storeId = "S001";

        //    List<MaterialInventoryDTO> result = await repo.GetMaterialInventoryByStoreAsync(storeId);

        //    Debug.WriteLine("MaterialId | MaterialName | StockMaterialQuantity | UnitPrice");

        //    foreach (var i in result)
        //    {
        //        Debug.WriteLine($"{i.MaterialId} | {i.MaterialName} | {i.StockMaterialQuantity} | {i.UnitPrice}");
        //    }

        //    Debug.WriteLine("-------Completed-------");
        //}

        //[TestMethod()]
        //public void UpdateProductInventoryAsyncTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public async Task GetSalesOrdersByStoreAsyncTest()
        //{
        //    StoreRepository repo = new StoreRepository();


        //    var result = await repo.GetSalesOrdersByStoreAsync("S001", DateTimeOffset.UtcNow.ToLocalTime());

        //    Debug.WriteLine(result);
        //}

        //[TestMethod()]
        //public async Task GetPlannedProductForStoreTest()
        //{
        //    SystemRepository.Initialize();
        //    StoreRepository repo = new StoreRepository();

        //    string dateTimeString = "2025-01-02 00:15:00 +07:00";
        //    DateTimeOffset dateTimeOffset = DateTimeOffset.Parse(dateTimeString);

        //    // Convert DateTimeOffset to string
        //    string formattedString = dateTimeOffset.ToString("yyyy-MM-dd HH:mm:ss zzz");

        //    PlannedProductDTO? result = await repo.GetPlannedProductForStoreAsync(dateTimeOffset);

        //    if (result != null)
        //    {
        //        Debug.WriteLine(result.PlannedDateTime);
        //    }


        //    //if (result != null)
        //    //{
        //    //    var productId = result.GetType().GetProperty("ProductId")?.GetValue(result, null);
        //    //    var productName = result.GetType().GetProperty("ProductName")?.GetValue(result, null);
        //    //    var implementationDateTime = result.GetType().GetProperty("ImplementataionDateTime")?.GetValue(result, null);
        //    //    var quantity = result.GetType().GetProperty("Quantity")?.GetValue(result, null);

        //    //    Debug.WriteLine($"ProductId: {productId}");
        //    //    Debug.WriteLine($"ProductName: {productName}");
        //    //    Debug.WriteLine($"ImplementationDateTime: {implementationDateTime}");
        //    //    Debug.WriteLine($"Quantity: {quantity}");
        //    //}
        //    //else
        //    //{
        //    //    Debug.WriteLine("No planned product found for the given date.");
        //    //}

        //}

        //[TestMethod()]
        //public async Task GetPlannedProductsForStoreAsyncTest()
        //{
        //    SystemRepository.Initialize();
        //    StoreRepository repo = new StoreRepository();

        //    //var result = await repo.GetPlannedProductsForStoreAsync(DateTime.UtcNow.ToLocalTime(), "S001");

        //    if (result != null)
        //    {
        //        foreach (var pp in result)
        //        {
        //            Debug.WriteLine($"PlannedDateTime: {pp.PlannedDateTime}");
        //        }
        //    }

            
        //}
    }
}