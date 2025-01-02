using DL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL.SalesEmployee.ProductPlan
{
    public partial class DetailedProductForm : System.Windows.Forms.Form
    {
        private string productID { get; set; }
        public DetailedProductForm(string productID)
        {
            InitializeComponent();
            this.productID = productID;
            try
            {
                using (var db = new FlowerSalesCompanyDbContext())
                {
                    // Query to fetch the detailed product data
                    var detailedProductData = db.DetailedProducts
                        .Where(dp => dp.ProductId == productID)
                        .Join(
                            db.Materials,
                            dp => dp.MaterialId,
                            m => m.MaterialId,
                            (dp, m) => new
                            {
                                dp.MaterialId,
                                m.MaterialName,
                                m.MaterialType,
                                m.Unit,
                                dp.UsedQuantity
                            }
                        )
                        .ToList();

                    // Bind the data to the DataGridView
                    dgvDetailedProduct.DataSource = detailedProductData;
                }
            }
            catch (Exception ex)
            {
                // Display an error message if something goes wrong
                MessageBox.Show($"An error occurred while loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
