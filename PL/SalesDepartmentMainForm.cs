using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL
{
    public partial class SalesDepartmentMainForm : Form, INotifiable
    {
        public SalesDepartmentMainForm()
        {
            InitializeComponent();
        }

        private void SalesDepartmentMainForm_Load(object sender, EventArgs e)
        {
            NotificationManager.Instance.RegisterForm(this);
        }

        private void SalesDepartmentMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            NotificationManager.Instance.UnregisterForm(this);
        }

        public void HandleNotification(string message)
        {
            // Handle the notification and update the UI
            MessageBox.Show($"SalesDepartmentMainForm received message: {message}");
        }
    }
}
