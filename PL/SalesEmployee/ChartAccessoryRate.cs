using System;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using DL.Models;

namespace PL.SalesEmployee
{
    public partial class ChartAccessoryRate : System.Windows.Forms.Form
    {
        private string accessoryId { get; set; }

        public ChartAccessoryRate(string accessoryId)
        {
            InitializeComponent();
            this.accessoryId = accessoryId;
            LoadDataAndDisplayChart();
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
                // Convert to DateOnly
                DateOnly startDateOnly = DateOnly.FromDateTime(startDate);
                DateOnly endDateOnly = DateOnly.FromDateTime(endDate);
                var historyData = (from history in context.AccessoryProfitRateHistories
                                   join rate in context.AccessoryProfitRates
                                   on history.AccessoryProfitRateId equals rate.AccessoryProfitRateId
                                   where history.AccessoryId == accessoryId // Filter by accessoryId
                                   select new
                                   {
                                       StartDate = rate.StartDate,
                                       EndDate = rate.EndDate,
                                       ProfitRate = history.ProfitRate // ProfitRate is decimal
                                   })
                                     .AsEnumerable() // Execute the query and bring data into memory
                                   .Where(data =>
                                       // Convert nullable DateOnly to DateTime for comparison
                                       (data.StartDate.HasValue ? data.StartDate.Value.ToDateTime(new TimeOnly()) : DateTime.MinValue) >= startDateOnly.ToDateTime(new TimeOnly()) &&
                                       (data.EndDate.HasValue ? data.EndDate.Value.ToDateTime(new TimeOnly()) : DateTime.MaxValue) <= endDateOnly.ToDateTime(new TimeOnly())) // Compare using DateTime conversion
                                   .OrderBy(data => data.StartDate) // Ensure the data is ordered by StartDate
                                   .ThenBy(data => data.EndDate) // Order by EndDate as well
                                   .ToList();
                if (historyData.Any())
                {
                    // Configure chart
                    chart1.Series.Clear();
                    var series = new Series
                    {
                        Name = "Profit Rate Accessory",
                        IsVisibleInLegend = true,
                        ChartType = SeriesChartType.Line,
                        BorderWidth = 3
                    };
                    chart1.Series.Add(series);

                    // Add data points to the chart
                    foreach (var data in historyData)
                    {
                        // Ensure that StartDate and EndDate are valid
                        if (data.StartDate != null && data.EndDate != null)
                        {
                            DateTime? startDateValue = data.StartDate?.ToDateTime(new TimeOnly()); // Convert DateOnly? to DateTime?
                            DateTime? endDateValue = data.EndDate?.ToDateTime(new TimeOnly()); // Convert DateOnly? to DateTime?

                            // Ensure ProfitRate is treated as a decimal (or double)
                            series.Points.AddXY(startDateValue, Convert.ToDouble(data.ProfitRate)); // Convert ProfitRate to double
                            series.Points.AddXY(endDateValue, Convert.ToDouble(data.ProfitRate)); // Add another point for the end date
                        }
                    }

                    // Configure chart appearance
                    chart1.ChartAreas[0].AxisX.LabelStyle.Format = "MMM yyyy"; // Display month-year
                    chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Months;
                    chart1.ChartAreas[0].AxisX.Interval = 1; // Show points per month

                    chart1.ChartAreas[0].AxisY.Title = "Profit Rate Accessory";
                    chart1.ChartAreas[0].AxisX.Title = "Time (Month/Year)";
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu cho accessoryId này.");
                }
            }
        }
    }
}
