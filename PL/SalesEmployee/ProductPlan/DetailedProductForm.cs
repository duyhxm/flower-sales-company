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
using BL;
using DTO.Product;

namespace PL.SalesEmployee.ProductPlan
{
    public partial class DetailedProductForm : System.Windows.Forms.Form
    {
        private string _productId { get; set; }

        private ProductService _productService = new ProductService();

        public DetailedProductForm(string productId)
        {
            InitializeComponent();
   
            SetupDgv();
            _productId = productId;
            //try
            //{
            //    using (var db = new FlowerSalesCompanyDbContext())
            //    {
            //        // Query to fetch the detailed product data
            //        var detailedProductData = db.DetailedProducts
            //            .Where(dp => dp.ProductId == productID)
            //            .Join(
            //                db.Materials,
            //                dp => dp.MaterialId,
            //                m => m.MaterialId,
            //                (dp, m) => new
            //                {
            //                    dp.MaterialId,
            //                    m.MaterialName,
            //                    m.MaterialType,
            //                    m.Unit,
            //                    dp.UsedQuantity
            //                }
            //            )
            //            .ToList();

            //        // Bind the data to the DataGridView
            //        dgvDetailedProduct.DataSource = detailedProductData;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    // Display an error message if something goes wrong
            //    MessageBox.Show($"An error occurred while loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private async void DetailedProductForm_Load(object sender, EventArgs e)
        {
            await LoadDetailedProduct(_productId);
        }

        private void SetupDgv()
        {
            dgvDetailedProduct.Columns["ColMaterialId"].DataPropertyName = "MaterialId";
            dgvDetailedProduct.Columns["ColMaterialId"].Width = 100;

            dgvDetailedProduct.Columns["ColMaterialName"].DataPropertyName = "MaterialName";

            dgvDetailedProduct.Columns["ColUsedQuantity"].DataPropertyName = "UsedQuantity";
            dgvDetailedProduct.Columns["ColUsedQuantity"].Width = 80;

            dgvDetailedProduct.AutoGenerateColumns = false;
        }

        private async Task LoadDetailedProduct(string productId)
        {
            try
            {
                List<DetailedProductMaterialNameDTO> detailedProducts = await _productService.GetDetailedProductsByProductIdAsync(productId);

                dgvDetailedProduct.DataSource = detailedProducts;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi trong quá trình lấy dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
