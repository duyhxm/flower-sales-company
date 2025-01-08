using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BL.GeneralService;
using DTO.SalesOrder;

namespace PL.StoreEmployee
{
    public partial class ShippingInformationForm : Form
    {
        private ErrorProvider _errorProvider = new ErrorProvider();
        private SalesOrderForm _salesOrderForm;
        private InvoiceForm? _invoiceForm;

        public ShippingInformationForm(SalesOrderForm salesOrderForm)
        {
            InitializeComponent();
            _salesOrderForm = salesOrderForm;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                _salesOrderForm.SetShippingInfoEntered(true);
                this.Hide();
                _invoiceForm = new InvoiceForm(_salesOrderForm, this);
                _invoiceForm.ShowDialog();
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            _salesOrderForm.SetShippingInfoEntered(true);
            this.Hide();
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn huỷ thông tin giao hàng?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                ClearShippingInformation();
                this.Hide();
            }
        }

        private void txtBxShippingCost_Validating(object sender, CancelEventArgs e)
        {
            if (!decimal.TryParse(txtBxShippingCost.Text, out _))
            {
                e.Cancel = true;
                MessageBox.Show("Chi phí vận chuyển phải là một số", "Thông báo");
                txtBxShippingCost.Focus();
                return;
            }
        }

        private void dtpDeliveryDatetime_Validating(object sender, CancelEventArgs e)
        {
            if (_salesOrderForm.IsPreorder)
            {
                if (!ValidatePreorderDeliveryDatetime())
                {
                    MessageBox.Show("Đơn hàng đặt trước phải lớn hơn ngày hiện tại và không được vượt quá 7 ngày. Giờ giao hàng phải từ 05:00 - 20:00", "Thông báo");
                    e.Cancel = true;
                    dtpDeliveryDatetime.Focus();
                    return;
                }
            }
            else
            {
                if (!ValidateImmediateOrderDeliveryDatetime())
                {
                    e.Cancel = true;
                    MessageBox.Show("Đơn hàng lấy ngay phải được giao trong ngày và giờ giao hàng phải từ 05:00 - 20:00", "Thông báo");
                    dtpDeliveryDatetime.Focus();
                    return;
                }
            }
        }

        private void txtBxConsigneePhoneNumber_Validating(object sender, CancelEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtBxConsigneePhoneNumber.Text, @"^0\d{9,10}$"))
            {
                e.Cancel = true;
                MessageBox.Show("Số điện thoại phải bắt đầu bằng 0 và từ 10-11 chữ số", "Thông báo");
                txtBxConsigneePhoneNumber.Focus();
            }
        }

        private void txtBxConsigneeName_Validating(object sender, CancelEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtBxConsigneeName.Text, @"^[\p{L}\s]+$"))
            {
                e.Cancel = true;
                MessageBox.Show("Tên người nhậnc chỉ được chứa ký tự và khoảng trắng", "Thông báo");
                txtBxConsigneeName.Focus();
            }
        }

        public void ClearShippingInformation()
        {
            txtBxConsigneeName.Clear();
            txtBxConsigneePhoneNumber.Clear();
            dtpDeliveryDatetime.Value = DateTime.Now;
            txtBxShippingAddress.Clear();
            cmbBxDistrict.Text = string.Empty;
            cmbBxCity.Text = string.Empty;
            txtBxShippingCost.Clear();
        }

        public decimal GetShippingCost()
        {
            return decimal.Parse(txtBxShippingCost.Text);
        }

        private bool ValidatePreorderDeliveryDatetime()
        {
            DateTime deliveryDatetime = dtpDeliveryDatetime.Value;
            if (deliveryDatetime.Date > DateTime.Now.Date && deliveryDatetime.Date <= DateTime.Now.Date.AddDays(7))
            {
                if (deliveryDatetime.TimeOfDay >= TimeSpan.FromHours(5) && deliveryDatetime.TimeOfDay <= TimeSpan.FromHours(20))
                {
                    return true;
                }
            }
            return false;
        }

        private bool ValidateImmediateOrderDeliveryDatetime()
        {
            DateTime deliveryDatetime = dtpDeliveryDatetime.Value;
            if (deliveryDatetime.Date == DateTime.Now.Date)
            {
                if (deliveryDatetime.TimeOfDay >= TimeSpan.FromHours(5) && deliveryDatetime.TimeOfDay <= TimeSpan.FromHours(20))
                {
                    return true;
                }
            }
            return false;
        }

        public ShippingInformationDTO GetShippingInfo()
        {
            return new ShippingInformationDTO()
            {
                ConsigneeName = txtBxConsigneeName.Text,
                ConsigneePhoneNumber = txtBxConsigneePhoneNumber.Text,
                DeliveryDateTime = ConvertStringToDateTimeOffset(dtpDeliveryDatetime.Text, "dd/MM/yyyy HH:mm"),
                ShippingAddress = txtBxShippingAddress.Text,
                District = cmbBxDistrict.Text,
                CityProvince = cmbBxCity.Text,
                ShippingCost = Convert.ToDecimal(txtBxShippingCost.Text),
            };
        }
    }
}
