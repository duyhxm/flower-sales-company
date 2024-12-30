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
            dataGridView1 = new DataGridView();
            ColProductId = new DataGridViewTextBoxColumn();
            ColProductName = new DataGridViewTextBoxColumn();
            ColFRepresentationName = new DataGridViewTextBoxColumn();
            ColDetailedProduct = new DataGridViewImageColumn();
            ColCreationQuantity = new DataGridViewTextBoxColumn();
            ColSelection = new DataGridViewCheckBoxColumn();
            lblImplementationDate = new Label();
            dtpImplementationDate = new DateTimePicker();
            btnPlan = new Button();
            cmbBxStores = new ComboBox();
            lblStoreName = new Label();
            cmbBxRegions = new ComboBox();
            lblRegionFilter = new Label();
            btnClear = new Button();
            lblFindById = new Label();
            txtBxFindById = new TextBox();
            cmbBxFRName = new ComboBox();
            lblFRName = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ColProductId, ColProductName, ColFRepresentationName, ColDetailedProduct, ColCreationQuantity, ColSelection });
            dataGridView1.Location = new Point(30, 227);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(943, 626);
            dataGridView1.TabIndex = 0;
            // 
            // ColProductId
            // 
            ColProductId.FillWeight = 50F;
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
            ColProductName.Width = 250;
            // 
            // ColFRepresentationName
            // 
            ColFRepresentationName.HeaderText = "FR Name";
            ColFRepresentationName.MinimumWidth = 8;
            ColFRepresentationName.Name = "ColFRepresentationName";
            ColFRepresentationName.ReadOnly = true;
            ColFRepresentationName.Width = 150;
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
            // ColSelection
            // 
            ColSelection.FillWeight = 50F;
            ColSelection.HeaderText = "";
            ColSelection.MinimumWidth = 8;
            ColSelection.Name = "ColSelection";
            ColSelection.Width = 80;
            // 
            // lblImplementationDate
            // 
            lblImplementationDate.AutoSize = true;
            lblImplementationDate.Location = new Point(1076, 360);
            lblImplementationDate.Name = "lblImplementationDate";
            lblImplementationDate.Size = new Size(187, 32);
            lblImplementationDate.TabIndex = 1;
            lblImplementationDate.Text = "Implement Date";
            // 
            // dtpImplementationDate
            // 
            dtpImplementationDate.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpImplementationDate.Format = DateTimePickerFormat.Custom;
            dtpImplementationDate.Location = new Point(1293, 355);
            dtpImplementationDate.Name = "dtpImplementationDate";
            dtpImplementationDate.Size = new Size(249, 39);
            dtpImplementationDate.TabIndex = 2;
            // 
            // btnPlan
            // 
            btnPlan.Location = new Point(1217, 557);
            btnPlan.Name = "btnPlan";
            btnPlan.Size = new Size(152, 52);
            btnPlan.TabIndex = 3;
            btnPlan.Text = "Plan";
            btnPlan.UseVisualStyleBackColor = true;
            // 
            // cmbBxStores
            // 
            cmbBxStores.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBxStores.FormattingEnabled = true;
            cmbBxStores.Location = new Point(1338, 487);
            cmbBxStores.Name = "cmbBxStores";
            cmbBxStores.Size = new Size(204, 40);
            cmbBxStores.TabIndex = 4;
            // 
            // lblStoreName
            // 
            lblStoreName.AutoSize = true;
            lblStoreName.Location = new Point(1263, 490);
            lblStoreName.Name = "lblStoreName";
            lblStoreName.Size = new Size(69, 32);
            lblStoreName.TabIndex = 5;
            lblStoreName.Text = "Store";
            // 
            // cmbBxRegions
            // 
            cmbBxRegions.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBxRegions.FormattingEnabled = true;
            cmbBxRegions.Location = new Point(1338, 431);
            cmbBxRegions.Name = "cmbBxRegions";
            cmbBxRegions.Size = new Size(204, 40);
            cmbBxRegions.TabIndex = 6;
            // 
            // lblRegionFilter
            // 
            lblRegionFilter.AutoSize = true;
            lblRegionFilter.Location = new Point(1244, 434);
            lblRegionFilter.Name = "lblRegionFilter";
            lblRegionFilter.Size = new Size(88, 32);
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
            lblFindById.Location = new Point(67, 107);
            lblFindById.Name = "lblFindById";
            lblFindById.Size = new Size(123, 32);
            lblFindById.TabIndex = 10;
            lblFindById.Text = "Find by ID";
            // 
            // txtBxFindById
            // 
            txtBxFindById.Location = new Point(208, 106);
            txtBxFindById.Name = "txtBxFindById";
            txtBxFindById.Size = new Size(181, 39);
            txtBxFindById.TabIndex = 11;
            // 
            // cmbBxFRName
            // 
            cmbBxFRName.FormattingEnabled = true;
            cmbBxFRName.Location = new Point(573, 106);
            cmbBxFRName.Name = "cmbBxFRName";
            cmbBxFRName.Size = new Size(221, 40);
            cmbBxFRName.TabIndex = 12;
            // 
            // lblFRName
            // 
            lblFRName.AutoSize = true;
            lblFRName.Location = new Point(423, 109);
            lblFRName.Name = "lblFRName";
            lblFRName.Size = new Size(111, 32);
            lblFRName.TabIndex = 13;
            lblFRName.Text = "FR Name";
            // 
            // ProductPlanForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1653, 944);
            Controls.Add(lblFRName);
            Controls.Add(cmbBxFRName);
            Controls.Add(txtBxFindById);
            Controls.Add(lblFindById);
            Controls.Add(btnClear);
            Controls.Add(lblRegionFilter);
            Controls.Add(cmbBxRegions);
            Controls.Add(lblStoreName);
            Controls.Add(cmbBxStores);
            Controls.Add(btnPlan);
            Controls.Add(dtpImplementationDate);
            Controls.Add(lblImplementationDate);
            Controls.Add(dataGridView1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "ProductPlanForm";
            Text = "ProductPlanForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label lblImplementationDate;
        private DateTimePicker dtpImplementationDate;
        private Button btnPlan;
        private ComboBox cmbBxStores;
        private Label lblStoreName;
        private ComboBox cmbBxRegions;
        private Label lblRegionFilter;
        private Button btnClear;
        private DataGridViewTextBoxColumn ColProductId;
        private DataGridViewTextBoxColumn ColProductName;
        private DataGridViewTextBoxColumn ColFRepresentationName;
        private DataGridViewImageColumn ColDetailedProduct;
        private DataGridViewTextBoxColumn ColCreationQuantity;
        private DataGridViewCheckBoxColumn ColSelection;
        private ComboBox cmbBxFRName;
        private Label lblFindById;
        private TextBox txtBxFindById;
        private Label lblFRName;
    }
}