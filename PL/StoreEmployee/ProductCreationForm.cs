﻿using BL;
using DTO.Material;
using DTO.Product;
using DTO.Store;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Diagnostics;
using System.Globalization;
using static BL.GeneralService;

namespace PL
{
    public partial class ProductCreationForm : Form
    {
        //khai báo biến liên quan đến việc khởi tạo
        private static ProductCreationForm? _instance;
        private static readonly object _lock = new object();

        //khai báo các service sẽ dùng
        private NotificationService _notificationService; //lấy từ bên StoreMainForm hoặc bên SalesDeptMainForm
        private MaterialService _materialService = new();
        private ProductService _productService = new();
        private StoreService _storeService = new();

        //khai báo các biến sẽ sử dụng trong form
        private readonly string? _storeId = LoginForm.Instance.LoginInformation.StoreID;
        private List<FloralRepresentationDTO>? _fRepresentations = new();
        private List<FlowerDTO> _flowers = new List<FlowerDTO>();
        private List<MaterialInventoryDTO> _accessories = new();

        private BindingSource _flowerBindingSource = new BindingSource();
        private BindingSource _accessoryBindingSource = new BindingSource();

        private ProductCreationForm(NotificationService notificationService)
        {
            //khởi tạo các thành phần designer
            InitializeComponent();

            //khởi tạo các service
            _notificationService = notificationService;

            InitializeDataGridView();

            //Cấu hình data property name cho flower 
            SetupFlowerDgv();

            //cấu hình data property name cho accessory
            SetupAccessoryDgv();

            //Cấu hình cho text box 'số lượng sản phẩm'
            txtBxCreationQuantity.ReadOnly = true;
            txtBxCreationQuantity.Enabled = false;
        }

        private void SetupFlowerDgv()
        {
            dgvFlowerList.Columns[0].DataPropertyName = "FlowerID";
            dgvFlowerList.Columns[1].DataPropertyName = "FlowerName";
            dgvFlowerList.Columns[2].DataPropertyName = "FTypeName";
            dgvFlowerList.Columns[3].DataPropertyName = "FColorName";
            dgvFlowerList.Columns[4].DataPropertyName = "FCharacteristicName";
            dgvFlowerList.AutoGenerateColumns = false;
        }

        private void SetupAccessoryDgv()
        {
            dgvAccessoryList.Columns[0].DataPropertyName = "MaterialID";
            dgvAccessoryList.Columns[1].DataPropertyName = "MaterialName";
            dgvAccessoryList.AutoGenerateColumns = false;
        }

        private void InitializeDataGridView()
        {
            dgvFlowerList.DataSource = _flowerBindingSource;
            dgvAccessoryList.DataSource = _accessoryBindingSource;
        }

        public void SetFlowerData(List<FlowerDTO> flowers)
        {
            _flowerBindingSource.DataSource = flowers;
        }

        public void SetAccessoryData(List<MaterialInventoryDTO> accessories)
        {
            _accessoryBindingSource.DataSource = accessories;
        }

        public static void Initialize(NotificationService notificationService)
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    try
                    {
                        _instance = new ProductCreationForm(notificationService);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }

        public static ProductCreationForm Instance
        {
            get
            {
                if (_instance == null)
                {
                    throw new InvalidOperationException("ProductCreationForm is not initialized. Call Initialize() first.");
                }
                return _instance;
            }
        }

        private async void ProductCreationForm_Load(object sender, EventArgs e)
        {
            await LoadAllFlowersByStoreAsync();
            LoadAllAccessories();
            await LoadAllFRepresentations();
        }

        //===================Xử lý cho tab Product Information===================

        private async Task LoadAllFRepresentations()
        {
            _fRepresentations = await _materialService.GetAllFRepresentationsAsync();

            cmbBxFloralRepresentations.DataSource = _fRepresentations;
            cmbBxFloralRepresentations.DisplayMember = "Frname";
            cmbBxFloralRepresentations.ValueMember = "FrepresentationId";
        }

        //xử lý khi user click nút tăng giảm số lượng sản phẩm
        private bool IsStockAvailableForIncrease(string materialId, int requiredAmount)
        {
            var material = InventoryForm.Instance.MaterialInventory.FirstOrDefault(m => m.MaterialId == materialId);
            if (material != null)
            {
                return requiredAmount <= material.StockMaterialQuantity;
            }
            return false;
        }
        private void ibtnIncrease_Click(object sender, EventArgs e)
        {
            if (txtBxCreationQuantity.ReadOnly == false && int.TryParse(txtBxCreationQuantity.Text, out int value) && value > 0)
            {
                bool canIncrease = true;
                foreach (DataGridViewRow row in dgvProductDetails.Rows)
                {
                    string materialId = row.Cells[0].Value.ToString();
                    int materialQuantity = Convert.ToInt32(row.Cells[3].Value);
                    int requiredAmount = materialQuantity * (value + 1);

                    if (!IsStockAvailableForIncrease(materialId, requiredAmount))
                    {
                        canIncrease = false;
                        MessageBox.Show($"Số lượng sản phẩm vượt quá tồn kho của vật liệu {materialId}", "Cảnh báo");
                        break;
                    }
                }

                if (canIncrease)
                {
                    ++value;
                    txtBxCreationQuantity.Text = value.ToString();
                }
            }
        }

        private void ibtnDecrease_Click(object sender, EventArgs e)
        {
            if (txtBxCreationQuantity.ReadOnly == false && int.TryParse(txtBxCreationQuantity.Text, out int value) && value > 1)
            {
                --value;
                txtBxCreationQuantity.Text = value.ToString();
            }
        }

        //Thêm product
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            //Kiểm tra số lượng sản phẩm
            string creationQuantity = txtBxCreationQuantity.Text;
            if (creationQuantity == string.Empty)
            {
                MessageBox.Show("Bạn cần thêm tối thiểu 1 mặt hàng", "Cảnh báo");
                return;
            }

            //Kiểm tra hình thức sản phẩm
            string floralRepresentation = cmbBxFloralRepresentations.Text;
            if (floralRepresentation == string.Empty)
            {
                MessageBox.Show("Không được để trống hình thức hoa", "Cảnh báo");
                return;
            }

            //Kiểm tra tên sản phẩm
            string productName = txtBxProductName.Text;
            if (productName == string.Empty)
            {
                MessageBox.Show("Không được để trống tên sản phẩm", "Cảnh báo");
                return;
            }

            //Sau khi kiểm tra tính hợp lệ, nếu hợp lệ thì sẽ tiếp tục thực hiện các phần dưới đây

            //Lấy unit price
            string unitPrice = txtBxUnitPrice.Text;

            //Lấy floral representation id
            string? frId = cmbBxFloralRepresentations.SelectedValue!.ToString();

            //Tạo list chứa các thông tin chi tiết của sản phẩm, bao gồm mã vật liệu và số lượng
            List<DetailedProductDTO> detailedProduct = new List<DetailedProductDTO>();

            //Duyệt datagridview để tạo chi tiết sản phẩm
            foreach (DataGridViewRow row in dgvProductDetails.Rows)
            {
                string? id = row.Cells[0].Value?.ToString();
                if (id != null && Int16.TryParse(row.Cells[3].Value?.ToString(), out short quantity))
                {
                    //Thêm vô danh sách chứa chi tiết sản phẩm
                    detailedProduct.Add(new DetailedProductDTO()
                    {
                        MaterialId = id,
                        UsedQuantity = quantity
                    });
                }
                else
                {
                    MessageBox.Show("Giá trị không hợp lệ", "Lỗi");
                }
            }

            //Tạo sản phẩm. Ở đây sẽ chỉ tạo 3 thuộc tính, trừ thuộc tính ProductId. Vì thuộc tính ProductId sẽ được tạo ra ở dưới database
            ProductDTO product = new ProductDTO()
            {
                DetailedProducts = detailedProduct,
                FrepresentationId = frId,
                ProductName = productName
            };


            //Số lượng sản phẩm được tạo ra
            short createdQuantity = Convert.ToInt16(creationQuantity);

            //Unit price của sản phẩm
            decimal price = ConvertFromCurrency(unitPrice);

            //Tạo lịch sử tạo sản phẩm
            ProductCreationHistoryDTO creationHistory = new ProductCreationHistoryDTO()
            {
                CreatedDateTime = LocalDateTimeOffset(),
                EmployeeId = LoginForm.Instance.LoginInformation.UserAccount.EmployeeId!,
                CreatedQuantity = createdQuantity,
                UnitPrice = price
            };

            //Xử lý sản phẩm trả về sau khi thêm mới sản phẩm
            ReturnedProductDTO returnedProduct = await _productService.AddProductAsync(product, creationHistory, _storeId!);

            if (returnedProduct.HasExisted)
            {
                MessageBox.Show($"Sản phẩm đã tồn tại, tên là {returnedProduct.Product.ProductName}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //Sau khi thêm sản phẩm thành công, update giao diện bên Inventory
            await UpdateStoreInventory();

            //Refresh danh sách hoa và phụ liệu trong form này
            await RefreshFlowerList();
            RefreshAllAccessories();
            dgvProductDetails.Rows.Clear();
            txtBxProductName.Text = string.Empty;

            MessageBox.Show("Đã thêm thành công sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Update store inventory sẽ bao gồm material và product
        private async Task UpdateStoreInventory()
        {
            try
            {
                var inventoryForm = InventoryForm.Instance;
                var materialInventory = inventoryForm.MaterialInventory;
                var productInventory = inventoryForm.ProductInventory;

                // Update materialInventory based on dgvProductDetails
                Dictionary<string, int> updatedQuantities = new Dictionary<string, int>();

                foreach (DataGridViewRow row in dgvProductDetails.Rows)
                {
                    string materialId = row.Cells[0].Value.ToString()!;
                    int materialQuantity = Convert.ToInt32(row.Cells[3].Value);
                    int productQuantity = int.TryParse(txtBxCreationQuantity.Text, out int pq) ? pq : 1;
                    int requiredAmount = materialQuantity * productQuantity;

                    var inventoryItem = materialInventory.FirstOrDefault(si => si.MaterialId == materialId);
                    if (inventoryItem != null)
                    {
                        inventoryItem.StockMaterialQuantity -= requiredAmount;
                        if (inventoryItem.StockMaterialQuantity <= 0)
                        {
                            materialInventory.Remove(inventoryItem);
                        }
                        else
                        {
                            updatedQuantities[materialId] = inventoryItem.StockMaterialQuantity;
                        }
                    }
                }

                // Refresh InventoryForm
                await inventoryForm.RefreshStoreInventory();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Xử lý khi user nhấn Clear dữ liệu 
        private void btnClear_Click(object sender, EventArgs e)
        {
            if (txtBxCreationQuantity.Text == string.Empty)
            {
                MessageBox.Show("Không có gì để xoá cả", "Thông báo");
                return;
            }

            DialogResult dialog = MessageBox.Show("Bạn có chắc muốn xoá bỏ các thông tin đã nhập?", "Cảnh báo", MessageBoxButtons.YesNo);

            if (dialog == DialogResult.Yes)
            {
                txtBxProductName.Clear();
                cmbBxFloralRepresentations.Text = string.Empty;
                txtBxCreationQuantity.Clear();
                txtBxUnitPrice.Clear();

                CancelSelection(dgvFlowerList);
                CancelSelection(dgvAccessoryList);
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

                    string materialId = dgvProductDetails.Rows[e.RowIndex].Cells[0].Value.ToString()!;
                    int productQuantity = int.TryParse(txtBxCreationQuantity.Text, out int pq) ? pq : 1;
                    int requiredAmount = newValue * productQuantity;

                    if (!IsStockAvailableForIncrease(materialId, requiredAmount))
                    {
                        MessageBox.Show($"Số lượng sản phẩm vượt quá tồn kho của vật liệu {materialId}", "Cảnh báo");
                        dgvProductDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 1; // Reset to 1 if invalid
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
                txtBxCreationQuantity.ReadOnly = false;
                txtBxCreationQuantity.Enabled = true;
                txtBxCreationQuantity.Text = "1";
                //Lấy thông tin ProductID
            }

            //tính toán unit price
            await CalculateAndDisplayUnitPrice();

        }

        //Lắng nghe event khi row bị xoá
        private async void dgvProductDetails_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dgvProductDetails.Rows.Count == 0)
            {
                txtBxCreationQuantity.ReadOnly = true;
                txtBxCreationQuantity.Enabled = false;
                txtBxCreationQuantity.Text = string.Empty;
            }

            await CalculateAndDisplayUnitPrice();
        }

        //tính toán unit price
        private async Task CalculateAndDisplayUnitPrice()
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

            decimal unitPrice = await _productService.CalculateUnitPriceAsync(materialQuantities, InventoryForm.Instance.MaterialInventory);
            txtBxUnitPrice.Text = unitPrice.ToString("C", new CultureInfo("vi-VN"));
        }

        //Xử lý khi user nhập số lượng sản phẩm
        private void txtBxCreationQuantity_Validating(object sender, CancelEventArgs e)
        {
            if (txtBxCreationQuantity.ReadOnly == true)
            {
                return;
            }

            if (int.TryParse(txtBxCreationQuantity.Text, out int value) && value > 0)
            {
                foreach (DataGridViewRow row in dgvProductDetails.Rows)
                {
                    string materialId = row.Cells[0].Value.ToString()!;
                    int materialQuantity = Convert.ToInt32(row.Cells[3].Value);
                    int requiredAmount = materialQuantity * value;

                    if (!IsStockAvailableForIncrease(materialId, requiredAmount))
                    {
                        MessageBox.Show($"Số lượng sản phẩm vượt quá tồn kho của vật liệu {materialId}", "Cảnh báo");
                        e.Cancel = true;
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Giá trị không hợp lệ.", "Cảnh báo");
                e.Cancel = true;
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
                        int requiredAmount = (currentValue + 1) * productQuantity;
                        if (IsStockAvailableForIncrease(materialId, requiredAmount))
                        {
                            int newValue = currentValue + 1;
                            dgvProductDetails.Rows[e.RowIndex].Cells[3].Value = newValue.ToString();
                        }
                        else
                        {
                            MessageBox.Show($"Số lượng sản phẩm vượt quá tồn kho của vật liệu {materialId}", "Cảnh báo");
                        }
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
        private async Task LoadAllFlowersByStoreAsync()
        {
            try
            {
                List<FlowerDTO> flowerDtoInventory;

                if (_storeId != null)
                {
                    flowerDtoInventory = await _storeService.GetAllFlowerByStoreAsync(_storeId);

                    var materialInventory = InventoryForm.Instance.MaterialInventory;

                    if (flowerDtoInventory == null)
                    {
                        MessageBox.Show("Hoa hiện tại đang hết hàng ở cửa hàng này");
                        return;
                    }
                    _flowers = flowerDtoInventory
                                    .Join(materialInventory,
                                         fl => fl.FlowerID,
                                         t => t.MaterialId,
                                         (fl, t) => new FlowerDTO
                                         {
                                             FlowerID = fl.FlowerID,
                                             FlowerName = fl.FlowerName,
                                             FTypeName = fl.FTypeName,
                                             FColorName = fl.FColorName,
                                             FCharacteristicName = fl.FCharacteristicName
                                         }
                                    ).ToList();

                    //dgvFlowerList.DataSource = _flowers;
                    SetFlowerData(_flowers);

                    LoadComboBoxData(_flowers);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Message: {e.Message}");
            }
        }

        private async Task RefreshFlowerList()
        {
            await LoadAllFlowersByStoreAsync();
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
            FilterFlowerList();
        }

        //Lọc dữ liệu theo màu hoa
        private void cmbBxFloralColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterFlowerList();
        }

        //Lọc dữ liệu theo đặc điểm hoa
        private void cmbBxFloralCharacteristic_SelectedIndexChanged(object sender, EventArgs e)
        {
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
        private void LoadAllAccessories()
        {
            try
            {
                if (_storeId != null)
                {
                    List<MaterialInventoryDTO> accessoryList = InventoryForm.Instance.MaterialInventory;

                    _accessories = accessoryList.Where(al => al.MaterialId.StartsWith("A")).ToList();

                    //dgvAccessoryList.DataSource = _accessories;
                    SetAccessoryData(_accessories);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Message: {e.Message}");
            }
        }

        public void RefreshAllAccessories()
        {
            LoadAllAccessories();
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
    }
}
