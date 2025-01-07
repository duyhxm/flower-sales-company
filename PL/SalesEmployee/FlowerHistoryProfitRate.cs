using DL.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BL;
using DTO.Material;

namespace PL.SalesEmployee
{
    public partial class FlowerHistoryProfitRate : System.Windows.Forms.Form
    {
        private string _flowerId;

        private List<FlowerProfitRateDTO> _flowerProfitRates = new();

        private MaterialService _materialService = new();

        private decimal selectedApplyMonth = 0;
        private decimal selectedApplyYear = 0;

        public FlowerHistoryProfitRate(string flowerId)
        {
            InitializeComponent();
            _flowerId = flowerId;
            txtBxFlowerId.Text = _flowerId;

            SetupFlowerProfitRates();
        }

        private void SetupFlowerProfitRates()
        {
            dgvFlowerProfitRates.AutoGenerateColumns = false;

            dgvFlowerProfitRates.Columns["ColApplyMonth"].Width = 100;
            dgvFlowerProfitRates.Columns["ColApplyMonth"].DataPropertyName = "ApplyMonth";

            dgvFlowerProfitRates.Columns["ColApplyYear"].Width = 100;
            dgvFlowerProfitRates.Columns["ColApplyYear"].DataPropertyName = "ApplyYear";

            dgvFlowerProfitRates.Columns["ColExpectedQuantity"].Width = 80;
            dgvFlowerProfitRates.Columns["ColExpectedQuantity"].DataPropertyName = "ExpectedQuantity";

            dgvFlowerProfitRates.Columns["ColProfitRate"].Width = 100;
            dgvFlowerProfitRates.Columns["ColProfitRate"].DataPropertyName = "ProfitRate";

            dgvFlowerProfitRates.Columns["ColUsageStatus"].Width = 200;
            dgvFlowerProfitRates.Columns["ColUsageStatus"].DataPropertyName = "UsageStatus";
        }
        private async void FlowerHistoryProfitRate_Load(object sender, EventArgs e)
        {
            await LoadFlowerProfitRateHistoryAsync();
        }

        private async Task LoadFlowerProfitRateHistoryAsync()
        {
            try
            {
                List<FlowerProfitRateDTO> result = await _materialService.GetFlowerProfitRatesByIdAsync(_flowerId);

                if (result.Count == 0)
                {
                    MessageBox.Show($"Dữ hiện tỉ lệ lợi nhuận cho hoa {_flowerId} hiện đang trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                _flowerProfitRates = result;

                dgvFlowerProfitRates.DataSource = _flowerProfitRates;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnAdjustFPrice_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedApplyMonth == 0 || selectedApplyYear == 0)
                {
                    MessageBox.Show("Bạn cần chọn một row để thực hiện thay đổi dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (!int.TryParse(txtExpectedQuantity.Text.Trim(), out int expectedQuantity))
                {
                    MessageBox.Show("Expected Quantity phải là số nguyên hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!decimal.TryParse(txtProfitRate.Text.Trim(), out decimal profitRate) || profitRate < 0 || profitRate > 999.9m)
                {
                    MessageBox.Show("Profit Rate phải là số thập phân hợp lệ với tối đa 5 chữ số và 1 chữ số thập phân", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var flowerProfitRate = _flowerProfitRates.FirstOrDefault(f => f.ApplyMonth == selectedApplyMonth && f.ApplyYear == selectedApplyYear);

                if (flowerProfitRate != null)
                {
                    await _materialService.UpdateFlowerProfitRateAsync(flowerProfitRate.TargetId, _flowerId, expectedQuantity, profitRate);

                    await LoadFlowerProfitRateHistoryAsync();
                }

                MessageBox.Show("Đã cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnAddNewFPrice_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtExpectedQuantity.Text.Trim(), out int expectedQuantity))
                {
                    MessageBox.Show("Expected Quantity phải là số nguyên hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!decimal.TryParse(txtProfitRate.Text.Trim(), out decimal profitRate) || profitRate < 0 || profitRate > 999.9m)
                {
                    MessageBox.Show("Profit Rate phải là số thập phân hợp lệ với tối đa 5 chữ số và 1 chữ số thập phân", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DateTime currentDate = DateTime.Now;
                int nextMonth = currentDate.Month == 12 ? 1 : currentDate.Month + 1;
                int nextYear = currentDate.Month == 12 ? currentDate.Year + 1 : currentDate.Year;

                string targetId = new DateTime(nextYear, nextMonth, 1).AddDays(-1).ToString("yyyyMMdd");

                var existingTarget = await _materialService.GetFlowerProfitRatesByMonthYearAsync(nextMonth, nextYear);

                if (existingTarget.Any())
                {
                    MessageBox.Show("Đã tồn tại TargetID cho tháng và năm này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                await _materialService.AddNewFlowerProfitRateAsync(targetId, _flowerId, expectedQuantity, profitRate, nextMonth, nextYear);

                MessageBox.Show("Thêm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await LoadFlowerProfitRateHistoryAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvFlowerProfitRates_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvFlowerProfitRates.Rows.Count)
            {
                // Lấy dữ liệu từ hàng được chọn
                var selectedRow = dgvFlowerProfitRates.Rows[e.RowIndex];

                selectedApplyMonth = Convert.ToDecimal(selectedRow.Cells["ColApplyMonth"].Value.ToString());
                selectedApplyYear = Convert.ToDecimal(selectedRow.Cells["ColApplyYear"].Value.ToString());

                txtExpectedQuantity.Text = selectedRow.Cells["ColExpectedQuantity"].Value?.ToString();
                txtProfitRate.Text = selectedRow.Cells["ColProfitRate"].Value?.ToString();
            }
        }
    }
}
