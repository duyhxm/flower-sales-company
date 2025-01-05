using DL.Models;
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
    public partial class AccesoryHistoryProfitRate : System.Windows.Forms.Form
    {
        private string accsoryId { get; set; }
        public AccesoryHistoryProfitRate(string accsoryId)
        {
            InitializeComponent();
            this.accsoryId = accsoryId;
        }
        private void LoadData()
        {
            using (var context = new FlowerSalesCompanyDbContext())
            {
                // Join the AccessoryProfitRateHistory and AccessoryProfitRate tables
                var result = (from history in context.AccessoryProfitRateHistories
                              join rate in context.AccessoryProfitRates
                              on history.AccessoryProfitRateId equals rate.AccessoryProfitRateId
                              where history.AccessoryId == accsoryId // Filter by AccessoryID
                           && (rate.UsageStatus == "Đang áp dụng" || rate.UsageStatus == "Sắp áp dụng")
                              select new
                              {
                                  history.AccessoryProfitRateId,
                                  history.AccessoryId,
                                  history.ProfitRate,
                                  rate.StartDate,
                                  rate.EndDate,
                                  rate.UsageStatus
                              }).ToList();

                // Bind the result to the DataGridView
                dgvAProfitRateHistory.DataSource = result;
            }
        }


        private void AccesoryHistoryProfitRate_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAdjustFPrice_Click(object sender, EventArgs e)
        {
            // Get the values from the TextBox controls
            string accessoryProfitRateId = txtAccessoryProfitRateID.Text;
            string accessoryId = txtAccessoryID.Text;
            string profitRateText = txtProfitRate.Text;

            // Validate input values
            if (string.IsNullOrEmpty(accessoryProfitRateId) || string.IsNullOrEmpty(accessoryId) || string.IsNullOrEmpty(profitRateText))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi cập nhật.");
                return;
            }

            // Try to parse the ProfitRate to decimal
            decimal profitRate;
            if (!decimal.TryParse(profitRateText, out profitRate))
            {
                MessageBox.Show("Tỷ lệ lợi nhuận không hợp lệ. Vui lòng nhập một số hợp lệ.");
                return;
            }

            using (var context = new FlowerSalesCompanyDbContext())
            {
                // Find the AccessoryProfitRateHistory entry that matches the AccessoryProfitRateID and AccessoryID
                var historyRecord = context.AccessoryProfitRateHistories
                    .FirstOrDefault(h => h.AccessoryProfitRateId == accessoryProfitRateId && h.AccessoryId == accessoryId);

                if (historyRecord != null)
                {
                    // Update the ProfitRate
                    historyRecord.ProfitRate = profitRate;

                    // Save changes to the database
                    context.SaveChanges();

                    MessageBox.Show("Tỷ lệ lợi nhuận đã được cập nhật thành công.");

                    // Optionally, reload the data to reflect the changes in the DataGridView
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy bản ghi phù hợp để cập nhật.");
                }
            }
        }

        private void btnAddNewFPrice_Click(object sender, EventArgs e)
        {

            string profitRateText = txtProfitRate.Text;
            DateTime startDate = dateTimePickerStartDate.Value;  // StartDate from DateTimePicker
            DateTime endDate = dateTimePickerEndDate.Value;      // EndDate from DateTimePicker
            string usageStatus = "Sắp áp dụng";  // UsageStatus from TextBox (or could be a DropDownList)

            // Validate input values
            if (string.IsNullOrEmpty(accsoryId) || string.IsNullOrEmpty(profitRateText))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi thêm mới.");
                return;
            }

            // Check if the StartDate is greater than the current date
            if (startDate <= DateTime.Now)
            {
                MessageBox.Show("Ngày bắt đầu phải lớn hơn ngày hiện tại.");
                return;
            }

            // Check if the EndDate is greater than the StartDate
            if (endDate <= startDate)
            {
                MessageBox.Show("Ngày kết thúc phải lớn hơn ngày bắt đầu.");
                return;
            }

            // Try to parse the ProfitRate to decimal
            decimal profitRate;
            if (!decimal.TryParse(profitRateText, out profitRate))
            {
                MessageBox.Show("Tỷ lệ lợi nhuận không hợp lệ. Vui lòng nhập một số hợp lệ.");
                return;
            }

            // Generate AccessoryProfitRateID as the day before the StartDate (formatted as string)
            string accessoryProfitRateId = startDate.AddDays(-1).ToString("yyyyMMdd");

            using (var context = new FlowerSalesCompanyDbContext())
            {
                // Create a new AccessoryProfitRateHistory record
                var newHistoryRecord = new AccessoryProfitRateHistory
                {
                    AccessoryProfitRateId = accessoryProfitRateId,
                    AccessoryId = accsoryId,
                    ProfitRate = profitRate
                };

                // Add the new record to the AccessoryProfitRateHistory table
                context.AccessoryProfitRateHistories.Add(newHistoryRecord);

                // Create a new AccessoryProfitRate record
                var newProfitRateRecord = new AccessoryProfitRate
                {
                    AccessoryProfitRateId = accessoryProfitRateId,
                    StartDate = DateOnly.FromDateTime(startDate),
                    EndDate = DateOnly.FromDateTime(endDate),
                    UsageStatus = usageStatus
                };

                context.AccessoryProfitRates.Add(newProfitRateRecord);
                context.SaveChanges();
                MessageBox.Show("Đã thêm mới tỷ lệ lợi nhuận thành công.");
                LoadData();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvAProfitRateHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var clickedRow = dgvAProfitRateHistory.Rows[e.RowIndex];
                var accessoryProfitRateID = clickedRow.Cells["AccessoryProfitRateID"].Value.ToString();
                var accessoryID = clickedRow.Cells["AccessoryID"].Value.ToString();
                var profitRate = clickedRow.Cells["ProfitRate"].Value.ToString();
                var usageStatus = clickedRow.Cells["UsageStatus"].Value.ToString();
                txtAccessoryProfitRateID.Text = accessoryProfitRateID;
                txtAccessoryID.Text = accessoryID;
                txtProfitRate.Text = profitRate;
                txtUsageStatus.Text = usageStatus;
            }
        }
    }
}
