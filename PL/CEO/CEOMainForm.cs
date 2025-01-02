using BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Infrastructure;
using DTO;
using DL.Models;
using System.Windows.Forms.DataVisualization.Charting;

namespace PL
{
    public partial class CEOMainForm : System.Windows.Forms.Form, INotifiable
    {
        private NotificationService _notificationService;
        public CEOMainForm()
        {
            InitializeComponent();
            _notificationService = NotificationService.Instance;
        }

        private void CEOMainForm_Load(object sender, EventArgs e)
        {
            NotificationManager.Instance.RegisterForm(this);
        }

        private void CEOMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            NotificationManager.Instance.UnregisterForm(this);
        }

        public async Task HandleNotification(Dictionary<string, object> message)
        {
            // Handle the notification and update the UI
            MessageBox.Show($"SalesDepartmentMainForm received message: {message}");
        }

        private void btnDailyTask_Click(object sender, EventArgs e)
        {

        }
        private void Chart1()
        {
            // Lấy ngày bắt đầu và kết thúc từ DateTime Picker
            DateTime startDate = dateTimePickerStart.Value;
            DateTime endDate = dateTimePickerEnd.Value;


            using (var context = new FlowerSalesCompanyDbContext())
            {
                // Truy vấn tổng chi phí
                var totalExpense = context.OperatingExpenseHistories
                    .Where(e => e.ReportingYear >= startDate.Year && e.ReportingYear <= endDate.Year
                             && e.ReportingMonth >= startDate.Month && e.ReportingMonth <= endDate.Month)
                    .Sum(e => (decimal?)e.TotalExpense) ?? 0;

                // Truy vấn tổng doanh thu
                var totalRevenue = context.SalesOrders
                    .Where(o => o.CreatedDateTime >= startDate && o.CreatedDateTime <= endDate
                             && o.OrderStatus == "Hoàn thành")
                    .Sum(o => (decimal?)o.FinalPrice) ?? 0;

                // Tính toán tỷ lệ
                var total = totalExpense + totalRevenue;
                var expensePercentage = total == 0 ? 0 : (totalExpense / total) * 100;
                var revenuePercentage = total == 0 ? 0 : (totalRevenue / total) * 100;
                txt_chiPhi.Text = totalExpense.ToString("N0");
                txt_doanhThu.Text = totalRevenue.ToString("N0");
                // Xóa dữ liệu cũ
                chart1.Series.Clear();
                chart1.Titles.Clear();
                chart1.Legends.Clear(); // Xóa các chú thích cũ nếu có

                // Thêm tiêu đề
                chart1.Titles.Add("Biểu đồ thống kê chi phí và doanh thu");

                // Thêm chú thích (legend)
                var legend = chart1.Legends.Add("Chú thích");
                legend.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Right; // Vị trí hiển thị

                // Thêm series cho biểu đồ
                var series = chart1.Series.Add("Thống kê");
                series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;

                // Thêm dữ liệu vào series với giá trị làm tròn và chú thích
                series.Points.AddXY("Chi phí", Math.Round(expensePercentage));
                series.Points[0].Label = $"{Math.Round(expensePercentage)}%";
                series.Points[0].LegendText = "Chi phí"; // Chú thích cho màu đầu tiên

                series.Points.AddXY("Doanh thu", Math.Round(revenuePercentage));
                series.Points[1].Label = $"{Math.Round(revenuePercentage)}%";
                series.Points[1].LegendText = "Doanh thu"; // Chú thích cho màu thứ hai



                // Cấu hình hiển thị
                series.IsValueShownAsLabel = true; // Hiển thị giá trị trên biểu đồ                      }
            }
        }
        private void Chart2()
        {
            // Lấy ngày bắt đầu và kết thúc từ DateTime Picker
            DateTime startDate = dateTimePickerStart.Value;
            DateTime endDate = dateTimePickerEnd.Value;
         
            using (var context = new FlowerSalesCompanyDbContext())
            {
                var revenueData = context.RevenueHistories
                    .Where(r => r.ReportingYear > startDate.Year ||
                               (r.ReportingYear == startDate.Year && r.ReportingMonth >= startDate.Month) &&
                               r.ReportingYear < endDate.Year ||
                               (r.ReportingYear == endDate.Year && r.ReportingMonth <= endDate.Month))
                    .OrderBy(r => r.ReportingYear).ThenBy(r => r.ReportingMonth)
                    .Select(r => new
                    {
                        ReportingYear = r.ReportingYear,
                        ReportingMonth = r.ReportingMonth,
                        r.ExpectedFlowerRevenue,
                        r.NetFlowerRevenue,
                        r.NetSuppMaterialRevenue,
                        a = new DateTime((int)(r.ReportingYear.GetValueOrDefault()), (int)(r.ReportingMonth.GetValueOrDefault()), 1)
                    })
                    .ToList();

                // Xóa dữ liệu cũ
                chart2.Series.Clear();
                chart2.Titles.Clear();
                chart2.Legends.Clear();

                // Thêm tiêu đề biểu đồ
                chart2.Titles.Add("Biểu đồ doanh thu theo tháng");

                // Tạo series cho từng loại doanh thu
                var series1 = chart2.Series.Add("Doanh thu kỳ vọng (Expected)");
                var series2 = chart2.Series.Add("Doanh thu thực tế (Net Flower)");
                var series3 = chart2.Series.Add("Doanh thu phụ liệu (Net Supp)");

                // Đặt kiểu biểu đồ là đường
                series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

                // Thêm dữ liệu vào từng series
                foreach (var item in revenueData)
                {
                    series1.Points.AddXY(item.a, item.ExpectedFlowerRevenue);
                    series2.Points.AddXY(item.a, item.NetFlowerRevenue);
                    series3.Points.AddXY(item.a, item.NetSuppMaterialRevenue);
                }

                // Tùy chỉnh giao diện (màu sắc, chú thích, v.v.)
                series1.Color = System.Drawing.Color.Blue;
                series2.Color = System.Drawing.Color.Green;
                series3.Color = System.Drawing.Color.Orange;

                // Hiển thị chú thích (legend)
                var legend = chart2.Legends.Add("Chú thích");
                legend.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
                chart2.ChartAreas[0].AxisX.Title = "Time (Month/Year)";
                chart2.ChartAreas[0].AxisX.LabelStyle.Format = "MM/yyyy"; // Định dạng trục X tháng/năm
                chart2.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Months; // Định dạng theo tháng
                chart2.ChartAreas[0].AxisX.Interval = 1; // Hiển thị theo tháng
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePickerStart.Value;
            DateTime endDate = dateTimePickerEnd.Value;
            if ((endDate - startDate).Days > 365)
            {
                MessageBox.Show("Vui lòng chọn khoảng thời gian trong vòng 12 tháng.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Chart1();
            Chart2();
        }

       
    }
}
