namespace PL
{
    partial class InventoryForm
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
            dgvMaterialInventory = new DataGridView();
            lblFilter = new Label();
            lblMaterialType = new Label();
            cmbBxMaterials = new ComboBox();
            plHorizontalLine = new Panel();
            tbCtrlStoreInventory = new TabControl();
            tpMaterial = new TabPage();
            tpProduct = new TabPage();
            dgvProductInventory = new DataGridView();
            ColProductId = new DataGridViewTextBoxColumn();
            ColProductName = new DataGridViewTextBoxColumn();
            ColStockProductQuantity = new DataGridViewTextBoxColumn();
            ColDetailedProductInventory = new DataGridViewImageColumn();
            ColMaterialId = new DataGridViewTextBoxColumn();
            ColMaterialName = new DataGridViewTextBoxColumn();
            ColStockMaterialQuantity = new DataGridViewTextBoxColumn();
            ColUnitPrice = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvMaterialInventory).BeginInit();
            tbCtrlStoreInventory.SuspendLayout();
            tpMaterial.SuspendLayout();
            tpProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductInventory).BeginInit();
            SuspendLayout();
            // 
            // dgvMaterialInventory
            // 
            dgvMaterialInventory.AllowUserToAddRows = false;
            dgvMaterialInventory.AllowUserToDeleteRows = false;
            dgvMaterialInventory.AllowUserToResizeColumns = false;
            dgvMaterialInventory.AllowUserToResizeRows = false;
            dgvMaterialInventory.BackgroundColor = SystemColors.Window;
            dgvMaterialInventory.BorderStyle = BorderStyle.None;
            dgvMaterialInventory.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvMaterialInventory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvMaterialInventory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMaterialInventory.Columns.AddRange(new DataGridViewColumn[] { ColMaterialId, ColMaterialName, ColStockMaterialQuantity, ColUnitPrice });
            dgvMaterialInventory.Location = new Point(95, 234);
            dgvMaterialInventory.Name = "dgvMaterialInventory";
            dgvMaterialInventory.RowHeadersWidth = 62;
            dgvMaterialInventory.Size = new Size(842, 589);
            dgvMaterialInventory.TabIndex = 1;
            // 
            // lblFilter
            // 
            lblFilter.AutoSize = true;
            lblFilter.Location = new Point(149, 99);
            lblFilter.Name = "lblFilter";
            lblFilter.Size = new Size(67, 32);
            lblFilter.TabIndex = 2;
            lblFilter.Text = "Filter";
            // 
            // lblMaterialType
            // 
            lblMaterialType.AutoSize = true;
            lblMaterialType.Location = new Point(454, 155);
            lblMaterialType.Name = "lblMaterialType";
            lblMaterialType.Size = new Size(164, 32);
            lblMaterialType.TabIndex = 5;
            lblMaterialType.Text = "Material Type:";
            // 
            // cmbBxMaterials
            // 
            cmbBxMaterials.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBxMaterials.FormattingEnabled = true;
            cmbBxMaterials.Location = new Point(624, 152);
            cmbBxMaterials.Name = "cmbBxMaterials";
            cmbBxMaterials.Size = new Size(204, 40);
            cmbBxMaterials.TabIndex = 6;
            cmbBxMaterials.SelectedIndexChanged += cmbBxMaterials_SelectedIndexChanged;
            // 
            // plHorizontalLine
            // 
            plHorizontalLine.BackColor = SystemColors.ActiveBorder;
            plHorizontalLine.Location = new Point(147, 134);
            plHorizontalLine.Name = "plHorizontalLine";
            plHorizontalLine.Size = new Size(730, 1);
            plHorizontalLine.TabIndex = 8;
            // 
            // tbCtrlStoreInventory
            // 
            tbCtrlStoreInventory.Controls.Add(tpMaterial);
            tbCtrlStoreInventory.Controls.Add(tpProduct);
            tbCtrlStoreInventory.Dock = DockStyle.Fill;
            tbCtrlStoreInventory.Location = new Point(0, 0);
            tbCtrlStoreInventory.Name = "tbCtrlStoreInventory";
            tbCtrlStoreInventory.SelectedIndex = 0;
            tbCtrlStoreInventory.Size = new Size(1653, 944);
            tbCtrlStoreInventory.TabIndex = 9;
            // 
            // tpMaterial
            // 
            tpMaterial.BackColor = Color.White;
            tpMaterial.Controls.Add(dgvMaterialInventory);
            tpMaterial.Controls.Add(plHorizontalLine);
            tpMaterial.Controls.Add(lblMaterialType);
            tpMaterial.Controls.Add(lblFilter);
            tpMaterial.Controls.Add(cmbBxMaterials);
            tpMaterial.Location = new Point(4, 41);
            tpMaterial.Name = "tpMaterial";
            tpMaterial.Padding = new Padding(3);
            tpMaterial.Size = new Size(1645, 899);
            tpMaterial.TabIndex = 0;
            tpMaterial.Text = "Material";
            // 
            // tpProduct
            // 
            tpProduct.BackColor = Color.White;
            tpProduct.Controls.Add(dgvProductInventory);
            tpProduct.Location = new Point(4, 34);
            tpProduct.Name = "tpProduct";
            tpProduct.Padding = new Padding(3);
            tpProduct.Size = new Size(1645, 906);
            tpProduct.TabIndex = 1;
            tpProduct.Text = "Product";
            // 
            // dgvProductInventory
            // 
            dgvProductInventory.AllowUserToAddRows = false;
            dgvProductInventory.AllowUserToDeleteRows = false;
            dgvProductInventory.AllowUserToResizeColumns = false;
            dgvProductInventory.AllowUserToResizeRows = false;
            dgvProductInventory.BackgroundColor = SystemColors.ButtonHighlight;
            dgvProductInventory.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvProductInventory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvProductInventory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductInventory.Columns.AddRange(new DataGridViewColumn[] { ColProductId, ColProductName, ColStockProductQuantity, ColDetailedProductInventory });
            dgvProductInventory.Location = new Point(95, 234);
            dgvProductInventory.Name = "dgvProductInventory";
            dgvProductInventory.RowHeadersWidth = 62;
            dgvProductInventory.Size = new Size(791, 588);
            dgvProductInventory.TabIndex = 0;
            dgvProductInventory.CellClick += dgvProductInventory_CellClick;
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
            ColProductName.HeaderText = "Product Name";
            ColProductName.MinimumWidth = 8;
            ColProductName.Name = "ColProductName";
            ColProductName.ReadOnly = true;
            ColProductName.Width = 250;
            // 
            // ColStockProductQuantity
            // 
            ColStockProductQuantity.HeaderText = "Q";
            ColStockProductQuantity.MinimumWidth = 8;
            ColStockProductQuantity.Name = "ColStockProductQuantity";
            ColStockProductQuantity.ReadOnly = true;
            ColStockProductQuantity.Width = 150;
            // 
            // ColDetailedProductInventory
            // 
            ColDetailedProductInventory.HeaderText = "Details";
            ColDetailedProductInventory.Image = Properties.Resources.details;
            ColDetailedProductInventory.MinimumWidth = 8;
            ColDetailedProductInventory.Name = "ColDetailedProductInventory";
            ColDetailedProductInventory.ReadOnly = true;
            ColDetailedProductInventory.Resizable = DataGridViewTriState.True;
            ColDetailedProductInventory.SortMode = DataGridViewColumnSortMode.Automatic;
            ColDetailedProductInventory.Width = 150;
            // 
            // ColMaterialId
            // 
            ColMaterialId.HeaderText = "ID";
            ColMaterialId.MinimumWidth = 8;
            ColMaterialId.Name = "ColMaterialId";
            ColMaterialId.ReadOnly = true;
            ColMaterialId.Resizable = DataGridViewTriState.False;
            ColMaterialId.Width = 150;
            // 
            // ColMaterialName
            // 
            ColMaterialName.HeaderText = "Name";
            ColMaterialName.MinimumWidth = 8;
            ColMaterialName.Name = "ColMaterialName";
            ColMaterialName.ReadOnly = true;
            ColMaterialName.Resizable = DataGridViewTriState.False;
            ColMaterialName.Width = 250;
            // 
            // ColStockMaterialQuantity
            // 
            ColStockMaterialQuantity.HeaderText = "Q";
            ColStockMaterialQuantity.MinimumWidth = 8;
            ColStockMaterialQuantity.Name = "ColStockMaterialQuantity";
            ColStockMaterialQuantity.ReadOnly = true;
            ColStockMaterialQuantity.Resizable = DataGridViewTriState.False;
            ColStockMaterialQuantity.Width = 150;
            // 
            // ColUnitPrice
            // 
            ColUnitPrice.HeaderText = "Unit Price";
            ColUnitPrice.MinimumWidth = 8;
            ColUnitPrice.Name = "ColUnitPrice";
            ColUnitPrice.ReadOnly = true;
            ColUnitPrice.Width = 200;
            // 
            // InventoryForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1653, 944);
            Controls.Add(tbCtrlStoreInventory);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "InventoryForm";
            ((System.ComponentModel.ISupportInitialize)dgvMaterialInventory).EndInit();
            tbCtrlStoreInventory.ResumeLayout(false);
            tpMaterial.ResumeLayout(false);
            tpMaterial.PerformLayout();
            tpProduct.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProductInventory).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView dgvMaterialInventory;
        private Label lblFilter;
        private Label lblMaterialType;
        private ComboBox cmbBxMaterials;
        private Panel plHorizontalLine;
        private TabControl tbCtrlStoreInventory;
        private TabPage tpMaterial;
        private TabPage tpProduct;
        private DataGridView dgvProductInventory;
        private DataGridViewTextBoxColumn ColProductId;
        private DataGridViewTextBoxColumn ColProductName;
        private DataGridViewTextBoxColumn ColStockProductQuantity;
        private DataGridViewImageColumn ColDetailedProductInventory;
        private DataGridViewTextBoxColumn ColMaterialId;
        private DataGridViewTextBoxColumn ColMaterialName;
        private DataGridViewTextBoxColumn ColStockMaterialQuantity;
        private DataGridViewTextBoxColumn ColUnitPrice;
    }
}