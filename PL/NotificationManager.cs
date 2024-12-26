using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Windows.Forms;

namespace PL
{
    public class NotificationManager
    {
        private static NotificationManager? _instance;
        private static readonly object _lock = new object();
        private Form? _activeForm;
        private NotificationService _notificationService;

        // Private constructor to prevent direct instantiation
        private NotificationManager(NotificationService notificationService)
        {
            _notificationService = notificationService;
            _notificationService.MessageReceived += OnNotificationReceived;
        }

        // Public static method to initialize the singleton instance
        public static void Initialize()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new NotificationManager(NotificationService.Instance);
                    }
                }
            }
        }

        // Singleton instance property
        public static NotificationManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    throw new InvalidOperationException("NotificationManager is not initialized. Call Initialize() first.");
                }
                return _instance;
            }
        }

        public void RegisterForm(Form form)
        {
            _activeForm = form;
        }

        public void UnregisterForm(Form form)
        {
            if (_activeForm == form)
            {
                _activeForm = null;
            }
        }

        public void Notify(Dictionary<string, object> message)
        {
            if (_activeForm is INotifiable notifiableForm)
            {
                notifiableForm.HandleNotification(message);
            }
        }

        public void OnNotificationReceived(object? sender, DataChangedEventArgs e)
        {
            Dictionary<string, object> formattedMessage = new Dictionary<string, object>()
            {
                { "Message", e.Message},
                { "OperationName", e.OperationName},
                { "TableName", e.TableName},
                { "AffectedRows", e.AffectedRows }
            };

            Notify(formattedMessage);
        }
    }
}
