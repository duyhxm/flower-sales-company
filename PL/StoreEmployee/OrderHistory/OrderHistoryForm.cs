using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;
using DTO.SalesOrder;
using DTO.Enum.SalesOrder;
using PL.StoreEmployee.OrderHistory;
using System.Diagnostics;

namespace PL.StoreEmployee
{
    public partial class OrderHistoryForm : Form
    {
        private static OrderHistoryForm? _instance;
        private static readonly object _lock = new object();

        //Khai báo các service
        private StoreService _storeService = new StoreService();
        private SalesOrderService _salesOrderService = new SalesOrderService();

        private BindingList<SalesOrderDTO> _salesOrders;

        private List<ShippingInformationDTO> _shippingInformation = new List<ShippingInformationDTO>();

        private OrderHistoryForm()
        {
            InitializeComponent();

            //Setup cho danh sách đơn hàng
            SetupOrderHistoryDgv();
        }

      
        private void SetupOrderHistoryDgv()
        {
            dgvOrderHistory.Columns[0].DataPropertyName = "SalesOrderId";
            dgvOrderHistory.Columns[1].DataPropertyName = "OrderType";
            dgvOrderHistory.Columns[2].DataPropertyName = "OrderStatus";
            dgvOrderHistory.Columns[3].DataPropertyName = "PurchaseMethod";
            dgvOrderHistory.Columns[4].DataPropertyName = "FinalPrice";

            dgvOrderHistory.AutoGenerateColumns = false;
        }

        public static void Initialize()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    try
                    {
                        _instance = new OrderHistoryForm();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }

        public static OrderHistoryForm Instance
        {
            get
            {
                if (_instance == null)
                {
                    throw new InvalidOperationException("OrderHistoryForm is not initialized. Call Initialize() first.");
                }

                return _instance;
            }
        }

        public async Task LoadSalesOrders(string storeId, DateTimeOffset date)
        {
            List<SalesOrderDTO> salesOrders = await _storeService.GetSalesOrdersByStoreAsync(storeId, date);

            if (salesOrders == null)
            {
                MessageBox.Show("Cửa hàng hiện tại chưa có đơn hàng nào trong ngày hoặc đơn hàng chưa hoàn tất", "Thông báo");
                return;
            }

            _salesOrders = new BindingList<SalesOrderDTO>(salesOrders);

            dgvOrderHistory.DataSource = _salesOrders;

            await InitializeShippingValues();

            foreach (DataGridViewRow row in dgvOrderHistory.Rows)
            {
                var orderType = row.Cells["ColOrderType"].Value.ToString();
                var hasShipping = row.Cells["ColShip"].Value != null && (bool)row.Cells["ColShip"].Value;

                if (orderType == OrderType.ImmediateSalesOrder)
                {
                    row.Cells["ColSave"].ReadOnly = true;
                }
            }
        }

        private async Task InitializeShippingValues()
        {
            if (dgvOrderHistory.Rows.Count == 0)
            {
                return;
            }

            foreach (DataGridViewRow row in dgvOrderHistory.Rows)
            {
                ShippingInformationDTO? shipInfo = await _storeService.GetShippingInfoByOrderIdAsync(row.Cells[0].Value.ToString()!);

                if (shipInfo != null)
                {
                    row.Cells[8].Value = true;
                }
                else
                {
                    row.Cells[8].Value = false;
                }
            }
        }

        private SalesOrderDTO? FindSalesOrderById(string salesOrderId)
        {
            return _salesOrders.FirstOrDefault(order => order.SalesOrderId == salesOrderId);
        }

        private async void dgvOrderHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == dgvOrderHistory.Columns["ColOrderDetails"].Index) //Ấn xem chi tiết đơn hàng
                {
                    var salesOrder = _salesOrders[e.RowIndex];
                    var form = new ExtraOrderInfoForm(salesOrder);
                    form.ShowDialog();

                    if (form.DialogResult == DialogResult.OK)
                    {
                        form.Close();
                    }
                }

                if (e.ColumnIndex == 6) //Nhấn lưu lại thông tin đã chỉnh sửa
                {
                    try
                    {
                        DataGridViewRow thisRow = dgvOrderHistory.Rows[e.RowIndex];
                        SalesOrderDTO salesOrder = FindSalesOrderById(thisRow.Cells["ColSalesOrderId"].Value.ToString()!)!;
                        string orderStatus = salesOrder.OrderStatus!;
                        string id = salesOrder.SalesOrderId;
                        

                        if (thisRow.Cells["ColShip"].Value != null && (bool)thisRow.Cells["ColShip"].Value == true && thisRow.Cells["ColOrderType"].Value.ToString() == OrderType.ImmediateSalesOrder && thisRow.Cells["ColOrderStatus"].Value.ToString() != orderStatus)
                        {
                            string editedStatus = thisRow.Cells["ColOrderStatus"].Value.ToString()!;
                            //Xử lý đơn hàng lấy ngay có ship
                            if (editedStatus == OrderStatus.Cancelled)
                            {
                                DialogResult result = MessageBox.Show($"Xác nhận cập nhật trạng thái của đơn hàng {id} thành '{OrderStatus.Cancelled}'", "Xác nhận", MessageBoxButtons.YesNo);

                                if (result == DialogResult.Yes)
                                {
                                    await _salesOrderService.UpdateOrderStatusAsync(id, OrderStatus.Cancelled);
                                    //Đối với trường hợp này, do khi tạo đơn hàng thì trạng thái là thành công, nên nếu huỷ thì sẽ cần cập nhật kho lại. Việc này đã có trigger xử lý
                                    MessageBox.Show("Đã cập nhật thành công", "Thông báo");
                                }
                                return;
                            }

                            if (editedStatus == OrderStatus.Success)
                            {
                                DialogResult result = MessageBox.Show($"Xác nhận cập nhật trạng thái của đơn hàng {id} thành '{OrderStatus.Success}'", "Xác nhận", MessageBoxButtons.YesNo);

                                if (result == DialogResult.Yes)
                                {
                                    await _salesOrderService.UpdateOrderStatusAsync(id, OrderStatus.Success);
                                    MessageBox.Show("Đã cập nhật thành công", "Thông báo");
                                }
                                return;
                            }
                        }

                        //Trường hợp trạng thái đơn hàng khác với trạng thái ban đầu và đơn hàng là đơn hàng đặt trước
                        if (thisRow.Cells["ColOrderStatus"].Value.ToString() != orderStatus && thisRow.Cells["ColOrderType"].Value.ToString() == OrderType.PreSalesOrder)
                        {
                            string editedStatus = thisRow.Cells["ColOrderStatus"].Value.ToString()!;
                            if (editedStatus == OrderStatus.Cancelled) //Trường hợp đơn hàng bị huỷ
                            {
                                //Xử lý đơn hàng đặt trước nhưng lại huỷ
                                DialogResult result = MessageBox.Show($"Xác nhận cập nhật trạng thái của đơn hàng {id} thành '{OrderStatus.Cancelled}'", "Xác nhận", MessageBoxButtons.YesNo);

                                if (result == DialogResult.Yes)
                                {
                                    await _salesOrderService.UpdateOrderStatusAsync(id, OrderStatus.Cancelled);
                                    //Vì là đơn hàng đặt trước, mình chỉ kiểm kho khi trạng thái hoàn thành, nghĩa là đã giao hành công đơn hành. Nhưng nếu đơn hàng bị huỷ thì là trước khi xuất hàng, nên không cần cập nhật
                                    MessageBox.Show("Đã cập nhật thành công", "Thông báo");
                                }
                                return;
                            }


                            if (editedStatus == OrderStatus.Success)
                            {
                                DialogResult result = MessageBox.Show($"Xác nhận cập nhật trạng thái của đơn hàng {id} thành '{OrderStatus.Success}'", "Xác nhận", MessageBoxButtons.YesNo);

                                if (result == DialogResult.Yes)
                                {
                                    await _salesOrderService.UpdateOrderStatusAsync(id, OrderStatus.Success);
                                    //Database sẽ tự động trừ số lượng product mà đơn hàng đã sử dụng bằng trigger
                                    MessageBox.Show("Đã cập nhật thành công", "Thông báo");
                                }
                                return;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                //Chỉnh sửa trạng thái đơn hàng
                if (e.ColumnIndex == 7)
                {
                    var orderType = dgvOrderHistory.Rows[e.RowIndex].Cells["ColOrderType"].Value.ToString();
                    var hasShipping = dgvOrderHistory.Rows[e.RowIndex].Cells["ColShip"].Value != null && (bool)dgvOrderHistory.Rows[e.RowIndex].Cells["ColShip"].Value;
                    var currentStatus = dgvOrderHistory.Rows[e.RowIndex].Cells["ColOrderStatus"].Value.ToString();

                    if (orderType == OrderType.ImmediateSalesOrder)
                    {
                        MessageBox.Show("Đơn hàng lấy ngay sẽ chỉ có một trạng thái là thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return; // Đơn hàng lấy ngay chỉ có một trạng thái là success
                    }

                    var form = new OrderStatusAdjustmentForm(orderType, hasShipping, currentStatus);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        var selectedStatus = form.SelectedStatus;
                        if (!string.IsNullOrEmpty(selectedStatus))
                        {
                            dgvOrderHistory.Rows[e.RowIndex].Cells["ColOrderStatus"].Value = selectedStatus;
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng chọn trạng thái hợp lệ.", "Lỗi");
                        }
                    }
                }
            }
        }

        public async Task AddSalesOrderToDataGridView(SalesOrderDTO salesOrder)
        {
            if (_salesOrders != null)
            {
                _salesOrders.Add(salesOrder);

                var newRow = dgvOrderHistory.Rows[dgvOrderHistory.Rows.Count - 1];

                ShippingInformationDTO? shipInfo = await _storeService.GetShippingInfoByOrderIdAsync(salesOrder.SalesOrderId);

                if (shipInfo != null)
                {
                    newRow.Cells[8].Value = true;
                }
                else
                {
                    newRow.Cells[8].Value = false;
                }
            }
            else
            {
                MessageBox.Show("Danh sách đơn hàng chưa được khởi tạo", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
