using DL.Models;
using DL.Repositories.Implementations;
using DTO.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL.SalesEmployee
{
    public partial class CreateProduct : System.Windows.Forms.Form
    {
        private static CreateProduct? _instance;
        private static readonly object _lock = new object();
        private ProductRepository repository = new ProductRepository();
        public CreateProduct()
        {
            InitializeComponent();
        }
        public static void Initialize()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    try
                    {
                        _instance = new CreateProduct();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }
        public static CreateProduct Instance
        {
            get
            {
                if (_instance == null)
                {
                    throw new InvalidOperationException("MaterialDistributionForm is not initialized. Call Initialize() first.");
                }
                return _instance;
            }
        }
        private void LoadMaterialData()
        {
            using (var context = new FlowerSalesCompanyDbContext())
            {
                var materials = context.Materials
                    .Select(m => new
                    {
                        m.MaterialId,
                        m.MaterialName,
                        m.MaterialType,
                        m.Unit
                    })
                    .ToList();
                materialDataGridView.DataSource = materials;
            }
        }
        private void LoadFloralRepresentationData()
        {
            using (var context = new FlowerSalesCompanyDbContext())
            {
                var floralRepresentations = context.FloralRepresentations
                    .Select(fr => new
                    {
                        fr.FrepresentationId,
                        fr.Frname
                    })
                    .ToList();
                cbbFr.DataSource = floralRepresentations;
                cbbFr.DisplayMember = "Frname";
                cbbFr.ValueMember = "FrepresentationId";
            }
        }
        private void CreateProduct_Load(object sender, EventArgs e)
        {
            LoadMaterialData();
            LoadFloralRepresentationData();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy giá trị từ ComboBox
                string? selectedFRepresentationId = cbbFr.SelectedValue?.ToString();

                // Lấy tên sản phẩm từ TextBox
                string productName = txtProductName.Text.Trim();

                // Danh sách chi tiết sản phẩm
                List<DetailedProductDTO> detailedProducts = new List<DetailedProductDTO>();

                // Duyệt qua DataGridView để lấy dữ liệu của các hàng được chọn (checkbox)
                foreach (DataGridViewRow row in materialDataGridView.Rows)
                {
                    // Kiểm tra checkbox
                    DataGridViewCheckBoxCell checkBoxCell = row.Cells["Check"] as DataGridViewCheckBoxCell;
                    if (checkBoxCell != null && checkBoxCell.Value is bool isChecked && isChecked)
                    {
                        string materialId = row.Cells["MaterialId"].Value.ToString();

                        // Lấy giá trị từ cột Quantity
                        var quantityCell = row.Cells["Quantity"];
                        if (quantityCell.Value != null && short.TryParse(quantityCell.Value.ToString(), out short usedQuantity) && usedQuantity > 0)
                        {
                            // Thêm vào danh sách
                            detailedProducts.Add(new DetailedProductDTO
                            {
                                MaterialId = materialId,
                                UsedQuantity = usedQuantity
                            });
                        }
                        else
                        {
                            MessageBox.Show($"Vui lòng nhập số lượng hợp lệ cho vật liệu {materialId}");
                            return;
                        }
                    }
                }

                // Kiểm tra dữ liệu hợp lệ
                if (string.IsNullOrEmpty(productName) || string.IsNullOrEmpty(selectedFRepresentationId) || !detailedProducts.Any())
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin sản phẩm và chọn vật liệu.");
                    return;
                }

                // Tạo đối tượng ProductDTO
                ProductDTO product = new ProductDTO
                {
                    FrepresentationId = selectedFRepresentationId,
                    ProductName = productName,
                    DetailedProducts = detailedProducts
                };

                // Gọi hàm thêm sản phẩm
                ReturnedProductDTO result = await repository.AddAbstractProductAsync(product);

                // Thông báo kết quả
                if (result.HasExisted)
                {
                    MessageBox.Show($"Sản phẩm đã tồn tại: {result.Product.ProductName}");
                }
                else
                {
                    MessageBox.Show("Tạo sản phẩm thành công!");
                    CreateProduct_Load(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
            }
        }

    }
}
