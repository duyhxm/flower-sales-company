namespace PL.StoreEmployee
{
    partial class ShippingInformationForm
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
            lblShippingId = new Label();
            btnNext = new Button();
            txtBxShippingId = new TextBox();
            lblShippingCompanyId = new Label();
            lblConsigneeName = new Label();
            lblConsigneePhoneNumber = new Label();
            lblDeliveryDatetime = new Label();
            lblShippingAddress = new Label();
            lblDistrict = new Label();
            lblCity = new Label();
            lblShippingCost = new Label();
            btnCancel = new Button();
            txtBxShippingCompanyId = new TextBox();
            txtBxConsigneeName = new TextBox();
            txtBxConsigneePhoneNumber = new TextBox();
            txtBxShippingAddress = new TextBox();
            txtBxShippingCost = new TextBox();
            dtpDeliveryDatetime = new DateTimePicker();
            lblShippingInfo = new Label();
            cmbBxCity = new ComboBox();
            cmbBxDistrict = new ComboBox();
            btnReturn = new Button();
            SuspendLayout();
            // 
            // lblShippingId
            // 
            lblShippingId.AutoSize = true;
            lblShippingId.Location = new Point(168, 160);
            lblShippingId.Name = "lblShippingId";
            lblShippingId.Size = new Size(139, 32);
            lblShippingId.TabIndex = 0;
            lblShippingId.Text = "Shipping ID";
            // 
            // btnNext
            // 
            btnNext.Location = new Point(356, 718);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(146, 53);
            btnNext.TabIndex = 1;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // txtBxShippingId
            // 
            txtBxShippingId.Location = new Point(492, 157);
            txtBxShippingId.Name = "txtBxShippingId";
            txtBxShippingId.Size = new Size(340, 39);
            txtBxShippingId.TabIndex = 2;
            // 
            // lblShippingCompanyId
            // 
            lblShippingCompanyId.AutoSize = true;
            lblShippingCompanyId.Location = new Point(168, 218);
            lblShippingCompanyId.Name = "lblShippingCompanyId";
            lblShippingCompanyId.Size = new Size(248, 32);
            lblShippingCompanyId.TabIndex = 3;
            lblShippingCompanyId.Text = "Shipping Company ID";
            // 
            // lblConsigneeName
            // 
            lblConsigneeName.AutoSize = true;
            lblConsigneeName.Location = new Point(168, 276);
            lblConsigneeName.Name = "lblConsigneeName";
            lblConsigneeName.Size = new Size(198, 32);
            lblConsigneeName.TabIndex = 4;
            lblConsigneeName.Text = "Consignee Name";
            // 
            // lblConsigneePhoneNumber
            // 
            lblConsigneePhoneNumber.AutoSize = true;
            lblConsigneePhoneNumber.Location = new Point(168, 334);
            lblConsigneePhoneNumber.Name = "lblConsigneePhoneNumber";
            lblConsigneePhoneNumber.Size = new Size(297, 32);
            lblConsigneePhoneNumber.TabIndex = 5;
            lblConsigneePhoneNumber.Text = "Consignee Phone Number";
            // 
            // lblDeliveryDatetime
            // 
            lblDeliveryDatetime.AutoSize = true;
            lblDeliveryDatetime.Location = new Point(168, 392);
            lblDeliveryDatetime.Name = "lblDeliveryDatetime";
            lblDeliveryDatetime.Size = new Size(206, 32);
            lblDeliveryDatetime.TabIndex = 6;
            lblDeliveryDatetime.Text = "Delivery Datetime";
            // 
            // lblShippingAddress
            // 
            lblShippingAddress.AutoSize = true;
            lblShippingAddress.Location = new Point(168, 450);
            lblShippingAddress.Name = "lblShippingAddress";
            lblShippingAddress.Size = new Size(192, 32);
            lblShippingAddress.TabIndex = 7;
            lblShippingAddress.Text = "Shipping Addess";
            // 
            // lblDistrict
            // 
            lblDistrict.AutoSize = true;
            lblDistrict.Location = new Point(168, 508);
            lblDistrict.Name = "lblDistrict";
            lblDistrict.Size = new Size(88, 32);
            lblDistrict.TabIndex = 8;
            lblDistrict.Text = "District";
            // 
            // lblCity
            // 
            lblCity.AutoSize = true;
            lblCity.Location = new Point(168, 566);
            lblCity.Name = "lblCity";
            lblCity.Size = new Size(155, 32);
            lblCity.TabIndex = 9;
            lblCity.Text = "City/Province";
            // 
            // lblShippingCost
            // 
            lblShippingCost.AutoSize = true;
            lblShippingCost.Location = new Point(168, 624);
            lblShippingCost.Name = "lblShippingCost";
            lblShippingCost.Size = new Size(163, 32);
            lblShippingCost.TabIndex = 10;
            lblShippingCost.Text = "Shipping Cost";
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(686, 718);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(146, 53);
            btnCancel.TabIndex = 11;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // txtBxShippingCompanyId
            // 
            txtBxShippingCompanyId.Location = new Point(492, 215);
            txtBxShippingCompanyId.Name = "txtBxShippingCompanyId";
            txtBxShippingCompanyId.Size = new Size(340, 39);
            txtBxShippingCompanyId.TabIndex = 12;
            // 
            // txtBxConsigneeName
            // 
            txtBxConsigneeName.Location = new Point(492, 273);
            txtBxConsigneeName.Name = "txtBxConsigneeName";
            txtBxConsigneeName.Size = new Size(340, 39);
            txtBxConsigneeName.TabIndex = 13;
            txtBxConsigneeName.Validating += txtBxConsigneeName_Validating;
            // 
            // txtBxConsigneePhoneNumber
            // 
            txtBxConsigneePhoneNumber.Location = new Point(492, 331);
            txtBxConsigneePhoneNumber.Name = "txtBxConsigneePhoneNumber";
            txtBxConsigneePhoneNumber.Size = new Size(340, 39);
            txtBxConsigneePhoneNumber.TabIndex = 14;
            txtBxConsigneePhoneNumber.Validating += txtBxConsigneePhoneNumber_Validating;
            // 
            // txtBxShippingAddress
            // 
            txtBxShippingAddress.Location = new Point(492, 447);
            txtBxShippingAddress.Name = "txtBxShippingAddress";
            txtBxShippingAddress.Size = new Size(340, 39);
            txtBxShippingAddress.TabIndex = 15;
            // 
            // txtBxShippingCost
            // 
            txtBxShippingCost.Location = new Point(492, 621);
            txtBxShippingCost.Name = "txtBxShippingCost";
            txtBxShippingCost.Size = new Size(340, 39);
            txtBxShippingCost.TabIndex = 17;
            txtBxShippingCost.Validating += txtBxShippingCost_Validating;
            // 
            // dtpDeliveryDatetime
            // 
            dtpDeliveryDatetime.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpDeliveryDatetime.Format = DateTimePickerFormat.Custom;
            dtpDeliveryDatetime.Location = new Point(492, 387);
            dtpDeliveryDatetime.Name = "dtpDeliveryDatetime";
            dtpDeliveryDatetime.Size = new Size(340, 39);
            dtpDeliveryDatetime.TabIndex = 18;
            dtpDeliveryDatetime.Validating += dtpDeliveryDatetime_Validating;
            // 
            // lblShippingInfo
            // 
            lblShippingInfo.AutoSize = true;
            lblShippingInfo.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblShippingInfo.Location = new Point(356, 33);
            lblShippingInfo.Name = "lblShippingInfo";
            lblShippingInfo.Size = new Size(330, 45);
            lblShippingInfo.TabIndex = 19;
            lblShippingInfo.Text = "Shipping Information";
            // 
            // cmbBxCity
            // 
            cmbBxCity.FormattingEnabled = true;
            cmbBxCity.Location = new Point(492, 563);
            cmbBxCity.Name = "cmbBxCity";
            cmbBxCity.Size = new Size(340, 40);
            cmbBxCity.TabIndex = 20;
            // 
            // cmbBxDistrict
            // 
            cmbBxDistrict.FormattingEnabled = true;
            cmbBxDistrict.Location = new Point(492, 505);
            cmbBxDistrict.Name = "cmbBxDistrict";
            cmbBxDistrict.Size = new Size(340, 40);
            cmbBxDistrict.TabIndex = 21;
            // 
            // btnReturn
            // 
            btnReturn.Location = new Point(523, 718);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(146, 53);
            btnReturn.TabIndex = 22;
            btnReturn.Text = "Return";
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Click += btnReturn_Click;
            // 
            // ShippingInformationForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 900);
            Controls.Add(btnReturn);
            Controls.Add(cmbBxDistrict);
            Controls.Add(cmbBxCity);
            Controls.Add(lblShippingInfo);
            Controls.Add(dtpDeliveryDatetime);
            Controls.Add(txtBxShippingCost);
            Controls.Add(txtBxShippingAddress);
            Controls.Add(txtBxConsigneePhoneNumber);
            Controls.Add(txtBxConsigneeName);
            Controls.Add(txtBxShippingCompanyId);
            Controls.Add(btnCancel);
            Controls.Add(lblShippingCost);
            Controls.Add(lblCity);
            Controls.Add(lblDistrict);
            Controls.Add(lblShippingAddress);
            Controls.Add(lblDeliveryDatetime);
            Controls.Add(lblConsigneePhoneNumber);
            Controls.Add(lblConsigneeName);
            Controls.Add(lblShippingCompanyId);
            Controls.Add(txtBxShippingId);
            Controls.Add(btnNext);
            Controls.Add(lblShippingId);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "ShippingInformationForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ShippingInformationForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblShippingId;
        private Button btnNext;
        private TextBox txtBxShippingId;
        private Label lblShippingCompanyId;
        private Label lblConsigneeName;
        private Label lblConsigneePhoneNumber;
        private Label lblDeliveryDatetime;
        private Label lblShippingAddress;
        private Label lblDistrict;
        private Label lblCity;
        private Label lblShippingCost;
        private Button btnCancel;
        private TextBox txtBxShippingCompanyId;
        private TextBox txtBxConsigneeName;
        private TextBox txtBxConsigneePhoneNumber;
        private TextBox txtBxShippingAddress;
        private TextBox txtBxShippingCost;
        private DateTimePicker dtpDeliveryDatetime;
        private Label lblShippingInfo;
        private ComboBox cmbBxCity;
        private ComboBox cmbBxDistrict;
        private Button btnReturn;
    }
}