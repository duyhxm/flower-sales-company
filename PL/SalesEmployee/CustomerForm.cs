using System;
using System.Collections.Generic;
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
using DTO;
using DTO.SalesOrder;

namespace PL.SalesEmployee
{
    public partial class CustomerForm : Form
    {
        //Cấu hình khởi tạo đối tượng
        private static CustomerForm? _instance;
        private static readonly object _lock = new object();

        //Khai báo các service
        private CustomerService _customerService = new CustomerService();

        //Khai báo các biến sử dụng
        private List<CustomerRankHistoryDTO> _customerRankHistories = new();

        private CustomerForm()
        {
            InitializeComponent();

            SetupCustomerRankingDgv();
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

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            LoadCustomerRank();
            LoadQuaterComboBox();
            LoadYearComboBox(10);
        }

        private void SetupCustomerRankingDgv()
        {
            dgvCustomerRanking.Columns["ColOrder"].Width = 50;

            dgvCustomerRanking.Columns["ColCustomerId"].Width = 150;
            dgvCustomerRanking.Columns["ColCustomerId"].DataPropertyName = "CustomerId";

            dgvCustomerRanking.Columns["ColCustomerName"].Width = 300;
            dgvCustomerRanking.Columns["ColCustomerName"].DataPropertyName = "CustomerName";

            dgvCustomerRanking.Columns["ColTotalSpending"].Width = 170;
            dgvCustomerRanking.Columns["ColTotalSpending"].DataPropertyName = "TotalSpending";

            dgvCustomerRanking.Columns["ColRankName"].Width = 150;
            dgvCustomerRanking.Columns["ColRankName"].DataPropertyName = "RankName";
        }

        //Load quý
        private void LoadQuaterComboBox()
        {
            List<QuarterDTO> quarters = new List<QuarterDTO>()
            {
                new QuarterDTO { Id = 1, Name = "Q1", Months = new List<int> { 1, 2,3 } },

                new QuarterDTO { Id = 2, Name = "Q2", Months = new List<int> { 4, 5, 6 } },

                new QuarterDTO { Id = 3, Name = "Q3", Months = new List<int> { 7, 8, 9 } },

                new QuarterDTO { Id = 4, Name = "Q4", Months = new List<int> { 10, 11, 12 } }
            };

            cmbBxQuarter.DataSource = quarters;
            cmbBxQuarter.DisplayMember = "Name";
            cmbBxQuarter.ValueMember = "Id";
            cmbBxQuarter.SelectedIndex = -1;
        }

        private List<int> GetMonthsFromQuarterComboBox()
        {
            if (cmbBxQuarter.SelectedItem is QuarterDTO selectedQuarter)
            {
                return selectedQuarter.Months;
            }
            return new List<int>();
        }

        //Load năm
        private void LoadYearComboBox(int yearRange)
        {
            for (int year = DateTime.Now.Year - yearRange; year <= DateTime.Now.Year + yearRange; year++)
            {
                cmbBxYear.Items.Add(year);
            }
        }

        //Load hạng khách hàng
        private void LoadCustomerRank()
        {
            try
            {
                List<CustomerRankDTO> customerRanks = _customerService.GetAllCustomerRanks();

                customerRanks.Add(new CustomerRankDTO { CustomerRankId = "RC00", RankName = "All" });
                cmbBxRank.DataSource = customerRanks;
                cmbBxRank.DisplayMember = "RankName";
                cmbBxRank.ValueMember = "CustomerRankId";
                cmbBxRank.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã có lỗi xảy ra trong quá trình lấy danh sách hạng khách hàng {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnShow_Click(object sender, EventArgs e)
        {
            List<int> months = GetMonthsFromQuarterComboBox();
            

            //Kiểm tra tháng từ ComboBox chọn quý.
            if (months.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn quý trước khi thực hiện thống kê", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //Kiểm tra năm từ ComboBox chọn năm
            if (cmbBxYear.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng chọn năm trước khi thực hiện thống kê", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int year = Convert.ToInt32(cmbBxYear.Text);

            await LoadCustomerRankingDataByQuarter(months, year);
            await CreateStatisticsChart(months, year);
        }

        private async Task CreateStatisticsChart(List<int> months, int year)
        {
            try
            {
                List<SalesStatisticsDataDTO> salesData = await _customerService.GetSalesDataByQuarterAsync(months, year);

                // Kiểm tra xem Series đã tồn tại hay chưa
                Series customerSeries = chart1.Series.FindByName("Number of Customers");
                if (customerSeries == null)
                {
                    customerSeries = new Series("Number of Customers")
                    {
                        ChartType = SeriesChartType.Column,
                        IsVisibleInLegend = true,
                        Color = ColorTranslator.FromHtml("#F8766C")
                    };
                    chart1.Series.Add(customerSeries);
                }
                else
                {
                    customerSeries.Points.Clear(); //Nếu đã tồn tại, xóa các điểm cũ
                }

                Series revenueSeries = chart1.Series.FindByName("Average Revenue");
                if (revenueSeries == null)
                {
                    revenueSeries = new Series("Average Revenue")
                    {
                        ChartType = SeriesChartType.Line,
                        IsVisibleInLegend = true,
                        BorderWidth = 3,
                        Color = ColorTranslator.FromHtml("#00BFC3"),
                        YAxisType = AxisType.Secondary
                    };
                    chart1.Series.Add(revenueSeries);
                }
                else
                {
                    revenueSeries.Points.Clear(); // Nếu đã tồn tại, xóa các điểm cũ
                }

                // Thêm dữ liệu vào các series
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

                // Cập nhật lại các cài đặt biểu đồ
                chart1.ChartAreas[0].AxisX.LabelStyle.Format = "MMM yyyy"; // Sử dụng "MMM yyyy" thay vì "MM/yyyy"
                chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Months;  // Interval theo tháng
                chart1.ChartAreas[0].AxisX.Interval = 1; // Đặt khoảng cách là 1 tháng cho trục X

                chart1.ChartAreas[0].AxisY.Title = "Number of Customers";
                chart1.ChartAreas[0].AxisY.LabelStyle.Format = "N0"; // Hiển thị số nguyên
                chart1.ChartAreas[0].AxisY.Interval = 1; // Đặt khoảng cách là 1 đơn vị cho trục Y

                chart1.ChartAreas[0].AxisY2.Title = "Average Revenue";
                chart1.ChartAreas[0].AxisY2.LabelStyle.Format = "N0";

                chart1.Legends.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadCustomerRankingDataByQuarter(List<int> months, int year)
        {
            try
            {
                List<CustomerRankHistoryDTO> customerData = await _customerService.GetCustomerRankHistoryByQuarterAsync(months, year);

                if (customerData.Count == 0)
                {
                    MessageBox.Show($"Không có dữ liệu khách hàng tương ứng với quý và năm đang được chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                _customerRankHistories = customerData;
                FilterCustomerRankHistory();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi" ,MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilterCustomerRankHistory()
        {
            List<CustomerRankHistoryDTO> filteredCustomerData = _customerRankHistories;

            if (!string.IsNullOrEmpty(cmbBxRank.Text) && cmbBxRank.Text != "All")
            {
                filteredCustomerData = filteredCustomerData
                                        .Where(crh => crh.RankName == cmbBxRank.Text).ToList();
            }

            if (!string.IsNullOrEmpty(cmbBxTop.Text) && int.TryParse(cmbBxTop.Text, out int topCount) && topCount != -1)
            {
                filteredCustomerData = filteredCustomerData
                                        .OrderByDescending(crh => crh.TotalSpending)
                                        .Take(topCount)
                                        .ToList();
            }

            dgvCustomerRanking.DataSource = filteredCustomerData;
        }

        private void cmbBxRank_SelectedValueChanged(object sender, EventArgs e)
        {
            FilterCustomerRankHistory();
        }

        private void cmbBxTop_SelectedValueChanged(object sender, EventArgs e)
        {
            FilterCustomerRankHistory();
        }
    }
}
