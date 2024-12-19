using System.ComponentModel;

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
        public void Stop()
        {
            if (_backgroundWorker.WorkerSupportsCancellation)
            {
                _backgroundWorker.CancelAsync();
            }

            _serviceBusManager.ShutdownAsync().Wait();
        }

        // Logic chạy trong nền
        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;

            if (worker == null || worker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            if (e.Argument == null)
            {
                e.Cancel = true;
                return;
            }

            dynamic args = e.Argument;
            string topicName = args.TopicName;
            string subscriptionName = args.SubscriptionName;

            _serviceBusManager.InitializeSessionProcessor(topicName, subscriptionName);
        }
    }
}
