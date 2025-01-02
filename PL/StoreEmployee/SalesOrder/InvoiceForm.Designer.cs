namespace PL.StoreEmployee
{
    partial class InvoiceForm
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
            lblCustomerId = new Label();
            lblCustomerName = new Label();
            label3 = new Label();
            lblCustomerInfo = new Label();
            lblInvoice = new Label();
            dgvOrderInfo = new DataGridView();
            txtBxCustomerId = new TextBox();
            btnCancel = new Button();
            txtBxBasePrice = new TextBox();
            txtBxCustomerDiscountValue = new TextBox();
            txtBxOrderDiscountValue = new TextBox();
            txtBxShippingCost = new TextBox();
            txtBxFinalPrice = new TextBox();
            btnReturn = new Button();
            btnAddOrder = new Button();
            txtBxCustomerName = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            ColOrder = new DataGridViewTextBoxColumn();
            ColProductId = new DataGridViewTextBoxColumn();
            ColProductName = new DataGridViewTextBoxColumn();
            ColQuantity = new DataGridViewTextBoxColumn();
            ColLinePrice = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvOrderInfo).BeginInit();
            SuspendLayout();
            // 
            // lblCustomerId
            // 
            lblCustomerId.AutoSize = true;
            lblCustomerId.Location = new Point(45, 96);
            lblCustomerId.Margin = new Padding(2, 0, 2, 0);
            lblCustomerId.Name = "lblCustomerId";
            lblCustomerId.Size = new Size(112, 25);
            lblCustomerId.TabIndex = 0;
            lblCustomerId.Text = "Customer ID";
            // 
            // lblCustomerName
            // 
            lblCustomerName.AutoSize = true;
            lblCustomerName.Location = new Point(435, 93);
            lblCustomerName.Margin = new Padding(2, 0, 2, 0);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(138, 25);
            lblCustomerName.TabIndex = 1;
            lblCustomerName.Text = "Customer name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(32, 134);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(212, 32);
            label3.TabIndex = 2;
            label3.Text = "Order information";
            // 
            // lblCustomerInfo
            // 
            lblCustomerInfo.AutoSize = true;
            lblCustomerInfo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCustomerInfo.Location = new Point(22, 55);
            lblCustomerInfo.Margin = new Padding(2, 0, 2, 0);
            lblCustomerInfo.Name = "lblCustomerInfo";
            lblCustomerInfo.Size = new Size(254, 32);
            lblCustomerInfo.TabIndex = 3;
            lblCustomerInfo.Text = "Customer information";
            // 
            // lblInvoice
            // 
            lblInvoice.AutoSize = true;
            lblInvoice.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblInvoice.Location = new Point(347, 23);
            lblInvoice.Margin = new Padding(2, 0, 2, 0);
            lblInvoice.Name = "lblInvoice";
            lblInvoice.Size = new Size(107, 38);
            lblInvoice.TabIndex = 4;
            lblInvoice.Text = "Invoice";
            // 
            // dgvOrderInfo
            // 
            dgvOrderInfo.AllowUserToAddRows = false;
            dgvOrderInfo.AllowUserToDeleteRows = false;
            dgvOrderInfo.AllowUserToResizeColumns = false;
            dgvOrderInfo.AllowUserToResizeRows = false;
            dgvOrderInfo.BackgroundColor = SystemColors.ControlLightLight;
            dgvOrderInfo.BorderStyle = BorderStyle.None;
            dgvOrderInfo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrderInfo.Columns.AddRange(new DataGridViewColumn[] { ColOrder, ColProductId, ColProductName, ColQuantity, ColLinePrice });
            dgvOrderInfo.Location = new Point(22, 169);
            dgvOrderInfo.Name = "dgvOrderInfo";
            dgvOrderInfo.ReadOnly = true;
            dgvOrderInfo.RowHeadersVisible = false;
            dgvOrderInfo.RowHeadersWidth = 62;
            dgvOrderInfo.Size = new Size(897, 257);
            dgvOrderInfo.TabIndex = 5;
            // 
            // txtBxCustomerId
            // 
            txtBxCustomerId.BackColor = SystemColors.Info;
            txtBxCustomerId.BorderStyle = BorderStyle.FixedSingle;
            txtBxCustomerId.Enabled = false;
            txtBxCustomerId.Location = new Point(221, 90);
            txtBxCustomerId.Name = "txtBxCustomerId";
            txtBxCustomerId.ReadOnly = true;
            txtBxCustomerId.Size = new Size(193, 31);
            txtBxCustomerId.TabIndex = 6;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(697, 556);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(112, 34);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // txtBxBasePrice
            // 
            txtBxBasePrice.BackColor = SystemColors.Info;
            txtBxBasePrice.Location = new Point(228, 466);
            txtBxBasePrice.Name = "txtBxBasePrice";
            txtBxBasePrice.Size = new Size(150, 31);
            txtBxBasePrice.TabIndex = 8;
            // 
            // txtBxCustomerDiscountValue
            // 
            txtBxCustomerDiscountValue.BackColor = SystemColors.Info;
            txtBxCustomerDiscountValue.Location = new Point(228, 503);
            txtBxCustomerDiscountValue.Name = "txtBxCustomerDiscountValue";
            txtBxCustomerDiscountValue.Size = new Size(150, 31);
            txtBxCustomerDiscountValue.TabIndex = 9;
            // 
            // txtBxOrderDiscountValue
            // 
            txtBxOrderDiscountValue.BackColor = SystemColors.Info;
            txtBxOrderDiscountValue.Location = new Point(228, 540);
            txtBxOrderDiscountValue.Name = "txtBxOrderDiscountValue";
            txtBxOrderDiscountValue.Size = new Size(150, 31);
            txtBxOrderDiscountValue.TabIndex = 10;
            // 
            // txtBxShippingCost
            // 
            txtBxShippingCost.BackColor = SystemColors.Info;
            txtBxShippingCost.Location = new Point(228, 577);
            txtBxShippingCost.Name = "txtBxShippingCost";
            txtBxShippingCost.Size = new Size(150, 31);
            txtBxShippingCost.TabIndex = 11;
            // 
            // txtBxFinalPrice
            // 
            txtBxFinalPrice.BackColor = SystemColors.Info;
            txtBxFinalPrice.Location = new Point(652, 499);
            txtBxFinalPrice.Name = "txtBxFinalPrice";
            txtBxFinalPrice.Size = new Size(150, 31);
            txtBxFinalPrice.TabIndex = 12;
            // 
            // btnReturn
            // 
            btnReturn.Location = new Point(579, 556);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(112, 34);
            btnReturn.TabIndex = 13;
            btnReturn.Text = "Return";
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Click += btnReturn_Click;
            // 
            // btnAddOrder
            // 
            btnAddOrder.Location = new Point(461, 556);
            btnAddOrder.Name = "btnAddOrder";
            btnAddOrder.Size = new Size(112, 34);
            btnAddOrder.TabIndex = 14;
            btnAddOrder.Text = "Add";
            btnAddOrder.UseVisualStyleBackColor = true;
            btnAddOrder.Click += btnAddOrder_Click;
            // 
            // txtBxCustomerName
            // 
            txtBxCustomerName.BackColor = SystemColors.Info;
            txtBxCustomerName.BorderStyle = BorderStyle.FixedSingle;
            txtBxCustomerName.Enabled = false;
            txtBxCustomerName.Location = new Point(611, 90);
            txtBxCustomerName.Name = "txtBxCustomerName";
            txtBxCustomerName.ReadOnly = true;
            txtBxCustomerName.Size = new Size(281, 31);
            txtBxCustomerName.TabIndex = 15;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(52, 469);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(91, 25);
            label1.TabIndex = 16;
            label1.Text = "Base price";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(52, 506);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(162, 25);
            label2.TabIndex = 17;
            label2.Text = "Customer discount";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(52, 543);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(131, 25);
            label5.TabIndex = 18;
            label5.Text = "Order discount";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(52, 580);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(121, 25);
            label6.TabIndex = 19;
            label6.Text = "Shipping cost";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(476, 502);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(91, 25);
            label7.TabIndex = 20;
            label7.Text = "Final price";
            // 
            // ColOrder
            // 
            ColOrder.DataPropertyName = "Order";
            ColOrder.FillWeight = 30F;
            ColOrder.HeaderText = "#";
            ColOrder.MinimumWidth = 8;
            ColOrder.Name = "ColOrder";
            ColOrder.ReadOnly = true;
            ColOrder.Width = 50;
            // 
            // ColProductId
            // 
            ColProductId.DataPropertyName = "ProductId";
            ColProductId.FillWeight = 50F;
            ColProductId.HeaderText = "ID";
            ColProductId.MinimumWidth = 8;
            ColProductId.Name = "ColProductId";
            ColProductId.ReadOnly = true;
            ColProductId.Width = 120;
            // 
            // ColProductName
            // 
            ColProductName.DataPropertyName = "ProductName";
            ColProductName.HeaderText = "Name";
            ColProductName.MinimumWidth = 8;
            ColProductName.Name = "ColProductName";
            ColProductName.ReadOnly = true;
            ColProductName.Width = 200;
            // 
            // ColQuantity
            // 
            ColQuantity.DataPropertyName = "Quantity";
            ColQuantity.FillWeight = 50F;
            ColQuantity.HeaderText = "Q";
            ColQuantity.MinimumWidth = 8;
            ColQuantity.Name = "ColQuantity";
            ColQuantity.ReadOnly = true;
            ColQuantity.Width = 80;
            // 
            // ColLinePrice
            // 
            ColLinePrice.DataPropertyName = "LinePrice";
            ColLinePrice.HeaderText = "Line Price";
            ColLinePrice.MinimumWidth = 8;
            ColLinePrice.Name = "ColLinePrice";
            ColLinePrice.ReadOnly = true;
            ColLinePrice.Width = 150;
            // 
            // InvoiceForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(948, 650);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtBxCustomerName);
            Controls.Add(btnAddOrder);
            Controls.Add(btnReturn);
            Controls.Add(txtBxFinalPrice);
            Controls.Add(txtBxShippingCost);
            Controls.Add(txtBxOrderDiscountValue);
            Controls.Add(txtBxCustomerDiscountValue);
            Controls.Add(txtBxBasePrice);
            Controls.Add(btnCancel);
            Controls.Add(txtBxCustomerId);
            Controls.Add(dgvOrderInfo);
            Controls.Add(lblInvoice);
            Controls.Add(lblCustomerInfo);
            Controls.Add(label3);
            Controls.Add(lblCustomerName);
            Controls.Add(lblCustomerId);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "InvoiceForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "InvoiceForm";
            ((System.ComponentModel.ISupportInitialize)dgvOrderInfo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCustomerId;
        private Label lblCustomerName;
        private Label label3;
        private Label lblCustomerInfo;
        private Label lblInvoice;
        private DataGridView dgvOrderInfo;
        private TextBox txtBxCustomerId;
        private Button btnCancel;
        private TextBox txtBxBasePrice;
        private TextBox txtBxCustomerDiscountValue;
        private TextBox txtBxOrderDiscountValue;
        private TextBox txtBxShippingCost;
        private TextBox txtBxFinalPrice;
        private Button btnReturn;
        private Button btnAddOrder;
        private TextBox txtBxCustomerName;
        private Label label1;
        private Label label2;
        private Label label5;
        private Label label6;
        private Label label7;
        private DataGridViewTextBoxColumn ColOrder;
        private DataGridViewTextBoxColumn ColProductId;
        private DataGridViewTextBoxColumn ColProductName;
        private DataGridViewTextBoxColumn ColQuantity;
        private DataGridViewTextBoxColumn ColLinePrice;
    }
}