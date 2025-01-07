namespace PL.SalesEmployee
{
    partial class AbstractProductCreationForm
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
            dgvFlowers = new DataGridView();
            ColFlowerId = new DataGridViewTextBoxColumn();
            ColFlowerName = new DataGridViewTextBoxColumn();
            ColFType = new DataGridViewTextBoxColumn();
            ColFColor = new DataGridViewTextBoxColumn();
            ColFChar = new DataGridViewTextBoxColumn();
            ColUsedFQuantity = new DataGridViewTextBoxColumn();
            ColFSelection = new DataGridViewCheckBoxColumn();
            btnCreate = new Button();
            cmbBxFType = new ComboBox();
            lblFlower = new Label();
            txtBxProductName = new TextBox();
            lblFloralColor = new Label();
            lblFloralType = new Label();
            lblFRepresentation = new Label();
            lblAccessory = new Label();
            lblProductName = new Label();
            lblFloralCharacteristic = new Label();
            dgvAccessories = new DataGridView();
            ColAccessoryId = new DataGridViewTextBoxColumn();
            ColAccessoryName = new DataGridViewTextBoxColumn();
            ColUsedAQuantity = new DataGridViewTextBoxColumn();
            ColASelection = new DataGridViewCheckBoxColumn();
            cmbBxFColor = new ComboBox();
            cmbBxFChar = new ComboBox();
            cmbBxFrs = new ComboBox();
            label1 = new Label();
            btnClear = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvFlowers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvAccessories).BeginInit();
            SuspendLayout();
            // 
            // dgvFlowers
            // 
            dgvFlowers.AllowUserToAddRows = false;
            dgvFlowers.AllowUserToDeleteRows = false;
            dgvFlowers.AllowUserToResizeColumns = false;
            dgvFlowers.AllowUserToResizeRows = false;
            dgvFlowers.BackgroundColor = SystemColors.Control;
            dgvFlowers.BorderStyle = BorderStyle.None;
            dgvFlowers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFlowers.Columns.AddRange(new DataGridViewColumn[] { ColFlowerId, ColFlowerName, ColFType, ColFColor, ColFChar, ColUsedFQuantity, ColFSelection });
            dgvFlowers.Location = new Point(12, 114);
            dgvFlowers.Name = "dgvFlowers";
            dgvFlowers.RowHeadersVisible = false;
            dgvFlowers.RowHeadersWidth = 62;
            dgvFlowers.Size = new Size(1023, 360);
            dgvFlowers.TabIndex = 0;
            // 
            // ColFlowerId
            // 
            ColFlowerId.HeaderText = "ID";
            ColFlowerId.MinimumWidth = 8;
            ColFlowerId.Name = "ColFlowerId";
            ColFlowerId.ReadOnly = true;
            ColFlowerId.Width = 120;
            // 
            // ColFlowerName
            // 
            ColFlowerName.HeaderText = "Name";
            ColFlowerName.MinimumWidth = 8;
            ColFlowerName.Name = "ColFlowerName";
            ColFlowerName.ReadOnly = true;
            ColFlowerName.Width = 250;
            // 
            // ColFType
            // 
            ColFType.HeaderText = "Type";
            ColFType.MinimumWidth = 8;
            ColFType.Name = "ColFType";
            ColFType.ReadOnly = true;
            ColFType.Width = 200;
            // 
            // ColFColor
            // 
            ColFColor.HeaderText = "Color";
            ColFColor.MinimumWidth = 8;
            ColFColor.Name = "ColFColor";
            ColFColor.ReadOnly = true;
            ColFColor.Width = 150;
            // 
            // ColFChar
            // 
            ColFChar.HeaderText = "Char";
            ColFChar.MinimumWidth = 8;
            ColFChar.Name = "ColFChar";
            ColFChar.ReadOnly = true;
            ColFChar.Width = 150;
            // 
            // ColUsedFQuantity
            // 
            ColUsedFQuantity.HeaderText = "Q";
            ColUsedFQuantity.MinimumWidth = 8;
            ColUsedFQuantity.Name = "ColUsedFQuantity";
            ColUsedFQuantity.Width = 80;
            // 
            // ColFSelection
            // 
            ColFSelection.HeaderText = "";
            ColFSelection.MinimumWidth = 8;
            ColFSelection.Name = "ColFSelection";
            ColFSelection.Width = 50;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(1121, 576);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(120, 50);
            btnCreate.TabIndex = 1;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // cmbBxFType
            // 
            cmbBxFType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBxFType.FormattingEnabled = true;
            cmbBxFType.Location = new Point(310, 61);
            cmbBxFType.Name = "cmbBxFType";
            cmbBxFType.Size = new Size(227, 40);
            cmbBxFType.TabIndex = 2;
            cmbBxFType.SelectedValueChanged += cmbBxFType_SelectedValueChanged;
            // 
            // lblFlower
            // 
            lblFlower.AutoSize = true;
            lblFlower.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFlower.Location = new Point(12, 28);
            lblFlower.Name = "lblFlower";
            lblFlower.Size = new Size(101, 38);
            lblFlower.TabIndex = 3;
            lblFlower.Text = "Flower";
            // 
            // txtBxProductName
            // 
            txtBxProductName.Location = new Point(1155, 493);
            txtBxProductName.Name = "txtBxProductName";
            txtBxProductName.Size = new Size(291, 39);
            txtBxProductName.TabIndex = 4;
            // 
            // lblFloralColor
            // 
            lblFloralColor.AutoSize = true;
            lblFloralColor.Location = new Point(543, 19);
            lblFloralColor.Name = "lblFloralColor";
            lblFloralColor.Size = new Size(136, 32);
            lblFloralColor.TabIndex = 5;
            lblFloralColor.Text = "Floral Color";
            // 
            // lblFloralType
            // 
            lblFloralType.AutoSize = true;
            lblFloralType.Location = new Point(310, 19);
            lblFloralType.Name = "lblFloralType";
            lblFloralType.Size = new Size(130, 32);
            lblFloralType.TabIndex = 6;
            lblFloralType.Text = "Floral Type";
            // 
            // lblFRepresentation
            // 
            lblFRepresentation.AutoSize = true;
            lblFRepresentation.Location = new Point(1155, 380);
            lblFRepresentation.Name = "lblFRepresentation";
            lblFRepresentation.Size = new Size(111, 32);
            lblFRepresentation.TabIndex = 7;
            lblFRepresentation.Text = "FR Name";
            // 
            // lblAccessory
            // 
            lblAccessory.AutoSize = true;
            lblAccessory.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAccessory.Location = new Point(25, 481);
            lblAccessory.Name = "lblAccessory";
            lblAccessory.Size = new Size(143, 38);
            lblAccessory.TabIndex = 8;
            lblAccessory.Text = "Accessory";
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Location = new Point(1155, 458);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(167, 32);
            lblProductName.TabIndex = 9;
            lblProductName.Text = "Product Name";
            // 
            // lblFloralCharacteristic
            // 
            lblFloralCharacteristic.AutoSize = true;
            lblFloralCharacteristic.Location = new Point(738, 19);
            lblFloralCharacteristic.Name = "lblFloralCharacteristic";
            lblFloralCharacteristic.Size = new Size(128, 32);
            lblFloralCharacteristic.TabIndex = 10;
            lblFloralCharacteristic.Text = "Floral Char";
            // 
            // dgvAccessories
            // 
            dgvAccessories.AllowUserToAddRows = false;
            dgvAccessories.AllowUserToDeleteRows = false;
            dgvAccessories.AllowUserToResizeColumns = false;
            dgvAccessories.AllowUserToResizeRows = false;
            dgvAccessories.BackgroundColor = SystemColors.Control;
            dgvAccessories.BorderStyle = BorderStyle.None;
            dgvAccessories.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAccessories.Columns.AddRange(new DataGridViewColumn[] { ColAccessoryId, ColAccessoryName, ColUsedAQuantity, ColASelection });
            dgvAccessories.Location = new Point(25, 536);
            dgvAccessories.Name = "dgvAccessories";
            dgvAccessories.RowHeadersVisible = false;
            dgvAccessories.RowHeadersWidth = 62;
            dgvAccessories.Size = new Size(529, 396);
            dgvAccessories.TabIndex = 11;
            // 
            // ColAccessoryId
            // 
            ColAccessoryId.HeaderText = "ID";
            ColAccessoryId.MinimumWidth = 8;
            ColAccessoryId.Name = "ColAccessoryId";
            ColAccessoryId.ReadOnly = true;
            ColAccessoryId.Width = 120;
            // 
            // ColAccessoryName
            // 
            ColAccessoryName.HeaderText = "Name";
            ColAccessoryName.MinimumWidth = 8;
            ColAccessoryName.Name = "ColAccessoryName";
            ColAccessoryName.ReadOnly = true;
            ColAccessoryName.Width = 250;
            // 
            // ColUsedAQuantity
            // 
            ColUsedAQuantity.HeaderText = "Q";
            ColUsedAQuantity.MinimumWidth = 8;
            ColUsedAQuantity.Name = "ColUsedAQuantity";
            ColUsedAQuantity.Width = 80;
            // 
            // ColASelection
            // 
            ColASelection.HeaderText = "";
            ColASelection.MinimumWidth = 8;
            ColASelection.Name = "ColASelection";
            ColASelection.Width = 50;
            // 
            // cmbBxFColor
            // 
            cmbBxFColor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBxFColor.FormattingEnabled = true;
            cmbBxFColor.Location = new Point(543, 61);
            cmbBxFColor.Name = "cmbBxFColor";
            cmbBxFColor.Size = new Size(189, 40);
            cmbBxFColor.TabIndex = 12;
            cmbBxFColor.SelectedValueChanged += cmbBxFColor_SelectedValueChanged;
            // 
            // cmbBxFChar
            // 
            cmbBxFChar.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBxFChar.FormattingEnabled = true;
            cmbBxFChar.Location = new Point(738, 62);
            cmbBxFChar.Name = "cmbBxFChar";
            cmbBxFChar.Size = new Size(146, 40);
            cmbBxFChar.TabIndex = 13;
            cmbBxFChar.SelectedValueChanged += cmbBxFChar_SelectedValueChanged;
            // 
            // cmbBxFrs
            // 
            cmbBxFrs.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBxFrs.FormattingEnabled = true;
            cmbBxFrs.Location = new Point(1155, 415);
            cmbBxFrs.Name = "cmbBxFrs";
            cmbBxFrs.Size = new Size(146, 40);
            cmbBxFrs.TabIndex = 14;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(1105, 327);
            label1.Name = "label1";
            label1.Size = new Size(175, 38);
            label1.TabIndex = 15;
            label1.Text = "Product Info";
            // 
            // btnClear
            // 
            btnClear.Location = new Point(1247, 576);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(120, 50);
            btnClear.TabIndex = 16;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // AbstractProductCreationForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1600, 944);
            Controls.Add(btnClear);
            Controls.Add(label1);
            Controls.Add(cmbBxFrs);
            Controls.Add(cmbBxFChar);
            Controls.Add(cmbBxFColor);
            Controls.Add(dgvAccessories);
            Controls.Add(lblFloralCharacteristic);
            Controls.Add(lblProductName);
            Controls.Add(lblAccessory);
            Controls.Add(lblFRepresentation);
            Controls.Add(lblFloralType);
            Controls.Add(lblFloralColor);
            Controls.Add(txtBxProductName);
            Controls.Add(lblFlower);
            Controls.Add(cmbBxFType);
            Controls.Add(btnCreate);
            Controls.Add(dgvFlowers);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "AbstractProductCreationForm";
            Text = "AbstractProductCreationForm";
            Load += AbstractProductCreationForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvFlowers).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvAccessories).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvFlowers;
        private Button btnCreate;
        private ComboBox cmbBxFType;
        private Label lblFlower;
        private TextBox txtBxProductName;
        private Label lblFloralColor;
        private Label lblFloralType;
        private Label lblFRepresentation;
        private Label lblAccessory;
        private Label lblProductName;
        private Label lblFloralCharacteristic;
        private DataGridViewTextBoxColumn ColFlowerId;
        private DataGridViewTextBoxColumn ColFlowerName;
        private DataGridViewTextBoxColumn ColFType;
        private DataGridViewTextBoxColumn ColFColor;
        private DataGridViewTextBoxColumn ColFChar;
        private DataGridViewTextBoxColumn ColUsedFQuantity;
        private DataGridViewCheckBoxColumn ColFSelection;
        private DataGridView dgvAccessories;
        private DataGridViewTextBoxColumn ColAccessoryId;
        private DataGridViewTextBoxColumn ColAccessoryName;
        private DataGridViewTextBoxColumn ColUsedAQuantity;
        private DataGridViewCheckBoxColumn ColASelection;
        private ComboBox cmbBxFColor;
        private ComboBox cmbBxFChar;
        private ComboBox cmbBxFrs;
        private Label label1;
        private Button btnClear;
    }
}