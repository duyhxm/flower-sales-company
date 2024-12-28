using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;
using System.Reflection;
using DTO.Employee;
using DTO;
using System.Diagnostics;

namespace PL
{
    public partial class LoginForm : Form
    {
        private static LoginForm? _instance;
        private static readonly object _lock = new object();
        private SystemService _systemService;
        private const string TOPIC_NAME = "DataChanges";

        private Form WorkForm { get; set; }

        private Dictionary<string, Type> Forms;

        public string Username { get; private set; } = string.Empty;

        public string Password { get; private set; } = string.Empty;

        public LoginInformation LoginInformation { get; set; }

        private bool _isLoggingIn = false;

        private LoginForm()
        {
            InitializeComponent();
            lblInvalidCredential.Visible = false;

            SystemService.Initialize();
            _systemService = SystemService.Instance;

            Forms = new Dictionary<string, Type>
            {
                { "CEOMainForm", typeof(CEOMainForm) },
                { "StoreMainForm", typeof(StoreMainForm) },
                { "SalesDepartmentMainForm", typeof(SalesDepartmentMainForm)}
            };
            WorkForm = new Form();
        }

        public static LoginForm Instance
        {
            get
            {
                return _instance!;
            }
        }

        public static void Initialize()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    _instance = new LoginForm();
                }
            }
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (_isLoggingIn) return;

            _isLoggingIn = true;
            btnLogin.Enabled = false;

            Username = txtBxUsername.Text;
            Password = txtBxPassword.Text;

            UserAccountDTO userAccount = new UserAccountDTO()
            {
                Username = Username,
                Password = Password
            };

            try
            {
                UserAccountDTO? result = await _systemService.LoginAsync(userAccount);

                Debug.WriteLine("LoginForm");

                if (result != null)
                {

                    LoginInformation? extraLoginInfo = await _systemService.GetExtraLoginInfo(result);

                    if (extraLoginInfo != null)
                    {
                        LoginInformation = extraLoginInfo;
                        LoginInformation.UserAccount = result;

                        RunServiceBusHost(TOPIC_NAME, "UserA_Subscription");
                        RunNotificationService(TOPIC_NAME);

                        WorkForm = CreateFormByName(LoginInformation.AccessibleForm);
                        WorkForm.FormClosed += (s, args) => this.Show();
                        ShowWorkForm();

                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Hệ thống hiện tại đang bị lỗi, vui lòng liên hệ bộ phận kỹ thuật");
                    }
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
            finally
            {
                _isLoggingIn = false;
                btnLogin.Enabled = true;
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

        private async void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult results = MessageBox.Show("Bạn có chắc muốn thoát chương trình không?", "Warning", buttons);

            if(results == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                await _systemService.StopServiceBusHost();
                e.Cancel = false;
            }
        }

        public void RunServiceBusHost(string topicName, string subscription)
        {
            try
            {
                _systemService.RunServiceBusHost(topicName, subscription);
            }
            catch (Exception e)
            {
                MessageBox.Show(@$"An error occured!!!
                                  Message: {e.Message}
                                  Stack trace: {e.StackTrace}");
            }
        }

        private void RunNotificationService(string topicName)
        {
            NotificationService.Initialize(topicName);
            NotificationManager.Initialize();
        }
    }
}
