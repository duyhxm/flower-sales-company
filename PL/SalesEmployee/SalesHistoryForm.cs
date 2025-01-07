using DL.Models;
using System;
using System.Data;
using System.Windows.Forms.DataVisualization.Charting;

namespace PL.SalesEmployee
{
    public partial class SalesHistoryForm : System.Windows.Forms.Form
    {
        //Cấu hình khởi tạo đối tượng
        private static SalesHistoryForm? _instance;
        private static readonly object _lock = new object();
        private SalesHistoryForm()
        {
            InitializeComponent();
        }

        public static void Initialize()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    try
                    {
                        _instance = new SalesHistoryForm();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }
        private void Chart1()
        {
            // Lấy ngày bắt đầu và ngày kết thúc từ DateTimePicker
            DateTime startDate = dateTimePickerStart.Value;
            DateTime endDate = dateTimePickerEnd.Value;

            try
            {
                using (var db = new FlowerSalesCompanyDbContext())
                {
                    // Lọc dữ liệu theo khoảng thời gian và lấy tất cả đơn hàng
                    var salesData = db.SalesOrders
                                      .Where(so => so.CreatedDateTime >= startDate && so.CreatedDateTime <= endDate)
                                      .AsEnumerable() // Chuyển về client để thực hiện các phép toán tiếp theo
                                      .GroupBy(so => new
                                      {
                                          YearMonth = new DateTime(so.CreatedDateTime.Value.Year, so.CreatedDateTime.Value.Month, 1) // Nhóm theo tháng
                                      })
                                      .Select(g => new
                                      {
                                          YearMonth = g.Key.YearMonth,
                                          CompletedOrders = g.Count(so => so.OrderStatus == "Hoàn thành"), // Đếm số đơn hàng hoàn thành
                                          FailedOrders = g.Count(so => so.OrderStatus == "Thất bại") // Đếm số đơn hàng thất bại
                                      })
                                      .OrderBy(g => g.YearMonth) // Sắp xếp theo tháng
                                      .ToList(); // Lấy dữ liệu dưới dạng list

                    // Xóa dữ liệu cũ trên biểu đồ
                    chart1.Series.Clear();

                    // Tạo series cho số đơn hàng hoàn thành
                    var completedSeries = new Series("Completed Orders")
                    {
                        ChartType = SeriesChartType.StackedColumn,
                        Color = Color.Green
                    };
                    chart1.Series.Add(completedSeries);

                    // Tạo series cho số đơn hàng thất bại
                    var failedSeries = new Series("Failed Orders")
                    {
                        ChartType = SeriesChartType.StackedColumn,
                        Color = Color.Red
                    };
                    chart1.Series.Add(failedSeries);

                    // Thêm dữ liệu vào biểu đồ
                    foreach (var monthData in salesData)
                    {
                        completedSeries.Points.AddXY(monthData.YearMonth, monthData.CompletedOrders);

                        // Thêm số đơn hàng thất bại vào cột của tháng
                        failedSeries.Points.AddXY(monthData.YearMonth, monthData.FailedOrders);
                    }

                    // Cài đặt các thuộc tính cho biểu đồ
                    chart1.ChartAreas[0].AxisX.Title = "Month";
                    chart1.ChartAreas[0].AxisY.Title = "Number of Orders";
                    chart1.ChartAreas[0].AxisX.LabelStyle.Format = "MM/yyyy"; // Định dạng tháng/năm
                    chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Months;
                    chart1.ChartAreas[0].AxisX.Interval = 1; // Hiển thị tất cả nhãn
                    chart1.ChartAreas[0].AxisX.IsLabelAutoFit = true;

                    // Cài đặt lại legend
                    chart1.Legends.Clear();
                    chart1.Legends.Add(new Legend());
                    chart1.Legends[0].Docking = Docking.Top;
                    chart1.Legends[0].Alignment = StringAlignment.Center;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Chart2()
        {
            using (var dbContext = new FlowerSalesCompanyDbContext())
            {

                DateTime startDate = dateTimePickerStart.Value;
                DateTime endDate = dateTimePickerEnd.Value;

                var query = dbContext.SalesOrders
                           .Where(order => order.CreatedDateTime.HasValue &&
                                           order.CreatedDateTime.Value.Date >= startDate.Date &&
                                           order.CreatedDateTime.Value.Date <= endDate.Date)
                           .GroupBy(order => new { Year = order.CreatedDateTime.Value.Year, Month = order.CreatedDateTime.Value.Month })
                           .Select(group => new
                           {
                               Year = group.Key.Year,
                               Month = group.Key.Month,
                               AverageRevenue = group.Average(order => order.FinalPrice),
                               DateMonthYear = new DateTime(group.Key.Year, group.Key.Month, 1) // Sử dụng DateTime thay vì chuỗi
                           })
                           .OrderBy(result => result.Year)
                           .ThenBy(result => result.Month)
                           .ToList();

                // Kiểm tra nếu có dữ liệu trả về
                if (query.Any())
                {
                    // Xóa dữ liệu cũ trên biểu đồ
                    chart2.Series.Clear();
                    var series = new Series
                    {
                        Name = "Average Revenue",
                        IsVisibleInLegend = true,
                        ChartType = SeriesChartType.Line,
                        BorderWidth = 3
                    };
                    // Thêm series vào biểu đồ
                    chart2.Series.Add(series);
                    // Thêm dữ liệu vào biểu đồ
                    foreach (var record in query)
                    {
                        series.Points.AddXY(record.DateMonthYear, Convert.ToDouble(record.AverageRevenue));
                    }

                    // Cài đặt các thuộc tính cho trục X và Y
                    chart2.ChartAreas[0].AxisY.Title = "Average Revenue";
                    chart2.ChartAreas[0].AxisX.Title = "Time (Month/Year)";
                    chart2.ChartAreas[0].AxisX.LabelStyle.Format = "MM/yyyy"; // Định dạng trục X tháng/năm
                    chart2.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Months; // Định dạng theo tháng
                    chart2.ChartAreas[0].AxisX.Interval = 1; // Hiển thị theo tháng


                }
                else
                {
                    MessageBox.Show("Không có dữ liệu cho khoảng thời gian này.");
                }
            }

        }

        private void LoadSalesOrders()
        {
            // Lấy giá trị ngày bắt đầu và kết thúc từ DateTimePicker
            DateTime startDate = dateTimePickerStart.Value.Date; // Ngày bắt đầu
            DateTime endDate = dateTimePickerEnd.Value.Date.AddDays(1).AddTicks(-1); // Ngày kết thúc (bao gồm hết ngày)

            using (var context = new FlowerSalesCompanyDbContext())
            {

                var query = context.SalesOrders
                                   .Where(order => order.CreatedDateTime.HasValue &&
                                                   order.CreatedDateTime.Value.Date >= startDate &&
                                                   order.CreatedDateTime.Value.Date <= endDate)
                                   .Select(order => new
                                   {
                                       order.SalesOrderId,
                                       order.CustomerId,
                                       order.StoreId,
                                       order.CreatedDateTime,
                                       order.OrderStatus,
                                       order.OrderType,
                                       order.PurchaseMethod,
                                       order.BasePrice,
                                       order.FinalPrice
                                   })
                                   .OrderBy(order => order.CreatedDateTime)
                                   .ToList();


                dgvSalesOrders.DataSource = query;
            }
        }

        private void btnGetStatistics_Click(object sender, EventArgs e)
        {
            Chart1();
            Chart2();
            LoadSalesOrders();
        }

        public static SalesHistoryForm Instance
        {
            get
            {
                if (_instance == null)
                {
                    throw new InvalidOperationException("SalesHistoryForm chưa được khởi tạo. Gọi Initialize() trước tiên.");
                }
                return _instance;
            }
        }
    }
}
