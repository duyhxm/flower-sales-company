using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO.SalesOrder;

namespace PL.StoreEmployee
{
    public partial class InvoiceForm : Form
    {
        private SalesOrderForm _salesOrderForm;
        private ShippingInformationForm _shippingInformationForm;

        public InvoiceForm(SalesOrderForm salesOrderForm, ShippingInformationForm shippingInformationForm)
        {
            InitializeComponent();

            _salesOrderForm = salesOrderForm;
            _shippingInformationForm = shippingInformationForm;

            SetupOrderInfoDgv();
            LoadInvoiceData();
        }

        private void LoadInvoiceData()
        {
            txtBxCustomerName.Text = _salesOrderForm.GetCustomerName();
            txtBxCustomerId.Text = _salesOrderForm.GetCustomerId();

            DataTable orderInfo = _salesOrderForm.GetOrderInformation();
            dgvOrderInfo.DataSource = orderInfo;

            txtBxBasePrice.Text = _salesOrderForm.GetBasePrice().ToString();
            txtBxCustomerDiscountValue.Text = _salesOrderForm.GetCustomerDiscount().ToString();
            txtBxOrderDiscountValue.Text = _salesOrderForm.GetOrderDiscount().ToString();
            txtBxShippingCost.Text = _shippingInformationForm.GetShippingCost().ToString();

            decimal finalPrice = _salesOrderForm.GetBasePrice() - _salesOrderForm.GetCustomerDiscount() - _salesOrderForm.GetOrderDiscount() + _shippingInformationForm.GetShippingCost();
            txtBxFinalPrice.Text = finalPrice.ToString();
        }

        private void SetupOrderInfoDgv()
        {
            dgvOrderInfo.Columns[0].DataPropertyName = "Order";
            dgvOrderInfo.Columns[1].DataPropertyName = "ProductId";
            dgvOrderInfo.Columns[2].DataPropertyName = "ProductName";
            dgvOrderInfo.Columns[3].DataPropertyName = "Quantity";
            dgvOrderInfo.Columns[4].DataPropertyName = "LinePrice";
            dgvOrderInfo.AutoGenerateColumns = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to cancel the invoice and shipping information?", "Confirm", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                _shippingInformationForm.ClearShippingInformation();
                this.Hide();
                _salesOrderForm.SetShippingInfoEntered(false);
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            _shippingInformationForm.Show();
        }

        private async void btnAddOrder_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Xác nhận thêm mới đơn hàng", "Thông báo", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                try
                {
                    ShippingInformationDTO shippingInfo = _shippingInformationForm.GetShippingInfo();
                    await _salesOrderForm.AddSalesOrderWithShippingInfo(shippingInfo);

                    MessageBox.Show("Đã thêm thành công đơn hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _shippingInformationForm.Close();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                return;
            }
        }
    }
}
