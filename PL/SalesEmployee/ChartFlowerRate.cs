using System;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using DL.Models;

namespace PL.SalesEmployee
{
    public partial class ChartFlowerRate : System.Windows.Forms.Form
    {
        private string flowerId { get; set; }

        public ChartFlowerRate(string flowerId)
        {
            InitializeComponent();

            this.flowerId = flowerId;
            LoadDataAndDisplayChart();
            lblFlowerId.Text = $"FlowerID: {flowerId}";
        }

        private void LoadDataAndDisplayChart()
        {
            using (var context = new FlowerSalesCompanyDbContext())
            {
                // Get the current date
                DateTime currentDate = DateTime.Now;

                // Calculate the range for 6 months before and 6 months after the current date
                DateTime startDate = currentDate.AddMonths(-6); // 6 months before current date
                DateTime endDate = currentDate.AddMonths(6); // 6 months after current date

                // Get the flower sales target history for the given flowerId
                var historyData = (from history in context.FlowerSalesTargetHistories
                                   join target in context.FlowerSalesTargets
                                   on history.TargetId equals target.TargetId
                                   where history.FlowerId == flowerId // Filter by flowerId

                                   select new
                                   {
                                       ApplyMonth = target.ApplyMonth,
                                       ApplyYear = target.ApplyYear,
                                       ProfitRate = history.ProfitRate // ProfitRate is decimal
                                   })
                                   .AsEnumerable() // Execute the query and bring data into memory
                                   .Where(data =>
                                       new DateTime(
                                          (int)data.ApplyYear.GetValueOrDefault(),
                                          (int)data.ApplyMonth.GetValueOrDefault(), 1
                                       ) >= startDate && new DateTime(
                                          (int)data.ApplyYear.GetValueOrDefault(),
                                          (int)data.ApplyMonth.GetValueOrDefault(), 1
                                       ) <= endDate) // Now filter in memory
                                   .OrderBy(data => data.ApplyYear)
                                   .ThenBy(data => data.ApplyMonth) // Ensure the data is ordered by date
                                   .ToList();

                if (historyData.Any())
                {
                    // Configure chart
                    chart1.Series.Clear();
                    var series = new Series
                    {
                        Name = "Profit Rate Flower",
                        IsVisibleInLegend = true,
                        ChartType = SeriesChartType.Line,
                        BorderWidth = 3
                    };
                    chart1.Series.Add(series);

                    // Add data points to the chart
                    foreach (var data in historyData)
                    {
                        // Safely get ApplyYear and ApplyMonth values, handling nulls
                        int year = (int)data.ApplyYear.GetValueOrDefault(); // Default to 0 if null
                        int month = (int)data.ApplyMonth.GetValueOrDefault(); // Default to 0 if null

                        // Ensure valid month and year before creating DateTime
                        if (year > 0 && month > 0 && month <= 12)
                        {
                            DateTime date = new DateTime(year, month, 1); // First day of the month

                            // Ensure that ProfitRate is treated as a decimal (or double)
                            series.Points.AddXY(date, Convert.ToDouble(data.ProfitRate)); // Convert ProfitRate to double
                        }
                    }

                    // Configure chart appearance
                    chart1.ChartAreas[0].AxisX.LabelStyle.Format = "MMM yyyy"; // Display month-year
                    chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Months;
                    chart1.ChartAreas[0].AxisX.Interval = 1; // Show points per month

                    chart1.ChartAreas[0].AxisY.Title = "Profit Rate Flower";
                    chart1.ChartAreas[0].AxisX.Title = "Time (Month/Year)";
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu cho flowerId này.");
                }
            }
        }
    }
}
