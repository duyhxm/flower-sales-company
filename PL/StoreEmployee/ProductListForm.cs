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

namespace PL.StoreEmployee
{
    public partial class ProductListForm : Form
    {
        private static ProductListForm? _instance;
        private static readonly object _lock = new object();

        private StoreService _storeService = new StoreService();

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

        private void btnCreate_Click(object sender, EventArgs e)
        {

        }
    }
}
