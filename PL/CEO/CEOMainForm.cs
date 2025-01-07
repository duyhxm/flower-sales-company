using BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PL.CEO;

namespace PL
{
    public partial class CEOMainForm : Form, INotifiable
    {
        private NotificationService _notificationService;

        public Dictionary<string, Form> formInstances = new();
        public CEOMainForm()
        {
            InitializeComponent();
            _notificationService = NotificationService.Instance;
        }

        private void CEOMainForm_Load(object sender, EventArgs e)
        {
            NotificationManager.Instance.RegisterForm(this);

            AccountInformationForm.Initialize();
            formInstances[AccountInformationForm.Instance.Name] = AccountInformationForm.Instance;

            StatisticsForm statisticsForm = new StatisticsForm();
            formInstances["StatisticsForm"] = statisticsForm;

            foreach (var form in formInstances.Values)
            {
                form.TopLevel = false;
                form.Dock = DockStyle.Fill;
            }
        }

        private void CEOMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            NotificationManager.Instance.UnregisterForm(this);
        }

        private void AddFormIntoPanel(Form form)
        {
            splConStoreMainForm.Panel2.Controls.Clear();
            splConStoreMainForm.Panel2.Controls.Add(form);
            form.Show();
        }

        public async Task HandleNotification(Dictionary<string, object> message)
        {
            // Handle the notification and update the UI
            MessageBox.Show($"SalesDepartmentMainForm received message: {message}");
        }

        private void btnAccountInformation_Click(object sender, EventArgs e)
        {
            if (formInstances.ContainsKey(AccountInformationForm.Instance.Name))
            {
                AddFormIntoPanel(formInstances[AccountInformationForm.Instance.Name]);

                ((AccountInformationForm)formInstances[AccountInformationForm.Instance.Name]).DisplayInformation(LoginForm.Instance.LoginInformation);
            }
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            if (formInstances.ContainsKey("StatisticsForm"))
            {
                AddFormIntoPanel(formInstances["StatisticsForm"]);
            }
        }
    }
}
