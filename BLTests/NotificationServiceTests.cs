using Microsoft.VisualStudio.TestTools.UnitTesting;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using DL.Repositories.Implementations;

namespace BL.Tests
{
    [TestClass()]
    public class NotificationServiceTests
    {
        [TestMethod()]
        public async Task NotifyDatabaseOperationAsyncTest()
        {
            SystemRepository.Initialize();
            SystemRepository system = SystemRepository.Instance;


            List<string> topics = new List<string>() { "DataChanges", "Store001"};
            NotificationService.Initialize(topics);

            NotificationService service = NotificationService.Instance;

            IDictionary<string, object> filters = new Dictionary<string, object>()
            {
                { "Action", "Test" },
                { "Location", "DongNai"}
            };

            ServiceBusMessage message = service.CreateMessage("Gửi thử mesage", "1234", "Test" , filters);

            await service.NotifyDatabaseOperationAsync(message, "Store001");
        }
    }
}