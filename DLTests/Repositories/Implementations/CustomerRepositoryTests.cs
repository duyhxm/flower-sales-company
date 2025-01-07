using Microsoft.VisualStudio.TestTools.UnitTesting;
using DL.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Customer;
using System.Diagnostics;
using DTO.SalesOrder;

namespace DL.Repositories.Implementations.Tests
{
    [TestClass()]
    public class CustomerRepositoryTests
    {
        //[TestMethod()]
        //public async Task GetCustomerRankHistoryByQuarterAsyncTest()
        //{
        //    SystemRepository.Initialize();
        //    CustomerRepository repo = new CustomerRepository();

        //    List<CustomerRankHistoryDTO> r = await repo.GetCustomerRankHistoryByQuarterAsync(new List<int> { 1, 2, 3 }, 2024);

        //    Debug.WriteLine(r);
        //}

        [TestMethod()]
        public async Task GetSalesDataByQuarterAsyncTest()
        {
            SystemRepository.Initialize();

            CustomerRepository repo = new CustomerRepository();

            List<SalesStatisticsDataDTO> reports = await repo.GetSalesDataByQuarterAsync(new List<int> { 1, 2, 3}, 2024);

            Debug.WriteLine(reports);
        }
    }
}