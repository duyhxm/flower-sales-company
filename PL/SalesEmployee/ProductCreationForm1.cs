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
using DTO.Enum;
using BL;
using DTO.Material;

namespace PL.SalesEmployee
{
    public partial class ProductCreationForm1 : Form
    {
        //Khai báo khởi tạo form
        private static ProductCreationForm1? _instance;
        private static readonly object _lock = new object();

        //Khai báo các service
        private MaterialService _materialService = new MaterialService();
        private ProductService _productService = new ProductService();

        //Khai báo các biến sử dụng
        private List<MaterialDTO> _materials = new List<MaterialDTO>();

        private ProductCreationForm1()
        {
            InitializeComponent();
            dgvMaterials.AutoGenerateColumns = false;
            this.VisibleChanged += ProductCreationForm_VisibleChanged;
        }

        private void ProductCreationForm_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                dgvMaterials.Size = new Size(992, 604); // Thiết lập lại kích thước mong muốn
                cbbFr.Location = new Point(1304, 222);
            }
        }

        public static void Initialize()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    try
                    {
                        _instance = new ProductCreationForm1();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }

        public static ProductCreationForm1 Instance
        {
            get
            {
                if (_instance == null)
                {
                    throw new InvalidOperationException("ProductCreationForm chưa được khởi tạo. Gọi Initialize() trước tiên.");
                }
                return _instance;
            }
        }

        //Load loại vật liệu
        private void LoadMaterialType()
        {
            cmbBxMaterialType.Items.Add("All");
            cmbBxMaterialType.Items.Add(DTO.Enum.MaterialType.Flower);
            cmbBxMaterialType.Items.Add(DTO.Enum.MaterialType.Accessory);
            cmbBxMaterialType.SelectedIndex = 0;
        }

        //Load danh sách các vật liệu
        private async Task LoadMaterialData()
        {
            try
            {
                _materials = await _materialService.GetAllMaterials();
                FilterMaterials();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Load danh sách các hình thức sản phẩm
        private async Task LoadFloralRepresentationData()
        {
            try
            {
                var fRepresentations = await _materialService.GetAllFRepresentationsAsync();

                cbbFr.DataSource = fRepresentations;
                cbbFr.DisplayMember = "Frname";
                cbbFr.ValueMember = "FrepresentationId";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FilterMaterials()
        {
            if (cmbBxMaterialType.Text == "All")
            {
                dgvMaterials.DataSource = _materials;
                return;
            }

            if (cmbBxMaterialType.Text == DTO.Enum.MaterialType.Flower)
            {
                List<MaterialDTO> filteredMaterials = _materials.Where(m => m.MaterialType == DTO.Enum.MaterialType.Flower).ToList();

                dgvMaterials.DataSource = filteredMaterials;
                return;
            }

            if (cmbBxMaterialType.Text == DTO.Enum.MaterialType.Accessory)
            {
                List<MaterialDTO> filteredMaterials = _materials.Where(m => m.MaterialType == DTO.Enum.MaterialType.Accessory).ToList();

                dgvMaterials.DataSource = filteredMaterials;
                return;
            }
        }

        //Khi form load xong
        private async void CreateProduct_Load(object sender, EventArgs e)
        {
            LoadMaterialType();
            await LoadMaterialData();
            await LoadFloralRepresentationData();
        }

        //Khi nhấn tạo sản phẩm
        private async void btnCreate_Click(object sender, EventArgs e)
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
                foreach (DataGridViewRow row in dgvMaterials.Rows)
                {
                    // Kiểm tra checkbox
                    DataGridViewCheckBoxCell? checkBoxCell = row.Cells["Check"] as DataGridViewCheckBoxCell;

                    if (checkBoxCell != null && checkBoxCell.Value is bool isChecked && isChecked)
                    {
                        string materialId = row.Cells["MaterialId"].Value.ToString()!;

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
                ReturnedProductDTO result = await _productService.AddAbstractProductAsync(product);

                // Thông báo kết quả
                if (result.HasExisted)
                {
                    MessageBox.Show($"Sản phẩm đã tồn tại với tên gọi: {result.Product.ProductName}");
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

        private void cmbBxMaterialType_SelectedValueChanged(object sender, EventArgs e)
        {
            FilterMaterials();
        }
    }
}
