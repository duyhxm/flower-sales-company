using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO.Material;
using BL;
using DTO;
using System.Diagnostics;
using DTO.Product;
using DTO.Store;
using System.Globalization;

namespace PL
{
    public partial class ProductCreationForm : System.Windows.Forms.Form
    {
        private static ProductCreationForm? _instance;
        private static readonly object _lock = new object();
        private NotificationService notificationService;
        private MaterialService materialService;
        private readonly string? storeId = LoginForm.Instance.LoginInformation.StoreID;
        private BindingSource accessoryBs;
        //private BindingSource productDetailsBs;
        private bool isHandlingCellValueChangedOfProductDetails = false;
        private ProductService _productService;
        private List<FlowerWithStockDTO>? originalFlowerList;

        private List<FloralRepresentationDTO>? fRepresentations;
        private List<StoreInventoryDTO> storeInventory;
        private ProductCreationForm()
        {
            InitializeComponent();
            notificationService = StoreMainForm.Instance.NotificationService;
            materialService = new MaterialService();
            _productService = new ProductService();
            accessoryBs = new BindingSource();
            //productDetailsBs = new BindingSource();

            //Set DataPropertyName
            dgvFlowerList.Columns[0].DataPropertyName = "FlowerID";
            dgvFlowerList.Columns[1].DataPropertyName = "FlowerName";
            dgvFlowerList.Columns[2].DataPropertyName = "FTypeName";
            dgvFlowerList.Columns[3].DataPropertyName = "FColorName";
            dgvFlowerList.Columns[4].DataPropertyName = "FCharacteristicName";
            dgvFlowerList.AutoGenerateColumns = false;

            dgvAccessoryList.Columns[0].DataPropertyName = "MaterialID";
            dgvAccessoryList.Columns[1].DataPropertyName = "MaterialName";
            dgvAccessoryList.AutoGenerateColumns = false;

            txtBxCreationQuantity.ReadOnly = true;
            txtBxCreationQuantity.Enabled = false;
        }

        public static void Initialize()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    try
                    {
                        _instance = new ProductCreationForm();
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
            var storeMainForm = StoreMainForm.Instance;
            if (storeMainForm.formInstances.ContainsKey("InventoryForm"))
            {
                var inventoryForm = storeMainForm.formInstances["InventoryForm"] as InventoryForm;
                if (inventoryForm != null)
                {
                    storeInventory = inventoryForm.storeInventory;
                }
            }

            await LoadFlowerListAsync();
            await LoadAccessoryListAsync();
            await LoadFloralRepresentation();

            MessageBox.Show("Form is load");
        }

        //===================Xử lý cho tab Product Information===================

        private async Task LoadFloralRepresentation()
        {
            fRepresentations = await materialService.GetFloralRepresentationAsync();

            if (fRepresentations != null)
            {
                foreach (var f in fRepresentations)
                {
                    cmbBxFloralRepresentations.Items.Add(f.Frname!);
                }
            }
        }

        private bool IsStockAvailableForIncrease(string materialId, int requiredAmount)
        {
            var material = InventoryForm.Instance.storeInventory.FirstOrDefault(m => m.MaterialId == materialId);
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
            //Kiểm tra tính hợp lệ của các thông tin
            string creationQuantity = txtBxCreationQuantity.Text;
            if (creationQuantity == string.Empty)
            {
                MessageBox.Show("Bạn cần thêm tối thiểu 1 mặt hàng", "Cảnh báo");
                return;
            }

            string floralRepresentation = cmbBxFloralRepresentations.Text;
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

            //Lấy unit price
            string unitPrice = txtBxUnitPrice.Text;

            //Lấy floral representation id
            string? idFRepresentation = null;
            if (fRepresentations != null)
            {
                idFRepresentation = fRepresentations
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

            ProductDTO product = new ProductDTO()
            {
                DetailedProducts = detailedProduct,
                FrepresentationId = idFRepresentation,
                ProductName = productName
            };

            short createdQuantity = Convert.ToInt16(creationQuantity);
            decimal price = GeneralService.ConvertFormattedStringToDecimal(unitPrice);

            ProductCreationHistoryDTO creationHistory = new ProductCreationHistoryDTO()
            {
                CreatedDateTime = GeneralService.LocalDateTimeOffset(),
                EmployeeId = LoginForm.Instance.LoginInformation.UserAccount.EmployeeId!,
                CreatedQuantity = createdQuantity,
                UnitPrice = price
            };

            await _productService.AddProductAsync(product, creationHistory, storeId);

            UpdateStoreInventory();

            MessageBox.Show("Đã thêm thành công sản phẩm", "Thông báo");
        }

        private void UpdateStoreInventory()
        {
            try
            {
                var inventoryForm = InventoryForm.Instance;
                var storeInventory = inventoryForm.storeInventory;

                // Update storeInventory based on dgvProductDetails
                Dictionary<string, int> updatedQuantities = new Dictionary<string, int>();

                foreach (DataGridViewRow row in dgvProductDetails.Rows)
                {
                    string materialId = row.Cells[0].Value.ToString();
                    int materialQuantity = Convert.ToInt32(row.Cells[3].Value);
                    int productQuantity = int.TryParse(txtBxCreationQuantity.Text, out int pq) ? pq : 1;
                    int requiredAmount = materialQuantity * productQuantity;

                    var inventoryItem = storeInventory.FirstOrDefault(si => si.MaterialId == materialId);
                    if (inventoryItem != null)
                    {
                        inventoryItem.StockMaterialQuantity -= requiredAmount;
                        if (inventoryItem.StockMaterialQuantity <= 0)
                        {
                            storeInventory.Remove(inventoryItem);
                        }
                        else
                        {
                            updatedQuantities[materialId] = inventoryItem.StockMaterialQuantity;
                        }
                    }
                }

                // Refresh InventoryForm
                inventoryForm.RefreshStoreInventory();
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
                txtBxProductId.Clear();
                txtBxProductName.Clear();
                cmbBxFloralRepresentations.Text = string.Empty;
                txtBxCreationQuantity.Clear();
                txtBxUnitPrice.Clear();

                CancelSelection(dgvFlowerList);
                CancelSelection(dgvAccessoryList);
            }
        }

        //Xử lý khi user nhấn Clear dữ liệu giống trên
        private void CancelSelection(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                DataGridViewCell cell = dgv.Name == "dgvFlowerList" ? row.Cells[0] : row.Cells[dgv.Columns.Count - 1];

                // Kiểm tra giá trị của ô có phải là true không
                if (cell.Value != null && cell.Value is bool isChecked && isChecked)
                {
                    cell.Value = false;
                }
            }

        }

        //Xử lý khi user click tăng giảm số lượng

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

        //Đồng bộ các vật liệu ở tab Flower và Accessory sang tab Product
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
        private void dgvProductDetails_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (isHandlingCellValueChangedOfProductDetails)
            {
                return;
            }

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

                    string materialId = dgvProductDetails.Rows[e.RowIndex].Cells[0].Value.ToString();
                    int productQuantity = int.TryParse(txtBxCreationQuantity.Text, out int pq) ? pq : 1;
                    int requiredAmount = newValue * productQuantity;

                    if (!IsStockAvailableForIncrease(materialId, requiredAmount))
                    {
                        MessageBox.Show($"Số lượng sản phẩm vượt quá tồn kho của vật liệu {materialId}", "Cảnh báo");
                        dgvProductDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 1; // Reset to 1 if invalid
                    }
                }
                else
                {
                    MessageBox.Show("Giá trị không hợp lệ.", "Cảnh báo");
                    dgvProductDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 1; // Reset to 1 if invalid
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

        private async Task CalculateAndDisplayUnitPrice()
        {
            var materialQuantities = new Dictionary<string, int>();

            foreach (DataGridViewRow row in dgvProductDetails.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[3].Value != null)
                {
                    string materialId = row.Cells[0].Value.ToString();
                    int quantity = Convert.ToInt32(row.Cells[3].Value);

                    if (!materialQuantities.ContainsKey(materialId))
                    {
                        materialQuantities.Add(materialId, quantity);
                    }
                }
            }

            decimal unitPrice = await _productService.CalculateUnitPriceAsync(InventoryForm.Instance.storeInventory, materialQuantities);
            txtBxUnitPrice.Text = unitPrice.ToString("C", new CultureInfo("vi-VN"));
        }

        //================Xử lý cho tab Flower=========================

        //Load dữ liệu flower của cửa hàng
        private async Task LoadFlowerListAsync()
        {
            try
            {
                List<FlowerDTO>? flowerList = null;

                if (storeId != null)
                {
                    flowerList = await materialService.GetAllFlowerByStoreAsync(storeId);
                    var materialInventoryList = await materialService.GetAllMaterialByStoreAsync(storeId, "hoa");

                    originalFlowerList = flowerList?
                        .Join(materialInventoryList,
                            fl => fl.FlowerID,
                            mi => mi.MaterialID,
                            (fl, mi) => new FlowerWithStockDTO
                            {
                                FlowerID = fl.FlowerID,
                                FlowerName = fl.FlowerName,
                                FTypeName = fl.FTypeName,
                                FColorName = fl.FColorName,
                                FCharacteristicName = fl.FCharacteristicName,
                                StockMaterialQuantity = (int)mi.StockMaterialQuantity!
                            })
                        .ToList();

                    dgvFlowerList.DataSource = originalFlowerList;

                    LoadComboBoxData(originalFlowerList!);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Message: {e.Message}");
            }
        }


        //Lọc dữ liệu theo loại hoa
        private void LoadComboBoxData(List<FlowerWithStockDTO> flowerList)
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
            var filteredList = originalFlowerList!.AsQueryable();

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
        private async Task LoadAccessoryListAsync()
        {
            try
            {
                if (storeId != null)
                {
                    List<MaterialInventoryDTO> acessoryList = await materialService.GetAllMaterialByStoreAsync(storeId, "phụ liệu");
                    accessoryBs.DataSource = acessoryList;
                    dgvAccessoryList.DataSource = accessoryBs;
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

        //
        private void dgvAccessoryList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAccessoryList.Columns[e.ColumnIndex] is DataGridViewTextBoxColumn)
            {
                dgvAccessoryList.CurrentCell = null;
            }
        }

        private void btnTestBindingSource_Click(object sender, EventArgs e)
        {
            accessoryBs.RemoveAt(0);
            accessoryBs.ResetBindings(false);
        }

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
                    string materialId = row.Cells[0].Value.ToString();
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

        private void dgvProductDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dgvProductDetails.Columns[e.ColumnIndex] is DataGridViewImageColumn)
            {
                var cellValue = dgvProductDetails.Rows[e.RowIndex].Cells[3].Value;
                if (cellValue != null && int.TryParse(cellValue.ToString(), out int currentValue))
                {
                    string materialId = dgvProductDetails.Rows[e.RowIndex].Cells[0].Value.ToString();
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
    }
}
