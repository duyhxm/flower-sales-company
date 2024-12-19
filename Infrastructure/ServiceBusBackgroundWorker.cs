using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ServiceBusBackgroundWorker
    {
        private readonly ServiceBusManager _serviceBusManager;
        private Thread? _workerThread;

        public ServiceBusBackgroundWorker(ServiceBusManager serviceBusManager)
        {
            _serviceBusManager = serviceBusManager;
        }

        public void Start()
        {
            _workerThread = new Thread(Run);
            _workerThread.IsBackground = true;
            _workerThread.Start();
        }

        private void Run()
        {
            // Lắng nghe Service Bus.
            _serviceBusManager.InitializeSessionProcessor("topicName", "subscriptionName");
        }

        public async Task StopAsync()
        {
            // Dừng lắng nghe.
            await _serviceBusManager.ShutdownAsync();
        }
    }
}