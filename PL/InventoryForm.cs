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
using DTO;
using BL;

namespace PL
{
    public partial class InventoryForm : Form
    {
        private static InventoryForm? _instance;
        private static readonly object _lock = new object();
        private StoreService _storeService;
        public List<StoreInventoryDTO> storeInventory;

        private InventoryForm()
        {
            InitializeComponent();
            _storeService = new StoreService();
            storeInventory = new List<StoreInventoryDTO>();

            dgvStoreInventory.Columns["ColMaterialId"].DataPropertyName = "MaterialId";
            dgvStoreInventory.Columns["ColMaterialName"].DataPropertyName = "MaterialName";
            dgvStoreInventory.Columns["ColStockMaterialQuantity"].DataPropertyName = "StockMaterialQuantity";
            dgvStoreInventory.Columns["ColUnitPrice"].DataPropertyName = "UnitPrice";

            //Khởi tạo ComboBox cho filter
            string[] materialType = { "both", "flower", "accessory" };

            cmbBxMaterials.Items.AddRange(materialType);
            cmbBxMaterials.SelectedIndex = 0;
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

        private void FilterStoreInventory()
        {
            if (storeInventory == null) return;

            var filteredStoreInventory = storeInventory;

            string? selectedFilter = cmbBxMaterials.SelectedItem?.ToString();

            if (selectedFilter == "flower")
            {
                filteredStoreInventory = storeInventory
                    .Where(si => si.MaterialId.StartsWith("F")).ToList();
            }
            else if (selectedFilter == "accessory")
            {
                filteredStoreInventory = storeInventory
                    .Where(si => si.MaterialId.StartsWith("A")).ToList();
            }

            dgvStoreInventory.DataSource = filteredStoreInventory;
            dgvStoreInventory.Refresh();
        }

        private void cmbBxMaterials_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterStoreInventory();
        }

        //Gọi hàm này khi mà data thay đổi ở dưới database
        public async Task LoadStoreInventory(string? storeId)
        {
            if (storeId == null)
            {
                return;
            }

            try
            {
                var result = await _storeService.GetStoreInventoryAsync(storeId);

                storeInventory = result.Where(x => x.StockMaterialQuantity > 0).ToList();

                FilterStoreInventory();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Gọi hàm này khi mà data thay đổi giữa các form

        public void RefreshStoreInventory()
        {
            FilterStoreInventory();
        }

        public int UpdateQuantity(Dictionary<string, int> data)
        {
            string id;
            int quantity;

            try
            {
                foreach (var i in data)
                {
                    id = i.Key;
                    quantity = i.Value;

                    // Tìm mục trong _storeInventory dựa trên materialId
                    var inventoryItem = storeInventory.FirstOrDefault(si => si.MaterialId == id);
                    if (inventoryItem != null)
                    {
                        // Cập nhật StockMaterialQuantity
                        inventoryItem.StockMaterialQuantity = quantity;
                    }
                }

                FilterStoreInventory();
                return -1;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
        }

    }
}
