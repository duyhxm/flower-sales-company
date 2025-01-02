using DL.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PL.SalesEmployee
{
    public partial class FlowerHistoryProfitRate : System.Windows.Forms.Form
    {
        private string flowerID { get; set; }

        public FlowerHistoryProfitRate(string flowerID)
        {
            InitializeComponent();
            this.flowerID = flowerID;
            LoadData();
        }

        private void LoadData()
        {
            using (var context = new FlowerSalesCompanyDbContext())
            {

                var result = (from history in context.FlowerSalesTargetHistories
                              join target in context.FlowerSalesTargets
                              on history.TargetId equals target.TargetId
                              where history.FlowerId == flowerID // Điều kiện lọc FlowerId
                              && (target.UsageStatus == "Đang áp dụng" || target.UsageStatus == "Sắp áp dụng") // Điều kiện UsageStatus
                              select new
                              {
                                  history.TargetId,
                                  history.FlowerId,
                                  history.ExpectedQuantity,
                                  history.ProfitRate,
                                  target.ApplyMonth,
                                  target.ApplyYear,
                                  target.UsageStatus
                              }).ToList();

                // Hiển thị kết quả lên DataGridView
                dataGridViewHistory.DataSource = result;

            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdjustFPrice_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new FlowerSalesCompanyDbContext())
                {
                    // Lấy TargetId và FlowerId từ TextBox
                    var targetId = txtTargetId.Text.Trim();
                    var flowerId = txtFlowerId.Text.Trim();

                    if (string.IsNullOrEmpty(targetId) || string.IsNullOrEmpty(flowerId))
                    {
                        MessageBox.Show("Vui lòng chọn dòng để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Tìm bản ghi cần cập nhật
                    var historyRecord = context.FlowerSalesTargetHistories
                        .FirstOrDefault(h => h.TargetId == targetId && h.FlowerId == flowerId);

                    if (historyRecord != null)
                    {
                        historyRecord.ProfitRate = decimal.Parse(txtProfitRate.Text.Trim());

                        // Lưu thay đổi vào database
                        context.SaveChanges();

                        MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Cập nhật lại DataGridView
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy bản ghi để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridViewHistory.Rows.Count)
            {
                // Lấy dữ liệu từ hàng được chọn
                var selectedRow = dataGridViewHistory.Rows[e.RowIndex];

                // Gán dữ liệu từ DataGridView vào các TextBox
                txtTargetId.Text = selectedRow.Cells["TargetId"].Value?.ToString();
                txtFlowerId.Text = selectedRow.Cells["FlowerId"].Value?.ToString();
                txtExpectedQuantity.Text = selectedRow.Cells["ExpectedQuantity"].Value?.ToString();
                txtProfitRate.Text = selectedRow.Cells["ProfitRate"].Value?.ToString();
            }
        }

        private void btnAddNewFPrice_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new FlowerSalesCompanyDbContext())
                {
                    // Lấy tháng và năm hiện tại
                    int currentMonth = DateTime.Now.Month;
                    int currentYear = DateTime.Now.Year;
                    int currentDay = DateTime.Now.Day;
                    // Kiểm tra TargetID có tồn tại với tháng và năm hiện tại chưa
                    var existingTarget = context.FlowerSalesTargets
                        .FirstOrDefault(t => t.ApplyMonth == currentMonth && t.ApplyYear == currentYear);

                    if (existingTarget == null)
                    {
                        // Nếu không tìm thấy, tạo TargetID mới
                        var newTarget = new FlowerSalesTarget
                        {
                            TargetId = $"{currentYear}{currentMonth:D2}{currentDay:D2}",
                            ApplyMonth = currentMonth,
                            ApplyYear = currentYear,
                            UsageStatus = "Đang áp dụng" // Gán trạng thái mặc định
                        };

                        // Thêm TargetID mới vào database
                        context.FlowerSalesTargets.Add(newTarget);
                        context.SaveChanges();

                        // Cập nhật lại đối tượng `existingTarget` để sử dụng tiếp
                        existingTarget = newTarget;

                        MessageBox.Show("TargetID mới đã được tạo cho tháng và năm hiện tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    // Lấy TargetID từ bản ghi tìm thấy hoặc vừa tạo
                    string targetId = existingTarget.TargetId;

                    // Kiểm tra FlowerID đã được thêm vào TargetID chưa
                    var existingFlower = context.FlowerSalesTargetHistories
                        .FirstOrDefault(h => h.TargetId == targetId && h.FlowerId == flowerID);

                    if (existingFlower != null)
                    {
                        MessageBox.Show("FlowerID này đã được thêm vào TargetID hiện tại!",
                                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // Nếu chưa tồn tại, thêm bản ghi mới
                    var newRecord = new FlowerSalesTargetHistory
                    {
                        TargetId = targetId,
                        FlowerId = flowerID,
                        ExpectedQuantity = int.Parse(txtExpectedQuantity.Text.Trim()),
                        ProfitRate = decimal.Parse(txtProfitRate.Text.Trim())
                    };

                    context.FlowerSalesTargetHistories.Add(newRecord);
                    context.SaveChanges();

                    MessageBox.Show("Thêm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Làm mới DataGridView
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
