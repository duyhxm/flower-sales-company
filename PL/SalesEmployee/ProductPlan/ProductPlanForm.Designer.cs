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
            btnClear = new Button();
            lblFindById = new Label();
            txtBxFindById = new TextBox();
            cbbType = new ComboBox();
            lblFRName = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvProduct).BeginInit();
            SuspendLayout();
            // 
            // dgvProduct
            // 
            dgvProduct.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProduct.Columns.AddRange(new DataGridViewColumn[] { ProductId, ProductName, FRName, ColDetailedProduct, ColCreationQuantity, SelectColumn });
            dgvProduct.Location = new Point(30, 227);
            dgvProduct.Name = "dgvProduct";
            dgvProduct.RowHeadersWidth = 62;
            dgvProduct.Size = new Size(943, 626);
            dgvProduct.TabIndex = 0;
            dgvProduct.CellContentClick += dgvProduct_CellContentClick;
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
            lblImplementationDate.Location = new Point(1128, 361);
            lblImplementationDate.Name = "lblImplementationDate";
            lblImplementationDate.Size = new Size(121, 21);
            lblImplementationDate.TabIndex = 1;
            lblImplementationDate.Text = "Implement Date";
            // 
            // dtpImplementDate
            // 
            dtpImplementDate.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpImplementDate.Format = DateTimePickerFormat.Custom;
            dtpImplementDate.Location = new Point(1293, 355);
            dtpImplementDate.Name = "dtpImplementDate";
            dtpImplementDate.Size = new Size(249, 29);
            dtpImplementDate.TabIndex = 2;
            // 
            // btnPlan
            // 
            btnPlan.Location = new Point(1217, 557);
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
            cbbStore.Location = new Point(1338, 487);
            cbbStore.Name = "cbbStore";
            cbbStore.Size = new Size(204, 29);
            cbbStore.TabIndex = 4;
            // 
            // lblStoreName
            // 
            lblStoreName.AutoSize = true;
            lblStoreName.Location = new Point(1263, 490);
            lblStoreName.Name = "lblStoreName";
            lblStoreName.Size = new Size(46, 21);
            lblStoreName.TabIndex = 5;
            lblStoreName.Text = "Store";
            // 
            // cbbRegion
            // 
            cbbRegion.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbRegion.FormattingEnabled = true;
            cbbRegion.Location = new Point(1338, 431);
            cbbRegion.Name = "cbbRegion";
            cbbRegion.Size = new Size(204, 29);
            cbbRegion.TabIndex = 6;
            cbbRegion.SelectedValueChanged += cbbRegion_SelectedValueChanged;
            // 
            // lblRegionFilter
            // 
            lblRegionFilter.AutoSize = true;
            lblRegionFilter.Location = new Point(1244, 434);
            lblRegionFilter.Name = "lblRegionFilter";
            lblRegionFilter.Size = new Size(59, 21);
            lblRegionFilter.TabIndex = 7;
            lblRegionFilter.Text = "Region";
            // 
            // btnClear
            // 
            btnClear.Location = new Point(1375, 557);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(157, 52);
            btnClear.TabIndex = 8;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // lblFindById
            // 
            lblFindById.AutoSize = true;
            lblFindById.Location = new Point(122, 112);
            lblFindById.Name = "lblFindById";
            lblFindById.Size = new Size(80, 21);
            lblFindById.TabIndex = 10;
            lblFindById.Text = "Find by ID";
            // 
            // txtBxFindById
            // 
            txtBxFindById.Location = new Point(208, 106);
            txtBxFindById.Name = "txtBxFindById";
            txtBxFindById.Size = new Size(181, 29);
            txtBxFindById.TabIndex = 11;
            txtBxFindById.TextChanged += txtBxFindById_TextChanged;
            // 
            // cbbType
            // 
            cbbType.FormattingEnabled = true;
            cbbType.Items.AddRange(new object[] { "" });
            cbbType.Location = new Point(573, 106);
            cbbType.Name = "cbbType";
            cbbType.Size = new Size(221, 29);
            cbbType.TabIndex = 12;
            cbbType.SelectedValueChanged += cbbType_SelectedValueChanged;
            // 
            // lblFRName
            // 
            lblFRName.AutoSize = true;
            lblFRName.Location = new Point(484, 110);
            lblFRName.Name = "lblFRName";
            lblFRName.Size = new Size(74, 21);
            lblFRName.TabIndex = 13;
            lblFRName.Text = "FR Name";
            // 
            // ProductPlanForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1653, 944);
            Controls.Add(lblFRName);
            Controls.Add(cbbType);
            Controls.Add(txtBxFindById);
            Controls.Add(lblFindById);
            Controls.Add(btnClear);
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
        private Button btnClear;
        private ComboBox cbbType;
        private Label lblFindById;
        private TextBox txtBxFindById;
        private Label lblFRName;
        private DataGridViewTextBoxColumn ProductId;
        private DataGridViewTextBoxColumn ProductName;
        private DataGridViewTextBoxColumn FRName;
        private DataGridViewImageColumn ColDetailedProduct;
        private DataGridViewTextBoxColumn ColCreationQuantity;
        private DataGridViewCheckBoxColumn SelectColumn;
    }
}