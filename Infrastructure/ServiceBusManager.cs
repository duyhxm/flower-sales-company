using Azure.Messaging.ServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Infrastructure
{
    public class ServiceBusManager
    {
        private readonly string _serviceBusConnectionString;
        private ServiceBusClient _client;
        private ServiceBusSessionProcessor? _processor;
        public event EventHandler<string> MessageReceived;

        public ServiceBusManager(string serviceBusConnectionString)
        {
            _serviceBusConnectionString = serviceBusConnectionString;
            try
            {
                _client = new ServiceBusClient(_serviceBusConnectionString);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InitializeSessionProcessor(string topicName, string subscriptionName)
        {
            _processor = _client.CreateSessionProcessor(topicName, subscriptionName, new ServiceBusSessionProcessorOptions());

            _processor.ProcessMessageAsync += MessageHandler;
            _processor.ProcessErrorAsync += ErrorHandler;

            _processor.StartProcessingAsync();
        }

        private Task MessageHandler(ProcessSessionMessageEventArgs args)
        {
            // Xử lý message nhận được.
            string body = args.Message.Body.ToString();
            Debug.WriteLine($"Received message: {body}");
            MessageReceived?.Invoke(this, body);
            return Task.CompletedTask;
        }

        private Task ErrorHandler(ProcessErrorEventArgs args)
        {
            // Xử lý lỗi.
            Console.WriteLine($"Error: {args.Exception.Message}");
            return Task.CompletedTask;
        }

        public async Task SendMessageAsync(string topicName, string messageBody)
        {
            ServiceBusSender sender = _client.CreateSender(topicName);
            ServiceBusMessage message = new ServiceBusMessage(messageBody);

            await sender.SendMessageAsync(message);

            Debug.WriteLine("Message sent to Service Bus.");
        }

        public async Task ShutdownAsync()
        {
            if (_processor != null) await _processor.CloseAsync();
            if (_client != null) await _client.DisposeAsync();
        }
    }
}


