using Microsoft.VisualStudio.TestTools.UnitTesting;
using DL.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.SalesOrder;
using System.Diagnostics;

namespace DL.Repositories.Implementations.Tests
{
    [TestClass()]
    public class SalesOrderRepositoryTests
    {
        [TestMethod()]
        public void AddSalesOrderAsyncTest()
        {
            Assert.Fail();
        }
        //[TestMethod()]
        //public async Task GetOrderDiscountInfoAsyncTest()
        //{
        //    SalesOrderRepository repo = new SalesOrderRepository();

        //    decimal basePrice = 10000;

        //    DiscountInfo? result = await repo.GetOrderDiscountInfoAsync(basePrice);

        //    if(result == null)
        //    {
        //        Debug.WriteLine("Không tìm thấy order discount phù hợp");
        //    }
        //    else
        //    {
        //        Debug.WriteLine($"PromotionID: {result.PromotionID} \n Discount: {result.Discount} \n MaximumDiscountValue: {result.MaximumDiscountValue}");
        //    }
        //}

        //[TestMethod()]
        //public async Task GetCustomerDiscountInfoAsyncTest()
        //{
        //    SalesOrderRepository repo = new SalesOrderRepository();

        //    decimal basePrice = 200000;
        //    string rankName = "hạng vàng";

        //    DiscountInfo? result = await repo.GetCustomerDiscountInfoAsync(rankName, basePrice);

        //    if (result == null)
        //    {
        //        Debug.WriteLine("Không tìm thấy customer discount phù hợp");
        //    }
        //    else
        //    {
        //        Debug.WriteLine($"PromotionID: {result.PromotionID} \n Discount: {result.Discount} \n MaximumDiscountValue: {result.MaximumDiscountValue}");
        //    }
        //}
    }
}