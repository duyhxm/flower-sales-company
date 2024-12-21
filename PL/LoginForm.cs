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
using BL;
using System.Reflection;
using Infrastructure;
using Azure.Messaging.ServiceBus;

namespace PL
{
    public partial class LoginForm : Form
    {
        private const string TOPIC_NAME = "DataChanges";
        private Form WorkForm { get; set; }
        private Dictionary<string, Type> Forms;
        public string Username { get; private set; } = string.Empty;
        public string Password { get; private set; } = string.Empty;
        private ServiceBusManager _serviceBusManager;
        private string _serviceBusConnectionString;
        private ServiceBusHost _serviceBusHost;
        private bool _isServiceBusHostEnabled = false;
        private NotificationService _notificationService;
        private NotificationManager _notificationManager;
        public LoginForm()
        {
            InitializeComponent();
            lblInvalidCredential.Visible = false;

            Forms = new Dictionary<string, Type>
            {
                { "CEOMainForm", typeof(CEOMainForm) },
                { "StoreMainForm", typeof(StoreMainForm) },
                { "SalesDepartmentMainForm", typeof(SalesDepartmentMainForm)}
            };
            WorkForm = new Form();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Username = txtBxUsername.Text;
            Password = txtBxPassword.Text;
            UserAccountDTO account = new UserAccountDTO(Username, Password);

            try
            {
                LoginBL login = new LoginBL();
                bool canLogin = login.Login(account);

                if (canLogin)
                {
                    Dictionary<string, string> infor = login.GetLoginInfo(account);
                    string formName = infor["AccessibleFormName"];
                    WorkForm = CreateFormByName(formName);
                    WorkForm.FormClosed += (s, args) => this.Show();
                    ShowWorkForm();

                    this.Hide();

                    StartServiceBusHost();
                }
                else
                {
                    lblInvalidCredential.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private Form CreateFormByName(string formName)
        {
            if (Forms.ContainsKey(formName))
            {
                return (Form)Activator.CreateInstance(Forms[formName]);
            }

            throw new ArgumentException($"Form with name '{formName}' not registered.");
        }

        private void ShowWorkForm()
        {
            WorkForm.Show();
        }

        private void txtBxUsername_TextChanged(object sender, EventArgs e)
        {
            if (lblInvalidCredential.Visible == true)
            {
                lblInvalidCredential.Visible = false;
            }
        }

        private void txtBxPassword_TextChanged(object sender, EventArgs e)
        {
            if (lblInvalidCredential.Visible == true)
            {
                lblInvalidCredential.Visible = false;
            }
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult results = MessageBox.Show("Bạn có chắc muốn thoát chương trình không?", "Warning", buttons);

            if(results == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                if(_isServiceBusHostEnabled == true)
                {
                    _serviceBusHost.Stop();
                }
            }
        }

        public void StartServiceBusHost()
        {
            _serviceBusConnectionString = new ConfigurationManager().GetServiceBusConnectionString();

            try
            {
                _serviceBusManager = new ServiceBusManager(_serviceBusConnectionString);
                _serviceBusHost = new ServiceBusHost(_serviceBusManager);
                _serviceBusHost.Start(TOPIC_NAME, "UserA_Subscription");
                _isServiceBusHostEnabled = true;

                SubscribeNotification();
            }
            catch (Exception ex)
            {
                MessageBox.Show(@$"An error occured!!!
                                  Message: {ex.Message}
                                  Stack trace: {ex.StackTrace}");
            }
        }

        private void SubscribeNotification()
        {
            _notificationService = new NotificationService(_serviceBusManager, TOPIC_NAME);
            //NotificationManager.Instance.OnNotificationReceived(_notificationService); // Gọi hàm này để đăng ký nhận thông báo
            _notificationManager = new NotificationManager(_notificationService);
        }

        public async Task Perform()
        {
            ServiceBusMessage message = new ServiceBusMessage("test")
            {
                SessionId = "1234",
                Subject = "Database Change Notification",
                ApplicationProperties = { { "Action", "Insert" } }
            };
            await _notificationService.NotifyDatabaseOperationAsync(message);
        }
    }
}
