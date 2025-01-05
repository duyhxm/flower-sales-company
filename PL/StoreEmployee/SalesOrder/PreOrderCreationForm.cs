using BL;
using DTO.Material;
using DTO.Product;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using static BL.GeneralService;

namespace PL
{
    public partial class PreOrderCreationForm : System.Windows.Forms.Form
    {
        private MaterialService _materialService;
        private ProductService _productService;

        //khai báo các biến sẽ sử dụng trong form
        private List<FloralRepresentationDTO>? _fRepresentations;
        private List<FlowerDTO> _flowers = new();
        private List<MaterialDTO> _accessories = new();
        private bool _isCalculatingUnitPrice = false;
        public PreOrderCreationForm()
        {
            InitializeComponent();

            _materialService = new MaterialService();
            _productService = new ProductService();

            //Cấu hình data property name cho flower 
            SetupFlowerListDgv();

            //cấu hình data property name cho accessory
            SetupAccessoryList();

            //Cấu hình cho text box 'số lượng sản phẩm'
            txtBxCreationQuantity.ReadOnly = true;
            txtBxCreationQuantity.Enabled = false;
        }

        private void SetupFlowerListDgv()
        {
            dgvFlowerList.Columns[0].DataPropertyName = "FlowerID";
            dgvFlowerList.Columns[1].DataPropertyName = "FlowerName";
            dgvFlowerList.Columns[2].DataPropertyName = "FTypeName";
            dgvFlowerList.Columns[3].DataPropertyName = "FColorName";
            dgvFlowerList.Columns[4].DataPropertyName = "FCharacteristicName";
            dgvFlowerList.AutoGenerateColumns = false;
        }

        private void SetupAccessoryList()
        {
            dgvAccessoryList.Columns[0].DataPropertyName = "MaterialID";
            dgvAccessoryList.Columns[1].DataPropertyName = "MaterialName";
            dgvAccessoryList.AutoGenerateColumns = false;
        }

        private async void PreOrderCreationForm_Load(object sender, EventArgs e)
        {
            await LoadAllFlowersAsync();
            await LoadAllAccessories();
            await LoadAllFRepresentations();
        }

        private async Task LoadAllFRepresentations()
        {
            _fRepresentations = await _materialService.GetAllFRepresentationsAsync();

            if (_fRepresentations != null)
            {
                foreach (var f in _fRepresentations)
                {
                    cmbBxFR.Items.Add(f.Frname!);
                }
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            //Kiểm tra tính hợp lệ của các thông tin
            string creationQuantity = txtBxCreationQuantity.Text;
            if (creationQuantity == string.Empty)
            {
                MessageBox.Show("Bạn cần thêm tối thiểu 1 mặt hàng", "Cảnh báo");
                return;
            }

            string floralRepresentation = cmbBxFR.Text;
            if (floralRepresentation == string.Empty)
            {
                MessageBox.Show("Không được để trống hình thức hoa", "Cảnh báo");
                return;
            }

            string productName = txtBxProductName.Text;
            if (productName == string.Empty)
            {
                MessageBox.Show("Không được để trống tên sản phẩm", "Cảnh báo");
                return;
            }

            //Sau khi kiểm tra tính hợp lệ, nếu hợp lệ thì sẽ tiếp tục thực hiện các phần dưới đây
            //Lấy floral representation id
            string? idFRepresentation = null;
            if (_fRepresentations != null)
            {
                idFRepresentation = _fRepresentations
                                       .Where(fr => fr.Frname == floralRepresentation)
                                       .Select(fr => fr.FrepresentationId).FirstOrDefault();
            }

            //Tạo list chứa các thông tin chi tiết của sản phẩm, bao gồm mã vật liệu và số lượng
            List<DetailedProductDTO> detailedProduct = new List<DetailedProductDTO>();

            //duyệt datagridview
            foreach (DataGridViewRow row in dgvProductDetails.Rows)
            {
                string? id = row.Cells[0].Value?.ToString();
                if (id != null && Int16.TryParse(row.Cells[3].Value?.ToString(), out short quantity))
                {
                    detailedProduct.Add(new DetailedProductDTO()
                    {
                        MaterialId = id,
                        UsedQuantity = quantity
                    });
                }
                else
                {
                    MessageBox.Show("Invalid quantity value in product details.", "Error");
                }
            }

            //product này chưa có ID, xuống dưới DL mới có ID
            ProductDTO product = new ProductDTO()
            {
                DetailedProducts = detailedProduct,
                FrepresentationId = idFRepresentation,
                ProductName = productName
            };

            //Lấy unit price
            string unitPrice = txtBxUnitPrice.Text;
            decimal price = ConvertFromCurrency(unitPrice);

            //Xử lý sản phẩm trả về sau khi thêm mới sản phẩm
            ReturnedProductDTO returnedProduct = await _productService.AddAbstractProductAsync(product);

            if (returnedProduct.HasExisted == true)
            {
                MessageBox.Show($"Sản phẩm đã tồn tại trong hệ thống với ID là {returnedProduct.Product.ProductId} và tên là {returnedProduct.Product.ProductName}");
            }
            else
            {
                MessageBox.Show($"Sản phẩm đã được thêm mới với ID là {returnedProduct.Product.ProductId} và tên là {returnedProduct.Product.ProductName}");
            }

            //Chuyển dữ liệu qua form SalesOrder để hiển thị 
            SalesOrderForm.Instance.AddProductOfPreorderToDgv(returnedProduct.Product, price);
        }

        private async void btnClear_Click(object sender, EventArgs e)
        {
            if (txtBxCreationQuantity.Text == string.Empty)
            {
                MessageBox.Show("Không có gì để xoá cả", "Thông báo");
                return;
            }

            DialogResult dialog = MessageBox.Show("Bạn có chắc muốn xoá bỏ các thông tin đã nhập?", "Cảnh báo", MessageBoxButtons.YesNo);

            if (dialog == DialogResult.Yes)
            {
                CancelSelection(dgvFlowerList);
                CancelSelection(dgvAccessoryList);

                // Clear the rows in dgvProductDetails
                //dgvProductDetails.Rows.Clear();

                txtBxProductName.Clear();
                cmbBxFR.Text = string.Empty;
                txtBxCreationQuantity.Clear();
                txtBxUnitPrice.Text = string.Empty;

                // Recalculate the unit price
                //await CalculateAndDisplayUnitPrice();
            }
        }

        private void CancelSelection(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                DataGridViewCell cell = row.Cells[dgv.Columns.Count - 1];

                // Kiểm tra giá trị của ô có phải là true không
                if (cell.Value != null && cell.Value is bool isChecked && isChecked)
                {
                    cell.Value = false;
                }
            }

        }

        //Đồng bộ các vật liệu ở tab Flower và Accessory sang tab Product
        private bool TryFindRowById(string id, out int index)
        {
            int numberOfRows = dgvProductDetails.Rows.Count;
            index = -1;

            for (int i = 0; i < numberOfRows; i++)
            {
                string? idValue = dgvProductDetails.Rows[i].Cells[0].Value.ToString();

                if (idValue != null && idValue == id)
                {
                    index = i;
                    return true;
                }
            }

            return false;
        }

        private void UpdateDataOfProductDetails(DataGridView dgvSource, DataGridViewCellEventArgs eOfThatDgv)
        {
            if (eOfThatDgv.RowIndex >= 0 && eOfThatDgv.ColumnIndex >= 0 && dgvSource.Columns[eOfThatDgv.ColumnIndex] is DataGridViewCheckBoxColumn)
            {
                // Lấy giá trị của ô checkbox
                var cellValue = dgvSource.Rows[eOfThatDgv.RowIndex].Cells[eOfThatDgv.ColumnIndex].Value;
                string? idCell = dgvSource.Rows[eOfThatDgv.RowIndex].Cells[0].Value.ToString();
                string? nameCell = dgvSource.Rows[eOfThatDgv.RowIndex].Cells[1].Value.ToString();

                Debug.WriteLine($"id cell: {idCell}; name cell: {nameCell}");


                // Kiểm tra giá trị của ô checkbox có phải là null không
                if (cellValue != null && cellValue is bool isChecked)
                {
                    if (isChecked)
                    {
                        dgvProductDetails.Rows.Add(idCell, nameCell, null, "1", null);
                    }
                    else
                    {

                        if (idCell != null && TryFindRowById(idCell, out int index))
                        {
                            dgvProductDetails.Rows.RemoveAt(index);
                        }
                    }
                }
            }
        }

        //Kiểm tra số lượng vật liệu nhập vô
        private async void dgvProductDetails_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 3) // Assuming the quantity column index is 3
            {
                var cellValue = dgvProductDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (cellValue != null && int.TryParse(cellValue.ToString(), out int newValue))
                {
                    if (newValue <= 0)
                    {
                        MessageBox.Show("Số lượng phải lớn hơn 0.", "Cảnh báo");
                        dgvProductDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 1; // Reset to 1 if invalid
                        return;
                    }

                    await CalculateAndDisplayUnitPrice();
                }
                else
                {
                    MessageBox.Show("Giá trị không hợp lệ.", "Cảnh báo");
                    dgvProductDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 1; // Reset to 1 if invalid

                    await CalculateAndDisplayUnitPrice();
                }
            }
        }

        //Lắng nghe event khi row được thêm vô
        private async void dgvProductDetails_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dgvProductDetails.Rows.Count == 1)
            {
                txtBxCreationQuantity.Text = "1";
            }

            //tính toán unit price
            await CalculateAndDisplayUnitPrice();

        }

        //Lắng nghe event khi row bị xoá
        private async void dgvProductDetails_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dgvProductDetails.Rows.Count == 0)
            {
                txtBxCreationQuantity.Text = string.Empty;
            }

            await CalculateAndDisplayUnitPrice();
        }

        //tính toán unit price
        private async Task CalculateAndDisplayUnitPrice()
        {
            if (_isCalculatingUnitPrice)
            {
                return;
            }

            _isCalculatingUnitPrice = true;

            try
            {
                var materialQuantities = new Dictionary<string, int>();

                foreach (DataGridViewRow row in dgvProductDetails.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[3].Value != null)
                    {
                        string materialId = row.Cells[0].Value.ToString()!;
                        int quantity = Convert.ToInt32(row.Cells[3].Value);

                        if (!materialQuantities.ContainsKey(materialId))
                        {
                            materialQuantities.Add(materialId, quantity);
                        }
                    }
                }

                decimal unitPrice = await _productService.CalculateUnitPriceAsync(materialQuantities, null);
                txtBxUnitPrice.Text = unitPrice.ToString("C", new CultureInfo("vi-VN"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
            finally
            {
                _isCalculatingUnitPrice = false;
            }
            
        }

        //xử lý khi user click vô hai ô image của dgv product
        private void dgvProductDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dgvProductDetails.Columns[e.ColumnIndex] is DataGridViewImageColumn)
            {
                var cellValue = dgvProductDetails.Rows[e.RowIndex].Cells[3].Value;
                if (cellValue != null && int.TryParse(cellValue.ToString(), out int currentValue))
                {
                    string materialId = dgvProductDetails.Rows[e.RowIndex].Cells[0].Value.ToString()!;
                    int productQuantity = int.TryParse(txtBxCreationQuantity.Text, out int pq) ? pq : 1;

                    if (e.ColumnIndex == 2)
                    {
                        int newValue = currentValue - 1;
                        if (newValue > 0)
                        {
                            dgvProductDetails.Rows[e.RowIndex].Cells[3].Value = newValue.ToString();
                        }
                    }
                    else if (e.ColumnIndex == 4)
                    {
                        int newValue = currentValue + 1;
                        dgvProductDetails.Rows[e.RowIndex].Cells[3].Value = newValue.ToString();

                    }
                }
                else
                {
                    MessageBox.Show("The cell value is not a valid integer.");
                }
            }
        }

        //================Xử lý cho tab Flower=========================

        //Load dữ liệu flower của cửa hàng
        private async Task LoadAllFlowersAsync()
        {
            try
            {
                var result = await _materialService.GetAllFlowersAsync();

                if (result == null)
                {
                    MessageBox.Show("Danh sách hoa hiện tại đang trống");
                }
                else
                {
                    _flowers = result;
                    dgvFlowerList.DataSource = _flowers;

                    LoadComboBoxData(_flowers);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Message: {e.Message}");
            }
        }

        //Lọc dữ liệu theo loại hoa
        private void LoadComboBoxData(List<FlowerDTO> flowerList)
        {
            var floralTypes = flowerList.Select(f => f.FTypeName).Distinct().ToList();
            var floralColors = flowerList.Select(f => f.FColorName).Distinct().ToList();
            var floralCharacteristics = flowerList.Select(f => f.FCharacteristicName).Distinct().ToList();

            floralTypes.Insert(0, "All");
            floralColors.Insert(0, "All");
            floralCharacteristics.Insert(0, "All");

            cmbBxFloralType.DataSource = floralTypes;
            cmbBxFloralColor.DataSource = floralColors;
            cmbBxFloralCharacteristic.DataSource = floralCharacteristics;

            cmbBxFloralType.SelectedIndex = 0;
            cmbBxFloralColor.SelectedIndex = 0;
            cmbBxFloralCharacteristic.SelectedIndex = 0;
        }

        private void FilterFlowerList()
        {
            var filteredList = _flowers.AsQueryable();

            if (cmbBxFloralType.SelectedItem != null && cmbBxFloralType.SelectedItem.ToString() != "All")
            {
                filteredList = filteredList.Where(f => f.FTypeName == cmbBxFloralType.SelectedItem.ToString());
            }

            if (cmbBxFloralColor.SelectedItem != null && cmbBxFloralColor.SelectedItem.ToString() != "All")
            {
                filteredList = filteredList.Where(f => f.FColorName == cmbBxFloralColor.SelectedItem.ToString());
            }

            if (cmbBxFloralCharacteristic.SelectedItem != null && cmbBxFloralCharacteristic.SelectedItem.ToString() != "All")
            {
                filteredList = filteredList.Where(f => f.FCharacteristicName == cmbBxFloralCharacteristic.SelectedItem.ToString());
            }

            dgvFlowerList.DataSource = filteredList.ToList();
        }
        private void cmbBxFloralType_SelectedIndexChanged(object sender, EventArgs e)
        {
            CancelSelection(dgvFlowerList);
            FilterFlowerList();
        }

        //Lọc dữ liệu theo màu hoa
        private void cmbBxFloralColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            CancelSelection(dgvFlowerList);
            FilterFlowerList();
        }

        //Lọc dữ liệu theo đặc điểm hoa
        private void cmbBxFloralCharacteristic_SelectedIndexChanged(object sender, EventArgs e)
        {
            CancelSelection(dgvFlowerList);
            FilterFlowerList();
        }

        //Xác nhận action ngay lập tức khi user tick vô checkbox
        private void dgvFlowerList_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvFlowerList.IsCurrentCellDirty)
            {
                // Xác nhận giá trị của ô hiện tại ngay lập tức
                dgvFlowerList.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        //Lắng nghe event user tick vô checkbox
        private void dgvFlowerList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            UpdateDataOfProductDetails(dgvFlowerList, e);
        }

        //================Xử lý cho tab Accessory=================
        //Load dữ liệu accessory lên
        private async Task LoadAllAccessories()
        {
            try
            {
                var result = await _materialService.GetAllAccessoriesAsync();

                if (result == null)
                {
                    MessageBox.Show("Danh sách phụ liệu hiện tại đang trống");
                }
                else
                {
                    _accessories = result;
                    dgvAccessoryList.DataSource = _accessories;
                }

            }
            catch (Exception e)
            {
                MessageBox.Show($"Message: {e.Message}");
            }
        }

        //Update dữ liệu bên Product khi user tick vô checkbox
        private void dgvAccessoryList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            UpdateDataOfProductDetails(dgvAccessoryList, e);
        }

        //Cập nhật action ngay lập tức khi có change
        private void dgvAccessoryList_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvAccessoryList.IsCurrentCellDirty)
            {
                // Xác nhận giá trị của ô hiện tại ngay lập tức
                dgvAccessoryList.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        //Xử lý khi click vô checkbox của accessory
        private void dgvAccessoryList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAccessoryList.Columns[e.ColumnIndex] is DataGridViewTextBoxColumn)
            {
                dgvAccessoryList.CurrentCell = null;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
