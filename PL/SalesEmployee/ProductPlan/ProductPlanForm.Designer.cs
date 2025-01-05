namespace PL.SalesEmployee
{
    partial class ProductPlanForm
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
            dgvProduct = new DataGridView();
            ProductId = new DataGridViewTextBoxColumn();
            ProductName = new DataGridViewTextBoxColumn();
            FRName = new DataGridViewTextBoxColumn();
            ColDetailedProduct = new DataGridViewImageColumn();
            ColCreationQuantity = new DataGridViewTextBoxColumn();
            SelectColumn = new DataGridViewCheckBoxColumn();
            lblImplementationDate = new Label();
            dtpImplementDate = new DateTimePicker();
            btnPlan = new Button();
            cbbStore = new ComboBox();
            lblStoreName = new Label();
            cbbRegion = new ComboBox();
            lblRegionFilter = new Label();
            lblFindById = new Label();
            txtBxFindById = new TextBox();
            cbbType = new ComboBox();
            lblFRName = new Label();
            lblProductList = new Label();
            btnFind = new FontAwesome.Sharp.IconButton();
            btnRefresh = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)dgvProduct).BeginInit();
            SuspendLayout();
            // 
            // dgvProduct
            // 
            dgvProduct.AllowUserToOrderColumns = true;
            dgvProduct.BackgroundColor = SystemColors.Control;
            dgvProduct.BorderStyle = BorderStyle.None;
            dgvProduct.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProduct.Columns.AddRange(new DataGridViewColumn[] { ProductId, ProductName, FRName, ColDetailedProduct, ColCreationQuantity, SelectColumn });
            dgvProduct.Location = new Point(12, 206);
            dgvProduct.Name = "dgvProduct";
            dgvProduct.RowHeadersWidth = 62;
            dgvProduct.Size = new Size(953, 626);
            dgvProduct.TabIndex = 0;
            dgvProduct.CellContentClick += dgvProduct_CellContentClick;
            dgvProduct.CellValueChanged += dgvProduct_CellValueChanged;
            // 
            // ProductId
            // 
            ProductId.DataPropertyName = "ProductId";
            ProductId.FillWeight = 50F;
            ProductId.HeaderText = "ID";
            ProductId.MinimumWidth = 8;
            ProductId.Name = "ProductId";
            ProductId.ReadOnly = true;
            ProductId.Width = 150;
            // 
            // ProductName
            // 
            ProductName.DataPropertyName = "ProductName";
            ProductName.HeaderText = "Name";
            ProductName.MinimumWidth = 8;
            ProductName.Name = "ProductName";
            ProductName.ReadOnly = true;
            ProductName.Width = 250;
            // 
            // FRName
            // 
            FRName.DataPropertyName = "FRName";
            FRName.HeaderText = "FR Name";
            FRName.MinimumWidth = 8;
            FRName.Name = "FRName";
            FRName.ReadOnly = true;
            FRName.Width = 150;
            // 
            // ColDetailedProduct
            // 
            ColDetailedProduct.FillWeight = 50F;
            ColDetailedProduct.HeaderText = "";
            ColDetailedProduct.Image = Properties.Resources.details;
            ColDetailedProduct.ImageLayout = DataGridViewImageCellLayout.Zoom;
            ColDetailedProduct.MinimumWidth = 8;
            ColDetailedProduct.Name = "ColDetailedProduct";
            ColDetailedProduct.Width = 80;
            // 
            // ColCreationQuantity
            // 
            ColCreationQuantity.FillWeight = 50F;
            ColCreationQuantity.HeaderText = "Q";
            ColCreationQuantity.MinimumWidth = 8;
            ColCreationQuantity.Name = "ColCreationQuantity";
            ColCreationQuantity.Width = 150;
            // 
            // SelectColumn
            // 
            SelectColumn.FillWeight = 50F;
            SelectColumn.HeaderText = "";
            SelectColumn.MinimumWidth = 8;
            SelectColumn.Name = "SelectColumn";
            SelectColumn.Width = 80;
            // 
            // lblImplementationDate
            // 
            lblImplementationDate.AutoSize = true;
            lblImplementationDate.Location = new Point(971, 380);
            lblImplementationDate.Name = "lblImplementationDate";
            lblImplementationDate.Size = new Size(187, 32);
            lblImplementationDate.TabIndex = 1;
            lblImplementationDate.Text = "Implement Date";
            // 
            // dtpImplementDate
            // 
            dtpImplementDate.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpImplementDate.Format = DateTimePickerFormat.Custom;
            dtpImplementDate.Location = new Point(1164, 375);
            dtpImplementDate.Name = "dtpImplementDate";
            dtpImplementDate.Size = new Size(249, 39);
            dtpImplementDate.TabIndex = 2;
            // 
            // btnPlan
            // 
            btnPlan.Location = new Point(1114, 562);
            btnPlan.Name = "btnPlan";
            btnPlan.Size = new Size(152, 52);
            btnPlan.TabIndex = 3;
            btnPlan.Text = "Plan";
            btnPlan.UseVisualStyleBackColor = true;
            btnPlan.Click += btnPlan_Click;
            // 
            // cbbStore
            // 
            cbbStore.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbStore.FormattingEnabled = true;
            cbbStore.Location = new Point(1164, 486);
            cbbStore.Name = "cbbStore";
            cbbStore.Size = new Size(204, 40);
            cbbStore.TabIndex = 4;
            // 
            // lblStoreName
            // 
            lblStoreName.AutoSize = true;
            lblStoreName.Location = new Point(971, 489);
            lblStoreName.Name = "lblStoreName";
            lblStoreName.Size = new Size(69, 32);
            lblStoreName.TabIndex = 5;
            lblStoreName.Text = "Store";
            // 
            // cbbRegion
            // 
            cbbRegion.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbRegion.FormattingEnabled = true;
            cbbRegion.Location = new Point(1164, 430);
            cbbRegion.Name = "cbbRegion";
            cbbRegion.Size = new Size(204, 40);
            cbbRegion.TabIndex = 6;
            cbbRegion.SelectedValueChanged += cbbRegion_SelectedValueChanged;
            // 
            // lblRegionFilter
            // 
            lblRegionFilter.AutoSize = true;
            lblRegionFilter.Location = new Point(971, 433);
            lblRegionFilter.Name = "lblRegionFilter";
            lblRegionFilter.Size = new Size(88, 32);
            lblRegionFilter.TabIndex = 7;
            lblRegionFilter.Text = "Region";
            // 
            // lblFindById
            // 
            lblFindById.AutoSize = true;
            lblFindById.Location = new Point(16, 107);
            lblFindById.Name = "lblFindById";
            lblFindById.Size = new Size(123, 32);
            lblFindById.TabIndex = 10;
            lblFindById.Text = "Find by ID";
            // 
            // txtBxFindById
            // 
            txtBxFindById.Location = new Point(145, 104);
            txtBxFindById.Name = "txtBxFindById";
            txtBxFindById.Size = new Size(181, 39);
            txtBxFindById.TabIndex = 11;
            // 
            // cbbType
            // 
            cbbType.FormattingEnabled = true;
            cbbType.Items.AddRange(new object[] { "" });
            cbbType.Location = new Point(734, 101);
            cbbType.Name = "cbbType";
            cbbType.Size = new Size(221, 40);
            cbbType.TabIndex = 12;
            cbbType.SelectedValueChanged += cbbType_SelectedValueChanged;
            // 
            // lblFRName
            // 
            lblFRName.AutoSize = true;
            lblFRName.Location = new Point(617, 104);
            lblFRName.Name = "lblFRName";
            lblFRName.Size = new Size(111, 32);
            lblFRName.TabIndex = 13;
            lblFRName.Text = "FR Name";
            // 
            // lblProductList
            // 
            lblProductList.AutoSize = true;
            lblProductList.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProductList.Location = new Point(30, 42);
            lblProductList.Name = "lblProductList";
            lblProductList.Size = new Size(167, 38);
            lblProductList.TabIndex = 14;
            lblProductList.Text = "Product List";
            // 
            // btnFind
            // 
            btnFind.BackColor = SystemColors.Control;
            btnFind.IconChar = FontAwesome.Sharp.IconChar.Search;
            btnFind.IconColor = Color.Black;
            btnFind.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnFind.IconSize = 26;
            btnFind.Location = new Point(332, 100);
            btnFind.Name = "btnFind";
            btnFind.Size = new Size(52, 47);
            btnFind.TabIndex = 16;
            btnFind.UseVisualStyleBackColor = false;
            btnFind.Click += btnFind_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = SystemColors.Control;
            btnRefresh.IconChar = FontAwesome.Sharp.IconChar.Refresh;
            btnRefresh.IconColor = Color.Black;
            btnRefresh.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnRefresh.IconSize = 26;
            btnRefresh.Location = new Point(903, 153);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(52, 47);
            btnRefresh.TabIndex = 17;
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // ProductPlanForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1500, 850);
            Controls.Add(btnRefresh);
            Controls.Add(btnFind);
            Controls.Add(lblProductList);
            Controls.Add(lblFRName);
            Controls.Add(cbbType);
            Controls.Add(txtBxFindById);
            Controls.Add(lblFindById);
            Controls.Add(lblRegionFilter);
            Controls.Add(cbbRegion);
            Controls.Add(lblStoreName);
            Controls.Add(cbbStore);
            Controls.Add(btnPlan);
            Controls.Add(dtpImplementDate);
            Controls.Add(lblImplementationDate);
            Controls.Add(dgvProduct);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "ProductPlanForm";
            Text = "ProductPlanForm";
            Load += ProductPlanForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProduct).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvProduct;
        private Label lblImplementationDate;
        private DateTimePicker dtpImplementDate;
        private Button btnPlan;
        private ComboBox cbbStore;
        private Label lblStoreName;
        private ComboBox cbbRegion;
        private Label lblRegionFilter;
        private ComboBox cbbType;
        private Label lblFindById;
        private TextBox txtBxFindById;
        private Label lblFRName;
        private Label lblProductList;
        private FontAwesome.Sharp.IconButton btnFind;
        private FontAwesome.Sharp.IconButton btnRefresh;
        private DataGridViewTextBoxColumn ProductId;
        private DataGridViewTextBoxColumn ProductName;
        private DataGridViewTextBoxColumn FRName;
        private DataGridViewImageColumn ColDetailedProduct;
        private DataGridViewTextBoxColumn ColCreationQuantity;
        private DataGridViewCheckBoxColumn SelectColumn;
    }
}