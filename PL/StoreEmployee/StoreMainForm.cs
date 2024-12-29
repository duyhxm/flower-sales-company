using Azure.Messaging.ServiceBus;
using BL;
using DL;
using System.Collections.Generic;
using Infrastructure;
using DTO.Store;

namespace PL
{
    public partial class StoreMainForm : System.Windows.Forms.Form, INotifiable
    {
        private static StoreMainForm? _instance;
        public Dictionary<string, Form> formInstances;
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

        private async void StoreMainForm_Load(object sender, EventArgs e)
        {
            await InitializeForms();
            NotificationManager.Instance.RegisterForm(this);
            MessageBox.Show($"StoreID: {StoreId} \n StoreName: {StoreName}");
        }

        private void StoreMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            NotificationManager.Instance.UnregisterForm(this);
        }

        private async Task InitializeForms()
        {
            //Khởi tạo InventoryForm. Form này sẽ chứa kho vật liệu và sản phẩm của cửa hàng
            InventoryForm.Initialize();
            formInstances["InventoryForm"] = InventoryForm.Instance;
            await InventoryForm.Instance.LoadMaterialInventory(StoreId);
            await InventoryForm.Instance.LoadProductInventory(StoreId);

            //Chuyển hai form này thành singleton
            formInstances["SalesOrderForm"] = new SalesOrderForm();
            formInstances["AccountInformationForm"] = new AccountInformationForm();
            formInstances["OrderCreationForm"] = new OrderCreationForm();


            //Khởi tạo ProductCreationForm, dùng để tạo product
            ProductCreationForm.Initialize();
            formInstances["ProductCreationForm"] = ProductCreationForm.Instance;

            //Khởi tạo OrderHistoryForm, dùng để xem lịch sử đơn hàng đã bán
            StoreEmployee.OrderHistoryForm.Initialize();
            formInstances["OrderHistoryForm"] = StoreEmployee.OrderHistoryForm.Instance;

            //Khởi tạo ProductList Form. Dùng để xem danh sách các sản phẩm mà phòng kinh doanh chỉ định cho cửa hàng để bán, hay gọi là danh sách các sản phẩm chủ đạo của cửa hàng
            StoreEmployee.ProductListForm.Initialize();
            formInstances["ProductListForm"] = StoreEmployee.ProductListForm.Instance;

            //Khởi tạo DailyTask Form. Dùng để xem các sản phẩm cần tạo mỗi ngày mà phòng kinh doanh đưa xuống cho cửa hàng
            StoreEmployee.DailyTaskForm.Initialize();
            formInstances["DailyTaskForm"] = StoreEmployee.DailyTaskForm.Instance;

            foreach (var form in formInstances.Values)
            {
                form.TopLevel = false;
                form.Dock = DockStyle.Fill;
            }
        }

        private void AddFormIntoPanel(Form form)
        {
            splConStoreMainForm.Panel2.Controls.Clear();
            splConStoreMainForm.Panel2.Controls.Add(form);
            form.Show();
        }

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            if (formInstances.ContainsKey("SalesOrderForm"))
            {
                AddFormIntoPanel(formInstances["SalesOrderForm"]);
            }
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            if (formInstances.ContainsKey("InventoryForm"))
            {
                AddFormIntoPanel(formInstances["InventoryForm"]);
            }
        }

        private void btnAccountInformation_Click(object sender, EventArgs e)
        {
            if (formInstances.ContainsKey("AccountInformationForm"))
            {
                AddFormIntoPanel(formInstances["AccountInformationForm"]);

                ((AccountInformationForm)formInstances["AccountInformationForm"]).DisplayInformation(LoginForm.Instance.LoginInformation);
            }
        }

        private void btnCreateProduct_Click(object sender, EventArgs e)
        {
            if (formInstances.ContainsKey("ProductCreationForm"))
            {
                AddFormIntoPanel(formInstances["ProductCreationForm"]);
            }
        }

        //Đang thử nghiệm phần này
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

        public void HandleNotification(Dictionary<string, object> message)
        {
            
            // Handle the notification and update the UI
            MessageBox.Show($"StoreMainForm received message: {message}");
        }

        private void btnProductList_Click(object sender, EventArgs e)
        {
            if (formInstances.ContainsKey("ProductListForm"))
            {
                AddFormIntoPanel(formInstances["ProductListForm"]);
            }
        }

        private void btnPreOrderList_Click(object sender, EventArgs e)
        {
            if (formInstances.ContainsKey("PreoderListForm"))
            {
                AddFormIntoPanel(formInstances["PreorderListForm"]);
            }
        }

        private void btnOrderHistory_Click(object sender, EventArgs e)
        {
            if (formInstances.ContainsKey("OrderHistoryForm"))
            {
                AddFormIntoPanel(formInstances["OrderHistoryForm"]);
            }
        }

        private void btnDailyTask_Click(object sender, EventArgs e)
        {
            if (formInstances.ContainsKey("DailyTaskForm"))
            {
                AddFormIntoPanel(formInstances["DailyTaskForm"]);
            }
        }
    }

}
