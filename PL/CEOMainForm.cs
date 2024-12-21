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
    public partial class CEOMainForm : Form, INotifiable
    {
        public CEOMainForm()
        {
            InitializeComponent();
        }

        private void CEOMainForm_Load(object sender, EventArgs e)
        {
            NotificationManager.Instance.RegisterForm(this);
        }

        private void CEOMainForm_FormClosing(object sender, FormClosingEventArgs e)
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
