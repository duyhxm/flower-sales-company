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
        private static NotificationManager _instance;
        private Form? _activeForm;
        private NotificationService _notificationService;

        public NotificationManager(NotificationService notificationService)
        {
            _notificationService = notificationService;
            _notificationService.MessageReceived += OnNotificationReceived;
        }

        public NotificationManager() { }
        public static NotificationManager Instance => _instance ??= new NotificationManager();

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

        public void SubscribeToNotificationService(NotificationService notificationService)
        {
            notificationService.MessageReceived += (sender, message) =>
            {
                Dictionary<string, object> formattedMessage = new Dictionary<string, object>();

                formattedMessage.Add("Message", message.Message);
                formattedMessage.Add("OperationName", message.OperationName);
                formattedMessage.Add("TableName", message.TableName);
                formattedMessage.Add("AffectedRows", message.AffectedRows);

                Notify(formattedMessage);
            };
        }

        public void OnNotificationReceived(object sender, DataChangedEventArgs e)
        {
            Dictionary<string, object> formattedMessage = new Dictionary<string, object>();

            formattedMessage.Add("Message", e.Message);
            formattedMessage.Add("OperationName", e.OperationName);
            formattedMessage.Add("TableName", e.TableName);
            formattedMessage.Add("AffectedRows", e.AffectedRows);

            Notify(formattedMessage);
        }
    }
}
