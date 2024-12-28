using DTO.Store;
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
    public partial class ProductStockDetails : Form
    {
        public ProductStockDetails(List<ProductInventoryDTO> productDetails)
        {
            InitializeComponent();
            LoadProductDetails(productDetails);
        }

        private void LoadProductDetails(List<ProductInventoryDTO> productDetails)
        {
            dgvProductStockDetails.DataSource = productDetails.Select(p => new
            {
                p.StockDate,
                Quantity = p.StockProductQuantity,
                p.UnitPrice
            }).ToList();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
