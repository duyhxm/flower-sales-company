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

namespace PL.StoreEmployee
{
    public partial class ShippingInformationForm : Form
    {
        private ErrorProvider _errorProvider = new ErrorProvider();
        private SalesOrderForm _salesOrderForm;
        private InvoiceForm _invoiceForm;

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
                return;
            }
            else
            {
                e.Cancel = false;
                _errorProvider.SetError(txtBxShippingCost, null);
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
                    return;
                }
            }
            else
            {
                if (!ValidateImmediateOrderDeliveryDatetime())
                {
                    e.Cancel = true;
                    _errorProvider.SetError(dtpDeliveryDatetime, "Đơn hàng lấy ngay phải được giao trong ngày và giờ giao hàng phải từ 05:00 - 20:00");
                    //MessageBox.Show("Đơn hàng lấy ngay phải được giao trong ngày và giờ giao hàng phải từ 05:00 - 20:00", "Thông báo");
                    //e.Cancel = false;
                    //return;
                    return;
                }
            }
        }

        private void txtBxConsigneePhoneNumber_Validating(object sender, CancelEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtBxConsigneePhoneNumber.Text, @"^0\d{9,10}$"))
            {
                e.Cancel = true;
                _errorProvider.SetError(txtBxConsigneePhoneNumber, "Phone number must start with 0 and contain 10-11 digits.");
            }
            else
            {
                e.Cancel = false;
                _errorProvider.SetError(txtBxConsigneePhoneNumber, null);
            }
        }

        private void txtBxConsigneeName_Validating(object sender, CancelEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtBxConsigneeName.Text, @"^[a-zA-Z\s]+$"))
            {
                e.Cancel = true;
                _errorProvider.SetError(txtBxConsigneeName, "Consignee name must contain only letters.");
            }
            else
            {
                e.Cancel = false;
                _errorProvider.SetError(txtBxConsigneeName, null);
            }
        }

        public void ClearShippingInformation()
        {
            txtBxShippingId.Clear();
            txtBxShippingCompanyId.Clear();
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
    }
}
