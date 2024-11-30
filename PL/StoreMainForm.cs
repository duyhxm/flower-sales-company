using BL;

namespace PL
{
    public partial class StoreMainForm : Form
    {
        public StoreMainForm()
        {
            InitializeComponent();
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {
            
        }

        private void addFormInPanel(Form form)
        {                                  
            splitContainer_mainInterface.Panel2.Controls
                .Clear();

            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            splitContainer_mainInterface.Panel2.Controls.Add(form);
            form.Show();
        }

        private void btn_inventory_Click(object sender, EventArgs e)
        {
            InventoryForm inventoryForm = new InventoryForm();
            addFormInPanel(inventoryForm);
        }

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            SalesOrderForm orderForm = new SalesOrderForm();
            
            addFormInPanel(orderForm);
        }


    }

}
