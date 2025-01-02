using DTO.Enum.SalesOrder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace PL.StoreEmployee.OrderHistory
{
    public partial class OrderStatusAdjustmentForm : Form
    {
        public string SelectedStatus { get; private set; }

        private string _orderType;
        private bool _hasShipping;
        private string _currentStatus;

        public OrderStatusAdjustmentForm(string orderType, bool hasShipping, string currentStatus)
        {
            InitializeComponent();
            _orderType = orderType;
            _hasShipping = hasShipping;
            _currentStatus = currentStatus;

            LoadComboBoxData();
        }

        private void LoadComboBoxData()
        {
            List<string> statuses = new List<string>();

            if (_hasShipping || _orderType == OrderType.PreSalesOrder)
            {
                statuses.Add(OrderStatus.Confirmed);
                statuses.Add(OrderStatus.Success);
                statuses.Add(OrderStatus.Cancelled);
            }

            statuses.Remove(_currentStatus); // Loại bỏ trạng thái hiện tại

            cmbBxOrderStatus.DataSource = statuses;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (cmbBxOrderStatus.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn trạng thái hợp lệ.", "Lỗi");
                return;
            }

            SelectedStatus = cmbBxOrderStatus.SelectedItem.ToString()!;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
