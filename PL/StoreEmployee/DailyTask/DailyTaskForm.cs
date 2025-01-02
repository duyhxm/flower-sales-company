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
using PL.StoreEmployee.DailyTask;
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
            SetupDataGridView();
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

        private void SetupDataGridView()
        {
            // Initialize the DataGridView and set its properties
            dgvDailyTasks.AutoGenerateColumns = false;

            dgvDailyTasks.Columns["ColProductId"].DataPropertyName = "ProductId";
            dgvDailyTasks.Columns["ColProductName"].DataPropertyName = "ProductId";
            dgvDailyTasks.Columns["ColNeededCreationQuantity"].DataPropertyName = "Quantity";
            dgvDailyTasks.Columns["ColImplementationTime"].DataPropertyName = "ImplementationDateTime";

            // Set the data source
            dgvDailyTasks.DataSource = _bindingSource;
        }

        private async void dgvDailyTasks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //User click nút xem chi tiết sản phẩm
            if (e.ColumnIndex == 4)
            {
                string productId = dgvDailyTasks.Rows[e.RowIndex].Cells[0].Value.ToString()!;
                var detailProductForm = new DetailedProductForm(productId);
                detailProductForm.ShowDialog();
            }

            //User click nút hoàn thành tạo sản phẩm
            if (e.ColumnIndex == 5)
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
                            DateTimeOffset plannedDateTime = plannedProduct.PlannedDateTime;
                            await _storeService.UpdateProductCreationPlanStatusAsync(plannedDateTime, createdDateTime, planStatus);

                            //Sau khi cập nhật, gọi đến InventoryForm để load lại dữ liệu dữ database lên.
                            await InventoryForm.Instance.LoadMaterialInventory(LoginForm.Instance.LoginInformation.StoreID!);
                            await InventoryForm.Instance.LoadProductInventory(LoginForm.Instance.LoginInformation.StoreID!);

                            //Sau khi cập nhật giao diện bên InventoryForm, thực hiện xoá sản phẩm khỏi danh sách DailyTasks
                            _plannedProducts.Remove(plannedProduct);
                        });

                        // Xử lý hàng đợi
                        await ProcessQueue();

                        MessageBox.Show("Đã tạo mới sản phẩm thành công.", "Thông báo");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sản phẩm tương ứng.");
                    }
                }
            }
        }

        public async void LoadPlannedProducts(DateTimeOffset todayDateTime, string storeId)
        {
            var plannedProducts = await GetPlannedProductsForStoreAsync(todayDateTime, storeId);

            if (plannedProducts != null)
            {
                _plannedProducts.Clear();
                foreach (var pp in plannedProducts)
                {
                    _plannedProducts.Add(pp);
                }
            }
            else
            {
                MessageBox.Show("Danh sách sản phẩm được lên kế hoạch cho cửa hàng hiện tại đang trống");
            }
        }

        private async Task<List<PlannedProductDTO>?> GetPlannedProductsForStoreAsync(DateTimeOffset plannedDateTime, string storeId)
        {
            try
            {
                var result = await _storeService.GetPlannedProductsForStoreAsync(plannedDateTime, storeId);
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public async void LoadPlannedProduct(DateTimeOffset plannedDateTime)
        {
            var plannedProduct = await GetPlannedProductForStoreAsync(plannedDateTime);

            if (plannedProduct != null)
            {
                _plannedProducts.Clear();
                _plannedProducts.Add(plannedProduct);
                _plannedDateTimes[_plannedProducts.Count - 1] = plannedProduct.PlannedDateTime;
            }
            else
            {
                MessageBox.Show("No planned product found for the given date.");
            }
        }

        private async Task<PlannedProductDTO?> GetPlannedProductForStoreAsync(DateTimeOffset plannedDateTime)
        {
            try
            {
                var result = await _storeService.GetPlannedProductForStoreAsync(plannedDateTime);
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }


        private void AddNewPlannedProduct(DateTimeOffset plannedDateTime, string productId, string productName, DateTimeOffset implementationDateTime, short quantity)
        {
            var newProduct = new PlannedProductDTO
            {
                PlannedDateTime = plannedDateTime,
                ProductId = productId,
                ProductName = productName,
                ImplementationDateTime = implementationDateTime,
                Quantity = quantity
            };

            _plannedProducts.Add(newProduct);
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
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }

            _isProcessingQueue = false;
        }


    }
}
