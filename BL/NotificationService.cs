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
