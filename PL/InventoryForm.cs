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
    public partial class InventoryForm : Form
    {
        public InventoryForm()
        {
            InitializeComponent();
        }

        private void tolStrBtnMaterial_Click(object sender, EventArgs e)
        {
            tolStrBtnMaterial.BackColor = SystemColors.ActiveCaption;
            tolStrBtnProduct.BackColor = SystemColors.GradientInactiveCaption;
        }

        private void tolStrBtnProduct_Click(object sender, EventArgs e)
        {
            tolStrBtnProduct.BackColor = SystemColors.ActiveCaption;
            tolStrBtnMaterial.BackColor = SystemColors.GradientInactiveCaption;
        }
    }
}
