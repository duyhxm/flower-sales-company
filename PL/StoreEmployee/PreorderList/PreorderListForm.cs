using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO.Enum.SalesOrder;
using DTO.SalesOrder;
using BL;

namespace PL.StoreEmployee
{
    public partial class PreorderListForm : Form
    {
        private static PreorderListForm? _instance;
        private static readonly object _lock = new object();

        //khai báo các service
        private StoreService _storeService = new StoreService();
        private SalesOrderService _salesOrderService = new SalesOrderService();

        //khởi tạo các biến sử dụng
        private List<PreSalesOrderDTO> _preSalesOrders = new List<PreSalesOrderDTO>();
        private List<string> _orderStatus = new List<string>();

        private PreorderListForm()
        {
            InitializeComponent();

            //Set giá trị cho combobox
            DataGridViewComboBoxColumn? orderStatus = dgvPreorderList.Columns[3] as DataGridViewComboBoxColumn;

            _orderStatus.Add(OrderStatus.Confirmed);
            _orderStatus.Add(OrderStatus.Success);
            _orderStatus.Add(OrderStatus.Cancelled);

            if (orderStatus != null)
            {
                orderStatus.DataSource = _orderStatus;
            }

            SetupPreOrderListDgv();
            SetupProductListDgv();

        }

        public static void Initialize()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    try
                    {
                        _instance = new PreorderListForm();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }

        public static PreorderListForm Instance
        {
            get
            {
                if (_instance == null)
                {
                    throw new InvalidOperationException("PreoderListForm is not initialized. Call Initialize() first.");
                }

                return _instance;
            }
        }

        private void SetupPreOrderListDgv()
        {
            dgvPreorderList.Columns[0].DataPropertyName = "SalesOrderId";
            dgvPreorderList.Columns[0].DataPropertyName = "DeliveryDateTime";
            dgvPreorderList.Columns[0].DataPropertyName = "OrderStatus";
            dgvPreorderList.Columns[0].DataPropertyName = "FinalPrice";
        }

        private void SetupProductListDgv()
        {
            dgvProductList.Columns[0].DataPropertyName = "ProductId";
            dgvProductList.Columns[1].DataPropertyName = "ProductName";
            dgvProductList.Columns[2].DataPropertyName = "RepresentationName";
            dgvProductList.Columns[3].DataPropertyName = "Quantity";
            // Cột cuối cùng là cột hình ảnh, không cần thiết lập DataPropertyName
        }

        public async Task LoadPreorder(string storeId)
        {
            var preorders = await _storeService.GetPreSalesOrderByStoreAsync(storeId);

            dgvPreorderList.DataSource = preorders;
        }

        public void AddPreoder(SalesOrderDTO salesOrder, DateTimeOffset deliveryDateTime)
        {
            int rowIndex = dgvPreorderList.Rows.Add();

            DataGridViewRow newRow = dgvPreorderList.Rows[rowIndex];

            newRow.Cells[0].Value = salesOrder.SalesOrderId;
            newRow.Cells[1].Value = deliveryDateTime.ToString();
            newRow.Cells[2].Value = salesOrder.OrderStatus;
            newRow.Cells[3].Value = GeneralService.ConvertToCurrency(Convert.ToDecimal(salesOrder.FinalPrice));

        }

        private async void dgvPreorderList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            //lấy ra mã đơn hàng
            var salesOrderId = dgvPreorderList.Rows[e.RowIndex].Cells[0].Value.ToString();

            //Chọn hiển thị chi tiết đơn hàng đặt trước
            if (e.ColumnIndex == 4)
            {
                // Load các sản phẩm có trong đơn hàng
                var products = await _salesOrderService.GetProductsBySalesOrderIdAsync(salesOrderId!);
                dgvProductList.DataSource = products;
            }
            else if (e.ColumnIndex == 5)
            {
                // Check the value of the combo box in column 2
                var orderStatus = dgvPreorderList.Rows[e.RowIndex].Cells[2].Value.ToString();
                if (orderStatus == OrderStatus.Confirmed)
                {
                    var result = MessageBox.Show($"Xác nhận xuất hoá đơn cho đơn hàng {salesOrderId}?", "Confirm", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        var inventoryForm = InventoryForm.Instance;
                        var products = await _salesOrderService.GetProductsBySalesOrderIdAsync(salesOrderId!);
                        var productQuantities = products.Select(p => ((string)p.ProductId, (int)p.Quantity)).ToList();
                        if (inventoryForm.CheckProductInventory(productQuantities))
                        {
                            await _salesOrderService.UpdateOrderStatusAsync(salesOrderId!, OrderStatus.Success);
                            await inventoryForm.LoadProductInventory(LoginForm.Instance.LoginInformation.StoreID);
                        }
                        else
                        {
                            MessageBox.Show("Không đủ số lượng sản phẩm để xuất hoá đơn.");
                        }
                    }
                }
                else if (orderStatus == OrderStatus.Cancelled)
                {
                    await _salesOrderService.UpdateOrderStatusAsync(salesOrderId!, OrderStatus.Cancelled);
                }
            }
        }

        private void dgvProductList_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
