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
            toolStripNavigationBar.Renderer = new CustomToolStripRenderer();
        }

        private void Inventory_Form_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            toolStripButtonMaterial.BackColor = SystemColors.ActiveCaption;
            toolStripButtonProduct.BackColor = SystemColors.GradientInactiveCaption;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            toolStripButtonProduct.BackColor = SystemColors.ActiveCaption;
            toolStripButtonMaterial.BackColor = SystemColors.GradientInactiveCaption;
        }
    }
}
