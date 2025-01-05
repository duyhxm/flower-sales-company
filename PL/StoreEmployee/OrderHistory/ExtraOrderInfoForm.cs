using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;
using DTO.Enum.SalesOrder;
using DTO.SalesOrder;
using static BL.GeneralService;

namespace PL.StoreEmployee.OrderHistory
{
    public partial class ExtraOrderInfoForm : Form
    {
        //Khai báo các service
        private StoreService _storeService = new StoreService();

        private SalesOrderService _salesOrderService = new SalesOrderService();

        private ProductService _productService = new ProductService();

        //Khai báo các biến sử dụng
        private SalesOrderDTO _salesOrder;

        private ShippingInformationDTO? _shippingInformation;

        private List<ShippingCompanyDTO> _shippingCompanyList = new List<ShippingCompanyDTO>();

        public ExtraOrderInfoForm(SalesOrderDTO salesOrder)
        {
            InitializeComponent();

            _salesOrder = salesOrder;

            DisplayShippingInfo(false);

            SetupDetailedOrderDgv();

            btnOk.Location = new Point(515, 680);

            this.Size = new Size(700, 800);
        }

        private void SetupDetailedOrderDgv()
        {
            dgvDetailedOrder.AutoGenerateColumns = false;

            dgvDetailedOrder.Columns["ColProductId"].DataPropertyName = "ProductId";

            dgvDetailedOrder.Columns["ColProductName"].DataPropertyName = "ProductName";

            dgvDetailedOrder.Columns["ColUsedQuantity"].DataPropertyName = "Quantity";
        }

        private async void ExtraOrderInfoForm_Load(object sender, EventArgs e)
        {
            await LoadDetailedOrder(_salesOrder.SalesOrderId);
        }

        private async Task LoadShippingCompaniesAsync()
        {
            try
            {
                _shippingCompanyList = await _salesOrderService.LoadShippingCompaniesAsync();

                cmbBxShippingCompany.DataSource = _shippingCompanyList;
                cmbBxShippingCompany.SelectedIndex = 0;
                cmbBxShippingCompany.DisplayMember = "ShippingCompanyName";
                cmbBxShippingCompany.ValueMember = "ShippingCompanyId";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async Task LoadDetailedOrder(string salesOrderId)
        {
            //Hiển thị ngày tạo đơn hàng
            txtBxCreatedDateTime.Text = _salesOrder.CreatedDateTime?.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

            //Load chi tiết đơn hàng
            var detailedOrders = await _salesOrderService.GetDetailedSalesOrderByIdAsync(salesOrderId);
            var products = await _productService.GetAllProductsAsync();

            var transformedDetailedOrder = detailedOrders
                                            .Join(products,
                                                  i => i.ProductId,
                                                  pr => pr.ProductId,
                                                  (i, pr) => new
                                                  {
                                                      i.ProductId,
                                                      pr.ProductName,
                                                      i.Quantity
                                                  })
                                            .ToList();

            dgvDetailedOrder.DataSource = transformedDetailedOrder;

            _shippingInformation = await _storeService.GetShippingInfoByOrderIdAsync(_salesOrder.SalesOrderId);

            if (_shippingInformation != null)
            {
                this.Size = new Size(1600, 800);
                btnOk.Visible = false;
                DisplayShippingInfo(true);

                //Hiển thị thông tin shipping
                await LoadShippingCompaniesAsync();

                txtBxCustomerName.Text = _shippingInformation.ConsigneeName;

                txtBxCustomerPhoneNumber.Text = _shippingInformation.ConsigneePhoneNumber;

                txtBxDeliveryTime.Text = ConvertDateTimeOffsetToString(_shippingInformation.DeliveryDateTime, "dd/MM/yyyy HH:mm");

                txtBxAddress.Text = _shippingInformation.ShippingAddress;

                txtBxDistrict.Text = _shippingInformation.District;

                txtBxCity.Text = _shippingInformation.CityProvince;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc muốn đóng cửa sổ?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void DisplayShippingInfo(bool value)
        {
            lblShippingCompanyName.Visible = value;
            lblOrderTime.Visible = value;
            lblDeliveryTime.Visible = value;
            lblCustomerName.Visible = value;
            lblPhoneNumber.Visible = value;
            lblAddress.Visible = value;
            lblDistrict.Visible = value;
            lblCity.Visible = value;
            lblShippingInfo.Visible = value;

            dtpOrderDateTime.Visible = value;
            txtBxDeliveryTime.Visible = value;
            lblCustomerName.Visible = value;
            txtBxCustomerPhoneNumber.Visible = value;
            txtBxAddress.Visible = value;
            txtBxDistrict.Visible = value;
            txtBxCity.Visible = value;
            cmbBxShippingCompany.Visible = value;
            

            btnCancel.Visible = value;
            btnSave.Visible = value;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            DateTime orderDatetime = dtpOrderDateTime.Value;
            if (orderDatetime.Date != DateTime.Now.Date)
            {
                MessageBox.Show("Ngày đặt hàng phải là ngày hiện tại", "Thông báo");
                return;
            }

            DialogResult result = MessageBox.Show("Xác nhận lưu thông tin vận chuyển và trạng thái đơn hàng thành công", "Thông báo", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                if (_shippingInformation != null)
                {
                    //Lấy ra ShippingCompanyId từ ComboBox
                    _shippingInformation.ShippingCompanyId = cmbBxShippingCompany.SelectedValue!.ToString();

                    //Lấy OrderDateTime từ DateTimePicker
                    _shippingInformation.OrderDateTime = ConvertStringToDateTimeOffset(dtpOrderDateTime.Text, "dd/MM/yyyy HH:mm");

                    //Lấy thông tin địa chỉ
                    _shippingInformation.ShippingAddress = txtBxAddress.Text;

                    //Lấy thông tin quận
                    _shippingInformation.District = txtBxDistrict.Text;

                    //Lấy thông tin tỉnh, thành phố
                    _shippingInformation.CityProvince = txtBxCity.Text;

                    //Update thông tin vận chuyển
                    await _salesOrderService.UpdateShippingInfoAsync(_shippingInformation);

                    MessageBox.Show("Đã cập nhật thông tin vận chuyển thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                }
            }

        }

        private void dtpOrderDateTime_Validating(object sender, CancelEventArgs e)
        {
            DateTime orderDatetime = dtpOrderDateTime.Value;
            if (orderDatetime.Date != DateTime.Now.Date)
            {
                MessageBox.Show("Ngày đặt hàng phải là ngày hiện tại", "Thông báo");
                dtpOrderDateTime.Focus();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvDetailedOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvDetailedOrder.Columns["ColDetailedProduct"].Index)
            {
                string? productId = dgvDetailedOrder.Rows[e.RowIndex].Cells["ColProductId"].Value.ToString();

                if (productId != null)
                {
                    DetailedProductForm detailedProduct = new DetailedProductForm(productId);
                    detailedProduct.ShowDialog();
                }
            }
        }
    }
}
