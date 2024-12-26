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

namespace PL
{
    public partial class SalesDepartmentMainForm : Form, INotifiable
    {
        private NotificationService _notificationService;
        public SalesDepartmentMainForm()
        {
            InitializeComponent();
            _notificationService = NotificationService.Instance;
        }

        private void SalesDepartmentMainForm_Load(object sender, EventArgs e)
        {
            NotificationManager.Instance.RegisterForm(this);
        }

        private void SalesDepartmentMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            NotificationManager.Instance.UnregisterForm(this);
        }

        public void HandleNotification(Dictionary<string, object> message)
        {
            // Handle the notification and update the UI
            MessageBox.Show($"SalesDepartmentMainForm received message: {message}");
        }
    }
}
