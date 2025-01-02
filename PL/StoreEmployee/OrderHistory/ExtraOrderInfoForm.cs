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
        private List<ShippingCompanyDTO> _shippingCompanyList = new List<ShippingCompanyDTO>();

        public ExtraOrderInfoForm(SalesOrderDTO salesOrder, StoreService storeService)
        {
            InitializeComponent();
            _salesOrder = salesOrder;
            _storeService = storeService;
            LoadOrderDetails();
            DisplayShippingInfo(false);
            btnCancel.Visible = false;
            btnSave.Visible = false;
            btnOk.Visible = true;
        }

        private async void ExtraOrderInfoForm_Load(object sender, EventArgs e)
        {
            
            
        }

        private async Task LoadShippingCompaniesAsync()
        {
            try
            {
                _shippingCompanyList = await _salesOrderService.LoadShippingCompaniesAsync();

                foreach (var sc in _shippingCompanyList)
                {
                    string name = sc.ShippingCompanyName!;

                    cmbBxShippingCompany.Items.Add(name);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async Task LoadOrderDetails()
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
                await LoadShippingCompaniesAsync();
                cmbBxShippingCompany.SelectedIndex = 0;
                btnCancel.Visible = true;
                btnSave.Visible = true;
                btnOk.Visible = false;
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
                    //Lấy ra ShippingCompanyId từ ComboBox
                    _shippingInformation.ShippingCompanyId = _shippingCompanyList.Where(sc => sc.ShippingCompanyName == cmbBxShippingCompany.Text)
                        .Select(sc => sc.ShippingCompanyId).FirstOrDefault();

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

                    //Update trạng thái đơn hàng
                    //await _salesOrderService.UpdateOrderStatusAsync(_shippingInformation.SalesOrderId, OrderStatus.Success);

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

        
    }
}
