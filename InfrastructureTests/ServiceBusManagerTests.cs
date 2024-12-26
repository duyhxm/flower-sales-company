using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;
using Azure.Messaging.ServiceBus;
using System.Diagnostics;
using BL;
using Moq;

namespace Infrastructure.Tests
{
    [TestClass()]
    public class ServiceBusManagerTests
    {
        [TestMethod()]
        public async Task ServiceBusManagerTest()
        {
            //ConfigurationManager config = new ConfigurationManager();
            //string serviceBusConnectionString = new ConfigurationManager().GetServiceBusConnectionString();

            //NotificationService notificationService;

            //ServiceBusManager serviceBus = new ServiceBusManager(serviceBusConnectionString);
            //notificationService = new NotificationService(serviceBus, "DataChanges");

            //ServiceBusMessage message = new ServiceBusMessage("test")
            //{
            //    SessionId = "1234",
            //    Subject = "Database Change Notification",
            //    ApplicationProperties = { { "Action", "Insert" } }
            //};

            //await serviceBus.SendMessageAsync("DataChanges", message);
            //serviceBus.InitializeSessionProcessor("DataChanges", "UserA_Subscription");
        }
    }
}