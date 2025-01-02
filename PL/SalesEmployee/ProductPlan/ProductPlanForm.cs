using DL.Models;
using PL.SalesEmployee.ProductPlan;
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
    public partial class ProductPlanForm : System.Windows.Forms.Form
    {
        //Cấu hình khởi tạo đối tượng
        private static ProductPlanForm? _instance;
        private static readonly object _lock = new object();
        private ProductPlanForm()
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
                        _instance = new ProductPlanForm();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }

        public static ProductPlanForm Instance
        {
            get
            {
                if (_instance == null)
                {
                    throw new InvalidOperationException("ProductPlanForm is not initialized. Call Initialize() first.");
                }
                return _instance;
            }
        }
        private void ProductPlanForm_Load(object sender, EventArgs e)
        {
            LoadFrCbx();
            LoadRegionsToComboBox();
            using (var context = new FlowerSalesCompanyDbContext())
            {
                var query = from p in context.Products
                            join fr in context.FloralRepresentations
                            on p.FrepresentationId equals fr.FrepresentationId
                            select new
                            {
                                p.ProductId,
                                p.ProductName,
                                FRName = fr.Frname
                            };

                dgvProduct.DataSource = query.ToList();
            }


        }

        private void LoadFrCbx()
        {
            using (var db = new FlowerSalesCompanyDbContext())
            {
                // Truy vấn danh sách các Region
                var type = db.FloralRepresentations
                                .Select(r => new
                                {
                                    r.FrepresentationId,
                                    r.Frname
                                })
                                .ToList();


                cbbType.DataSource = type;
                cbbType.DisplayMember = "Frname";
                cbbType.ValueMember = "FrepresentationId";
                cbbType.SelectedIndex = -1;
            }
        }

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
                cbbRegion.DataSource = regions;
                cbbRegion.DisplayMember = "RegionName";
                cbbRegion.ValueMember = "RegionId";
                cbbRegion.SelectedIndex = -1;
                cbbStore.SelectedIndex = -1;
            }
        }

        private void cbbRegion_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbbRegion.SelectedValue != null)
            {

                string regionId = cbbRegion.SelectedValue.ToString();

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

                    cbbStore.DisplayMember = "StoreName";
                    cbbStore.ValueMember = "StoreId";
                    cbbStore.DataSource = stores;
                }
            }
        }

        private void cbbType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbbType.SelectedIndex == -1)
            {
                return;
            }

            using (var context = new FlowerSalesCompanyDbContext())
            {
                var query = from p in context.Products
                            join fr in context.FloralRepresentations
                            on p.FrepresentationId equals fr.FrepresentationId
                            where p.FrepresentationId.Equals(cbbType.SelectedValue.ToString())
                            select new
                            {
                                p.ProductId,
                                p.ProductName,
                                FRName = fr.Frname
                            };

                dgvProduct.DataSource = query.ToList();
            }
        }

        private void txtBxFindById_TextChanged(object sender, EventArgs e)
        {
            using (var context = new FlowerSalesCompanyDbContext())
            {
                var query = from p in context.Products
                            join fr in context.FloralRepresentations
                            on p.FrepresentationId equals fr.FrepresentationId
                            where p.ProductId.ToString().ToLower().Contains(txtBxFindById.Text.ToLower())
                            select new
                            {
                                p.ProductId,
                                p.ProductName,
                                FRName = fr.Frname
                            };

                dgvProduct.DataSource = query.ToList();
            }
        }

        private void btnPlan_Click(object sender, EventArgs e)
        {
            DateTimeOffset implementationDate = new DateTimeOffset(dtpImplementDate.Value, TimeSpan.FromHours(7));
            string selectedRegion = cbbRegion.SelectedValue?.ToString(); // Lấy vùng
            string selectedStore = cbbStore.SelectedValue?.ToString(); // Lấy cửa hàng

            // Kiểm tra các trường nhập liệu
            if (string.IsNullOrEmpty(selectedRegion) || string.IsNullOrEmpty(selectedStore))
            {
                MessageBox.Show("Vui lòng chọn đầy đủ thông tin Region và Store.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy danh sách sản phẩm được chọn từ DataGridView
            var selectedRows = dgvProduct.Rows
                .Cast<DataGridViewRow>()
                .Where(row => Convert.ToBoolean(row.Cells["SelectColumn"].Value) == true)
                .ToList();

            if (selectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một sản phẩm để lập kế hoạch.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Khởi tạo Entity Framework DbContext
            using (var dbContext = new FlowerSalesCompanyDbContext())
            {
                // Duyệt qua các dòng đã chọn và thêm vào bảng
                foreach (var row in selectedRows)
                {
                    string productId = row.Cells["ProductId"].Value.ToString();
                    int neededQuantity = Convert.ToInt32(row.Cells["ColCreationQuantity"].Value);

                    // Tạo đối tượng mới để thêm vào bảng
                    var newPlan = new ProductCreationPlanHistory
                    {
                        PlannedDateTime = DateTimeOffset.Now, // Thời gian lập kế hoạch
                        StoreId = selectedStore,
                        ProductId = productId,
                        ImplementationDateTime = implementationDate,
                        NeededCreationQuantity = (short)neededQuantity,
                        CreatedDateTime = null, // Thời gian tạo bản ghi
                        PlanStatus = "Đã khởi tạo" // Trạng thái mặc định
                    };

                    // Thêm vào DbSet
                    dbContext.ProductCreationPlanHistories.Add(newPlan);
                }

                // Lưu thay đổi vào database
                try
                {
                    dbContext.SaveChanges();
                    MessageBox.Show("Lập kế hoạch thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ProductPlanForm_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi lưu dữ liệu: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra người dùng có click vào cột ColDetailedProduct hay không
            if (e.ColumnIndex == dgvProduct.Columns["ColDetailedProduct"].Index && e.RowIndex >= 0)
            {
              
                string productId = dgvProduct.Rows[e.RowIndex].Cells["ProductId"].Value.ToString();

              
                DetailedProductForm formDetails = new DetailedProductForm(productId);
                formDetails.ShowDialog();
            }
        }
    }
}
