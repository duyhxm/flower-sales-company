using BL;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class NotificationServiceSingleton
    {
        private static NotificationService? _instance;
        private static readonly object _lock = new object();

        private NotificationServiceSingleton() { }

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

        public static void Initialize(ServiceBusManager serviceBusManager, string topicName)
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new NotificationService(serviceBusManager, topicName);
                    }
                }
            }
        }
    }
}
