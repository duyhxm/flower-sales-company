using BL;
using DL.Models;
using DTO.Material;
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
    public partial class MaterialAdjustmentForm : System.Windows.Forms.Form
    {
        //Cấu hình khởi tạo đối tượng
        private static MaterialAdjustmentForm? _instance;
        private static readonly object _lock = new object();
        MaterialService materialService;
        FlowerSalesCompanyDbContext context = new FlowerSalesCompanyDbContext();
        private MaterialAdjustmentForm()
        {
            InitializeComponent();
            materialService = new MaterialService();
        }
        public class FlowerListItem
        {
            public string FlowerID { get; set; }
            public string FlowerName { get; set; }
            public string FTypeName { get; set; }
            public string FColorName { get; set; }
            public string FCharacteristicName { get; set; }
            public decimal? ProfitRate { get; set; }
        }
        public class AccessListItem
        {
            public string MaterialId { get; set; } = null!;

            public string? MaterialName { get; set; }


            public decimal? ProfitRateA { get; set; }
        }

        List<FlowerListItem> tempDgv = null;
        public async void LoadFlower()
        {

            List<FlowerDTO> flowerDTOs = await materialService.GetFlowerInventoryAsync();
            List<FlowerListItem> updatedFlowerList = new List<FlowerListItem>(); // Danh sách đối tượng FlowerListItem

            // Duyệt qua từng phần tử trong flowerDTOs
            foreach (var flower in flowerDTOs)
            {
                // Tìm ProfitRate tương ứng trong salesTargetHistory
                decimal? profitRate = 0; // Giá trị mặc định

                var obj = context.FlowerSalesTargetHistories.Where(a => a.FlowerId == flower.FlowerID).FirstOrDefault();
                if (obj != null)
                {
                    profitRate = obj.ProfitRate;
                }

                // Tạo đối tượng FlowerListItem
                var newFlower = new FlowerListItem
                {
                    FlowerID = flower.FlowerID,
                    FlowerName = flower.FlowerName,
                    FTypeName = flower.FTypeName,
                    FColorName = flower.FColorName,
                    FCharacteristicName = flower.FCharacteristicName,
                    ProfitRate = profitRate
                };

                updatedFlowerList.Add(newFlower);
            }

            // Gán vào DataGridView
            dgvFlowerPrice.DataSource = updatedFlowerList;
            tempDgv = updatedFlowerList; // Lưu vào tempDgv

            // Gán vào DataGridView
            dgvFlowerPrice.DataSource = updatedFlowerList;


            // Lấy danh sách các FTypeName từ flowerDTOs và loại bỏ các giá trị trùng lặp
            List<string> typeNames = flowerDTOs
                .Select(f => f.FTypeName)
                .Distinct()
                .ToList();
            typeNames.Insert(0, "");
            // Gán danh sách vào ComboBox
            cbbType.DataSource = typeNames;

            List<string> colorNames = flowerDTOs
               .Select(f => f.FColorName)
               .Distinct()
               .ToList();
            colorNames.Insert(0, "");
            // Gán danh sách vào ComboBox
            cbbColor.DataSource = colorNames;

            List<string> colorChar = flowerDTOs
              .Select(f => f.FCharacteristicName)
              .Distinct()
              .ToList();
            colorChar.Insert(0, "");
            // Gán danh sách vào ComboBox
            cbbChar.DataSource = colorChar;


        }
        public async void LoadAccessoryProfitRates()
        {
            // Fetch data for Material and AccessoryProfitRateHistory
            List<MaterialDTO> accessoryProfitRates = await materialService.GetMaterialInventoryAsync();

            // Query AccessoryProfitRates where UsageStatus is "Đang áp dụng"
            var activeProfitRates = context.AccessoryProfitRates
                .Where(apr => apr.UsageStatus == "Đang áp dụng")
                .ToList();

            // Create a list to store the AccessListItem
            List<AccessListItem> accessListItems = new List<AccessListItem>();

            // Iterate over each material in accessoryProfitRates
            foreach (var material in accessoryProfitRates)
            {
                // Find the corresponding active ProfitRate in AccessoryProfitRates and AccessoryProfitRateHistories
                var profitRateRecord = (from apr in activeProfitRates
                                        join aprh in context.AccessoryProfitRateHistories
                                        on apr.AccessoryProfitRateId equals aprh.AccessoryProfitRateId
                                        where aprh.AccessoryId == material.MaterialId
                                        select aprh.ProfitRate).FirstOrDefault();

                decimal? profitRate = profitRateRecord ?? 0; // Default to 0 if no ProfitRate is found

                // Create a new AccessListItem and add it to the list
                var newAccess = new AccessListItem
                {
                    MaterialId = material.MaterialId,
                    MaterialName = material.MaterialName,

                    ProfitRateA = profitRate
                };

                accessListItems.Add(newAccess);
            }

            // Bind the list of AccessListItems to the DataGridView
            dgvAccessoryPrice.DataSource = accessListItems;
        }


        private void MaterialAdjustmentForm_Load(object sender, EventArgs e)
        {
            LoadFlower();
            LoadAccessoryProfitRates();
        }
        public static void Initialize()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    try
                    {
                        _instance = new MaterialAdjustmentForm();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }

        public static MaterialAdjustmentForm Instance
        {
            get
            {
                if (_instance == null)
                {
                    throw new InvalidOperationException("MaterialAdjustmentForm is not initialized. Call Initialize() first.");
                }
                return _instance;
            }
        }

        private void AddNewColToAdjust(DataGridView dgv)
        {
            DataGridViewColumn newCol = new DataGridViewTextBoxColumn();
            newCol.HeaderText = "New PR";
            newCol.Name = "ColNewFProfitRate";
            newCol.Width = 200;
            newCol.ReadOnly = false;
            dgv.Columns.Add(newCol);
        }

        private void btnAdjustFPrice_Click(object sender, EventArgs e)
        {
            // Kiểm tra DataGridView và đảm bảo dữ liệu đã được load
            if (dgvFlowerPrice.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để cập nhật!");
                return;
            }

            // Duyệt qua các dòng trong DataGridView
            using (var context = new FlowerSalesCompanyDbContext())
            {
                foreach (DataGridViewRow row in dgvFlowerPrice.Rows)
                {
                    // Kiểm tra xem dòng có được check không
                    bool isChecked = Convert.ToBoolean(row.Cells["Check"].Value);
                    if (isChecked)
                    {
                        // Lấy thông tin cần thiết từ DataGridView
                        string flowerId = row.Cells["ID"].Value.ToString();
                        decimal newProfitRate = Convert.ToDecimal(row.Cells["Asls PrfitRate"].Value);

                        var target = context.FlowerSalesTargetHistories
                            .FirstOrDefault(f => f.FlowerId == flowerId);

                        if (target != null)
                        {
                            target.ProfitRate = newProfitRate;
                        }
                    }
                }

                // Lưu thay đổi vào database
                context.SaveChanges();
                MessageBox.Show("Cập nhật thành công!");
            }
        }

        private void btnAdjustA_Click(object sender, EventArgs e)
        {

        }

        private void cbbType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbbType.SelectedItem.ToString()))
            {
                // Nếu không có lựa chọn, hiển thị toàn bộ danh sách
                dgvFlowerPrice.DataSource = tempDgv;
            }
            else
            {
                // Nếu có lựa chọn, lọc theo FTypeName
                string selectedType = cbbType.SelectedItem.ToString();

                // Lọc danh sách flowerDTOs theo loại hoa (FTypeName)
                var filteredList = tempDgv.Where(flower => flower.FTypeName == selectedType).ToList();

                // Gán danh sách đã lọc vào DataGridView
                dgvFlowerPrice.DataSource = filteredList;
            }
        }

        private void dgvFlowerPrice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvFlowerPrice.Columns["HistoryProfitRate"].Index && e.RowIndex >= 0)
            {
                string productId = dgvFlowerPrice.Rows[e.RowIndex].Cells["FlowerID"].Value.ToString();
                FlowerHistoryProfitRate formDetails = new FlowerHistoryProfitRate(productId);
                formDetails.ShowDialog();
            }
            if (e.ColumnIndex == dgvFlowerPrice.Columns["HistoryRateFlower"].Index && e.RowIndex >= 0)
            {
                string productId = dgvFlowerPrice.Rows[e.RowIndex].Cells["FlowerID"].Value.ToString();
                ChartFlowerRate formDetails = new ChartFlowerRate(productId);
                formDetails.ShowDialog();
            }
        }

        private void dgvAccessoryPrice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvAccessoryPrice.Columns["AccesoryHistoryPrice"].Index && e.RowIndex >= 0)
            {
                string productId = dgvAccessoryPrice.Rows[e.RowIndex].Cells["MaterialId"].Value.ToString();
                AccesoryHistoryProfitRate formDetails = new AccesoryHistoryProfitRate(productId);
                formDetails.ShowDialog();
            }
            if (e.ColumnIndex == dgvAccessoryPrice.Columns["HistoryRateChart"].Index && e.RowIndex >= 0)
            {
                string productId = dgvAccessoryPrice.Rows[e.RowIndex].Cells["MaterialId"].Value.ToString();
                ChartAccessoryRate formDetails = new ChartAccessoryRate(productId);
                formDetails.ShowDialog();
            }
        }

        private void cbbColor_SelectedValueChanged(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(cbbColor.SelectedItem.ToString()))
            {
                // Nếu không có lựa chọn, hiển thị toàn bộ danh sách
                dgvFlowerPrice.DataSource = tempDgv;
            }
            else
            {
                // Nếu có lựa chọn, lọc theo FTypeName
                string selectedType = cbbColor.SelectedItem.ToString();

                // Lọc danh sách flowerDTOs theo loại hoa (FTypeName)
                var filteredList = tempDgv.Where(flower => flower.FColorName == selectedType).ToList();

                // Gán danh sách đã lọc vào DataGridView
                dgvFlowerPrice.DataSource = filteredList;
            }
        }

        private void cbbChar_SelectedValueChanged(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(cbbChar.SelectedItem.ToString()))
            {
                // Nếu không có lựa chọn, hiển thị toàn bộ danh sách
                dgvFlowerPrice.DataSource = tempDgv;
            }
            else
            {
                // Nếu có lựa chọn, lọc theo FTypeName
                string selectedType = cbbChar.SelectedItem.ToString();

                // Lọc danh sách flowerDTOs theo loại hoa (FTypeName)
                var filteredList = tempDgv.Where(flower => flower.FCharacteristicName == selectedType).ToList();

                // Gán danh sách đã lọc vào DataGridView
                dgvFlowerPrice.DataSource = filteredList;
            }
        }
    }
}
