using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using DTO.SalesOrder;
using DTO.Store;
using static BL.GeneralService;
using BL;
using PL.StoreEmployee;

namespace PL
{
    public partial class SalesOrderForm : System.Windows.Forms.Form
    {

        private SalesOrderService _salesOrderService = new SalesOrderService();
        private StoreService _storeService = new StoreService();

        private Dictionary<int, int> previousQuantities = new Dictionary<int, int>();
        private bool isAddingRow = false;
        private ShippingInformationForm _shippingInformationForm;
        private bool isShippingInfoEntered = false;
        public bool IsPreorder = false;
        public bool IsNonMember = false;
        public Dictionary<DiscountInfo?, decimal> DiscountInfos = new();
        public Dictionary<string, Tuple<DateTime, int>> usedProducts = new(); 
        public SalesOrderForm()
        {
            InitializeComponent();
            dgvDetailedOrder.Columns[6].Width = 50;
            _shippingInformationForm = new ShippingInformationForm(this);
        }

        private void dgvDetailedOrder_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (isAddingRow)
            {
                dgvDetailedOrder.Rows[e.RowIndex].Cells[6].Value = Properties.Resources.icon_remove;
            }
        }

        private void ibtnAdd_Click(object sender, EventArgs e)
        {
            string productId = txtBxProductId.Text.ToString();
            string stockDate = txtBxStockDate.Text.ToString();

            DateTime convertedStockDate;

            try
            {
                convertedStockDate = DateTime.ParseExact(stockDate, "dd/MM/yyyy", null);
            }
            catch (FormatException)
            {
                MessageBox.Show("Ngày không đúng định dạng dd/MM/yyyy", "Lỗi định dạng");
                return;
            }



            ProductInventoryDTO? product = GetProductInformation(productId, convertedStockDate);

            if (product != null)
            {
                isAddingRow = true;
                AddOrUpdateProductRow(product);
                if (!usedProducts.ContainsKey(product.ProductId))
                {
                    usedProducts.Add(product.ProductId, new Tuple<DateTime, int>(product.StockDate, 1));
                }
                isAddingRow = false;
            }
            else
            {
                MessageBox.Show("Sản phẩm không tồn tại trong kho", "Thông báo");
                return;
            }
        }

        private ProductInventoryDTO? GetProductInformation(string productId, DateTime convertedStockDate)
        {
            var inventoryForm = InventoryForm.Instance.ProductStockDetails;

            if (inventoryForm != null)
            {
                var product = inventoryForm
                         .FirstOrDefault(p => p.ProductId == productId && p.StockDate == convertedStockDate);
                return product;
            }

            return null;
        }

        private void AddOrUpdateProductRow(ProductInventoryDTO product)
        {
            int rowIndex = -1;
            foreach (DataGridViewRow row in dgvDetailedOrder.Rows)
            {
                if (row.Cells[1].Value?.ToString() == product.ProductId)
                {
                    rowIndex = row.Index;
                    break;
                }
            }

            if (rowIndex == -1)
            {
                rowIndex = dgvDetailedOrder.Rows.Add();
                dgvDetailedOrder.Rows[rowIndex].Cells[0].Value = rowIndex + 1;
                dgvDetailedOrder.Rows[rowIndex].Cells[1].Value = product.ProductId;
                dgvDetailedOrder.Rows[rowIndex].Cells[2].Value = product.ProductName;
                dgvDetailedOrder.Rows[rowIndex].Cells[3].Value = 1;
                dgvDetailedOrder.Rows[rowIndex].Cells[4].Value = ConvertToCurrency(product.UnitPrice);
            }
            else
            {
                int quantity = Convert.ToInt32(dgvDetailedOrder.Rows[rowIndex].Cells[3].Value);
                dgvDetailedOrder.Rows[rowIndex].Cells[3].Value = quantity + 1;
            }

            decimal unitPrice = product.UnitPrice;
            int updatedQuantity = Convert.ToInt32(dgvDetailedOrder.Rows[rowIndex].Cells[3].Value);
            dgvDetailedOrder.Rows[rowIndex].Cells[5].Value = ConvertToCurrency(unitPrice * updatedQuantity);

            dgvDetailedOrder.Rows[rowIndex].Cells[6].Value = Properties.Resources.icon_remove;
        }

        private void UpdateOrderColumn()
        {
            for (int i = 0; i < dgvDetailedOrder.Rows.Count; i++)
            {
                dgvDetailedOrder.Rows[i].Cells[0].Value = i + 1;
            }
        }

        private void dgvDetailedOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvDetailedOrder.Columns[6].Index && e.RowIndex >= 0)
            {
                var row = dgvDetailedOrder.Rows[e.RowIndex];
                string productId = row.Cells[1].Value.ToString()!;
                string productName = row.Cells[2].Value.ToString()!;
                DialogResult result = MessageBox.Show($"Do you want to remove the product {productName} (ID: {productId})?", "Confirm Remove", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {
                    dgvDetailedOrder.Rows.RemoveAt(e.RowIndex);
                    usedProducts.Remove(productId);
                    UpdateOrderColumn();
                }
            }
        }

        private async void btnCalculateFinalPrice_Click(object sender, EventArgs e)
        {
            if (dgvDetailedOrder.Rows.Count == 0)
            {
                MessageBox.Show("Bạn cần thêm tối thiểu một sản phẩm để tính giá", "Thông báo");
                return;
            }

            decimal basePrice = CalculateBasePrice();
            txtBxBasePrice.Text = ConvertToCurrency(basePrice);

            DiscountInfo? customerDiscount = await GetCustomerDiscountInfoAsync(txtBxCustomerRank.Text, basePrice);
            decimal customerDiscountValue = CalculateDiscountValue(customerDiscount, basePrice);

            DiscountInfos.Add(customerDiscount, customerDiscountValue);
            txtBxCustomerDiscountValue.Text = ConvertToCurrency(customerDiscountValue);

            DiscountInfo? orderDiscount = await GetOrderDiscountInfoAsync(basePrice);
            decimal orderDiscountValue = CalculateDiscountValue(orderDiscount, basePrice);
            DiscountInfos.Add(orderDiscount, orderDiscountValue);
            txtBxOrderDiscountValue.Text = ConvertToCurrency(orderDiscountValue);

            decimal finalPrice = basePrice - customerDiscountValue - orderDiscountValue;
            txtBxFinalPrice.Text = ConvertToCurrency(finalPrice);
        }

        private decimal CalculateBasePrice()
        {
            decimal basePrice = 0;
            foreach (DataGridViewRow row in dgvDetailedOrder.Rows)
            {
                if (row.Cells[5].Value != null)
                {
                    basePrice += ConvertFromCurrency(row.Cells[5].Value.ToString()!);
                }
            }
            return basePrice;
        }

        private decimal CalculateDiscountValue(DiscountInfo? discountInfo, decimal basePrice)
        {
            if (discountInfo == null)
            {
                return 0;
            }

            decimal discountValue = basePrice * discountInfo.Discount;
            if (discountValue > discountInfo.MaximumDiscountValue)
            {
                discountValue = discountInfo.MaximumDiscountValue;
            }
            return discountValue;
        }

        private async Task<DiscountInfo?> GetCustomerDiscountInfoAsync(string customerRank, decimal basePrice)
        {
            if (!IsNonMember && customerRank == string.Empty)
            {
                MessageBox.Show("Thông tin tên hạng còn thiếu, hãy cung cấp đầy đủ thông tin", "Thông báo");
                return null;
            }

            try
            {
                return await _salesOrderService.GetCustomerDiscountInfoAsync(customerRank, basePrice);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }

        private async Task<DiscountInfo?> GetOrderDiscountInfoAsync(decimal basePrice)
        {
            try
            {
                return await _salesOrderService.GetOrderDiscountInfoAsync(basePrice);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return null;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Bạn có chắc muốn xoá toàn bộ dữ liệu", "Cảnh báo", MessageBoxButtons.YesNo);

            if (dialog == DialogResult.Yes)
            {
                txtBxProductId.Clear();
                txtBxStockDate.Clear();
                txtBxCustomerID.Clear();
                txtBxCustomerName.Clear();
                txtBxCustomerRank.Clear();
                txtBxBasePrice.Clear();
                txtBxOrderDiscountValue.Clear();
                txtBxCustomerDiscountValue.Clear();
                txtBxFinalPrice.Clear();
                dgvDetailedOrder.Rows.Clear();
            }
        }

        private void ckBxIsNonMember_CheckedChanged(object sender, EventArgs e)
        {
            if (ckBxIsNonMember.Checked)
            {
                txtBxCustomerID.Clear();
                txtBxCustomerName.Clear();
                txtBxCustomerRank.Clear();

                txtBxCustomerID.Enabled = false;
                txtBxCustomerName.Enabled = false;
                txtBxCustomerRank.Enabled = false;
                IsNonMember = true;
            }
            else
            {
                txtBxCustomerID.Enabled = true;
                txtBxCustomerName.Enabled = true;
                txtBxCustomerRank.Enabled = true;
                IsNonMember = false;
            }
        }

        private void dgvDetailedOrder_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (isAddingRow) return;

            if (e.ColumnIndex == 3 && e.RowIndex >= 0)
            {
                var cell = dgvDetailedOrder.Rows[e.RowIndex].Cells[3];
                if (!int.TryParse(cell.Value?.ToString(), out int newQuantity) || newQuantity <= 0)
                {
                    MessageBox.Show("Số lượng phải là một số nguyên dương.", "Lỗi nhập liệu");
                    cell.Value = previousQuantities[e.RowIndex];
                    return;
                }

                string productId = dgvDetailedOrder.Rows[e.RowIndex].Cells[1].Value.ToString()!;
                DateTime stockDate = DateTime.ParseExact(txtBxStockDate.Text, "dd/MM/yyyy", null);
                ProductInventoryDTO? product = GetProductInformation(productId, stockDate);

                if (product != null && newQuantity > product.StockProductQuantity)
                {
                    MessageBox.Show($"Số lượng vượt quá số lượng có trong kho ({product.StockProductQuantity}).", "Lỗi nhập liệu");
                    cell.Value = previousQuantities[e.RowIndex];
                    return;
                }

                decimal unitPrice = ConvertFromCurrency(dgvDetailedOrder.Rows[e.RowIndex].Cells[4].Value.ToString()!);
                dgvDetailedOrder.Rows[e.RowIndex].Cells[5].Value = ConvertToCurrency(unitPrice * newQuantity);
            }
        }

        private void dgvDetailedOrder_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 3 && e.RowIndex >= 0)
            {
                int previousQuantity = Convert.ToInt32(dgvDetailedOrder.Rows[e.RowIndex].Cells[3].Value);
                previousQuantities[e.RowIndex] = previousQuantity;
            }
        }

        private void ckBxShippingOrder_CheckedChanged(object sender, EventArgs e)
        {
            if (ckBxShippingOrder.Checked)
            {
                btnComplete.Text = "Next";
            }
            else
            {
                btnComplete.Text = "Complete";
            }
        }

        private void ckBxPreorder_CheckedChanged(object sender, EventArgs e)
        {
            if (ckBxPreorder.Checked)
            {
                IsPreorder = true;
            }
            else
            {
                IsPreorder = false;
            }
        }

        private void ibtnAddPreorderProduct_Click(object sender, EventArgs e)
        {

        }

        private async void btnComplete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDetailedOrder.Rows.Count == 0)
                {
                    MessageBox.Show("Bạn cần phải thêm tối thiểu 1 sản phẩm", "Thông báo");
                    return;
                }

                if ((!IsNonMember && IsAnyCustomerInfoEmpty()))
                {
                    MessageBox.Show("Thông tin khách hàng không được để trống", "Thông báo");
                    return;
                }

                if (txtBxBasePrice.Text == string.Empty)
                {
                    MessageBox.Show("Bạn cần phải tính toán giá đơn hàng trước", "Thông báo");
                    return;
                }

                if (ckBxShippingOrder.Checked)
                {
                    _shippingInformationForm.ShowDialog();
                    return;
                }

                if (!ckBxShippingOrder.Checked && isShippingInfoEntered)
                {
                    DialogResult result = MessageBox.Show("Bạn đã nhập thông tin vận chuyển. Bạn muốn huỷ việc vận chuyển và thêm mới đơn hàng", "Xác nhận", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        _shippingInformationForm.ClearShippingInformation();
                        MessageBox.Show("Đơn hàng đã được thêm thành công", "Thông báo");
                        return;
                    }
                }

                if (!ckBxShippingOrder.Checked)
                {
                    List<UsedPromotionHistoryDTO> usedPromotions = new List<UsedPromotionHistoryDTO>();
                    DateTimeOffset deliveryDateTime = ConvertStringToDateTimeOffset(dtpDeliveryDatetime.Text);
                    List<DetailedSalesOrderDTO> detailedSalesOrders = new List<DetailedSalesOrderDTO>();
                    SalesOrderDTO salesOrder = new SalesOrderDTO();


                    foreach (var kvp in DiscountInfos)
                    {
                        if (kvp.Value == 0)
                        {
                            continue;
                        }

                        if (kvp.Key != null)
                        {
                            if (kvp.Key.PromotionType == "khách hàng")
                            {
                                DiscountInfo discountInfo = kvp.Key;
                                UsedPromotionHistoryDTO usedPromotion = new UsedPromotionHistoryDTO()
                                {
                                    PromotionId = discountInfo.PromotionID,
                                    CustomerDiscountValue = kvp.Value
                                };
                                usedPromotions.Add(usedPromotion);
                            }

                            if (kvp.Key.PromotionType == "đơn hàng")
                            {
                                DiscountInfo discountInfo = kvp.Key;
                                UsedPromotionHistoryDTO usedPromotion = new UsedPromotionHistoryDTO()
                                {
                                    PromotionId = discountInfo.PromotionID,
                                    OrderDiscountValue = kvp.Value
                                };
                                usedPromotions.Add(usedPromotion);
                            }
                        }

                    }

                    foreach (DataGridViewRow row in dgvDetailedOrder.Rows)
                    {
                        string productId = row.Cells[1].Value.ToString()!;
                        string quantity = row.Cells[3].Value.ToString()!;
                        DetailedSalesOrderDTO detail = new DetailedSalesOrderDTO()
                        {
                            ProductId = productId,
                            Quantity = Convert.ToInt32(quantity)
                        };

                        detailedSalesOrders.Add(detail);
                    }

                    salesOrder.DetailedSalesOrders = detailedSalesOrders;
                    salesOrder.CustomerId = GetCustomerId();
                    salesOrder.StoreId = LoginForm.Instance.LoginInformation.StoreID;
                    salesOrder.PurchaseMethod = "tại cửa hàng";
                    salesOrder.BasePrice = ConvertFromCurrency(txtBxBasePrice.Text);
                    salesOrder.FinalPrice = ConvertFromCurrency(txtBxFinalPrice.Text);
                    salesOrder.CreatedDateTime = LocalDateTimeOffset();

                    if (IsPreorder)
                    {
                        //Thực hiện add mới sản phẩm đặt trước, không có sử dụng dịch vụ vận chuyển
                        if (!ValidatePreorderDeliveryDatetime())
                        {
                            MessageBox.Show("Đơn hàng đặt trước phải lớn hơn ngày hiện tại và không được vượt quá 7 ngày. Giờ nhận hàng phải từ 05:00 - 20:00", "Thông báo");
                            dtpDeliveryDatetime.Focus();
                            return;
                        }

                        salesOrder.OrderStatus = "đã xác nhận";
                        salesOrder.OrderType = "đặt trước";

                        await _salesOrderService.AddSalesOrderAsync(salesOrder, usedPromotions, null, deliveryDateTime);
                    }
                    else
                    {
                        //Thực hiện add mới đơn hàng lấy ngay, không có sử dụng dịch vụ vận chuyển
                        salesOrder.OrderStatus = "thành công";
                        salesOrder.OrderType = "lấy ngay";

                        await _salesOrderService.AddSalesOrderAsync(salesOrder, usedPromotions, null, null);

                        await _storeService.UpdateProductInventoryByStoreAsync(LoginForm.Instance.LoginInformation.StoreID!, usedProducts);
                    }

                    
                    MessageBox.Show("Đơn hàng đã được thêm thành công", "Thông báo");

                    //Thực hiện làm mới form để tiếp tục thêm mới đơn hàng nếu có.
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private bool IsAnyCustomerInfoEmpty()
        {
            if (txtBxCustomerID.Text == string.Empty || txtBxCustomerName.Text == string.Empty || txtBxCustomerRank.Text == string.Empty)
            {
                return true;
            }
            return false;
        }

        public void SetShippingInfoEntered(bool value)
        {
            isShippingInfoEntered = value;
        }

        public string GetCustomerName()
        {
            return txtBxCustomerName.Text;
        }

        public string GetCustomerId()
        {
            return txtBxCustomerID.Text;
        }

        public DataTable GetOrderInformation()
        {
            DataTable orderInfo = new DataTable();
            orderInfo.Columns.Add("Order");
            orderInfo.Columns.Add("ProductId");
            orderInfo.Columns.Add("ProductName");
            orderInfo.Columns.Add("Quantity");
            orderInfo.Columns.Add("LinePrice");

            foreach (DataGridViewRow row in dgvDetailedOrder.Rows)
            {
                if (row.IsNewRow) continue;

                DataRow dataRow = orderInfo.NewRow();
                dataRow["Order"] = row.Cells[0].Value;
                dataRow["ProductId"] = row.Cells[1].Value;
                dataRow["ProductName"] = row.Cells[2].Value;
                dataRow["Quantity"] = row.Cells[3].Value;
                dataRow["LinePrice"] = row.Cells[5].Value;
                orderInfo.Rows.Add(dataRow);
            }

            return orderInfo;
        }

        public decimal GetBasePrice()
        {
            return ConvertFromCurrency(txtBxBasePrice.Text);
        }

        public decimal GetCustomerDiscount()
        {
            return ConvertFromCurrency(txtBxCustomerDiscountValue.Text);
        }

        public decimal GetOrderDiscount()
        {
            return ConvertFromCurrency(txtBxOrderDiscountValue.Text);
        }

        public void ResetSalesOrderForm()
        {
            IsPreorder = false;
            previousQuantities = new Dictionary<int, int>();
            isAddingRow = false;
            isShippingInfoEntered = false;
        }

        private void dtpDeliveryDatetime_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidatePreorderDeliveryDatetime())
            {
                MessageBox.Show("Đơn hàng đặt trước phải lớn hơn ngày hiện tại và không được vượt quá 7 ngày. Giờ giao hàng phải từ 05:00 - 20:00", "Thông báo");
                dtpDeliveryDatetime.Focus();
                return;
            }
        }
    }
}
