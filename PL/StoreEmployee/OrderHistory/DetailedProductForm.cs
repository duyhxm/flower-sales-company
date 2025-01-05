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

namespace PL.StoreEmployee.OrderHistory
{
    public partial class DetailedProductForm : Form
    {
        private ProductService _productService = new ProductService();
        private MaterialService _materialService = new MaterialService();
        private readonly string _productId;

        public DetailedProductForm(string productId)
        {
            InitializeComponent();
            _productId = productId;

            SetupAccessoryDgv();
            SetupFlowerDgv();
        }

        private void SetupAccessoryDgv()
        {
            dgvAccessories.AutoGenerateColumns = false;

            dgvAccessories.Columns["ColAccessoryId"].Width = 100;
            dgvAccessories.Columns["ColAccessoryId"].DataPropertyName = "MaterialId";

            dgvAccessories.Columns["ColAccessoryName"].Width = 200;
            dgvAccessories.Columns["ColAccessoryName"].DataPropertyName = "MaterialName";

            dgvAccessories.Columns["ColUsedAQuantity"].Width = 80;
            dgvAccessories.Columns["ColUsedAQuantity"].DataPropertyName = "UsedQuantity";
        }

        private void SetupFlowerDgv()
        {
            dgvFlowers.AutoGenerateColumns = false;

            dgvFlowers.Columns["ColFlowerId"].Width = 100;
            dgvFlowers.Columns["ColFlowerId"].DataPropertyName = "FlowerId";

            dgvFlowers.Columns["ColFlowerName"].Width = 200;
            dgvFlowers.Columns["ColFlowerName"].DataPropertyName = "FlowerName";

            dgvFlowers.Columns["ColFColor"].Width = 100;
            dgvFlowers.Columns["ColFColor"].DataPropertyName = "ColorName";

            dgvFlowers.Columns["ColFChar"].Width = 100;
            dgvFlowers.Columns["ColFChar"].DataPropertyName = "CharName";

            dgvFlowers.Columns["ColUsedFQuantity"].Width = 100;
            dgvFlowers.Columns["ColUsedFQuantity"].DataPropertyName = "Quantity";
        }

        public async Task LoadDetailedProductAsync(string productId)
        {
            //Load phụ liệu
            var detailedProducts = await _productService.GetDetailedProductsByProductIdAsync(productId);
            var accessories = detailedProducts.Where(dp => dp.MaterialId.StartsWith("A")).ToList();

            dgvAccessories.DataSource = accessories;

            //Load hoa
            //Load toàn bộ hoa với các thông tin chi tiết như tên màu sắc, tên loại hoa, tên đặc điểm
            var detailedFlowers = await _materialService.GetAllFlowersAsync();
            var transformedFlowers = detailedFlowers
                                    .Join(detailedProducts,
                                    df => df.FlowerID,
                                    dp => dp.MaterialId,
                                    (df, dp) => new
                                    {
                                        FlowerId = df.FlowerID,
                                        FlowerName = dp.MaterialName,
                                        ColorName = df.FColorName,
                                        CharName = df.FCharacteristicName,
                                        Quantity = dp.UsedQuantity
                                    }).ToList();

            dgvFlowers.DataSource = transformedFlowers;
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
