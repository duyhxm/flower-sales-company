using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;
using DTO;
using DTO.Enum;
using static BL.GeneralService;
using System.Collections.Concurrent;
using DTO.Product;

namespace PL.StoreEmployee
{
    public partial class DailyTaskForm : Form
    {
        //Khai báo cấu hình 
        private static DailyTaskForm? _instance;
        private static readonly object _lock = new object();

        //khai báo các service sử dụng
        private StoreService _storeService = new StoreService();
        private ProductService _productService = new ProductService();
        private MaterialService _materialService = new MaterialService();

        //Khai báo các biến sử dụng
        private BindingList<PlannedProductDTO> _plannedProducts;
        private BindingSource _bindingSource;
        private Dictionary<int, DateTimeOffset> _plannedDateTimes = new Dictionary<int, DateTimeOffset>();
        private ConcurrentQueue<Func<Task>> _taskQueue = new ConcurrentQueue<Func<Task>>();
        private bool _isProcessingQueue = false;

        public DailyTaskForm()
        {
            InitializeComponent();

            _plannedProducts = new BindingList<PlannedProductDTO>();
            _bindingSource = new BindingSource(_plannedProducts, null);

            SetupDailyTasksDgv();
            SetupFlowersDgv();
            SetupAccessoriesDgv();
        }

        public static void Initialize()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    try
                    {
                        _instance = new DailyTaskForm();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }

        public static DailyTaskForm Instance
        {
            get
            {
                if (_instance == null)
                {
                    throw new InvalidOperationException("DailyTaskForm is not initialized. Call Initialize() first.");
                }

                return _instance;
            }
        }

        private void SetupDailyTasksDgv()
        {
            dgvDailyTasks.AutoGenerateColumns = false;

            dgvDailyTasks.Columns["ColProductId"].DataPropertyName = "ProductId";

            dgvDailyTasks.Columns["ColFRName"].Width = 120;
            dgvDailyTasks.Columns["ColFRName"].DataPropertyName = "FRName";

            dgvDailyTasks.Columns["ColProductName"].DataPropertyName = "ProductName";

            dgvDailyTasks.Columns["ColNeededCreationQuantity"].DataPropertyName = "Quantity";
            dgvDailyTasks.Columns["ColNeededCreationQuantity"].Width = 80;

            dgvDailyTasks.Columns["ColImplementationTime"].DataPropertyName = "ImplementationDateTimeFormatted";

            // Set the data source
            dgvDailyTasks.DataSource = _bindingSource;
        }

        private void SetupFlowersDgv()
        {
            dgvFlowers.AutoGenerateColumns = false;

            dgvFlowers.Columns["ColFlowerId"].Width = 100;
            dgvFlowers.Columns["ColFlowerId"].DataPropertyName = "FlowerId";

            dgvFlowers.Columns["ColFlowerName"].Width = 200;
            dgvFlowers.Columns["ColFlowerName"].DataPropertyName = "FlowerName";

            dgvFlowers.Columns["ColFColor"].Width = 150;
            dgvFlowers.Columns["ColFColor"].DataPropertyName = "ColorName";

            dgvFlowers.Columns["ColFChar"].Width = 100;
            dgvFlowers.Columns["ColFChar"].DataPropertyName = "CharName";

            dgvFlowers.Columns["ColUsedFQuantity"].Width = 80;
            dgvFlowers.Columns["ColUsedFQuantity"].DataPropertyName = "Quantity";
        }

        private void SetupAccessoriesDgv()
        {
            dgvAccessories.AutoGenerateColumns = false;

            dgvAccessories.Columns["ColAccessoryId"].Width = 100;
            dgvAccessories.Columns["ColAccessoryId"].DataPropertyName = "MaterialId";

            dgvAccessories.Columns["ColAccessoryName"].Width = 200;
            dgvAccessories.Columns["ColAccessoryName"].DataPropertyName = "MaterialName";

            dgvAccessories.Columns["ColUsedAQuantity"].Width = 80;
            dgvAccessories.Columns["ColUsedAQuantity"].DataPropertyName = "UsedQuantity";
        }

        private async void dgvDailyTasks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //User click nút xem chi tiết sản phẩm
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvDailyTasks.Columns["ColDetails"].Index)
            {
                string productId = dgvDailyTasks.Rows[e.RowIndex].Cells[0].Value.ToString()!;

                await LoadDetailedProduct(productId);
            }

            //User click nút hoàn thành tạo sản phẩm
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvDailyTasks.Columns["ColCreate"].Index)
            {
                var result = MessageBox.Show("Xác nhận rằng bạn đã tạo sản phẩm đúng với số lượng yêu cầu", "Thông báo", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    // Lấy productId từ dòng được chọn
                    string productId = dgvDailyTasks.Rows[e.RowIndex].Cells["ColProductId"].Value.ToString()!;

                    // Tìm đối tượng PlannedProductDTO tương ứng trong BindingList
                    var plannedProduct = _plannedProducts.FirstOrDefault(p => p.ProductId == productId);

                    if (plannedProduct != null)
                    {
                        // Thêm tác vụ vào hàng đợi
                        _taskQueue.Enqueue(async () =>
                        {

                            //khai báo các biến sẽ sử dụng
                            List<DetailedProductMaterialNameDTO> detailedProducts = await _productService.GetDetailedProductsByProductIdAsync(plannedProduct.ProductId);
                            List<DetailedProductDTO> detailedProductList = new List<DetailedProductDTO>();
                            Dictionary<string, int> materialQuantities = new();

                            //Tạo danh sách chi tiết sản phẩm cũng như tạo dictionary chứa các key: materialId và value: usedQuantity
                            foreach (var dp in detailedProducts)
                            {
                                detailedProductList.Add(new DetailedProductDTO()
                                {
                                    ProductId = plannedProduct.ProductId,
                                    MaterialId = dp.MaterialId,
                                    UsedQuantity = dp.UsedQuantity
                                });
                                materialQuantities.Add(dp.MaterialId, Convert.ToInt32(dp.UsedQuantity));

                            }

                            //Tính toán UnitPrice
                            decimal unitPrice = await _productService.CalculateUnitPriceAsync(materialQuantities);

                            //Lấy ra thời gian hiện tại ở local
                            DateTimeOffset createdDateTime = LocalDateTimeOffset();

                            //Tạo lịch sử tạo product
                            ProductCreationHistoryDTO creationHistory = new ProductCreationHistoryDTO()
                            {
                                CreatedDateTime = createdDateTime,
                                ProductId = plannedProduct.ProductId,
                                EmployeeId = LoginForm.Instance.LoginInformation.UserAccount.EmployeeId!,
                                CreatedQuantity = plannedProduct.Quantity,
                                UnitPrice = unitPrice
                            };

                            //Tạo một product với các thông tin phía trên
                            ProductDTO product = new ProductDTO()
                            {
                                ProductId = plannedProduct.ProductId,
                                ProductName = plannedProduct.ProductName,
                                DetailedProducts = detailedProductList
                            };

                            //Gọi service để thêm product
                            ReturnedProductDTO returnedProduct = await _productService.AddProductAsync(product, creationHistory, LoginForm.Instance.LoginInformation.StoreID!);

                            //Sau khi thêm sản phẩm thành công, tiếp tục cập nhật trạng thái vô trong bảng ProductCreationPlanHistory
                            string planStatus = PlanStatus.Completed;
                            //DateTimeOffset plannedDateTime = plannedProduct.PlannedDateTime;
                            await _storeService.UpdateProductCreationPlanStatusAsync(plannedProduct, createdDateTime, planStatus);

                            //Sau khi cập nhật, gọi đến InventoryForm để load lại dữ liệu dữ database lên.
                            await InventoryForm.Instance.LoadMaterialInventory(LoginForm.Instance.LoginInformation.StoreID!);
                            await InventoryForm.Instance.LoadProductInventory(LoginForm.Instance.LoginInformation.StoreID!);

                            //Sau khi cập nhật giao diện bên InventoryForm, thực hiện xoá sản phẩm khỏi danh sách DailyTasks
                            _plannedProducts.Remove(plannedProduct);

                            if (_plannedProducts.Count == 0)
                            {
                                StoreMainForm.Instance.NotificationBellVisibility(false);
                            }

                            //Thêm sản phẩm vô trong ProductList Form
                            ProductListForm.Instance.AddProductToDgv(plannedProduct);

                            MessageBox.Show("Đã tạo mới sản phẩm thành công.", "Thông báo");
                        });

                        // Xử lý hàng đợi
                        await ProcessQueue();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sản phẩm tương ứng.");
                    }
                }
            }
        }

        public async Task LoadPlannedProducts(DateTime currentDate, string storeId, string planStatus)
        {
            var plannedProducts = await _storeService.GetPlannedProductsForStoreAsync(currentDate, storeId, planStatus);

            if (plannedProducts.Count != 0)
            {
                _plannedProducts.Clear();
                foreach (var pp in plannedProducts)
                {
                    _plannedProducts.Add(pp);
                }

                StoreMainForm.Instance.NotificationBellVisibility(true);
            }
            else
            {
                StoreMainForm.Instance.NotificationBellVisibility(false);
            }
        }

        private async Task ProcessQueue()
        {
            if (_isProcessingQueue)
                return;

            _isProcessingQueue = true;

            while (_taskQueue.TryDequeue(out var task))
            {
                try
                {
                    await task();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            _isProcessingQueue = false;
        }

        private async Task LoadDetailedProduct(string productId)
        {
            //Load phụ liệu
            var detailedProducts = await _productService.GetDetailedProductsByProductIdAsync(productId);
            var accessories = detailedProducts.Where(dp => dp.MaterialId.StartsWith("A")).ToList();

            dgvAccessories.DataSource = accessories;

            //Load hoa
            //Load toàn bộ hoa với các thông tin chi tiết như tên màu sắc, tên loại hoa, tên đặc điểm
            var detailedFlowers = await _materialService.GetAllFlowersAsync();
            var transformedFlowers = detailedFlowers
                                    .Join(detailedProducts,
                                    df => df.FlowerID,
                                    dp => dp.MaterialId,
                                    (df, dp) => new
                                    {
                                        FlowerId = df.FlowerID,
                                        FlowerName = dp.MaterialName,
                                        ColorName = df.FColorName,
                                        CharName = df.FCharacteristicName,
                                        Quantity = dp.UsedQuantity
                                    }).ToList();

            dgvFlowers.DataSource = transformedFlowers;
        }

        private void DailyTaskForm_Load(object sender, EventArgs e)
        {
            if (dgvDailyTasks.Rows.Count == 0)
            {
                MessageBox.Show("Danh sách sản phẩm được lên kế hoạch cho cửa hàng hiện tại đang trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
