using System.ComponentModel;
using System.Diagnostics;

namespace Infrastructure
{
    public class ServiceBusHost
    {
        private readonly ServiceBusManager _serviceBusManager;
        private readonly BackgroundWorker _backgroundWorker;

        public ServiceBusHost(ServiceBusManager serviceBusManager)
        {
            _serviceBusManager = serviceBusManager;
            _backgroundWorker = new BackgroundWorker
            {
                WorkerSupportsCancellation = true
            };

            _backgroundWorker.DoWork += BackgroundWorker_DoWork;
        }

        // Khởi động các dịch vụ nền
        public void Start(string topicName, string subscriptionName)
        {
            // Khởi chạy Background Worker
            if (!_backgroundWorker.IsBusy)
            {
                _backgroundWorker.RunWorkerAsync(new { TopicName = topicName, SubscriptionName = subscriptionName });
            }
        }

        // Dừng các dịch vụ nền
        public async Task StopAsync()
        {
            if (_backgroundWorker.WorkerSupportsCancellation)
            {
                _backgroundWorker.CancelAsync();
            }

            await _serviceBusManager.ShutdownAsync();
        }

        // Logic chạy trong nền
        private void BackgroundWorker_DoWork(object? sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;

            if (worker == null || worker.CancellationPending)
            {
                e.Cancel = true;
                Debug.WriteLine("BackgroundWorker is being cancelled.");
                return;
            }

            if (e.Argument == null)
            {
                e.Cancel = true;
                Debug.WriteLine("No arguments provided to BackgroundWorker.");
                return;
            }

            dynamic args = e.Argument;
            string topicName = args.TopicName;
            string subscriptionName = args.SubscriptionName;

            Debug.WriteLine("BackgroundWorker is starting ServiceBusManager.");
            _serviceBusManager.InitializeSessionProcessor(topicName, subscriptionName);
        }
    }
}
