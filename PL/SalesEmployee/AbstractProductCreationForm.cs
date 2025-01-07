using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO.Product;
using DTO.Material;
using DTO.Enum;
using BL;

namespace PL.SalesEmployee
{
    public partial class AbstractProductCreationForm : Form
    {
        //Khai báo khởi tạo form
        private static AbstractProductCreationForm? _instance;
        private static readonly object _lock = new object();

        //Khai báo các service
        private MaterialService _materialService = new MaterialService();
        private ProductService _productService = new ProductService();

        //Khai báo các biến sử dụng
        private List<FlowerDTO> _flowers = new();
        private List<MaterialDTO> _accessories = new();

        private AbstractProductCreationForm()
        {
            InitializeComponent();

            SetupFlowerDgv();
            SetupAccessoryDgv();
        }

        public static void Initialize()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    try
                    {
                        _instance = new AbstractProductCreationForm();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }

        public static AbstractProductCreationForm Instance
        {
            get
            {
                if (_instance == null)
                {
                    throw new InvalidOperationException("AbstractProductCreationForm chưa được khởi tạo. Gọi Initialize() trước tiên.");
                }
                return _instance;
            }
        }

        private async void AbstractProductCreationForm_Load(object sender, EventArgs e)
        {
            await LoadAllFlowers();
            await LoadAllAccessories();
            await LoadFloralRepresentations();
        }

        private void SetupFlowerDgv()
        {
            dgvFlowers.AutoGenerateColumns = false;

            dgvFlowers.Columns["ColFlowerId"].Width = 120;
            dgvFlowers.Columns["ColFlowerId"].DataPropertyName = "FlowerID";

            dgvFlowers.Columns["ColFlowerName"].Width = 250;
            dgvFlowers.Columns["ColFlowerName"].DataPropertyName = "FlowerName";

            dgvFlowers.Columns["ColFType"].Width = 150;
            dgvFlowers.Columns["ColFType"].DataPropertyName = "FTypeName";

            dgvFlowers.Columns["ColFColor"].Width = 150;
            dgvFlowers.Columns["ColFColor"].DataPropertyName = "FColorName";

            dgvFlowers.Columns["ColFChar"].Width = 150;
            dgvFlowers.Columns["ColFChar"].DataPropertyName = "FCharacteristicName";

            dgvFlowers.Columns["ColUsedFQuantity"].Width = 80;

            dgvFlowers.Columns["ColFSelection"].Width = 50;
        }

        private void SetupAccessoryDgv()
        {
            dgvAccessories.AutoGenerateColumns = false;

            dgvAccessories.Columns["ColAccessoryId"].Width = 120;
            dgvAccessories.Columns["ColAccessoryId"].DataPropertyName = "MaterialId";

            dgvAccessories.Columns["ColAccessoryName"].Width = 250;
            dgvAccessories.Columns["ColAccessoryName"].DataPropertyName = "MaterialName";

            dgvAccessories.Columns["ColUsedAQuantity"].Width = 80;

            dgvAccessories.Columns["ColASelection"].Width = 50;
        }

        //Load danh sách các vật liệu
        private async Task LoadAllFlowers()
        {
            try
            {
                _flowers = await _materialService.GetAllFlowersAsync();

                LoadComboBoxData(_flowers);

                FilterFlowers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async Task LoadAllAccessories()
        {
            try
            {
                var accessories = await _materialService.GetAllAccessoriesAsync();

                dgvAccessories.DataSource = accessories;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Load danh sách các hình thức sản phẩm
        private async Task LoadFloralRepresentations()
        {
            try
            {
                var fRepresentations = await _materialService.GetAllFRepresentationsAsync();

                cmbBxFrs.DataSource = fRepresentations;
                cmbBxFrs.DisplayMember = "Frname";
                cmbBxFrs.ValueMember = "FrepresentationId";
                cmbBxFrs.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadComboBoxData(List<FlowerDTO> flowerList)
        {
            var floralTypes = flowerList.Select(f => f.FTypeName).Distinct().ToList();
            var floralColors = flowerList.Select(f => f.FColorName).Distinct().ToList();
            var floralCharacteristics = flowerList.Select(f => f.FCharacteristicName).Distinct().ToList();

            floralTypes.Insert(0, "All");
            floralColors.Insert(0, "All");
            floralCharacteristics.Insert(0, "All");

            cmbBxFType.DataSource = floralTypes;
            cmbBxFColor.DataSource = floralColors;
            cmbBxFChar.DataSource = floralCharacteristics;

            cmbBxFType.SelectedIndex = 0;
            cmbBxFColor.SelectedIndex = 0;
            cmbBxFChar.SelectedIndex = 0;
        }

        private void FilterFlowers()
        {
            if (!this.IsDisposed)
            {
                var filteredList = _flowers.AsQueryable();

                if (cmbBxFType.SelectedItem != null && cmbBxFType.SelectedItem.ToString() != "All")
                {
                    filteredList = filteredList.Where(f => f.FTypeName == cmbBxFType.SelectedItem.ToString());
                }

                if (cmbBxFColor.SelectedItem != null && cmbBxFColor.SelectedItem.ToString() != "All")
                {
                    filteredList = filteredList.Where(f => f.FColorName == cmbBxFColor.SelectedItem.ToString());
                }

                if (cmbBxFChar.SelectedItem != null && cmbBxFChar.SelectedItem.ToString() != "All")
                {
                    filteredList = filteredList.Where(f => f.FCharacteristicName == cmbBxFChar.SelectedItem.ToString());
                }

                dgvFlowers.DataSource = filteredList.ToList();
            }
        }

        private void cmbBxFType_SelectedValueChanged(object sender, EventArgs e)
        {
            FilterFlowers();
        }

        private void cmbBxFColor_SelectedValueChanged(object sender, EventArgs e)
        {
            FilterFlowers();
        }

        private void cmbBxFChar_SelectedValueChanged(object sender, EventArgs e)
        {
            FilterFlowers();
        }

        private async void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBxProductName.Text == string.Empty)
                {
                    MessageBox.Show("Bạn cần điền tên sản phẩm để có thể thêm sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return;
                }

                if (!IsAnyMaterialSelected(dgvFlowers, "ColFSelection"))
                {
                    MessageBox.Show("Bạn cần chọn ít nhất một hoa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (!IsAnyMaterialSelected(dgvAccessories, "ColASelection"))
                {
                    MessageBox.Show("Bạn cần chọn ít nhất một phụ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (IsAnyRecordInvalid(dgvFlowers, "ColFSelection", "ColUsedFQuantity"))
                {
                    MessageBox.Show("Bạn cần điền số lượng thích hợp cho những hoa mà bạn đã chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (IsAnyRecordInvalid(dgvAccessories, "ColASelection", "ColUsedAQuantity"))
                {
                    MessageBox.Show("Bạn cần điền số lượng thích hợp cho những phụ liệu mà bạn đã chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Lấy giá trị từ ComboBox
                string? selectedFRId = cmbBxFrs.SelectedValue?.ToString();

                // Lấy tên sản phẩm từ TextBox
                string productName = txtBxProductName.Text.Trim();

                // Danh sách chi tiết sản phẩm
                List<DetailedProductDTO> detailedProducts = new List<DetailedProductDTO>();

                if (selectedFRId == null)
                {
                    MessageBox.Show("Dữ liệu hình thức sản phẩm hiện đang bị lỗi. Vui lòng load lại dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                foreach (DataGridViewRow row in dgvFlowers.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["ColFSelection"].Value) == true)
                    {
                        DetailedProductDTO dt = new DetailedProductDTO()
                        {
                            MaterialId = row.Cells["ColFlowerId"].Value.ToString()!,
                            UsedQuantity = Convert.ToInt16(row.Cells["ColUsedFQuantity"].Value.ToString())
                        };

                        detailedProducts.Add(dt);
                    }
                }

                foreach (DataGridViewRow row in dgvAccessories.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["ColASelection"].Value) == true)
                    {
                        DetailedProductDTO dt = new DetailedProductDTO()
                        {
                            MaterialId = row.Cells["ColAccessoryId"].Value.ToString()!,
                            UsedQuantity = Convert.ToInt16(row.Cells["ColUsedAQuantity"].Value.ToString())
                        };

                        detailedProducts.Add(dt);
                    }
                }

                ProductDTO product = new ProductDTO()
                {
                    ProductName = productName,
                    FrepresentationId = selectedFRId,
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
                }

                ClearFormData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsAnyRecordInvalid(DataGridView dgv, string selectionColName, string quantityColName)
        {
            bool result = false;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (Convert.ToBoolean(row.Cells[selectionColName].Value) == true)
                {
                    if (!int.TryParse(row.Cells[quantityColName].Value?.ToString(), out int quantity) || quantity <= 0)
                    {
                        return true;
                    }
                }
            }

            return result;
        }

        private bool IsAnyMaterialSelected(DataGridView dgv, string selectionColName)
        {
            bool result = false;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (Convert.ToBoolean(row.Cells[selectionColName].Value) == true)
                {
                    result = true;
                }
            }

            return result;
        }

        private void ClearFormData()
        {
            // Clear TextBox
            txtBxProductName.Text = string.Empty;

            // Clear DataGridView selections and quantities
            foreach (DataGridViewRow row in dgvFlowers.Rows)
            {
                row.Cells["ColFSelection"].Value = false;
                row.Cells["ColUsedFQuantity"].Value = null;
            }

            foreach (DataGridViewRow row in dgvAccessories.Rows)
            {
                row.Cells["ColASelection"].Value = false;
                row.Cells["ColUsedAQuantity"].Value = null;
            }

            // Reset ComboBox to default value
            cmbBxFrs.SelectedIndex = 0;
            cmbBxFType.SelectedIndex = 0;
            cmbBxFColor.SelectedIndex = 0;
            cmbBxFChar.SelectedIndex = 0;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc muốn xoá toàn bộ dữ liệu", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                ClearFormData();
            }
        }
    }
}
