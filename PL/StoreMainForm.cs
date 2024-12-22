using Azure.Messaging.ServiceBus;
using BL;
using DL;
using System.Collections.Generic;
using Infrastructure;

namespace PL
{
    public partial class StoreMainForm : Form, INotifiable
    {
        private Dictionary<string, Form> formInstances;
        private NotificationService _notificationService;

        public StoreMainForm()
        {
            InitializeComponent();
            formInstances = new Dictionary<string, Form>();
            _notificationService = NotificationServiceSingleton.Instance;
        }

        private void StoreMainForm_Load(object sender, EventArgs e)
        {
            NotificationManager.Instance.RegisterForm(this);
        }

        private void StoreMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            NotificationManager.Instance.UnregisterForm(this);
        }

        public void HandleNotification(Dictionary<string, object> message)
        {
            // Handle the notification and update the UI
            MessageBox.Show($"StoreMainForm received message: {message}");
        }

        private void addFormInPanel(string formName, Form form)
        {
            splConStoreMainForm.Panel2.Controls
                .Clear();

            if (!formInstances.ContainsKey(formName))
            {
                form.TopLevel = false;
                form.Dock = DockStyle.Fill;
                formInstances[formName] = form;
            }

            splConStoreMainForm.Panel2.Controls.Add(formInstances[formName]);
            formInstances[formName].Show();
        }

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            SalesOrderForm orderForm = new SalesOrderForm();

            addFormInPanel("SalesOrderForm", orderForm);
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            InventoryForm inventoryForm = new InventoryForm();

            addFormInPanel("InventoryForm", inventoryForm);
        }

        private async void btnTestServiceBus_Click(object sender, EventArgs e)
        {
            await SendMessageToServiceBusTest();
        }
        private async Task SendMessageToServiceBusTest()
        {
            IDictionary<string, object> applicationProperties = new Dictionary<string, object>()
            {
                {"Action", "Insert"}
            };
            ServiceBusMessage message = _notificationService.CreateMessage("test", "1234", "Database Change Notification", applicationProperties);

            try
            {
                await _notificationService.NotifyDatabaseOperationAsync(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Message: {ex.Message} \n Stack trace: {ex.StackTrace}");
            }

        }
    }

}
