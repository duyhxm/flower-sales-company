namespace PL
{
    partial class SalesOrderForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtBxOrderID = new TextBox();
            lblOrderID = new Label();
            lblCustomerID = new Label();
            lblCustomerName = new Label();
            ckBxIsMember = new CheckBox();
            lblOrderInfo = new Label();
            lblCustomerRank = new Label();
            grBxCustomerInfo = new GroupBox();
            txtBxCustomerName = new TextBox();
            txtBxCustomerID = new TextBox();
            txtBxCustomerRank = new TextBox();
            dgvProductList = new DataGridView();
            order_column = new DataGridViewTextBoxColumn();
            orderid_column = new DataGridViewTextBoxColumn();
            name_column = new DataGridViewTextBoxColumn();
            quantity_column = new DataGridViewTextBoxColumn();
            unit_price_column = new DataGridViewTextBoxColumn();
            line_price_column = new DataGridViewTextBoxColumn();
            remove_column = new DataGridViewImageColumn();
            lblCustomerDiscountValue = new Label();
            lblOrderDiscountValue = new Label();
            lblFinalPrice = new Label();
            lblBasePrice = new Label();
            txtBxBasePrice = new TextBox();
            txtBxOrderDiscountValue = new TextBox();
            txtBxCustomerDiscountValue = new TextBox();
            txtBxFinalPrice = new TextBox();
            btnComplete = new Button();
            btnClear = new Button();
            grBxCustomerInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductList).BeginInit();
            SuspendLayout();
            // 
            // txtBxOrderID
            // 
            txtBxOrderID.Location = new Point(349, 308);
            txtBxOrderID.Margin = new Padding(3, 4, 3, 4);
            txtBxOrderID.Name = "txtBxOrderID";
            txtBxOrderID.Size = new Size(177, 39);
            txtBxOrderID.TabIndex = 0;
            // 
            // lblOrderID
            // 
            lblOrderID.AutoSize = true;
            lblOrderID.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblOrderID.ForeColor = Color.FromArgb(47, 47, 48);
            lblOrderID.Location = new Point(247, 316);
            lblOrderID.Name = "lblOrderID";
            lblOrderID.Size = new Size(104, 27);
            lblOrderID.TabIndex = 1;
            lblOrderID.Text = "Order ID";
            // 
            // lblCustomerID
            // 
            lblCustomerID.AutoSize = true;
            lblCustomerID.BackColor = Color.Transparent;
            lblCustomerID.ForeColor = Color.DimGray;
            lblCustomerID.Location = new Point(30, 57);
            lblCustomerID.Name = "lblCustomerID";
            lblCustomerID.Size = new Size(146, 27);
            lblCustomerID.TabIndex = 2;
            lblCustomerID.Text = "Customer ID";
            // 
            // lblCustomerName
            // 
            lblCustomerName.AutoSize = true;
            lblCustomerName.ForeColor = Color.DimGray;
            lblCustomerName.Location = new Point(354, 57);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(183, 27);
            lblCustomerName.TabIndex = 3;
            lblCustomerName.Text = "Customer name";
            // 
            // ckBxIsMember
            // 
            ckBxIsMember.AutoSize = true;
            ckBxIsMember.Location = new Point(507, 111);
            ckBxIsMember.Margin = new Padding(3, 4, 3, 4);
            ckBxIsMember.Name = "ckBxIsMember";
            ckBxIsMember.Size = new Size(281, 31);
            ckBxIsMember.TabIndex = 4;
            ckBxIsMember.Text = "non-member customer";
            ckBxIsMember.UseVisualStyleBackColor = true;
            // 
            // lblOrderInfo
            // 
            lblOrderInfo.AutoSize = true;
            lblOrderInfo.ForeColor = Color.Black;
            lblOrderInfo.Location = new Point(19, 312);
            lblOrderInfo.Name = "lblOrderInfo";
            lblOrderInfo.Size = new Size(207, 32);
            lblOrderInfo.TabIndex = 5;
            lblOrderInfo.Text = "Order Information";
            // 
            // lblCustomerRank
            // 
            lblCustomerRank.AutoSize = true;
            lblCustomerRank.ForeColor = Color.DimGray;
            lblCustomerRank.Location = new Point(30, 115);
            lblCustomerRank.Name = "lblCustomerRank";
            lblCustomerRank.Size = new Size(170, 27);
            lblCustomerRank.TabIndex = 6;
            lblCustomerRank.Text = "Customer rank";
            // 
            // grBxCustomerInfo
            // 
            grBxCustomerInfo.Controls.Add(txtBxCustomerName);
            grBxCustomerInfo.Controls.Add(txtBxCustomerID);
            grBxCustomerInfo.Controls.Add(txtBxCustomerRank);
            grBxCustomerInfo.Controls.Add(lblCustomerID);
            grBxCustomerInfo.Controls.Add(lblCustomerRank);
            grBxCustomerInfo.Controls.Add(ckBxIsMember);
            grBxCustomerInfo.Controls.Add(lblCustomerName);
            grBxCustomerInfo.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            grBxCustomerInfo.Location = new Point(19, 119);
            grBxCustomerInfo.Margin = new Padding(3, 4, 3, 4);
            grBxCustomerInfo.Name = "grBxCustomerInfo";
            grBxCustomerInfo.Padding = new Padding(3, 4, 3, 4);
            grBxCustomerInfo.Size = new Size(859, 169);
            grBxCustomerInfo.TabIndex = 7;
            grBxCustomerInfo.TabStop = false;
            grBxCustomerInfo.Text = "Customer Information";
            // 
            // txtBxCustomerName
            // 
            txtBxCustomerName.Location = new Point(529, 53);
            txtBxCustomerName.Margin = new Padding(3, 4, 3, 4);
            txtBxCustomerName.Name = "txtBxCustomerName";
            txtBxCustomerName.Size = new Size(259, 35);
            txtBxCustomerName.TabIndex = 10;
            // 
            // txtBxCustomerID
            // 
            txtBxCustomerID.Location = new Point(173, 57);
            txtBxCustomerID.Margin = new Padding(3, 4, 3, 4);
            txtBxCustomerID.Name = "txtBxCustomerID";
            txtBxCustomerID.Size = new Size(177, 35);
            txtBxCustomerID.TabIndex = 8;
            // 
            // txtBxCustomerRank
            // 
            txtBxCustomerRank.Location = new Point(193, 109);
            txtBxCustomerRank.Margin = new Padding(3, 4, 3, 4);
            txtBxCustomerRank.Name = "txtBxCustomerRank";
            txtBxCustomerRank.Size = new Size(177, 35);
            txtBxCustomerRank.TabIndex = 9;
            // 
            // dgvProductList
            // 
            dgvProductList.BackgroundColor = SystemColors.Window;
            dgvProductList.BorderStyle = BorderStyle.None;
            dgvProductList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductList.Columns.AddRange(new DataGridViewColumn[] { order_column, orderid_column, name_column, quantity_column, unit_price_column, line_price_column, remove_column });
            dgvProductList.Location = new Point(84, 369);
            dgvProductList.Margin = new Padding(3, 4, 3, 4);
            dgvProductList.Name = "dgvProductList";
            dgvProductList.RowHeadersWidth = 62;
            dgvProductList.Size = new Size(1272, 239);
            dgvProductList.TabIndex = 8;
            // 
            // order_column
            // 
            order_column.HeaderText = "#";
            order_column.MinimumWidth = 8;
            order_column.Name = "order_column";
            order_column.Width = 80;
            // 
            // orderid_column
            // 
            orderid_column.HeaderText = "ID";
            orderid_column.MinimumWidth = 8;
            orderid_column.Name = "orderid_column";
            orderid_column.Width = 150;
            // 
            // name_column
            // 
            name_column.HeaderText = "Product Name";
            name_column.MinimumWidth = 8;
            name_column.Name = "name_column";
            name_column.Width = 250;
            // 
            // quantity_column
            // 
            quantity_column.HeaderText = "Q";
            quantity_column.MinimumWidth = 8;
            quantity_column.Name = "quantity_column";
            quantity_column.Width = 80;
            // 
            // unit_price_column
            // 
            unit_price_column.HeaderText = "Unit Price";
            unit_price_column.MinimumWidth = 8;
            unit_price_column.Name = "unit_price_column";
            unit_price_column.Width = 200;
            // 
            // line_price_column
            // 
            line_price_column.HeaderText = "Line Price";
            line_price_column.MinimumWidth = 8;
            line_price_column.Name = "line_price_column";
            line_price_column.Width = 200;
            // 
            // remove_column
            // 
            remove_column.HeaderText = "--";
            remove_column.MinimumWidth = 100;
            remove_column.Name = "remove_column";
            remove_column.Width = 150;
            // 
            // lblCustomerDiscountValue
            // 
            lblCustomerDiscountValue.AutoSize = true;
            lblCustomerDiscountValue.Location = new Point(518, 685);
            lblCustomerDiscountValue.Name = "lblCustomerDiscountValue";
            lblCustomerDiscountValue.Size = new Size(279, 32);
            lblCustomerDiscountValue.TabIndex = 9;
            lblCustomerDiscountValue.Text = "Customer discount value";
            // 
            // lblOrderDiscountValue
            // 
            lblOrderDiscountValue.AutoSize = true;
            lblOrderDiscountValue.Location = new Point(518, 731);
            lblOrderDiscountValue.Name = "lblOrderDiscountValue";
            lblOrderDiscountValue.Size = new Size(237, 32);
            lblOrderDiscountValue.TabIndex = 10;
            lblOrderDiscountValue.Text = "Order discount value";
            // 
            // lblFinalPrice
            // 
            lblFinalPrice.AutoSize = true;
            lblFinalPrice.Location = new Point(518, 777);
            lblFinalPrice.Name = "lblFinalPrice";
            lblFinalPrice.Size = new Size(123, 32);
            lblFinalPrice.TabIndex = 11;
            lblFinalPrice.Text = "Final price";
            // 
            // lblBasePrice
            // 
            lblBasePrice.AutoSize = true;
            lblBasePrice.Location = new Point(518, 639);
            lblBasePrice.Name = "lblBasePrice";
            lblBasePrice.Size = new Size(122, 32);
            lblBasePrice.TabIndex = 13;
            lblBasePrice.Text = "Base price";
            // 
            // txtBxBasePrice
            // 
            txtBxBasePrice.BackColor = SystemColors.Info;
            txtBxBasePrice.BorderStyle = BorderStyle.FixedSingle;
            txtBxBasePrice.Location = new Point(849, 633);
            txtBxBasePrice.Margin = new Padding(3, 4, 3, 4);
            txtBxBasePrice.Name = "txtBxBasePrice";
            txtBxBasePrice.Size = new Size(134, 39);
            txtBxBasePrice.TabIndex = 14;
            // 
            // txtBxOrderDiscountValue
            // 
            txtBxOrderDiscountValue.BackColor = SystemColors.Info;
            txtBxOrderDiscountValue.Location = new Point(849, 727);
            txtBxOrderDiscountValue.Margin = new Padding(3, 4, 3, 4);
            txtBxOrderDiscountValue.Name = "txtBxOrderDiscountValue";
            txtBxOrderDiscountValue.Size = new Size(134, 39);
            txtBxOrderDiscountValue.TabIndex = 15;
            // 
            // txtBxCustomerDiscountValue
            // 
            txtBxCustomerDiscountValue.BackColor = SystemColors.Info;
            txtBxCustomerDiscountValue.BorderStyle = BorderStyle.FixedSingle;
            txtBxCustomerDiscountValue.Location = new Point(849, 680);
            txtBxCustomerDiscountValue.Margin = new Padding(3, 4, 3, 4);
            txtBxCustomerDiscountValue.Name = "txtBxCustomerDiscountValue";
            txtBxCustomerDiscountValue.Size = new Size(134, 39);
            txtBxCustomerDiscountValue.TabIndex = 16;
            // 
            // txtBxFinalPrice
            // 
            txtBxFinalPrice.BackColor = SystemColors.Info;
            txtBxFinalPrice.Location = new Point(849, 774);
            txtBxFinalPrice.Margin = new Padding(3, 4, 3, 4);
            txtBxFinalPrice.Name = "txtBxFinalPrice";
            txtBxFinalPrice.Size = new Size(134, 39);
            txtBxFinalPrice.TabIndex = 17;
            // 
            // btnComplete
            // 
            btnComplete.Location = new Point(665, 855);
            btnComplete.Margin = new Padding(3, 4, 3, 4);
            btnComplete.Name = "btnComplete";
            btnComplete.Size = new Size(168, 50);
            btnComplete.TabIndex = 18;
            btnComplete.Text = "Complete";
            btnComplete.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(860, 855);
            btnClear.Margin = new Padding(3, 4, 3, 4);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(122, 50);
            btnClear.TabIndex = 19;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // SalesOrderForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1653, 944);
            Controls.Add(btnClear);
            Controls.Add(btnComplete);
            Controls.Add(txtBxFinalPrice);
            Controls.Add(txtBxCustomerDiscountValue);
            Controls.Add(txtBxOrderDiscountValue);
            Controls.Add(txtBxBasePrice);
            Controls.Add(lblBasePrice);
            Controls.Add(lblFinalPrice);
            Controls.Add(lblOrderDiscountValue);
            Controls.Add(lblCustomerDiscountValue);
            Controls.Add(dgvProductList);
            Controls.Add(grBxCustomerInfo);
            Controls.Add(lblOrderInfo);
            Controls.Add(lblOrderID);
            Controls.Add(txtBxOrderID);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "SalesOrderForm";
            Text = "Sales_Form";
            grBxCustomerInfo.ResumeLayout(false);
            grBxCustomerInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtBxOrderID;
        private Label lblOrderID;
        private Label lblCustomerID;
        private Label lblCustomerName;
        private CheckBox ckBxIsMember;
        private Label lblOrderInfo;
        private Label lblCustomerRank;
        private GroupBox grBxCustomerInfo;
        private TextBox txtBxCustomerName;
        private TextBox txtBxCustomerID;
        private TextBox txtBxCustomerRank;
        private DataGridView dgvProductList;
        private Label lblCustomerDiscountValue;
        private Label lblOrderDiscountValue;
        private Label lblFinalPrice;
        private Label lblBasePrice;
        private TextBox txtBxBasePrice;
        private TextBox txtBxOrderDiscountValue;
        private TextBox txtBxCustomerDiscountValue;
        private TextBox txtBxFinalPrice;
        private Button btnComplete;
        private Button btnClear;
        private DataGridViewTextBoxColumn order_column;
        private DataGridViewTextBoxColumn orderid_column;
        private DataGridViewTextBoxColumn name_column;
        private DataGridViewTextBoxColumn quantity_column;
        private DataGridViewTextBoxColumn unit_price_column;
        private DataGridViewTextBoxColumn line_price_column;
        private DataGridViewImageColumn remove_column;
    }
}