namespace PL.StoreEmployee.OrderHistory
{
    partial class ExtraOrderInfoForm
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
            dgvDetailedOrder = new DataGridView();
            ColProductId = new DataGridViewTextBoxColumn();
            ColProductName = new DataGridViewTextBoxColumn();
            ColUsedQuantity = new DataGridViewTextBoxColumn();
            ColDetailedProduct = new DataGridViewImageColumn();
            txtBxCreatedDateTime = new TextBox();
            lblCreatedDateTime = new Label();
            lblShippingCompanyName = new Label();
            lblPhoneNumber = new Label();
            lblCustomerName = new Label();
            lblAddress = new Label();
            lblDeliveryTime = new Label();
            lblOrderTime = new Label();
            txtBxCustomerName = new TextBox();
            txtBxCustomerPhoneNumber = new TextBox();
            txtBxDeliveryTime = new TextBox();
            txtBxAddress = new TextBox();
            dtpOrderDateTime = new DateTimePicker();
            btnSave = new Button();
            btnCancel = new Button();
            txtBxDistrict = new TextBox();
            txtBxCity = new TextBox();
            lblDistrict = new Label();
            lblCity = new Label();
            btnOk = new Button();
            cmbBxShippingCompany = new ComboBox();
            label1 = new Label();
            lblShippingInfo = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvDetailedOrder).BeginInit();
            SuspendLayout();
            // 
            // dgvDetailedOrder
            // 
            dgvDetailedOrder.AllowUserToAddRows = false;
            dgvDetailedOrder.AllowUserToDeleteRows = false;
            dgvDetailedOrder.AllowUserToResizeColumns = false;
            dgvDetailedOrder.AllowUserToResizeRows = false;
            dgvDetailedOrder.BackgroundColor = SystemColors.Control;
            dgvDetailedOrder.BorderStyle = BorderStyle.None;
            dgvDetailedOrder.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetailedOrder.Columns.AddRange(new DataGridViewColumn[] { ColProductId, ColProductName, ColUsedQuantity, ColDetailedProduct });
            dgvDetailedOrder.Location = new Point(23, 153);
            dgvDetailedOrder.Name = "dgvDetailedOrder";
            dgvDetailedOrder.RowHeadersVisible = false;
            dgvDetailedOrder.RowHeadersWidth = 62;
            dgvDetailedOrder.Size = new Size(625, 414);
            dgvDetailedOrder.TabIndex = 0;
            dgvDetailedOrder.CellClick += dgvDetailedOrder_CellClick;
            // 
            // ColProductId
            // 
            ColProductId.HeaderText = "ID";
            ColProductId.MinimumWidth = 8;
            ColProductId.Name = "ColProductId";
            ColProductId.ReadOnly = true;
            ColProductId.Width = 150;
            // 
            // ColProductName
            // 
            ColProductName.HeaderText = "Name";
            ColProductName.MinimumWidth = 8;
            ColProductName.Name = "ColProductName";
            ColProductName.ReadOnly = true;
            ColProductName.Width = 300;
            // 
            // ColUsedQuantity
            // 
            ColUsedQuantity.HeaderText = "Q";
            ColUsedQuantity.MinimumWidth = 8;
            ColUsedQuantity.Name = "ColUsedQuantity";
            ColUsedQuantity.ReadOnly = true;
            ColUsedQuantity.Width = 80;
            // 
            // ColDetailedProduct
            // 
            ColDetailedProduct.FillWeight = 50F;
            ColDetailedProduct.HeaderText = "";
            ColDetailedProduct.Image = Properties.Resources.details;
            ColDetailedProduct.ImageLayout = DataGridViewImageCellLayout.Zoom;
            ColDetailedProduct.MinimumWidth = 8;
            ColDetailedProduct.Name = "ColDetailedProduct";
            ColDetailedProduct.Width = 50;
            // 
            // txtBxCreatedDateTime
            // 
            txtBxCreatedDateTime.Enabled = false;
            txtBxCreatedDateTime.Location = new Point(186, 24);
            txtBxCreatedDateTime.Name = "txtBxCreatedDateTime";
            txtBxCreatedDateTime.ReadOnly = true;
            txtBxCreatedDateTime.Size = new Size(251, 39);
            txtBxCreatedDateTime.TabIndex = 1;
            // 
            // lblCreatedDateTime
            // 
            lblCreatedDateTime.AutoSize = true;
            lblCreatedDateTime.Location = new Point(23, 27);
            lblCreatedDateTime.Name = "lblCreatedDateTime";
            lblCreatedDateTime.Size = new Size(157, 32);
            lblCreatedDateTime.TabIndex = 2;
            lblCreatedDateTime.Text = "Created Time";
            // 
            // lblShippingCompanyName
            // 
            lblShippingCompanyName.AutoSize = true;
            lblShippingCompanyName.Location = new Point(769, 210);
            lblShippingCompanyName.Name = "lblShippingCompanyName";
            lblShippingCompanyName.Size = new Size(166, 32);
            lblShippingCompanyName.TabIndex = 3;
            lblShippingCompanyName.Text = "Shipping Com";
            // 
            // lblPhoneNumber
            // 
            lblPhoneNumber.AutoSize = true;
            lblPhoneNumber.Location = new Point(769, 428);
            lblPhoneNumber.Name = "lblPhoneNumber";
            lblPhoneNumber.Size = new Size(177, 32);
            lblPhoneNumber.TabIndex = 5;
            lblPhoneNumber.Text = "Phone Number";
            // 
            // lblCustomerName
            // 
            lblCustomerName.AutoSize = true;
            lblCustomerName.Location = new Point(769, 370);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(188, 32);
            lblCustomerName.TabIndex = 6;
            lblCustomerName.Text = "Customer Name";
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(769, 483);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(98, 32);
            lblAddress.TabIndex = 7;
            lblAddress.Text = "Address";
            // 
            // lblDeliveryTime
            // 
            lblDeliveryTime.AutoSize = true;
            lblDeliveryTime.Location = new Point(769, 314);
            lblDeliveryTime.Name = "lblDeliveryTime";
            lblDeliveryTime.Size = new Size(161, 32);
            lblDeliveryTime.TabIndex = 8;
            lblDeliveryTime.Text = "Delivery Time";
            // 
            // lblOrderTime
            // 
            lblOrderTime.AutoSize = true;
            lblOrderTime.Location = new Point(769, 257);
            lblOrderTime.Name = "lblOrderTime";
            lblOrderTime.Size = new Size(135, 32);
            lblOrderTime.TabIndex = 9;
            lblOrderTime.Text = "Order Time";
            // 
            // txtBxCustomerName
            // 
            txtBxCustomerName.Enabled = false;
            txtBxCustomerName.Location = new Point(975, 367);
            txtBxCustomerName.Name = "txtBxCustomerName";
            txtBxCustomerName.ReadOnly = true;
            txtBxCustomerName.Size = new Size(251, 39);
            txtBxCustomerName.TabIndex = 10;
            // 
            // txtBxCustomerPhoneNumber
            // 
            txtBxCustomerPhoneNumber.Enabled = false;
            txtBxCustomerPhoneNumber.Location = new Point(976, 425);
            txtBxCustomerPhoneNumber.Name = "txtBxCustomerPhoneNumber";
            txtBxCustomerPhoneNumber.ReadOnly = true;
            txtBxCustomerPhoneNumber.Size = new Size(251, 39);
            txtBxCustomerPhoneNumber.TabIndex = 11;
            // 
            // txtBxDeliveryTime
            // 
            txtBxDeliveryTime.Enabled = false;
            txtBxDeliveryTime.Location = new Point(975, 311);
            txtBxDeliveryTime.Name = "txtBxDeliveryTime";
            txtBxDeliveryTime.ReadOnly = true;
            txtBxDeliveryTime.Size = new Size(251, 39);
            txtBxDeliveryTime.TabIndex = 12;
            // 
            // txtBxAddress
            // 
            txtBxAddress.Location = new Point(975, 480);
            txtBxAddress.Name = "txtBxAddress";
            txtBxAddress.Size = new Size(251, 39);
            txtBxAddress.TabIndex = 13;
            // 
            // dtpOrderDateTime
            // 
            dtpOrderDateTime.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpOrderDateTime.Format = DateTimePickerFormat.Custom;
            dtpOrderDateTime.Location = new Point(975, 252);
            dtpOrderDateTime.Name = "dtpOrderDateTime";
            dtpOrderDateTime.Size = new Size(252, 39);
            dtpOrderDateTime.TabIndex = 14;
            dtpOrderDateTime.Validating += dtpOrderDateTime_Validating;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(935, 684);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(108, 45);
            btnSave.TabIndex = 15;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(1049, 684);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(119, 44);
            btnCancel.TabIndex = 16;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // txtBxDistrict
            // 
            txtBxDistrict.Location = new Point(976, 531);
            txtBxDistrict.Name = "txtBxDistrict";
            txtBxDistrict.Size = new Size(251, 39);
            txtBxDistrict.TabIndex = 17;
            // 
            // txtBxCity
            // 
            txtBxCity.Location = new Point(976, 589);
            txtBxCity.Name = "txtBxCity";
            txtBxCity.Size = new Size(251, 39);
            txtBxCity.TabIndex = 18;
            // 
            // lblDistrict
            // 
            lblDistrict.AutoSize = true;
            lblDistrict.Location = new Point(769, 534);
            lblDistrict.Name = "lblDistrict";
            lblDistrict.Size = new Size(88, 32);
            lblDistrict.TabIndex = 19;
            lblDistrict.Text = "District";
            // 
            // lblCity
            // 
            lblCity.AutoSize = true;
            lblCity.Location = new Point(769, 592);
            lblCity.Name = "lblCity";
            lblCity.Size = new Size(55, 32);
            lblCity.TabIndex = 20;
            lblCity.Text = "City";
            // 
            // btnOk
            // 
            btnOk.Location = new Point(548, 679);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(121, 44);
            btnOk.TabIndex = 21;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // cmbBxShippingCompany
            // 
            cmbBxShippingCompany.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBxShippingCompany.FormattingEnabled = true;
            cmbBxShippingCompany.Location = new Point(974, 202);
            cmbBxShippingCompany.Name = "cmbBxShippingCompany";
            cmbBxShippingCompany.Size = new Size(252, 40);
            cmbBxShippingCompany.TabIndex = 22;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(23, 105);
            label1.Name = "label1";
            label1.Size = new Size(200, 38);
            label1.TabIndex = 23;
            label1.Text = "Used Products";
            // 
            // lblShippingInfo
            // 
            lblShippingInfo.AutoSize = true;
            lblShippingInfo.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblShippingInfo.Location = new Point(935, 108);
            lblShippingInfo.Name = "lblShippingInfo";
            lblShippingInfo.Size = new Size(188, 38);
            lblShippingInfo.TabIndex = 24;
            lblShippingInfo.Text = "Shipping Info";
            // 
            // ExtraOrderInfoForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1600, 800);
            Controls.Add(lblShippingInfo);
            Controls.Add(label1);
            Controls.Add(cmbBxShippingCompany);
            Controls.Add(btnOk);
            Controls.Add(lblCity);
            Controls.Add(lblDistrict);
            Controls.Add(txtBxCity);
            Controls.Add(txtBxDistrict);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(dtpOrderDateTime);
            Controls.Add(txtBxAddress);
            Controls.Add(txtBxDeliveryTime);
            Controls.Add(txtBxCustomerPhoneNumber);
            Controls.Add(txtBxCustomerName);
            Controls.Add(lblOrderTime);
            Controls.Add(lblDeliveryTime);
            Controls.Add(lblAddress);
            Controls.Add(lblCustomerName);
            Controls.Add(lblPhoneNumber);
            Controls.Add(lblShippingCompanyName);
            Controls.Add(lblCreatedDateTime);
            Controls.Add(txtBxCreatedDateTime);
            Controls.Add(dgvDetailedOrder);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "ExtraOrderInfoForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ExtraOrderInfoForm";
            Load += ExtraOrderInfoForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDetailedOrder).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvDetailedOrder;
        private TextBox txtBxCreatedDateTime;
        private Label lblCreatedDateTime;
        private Label lblShippingCompanyName;
        private Label lblPhoneNumber;
        private Label lblCustomerName;
        private Label lblAddress;
        private Label lblDeliveryTime;
        private Label lblOrderTime;
        private TextBox txtBxCustomerName;
        private TextBox txtBxCustomerPhoneNumber;
        private TextBox txtBxDeliveryTime;
        private TextBox txtBxAddress;
        private DateTimePicker dtpOrderDateTime;
        private Button btnSave;
        private Button btnCancel;
        private TextBox txtBxDistrict;
        private TextBox txtBxCity;
        private Label lblDistrict;
        private Label lblCity;
        private Button btnOk;
        private ComboBox cmbBxShippingCompany;
        private DataGridViewTextBoxColumn ColProductId;
        private DataGridViewTextBoxColumn ColProductName;
        private DataGridViewTextBoxColumn ColUsedQuantity;
        private DataGridViewImageColumn ColDetailedProduct;
        private Label label1;
        private Label lblShippingInfo;
    }
}