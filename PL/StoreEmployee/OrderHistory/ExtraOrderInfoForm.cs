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
        private readonly SalesOrderDTO _salesOrder;
        private readonly StoreService _storeService;
        private readonly SalesOrderService _salesOrderService = new SalesOrderService();
        private ShippingInformationDTO? _shippingInformation;

        public ExtraOrderInfoForm(SalesOrderDTO salesOrder, StoreService storeService)
        {
            InitializeComponent();
            _salesOrder = salesOrder;
            _storeService = storeService;
            LoadOrderDetails();
            DisplayShippingInfo(false);
        }

        private async void LoadOrderDetails()
        {
            txtBxCreatedDateTime.Text = _salesOrder.CreatedDateTime?.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            // Load detailed sales order data into dgvDetailedOrder
            dgvDetailedOrder.Rows.Clear();
            foreach (var detail in _salesOrder.DetailedSalesOrders)
            {
                dgvDetailedOrder.Rows.Add(detail.ProductId, detail.Quantity);
            }

            _shippingInformation = await _storeService.GetShippingInfoByOrderIdAsync(_salesOrder.SalesOrderId);
            if (_shippingInformation != null)
            {
                DisplayShippingInfo(true);
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
            var result = MessageBox.Show("Are you sure you want to cancel?", "Confirmation", MessageBoxButtons.YesNo);
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

            txtBxShippingCompany.Visible = value;
            dtpOrderDateTime.Visible = value;
            txtBxDeliveryTime.Visible = value;
            lblCustomerName.Visible = value;
            txtBxCustomerPhoneNumber.Visible = value;
            txtBxAddress.Visible = value;
            txtBxDistrict.Visible = value;
            txtBxCity.Visible = value;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Xác nhận lưu thông tin vận chuyển và trạng thái đơn hàng thành công", "Thông báo", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                if (_shippingInformation != null)
                {
                    _shippingInformation.ShippingCompanyId = txtBxShippingCompany.Text;
                    _shippingInformation.OrderDateTime = ConvertStringToDateTimeOffset(dtpOrderDateTime.Text, "dd/MM/yyyy HH:mm");
                    _shippingInformation.ShippingAddress = txtBxAddress.Text;
                    _shippingInformation.District = txtBxDistrict.Text;
                    _shippingInformation.CityProvince = txtBxCity.Text;

                    await _salesOrderService.UpdateShippingInfoAsync(_shippingInformation);
                    await _salesOrderService.UpdateOrderStatusAsync(_shippingInformation.SalesOrderId, OrderStatus.Success);

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
    }
}
