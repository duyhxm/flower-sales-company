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
using System.Windows.Forms.DataVisualization.Charting;
using DTO.Customer;
using BL;
using System.Diagnostics;

namespace PL.SalesEmployee
{
    public partial class CustomerForm : System.Windows.Forms.Form
    {
        //Cấu hình khởi tạo đối tượng
        private static CustomerForm? _instance;
        private static readonly object _lock = new object();

        private CustomerService _customerService;
        private CustomerForm()
        {
            InitializeComponent();
            _customerService = new CustomerService();
        }

        public static void Initialize()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    try
                    {
                        _instance = new CustomerForm();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }
        public static CustomerForm Instance
        {
            get
            {
                if (_instance == null)
                {
                    throw new InvalidOperationException("CustomerForm chưa được khởi tạo. Gọi Initialize() trước tiên.");
                }
                return _instance;
            }
        }

        //Load rank
        private void LoadCustomerRank()
        {
            //using (var db = new FlowerSalesCompanyDbContext())
            //{
            //    // Truy vấn danh sách các Rank
            //    var values = db.CustomerRanks
            //                    .Select(r => new
            //                    {
            //                        r.CustomerRankId,
            //                        r.RankName
            //                    })
            //                    .ToList();

            //    // Gán dữ liệu vào ComboBox
            //    cbbRank.DataSource = values;
            //    cbbRank.DisplayMember = "RankName";
            //    cbbRank.ValueMember = "CustomerRankId";
            //    cbbRank.SelectedIndex = -1;

            //}

            try
            {
                List<CustomerRankDTO> customerRanks = _customerService.GetAllCustomerRanks();

                cbbRank.DataSource = customerRanks;
                cbbRank.DisplayMember = "RankName";
                cbbRank.ValueMember = "CustomerRankId";
                cbbRank.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã có lỗi xảy ra trong quá trình lấy danh sách hạng khách hàng {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            LoadCustomerRank();
        }

        private void cbbRank_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbbRank.SelectedValue != null)
            {
                try
                {
                    using (var db = new FlowerSalesCompanyDbContext())
                    {
                        var selectedRankId = cbbRank.SelectedValue.ToString();
                        var customerData = db.CustomerRankHistories
                                             .Where(crh => crh.CustomerRankId == selectedRankId)
                                             .Join(
                                                 db.Customers,
                                                 crh => crh.CustomerId,
                                                 c => c.CustomerId,
                                                 (crh, c) => new
                                                 {
                                                     c.CustomerId,
                                                     NameCus = c.LastName + " " + c.MiddleName + " " + c.FirstName,
                                                     crh.TotalSpending
                                                 }
                                             )
                                              .GroupBy(crh => crh.CustomerId) // Nhóm theo CustomerId
                                                 .Select(g => new
                                                 {
                                                     g.Key, // CustomerId
                                                     NameCus = g.FirstOrDefault().NameCus, // Lấy tên khách hàng từ nhóm đầu tiên
                                                     TotalSpending = g.Sum(crh => crh.TotalSpending) // Cộng dồn TotalSpending
                                                 })
                                             .ToList();

                        var indexedCustomerData = customerData.Select((item, index) => new
                        {
                            STT = index + 1,
                            item.Key,
                            item.NameCus,
                            TotalSpending = Convert.ToDecimal(item.TotalSpending).ToString("N0")
                        }).ToList();

                        dgvCustomerData.DataSource = indexedCustomerData;
                        cbbTop.SelectedIndex = -1;
                    }
                }
                catch (Exception ex)
                {
                    return;
                }
            }
        }

        private void cbbTop_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbbTop.Text != null)
            {
                try
                {
                    using (var db = new FlowerSalesCompanyDbContext())
                    {
                        var customerData = db.CustomerRankHistories
                                             .Join(
                                                 db.Customers,
                                                 crh => crh.CustomerId,
                                                 c => c.CustomerId,
                                                 (crh, c) => new
                                                 {
                                                     c.CustomerId,
                                                     NameCus = c.LastName + " " + c.MiddleName + " " + c.FirstName,
                                                     crh.TotalSpending
                                                 }
                                             )
                                             .OrderByDescending(crh => crh.TotalSpending)
                                              .GroupBy(crh => crh.CustomerId) // Nhóm theo CustomerId
                                                 .Select(g => new
                                                 {
                                                     g.Key, // CustomerId
                                                     NameCus = g.FirstOrDefault().NameCus, // Lấy tên khách hàng từ nhóm đầu tiên
                                                     TotalSpending = g.Sum(crh => crh.TotalSpending) // Cộng dồn TotalSpending
                                                 })
                                             .Take(Convert.ToInt32(cbbTop.Text))
                                             .ToList();

                        var indexedCustomerData = customerData.Select((item, index) => new
                        {
                            STT = index + 1,
                            item.Key,
                            item.NameCus,
                            TotalSpending = Convert.ToDecimal(item.TotalSpending).ToString("N0")
                        }).ToList();

                        dgvCustomerData.DataSource = indexedCustomerData;
                        cbbRank.SelectedIndex = -1;
                    }
                }
                catch (Exception ex)
                {
                    return;
                }
            }

        }
        private void LoadCusForDate()
        {
            DateTime startDate = new DateTime(dtpStartDate.Value.Year, dtpStartDate.Value.Month, 1);
            DateTime endDate = new DateTime(dtpEndDate.Value.Year, dtpEndDate.Value.Month, 1);
            DateTime currentDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            if (startDate < endDate && endDate <= currentDate)
            {
                try
                {
                    //using (var db = new FlowerSalesCompanyDbContext())
                    //{
                    //    var startDate = dtpStartDate.Value;
                    //    var endDate = dtpEndDate.Value;
                    //    var customerData = db.CustomerRankHistories
                    //                         .Join(
                    //                             db.Customers,
                    //                             crh => crh.CustomerId,
                    //                             c => c.CustomerId,
                    //                             (crh, c) => new
                    //                             {
                    //                                 c.CustomerId,
                    //                                 NameCus = c.LastName + " " + c.MiddleName + " " + c.FirstName,
                    //                                 crh.TotalSpending,
                    //                                 crh.RankingCycleId
                    //                             }
                    //                         )
                    //                         .Join(
                    //                             db.RankingCycles,
                    //                             crh => crh.RankingCycleId,
                    //                             rc => rc.RankingCycleId,
                    //                             (crh, rc) => new
                    //                             {
                    //                                 crh.CustomerId,
                    //                                 crh.NameCus,
                    //                                 crh.TotalSpending,
                    //                                 rc.StartDateTime,
                    //                                 rc.EndDateTime
                    //                             }
                    //                         )
                    //                         .Where(rc => rc.StartDateTime >= startDate && rc.EndDateTime <= endDate)
                    //                          .GroupBy(crh => crh.CustomerId) // Nhóm theo CustomerId
                    //                             .Select(g => new
                    //                             {
                    //                                 g.Key, // CustomerId
                    //                                 NameCus = g.FirstOrDefault().NameCus, // Lấy tên khách hàng từ nhóm đầu tiên
                    //                                 TotalSpending = g.Sum(crh => crh.TotalSpending) // Cộng dồn TotalSpending
                    //                             })
                    //                         .OrderByDescending(crh => crh.TotalSpending)
                    //                         .ToList();

                    //    var indexedCustomerData = customerData.Select((item, index) => new
                    //    {
                    //        STT = index + 1,
                    //        item.Key,
                    //        item.NameCus,
                    //        TotalSpending = Convert.ToDouble(item.TotalSpending).ToString("N0")
                    //    }).ToList();

                    //    dgvCustomerData.DataSource = indexedCustomerData;
                    //    cbbRank.SelectedIndex = -1;
                    //    cbbTop.SelectedIndex = -1;
                    //}
                }
                catch (Exception ex)
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show("Ngày bắt đầu phải bé hơn ngày kết thúc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void UpdateChart()
        {
            var startDate = dtpStartDate.Value;
            var endDate = dtpEndDate.Value;

            try
            {
                using (var db = new FlowerSalesCompanyDbContext())
                {
                    var salesData = db.SalesOrders
                                      .Where(so => so.CreatedDateTime >= startDate && so.CreatedDateTime <= endDate)
                                      .AsEnumerable()
                                      .GroupBy(so => new
                                      {
                                          YearMonth = new DateTime(so.CreatedDateTime.Value.Year, so.CreatedDateTime.Value.Month, 1)
                                      })
                                      .Select(g => new
                                      {
                                          g.Key.YearMonth,
                                          TotalRevenue = g.Sum(so => so.FinalPrice),
                                          CustomerCount = g.Select(so => so.CustomerId).Distinct().Count(),
                                      })
                                      .OrderBy(g => g.YearMonth)
                                      .ToList();

                    chart1.Series.Clear();

                    var customerSeries = new Series("Number of Customers")
                    {
                        ChartType = SeriesChartType.Column,
                        IsVisibleInLegend = true,
                        Color = System.Drawing.Color.Green
                    };

                    var revenueSeries = new Series("Average Revenue")
                    {
                        ChartType = SeriesChartType.Line,
                        IsVisibleInLegend = true,
                        BorderWidth = 3,
                        Color = System.Drawing.Color.Blue,
                        YAxisType = AxisType.Secondary
                    };

                    foreach (var monthData in salesData)
                    {
                        double avgRevenue = Convert.ToDouble(monthData.TotalRevenue) / Convert.ToDouble(monthData.CustomerCount);

                        customerSeries.Points.Add(new DataPoint
                        {
                            XValue = monthData.YearMonth.ToOADate(),
                            YValues = new double[] { monthData.CustomerCount }
                        });

                        revenueSeries.Points.Add(new DataPoint
                        {
                            XValue = monthData.YearMonth.ToOADate(),
                            YValues = new double[] { avgRevenue }
                        });

                        revenueSeries.Points.Last().Label = avgRevenue.ToString("N0");
                    }

                    chart1.Series.Add(customerSeries);
                    chart1.Series.Add(revenueSeries);

                    chart1.ChartAreas[0].AxisX.LabelStyle.Format = "MMM yyyy"; // Use "MMM yyyy" instead of "MM/yyyy"
                    chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Months;  // Interval by month
                    chart1.ChartAreas[0].AxisX.Interval = 1; // Set interval to 1 month for the X-axis

                    chart1.ChartAreas[0].AxisY.Title = "Number of Customers";
                    chart1.ChartAreas[0].AxisY2.Title = "Average Revenue";


                    chart1.ChartAreas[0].AxisY2.LabelStyle.Format = "N0";

                    chart1.Legends.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void btnShow_Click(object sender, EventArgs e)
        {
            LoadCusForDate();
            UpdateChart();
        }
    }
}
