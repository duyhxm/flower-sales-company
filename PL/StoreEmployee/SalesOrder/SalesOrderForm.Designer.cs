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
            txtBxProductId = new TextBox();
            lblCustomerId = new Label();
            lblCustomerName = new Label();
            ckBxIsNonMember = new CheckBox();
            lblOrderInfo = new Label();
            lblCustomerRank = new Label();
            txtBxCustomerName = new TextBox();
            txtBxCustomerID = new TextBox();
            txtBxCustomerRank = new TextBox();
            dgvDetailedOrder = new DataGridView();
            ColOrder = new DataGridViewTextBoxColumn();
            ColSalesOrderId = new DataGridViewTextBoxColumn();
            ColProductName = new DataGridViewTextBoxColumn();
            ColProductQuantity = new DataGridViewTextBoxColumn();
            ColUnitPrice = new DataGridViewTextBoxColumn();
            ColLinePrice = new DataGridViewTextBoxColumn();
            ColRemove = new DataGridViewImageColumn();
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
            txtBxStockDate = new TextBox();
            lblProductInfo = new Label();
            lblProductId = new Label();
            lblStockDate = new Label();
            lblCustomerInfo = new Label();
            ibtnAdd = new FontAwesome.Sharp.IconButton();
            btnCalculateFinalPrice = new Button();
            ckBxShippingOrder = new CheckBox();
            ckBxPreorder = new CheckBox();
            ibtnAddPreorderProduct = new FontAwesome.Sharp.IconButton();
            dtpDeliveryDatetime = new DateTimePicker();
            lblPurchaseMethod = new Label();
            cmbBxPurchaseMethod = new ComboBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvDetailedOrder).BeginInit();
            SuspendLayout();
            // 
            // txtBxProductId
            // 
            txtBxProductId.Location = new Point(1282, 92);
            txtBxProductId.Margin = new Padding(3, 4, 3, 4);
            txtBxProductId.Name = "txtBxProductId";
            txtBxProductId.Size = new Size(177, 39);
            txtBxProductId.TabIndex = 0;
            // 
            // lblCustomerId
            // 
            lblCustomerId.AutoSize = true;
            lblCustomerId.BackColor = Color.Transparent;
            lblCustomerId.ForeColor = Color.Black;
            lblCustomerId.Location = new Point(79, 95);
            lblCustomerId.Name = "lblCustomerId";
            lblCustomerId.Size = new Size(147, 32);
            lblCustomerId.TabIndex = 2;
            lblCustomerId.Text = "Customer ID";
            // 
            // lblCustomerName
            // 
            lblCustomerName.AutoSize = true;
            lblCustomerName.ForeColor = Color.Black;
            lblCustomerName.Location = new Point(499, 95);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(184, 32);
            lblCustomerName.TabIndex = 3;
            lblCustomerName.Text = "Customer name";
            // 
            // ckBxIsNonMember
            // 
            ckBxIsNonMember.AutoSize = true;
            ckBxIsNonMember.Location = new Point(706, 144);
            ckBxIsNonMember.Margin = new Padding(3, 4, 3, 4);
            ckBxIsNonMember.Name = "ckBxIsNonMember";
            ckBxIsNonMember.Size = new Size(288, 36);
            ckBxIsNonMember.TabIndex = 4;
            ckBxIsNonMember.Text = "non-member customer";
            ckBxIsNonMember.UseVisualStyleBackColor = true;
            ckBxIsNonMember.CheckedChanged += ckBxIsNonMember_CheckedChanged;
            // 
            // lblOrderInfo
            // 
            lblOrderInfo.AutoSize = true;
            lblOrderInfo.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblOrderInfo.ForeColor = Color.Black;
            lblOrderInfo.Location = new Point(52, 237);
            lblOrderInfo.Name = "lblOrderInfo";
            lblOrderInfo.Size = new Size(249, 38);
            lblOrderInfo.TabIndex = 5;
            lblOrderInfo.Text = "Order Information";
            // 
            // lblCustomerRank
            // 
            lblCustomerRank.AutoSize = true;
            lblCustomerRank.ForeColor = Color.Black;
            lblCustomerRank.Location = new Point(79, 145);
            lblCustomerRank.Name = "lblCustomerRank";
            lblCustomerRank.Size = new Size(170, 32);
            lblCustomerRank.TabIndex = 6;
            lblCustomerRank.Text = "Customer rank";
            // 
            // txtBxCustomerName
            // 
            txtBxCustomerName.Location = new Point(705, 92);
            txtBxCustomerName.Margin = new Padding(3, 4, 3, 4);
            txtBxCustomerName.Name = "txtBxCustomerName";
            txtBxCustomerName.Size = new Size(352, 39);
            txtBxCustomerName.TabIndex = 10;
            // 
            // txtBxCustomerID
            // 
            txtBxCustomerID.Location = new Point(291, 92);
            txtBxCustomerID.Margin = new Padding(3, 4, 3, 4);
            txtBxCustomerID.Name = "txtBxCustomerID";
            txtBxCustomerID.Size = new Size(177, 39);
            txtBxCustomerID.TabIndex = 8;
            // 
            // txtBxCustomerRank
            // 
            txtBxCustomerRank.Location = new Point(291, 142);
            txtBxCustomerRank.Margin = new Padding(3, 4, 3, 4);
            txtBxCustomerRank.Name = "txtBxCustomerRank";
            txtBxCustomerRank.Size = new Size(177, 39);
            txtBxCustomerRank.TabIndex = 9;
            // 
            // dgvDetailedOrder
            // 
            dgvDetailedOrder.AllowUserToAddRows = false;
            dgvDetailedOrder.AllowUserToDeleteRows = false;
            dgvDetailedOrder.AllowUserToResizeColumns = false;
            dgvDetailedOrder.AllowUserToResizeRows = false;
            dgvDetailedOrder.BackgroundColor = SystemColors.Window;
            dgvDetailedOrder.BorderStyle = BorderStyle.None;
            dgvDetailedOrder.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetailedOrder.Columns.AddRange(new DataGridViewColumn[] { ColOrder, ColSalesOrderId, ColProductName, ColProductQuantity, ColUnitPrice, ColLinePrice, ColRemove });
            dgvDetailedOrder.Location = new Point(35, 600);
            dgvDetailedOrder.Margin = new Padding(3, 4, 3, 4);
            dgvDetailedOrder.Name = "dgvDetailedOrder";
            dgvDetailedOrder.RowHeadersVisible = false;
            dgvDetailedOrder.RowHeadersWidth = 62;
            dgvDetailedOrder.Size = new Size(1047, 331);
            dgvDetailedOrder.TabIndex = 8;
            dgvDetailedOrder.CellBeginEdit += dgvDetailedOrder_CellBeginEdit;
            dgvDetailedOrder.CellClick += dgvDetailedOrder_CellClick;
            dgvDetailedOrder.CellValueChanged += dgvDetailedOrder_CellValueChanged;
            dgvDetailedOrder.RowsAdded += dgvDetailedOrder_RowsAdded;
            // 
            // ColOrder
            // 
            ColOrder.FillWeight = 40F;
            ColOrder.HeaderText = "#";
            ColOrder.MinimumWidth = 8;
            ColOrder.Name = "ColOrder";
            ColOrder.ReadOnly = true;
            ColOrder.Width = 60;
            // 
            // ColSalesOrderId
            // 
            ColSalesOrderId.HeaderText = "ID";
            ColSalesOrderId.MinimumWidth = 8;
            ColSalesOrderId.Name = "ColSalesOrderId";
            ColSalesOrderId.ReadOnly = true;
            ColSalesOrderId.Width = 150;
            // 
            // ColProductName
            // 
            ColProductName.HeaderText = "Product Name";
            ColProductName.MinimumWidth = 8;
            ColProductName.Name = "ColProductName";
            ColProductName.ReadOnly = true;
            ColProductName.Width = 300;
            // 
            // ColProductQuantity
            // 
            ColProductQuantity.HeaderText = "Q";
            ColProductQuantity.MinimumWidth = 8;
            ColProductQuantity.Name = "ColProductQuantity";
            ColProductQuantity.Width = 80;
            // 
            // ColUnitPrice
            // 
            ColUnitPrice.HeaderText = "Unit Price";
            ColUnitPrice.MinimumWidth = 8;
            ColUnitPrice.Name = "ColUnitPrice";
            ColUnitPrice.ReadOnly = true;
            ColUnitPrice.Width = 180;
            // 
            // ColLinePrice
            // 
            ColLinePrice.HeaderText = "Line Price";
            ColLinePrice.MinimumWidth = 8;
            ColLinePrice.Name = "ColLinePrice";
            ColLinePrice.ReadOnly = true;
            ColLinePrice.Width = 180;
            // 
            // ColRemove
            // 
            ColRemove.FillWeight = 50F;
            ColRemove.HeaderText = "";
            ColRemove.Image = Properties.Resources.icon_remove;
            ColRemove.ImageLayout = DataGridViewImageCellLayout.Zoom;
            ColRemove.MinimumWidth = 50;
            ColRemove.Name = "ColRemove";
            ColRemove.Resizable = DataGridViewTriState.False;
            ColRemove.Width = 70;
            // 
            // lblCustomerDiscountValue
            // 
            lblCustomerDiscountValue.AutoSize = true;
            lblCustomerDiscountValue.Location = new Point(1282, 660);
            lblCustomerDiscountValue.Name = "lblCustomerDiscountValue";
            lblCustomerDiscountValue.Size = new Size(130, 32);
            lblCustomerDiscountValue.TabIndex = 9;
            lblCustomerDiscountValue.Text = "C Discount";
            // 
            // lblOrderDiscountValue
            // 
            lblOrderDiscountValue.AutoSize = true;
            lblOrderDiscountValue.Location = new Point(1282, 706);
            lblOrderDiscountValue.Name = "lblOrderDiscountValue";
            lblOrderDiscountValue.Size = new Size(133, 32);
            lblOrderDiscountValue.TabIndex = 10;
            lblOrderDiscountValue.Text = "O Discount";
            // 
            // lblFinalPrice
            // 
            lblFinalPrice.AutoSize = true;
            lblFinalPrice.Location = new Point(1282, 752);
            lblFinalPrice.Name = "lblFinalPrice";
            lblFinalPrice.Size = new Size(123, 32);
            lblFinalPrice.TabIndex = 11;
            lblFinalPrice.Text = "Final price";
            // 
            // lblBasePrice
            // 
            lblBasePrice.AutoSize = true;
            lblBasePrice.Location = new Point(1282, 614);
            lblBasePrice.Name = "lblBasePrice";
            lblBasePrice.Size = new Size(86, 32);
            lblBasePrice.TabIndex = 13;
            lblBasePrice.Text = "B Price";
            // 
            // txtBxBasePrice
            // 
            txtBxBasePrice.BackColor = SystemColors.Info;
            txtBxBasePrice.BorderStyle = BorderStyle.FixedSingle;
            txtBxBasePrice.Enabled = false;
            txtBxBasePrice.Location = new Point(1432, 611);
            txtBxBasePrice.Margin = new Padding(3, 4, 3, 4);
            txtBxBasePrice.Name = "txtBxBasePrice";
            txtBxBasePrice.ReadOnly = true;
            txtBxBasePrice.Size = new Size(199, 39);
            txtBxBasePrice.TabIndex = 14;
            // 
            // txtBxOrderDiscountValue
            // 
            txtBxOrderDiscountValue.BackColor = SystemColors.Info;
            txtBxOrderDiscountValue.BorderStyle = BorderStyle.FixedSingle;
            txtBxOrderDiscountValue.Enabled = false;
            txtBxOrderDiscountValue.Location = new Point(1432, 705);
            txtBxOrderDiscountValue.Margin = new Padding(3, 4, 3, 4);
            txtBxOrderDiscountValue.Name = "txtBxOrderDiscountValue";
            txtBxOrderDiscountValue.ReadOnly = true;
            txtBxOrderDiscountValue.Size = new Size(199, 39);
            txtBxOrderDiscountValue.TabIndex = 15;
            // 
            // txtBxCustomerDiscountValue
            // 
            txtBxCustomerDiscountValue.BackColor = SystemColors.Info;
            txtBxCustomerDiscountValue.BorderStyle = BorderStyle.FixedSingle;
            txtBxCustomerDiscountValue.Enabled = false;
            txtBxCustomerDiscountValue.Location = new Point(1432, 658);
            txtBxCustomerDiscountValue.Margin = new Padding(3, 4, 3, 4);
            txtBxCustomerDiscountValue.Name = "txtBxCustomerDiscountValue";
            txtBxCustomerDiscountValue.ReadOnly = true;
            txtBxCustomerDiscountValue.Size = new Size(199, 39);
            txtBxCustomerDiscountValue.TabIndex = 16;
            // 
            // txtBxFinalPrice
            // 
            txtBxFinalPrice.BackColor = SystemColors.Info;
            txtBxFinalPrice.BorderStyle = BorderStyle.FixedSingle;
            txtBxFinalPrice.Enabled = false;
            txtBxFinalPrice.Location = new Point(1432, 752);
            txtBxFinalPrice.Margin = new Padding(3, 4, 3, 4);
            txtBxFinalPrice.Name = "txtBxFinalPrice";
            txtBxFinalPrice.ReadOnly = true;
            txtBxFinalPrice.Size = new Size(199, 39);
            txtBxFinalPrice.TabIndex = 17;
            // 
            // btnComplete
            // 
            btnComplete.Location = new Point(1132, 825);
            btnComplete.Margin = new Padding(3, 4, 3, 4);
            btnComplete.Name = "btnComplete";
            btnComplete.Size = new Size(168, 50);
            btnComplete.TabIndex = 18;
            btnComplete.Text = "Complete";
            btnComplete.UseVisualStyleBackColor = true;
            btnComplete.Click += btnComplete_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(1480, 825);
            btnClear.Margin = new Padding(3, 4, 3, 4);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(151, 50);
            btnClear.TabIndex = 19;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // txtBxStockDate
            // 
            txtBxStockDate.Location = new Point(1282, 142);
            txtBxStockDate.Margin = new Padding(3, 4, 3, 4);
            txtBxStockDate.Name = "txtBxStockDate";
            txtBxStockDate.Size = new Size(177, 39);
            txtBxStockDate.TabIndex = 21;
            // 
            // lblProductInfo
            // 
            lblProductInfo.AutoSize = true;
            lblProductInfo.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProductInfo.ForeColor = Color.FromArgb(47, 47, 48);
            lblProductInfo.Location = new Point(1101, 39);
            lblProductInfo.Name = "lblProductInfo";
            lblProductInfo.Size = new Size(265, 38);
            lblProductInfo.TabIndex = 22;
            lblProductInfo.Text = "Product Infomation";
            lblProductInfo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblProductId
            // 
            lblProductId.AutoSize = true;
            lblProductId.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblProductId.ForeColor = Color.FromArgb(47, 47, 48);
            lblProductId.Location = new Point(1136, 100);
            lblProductId.Name = "lblProductId";
            lblProductId.Size = new Size(126, 27);
            lblProductId.TabIndex = 23;
            lblProductId.Text = "Product ID";
            // 
            // lblStockDate
            // 
            lblStockDate.AutoSize = true;
            lblStockDate.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStockDate.ForeColor = Color.FromArgb(47, 47, 48);
            lblStockDate.Location = new Point(1136, 150);
            lblStockDate.Name = "lblStockDate";
            lblStockDate.Size = new Size(129, 27);
            lblStockDate.TabIndex = 25;
            lblStockDate.Text = "Stock Date";
            // 
            // lblCustomerInfo
            // 
            lblCustomerInfo.AutoSize = true;
            lblCustomerInfo.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCustomerInfo.ForeColor = Color.FromArgb(47, 47, 48);
            lblCustomerInfo.Location = new Point(49, 39);
            lblCustomerInfo.Name = "lblCustomerInfo";
            lblCustomerInfo.Size = new Size(288, 38);
            lblCustomerInfo.TabIndex = 24;
            lblCustomerInfo.Text = "Customer Infomation";
            lblCustomerInfo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ibtnAdd
            // 
            ibtnAdd.IconChar = FontAwesome.Sharp.IconChar.Add;
            ibtnAdd.IconColor = Color.Black;
            ibtnAdd.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ibtnAdd.IconSize = 24;
            ibtnAdd.Location = new Point(1480, 142);
            ibtnAdd.Name = "ibtnAdd";
            ibtnAdd.Size = new Size(55, 39);
            ibtnAdd.TabIndex = 28;
            ibtnAdd.UseVisualStyleBackColor = true;
            ibtnAdd.Click += ibtnAdd_Click;
            // 
            // btnCalculateFinalPrice
            // 
            btnCalculateFinalPrice.Location = new Point(1306, 825);
            btnCalculateFinalPrice.Margin = new Padding(3, 4, 3, 4);
            btnCalculateFinalPrice.Name = "btnCalculateFinalPrice";
            btnCalculateFinalPrice.Size = new Size(168, 50);
            btnCalculateFinalPrice.TabIndex = 29;
            btnCalculateFinalPrice.Text = "Calculate";
            btnCalculateFinalPrice.UseVisualStyleBackColor = true;
            btnCalculateFinalPrice.Click += btnCalculateFinalPrice_Click;
            // 
            // ckBxShippingOrder
            // 
            ckBxShippingOrder.AutoSize = true;
            ckBxShippingOrder.Location = new Point(67, 285);
            ckBxShippingOrder.Margin = new Padding(3, 4, 3, 4);
            ckBxShippingOrder.Name = "ckBxShippingOrder";
            ckBxShippingOrder.Size = new Size(132, 36);
            ckBxShippingOrder.TabIndex = 30;
            ckBxShippingOrder.Text = "shipping";
            ckBxShippingOrder.UseVisualStyleBackColor = true;
            ckBxShippingOrder.CheckedChanged += ckBxShippingOrder_CheckedChanged;
            // 
            // ckBxPreorder
            // 
            ckBxPreorder.AutoSize = true;
            ckBxPreorder.Location = new Point(67, 339);
            ckBxPreorder.Margin = new Padding(3, 4, 3, 4);
            ckBxPreorder.Name = "ckBxPreorder";
            ckBxPreorder.Size = new Size(132, 36);
            ckBxPreorder.TabIndex = 31;
            ckBxPreorder.Text = "preorder";
            ckBxPreorder.UseVisualStyleBackColor = true;
            ckBxPreorder.CheckedChanged += ckBxPreorder_CheckedChanged;
            // 
            // ibtnAddPreorderProduct
            // 
            ibtnAddPreorderProduct.BackColor = Color.LightSkyBlue;
            ibtnAddPreorderProduct.FlatAppearance.BorderSize = 0;
            ibtnAddPreorderProduct.FlatStyle = FlatStyle.Flat;
            ibtnAddPreorderProduct.IconChar = FontAwesome.Sharp.IconChar.Add;
            ibtnAddPreorderProduct.IconColor = Color.Black;
            ibtnAddPreorderProduct.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ibtnAddPreorderProduct.IconSize = 24;
            ibtnAddPreorderProduct.Location = new Point(472, 335);
            ibtnAddPreorderProduct.Name = "ibtnAddPreorderProduct";
            ibtnAddPreorderProduct.Size = new Size(40, 40);
            ibtnAddPreorderProduct.TabIndex = 32;
            ibtnAddPreorderProduct.UseVisualStyleBackColor = false;
            ibtnAddPreorderProduct.Visible = false;
            ibtnAddPreorderProduct.Click += ibtnAddPreorderProduct_Click;
            // 
            // dtpDeliveryDatetime
            // 
            dtpDeliveryDatetime.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpDeliveryDatetime.Format = DateTimePickerFormat.Custom;
            dtpDeliveryDatetime.Location = new Point(218, 335);
            dtpDeliveryDatetime.Name = "dtpDeliveryDatetime";
            dtpDeliveryDatetime.Size = new Size(241, 39);
            dtpDeliveryDatetime.TabIndex = 33;
            dtpDeliveryDatetime.Validating += dtpDeliveryDatetime_Validating;
            // 
            // lblPurchaseMethod
            // 
            lblPurchaseMethod.AutoSize = true;
            lblPurchaseMethod.ForeColor = Color.Black;
            lblPurchaseMethod.Location = new Point(52, 392);
            lblPurchaseMethod.Name = "lblPurchaseMethod";
            lblPurchaseMethod.Size = new Size(200, 32);
            lblPurchaseMethod.TabIndex = 34;
            lblPurchaseMethod.Text = "Purchase method";
            // 
            // cmbBxPurchaseMethod
            // 
            cmbBxPurchaseMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBxPurchaseMethod.FormattingEnabled = true;
            cmbBxPurchaseMethod.Location = new Point(52, 427);
            cmbBxPurchaseMethod.Name = "cmbBxPurchaseMethod";
            cmbBxPurchaseMethod.Size = new Size(210, 40);
            cmbBxPurchaseMethod.TabIndex = 36;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Black;
            label1.Location = new Point(218, 300);
            label1.Name = "label1";
            label1.Size = new Size(161, 32);
            label1.TabIndex = 37;
            label1.Text = "Delivery Time";
            // 
            // SalesOrderForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1653, 944);
            Controls.Add(label1);
            Controls.Add(cmbBxPurchaseMethod);
            Controls.Add(lblPurchaseMethod);
            Controls.Add(dtpDeliveryDatetime);
            Controls.Add(ibtnAddPreorderProduct);
            Controls.Add(ckBxPreorder);
            Controls.Add(ckBxShippingOrder);
            Controls.Add(btnCalculateFinalPrice);
            Controls.Add(ibtnAdd);
            Controls.Add(lblStockDate);
            Controls.Add(txtBxCustomerName);
            Controls.Add(lblCustomerInfo);
            Controls.Add(txtBxCustomerID);
            Controls.Add(lblProductId);
            Controls.Add(txtBxCustomerRank);
            Controls.Add(lblProductInfo);
            Controls.Add(lblCustomerId);
            Controls.Add(txtBxStockDate);
            Controls.Add(lblCustomerRank);
            Controls.Add(ckBxIsNonMember);
            Controls.Add(btnClear);
            Controls.Add(lblCustomerName);
            Controls.Add(btnComplete);
            Controls.Add(txtBxFinalPrice);
            Controls.Add(txtBxCustomerDiscountValue);
            Controls.Add(txtBxOrderDiscountValue);
            Controls.Add(txtBxBasePrice);
            Controls.Add(lblBasePrice);
            Controls.Add(lblFinalPrice);
            Controls.Add(lblOrderDiscountValue);
            Controls.Add(lblCustomerDiscountValue);
            Controls.Add(dgvDetailedOrder);
            Controls.Add(lblOrderInfo);
            Controls.Add(txtBxProductId);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "SalesOrderForm";
            Text = "Sales_Form";
            ((System.ComponentModel.ISupportInitialize)dgvDetailedOrder).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtBxProductId;
        private Label lblCustomerId;
        private Label lblCustomerName;
        private CheckBox ckBxIsNonMember;
        private Label lblOrderInfo;
        private Label lblCustomerRank;
        private TextBox txtBxCustomerName;
        private TextBox txtBxCustomerID;
        private TextBox txtBxCustomerRank;
        private DataGridView dgvDetailedOrder;
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
        private TextBox txtBxStockDate;
        private Label lblProductInfo;
        private Label lblProductId;
        private Label lblStockDate;
        private Label lblCustomerInfo;
        private FontAwesome.Sharp.IconButton ibtnAdd;
        private Button btnCalculateFinalPrice;
        private CheckBox ckBxShippingOrder;
        private CheckBox ckBxPreorder;
        private FontAwesome.Sharp.IconButton ibtnAddPreorderProduct;
        private DateTimePicker dtpDeliveryDatetime;
        private Label lblPurchaseMethod;
        private DataGridViewTextBoxColumn ColOrder;
        private DataGridViewTextBoxColumn ColSalesOrderId;
        private DataGridViewTextBoxColumn ColProductName;
        private DataGridViewTextBoxColumn ColProductQuantity;
        private DataGridViewTextBoxColumn ColUnitPrice;
        private DataGridViewTextBoxColumn ColLinePrice;
        private DataGridViewImageColumn ColRemove;
        private ComboBox cmbBxPurchaseMethod;
        private Label label1;
    }
}