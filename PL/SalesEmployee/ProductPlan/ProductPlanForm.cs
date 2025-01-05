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
using DTO.Product;
using static BL.GeneralService;
using DTO.Enum;
using BL;
using DTO.Material;
using DTO.Store;

namespace PL.SalesEmployee
{
    public partial class ProductPlanForm : Form
    {
        //Cấu hình khởi tạo đối tượng
        private static ProductPlanForm? _instance;

        private static readonly object _lock = new object();

        //Khai báo các service
        private ProductService _productService = new ProductService();

        private MaterialService _materialService = new MaterialService();

        private StoreService _storeService = new StoreService();

        //Khai báo các biến sử dụng
        private List<FloralRepresentationDTO> _fRepresentations = new();

        private List<ProductDTO> _products = new();
        private List<CustomProduct> _customProducts = new();

        private bool isCellValueChanging = false;
        private bool isRegionInitializing = false;
        private bool isProductListInitializing = false;
        private ProductPlanForm()
        {
            InitializeComponent();
            dgvProduct.Columns["ColCreationQuantity"].Width = 100;
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

        //Định nghĩa một đối tượng để sử dụng riêng trong form này
        private class CustomProduct
        {
            public string ProductId { get; set; } = null!;

            public string ProductName { get; set; } = null!;

            public string FRName { get; set; } = null!;
        }

        private async void ProductPlanForm_Load(object sender, EventArgs e)
        {
            await LoadFrCbx();
            await LoadRegionsToComboBox();
            //using (var context = new FlowerSalesCompanyDbContext())
            //{
            //    var query = from p in context.Products
            //                join fr in context.FloralRepresentations
            //                on p.FrepresentationId equals fr.FrepresentationId
            //                select new
            //                {
            //                    p.ProductId,
            //                    p.ProductName,
            //                    FRName = fr.Frname
            //                };

            //    dgvProduct.DataSource = query.ToList();
            //}
            isProductListInitializing = true;
            await LoadAllProducts();
            isProductListInitializing = false;
        }

        private async Task LoadAllProducts()
        {
            try
            {
                _products = await _productService.GetAllProductsAsync();

                _customProducts = _products
                                        .Join(_fRepresentations,
                                        p => p.FrepresentationId,
                                        fr => fr.FrepresentationId,
                                        (p, fr) => new CustomProduct
                                        {
                                            ProductId = p.ProductId,
                                            ProductName = p.ProductName!,
                                            FRName = fr.Frname!
                                        }).ToList();

                dgvProduct.DataSource = _customProducts;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadFrCbx()
        {
            //using (var db = new FlowerSalesCompanyDbContext())
            //{
            //    // Truy vấn danh sách các Region
            //    var type = db.FloralRepresentations
            //                    .Select(r => new
            //                    {
            //                        r.FrepresentationId,
            //                        r.Frname
            //                    })
            //                    .ToList();


            //    cbbType.DataSource = type;
            //    cbbType.DisplayMember = "Frname";
            //    cbbType.ValueMember = "FrepresentationId";
            //    cbbType.SelectedIndex = -1;
            //}

            _fRepresentations = await _materialService.GetAllFRepresentationsAsync();

            cbbType.DataSource = _fRepresentations;
            cbbType.DisplayMember = "Frname";
            cbbType.ValueMember = "FrepresentationId";
            cbbType.SelectedIndex = -1;
        }

        private async Task LoadRegionsToComboBox()
        {
            //using (var db = new FlowerSalesCompanyDbContext())
            //{
            //    // Truy vấn danh sách các Region
            //    var regions = db.Regions
            //                    .Select(r => new
            //                    {
            //                        r.RegionId,
            //                        r.RegionName
            //                    })
            //                    .ToList();

            //    // Gán dữ liệu vào ComboBox
            //    cbbRegion.DataSource = regions;
            //    cbbRegion.DisplayMember = "RegionName";
            //    cbbRegion.ValueMember = "RegionId";
            //    cbbRegion.SelectedIndex = -1;
            //    cbbStore.SelectedIndex = -1;
            //}

            try
            {
                List<RegionDTO> regions = await _storeService.GetAllRegionsAsync();

                isRegionInitializing = true;
                cbbRegion.DataSource = regions;
                cbbRegion.DisplayMember = "RegionName";
                cbbRegion.ValueMember = "RegionId";
                cbbRegion.SelectedIndex = -1;
                isRegionInitializing = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi trong quá trình lấy dữ liệu vùng {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void cbbRegion_SelectedValueChanged(object sender, EventArgs e)
        {
            if (isRegionInitializing)
                return;
            if (cbbRegion.SelectedValue != null)
            {

                string? regionId = cbbRegion.SelectedValue.ToString();

                try
                {
                    List<StoreDTO> stores = await _storeService.GetAllStoresByRegionId(regionId);

                    cbbStore.DisplayMember = "StoreName";
                    cbbStore.ValueMember = "StoreId";
                    cbbStore.DataSource = stores;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                //using (var db = new FlowerSalesCompanyDbContext())
                //{

                //    var stores = db.Stores
                //                   .Where(s => s.RegionId == regionId)
                //                   .Select(s => new
                //                   {
                //                       s.StoreId,
                //                       s.StoreName
                //                   })
                //                   .ToList();

                //    cbbStore.DisplayMember = "StoreName";
                //    cbbStore.ValueMember = "StoreId";
                //    cbbStore.DataSource = stores;
                //}
            }
        }

        private void cbbType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbbType.SelectedIndex == -1)
            {
                return;
            }

            //using (var context = new FlowerSalesCompanyDbContext())
            //{
            //    var query = from p in context.Products
            //                join fr in context.FloralRepresentations
            //                on p.FrepresentationId equals fr.FrepresentationId
            //                where p.FrepresentationId.Equals(cbbType.SelectedValue.ToString())
            //                select new
            //                {
            //                    p.ProductId,
            //                    p.ProductName,
            //                    FRName = fr.Frname
            //                };

            //    dgvProduct.DataSource = query.ToList();
            //}

            var filteredProducts = _customProducts.Where(p => p.FRName == cbbType.Text).ToList();

            dgvProduct.DataSource = filteredProducts;
        }

        //private async void txtBxFindById_TextChanged(object sender, EventArgs e)
        //{
        //    //using (var context = new FlowerSalesCompanyDbContext())
        //    //{
        //    //    var query = from p in context.Products
        //    //                join fr in context.FloralRepresentations
        //    //                on p.FrepresentationId equals fr.FrepresentationId
        //    //                where p.ProductId.ToString().ToLower().Contains(txtBxFindById.Text.ToLower())
        //    //                select new
        //    //                {
        //    //                    p.ProductId,
        //    //                    p.ProductName,
        //    //                    FRName = fr.Frname
        //    //                };

        //    //    dgvProduct.DataSource = query.ToList();
        //    //}
        //}

        private async void btnPlan_Click(object sender, EventArgs e)
        {
            //Lấy ngày thực hiện
            DateTimeOffset implementationDate = new DateTimeOffset(dtpImplementDate.Value, TimeSpan.FromHours(7));

            //Lấy vùng
            string? selectedRegion = cbbRegion.SelectedValue?.ToString();

            //Lấy cửa hàng
            string? selectedStore = cbbStore.SelectedValue?.ToString(); 

            //Kiểm tra ô vùng và cửa hàng
            if (string.IsNullOrEmpty(selectedRegion) || string.IsNullOrEmpty(selectedStore))
            {
                MessageBox.Show("Vui lòng chọn đầy đủ thông tin Region và Store.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Kiểm tra xem thời gian thực hiện có đúng không
            if (implementationDate.Date <= DateTime.UtcNow.Date || implementationDate.TimeOfDay < TimeSpan.FromHours(5) || implementationDate.TimeOfDay > TimeSpan.FromHours(20))
            {
                MessageBox.Show("Ngày tạo sản phẩm phải lớn hơn ngày hiện tại và nằm trong thời gian hoạt động của cửa hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lấy danh sách sản phẩm được chọn từ DataGridView
            var selectedRows = dgvProduct.Rows
                .Cast<DataGridViewRow>()
                .Where(row => Convert.ToBoolean(row.Cells["SelectColumn"].Value) == true)
                .ToList();

            //Kiểm tra xem danh sách sản phẩm được tick chọn có rỗng không
            if (selectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một sản phẩm để lập kế hoạch.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra xem có bất kỳ hàng nào có giá trị ở cột "ColCreationQuantity" bằng 0 hay không
            bool hasInvalidQuantity = selectedRows.Any(row => Convert.ToInt32(row.Cells["ColCreationQuantity"].Value) == 0);

            if (hasInvalidQuantity)
            {
                MessageBox.Show("Có sản phẩm có số lượng tạo bằng 0. Vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Duyệt qua các dòng đã chọn và thêm vào bảng
            foreach (var row in selectedRows)
            {
                string productId = row.Cells["ProductId"].Value.ToString()!;
                int neededQuantity = Convert.ToInt32(row.Cells["ColCreationQuantity"].Value);

                // Tạo đối tượng mới để thêm vào bảng
                ProductCreationPlanHistoryDTO productCreationPlan = new ProductCreationPlanHistoryDTO
                {
                    PlannedDateTime = LocalDateTimeOffset(), // Thời gian lập kế hoạch
                    StoreId = selectedStore,
                    ProductId = productId,
                    ImplementationDateTime = implementationDate,
                    NeededCreationQuantity = (short)neededQuantity,
                    CreatedDateTime = null, //Thời gian tạo bản ghi
                    PlanStatus = PlanStatus.Initialized //Trạng thái mặc định
                };

                //Lưu dữ liệu vào database
                try
                {
                    await _productService.AddProductCreationPlanAsync(productCreationPlan);

                    MessageBox.Show("Đã tạo kế hoạch thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi lưu dữ liệu: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Khởi tạo Entity Framework DbContext
            //using (var dbContext = new FlowerSalesCompanyDbContext())
            //{
            //    // Duyệt qua các dòng đã chọn và thêm vào bảng
            //    foreach (var row in selectedRows)
            //    {
            //        string productId = row.Cells["ProductId"].Value.ToString()!;
            //        int neededQuantity = Convert.ToInt32(row.Cells["ColCreationQuantity"].Value);

            //        // Tạo đối tượng mới để thêm vào bảng
            //        ProductCreationPlanHistoryDTO productCreationPlan = new ProductCreationPlanHistoryDTO
            //        {
            //            PlannedDateTime = LocalDateTimeOffset(), // Thời gian lập kế hoạch
            //            StoreId = selectedStore,
            //            ProductId = productId,
            //            ImplementationDateTime = implementationDate,
            //            NeededCreationQuantity = (short)neededQuantity,
            //            CreatedDateTime = null, //Thời gian tạo bản ghi
            //            PlanStatus = PlanStatus.Initialized //Trạng thái mặc định
            //        };

            //        // Thêm vào DbSet
            //        //dbContext.ProductCreationPlanHistories.Add();
            //    }

            // Lưu thay đổi vào database
            //try
            //{
            //    dbContext.SaveChanges();
            //    MessageBox.Show("Lập kế hoạch thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    ProductPlanForm_Load(sender, e);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Lỗi khi lưu dữ liệu: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra người dùng có click vào cột ColDetailedProduct hay không
            if (e.ColumnIndex == dgvProduct.Columns["ColDetailedProduct"].Index && e.RowIndex >= 0)
            {

                string productId = dgvProduct.Rows[e.RowIndex].Cells["ProductId"].Value.ToString()!;


                DetailedProductForm formDetails = new DetailedProductForm(productId);
                formDetails.ShowDialog();
            }
        }

        //Kiểm tra số lượng nhập vô có lớn hơn 0 không
        private void dgvProduct_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (isProductListInitializing) return;
            //Khi user nhấn vô thêm số lượng sản phẩm
            if (e.RowIndex >= 0 && dgvProduct.Columns[e.ColumnIndex] == dgvProduct.Columns["ColCreationQuantity"])
            {
                if (isCellValueChanging)
                {
                    return;
                }

                if (!int.TryParse(dgvProduct.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out int result) && result <= 0)
                {
                    MessageBox.Show("Số lượng phải là số lớn hơn 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    isCellValueChanging = true;
                    dgvProduct.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "1";
                    isCellValueChanging = false;

                    return;
                }
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (txtBxFindById.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập ProductID mà bạn muốn tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                string productId = txtBxFindById.Text;
                CustomProduct? product = _customProducts.Find(p => p.ProductId == productId);

                if (product == null)
                {
                    MessageBox.Show($"Không tìm thấy sản phẩm với ProductID là {productId}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                dgvProduct.DataSource = new List<CustomProduct> { product };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dgvProduct.DataSource = _customProducts;
        }
    }
}
