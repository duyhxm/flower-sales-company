using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class NotificationManager
    {
        private static NotificationManager _instance;
        private Form _activeForm;

        private NotificationManager() { }

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

        public void Notify(string message)
        {
            if (_activeForm is INotifiable notifiableForm)
            {
                notifiableForm.HandleNotification(message);
            }
        }

        public void SubscribeToNotificationService(NotificationService notificationService)
        {
            notificationService.MessageReceived += (sender, message) => Notify(message);
        }
    }
}
