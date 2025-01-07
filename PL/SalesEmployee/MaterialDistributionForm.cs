using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;
using Azure.Messaging.ServiceBus;
using BL;
using DTO;
using System.Globalization;
using DTO.Store;
using DTO.Enum;
using DTO.Material;
using static BL.GeneralService;

namespace PL.SalesEmployee
{
    public partial class MaterialDistributionForm : Form
    {
        //Cấu hình khởi tạo đối tượng
        private static MaterialDistributionForm? _instance;
        private static readonly object _lock = new object();

        //Khai báo các service được sử dụng
        private NotificationService _notificationService;
        private StoreService _storeService = new StoreService();
        private MaterialService _materialService = new();

        //Khai báo các biến sử dụng
        private List<PurchaseOrderDTO> _purchaseOrders = new();
        private string _selectedPurchaseOrderId = string.Empty;
        private bool _isLoadRegions = false;

        //Hàm Constructor
        private MaterialDistributionForm()
        {
            InitializeComponent();
            _notificationService = NotificationService.Instance;

            SetupPurchaseOrdersDgv();
            SetupFlowerDgv();
            SetupAccessoryDgv();

            dgvFlowers.Visible = false;
            dgvAccessories.Visible = false;
            lblMaterial.Visible = false;
        }

        //Method khởi tạo form
        public static void Initialize()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    try
                    {
                        _instance = new MaterialDistributionForm();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }

        //Property để lấy instance của form
        public static MaterialDistributionForm Instance
        {
            get
            {
                if (_instance == null)
                {
                    throw new InvalidOperationException("MaterialDistributionForm chưa được khởi tạo. Gọi Initialize() trước tiên.");
                }
                return _instance;
            }
        }


        private void SetupPurchaseOrdersDgv()
        {
            dgvPurchaseOrders.AutoGenerateColumns = false;

            dgvPurchaseOrders.Columns["ColPOId"].Width = 150;
            dgvPurchaseOrders.Columns["ColPOId"].DataPropertyName = "PurchaseOrderId";

            dgvPurchaseOrders.Columns["ColPurchasedDateTime"].Width = 170;
            dgvPurchaseOrders.Columns["ColPurchasedDateTime"].DataPropertyName = "PurchasedDateTimeFormatted";

            dgvPurchaseOrders.Columns["ColOrderType"].Width = 150;
            dgvPurchaseOrders.Columns["ColOrderType"].DataPropertyName = "OrderType";

            dgvPurchaseOrders.Columns["ColDistributionStatus"].Width = 250;
            dgvPurchaseOrders.Columns["ColDistributionStatus"].DataPropertyName = "DistributionStatus";
        }

        private void SetupFlowerDgv()
        {
            dgvFlowers.AutoGenerateColumns = false;
            dgvFlowers.Enabled = true;

            dgvFlowers.Columns["ColFlowerId"].Width = 100;
            dgvFlowers.Columns["ColFlowerId"].DataPropertyName = "FlowerId";

            dgvFlowers.Columns["ColFlowerName"].Width = 250;
            dgvFlowers.Columns["ColFlowerName"].DataPropertyName = "FlowerName";

            dgvFlowers.Columns["ColFColor"].Width = 150;
            dgvFlowers.Columns["ColFColor"].DataPropertyName = "FColor";

            dgvFlowers.Columns["ColFChar"].Width = 150;
            dgvFlowers.Columns["ColFChar"].DataPropertyName = "FChar";

            dgvFlowers.Columns["ColFQuantity"].Width = 100;
            dgvFlowers.Columns["ColFQuantity"].DataPropertyName = "Quantity";

            dgvFlowers.Columns["ColFSelection"].Width = 50;
            dgvFlowers.Columns["ColFSelection"].ReadOnly = false;
        }

        private void SetupAccessoryDgv()
        {
            dgvAccessories.AutoGenerateColumns = false;
            dgvAccessories.Enabled = true;

            dgvAccessories.Columns["ColAccessoryId"].Width = 100;
            dgvAccessories.Columns["ColAccessoryId"].DataPropertyName = "AccessoryId";

            dgvAccessories.Columns["ColAccessoryName"].Width = 250;
            dgvAccessories.Columns["ColAccessoryName"].DataPropertyName = "AccessoryName";

            dgvAccessories.Columns["ColAQuantity"].Width = 100;
            dgvAccessories.Columns["ColAQuantity"].DataPropertyName = "Quantity";

            dgvAccessories.Columns["ColASelection"].Width = 50;
            dgvAccessories.Columns["ColASelection"].ReadOnly = false;
        }

        private async void MaterialDistributionForm_Load(object sender, EventArgs e)
        {
            await LoadRegionsToComboBox();
            LoadOrderTypeToComboBox();
            await LoadPurchaseOrdersInStock();
        }

        private async Task LoadPurchaseOrdersInStock()
        {
            try
            {
                List<PurchaseOrderDTO> purchaseOrders = await _materialService.GetAllPurchaseOrdersInStockAsync();

                if (purchaseOrders.Count == 0)
                {
                    MessageBox.Show("Danh sách đơn hàng nhập hiện tại đang trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                _purchaseOrders = purchaseOrders;
                FilterPurchaseOrder();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Load sử dụng vùng vô trong ComboBox
        private async Task LoadRegionsToComboBox()
        {
            try
            {
                _isLoadRegions = true;
                List<RegionDTO> regions = await _storeService.GetAllRegionsAsync();

                cmbBxRegions.DataSource = regions;
                cmbBxRegions.DisplayMember = "RegionName";
                cmbBxRegions.ValueMember = "RegionId";
                cmbBxRegions.SelectedIndex = -1;
                _isLoadRegions = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void cmbBxRegions_SelectedValueChanged(object sender, EventArgs e)
        {
            if (_isLoadRegions) return;
            if (cmbBxRegions.SelectedValue != null)
            {
                string regionId = cmbBxRegions.SelectedValue.ToString()!;

                List<StoreDTO> stores = await _storeService.GetAllStoresByRegionId(regionId);

                cmbBxStores.DisplayMember = "StoreName";
                cmbBxStores.ValueMember = "StoreId";
                cmbBxStores.DataSource = stores;
                cmbBxStores.SelectedIndex = 0;
            }
        }

        private void LoadOrderTypeToComboBox()
        {
            cmbBxOrderType.Items.Add("All");
            cmbBxOrderType.Items.Add(MaterialType.Flower);
            cmbBxOrderType.Items.Add(MaterialType.Accessory);
            cmbBxOrderType.SelectedIndex = 0;
        }

        private void FilterPurchaseOrder()
        {
            List<PurchaseOrderDTO> filteredPurchaseOrders = _purchaseOrders;

            if (cmbBxOrderType.Text == MaterialType.Flower)
            {
                filteredPurchaseOrders = filteredPurchaseOrders
                                        .Where(po => po.OrderType == MaterialType.Flower).ToList();
            }

            if (cmbBxOrderType.Text == MaterialType.Accessory)
            {
                filteredPurchaseOrders = filteredPurchaseOrders
                                        .Where(po => po.OrderType == MaterialType.Accessory).ToList();
            }

            dgvPurchaseOrders.DataSource = filteredPurchaseOrders;
        }

        private void cmbBxOrderType_SelectedValueChanged(object sender, EventArgs e)
        {
            //using (var db = new FlowerSalesCompanyDbContext())
            //{
            //    // Lấy giá trị được chọn từ combobox
            //    string selectedOrderType = cmbBxOrderType.Text;

            //    // Kiểm tra nếu giá trị được chọn không null hoặc rỗng
            //    if (!string.IsNullOrEmpty(selectedOrderType))
            //    {
            //        // Truy vấn dữ liệu theo OrderType và DistributionStatus
            //        var filteredData = db.PurchaseOrders
            //                             .Where(p => p.OrderType == selectedOrderType &&
            //                                         (p.DistributionStatus == "Chưa phân phối" ||
            //                                          p.DistributionStatus == "Đang phân phối"))
            //                             .Select(p => new
            //                             {
            //                                 p.PurchaseOrderId,
            //                                 PurchasedDateTime = p.PurchasedDateTime.Value.ToString("dd-MM-yyyy"),
            //                                 p.OrderType,
            //                                 p.DistributionStatus
            //                             })
            //                             .ToList();

            //        // Gán dữ liệu vào DataGridView
            //        dgvPurchaseOrders.DataSource = filteredData;
            //        dgvFlowers.DataSource = null;
            //    }
            //}

            FilterPurchaseOrder();
        }

        private async void dgvPurchaseOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = dgvPurchaseOrders.Rows[e.RowIndex];

                string? orderType = selectedRow.Cells["ColOrderType"].Value.ToString();
                _selectedPurchaseOrderId = selectedRow.Cells["ColPOId"].Value.ToString()!;

                if (orderType == null)
                {
                    MessageBox.Show("Dữ liệu đang bị lỗi. Vui lòng tải lại dữ liệu. ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    if (orderType == MaterialType.Flower)
                    {
                        ChangeFlowerDgvVisibility(true);

                        lblMaterial.Visible = true;
                        lblMaterial.Text = MaterialType.Flower;

                        await LoadFlowersToDgv(_selectedPurchaseOrderId);
                    }
                    else if (orderType == MaterialType.Accessory)
                    {
                        ChangeAccessoryDgvVisibility(true);

                        lblMaterial.Visible = true;
                        lblMaterial.Text = MaterialType.Accessory;

                        await LoadAccessoriesToDgv(_selectedPurchaseOrderId);
                    }
                }
            }
        }

        private void ChangeFlowerDgvVisibility(bool value)
        {
            dgvFlowers.Visible = value;
            dgvAccessories.Visible = !value;
        }

        private void ChangeAccessoryDgvVisibility(bool value)
        {
            dgvAccessories.Visible = value;
            dgvFlowers.Visible = !value;
        }

        private async Task LoadFlowersToDgv(string purchaseOrderId)
        {
            try
            {
                //Bước 1: Load chi tiết đơn hàng nhập
                List<DetailedPurchaseOrderDTO> details = await _materialService.GetDetailedPurchaseOrderByIdAsync(purchaseOrderId);

                //Bước 2: Load thông tin hoa
                List<FlowerDTO> flowers = await _materialService.GetAllFlowersAsync();

                //Bước 3: Join hai bảng lại rồi lấy ra thông tin cần hiển thị
                var result = details
                             .Join(flowers,
                             d => d.MaterialId,
                             f => f.FlowerID,
                             (d, f) => new
                             {
                                 FlowerId = f.FlowerID,
                                 FlowerName = f.FlowerName,
                                 FColor = f.FColorName,
                                 FChar = f.FCharacteristicName,
                                 Quantity = d.Quantity
                             })
                             .ToList();

                //Bước 4: Hiển thị lên DataGridView
                dgvFlowers.DataSource = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadAccessoriesToDgv(string purchaseOrderId)
        {
            try
            {
                //Bước 1: Load chi tiết đơn hàng nhập
                List<DetailedPurchaseOrderDTO> details = await _materialService.GetDetailedPurchaseOrderByIdAsync(purchaseOrderId);

                //Bước 2: Load thông tin hoa
                List<MaterialDTO> accessories = await _materialService.GetAllAccessoriesAsync();

                //Bước 3: Join hai bảng lại rồi lấy ra thông tin cần hiển thị
                var result = details
                             .Join(accessories,
                             d => d.MaterialId,
                             a => a.MaterialId,
                             (d, a) => new
                             {
                                 AccessoryId = a.MaterialId,
                                 AccessoryName = a.MaterialName,
                                 Quantity = d.Quantity
                             })
                             .ToList();

                //Bước 4: Hiển thị lên DataGridView
                dgvAccessories.DataSource = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        //Xử lý khi nhân viên nhấn phân phối vật liệu
        private async void btnDistribute_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(_selectedPurchaseOrderId))
                {
                    MessageBox.Show("Bạn cần chọn đơn hàng để thực hiện phân phối vật liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (numericUdDisQuantity.Value == 0)
                {
                    MessageBox.Show("Bạn cần chọn số lượng lớn hơn 0 để có thể phân phối", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (cmbBxRegions.SelectedValue == null)
                {
                    MessageBox.Show("Bạn cần chọn vùng và cửa hàng để có thể phân phối", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                //Sau khi pass qua hết các ràng buộc, thì bắt đầu lấy thông tin cần thiết để thực hiện lưu trữ vô database
                var store = cmbBxStores.SelectedItem as StoreDTO;

                if (store == null)
                {
                    MessageBox.Show("Lỗi dữ liệu cửa hàng. Vui lòng load lại dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                //Thông tin chung
                string storeId = store.StoreId;
                DateTimeOffset distributedDateTime = LocalDateTimeOffset();
                int distributedQuantity = Convert.ToInt32(numericUdDisQuantity.Value);
                List<string> materialIds = new List<string>();

                if (dgvFlowers.Visible == true)
                {
                    if (!IsAnyMaterialSelected(dgvFlowers, "ColFSelection"))
                    {
                        MessageBox.Show("Bạn cần chọn ít nhất một vật liệu để phân phối", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    foreach (DataGridViewRow row in dgvFlowers.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells["ColFSelection"].Value) == true)
                        {
                            materialIds.Add(row.Cells["ColFlowerId"].Value.ToString()!);
                        }
                    }

                    
                }

                if (dgvAccessories.Visible == true)
                {
                    if (!IsAnyMaterialSelected(dgvAccessories, "ColASelection"))
                    {
                        MessageBox.Show("Bạn cần chọn ít nhất một vật liệu để phân phối", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    foreach (DataGridViewRow row in dgvAccessories.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells["ColASelection"].Value) == true)
                        {
                            materialIds.Add(row.Cells["ColAccessoryId"].Value.ToString()!);
                        }
                    }
                }

                //Phân phối vật liệu đã chọn
                Dictionary<bool, string> result = await DistributeMaterialsAsync(_selectedPurchaseOrderId, storeId, distributedDateTime, distributedQuantity, materialIds);

                bool isFullyDistributed = result.First().Key;
                string message = result.First().Value;

                if (isFullyDistributed)
                {
                    RemoveRowInPurchaseOrderDgv(_selectedPurchaseOrderId);

                    MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //Gửi message đến cho store
                string content = $"Phân phối vật liệu cho cửa hàng {storeId}";
                string sessionId = "2345";
                string subject = "Phân phối vật liệu";
                string operationName = "U";
                string tableName = "MaterialInventory";

                await SendMessageToStoreAsync(content, sessionId, subject, operationName, tableName, storeId);

                MessageBox.Show("Đã phân phối vật liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<Dictionary<bool, string>> DistributeMaterialsAsync(string purchaseOrderId, string storeId, DateTimeOffset distributedDateTime, int distributedQuantity, List<string> materialIds)
        {
            Dictionary<bool, string> result = new();

            try
            {
                result =  await _materialService.DistributeMaterialsAsync(purchaseOrderId, storeId, distributedDateTime, distributedQuantity, materialIds);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return result;
        }

        private async Task SendMessageToStoreAsync(string content, string sessionId, string subject, string operationName, string tableName, string storeId)
        {
            IDictionary<string, object> applicationProperties = new Dictionary<string, object>()
                            {
                                {"Message", content},
                                {"OperationName", operationName},
                                {"TableName", tableName}
                            };
            ServiceBusMessage message = _notificationService.CreateMessage(content, sessionId, subject, applicationProperties);

            try
            {
                string numericPart = storeId.Substring(1);
                string convertedStoreId = "Store" + numericPart;

                await _notificationService.NotifyDatabaseOperationAsync(message, convertedStoreId);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Message: {ex.Message} \n Stack trace: {ex.StackTrace}");
            }
        }

        private void RemoveRowInPurchaseOrderDgv(string purchaseOrderId)
        {
            for (int i = dgvPurchaseOrders.Rows.Count - 1; i >= 0; i--)
            {
                DataGridViewRow row = dgvPurchaseOrders.Rows[i];
                if (row.Cells["ColPOId"].Value != null && row.Cells["ColPOId"].Value.ToString() == purchaseOrderId)
                {
                    dgvPurchaseOrders.Rows.RemoveAt(i);
                }
            }
        }

    }
}
