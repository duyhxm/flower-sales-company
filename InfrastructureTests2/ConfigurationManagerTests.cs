﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Tests
{
    [TestClass]
    public class ConfigurationManagerTests
    {
        [TestMethod]
        public void GetServiceBusConnectionStringTest()
        {
            ConfigurationManager manager = new ConfigurationManager();
            manager.GetServiceBusConnectionString();
        }
    }
}