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

namespace PL
{
    public partial class SalesOrderForm : System.Windows.Forms.Form
    {
        public SalesOrderForm()
        {
            InitializeComponent();
        }

        private void dgvDetailedOrder_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dgvDetailedOrder.Rows[e.RowIndex].Cells[6].Value = Properties.Resources.icon_remove;
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
                AddOrUpdateProductRow(product);
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

        private string ConvertToCurrency(decimal value)
        {
            return value.ToString("C", new System.Globalization.CultureInfo("vi-VN"));
        }

        private decimal ConvertFromCurrency(string currencyValue)
        {
            return decimal.Parse(currencyValue, System.Globalization.NumberStyles.Currency, new System.Globalization.CultureInfo("vi-VN"));
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
                    UpdateOrderColumn();
                }
            }
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {

        }

        private void btnCalculateFinalPrice_Click(object sender, EventArgs e)
        {
            decimal basePrice = CalculateBasePrice();
            txtBxBasePrice.Text = ConvertToCurrency(basePrice);

            DiscountInfo? customerDiscount = GetCustomerDiscountInfo(txtBxCustomerRank.Text, basePrice);
            decimal customerDiscountValue = CalculateDiscountValue(customerDiscount, basePrice);
            txtBxCustomerDiscountValue.Text = ConvertToCurrency(customerDiscountValue);

            DiscountInfo? orderDiscount = GetOrderDiscountInfo(basePrice);
            decimal orderDiscountValue = CalculateDiscountValue(orderDiscount, basePrice);
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

        private DiscountInfo? GetCustomerDiscountInfo(string customerRank, decimal basePrice)
        {
            if (customerRank == string.Empty)
            {
                MessageBox.Show("Thông tin tên hạng còn thiếu, hãy cung cấp đầy đủ thông tin", "Thông báo");
                return null;
            }
            // Implement your logic to get customer discount info
            return new DiscountInfo { Discount = 0.1m, MaximumDiscountValue = 50000m };
        }

        private DiscountInfo? GetOrderDiscountInfo(decimal basePrice)
        {
            // Implement your logic to get order discount info
            return new DiscountInfo { Discount = 0.05m, MaximumDiscountValue = 30000m };
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
            }
            else
            {
                txtBxCustomerID.Enabled = true;
                txtBxCustomerName.Enabled = true;
                txtBxCustomerRank.Enabled = true;
            }
        }
    }
}
