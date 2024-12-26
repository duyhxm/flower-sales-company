using Microsoft.VisualStudio.TestTools.UnitTesting;
using DL.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Employee;
using DTO;
using System.Diagnostics;

namespace DL.Repositories.Implementations.Tests
{
    [TestClass()]
    public class SystemRepositoryTests
    {
        [TestMethod()]
        public async Task<UserAccountDTO?> LoginAsyncTest()
        {
            SystemRepository.Initialize();
            SystemRepository repo = SystemRepository.Instance;

            UserAccountDTO testAcc = new UserAccountDTO()
            {
                Username = "storeemp",
                Password = "123"
            };
            return await repo.LoginAsync(testAcc);
        }

        [TestMethod()]
        public async Task GetExtraLoginInfoTest()
        {
            SystemRepository.Initialize();
            SystemRepository repo = SystemRepository.Instance;

            LoginInformation? info;
            UserAccountDTO? acc = await LoginAsyncTest();

            if (acc != null)
            {
                info = await repo.GetExtraLoginInfo(acc);
                Debug.WriteLine(info?.StoreName);
            }
        }
    }
}