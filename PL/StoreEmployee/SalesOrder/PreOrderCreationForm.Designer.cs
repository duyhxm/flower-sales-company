namespace PL
{
    partial class PreOrderCreationForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            tbConCreateProduct = new TabControl();
            tpProductInfo = new TabPage();
            btnCloseCreateProduct = new Button();
            cmbBxFR = new ComboBox();
            btnClear = new Button();
            btnAddProduct = new Button();
            dgvProductDetails = new DataGridView();
            ColMaterialId = new DataGridViewTextBoxColumn();
            ColMaterialName = new DataGridViewTextBoxColumn();
            ColDecrease = new DataGridViewImageColumn();
            ColUsageQuantity = new DataGridViewTextBoxColumn();
            ColIncrease = new DataGridViewImageColumn();
            txtBxCreationQuantity = new TextBox();
            txtBxUnitPrice = new TextBox();
            txtBxProductName = new TextBox();
            lblUnitPrice = new Label();
            lblCreationQuantity = new Label();
            lblFloralRepresentation = new Label();
            lblProductName = new Label();
            lblProductDetails = new Label();
            lblProductInformation = new Label();
            tpFlower = new TabPage();
            lblFloralCharacteristic = new Label();
            lblFloralColor = new Label();
            lblFloralType = new Label();
            lblFilter = new Label();
            cmbBxFloralColor = new ComboBox();
            cmbBxFloralCharacteristic = new ComboBox();
            cmbBxFloralType = new ComboBox();
            dgvFlowerList = new DataGridView();
            ColFlowerId = new DataGridViewTextBoxColumn();
            ColFlowerName = new DataGridViewTextBoxColumn();
            ColFloralType = new DataGridViewTextBoxColumn();
            ColFloralColor = new DataGridViewTextBoxColumn();
            ColFloralCharacteristic = new DataGridViewTextBoxColumn();
            ColFlowerSelection = new DataGridViewCheckBoxColumn();
            tpAccessory = new TabPage();
            dgvAccessoryList = new DataGridView();
            ColAccessoryId = new DataGridViewTextBoxColumn();
            ColAccessoryName = new DataGridViewTextBoxColumn();
            ColAccessorySelection = new DataGridViewCheckBoxColumn();
            tbConCreateProduct.SuspendLayout();
            tpProductInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductDetails).BeginInit();
            tpFlower.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFlowerList).BeginInit();
            tpAccessory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAccessoryList).BeginInit();
            SuspendLayout();
            // 
            // tbConCreateProduct
            // 
            tbConCreateProduct.Controls.Add(tpProductInfo);
            tbConCreateProduct.Controls.Add(tpFlower);
            tbConCreateProduct.Controls.Add(tpAccessory);
            tbConCreateProduct.Dock = DockStyle.Fill;
            tbConCreateProduct.Location = new Point(0, 0);
            tbConCreateProduct.Name = "tbConCreateProduct";
            tbConCreateProduct.SelectedIndex = 0;
            tbConCreateProduct.Size = new Size(1100, 750);
            tbConCreateProduct.TabIndex = 0;
            // 
            // tpProductInfo
            // 
            tpProductInfo.Controls.Add(btnCloseCreateProduct);
            tpProductInfo.Controls.Add(cmbBxFR);
            tpProductInfo.Controls.Add(btnClear);
            tpProductInfo.Controls.Add(btnAddProduct);
            tpProductInfo.Controls.Add(dgvProductDetails);
            tpProductInfo.Controls.Add(txtBxCreationQuantity);
            tpProductInfo.Controls.Add(txtBxUnitPrice);
            tpProductInfo.Controls.Add(txtBxProductName);
            tpProductInfo.Controls.Add(lblUnitPrice);
            tpProductInfo.Controls.Add(lblCreationQuantity);
            tpProductInfo.Controls.Add(lblFloralRepresentation);
            tpProductInfo.Controls.Add(lblProductName);
            tpProductInfo.Controls.Add(lblProductDetails);
            tpProductInfo.Controls.Add(lblProductInformation);
            tpProductInfo.Location = new Point(4, 41);
            tpProductInfo.Name = "tpProductInfo";
            tpProductInfo.Padding = new Padding(3);
            tpProductInfo.Size = new Size(1092, 705);
            tpProductInfo.TabIndex = 0;
            tpProductInfo.Text = "Product Info";
            tpProductInfo.UseVisualStyleBackColor = true;
            // 
            // btnCloseCreateProduct
            // 
            btnCloseCreateProduct.Location = new Point(808, 494);
            btnCloseCreateProduct.Name = "btnCloseCreateProduct";
            btnCloseCreateProduct.Size = new Size(120, 50);
            btnCloseCreateProduct.TabIndex = 33;
            btnCloseCreateProduct.Text = "Close";
            btnCloseCreateProduct.UseVisualStyleBackColor = true;
            btnCloseCreateProduct.Click += btnClose_Click;
            // 
            // cmbBxFR
            // 
            cmbBxFR.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBxFR.FormattingEnabled = true;
            cmbBxFR.Location = new Point(659, 88);
            cmbBxFR.Name = "cmbBxFR";
            cmbBxFR.Size = new Size(187, 40);
            cmbBxFR.TabIndex = 32;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(808, 438);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(120, 50);
            btnClear.TabIndex = 31;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnAddProduct
            // 
            btnAddProduct.Location = new Point(808, 382);
            btnAddProduct.Name = "btnAddProduct";
            btnAddProduct.Size = new Size(120, 50);
            btnAddProduct.TabIndex = 30;
            btnAddProduct.Text = "Add";
            btnAddProduct.UseVisualStyleBackColor = true;
            btnAddProduct.Click += btnAdd_Click;
            // 
            // dgvProductDetails
            // 
            dgvProductDetails.AllowUserToAddRows = false;
            dgvProductDetails.AllowUserToDeleteRows = false;
            dgvProductDetails.AllowUserToResizeColumns = false;
            dgvProductDetails.BackgroundColor = SystemColors.Window;
            dgvProductDetails.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvProductDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvProductDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductDetails.Columns.AddRange(new DataGridViewColumn[] { ColMaterialId, ColMaterialName, ColDecrease, ColUsageQuantity, ColIncrease });
            dgvProductDetails.Location = new Point(89, 263);
            dgvProductDetails.Name = "dgvProductDetails";
            dgvProductDetails.RowHeadersVisible = false;
            dgvProductDetails.RowHeadersWidth = 62;
            dgvProductDetails.Size = new Size(674, 386);
            dgvProductDetails.TabIndex = 29;
            dgvProductDetails.CellClick += dgvProductDetails_CellClick;
            dgvProductDetails.CellValueChanged += dgvProductDetails_CellValueChanged;
            dgvProductDetails.RowsAdded += dgvProductDetails_RowsAdded;
            dgvProductDetails.RowsRemoved += dgvProductDetails_RowsRemoved;
            // 
            // ColMaterialId
            // 
            ColMaterialId.HeaderText = "ID";
            ColMaterialId.MinimumWidth = 8;
            ColMaterialId.Name = "ColMaterialId";
            ColMaterialId.ReadOnly = true;
            ColMaterialId.Width = 150;
            // 
            // ColMaterialName
            // 
            ColMaterialName.HeaderText = "Material Name";
            ColMaterialName.MinimumWidth = 8;
            ColMaterialName.Name = "ColMaterialName";
            ColMaterialName.ReadOnly = true;
            ColMaterialName.Width = 250;
            // 
            // ColDecrease
            // 
            ColDecrease.HeaderText = "";
            ColDecrease.Image = Properties.Resources.minus_sign;
            ColDecrease.MinimumWidth = 8;
            ColDecrease.Name = "ColDecrease";
            ColDecrease.Width = 50;
            // 
            // ColUsageQuantity
            // 
            ColUsageQuantity.HeaderText = "Q";
            ColUsageQuantity.MinimumWidth = 8;
            ColUsageQuantity.Name = "ColUsageQuantity";
            ColUsageQuantity.Width = 80;
            // 
            // ColIncrease
            // 
            ColIncrease.HeaderText = "";
            ColIncrease.Image = Properties.Resources.addition;
            ColIncrease.MinimumWidth = 8;
            ColIncrease.Name = "ColIncrease";
            ColIncrease.Width = 50;
            // 
            // txtBxCreationQuantity
            // 
            txtBxCreationQuantity.BorderStyle = BorderStyle.FixedSingle;
            txtBxCreationQuantity.Location = new Point(659, 133);
            txtBxCreationQuantity.Name = "txtBxCreationQuantity";
            txtBxCreationQuantity.Size = new Size(187, 39);
            txtBxCreationQuantity.TabIndex = 26;
            txtBxCreationQuantity.TextAlign = HorizontalAlignment.Center;
            // 
            // txtBxUnitPrice
            // 
            txtBxUnitPrice.BackColor = SystemColors.Info;
            txtBxUnitPrice.BorderStyle = BorderStyle.FixedSingle;
            txtBxUnitPrice.Enabled = false;
            txtBxUnitPrice.Location = new Point(659, 178);
            txtBxUnitPrice.Name = "txtBxUnitPrice";
            txtBxUnitPrice.Size = new Size(187, 39);
            txtBxUnitPrice.TabIndex = 25;
            txtBxUnitPrice.TextAlign = HorizontalAlignment.Right;
            // 
            // txtBxProductName
            // 
            txtBxProductName.BorderStyle = BorderStyle.FixedSingle;
            txtBxProductName.Location = new Point(225, 111);
            txtBxProductName.Name = "txtBxProductName";
            txtBxProductName.Size = new Size(291, 39);
            txtBxProductName.TabIndex = 24;
            // 
            // lblUnitPrice
            // 
            lblUnitPrice.AutoSize = true;
            lblUnitPrice.Location = new Point(524, 180);
            lblUnitPrice.Name = "lblUnitPrice";
            lblUnitPrice.Size = new Size(116, 32);
            lblUnitPrice.TabIndex = 23;
            lblUnitPrice.Text = "Unit Price";
            // 
            // lblCreationQuantity
            // 
            lblCreationQuantity.AutoSize = true;
            lblCreationQuantity.Location = new Point(608, 135);
            lblCreationQuantity.Name = "lblCreationQuantity";
            lblCreationQuantity.Size = new Size(32, 32);
            lblCreationQuantity.TabIndex = 22;
            lblCreationQuantity.Text = "Q";
            // 
            // lblFloralRepresentation
            // 
            lblFloralRepresentation.AutoSize = true;
            lblFloralRepresentation.Location = new Point(600, 91);
            lblFloralRepresentation.Name = "lblFloralRepresentation";
            lblFloralRepresentation.Size = new Size(40, 32);
            lblFloralRepresentation.TabIndex = 21;
            lblFloralRepresentation.Text = "FR";
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Location = new Point(52, 113);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(167, 32);
            lblProductName.TabIndex = 20;
            lblProductName.Text = "Product Name";
            // 
            // lblProductDetails
            // 
            lblProductDetails.AutoSize = true;
            lblProductDetails.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProductDetails.Location = new Point(48, 191);
            lblProductDetails.Name = "lblProductDetails";
            lblProductDetails.Size = new Size(210, 38);
            lblProductDetails.TabIndex = 19;
            lblProductDetails.Text = "Product Details";
            // 
            // lblProductInformation
            // 
            lblProductInformation.AutoSize = true;
            lblProductInformation.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProductInformation.Location = new Point(52, 51);
            lblProductInformation.Name = "lblProductInformation";
            lblProductInformation.Size = new Size(275, 38);
            lblProductInformation.TabIndex = 18;
            lblProductInformation.Text = "Product Information";
            // 
            // tpFlower
            // 
            tpFlower.Controls.Add(lblFloralCharacteristic);
            tpFlower.Controls.Add(lblFloralColor);
            tpFlower.Controls.Add(lblFloralType);
            tpFlower.Controls.Add(lblFilter);
            tpFlower.Controls.Add(cmbBxFloralColor);
            tpFlower.Controls.Add(cmbBxFloralCharacteristic);
            tpFlower.Controls.Add(cmbBxFloralType);
            tpFlower.Controls.Add(dgvFlowerList);
            tpFlower.Location = new Point(4, 41);
            tpFlower.Name = "tpFlower";
            tpFlower.Padding = new Padding(3);
            tpFlower.Size = new Size(1092, 705);
            tpFlower.TabIndex = 1;
            tpFlower.Text = "Flower";
            tpFlower.UseVisualStyleBackColor = true;
            // 
            // lblFloralCharacteristic
            // 
            lblFloralCharacteristic.AutoSize = true;
            lblFloralCharacteristic.Font = new Font("Segoe UI", 10F);
            lblFloralCharacteristic.Location = new Point(592, 59);
            lblFloralCharacteristic.Name = "lblFloralCharacteristic";
            lblFloralCharacteristic.Size = new Size(183, 28);
            lblFloralCharacteristic.TabIndex = 15;
            lblFloralCharacteristic.Text = "Floral Characteristic";
            // 
            // lblFloralColor
            // 
            lblFloralColor.AutoSize = true;
            lblFloralColor.Font = new Font("Segoe UI", 10F);
            lblFloralColor.Location = new Point(390, 59);
            lblFloralColor.Name = "lblFloralColor";
            lblFloralColor.Size = new Size(114, 28);
            lblFloralColor.TabIndex = 14;
            lblFloralColor.Text = "Floral Color";
            // 
            // lblFloralType
            // 
            lblFloralType.AutoSize = true;
            lblFloralType.Font = new Font("Segoe UI", 10F);
            lblFloralType.Location = new Point(187, 59);
            lblFloralType.Name = "lblFloralType";
            lblFloralType.Size = new Size(105, 28);
            lblFloralType.TabIndex = 13;
            lblFloralType.Text = "Floral type";
            // 
            // lblFilter
            // 
            lblFilter.AutoSize = true;
            lblFilter.Location = new Point(94, 97);
            lblFilter.Name = "lblFilter";
            lblFilter.Size = new Size(67, 32);
            lblFilter.TabIndex = 12;
            lblFilter.Text = "Filter";
            // 
            // cmbBxFloralColor
            // 
            cmbBxFloralColor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBxFloralColor.FormattingEnabled = true;
            cmbBxFloralColor.Items.AddRange(new object[] { "None" });
            cmbBxFloralColor.Location = new Point(390, 94);
            cmbBxFloralColor.Name = "cmbBxFloralColor";
            cmbBxFloralColor.Size = new Size(178, 40);
            cmbBxFloralColor.TabIndex = 11;
            cmbBxFloralColor.SelectedIndexChanged += cmbBxFloralColor_SelectedIndexChanged;
            // 
            // cmbBxFloralCharacteristic
            // 
            cmbBxFloralCharacteristic.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBxFloralCharacteristic.FormattingEnabled = true;
            cmbBxFloralCharacteristic.Items.AddRange(new object[] { "None" });
            cmbBxFloralCharacteristic.Location = new Point(592, 94);
            cmbBxFloralCharacteristic.Name = "cmbBxFloralCharacteristic";
            cmbBxFloralCharacteristic.Size = new Size(178, 40);
            cmbBxFloralCharacteristic.TabIndex = 10;
            cmbBxFloralCharacteristic.SelectedIndexChanged += cmbBxFloralCharacteristic_SelectedIndexChanged;
            // 
            // cmbBxFloralType
            // 
            cmbBxFloralType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBxFloralType.FormattingEnabled = true;
            cmbBxFloralType.Items.AddRange(new object[] { "None" });
            cmbBxFloralType.Location = new Point(187, 94);
            cmbBxFloralType.Name = "cmbBxFloralType";
            cmbBxFloralType.Size = new Size(178, 40);
            cmbBxFloralType.TabIndex = 9;
            cmbBxFloralType.SelectedIndexChanged += cmbBxFloralType_SelectedIndexChanged;
            // 
            // dgvFlowerList
            // 
            dgvFlowerList.AllowUserToAddRows = false;
            dgvFlowerList.AllowUserToDeleteRows = false;
            dgvFlowerList.AllowUserToOrderColumns = true;
            dgvFlowerList.AllowUserToResizeColumns = false;
            dgvFlowerList.AllowUserToResizeRows = false;
            dgvFlowerList.BackgroundColor = SystemColors.Window;
            dgvFlowerList.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvFlowerList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvFlowerList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFlowerList.Columns.AddRange(new DataGridViewColumn[] { ColFlowerId, ColFlowerName, ColFloralType, ColFloralColor, ColFloralCharacteristic, ColFlowerSelection });
            dgvFlowerList.Location = new Point(34, 189);
            dgvFlowerList.Name = "dgvFlowerList";
            dgvFlowerList.RowHeadersVisible = false;
            dgvFlowerList.RowHeadersWidth = 62;
            dgvFlowerList.Size = new Size(982, 450);
            dgvFlowerList.TabIndex = 8;
            dgvFlowerList.CellValueChanged += dgvFlowerList_CellValueChanged;
            dgvFlowerList.CurrentCellDirtyStateChanged += dgvFlowerList_CurrentCellDirtyStateChanged;
            // 
            // ColFlowerId
            // 
            ColFlowerId.FillWeight = 50F;
            ColFlowerId.HeaderText = "ID";
            ColFlowerId.MinimumWidth = 8;
            ColFlowerId.Name = "ColFlowerId";
            ColFlowerId.ReadOnly = true;
            ColFlowerId.Width = 150;
            // 
            // ColFlowerName
            // 
            ColFlowerName.HeaderText = "Flower Name";
            ColFlowerName.MinimumWidth = 8;
            ColFlowerName.Name = "ColFlowerName";
            ColFlowerName.ReadOnly = true;
            ColFlowerName.Width = 250;
            // 
            // ColFloralType
            // 
            ColFloralType.HeaderText = "Floral Type";
            ColFloralType.MinimumWidth = 8;
            ColFloralType.Name = "ColFloralType";
            ColFloralType.ReadOnly = true;
            ColFloralType.Width = 200;
            // 
            // ColFloralColor
            // 
            ColFloralColor.FillWeight = 50F;
            ColFloralColor.HeaderText = "Color";
            ColFloralColor.MinimumWidth = 8;
            ColFloralColor.Name = "ColFloralColor";
            ColFloralColor.ReadOnly = true;
            ColFloralColor.Width = 150;
            // 
            // ColFloralCharacteristic
            // 
            ColFloralCharacteristic.FillWeight = 50F;
            ColFloralCharacteristic.HeaderText = "Char";
            ColFloralCharacteristic.MinimumWidth = 8;
            ColFloralCharacteristic.Name = "ColFloralCharacteristic";
            ColFloralCharacteristic.ReadOnly = true;
            ColFloralCharacteristic.Width = 150;
            // 
            // ColFlowerSelection
            // 
            ColFlowerSelection.FillWeight = 50F;
            ColFlowerSelection.HeaderText = "";
            ColFlowerSelection.MinimumWidth = 8;
            ColFlowerSelection.Name = "ColFlowerSelection";
            ColFlowerSelection.Width = 60;
            // 
            // tpAccessory
            // 
            tpAccessory.Controls.Add(dgvAccessoryList);
            tpAccessory.Location = new Point(4, 41);
            tpAccessory.Name = "tpAccessory";
            tpAccessory.Size = new Size(1092, 705);
            tpAccessory.TabIndex = 2;
            tpAccessory.Text = "Accessory";
            tpAccessory.UseVisualStyleBackColor = true;
            // 
            // dgvAccessoryList
            // 
            dgvAccessoryList.AllowUserToAddRows = false;
            dgvAccessoryList.AllowUserToDeleteRows = false;
            dgvAccessoryList.AllowUserToResizeColumns = false;
            dgvAccessoryList.AllowUserToResizeRows = false;
            dgvAccessoryList.BackgroundColor = SystemColors.Window;
            dgvAccessoryList.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvAccessoryList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvAccessoryList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAccessoryList.Columns.AddRange(new DataGridViewColumn[] { ColAccessoryId, ColAccessoryName, ColAccessorySelection });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Window;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.MenuHighlight;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvAccessoryList.DefaultCellStyle = dataGridViewCellStyle4;
            dgvAccessoryList.Location = new Point(135, 115);
            dgvAccessoryList.Name = "dgvAccessoryList";
            dgvAccessoryList.RowHeadersVisible = false;
            dgvAccessoryList.RowHeadersWidth = 62;
            dgvAccessoryList.Size = new Size(461, 481);
            dgvAccessoryList.TabIndex = 1;
            dgvAccessoryList.CellClick += dgvAccessoryList_CellClick;
            dgvAccessoryList.CellValueChanged += dgvAccessoryList_CellValueChanged;
            dgvAccessoryList.CurrentCellDirtyStateChanged += dgvAccessoryList_CurrentCellDirtyStateChanged;
            // 
            // ColAccessoryId
            // 
            ColAccessoryId.HeaderText = "ID";
            ColAccessoryId.MinimumWidth = 8;
            ColAccessoryId.Name = "ColAccessoryId";
            ColAccessoryId.ReadOnly = true;
            ColAccessoryId.Resizable = DataGridViewTriState.True;
            ColAccessoryId.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColAccessoryId.Width = 150;
            // 
            // ColAccessoryName
            // 
            ColAccessoryName.HeaderText = "Name";
            ColAccessoryName.MinimumWidth = 8;
            ColAccessoryName.Name = "ColAccessoryName";
            ColAccessoryName.ReadOnly = true;
            ColAccessoryName.Width = 200;
            // 
            // ColAccessorySelection
            // 
            ColAccessorySelection.FillWeight = 30F;
            ColAccessorySelection.HeaderText = "";
            ColAccessorySelection.MinimumWidth = 8;
            ColAccessorySelection.Name = "ColAccessorySelection";
            ColAccessorySelection.Width = 50;
            // 
            // PreOrderCreationForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 750);
            Controls.Add(tbConCreateProduct);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "PreOrderCreationForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "OrderCreationForm";
            Load += PreOrderCreationForm_Load;
            tbConCreateProduct.ResumeLayout(false);
            tpProductInfo.ResumeLayout(false);
            tpProductInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductDetails).EndInit();
            tpFlower.ResumeLayout(false);
            tpFlower.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFlowerList).EndInit();
            tpAccessory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAccessoryList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tbConCreateProduct;
        private TabPage tpProductInfo;
        private TabPage tpFlower;
        private TabPage tpAccessory;
        private ComboBox cmbBxFR;
        private Button btnClear;
        private Button btnAddProduct;
        private DataGridView dgvProductDetails;
        private DataGridViewTextBoxColumn ColMaterialId;
        private DataGridViewTextBoxColumn ColMaterialName;
        private DataGridViewImageColumn ColDecrease;
        private DataGridViewTextBoxColumn ColUsageQuantity;
        private DataGridViewImageColumn ColIncrease;
        private TextBox txtBxCreationQuantity;
        private TextBox txtBxUnitPrice;
        private TextBox txtBxProductName;
        private Label lblUnitPrice;
        private Label lblCreationQuantity;
        private Label lblFloralRepresentation;
        private Label lblProductName;
        private Label lblProductDetails;
        private Label lblProductInformation;
        private Label lblFloralCharacteristic;
        private Label lblFloralColor;
        private Label lblFloralType;
        private Label lblFilter;
        private ComboBox cmbBxFloralColor;
        private ComboBox cmbBxFloralCharacteristic;
        private ComboBox cmbBxFloralType;
        private DataGridView dgvFlowerList;
        private DataGridView dgvAccessoryList;
        private Button btnCloseCreateProduct;
        private DataGridViewTextBoxColumn ColFlowerId;
        private DataGridViewTextBoxColumn ColFlowerName;
        private DataGridViewTextBoxColumn ColFloralType;
        private DataGridViewTextBoxColumn ColFloralColor;
        private DataGridViewTextBoxColumn ColFloralCharacteristic;
        private DataGridViewCheckBoxColumn ColFlowerSelection;
        private DataGridViewTextBoxColumn ColAccessoryId;
        private DataGridViewTextBoxColumn ColAccessoryName;
        private DataGridViewCheckBoxColumn ColAccessorySelection;
    }
}