using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BL;
using DTO.Enum;
using DL.Repositories.Implementations;
using DTO.Product;
using static BL.GeneralService;

namespace PL.StoreEmployee
{
    public partial class ProductListForm : Form
    {
        private static ProductListForm? _instance;
        private static readonly object _lock = new object();

        private StoreService _storeService = new StoreService();
        private ProductService _productService = new ProductService();

        private BindingList<PlannedProductDTO> _plannedProducts;
        private BindingSource _bindingSource;
        private ProductListForm()
        {
            InitializeComponent();

            _plannedProducts = new BindingList<PlannedProductDTO>();
            _bindingSource = new BindingSource(_plannedProducts, null);

            SetupProductListDgv();
        }

        public static void Initialize()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    try
                    {
                        _instance = new ProductListForm();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }

        private async void ProductListForm_Load(object sender, EventArgs e)
        {
            await LoadProductList(DateTime.Now.Date, LoginForm.Instance.LoginInformation.StoreID!, PlanStatus.Completed);
        }

        public static ProductListForm Instance
        {
            get
            {
                if (_instance == null)
                {
                    throw new InvalidOperationException("ProductListForm is not initialized. Call Initialize() first.");
                }

                return _instance;
            }
        }

        private void SetupProductListDgv()
        {
            dgvProductList.Columns["ColProductId"].DataPropertyName = "ProductId";

            dgvProductList.Columns["ColProductName"].DataPropertyName = "ProductName";

            dgvProductList.Columns["ColFRName"].DataPropertyName = "FRName";

            dgvProductList.AutoGenerateColumns = false;

            dgvProductList.DataSource = _bindingSource;
        }

        public void AddProductToDgv(PlannedProductDTO product)
        {
            _plannedProducts.Add(product);
        }

        public async Task LoadProductList(DateTime currentDate, string storeId, string planStatus)
        {
            try
            {
                var plannedProducts = await _storeService.GetPlannedProductsForStoreAsync(currentDate, storeId, planStatus);

                if (plannedProducts.Count != 0)
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnCreate_Click(object sender, EventArgs e)
        {
            if (txtBxQuantity.Text == string.Empty || !int.TryParse(txtBxQuantity.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Giá trị ở ô số lượng sản phẩm không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedProductIds = new List<string>();

            foreach (DataGridViewRow row in dgvProductList.Rows)
            {
                var isSelected = Convert.ToBoolean(row.Cells["ColSelection"].Value);
                if (isSelected)
                {
                    var productId = row.Cells["ColProductId"].Value.ToString();
                    selectedProductIds.Add(productId);
                }
            }

            if (selectedProductIds.Count == 0)
            {
                MessageBox.Show("Không có sản phẩm nào được chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show("Bạn có chắc chắn muốn tạo các sản phẩm đã chọn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    foreach (var productId in selectedProductIds)
                    {
                        var detailedProducts = await GetDetailedProductByIdAsync(productId);

                        decimal unitPrice = await CalculateUnitPriceAsync(detailedProducts);

                        ProductCreationHistoryDTO history = new()
                        {
                            CreatedDateTime = LocalDateTimeOffset(),
                            ProductId = productId,
                            EmployeeId = LoginForm.Instance.LoginInformation.UserAccount.EmployeeId!,
                            CreatedQuantity = Convert.ToInt16(txtBxQuantity.Text),
                            UnitPrice = unitPrice,
                        };

                        var product = await _productService.FindProductByIdAsync(productId);

                        foreach (var detailedProduct in detailedProducts)
                        {
                            DetailedProductDTO detailedProductDTO = new()
                            {
                                ProductId = productId,
                                MaterialId = detailedProduct.MaterialId,
                                UsedQuantity = detailedProduct.UsedQuantity
                            };

                            product.DetailedProducts.Add(detailedProductDTO);
                        }

                        await _productService.AddProductAsync(product, history, LoginForm.Instance.LoginInformation.StoreID!);
                    }

                    await InventoryForm.Instance.LoadMaterialInventory(LoginForm.Instance.LoginInformation.StoreID!);
                    await InventoryForm.Instance.LoadProductInventory(LoginForm.Instance.LoginInformation.StoreID!);

                    MessageBox.Show("Tạo sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private async Task<decimal> CalculateUnitPriceAsync(List<DetailedProductMaterialNameDTO> detailedProducts)
        {
            Dictionary<string, int> materialQuantities = new();

            foreach (var dt in detailedProducts)
            {
                materialQuantities.Add(dt.MaterialId, Convert.ToInt32(dt.UsedQuantity));
            }
            try
            {
                return await _productService.CalculateUnitPriceAsync(materialQuantities);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tính giá sản phẩm: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        private async Task<List<DetailedProductMaterialNameDTO>> GetDetailedProductByIdAsync(string productId)
        {
            List<DetailedProductMaterialNameDTO> result = new();
            try
            {
                result = await _productService.GetDetailedProductsByProductIdAsync(productId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return result;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc chắn muốn bỏ chọn các sản phẩm đã chọn và xóa số lượng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dgvProductList.Rows)
                {
                    row.Cells["ColSelection"].Value = false;
                }

                txtBxQuantity.Clear();
            }
        }
    }
}
