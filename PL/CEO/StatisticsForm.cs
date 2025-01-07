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
using System.Windows.Forms.DataVisualization.Charting;
using DTO;

namespace PL.CEO
{
    public partial class StatisticsForm : Form
    {
        private readonly CEOService _ceoService;
        public StatisticsForm()
        {
            _ceoService = new CEOService();
            InitializeComponent();
        }

        private void Chart1()
        {
            DateTime startDate = dtpStartDate.Value;
            DateTime endDate = dtpEndDate.Value;

            var (totalExpense, totalRevenue) = (0m, 0m);

            try
            {
                (totalExpense, totalRevenue) = _ceoService.GetExpenseAndRevenue(startDate, endDate);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            var total = totalExpense + totalRevenue;
            var expensePercentage = total == 0 ? 0 : (totalExpense / total) * 100;
            var revenuePercentage = total == 0 ? 0 : (totalRevenue / total) * 100;
            txt_chiPhi.Text = totalExpense.ToString("N0");
            txt_doanhThu.Text = totalRevenue.ToString("N0");

            chart1.Series.Clear();
            chart1.Titles.Clear();
            chart1.Legends.Clear();

            chart1.Titles.Add("Biểu đồ thống kê chi phí và doanh thu");

            var legend = chart1.Legends.Add("Chú thích");
            legend.Docking = Docking.Right;

            var series = chart1.Series.Add("Thống kê");
            series.ChartType = SeriesChartType.Pie;

            series.Points.AddXY("Chi phí", Math.Round(expensePercentage));
            series.Points[0].Label = $"{Math.Round(expensePercentage)}%";
            series.Points[0].LegendText = "Chi phí";

            series.Points.AddXY("Doanh thu", Math.Round(revenuePercentage));
            series.Points[1].Label = $"{Math.Round(revenuePercentage)}%";
            series.Points[1].LegendText = "Doanh thu";

            series.IsValueShownAsLabel = true;
        }
        private void Chart2()
        {
            DateTime startDate = dtpStartDate.Value;
            DateTime endDate = dtpEndDate.Value;

            List<RevenueDataDTO> revenueData = new();
            try
            {
                revenueData = _ceoService.GetRevenueData(startDate, endDate);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

            chart2.Series.Clear();
            chart2.Titles.Clear();
            chart2.Legends.Clear();

            chart2.Titles.Add("Biểu đồ doanh thu theo tháng");

            var series1 = chart2.Series.Add("Doanh thu kỳ vọng (Expected)");
            var series2 = chart2.Series.Add("Doanh thu thực tế (Net Flower)");
            var series3 = chart2.Series.Add("Doanh thu phụ liệu (Net Supp)");

            series1.ChartType = SeriesChartType.Line;
            series2.ChartType = SeriesChartType.Line;
            series3.ChartType = SeriesChartType.Line;

            foreach (var item in revenueData)
            {
                series1.Points.AddXY(item.Date, item.ExpectedFlowerRevenue);
                series2.Points.AddXY(item.Date, item.NetFlowerRevenue);
                series3.Points.AddXY(item.Date, item.NetSuppMaterialRevenue);
            }

            series1.Color = Color.Blue;
            series2.Color = Color.Green;
            series3.Color = Color.Orange;

            var legend = chart2.Legends.Add("Chú thích");
            legend.Docking = Docking.Top;
            chart2.ChartAreas[0].AxisX.Title = "Time (Month/Year)";
            chart2.ChartAreas[0].AxisX.LabelStyle.Format = "MM/yyyy";
            chart2.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Months;
            chart2.ChartAreas[0].AxisX.Interval = 1;
        }

        private void btnGetStatistics_Click(object sender, EventArgs e)
        {
            DateTime startDate = dtpStartDate.Value;
            DateTime endDate = dtpEndDate.Value;
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
