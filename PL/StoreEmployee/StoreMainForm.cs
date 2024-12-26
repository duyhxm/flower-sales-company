using Azure.Messaging.ServiceBus;
using BL;
using DL;
using System.Collections.Generic;
using Infrastructure;
using DTO.Store;

namespace PL
{
    public partial class StoreMainForm : Form, INotifiable
    {
        private static StoreMainForm? _instance;
        private Dictionary<string, Form> formInstances;
        public NotificationService NotificationService { get; private set; }
        public string? StoreId { get; private set; }
        public string? StoreName { get; private set; }

        public StoreMainForm()
        {
            InitializeComponent();
            _instance = this;

            StoreId = LoginForm.Instance.LoginInformation.StoreID;
            StoreName = LoginForm.Instance.LoginInformation.StoreName;

            formInstances = new Dictionary<string, Form>();
            NotificationService = NotificationService.Instance;
        }

        public static StoreMainForm Instance
        {
            get
            {
                return _instance!;
            }
        }

        private void StoreMainForm_Load(object sender, EventArgs e)
        {
            NotificationManager.Instance.RegisterForm(this);
            MessageBox.Show($"StoreID: {StoreId} \n StoreName: {StoreName}");
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

        private void AddFormIntoPanel(string formName, Form form)
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

            AddFormIntoPanel("SalesOrderForm", orderForm);
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            InventoryForm inventoryForm = new InventoryForm();

            AddFormIntoPanel("InventoryForm", inventoryForm);
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
            ServiceBusMessage message = NotificationService.CreateMessage("test", "1234", "Database Change Notification", applicationProperties);

            try
            {
                await NotificationService.NotifyDatabaseOperationAsync(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Message: {ex.Message} \n Stack trace: {ex.StackTrace}");
            }

        }

        private void btnAccountInformation_Click(object sender, EventArgs e)
        {
            AccountInformationForm accountInformationForm = new AccountInformationForm();
            AddFormIntoPanel("AccountInformationForm", accountInformationForm);

            accountInformationForm.DisplayInformation(LoginForm.Instance.LoginInformation);
        }

        private void btnCreateProduct_Click(object sender, EventArgs e)
        {
            ProductCreationForm productCreationForm = new ProductCreationForm();
            AddFormIntoPanel("ProductCreationForm", productCreationForm);
        }
    }

}
