using BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;


namespace Infrastructure.Tests
{
    [TestClass()]
    public class ServiceBusManagerTests
    {
        [TestMethod()]
        public void ServiceBusManagerTest()
        {
            string? connectionString = new ConfigurationManager().GetServiceBusConnectionString();
           ServiceBusManager mng = new ServiceBusManager(connectionString);
        }
    }
}