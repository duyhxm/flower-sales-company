using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO.Store;
using BL;

namespace PL
{
    public partial class InventoryForm : Form
    {
        //khai báo cấu hình khởi tạo form
        private static InventoryForm? _instance;
        private static readonly object _lock = new object();

        //khai báo các service được sử dụng
        private StoreService _storeService;

        //khai báo các biến sử dụng trong form
        public List<MaterialInventoryDTO> MaterialInventory; //vật liệu
        public BindingSource ProductInventory;//sản phẩm
        public List<ProductInventoryDTO>? ProductStockDetails;


        private InventoryForm()
        {
            //khởi tạo các thành phần trong designer
            InitializeComponent();

            //khởi tạo các dịch vụ
            _storeService = new StoreService();

            //khởi tạo các biến sử dụng
            MaterialInventory = new List<MaterialInventoryDTO>();
            ProductInventory = new BindingSource();

            //Setup for data grid view
            SetupMaterialInventoryDgv();
            SetupProductInventoryDgv();

            //Khởi tạo ComboBox cho filter
            string[] materialType = { "both", "flower", "accessory" };
            cmbBxMaterials.Items.AddRange(materialType);
            cmbBxMaterials.SelectedIndex = 0;
        }

        private void SetupMaterialInventoryDgv()
        {
            //cấu hình cho material inventory
            dgvMaterialInventory.Columns["ColMaterialId"].DataPropertyName = "MaterialId";
            dgvMaterialInventory.Columns["ColMaterialName"].DataPropertyName = "MaterialName";
            dgvMaterialInventory.Columns["ColStockMaterialQuantity"].DataPropertyName = "StockMaterialQuantity";
            dgvMaterialInventory.Columns["ColUnitPrice"].DataPropertyName = "UnitPrice";
        }

        private void SetupProductInventoryDgv()
        {
            //cấu hình cho product inventory
            dgvProductInventory.Columns["ColProductId"].DataPropertyName = "ProductId";
            dgvProductInventory.Columns["ColProductName"].DataPropertyName = "ProductName";
            dgvProductInventory.Columns["ColStockProductQuantity"].DataPropertyName = "StockProductQuantity";
            dgvProductInventory.AutoGenerateColumns = false;
        }

        public static void Initialize()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    try
                    {
                        _instance = new InventoryForm();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }

        public static InventoryForm Instance
        {
            get
            {
                if (_instance == null)
                {
                    throw new InvalidOperationException("InventoryForm is not initialized. Call Initialize() first.");
                }
                return _instance;
            }
        }

        private void FilterMaterialInventory()
        {
            if (MaterialInventory == null) return;

            var filteredStoreInventory = MaterialInventory;

            string? selectedFilter = cmbBxMaterials.SelectedItem?.ToString();

            if (selectedFilter == "flower")
            {
                filteredStoreInventory = MaterialInventory
                    .Where(si => si.MaterialId.StartsWith("F")).ToList();
            }
            else if (selectedFilter == "accessory")
            {
                filteredStoreInventory = MaterialInventory
                    .Where(si => si.MaterialId.StartsWith("A")).ToList();
            }

            dgvMaterialInventory.DataSource = filteredStoreInventory;
            dgvMaterialInventory.Refresh();
        }

        private void cmbBxMaterials_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterMaterialInventory();
        }

        //Load data trực tiếp từ database
        public async Task LoadMaterialInventory(string? storeId)
        {
            if (storeId == null)
            {
                return;
            }

            try
            {
                var result = await _storeService.GetMaterialInventoryByStoreAsync(storeId);

                MaterialInventory = result.Where(x => x.StockMaterialQuantity > 0).ToList();

                if (InvokeRequired)
                {
                    Invoke(new Action(() => FilterMaterialInventory()));
                }
                else
                {
                    FilterMaterialInventory();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Load data trực tiếp từ database
        public async Task LoadProductInventory(string? storeId)
        {
            if (storeId == null) return;

            try
            {
                ProductStockDetails = await _storeService.GetProductInventoryByStoreAsync(storeId);

                if (ProductStockDetails != null)
                {
                    var groupedProducts = ProductStockDetails
                                        .GroupBy(p => new { p.ProductId, p.ProductName })
                                        .Select(g => new ProductInventoryDTO
                                        {
                                            ProductId = g.Key.ProductId,
                                            ProductName = g.Key.ProductName,
                                            StockProductQuantity = g.Sum(p => p.StockProductQuantity)
                                        })
                                        .ToList();

                    ProductInventory.DataSource = groupedProducts;
                    dgvProductInventory.DataSource = ProductInventory;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Gọi hàm này khi mà data thay đổi giữa các form
        public async Task RefreshStoreInventory()
        {
            FilterMaterialInventory();
            await LoadProductInventory(LoginForm.Instance.LoginInformation.StoreID);
        }

        //Track event click vô ô details ở product inventory
        private void dgvProductInventory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3) // Assuming the index of the cell to click is 3
            {
                var selectedProductId = dgvProductInventory.Rows[e.RowIndex].Cells["ColProductId"].Value.ToString();
                var selectedProductDetails = (ProductStockDetails!)
                    .Where(p => p.ProductId == selectedProductId)
                    .ToList();

                var productStockDetailsForm = new ProductStockDetails(selectedProductDetails);
                productStockDetailsForm.ShowDialog();
            }
        }

        public bool CheckProductInventory(List<(string ProductId, int Quantity)> products)
        {
            foreach (var product in products)
            {
                var inventoryItem = ProductInventory.List.OfType<ProductInventoryDTO>()
                    .FirstOrDefault(p => p.ProductId == product.ProductId);

                if (inventoryItem == null || inventoryItem.StockProductQuantity < product.Quantity)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
