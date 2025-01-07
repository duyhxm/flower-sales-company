using BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using Infrastructure;
using PL.SalesEmployee;

namespace PL
{
    public partial class SalesDeptMainForm : Form, INotifiable
    {
        //Cấu hình khởi tạo đối tượng
        private static SalesDeptMainForm? _instance;
        private static readonly object _lock = new object();

        //khai báo các dịch vụ 
        private NotificationService NotificationService;

        //khai báo các biến sử dụng
        private Dictionary<string, Form> formInstances = new();

        private bool _isLoadData = false;
        private SalesDeptMainForm()
        {
            InitializeComponent();
            NotificationService = NotificationService.Instance;
            InitializeForms();
        }

        public static void Initialize()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    try
                    {
                        _instance = new SalesDeptMainForm();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }

        public static SalesDeptMainForm Instance
        {
            get
            {
                if (_instance == null)
                {
                    throw new InvalidOperationException("SalesDepartmentMainForm is not initialized. Call Initialize() first.");
                }
                return _instance;
            }
        }

        private void SalesDepartmentMainForm_Load(object sender, EventArgs e)
        {
            NotificationManager.Instance.RegisterForm(this);
        }

        private void SalesDepartmentMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            NotificationManager.Instance.UnregisterForm(this);
        }

        private void InitializeForms()
        {
            _isLoadData = true;

            //1. Khởi tạo MaterialDistributionForm
            MaterialDistributionForm.Initialize();
            formInstances[MaterialDistributionForm.Instance.Name] = MaterialDistributionForm.Instance;

            //2. Khởi tạo ProductCreationForm, dùng để tạo product
            AbstractProductCreationForm.Initialize();
            formInstances[AbstractProductCreationForm.Instance.Name] = AbstractProductCreationForm.Instance;

            //3. Khởi tạo ProductPlanForm
            ProductPlanForm.Initialize();
            formInstances[ProductPlanForm.Instance.Name] = ProductPlanForm.Instance;

            //4. Khởi tạo MaterialAdjustmentForm
            MaterialAdjustmentForm.Initialize();
            formInstances[MaterialAdjustmentForm.Instance.Name] = MaterialAdjustmentForm.Instance;

            //5. Khởi tạo CustomerForm
            CustomerForm.Initialize();
            formInstances[CustomerForm.Instance.Name] = CustomerForm.Instance;

            //6. Khởi tạo SaleHistoryForm
            SalesHistoryForm.Initialize();
            formInstances[SalesHistoryForm.Instance.Name] = SalesHistoryForm.Instance;

            //7. Khởi tạo AccountInformationForm
            AccountInformationForm.Initialize();
            formInstances[AccountInformationForm.Instance.Name] = AccountInformationForm.Instance;

            foreach (var form in formInstances.Values)
            {
                form.TopLevel = false;
                form.Dock = DockStyle.Fill;
            }

            _isLoadData = false;
        }

        private void AddFormIntoPanel(Form form)
        {
            splConSalesDeptMainForm.Panel2.Controls.Clear();
            splConSalesDeptMainForm.Panel2.Controls.Add(form);
            form.Show();
        }

        private void btnCreateMaterialDistribution_Click(object sender, EventArgs e)
        {
            if (_isLoadData) return;
            
            if (formInstances.ContainsKey(MaterialDistributionForm.Instance.Name))
            {
                AddFormIntoPanel(formInstances[MaterialDistributionForm.Instance.Name]);
            }
        }

        private void btnCreateProduct_Click(object sender, EventArgs e)
        {
            if (_isLoadData) return;

            if (formInstances.ContainsKey(AbstractProductCreationForm.Instance.Name))
            {
                AddFormIntoPanel(formInstances[AbstractProductCreationForm.Instance.Name]);
            }
        }

        private void btnCreateProductPlan_Click(object sender, EventArgs e)
        {
            if (_isLoadData) return;

            if (formInstances.ContainsKey(ProductPlanForm.Instance.Name))
            {
                AddFormIntoPanel(formInstances[ProductPlanForm.Instance.Name]);
            }
        }

        private void btnAdjustPrice_Click(object sender, EventArgs e)
        {
            if (_isLoadData) return;

            if (formInstances.ContainsKey(MaterialAdjustmentForm.Instance.Name))
            {
                AddFormIntoPanel(formInstances[MaterialAdjustmentForm.Instance.Name]);
            }
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            if (_isLoadData) return;

            if (formInstances.ContainsKey(CustomerForm.Instance.Name))
            {
                AddFormIntoPanel(formInstances[CustomerForm.Instance.Name]);
            }
        }

        private void btnSalesHistory_Click(object sender, EventArgs e)
        {
            if (_isLoadData) return;

            if (formInstances.ContainsKey(SalesHistoryForm.Instance.Name))
            {
                AddFormIntoPanel(formInstances[SalesHistoryForm.Instance.Name]);
            }
        }

        private void btnAccountInformation_Click(object sender, EventArgs e)
        {
            if (_isLoadData) return;

            if (formInstances.ContainsKey(AccountInformationForm.Instance.Name))
            {
                AddFormIntoPanel(formInstances[AccountInformationForm.Instance.Name]);

                ((AccountInformationForm)formInstances[AccountInformationForm.Instance.Name]).DisplayInformation(LoginForm.Instance.LoginInformation);
            }
        }




        //Hàm xử lý khi nhận được message
        public async Task HandleNotification(Dictionary<string, object> message)
        {
            // Handle the notification and update the UI
            MessageBox.Show($"SalesDepartmentMainForm received message: {message}");
        }


    }
}
