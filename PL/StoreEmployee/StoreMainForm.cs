﻿using Azure.Messaging.ServiceBus;
using BL;
using System.Collections.Generic;
using DTO.Store;
using PL.StoreEmployee;
using static BL.GeneralService;
using DTO.Enum;
using System.Diagnostics;

namespace PL
{
    public partial class StoreMainForm : Form, INotifiable
    {
        private static StoreMainForm? _instance;
        public Dictionary<string, Form> formInstances;
        public NotificationService NotificationService { get; private set; }
        public string? StoreId { get; private set; }
        public string? StoreName { get; private set; }

        private bool isLoadData = false;

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
        }

        private void StoreMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            NotificationManager.Instance.UnregisterForm(this);
        }

        private async Task InitializeForms()
        {
            isLoadData = true;
            //Khởi tạo InventoryForm. Form này sẽ chứa kho vật liệu và sản phẩm của cửa hàng
            InventoryForm.Initialize();
            formInstances[InventoryForm.Instance.Name] = InventoryForm.Instance;
            await InventoryForm.Instance.LoadMaterialInventory(StoreId);
            await InventoryForm.Instance.LoadProductInventory(StoreId);

            //SalesOrder
            SalesOrderForm.Initialize();
            formInstances[SalesOrderForm.Instance.Name] = SalesOrderForm.Instance;

            //khởi tạo AccountInformationForm
            AccountInformationForm.Initialize();
            formInstances[AccountInformationForm.Instance.Name] = AccountInformationForm.Instance;

            //Khởi tạo ProductCreationForm, dùng để tạo product
            ProductCreationForm.Initialize(NotificationService);
            formInstances[ProductCreationForm.Instance.Name] = ProductCreationForm.Instance;

            //Khởi tạo OrderHistoryForm, dùng để xem lịch sử đơn hàng đã bán
            OrderHistoryForm.Initialize();
            formInstances[OrderHistoryForm.Instance.Name] = OrderHistoryForm.Instance;
            await OrderHistoryForm.Instance.LoadSalesOrders(StoreId!, LocalDateTimeOffset());

            //Khởi tạo ProductList Form. Dùng để xem danh sách các sản phẩm mà phòng kinh doanh chỉ định cho cửa hàng để bán, hay gọi là danh sách các sản phẩm chủ đạo của cửa hàng
            ProductListForm.Initialize();
            formInstances[ProductListForm.Instance.Name] = ProductListForm.Instance;

            //Khởi tạo DailyTask Form. Dùng để xem các sản phẩm cần tạo mỗi ngày mà phòng kinh doanh đưa xuống cho cửa hàng
            DailyTaskForm.Initialize();
            formInstances[DailyTaskForm.Instance.Name] = DailyTaskForm.Instance;
            await DailyTaskForm.Instance.LoadPlannedProducts(DateTime.Now.Date, LoginForm.Instance.LoginInformation.StoreID!, PlanStatus.Initialized);

            foreach (var form in formInstances.Values)
            {
                form.TopLevel = false;
                form.Dock = DockStyle.Fill;
            }

            isLoadData = false;

            MessageBox.Show("Dữ liệu đã được tải lên hoàn tất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AddFormIntoPanel(Form form)
        {
            splConStoreMainForm.Panel2.Controls.Clear();
            splConStoreMainForm.Panel2.Controls.Add(form);
            form.Show();
        }

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            if (isLoadData) return;

            if (formInstances.ContainsKey(SalesOrderForm.Instance.Name))
            {
                AddFormIntoPanel(formInstances[SalesOrderForm.Instance.Name]);
            }
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            if (isLoadData) return;

            if (formInstances.ContainsKey(InventoryForm.Instance.Name))
            {
                AddFormIntoPanel(formInstances[InventoryForm.Instance.Name]);
            }
        }

        private void btnAccountInformation_Click(object sender, EventArgs e)
        {
            if (isLoadData) return;

            if (formInstances.ContainsKey(AccountInformationForm.Instance.Name))
            {
                AddFormIntoPanel(formInstances[AccountInformationForm.Instance.Name]);

                ((AccountInformationForm)formInstances[AccountInformationForm.Instance.Name]).DisplayInformation(LoginForm.Instance.LoginInformation);
            }
        }

        private void btnCreateProduct_Click(object sender, EventArgs e)
        {
            if (isLoadData) return;

            if (formInstances.ContainsKey(ProductCreationForm.Instance.Name))
            {
                AddFormIntoPanel(formInstances[ProductCreationForm.Instance.Name]);
            }
        }

        private void btnOrderHistory_Click(object sender, EventArgs e)
        {
            if (isLoadData) return;

            if (formInstances.ContainsKey(OrderHistoryForm.Instance.Name))
            {
                AddFormIntoPanel(formInstances[OrderHistoryForm.Instance.Name]);
            }
        }

        private void btnProductList_Click(object sender, EventArgs e)
        {
            if (isLoadData) return;

            if (formInstances.ContainsKey(ProductListForm.Instance.Name))
            {
                AddFormIntoPanel(formInstances[ProductListForm.Instance.Name]);
            }
        }

        private void btnDailyTask_Click(object sender, EventArgs e)
        {
            if (isLoadData) return;

            if (formInstances.ContainsKey(DailyTaskForm.Instance.Name))
            {
                AddFormIntoPanel(formInstances[DailyTaskForm.Instance.Name]);
            }
        }

        public async Task HandleNotification(Dictionary<string, object> message)
        {
            await InventoryForm.Instance.LoadMaterialInventory(LoginForm.Instance.LoginInformation.StoreID!);

            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    MessageBox.Show("Dữ liệu trong kho vật liệu vừa được cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }));
            }
            else
            {
                MessageBox.Show("Dữ liệu trong kho vật liệu vừa được cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void NotificationBellVisibility(bool value)
        {
            picBoxNotificationBell.Visible = value;
        }
    }

}
