using Azure.Messaging.ServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using DTO;

namespace Infrastructure
{
    public class ServiceBusManager
    {
        private readonly string _connectionString;
        private ServiceBusClient _client;
        private ServiceBusSessionProcessor? _processor;
        public event EventHandler<DataChangedEventArgs> DataChanged;

        //Khởi tạo ServicesBusClient với connection string
        public ServiceBusManager(string connectionString)
        {
            _connectionString = connectionString;
            try
            {
                _client = new ServiceBusClient(_connectionString);
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

        public async Task MessageHandler(ProcessSessionMessageEventArgs args)
        {
            // Xử lý message nhận được.
            string body = args.Message.Body.ToString();
            IReadOnlyDictionary<string, object> extraInfo = args.Message.ApplicationProperties;
            string tableName = string.Empty;
            int affectedRows = 0;
            string operationName = string.Empty;

            foreach(KeyValuePair<string, object> kvp in extraInfo)
            {
                if(kvp.Key == "TableName")
                {
                    tableName = kvp.Value.ToString() ?? throw new Exception("table name is null");
                }
                if(kvp.Key == "OperationName")
                {
                    operationName = kvp.Value.ToString() ?? throw new Exception("operation name is null");
                }
                if(kvp.Key == "AffectedRows")
                {
                    affectedRows = (int?)kvp.Value ?? throw new Exception("affected rows is null");
                }
            }

            DataChangedEventArgs arg = new DataChangedEventArgs()
            {
                Message = body,
                TableName = tableName,
                AffectedRows = affectedRows,
                OperationName = operationName
            };

            Debug.WriteLine($"Received message: {body}");
            
            //Khởi phát sự kiện để thông báo đến các subscribers
            OnDataChanged(arg);

            await args.CompleteMessageAsync(args.Message);
        }

        private Task ErrorHandler(ProcessErrorEventArgs args)
        {
            // Xử lý lỗi.
            Debug.WriteLine($"Error: {args.Exception.Message}");
            return Task.CompletedTask;
        }

        public async Task SendMessageAsync(string topicName, ServiceBusMessage message)
        {
            ServiceBusSender sender = _client.CreateSender(topicName);

            await sender.SendMessageAsync(message);

            Debug.WriteLine("Message sent to Service Bus.");
        }

        //Huỷ ServiceBusClient
        public async Task ShutdownAsync()
        {
            if (_processor != null) await _processor.CloseAsync();
            if (_client != null) await _client.DisposeAsync();
            Debug.WriteLine("ServiceBusManager shutdown completed.");
        }

        protected virtual void OnDataChanged(DataChangedEventArgs e)
        {
            if (DataChanged != null)
            {
                Debug.WriteLine("Raising DataChanged event.");
                DataChanged.Invoke(this, e);
            }
            else
            {
                Debug.WriteLine("No subscribers for DataChanged event.");
            }
            
        }
    }
}


