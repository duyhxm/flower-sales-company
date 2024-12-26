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
using DL.Repositories.Implementations;

namespace BL
{
    public class NotificationService
    {
        private static NotificationService? _instance;
        private static readonly object _lock = new object();
        private readonly ServiceBusManager _serviceBusManager;
        private readonly string _topicName;
        public event EventHandler<DataChangedEventArgs> MessageReceived;

        private NotificationService(string topicName)
        {
            try
            {
                _serviceBusManager = SystemRepository.Instance.ServiceBusManager;
                _topicName = topicName;
                _serviceBusManager.DataChanged += OnMessageReceived;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static NotificationService Instance
        {
            get
            {
                if (_instance == null)
                {
                    throw new InvalidOperationException("NotificationService is not initialized. Call Initialize() first.");
                }
                return _instance;
            }
        }

        public static void Initialize(string topicName)
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    try
                    {
                        _instance = new NotificationService(topicName);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }

        public async Task NotifyDatabaseOperationAsync(ServiceBusMessage message)
        {
            try
            {
                await _serviceBusManager.SendMessageAsync(_topicName, message);
            }
            catch(Exception)
            {
                throw;
            } 
        }

        private void OnMessageReceived(object? sender, DataChangedEventArgs e)
        {
            Debug.WriteLine($"Processing message: {e.Message}");
            MessageReceived?.Invoke(this, e);
        }

        public ServiceBusMessage CreateMessage(string message, string sessionId, string subject, IDictionary<string, object> applicationProperties)
        {
            ServiceBusMessage serviceBusMessage = new ServiceBusMessage(message)
            {
                SessionId = sessionId,
                Subject = subject,
            };

            foreach (var property in applicationProperties)
            {
                serviceBusMessage.ApplicationProperties[property.Key] = property.Value;
            }

            return serviceBusMessage;
        }
    }
}
