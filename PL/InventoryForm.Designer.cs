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
            dgvStoreInventory = new DataGridView();
            ColMaterialId = new DataGridViewTextBoxColumn();
            ColMaterialName = new DataGridViewTextBoxColumn();
            ColStockMaterialQuantity = new DataGridViewTextBoxColumn();
            ColUnitPrice = new DataGridViewTextBoxColumn();
            lblFilter = new Label();
            lblMaterialType = new Label();
            cmbBxMaterials = new ComboBox();
            plHorizontalLine = new Panel();
            tbCtrlStoreInventory = new TabControl();
            tpMaterial = new TabPage();
            tpProduct = new TabPage();
            ((System.ComponentModel.ISupportInitialize)dgvStoreInventory).BeginInit();
            tbCtrlStoreInventory.SuspendLayout();
            tpMaterial.SuspendLayout();
            SuspendLayout();
            // 
            // dgvStoreInventory
            // 
            dgvStoreInventory.AllowUserToAddRows = false;
            dgvStoreInventory.AllowUserToDeleteRows = false;
            dgvStoreInventory.AllowUserToResizeColumns = false;
            dgvStoreInventory.AllowUserToResizeRows = false;
            dgvStoreInventory.BackgroundColor = SystemColors.Menu;
            dgvStoreInventory.BorderStyle = BorderStyle.None;
            dgvStoreInventory.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvStoreInventory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvStoreInventory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStoreInventory.Columns.AddRange(new DataGridViewColumn[] { ColMaterialId, ColMaterialName, ColStockMaterialQuantity, ColUnitPrice });
            dgvStoreInventory.Location = new Point(95, 234);
            dgvStoreInventory.Name = "dgvStoreInventory";
            dgvStoreInventory.RowHeadersWidth = 62;
            dgvStoreInventory.Size = new Size(899, 344);
            dgvStoreInventory.TabIndex = 1;
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
            ColStockMaterialQuantity.HeaderText = "StockQuantity";
            ColStockMaterialQuantity.MinimumWidth = 8;
            ColStockMaterialQuantity.Name = "ColStockMaterialQuantity";
            ColStockMaterialQuantity.ReadOnly = true;
            ColStockMaterialQuantity.Resizable = DataGridViewTriState.False;
            ColStockMaterialQuantity.Width = 200;
            // 
            // ColUnitPrice
            // 
            ColUnitPrice.HeaderText = "Unit Price";
            ColUnitPrice.MinimumWidth = 8;
            ColUnitPrice.Name = "ColUnitPrice";
            ColUnitPrice.ReadOnly = true;
            ColUnitPrice.Width = 200;
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
            tpMaterial.Controls.Add(dgvStoreInventory);
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
            tpMaterial.UseVisualStyleBackColor = true;
            // 
            // tpProduct
            // 
            tpProduct.Location = new Point(4, 34);
            tpProduct.Name = "tpProduct";
            tpProduct.Padding = new Padding(3);
            tpProduct.Size = new Size(1645, 906);
            tpProduct.TabIndex = 1;
            tpProduct.Text = "Product";
            tpProduct.UseVisualStyleBackColor = true;
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
            ((System.ComponentModel.ISupportInitialize)dgvStoreInventory).EndInit();
            tbCtrlStoreInventory.ResumeLayout(false);
            tpMaterial.ResumeLayout(false);
            tpMaterial.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView dgvStoreInventory;
        private Label lblFilter;
        private Label lblMaterialType;
        private ComboBox cmbBxMaterials;
        private Panel plHorizontalLine;
        private TabControl tbCtrlStoreInventory;
        private TabPage tpMaterial;
        private TabPage tpProduct;
        private DataGridViewTextBoxColumn ColMaterialId;
        private DataGridViewTextBoxColumn ColMaterialName;
        private DataGridViewTextBoxColumn ColStockMaterialQuantity;
        private DataGridViewTextBoxColumn ColUnitPrice;
    }
}