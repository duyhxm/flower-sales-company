using BL;
using DL;
using System.Collections.Generic;

namespace PL
{
    public partial class StoreMainForm : Form, INotifiable
    {
        private Dictionary<string, Form> formInstances;
        //private readonly NotificationService _notificationService;

        public StoreMainForm()
        {
            InitializeComponent();

            formInstances = new Dictionary<string, Form>();
            //var functionNames = new List<string> {"dbo.fn_getProduct()"};
            //_notificationService = new NotificationService(functionNames);

            //_notificationService.Notification += OnNotification;

            //_notificationService.StartTracking();
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
            MessageBox.Show($"CEOMainForm received message: {message}");
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

        private void btnTestServiceBus_Click(object sender, EventArgs e)
        {
            new LoginForm().Perform();
        }
        //private void OnNotification(object sender, DataChangedEventArgs e)
        //{
        //    Invoke((Action)(() =>
        //    {
        //        switch (e.FunctionName)
        //        {
        //            case "dbo.GetOrder":
        //                HandleOrderChange(e);
        //                break;
        //            case "dbo.GetProduct":
        //                HandleProductChange(e);
        //                break;
        //            case "dbo.GetCustomer":
        //                HandleCustomerChange(e);
        //                break;
        //        }
        //    }));
        //}

        //private void HandleOrderChange(DataChangedEventArgs e)
        //{
        //    // Handle order updates
        //    MessageBox.Show("Order data has changed!");
        //}

        //private void HandleProductChange(DataChangedEventArgs e)
        //{
        //    // Handle product updates
        //    MessageBox.Show("Product data has changed!");
        //}

        //private void HandleCustomerChange(DataChangedEventArgs e)
        //{
        //    // Handle customer updates
        //    MessageBox.Show("Customer data has changed!");
        //}
    }

}
