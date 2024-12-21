using DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Infrastructure;
using Azure.Messaging.ServiceBus;
using DTO;

namespace BL
{
    public class NotificationService
    {
        //private readonly DataProvider _dataProvider;
        //private readonly Dictionary<string, Repository> _repositories;
        //public event EventHandler<DataChangedEventArgs> Notification;

        //public NotificationService(IEnumerable<String> functionNames)
        //{
        //    _dataProvider = new DataProvider();

        //    _repositories = new Dictionary<string, Repository>();
        //    foreach (var functionName in functionNames)
        //    {
        //        var repository = new Repository(_dataProvider);
        //        repository.DataChanged += OnDataChanged;
        //        _repositories[functionName] = repository;
        //    }
        //}

        //public void StartTracking()
        //{
        //    foreach (var functionName in _repositories.Keys)
        //    {
        //        var repo = _repositories[functionName];
        //        if (repo != null)
        //        {
        //            repo.TrackChanges(functionName);
        //        }
        //        else
        //        {
        //            // Handle the case where the repository is null
        //            Debug.WriteLine($"Repository for function '{functionName}' is null.");
        //        }
        //    }
        //}

        //private void OnDataChanged(object sender, DataChangedEventArgs e)
        //{
        //    Notification?.Invoke(this, e);
        //}

        private readonly ServiceBusManager _serviceBusManager;
        private readonly string _topicName;

        public event EventHandler<DataChangedEventArgs> MessageReceived;

        public NotificationService(ServiceBusManager serviceBusManager, string topicName)
        {
            _serviceBusManager = serviceBusManager;
            _topicName = topicName;
            _serviceBusManager.DataChanged += OnMessageReceived;
        }

        public async Task NotifyDatabaseOperationAsync(ServiceBusMessage message)
        {
            await _serviceBusManager.SendMessageAsync(_topicName, message);
        }

        private void OnMessageReceived(object sender, DataChangedEventArgs e)
        {
            Debug.WriteLine($"Processing message: {e.Message}");
            MessageReceived?.Invoke(this, e);
        }
    }
}
