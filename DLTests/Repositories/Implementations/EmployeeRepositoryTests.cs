using Microsoft.VisualStudio.TestTools.UnitTesting;
using DL.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Repositories.Implementations.Tests
{
    [TestClass()]
    public class EmployeeRepositoryTests
    {
        private EmployeeRepository repo = new EmployeeRepository();
        [TestMethod()]
        public void GetJobTitleTest()
        {
            string? re = repo.GetJobTitle("PTE0000005");
        }

        [TestMethod()]
        public async Task GetStoreIDTest()
        {
            string? storeId = await repo.GetStoreID("PTE0000001");
        }
    }
}