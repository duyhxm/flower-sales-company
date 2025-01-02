using DL.Repositories.Interfaces;
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

namespace PL.StoreEmployee.DailyTask
{
    public partial class DetailedProductForm : Form
    {
        private readonly ProductService _productService;
        private readonly string _productId;

        public DetailedProductForm(string productId)
        {
            InitializeComponent();
            _productId = productId;
            _productService = new ProductService();
            SetupDataGridView();
        }

        public void SetupDataGridView()
        {
            dgvDetailedProduct.Columns["ColMaterialId"].DataPropertyName = "MaterialId";
            dgvDetailedProduct.Columns["ColMaterialId"].Width = 100;

            dgvDetailedProduct.Columns["ColMaterialName"].DataPropertyName = "MaterialName";

            dgvDetailedProduct.Columns["ColUsedQuantity"].DataPropertyName = "UsedQuantity";
            dgvDetailedProduct.Columns["ColUsedQuantity"].Width = 100;

        }

        public async Task LoadDetailedProductAsync(string productId)
        {
            var detailedProducts = await _productService.GetDetailedProductsByProductIdAsync(productId);
            
            dgvDetailedProduct.DataSource = detailedProducts;
        }

        private async void DetailedProductForm_Load(object sender, EventArgs e)
        {
            await LoadDetailedProductAsync(_productId);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
