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
        private readonly List<string> _topicNames = new();
        public event EventHandler<DataChangedEventArgs> MessageReceived;

        private NotificationService(List<string> topicName)
        {
            try
            {
                _serviceBusManager = SystemRepository.Instance.ServiceBusManager;
                _topicNames = topicName;
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

        public static void Initialize(List<string> topicNames)
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    try
                    {
                        _instance = new NotificationService(topicNames);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }

        public async Task NotifyDatabaseOperationAsync(ServiceBusMessage message, string topicName)
        {
            try
            {
                if (_topicNames.Contains(topicName))
                {
                    await _serviceBusManager.SendMessageAsync(topicName, message);
                }
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

        public ServiceBusMessage CreateMessage(string message, string sessionId, string subject, IDictionary<string, object> applicationProperties, TimeSpan timeToLive = default)
        {
            if (timeToLive == default)
            {
                timeToLive = TimeSpan.FromMinutes(1);
            }

            ServiceBusMessage serviceBusMessage = new ServiceBusMessage(message)
            {
                SessionId = sessionId,
                Subject = subject,
                TimeToLive = timeToLive,
            };

            foreach (var property in applicationProperties)
            {
                serviceBusMessage.ApplicationProperties[property.Key] = property.Value;
            }

            return serviceBusMessage;
        }
    }
}
