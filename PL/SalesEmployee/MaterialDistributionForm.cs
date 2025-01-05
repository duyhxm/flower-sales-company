using DL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace PL.SalesEmployee
{

    /*Ở form này, mình sẽ thực hiện chức năng phân phối vật liệu cho các cửa hàng. Mình sẽ có 3 tab chính là PurchaseOrder, Accessory và Flower. Tab PurchaseOrder để load các đơn hàng đã nhập về. Sử dụng DataGridView để hiển thị dữ liệu. 
    các bảng mình cần tương tác bao gồm: PurchaseOrder, DetailedPurchaseOrder, Material,*/
    public partial class MaterialDistributionForm : System.Windows.Forms.Form
    {
        //Cấu hình khởi tạo đối tượng
        private static MaterialDistributionForm? _instance;
        private static readonly object _lock = new object();

        //Khai báo các service được sử dụng
        public NotificationService NotificationService { get; private set; }

        //Load sử dụng vùng vô trong ComboBox
        private void LoadRegionsToComboBox()
        {
            using (var db = new FlowerSalesCompanyDbContext())
            {
                // Truy vấn danh sách các Region
                var regions = db.Regions
                                .Select(r => new
                                {
                                    r.RegionId,
                                    r.RegionName
                                })
                                .ToList();

                // Gán dữ liệu vào ComboBox
                cmbBxRegions.DataSource = regions;
                cmbBxRegions.DisplayMember = "RegionName";
                cmbBxRegions.ValueMember = "RegionId";
                cmbBxRegions.SelectedIndex = -1;
            }
        }

        //Hàm Constructor
        private MaterialDistributionForm()
        {
            InitializeComponent();
            LoadRegionsToComboBox();
            NotificationService = NotificationService.Instance;

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

        private void cmbBxOrderType_SelectedValueChanged(object sender, EventArgs e)
        {
            using (var db = new FlowerSalesCompanyDbContext())
            {
                // Lấy giá trị được chọn từ combobox
                string selectedOrderType = cmbBxOrderType.Text;

                // Kiểm tra nếu giá trị được chọn không null hoặc rỗng
                if (!string.IsNullOrEmpty(selectedOrderType))
                {
                    // Truy vấn dữ liệu theo OrderType và DistributionStatus
                    var filteredData = db.PurchaseOrders
                                         .Where(p => p.OrderType == selectedOrderType &&
                                                     (p.DistributionStatus == "Chưa phân phối" ||
                                                      p.DistributionStatus == "Đã phân phối"))
                                         .Select(p => new
                                         {
                                             p.PurchaseOrderId,
                                             p.VendorId,
                                             p.OrderType,
                                             p.PurchasedDateTime,
                                             p.DistributionStatus
                                         })
                                         .ToList();

                    // Gán dữ liệu vào DataGridView
                    dgvPurchaseOrders.DataSource = filteredData;
                    dgvOrderDetails.DataSource = null;
                }
            }
        }

        //Biến này được sử dụng để làm gì??
        string purchaseOrderIdSelect = string.Empty;

        private void dgvPurchaseOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = dgvPurchaseOrders.Rows[e.RowIndex];
                string purchaseOrderId = selectedRow.Cells["PurchaseOrderId"].Value.ToString()!;
                purchaseOrderIdSelect = purchaseOrderId;
                using (var db = new FlowerSalesCompanyDbContext())
                {
                    var distributionDetails = db.DetailedPurchaseOrders
                                                .Where(gd => gd.PurchaseOrderId == purchaseOrderId)
                                                .Select(gd => new
                                                {
                                                    gd.PurchaseOrderId,
                                                    gd.MaterialId,
                                                    gd.CostPrice,
                                                    gd.Quantity
                                                })
                                                .ToList();
                    dgvOrderDetails.DataSource = distributionDetails;
                }
            }
        }

        //Xử lý khi nhân viên nhấn phân phối vật liệu
        private async void btnDistribute_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(purchaseOrderIdSelect))
                {
                    string purchaseOrderID = purchaseOrderIdSelect;

                    if (!string.IsNullOrEmpty(MaterialIDSelect))
                    {
                        string materialID = MaterialIDSelect;
                        string storeID = cmbBxStores.SelectedValue!.ToString()!;
                        int distributedQuantity = Convert.ToInt32(txtDistributedQuantity.Text);
                        DateTimeOffset distributedDate = DateTimeOffset.Now;

                        using (var db = new FlowerSalesCompanyDbContext())
                        {
                            db.Database.ExecuteSqlRaw("EXEC AddGoodsDistribution @PurchaseOrderID, @StoreID, @MaterialID, @DistributedQuantity, @DistributedDate",
                                new SqlParameter("@PurchaseOrderID", purchaseOrderID),
                                new SqlParameter("@StoreID", storeID),
                                new SqlParameter("@MaterialID", materialID),
                                new SqlParameter("@DistributedQuantity", distributedQuantity),
                                new SqlParameter("@DistributedDate", distributedDate));
                        }


                        MessageBox.Show("Material distribution has been successfully added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        IDictionary<string, object> applicationProperties = new Dictionary<string, object>()
                        {
                            {"Message", "Thêm vật liệu cho cửa hàng"},
                            {"OperationName", "U"},
                            {"TableName", "MaterialInventory"}
                        };
                        ServiceBusMessage message = NotificationService.CreateMessage("test", "1234", "Database Change Notification", applicationProperties);

                        try
                        {
                            string? storeId = storeID;
                            string numericPart = storeId!.Substring(1);

                            string convertedStoreId = "Store" + numericPart;
                            await NotificationService.NotifyDatabaseOperationAsync(message, convertedStoreId);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Message: {ex.Message} \n Stack trace: {ex.StackTrace}");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select a material in the order details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a purchase order.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Biến này được sử dụng để làm gì??
        string MaterialIDSelect = string.Empty;

        private void dgvOrderDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = dgvOrderDetails.Rows[e.RowIndex];
                string MaterialID = selectedRow.Cells["MaterialId"].Value.ToString()!;
                MaterialIDSelect = MaterialID;

            }
        }

        //Load danh sách các cửa hàng vô trong ComboBox khi nhân viên chọn vùng
        private void cmbBxRegions_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbBxRegions.SelectedValue != null)
            {

                string regionId = cmbBxRegions.SelectedValue.ToString()!;

                using (var db = new FlowerSalesCompanyDbContext())
                {

                    var stores = db.Stores
                                   .Where(s => s.RegionId == regionId)
                                   .Select(s => new
                                   {
                                       s.StoreId,
                                       s.StoreName
                                   })
                                   .ToList();

                    cmbBxStores.DisplayMember = "StoreName";
                    cmbBxStores.ValueMember = "StoreId";
                    cmbBxStores.DataSource = stores;
                }
            }
        }
    }
}
