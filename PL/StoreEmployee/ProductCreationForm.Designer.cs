namespace PL
{
    partial class ProductCreationForm
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
            tbCtrlProductCreationNavigation = new TabControl();
            tabProductInformation = new TabPage();
            cmbBxFloralRepresentations = new ComboBox();
            btnClear = new Button();
            btnAdd = new Button();
            dgvProductDetails = new DataGridView();
            ColMaterialId = new DataGridViewTextBoxColumn();
            ColMaterialName = new DataGridViewTextBoxColumn();
            ColDecrease = new DataGridViewImageColumn();
            ColUsageQuantity = new DataGridViewTextBoxColumn();
            ColIncrease = new DataGridViewImageColumn();
            ibtnDecrease = new FontAwesome.Sharp.IconButton();
            ibtnIncrease = new FontAwesome.Sharp.IconButton();
            txtBxCreationQuantity = new TextBox();
            txtBxUnitPrice = new TextBox();
            txtBxProductName = new TextBox();
            txtBxProductId = new TextBox();
            lblProductId = new Label();
            lblUnitPrice = new Label();
            lblCreationQuantity = new Label();
            lblFloralRepresentation = new Label();
            lblProductName = new Label();
            lblProductDetails = new Label();
            lblProductInformation = new Label();
            tabFlower = new TabPage();
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
            tabAccessory = new TabPage();
            dgvAccessoryList = new DataGridView();
            ColAccessoryId = new DataGridViewTextBoxColumn();
            ColAccessoryName = new DataGridViewTextBoxColumn();
            ColAccessorySelection = new DataGridViewCheckBoxColumn();
            tbCtrlProductCreationNavigation.SuspendLayout();
            tabProductInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductDetails).BeginInit();
            tabFlower.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFlowerList).BeginInit();
            tabAccessory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAccessoryList).BeginInit();
            SuspendLayout();
            // 
            // tbCtrlProductCreationNavigation
            // 
            tbCtrlProductCreationNavigation.Controls.Add(tabProductInformation);
            tbCtrlProductCreationNavigation.Controls.Add(tabFlower);
            tbCtrlProductCreationNavigation.Controls.Add(tabAccessory);
            tbCtrlProductCreationNavigation.Dock = DockStyle.Fill;
            tbCtrlProductCreationNavigation.Location = new Point(0, 0);
            tbCtrlProductCreationNavigation.Name = "tbCtrlProductCreationNavigation";
            tbCtrlProductCreationNavigation.SelectedIndex = 0;
            tbCtrlProductCreationNavigation.Size = new Size(1653, 944);
            tbCtrlProductCreationNavigation.TabIndex = 0;
            // 
            // tabProductInformation
            // 
            tabProductInformation.Controls.Add(cmbBxFloralRepresentations);
            tabProductInformation.Controls.Add(btnClear);
            tabProductInformation.Controls.Add(btnAdd);
            tabProductInformation.Controls.Add(dgvProductDetails);
            tabProductInformation.Controls.Add(ibtnDecrease);
            tabProductInformation.Controls.Add(ibtnIncrease);
            tabProductInformation.Controls.Add(txtBxCreationQuantity);
            tabProductInformation.Controls.Add(txtBxUnitPrice);
            tabProductInformation.Controls.Add(txtBxProductName);
            tabProductInformation.Controls.Add(txtBxProductId);
            tabProductInformation.Controls.Add(lblProductId);
            tabProductInformation.Controls.Add(lblUnitPrice);
            tabProductInformation.Controls.Add(lblCreationQuantity);
            tabProductInformation.Controls.Add(lblFloralRepresentation);
            tabProductInformation.Controls.Add(lblProductName);
            tabProductInformation.Controls.Add(lblProductDetails);
            tabProductInformation.Controls.Add(lblProductInformation);
            tabProductInformation.Location = new Point(4, 41);
            tabProductInformation.Name = "tabProductInformation";
            tabProductInformation.Padding = new Padding(3);
            tabProductInformation.Size = new Size(1645, 899);
            tabProductInformation.TabIndex = 0;
            tabProductInformation.Text = "Product Information";
            tabProductInformation.UseVisualStyleBackColor = true;
            // 
            // cmbBxFloralRepresentations
            // 
            cmbBxFloralRepresentations.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBxFloralRepresentations.FormattingEnabled = true;
            cmbBxFloralRepresentations.Location = new Point(1012, 90);
            cmbBxFloralRepresentations.Name = "cmbBxFloralRepresentations";
            cmbBxFloralRepresentations.Size = new Size(272, 40);
            cmbBxFloralRepresentations.TabIndex = 17;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(1218, 797);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(180, 60);
            btnClear.TabIndex = 16;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(1019, 797);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(180, 60);
            btnAdd.TabIndex = 15;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
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
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvProductDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvProductDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductDetails.Columns.AddRange(new DataGridViewColumn[] { ColMaterialId, ColMaterialName, ColDecrease, ColUsageQuantity, ColIncrease });
            dgvProductDetails.Location = new Point(104, 331);
            dgvProductDetails.Name = "dgvProductDetails";
            dgvProductDetails.RowHeadersWidth = 62;
            dgvProductDetails.Size = new Size(674, 526);
            dgvProductDetails.TabIndex = 14;
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
            // ibtnDecrease
            // 
            ibtnDecrease.FlatAppearance.BorderSize = 0;
            ibtnDecrease.IconChar = FontAwesome.Sharp.IconChar.Subtract;
            ibtnDecrease.IconColor = Color.Black;
            ibtnDecrease.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ibtnDecrease.IconSize = 30;
            ibtnDecrease.Location = new Point(1041, 141);
            ibtnDecrease.Name = "ibtnDecrease";
            ibtnDecrease.Size = new Size(25, 25);
            ibtnDecrease.TabIndex = 13;
            ibtnDecrease.UseVisualStyleBackColor = true;
            ibtnDecrease.Click += ibtnDecrease_Click;
            // 
            // ibtnIncrease
            // 
            ibtnIncrease.FlatAppearance.BorderSize = 0;
            ibtnIncrease.IconChar = FontAwesome.Sharp.IconChar.Add;
            ibtnIncrease.IconColor = Color.Black;
            ibtnIncrease.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ibtnIncrease.IconSize = 30;
            ibtnIncrease.Location = new Point(1204, 142);
            ibtnIncrease.Name = "ibtnIncrease";
            ibtnIncrease.Size = new Size(25, 25);
            ibtnIncrease.TabIndex = 12;
            ibtnIncrease.UseVisualStyleBackColor = true;
            ibtnIncrease.Click += ibtnIncrease_Click;
            // 
            // txtBxCreationQuantity
            // 
            txtBxCreationQuantity.BorderStyle = BorderStyle.FixedSingle;
            txtBxCreationQuantity.Location = new Point(1073, 135);
            txtBxCreationQuantity.Name = "txtBxCreationQuantity";
            txtBxCreationQuantity.Size = new Size(126, 39);
            txtBxCreationQuantity.TabIndex = 11;
            txtBxCreationQuantity.TextAlign = HorizontalAlignment.Center;
            txtBxCreationQuantity.Validating += txtBxCreationQuantity_Validating;
            // 
            // txtBxUnitPrice
            // 
            txtBxUnitPrice.BackColor = SystemColors.Info;
            txtBxUnitPrice.BorderStyle = BorderStyle.FixedSingle;
            txtBxUnitPrice.Enabled = false;
            txtBxUnitPrice.Location = new Point(1012, 180);
            txtBxUnitPrice.Name = "txtBxUnitPrice";
            txtBxUnitPrice.Size = new Size(272, 39);
            txtBxUnitPrice.TabIndex = 10;
            txtBxUnitPrice.TextAlign = HorizontalAlignment.Right;
            // 
            // txtBxProductName
            // 
            txtBxProductName.BorderStyle = BorderStyle.FixedSingle;
            txtBxProductName.Location = new Point(295, 135);
            txtBxProductName.Name = "txtBxProductName";
            txtBxProductName.Size = new Size(423, 39);
            txtBxProductName.TabIndex = 8;
            // 
            // txtBxProductId
            // 
            txtBxProductId.BorderStyle = BorderStyle.FixedSingle;
            txtBxProductId.Enabled = false;
            txtBxProductId.Location = new Point(295, 91);
            txtBxProductId.Name = "txtBxProductId";
            txtBxProductId.Size = new Size(189, 39);
            txtBxProductId.TabIndex = 7;
            // 
            // lblProductId
            // 
            lblProductId.AutoSize = true;
            lblProductId.Location = new Point(104, 91);
            lblProductId.Name = "lblProductId";
            lblProductId.Size = new Size(126, 32);
            lblProductId.TabIndex = 6;
            lblProductId.Text = "Product ID";
            // 
            // lblUnitPrice
            // 
            lblUnitPrice.AutoSize = true;
            lblUnitPrice.Location = new Point(753, 180);
            lblUnitPrice.Name = "lblUnitPrice";
            lblUnitPrice.Size = new Size(116, 32);
            lblUnitPrice.TabIndex = 5;
            lblUnitPrice.Text = "Unit Price";
            // 
            // lblCreationQuantity
            // 
            lblCreationQuantity.AutoSize = true;
            lblCreationQuantity.Location = new Point(753, 135);
            lblCreationQuantity.Name = "lblCreationQuantity";
            lblCreationQuantity.Size = new Size(203, 32);
            lblCreationQuantity.TabIndex = 4;
            lblCreationQuantity.Text = "Creation Quantity";
            // 
            // lblFloralRepresentation
            // 
            lblFloralRepresentation.AutoSize = true;
            lblFloralRepresentation.Location = new Point(753, 91);
            lblFloralRepresentation.Name = "lblFloralRepresentation";
            lblFloralRepresentation.Size = new Size(239, 32);
            lblFloralRepresentation.TabIndex = 3;
            lblFloralRepresentation.Text = "Floral Representation";
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Location = new Point(104, 135);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(167, 32);
            lblProductName.TabIndex = 2;
            lblProductName.Text = "Product Name";
            // 
            // lblProductDetails
            // 
            lblProductDetails.AutoSize = true;
            lblProductDetails.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProductDetails.Location = new Point(63, 259);
            lblProductDetails.Name = "lblProductDetails";
            lblProductDetails.Size = new Size(210, 38);
            lblProductDetails.TabIndex = 1;
            lblProductDetails.Text = "Product Details";
            // 
            // lblProductInformation
            // 
            lblProductInformation.AutoSize = true;
            lblProductInformation.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProductInformation.Location = new Point(63, 37);
            lblProductInformation.Name = "lblProductInformation";
            lblProductInformation.Size = new Size(275, 38);
            lblProductInformation.TabIndex = 0;
            lblProductInformation.Text = "Product Information";
            // 
            // tabFlower
            // 
            tabFlower.Controls.Add(lblFloralCharacteristic);
            tabFlower.Controls.Add(lblFloralColor);
            tabFlower.Controls.Add(lblFloralType);
            tabFlower.Controls.Add(lblFilter);
            tabFlower.Controls.Add(cmbBxFloralColor);
            tabFlower.Controls.Add(cmbBxFloralCharacteristic);
            tabFlower.Controls.Add(cmbBxFloralType);
            tabFlower.Controls.Add(dgvFlowerList);
            tabFlower.Location = new Point(4, 34);
            tabFlower.Name = "tabFlower";
            tabFlower.Padding = new Padding(3);
            tabFlower.Size = new Size(1645, 906);
            tabFlower.TabIndex = 1;
            tabFlower.Text = "Flower";
            tabFlower.UseVisualStyleBackColor = true;
            // 
            // lblFloralCharacteristic
            // 
            lblFloralCharacteristic.AutoSize = true;
            lblFloralCharacteristic.Font = new Font("Segoe UI", 10F);
            lblFloralCharacteristic.Location = new Point(867, 47);
            lblFloralCharacteristic.Name = "lblFloralCharacteristic";
            lblFloralCharacteristic.Size = new Size(183, 28);
            lblFloralCharacteristic.TabIndex = 7;
            lblFloralCharacteristic.Text = "Floral Characteristic";
            // 
            // lblFloralColor
            // 
            lblFloralColor.AutoSize = true;
            lblFloralColor.Font = new Font("Segoe UI", 10F);
            lblFloralColor.Location = new Point(578, 47);
            lblFloralColor.Name = "lblFloralColor";
            lblFloralColor.Size = new Size(114, 28);
            lblFloralColor.TabIndex = 6;
            lblFloralColor.Text = "Floral Color";
            // 
            // lblFloralType
            // 
            lblFloralType.AutoSize = true;
            lblFloralType.Font = new Font("Segoe UI", 10F);
            lblFloralType.Location = new Point(294, 47);
            lblFloralType.Name = "lblFloralType";
            lblFloralType.Size = new Size(105, 28);
            lblFloralType.TabIndex = 5;
            lblFloralType.Text = "Floral type";
            // 
            // lblFilter
            // 
            lblFilter.AutoSize = true;
            lblFilter.Location = new Point(201, 85);
            lblFilter.Name = "lblFilter";
            lblFilter.Size = new Size(67, 32);
            lblFilter.TabIndex = 4;
            lblFilter.Text = "Filter";
            // 
            // cmbBxFloralColor
            // 
            cmbBxFloralColor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBxFloralColor.FormattingEnabled = true;
            cmbBxFloralColor.Items.AddRange(new object[] { "None" });
            cmbBxFloralColor.Location = new Point(578, 82);
            cmbBxFloralColor.Name = "cmbBxFloralColor";
            cmbBxFloralColor.Size = new Size(256, 40);
            cmbBxFloralColor.TabIndex = 3;
            cmbBxFloralColor.SelectedIndexChanged += cmbBxFloralColor_SelectedIndexChanged;
            // 
            // cmbBxFloralCharacteristic
            // 
            cmbBxFloralCharacteristic.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBxFloralCharacteristic.FormattingEnabled = true;
            cmbBxFloralCharacteristic.Items.AddRange(new object[] { "None" });
            cmbBxFloralCharacteristic.Location = new Point(867, 82);
            cmbBxFloralCharacteristic.Name = "cmbBxFloralCharacteristic";
            cmbBxFloralCharacteristic.Size = new Size(256, 40);
            cmbBxFloralCharacteristic.TabIndex = 2;
            cmbBxFloralCharacteristic.SelectedIndexChanged += cmbBxFloralCharacteristic_SelectedIndexChanged;
            // 
            // cmbBxFloralType
            // 
            cmbBxFloralType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBxFloralType.FormattingEnabled = true;
            cmbBxFloralType.Items.AddRange(new object[] { "None" });
            cmbBxFloralType.Location = new Point(294, 82);
            cmbBxFloralType.Name = "cmbBxFloralType";
            cmbBxFloralType.Size = new Size(256, 40);
            cmbBxFloralType.TabIndex = 1;
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
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvFlowerList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvFlowerList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFlowerList.Columns.AddRange(new DataGridViewColumn[] { ColFlowerId, ColFlowerName, ColFloralType, ColFloralColor, ColFloralCharacteristic, ColFlowerSelection });
            dgvFlowerList.Location = new Point(110, 162);
            dgvFlowerList.Name = "dgvFlowerList";
            dgvFlowerList.RowHeadersWidth = 62;
            dgvFlowerList.Size = new Size(1196, 691);
            dgvFlowerList.TabIndex = 0;
            dgvFlowerList.CellValueChanged += dgvFlowerList_CellValueChanged;
            dgvFlowerList.CurrentCellDirtyStateChanged += dgvFlowerList_CurrentCellDirtyStateChanged;
            // 
            // ColFlowerId
            // 
            ColFlowerId.HeaderText = "ID";
            ColFlowerId.MinimumWidth = 8;
            ColFlowerId.Name = "ColFlowerId";
            ColFlowerId.ReadOnly = true;
            ColFlowerId.Width = 80;
            // 
            // ColFlowerName
            // 
            ColFlowerName.HeaderText = "Flower Name";
            ColFlowerName.MinimumWidth = 8;
            ColFlowerName.Name = "ColFlowerName";
            ColFlowerName.ReadOnly = true;
            ColFlowerName.Width = 200;
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
            ColFloralColor.HeaderText = "Floral Color";
            ColFloralColor.MinimumWidth = 8;
            ColFloralColor.Name = "ColFloralColor";
            ColFloralColor.ReadOnly = true;
            ColFloralColor.Width = 200;
            // 
            // ColFloralCharacteristic
            // 
            ColFloralCharacteristic.HeaderText = "Floral Characteristic";
            ColFloralCharacteristic.MinimumWidth = 8;
            ColFloralCharacteristic.Name = "ColFloralCharacteristic";
            ColFloralCharacteristic.ReadOnly = true;
            ColFloralCharacteristic.Width = 280;
            // 
            // ColFlowerSelection
            // 
            ColFlowerSelection.HeaderText = "";
            ColFlowerSelection.MinimumWidth = 8;
            ColFlowerSelection.Name = "ColFlowerSelection";
            ColFlowerSelection.Width = 150;
            // 
            // tabAccessory
            // 
            tabAccessory.Controls.Add(dgvAccessoryList);
            tabAccessory.Location = new Point(4, 41);
            tabAccessory.Name = "tabAccessory";
            tabAccessory.Size = new Size(1645, 899);
            tabAccessory.TabIndex = 2;
            tabAccessory.Text = "Accessory";
            tabAccessory.UseVisualStyleBackColor = true;
            // 
            // dgvAccessoryList
            // 
            dgvAccessoryList.AllowUserToDeleteRows = false;
            dgvAccessoryList.AllowUserToResizeColumns = false;
            dgvAccessoryList.AllowUserToResizeRows = false;
            dgvAccessoryList.BackgroundColor = SystemColors.Window;
            dgvAccessoryList.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
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
            dgvAccessoryList.Location = new Point(110, 162);
            dgvAccessoryList.Name = "dgvAccessoryList";
            dgvAccessoryList.RowHeadersWidth = 62;
            dgvAccessoryList.Size = new Size(571, 637);
            dgvAccessoryList.TabIndex = 0;
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
            ColAccessoryName.HeaderText = "Accessory Name";
            ColAccessoryName.MinimumWidth = 8;
            ColAccessoryName.Name = "ColAccessoryName";
            ColAccessoryName.ReadOnly = true;
            ColAccessoryName.Width = 250;
            // 
            // ColAccessorySelection
            // 
            ColAccessorySelection.HeaderText = "";
            ColAccessorySelection.MinimumWidth = 8;
            ColAccessorySelection.Name = "ColAccessorySelection";
            ColAccessorySelection.Width = 80;
            // 
            // ProductCreationForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1653, 944);
            Controls.Add(tbCtrlProductCreationNavigation);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "ProductCreationForm";
            Text = "ProductCreationForm";
            Load += ProductCreationForm_Load;
            tbCtrlProductCreationNavigation.ResumeLayout(false);
            tabProductInformation.ResumeLayout(false);
            tabProductInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductDetails).EndInit();
            tabFlower.ResumeLayout(false);
            tabFlower.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFlowerList).EndInit();
            tabAccessory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAccessoryList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tbCtrlProductCreationNavigation;
        private TabPage tabProductInformation;
        private TabPage tabFlower;
        private TabPage tabAccessory;
        private DataGridView dgvFlowerList;
        private ComboBox cmbBxFloralType;
        private Label lblFloralType;
        private Label lblFilter;
        private ComboBox cmbBxFloralColor;
        private ComboBox cmbBxFloralCharacteristic;
        private Label lblFloralCharacteristic;
        private Label lblFloralColor;
        private DataGridView dgvAccessoryList;
        private Label lblProductDetails;
        private Label lblProductInformation;
        private Label lblProductId;
        private Label lblUnitPrice;
        private Label lblCreationQuantity;
        private Label lblFloralRepresentation;
        private Label lblProductName;
        private FontAwesome.Sharp.IconButton ibtnIncrease;
        private TextBox txtBxCreationQuantity;
        private TextBox txtBxUnitPrice;
        private TextBox txtBxProductName;
        private TextBox txtBxProductId;
        private FontAwesome.Sharp.IconButton ibtnDecrease;
        private DataGridView dgvProductDetails;
        private Button btnClear;
        private Button btnAdd;
        private ComboBox cmbBxFloralRepresentations;
        private DataGridViewTextBoxColumn ColAccessoryId;
        private DataGridViewTextBoxColumn ColAccessoryName;
        private DataGridViewCheckBoxColumn ColAccessorySelection;
        private DataGridViewTextBoxColumn ColFlowerId;
        private DataGridViewTextBoxColumn ColFlowerName;
        private DataGridViewTextBoxColumn ColFloralType;
        private DataGridViewTextBoxColumn ColFloralColor;
        private DataGridViewTextBoxColumn ColFloralCharacteristic;
        private DataGridViewCheckBoxColumn ColFlowerSelection;
        private DataGridViewTextBoxColumn ColMaterialId;
        private DataGridViewTextBoxColumn ColMaterialName;
        private DataGridViewImageColumn ColDecrease;
        private DataGridViewTextBoxColumn ColUsageQuantity;
        private DataGridViewImageColumn ColIncrease;
    }
}