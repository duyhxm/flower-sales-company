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
using Infrastructure;
using DTO;

namespace PL
{
    public partial class CEOMainForm : Form, INotifiable
    {
        private NotificationService _notificationService;
        public CEOMainForm()
        {
            InitializeComponent();
            _notificationService = NotificationService.Instance;
        }

        private void CEOMainForm_Load(object sender, EventArgs e)
        {
            NotificationManager.Instance.RegisterForm(this);
        }

        private void CEOMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            NotificationManager.Instance.UnregisterForm(this);
        }

        public async Task HandleNotification(Dictionary<string, object> message)
        {
            // Handle the notification and update the UI
            MessageBox.Show($"SalesDepartmentMainForm received message: {message}");
        }
    }
}
