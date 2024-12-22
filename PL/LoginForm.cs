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
        private ServiceBusManager _serviceBusManager;
        private string _connectionString;
        private ServiceBusHost _serviceBusHost;
        private bool _isServiceBusHostEnabled = false;
        public string Username { get; private set; } = string.Empty;
        public string Password { get; private set; } = string.Empty;
        
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

            try
            {
                _connectionString = new ConfigurationManager().GetServiceBusConnectionString();
                _serviceBusManager = new ServiceBusManager(_connectionString);
                _serviceBusHost = new ServiceBusHost(_serviceBusManager);
            }
            catch (Exception e)
            {
                MessageBox.Show($"Message: {e.Message} \n Stack trace: {e.StackTrace}");
            }
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
                    StartServiceBusHost();
                    SubscribeNotification();

                    Dictionary<string, string> infor = login.GetLoginInfo(account);
                    string formName = infor["AccessibleFormName"];
                    WorkForm = CreateFormByName(formName);
                    WorkForm.FormClosed += (s, args) => this.Show();
                    ShowWorkForm();

                    this.Hide(); 
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
                try
                {
                    var form = Activator.CreateInstance(Forms[formName]);
                    if (form != null)
                    {
                        return (Form)form;
                    }
                }
                catch (NullReferenceException)
                {
                    throw;
                }  
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

        private void StartServiceBusHost()
        {
            try
            {
                _serviceBusHost.Start(TOPIC_NAME, "UserA_Subscription");
                _isServiceBusHostEnabled = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(@$"An error occured!!!
                                  Message: {e.Message}
                                  Stack trace: {e.StackTrace}");
            }
        }

        private void SubscribeNotification()
        {
            NotificationServiceSingleton.Initialize(_serviceBusManager, TOPIC_NAME);
            NotificationManager.Initialize();
        }
    }
}
