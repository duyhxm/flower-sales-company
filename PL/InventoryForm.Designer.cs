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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InventoryForm));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            tolStrNavigationBar = new ToolStrip();
            tolStrBtnMaterial = new ToolStripButton();
            tolStrSep = new ToolStripSeparator();
            tolStrBtnProduct = new ToolStripButton();
            dgvItemInventory = new DataGridView();
            colOrder = new DataGridViewTextBoxColumn();
            colID = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colStockQuantity = new DataGridViewTextBoxColumn();
            lblFilter = new Label();
            lblStore = new Label();
            lblMaterialType = new Label();
            cmbBxMaterials = new ComboBox();
            cmbBxStores = new ComboBox();
            plHorizontalLine = new Panel();
            tolStrNavigationBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvItemInventory).BeginInit();
            SuspendLayout();
            // 
            // tolStrNavigationBar
            // 
            tolStrNavigationBar.BackColor = SystemColors.GradientInactiveCaption;
            tolStrNavigationBar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tolStrNavigationBar.ImageScalingSize = new Size(24, 24);
            tolStrNavigationBar.Items.AddRange(new ToolStripItem[] { tolStrBtnMaterial, tolStrSep, tolStrBtnProduct });
            tolStrNavigationBar.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            tolStrNavigationBar.Location = new Point(0, 0);
            tolStrNavigationBar.Name = "tolStrNavigationBar";
            tolStrNavigationBar.Padding = new Padding(0, 0, 3, 0);
            tolStrNavigationBar.RenderMode = ToolStripRenderMode.Professional;
            tolStrNavigationBar.Size = new Size(1653, 41);
            tolStrNavigationBar.TabIndex = 0;
            tolStrNavigationBar.Text = "toolStrip1";
            // 
            // tolStrBtnMaterial
            // 
            tolStrBtnMaterial.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tolStrBtnMaterial.Image = (Image)resources.GetObject("tolStrBtnMaterial.Image");
            tolStrBtnMaterial.ImageTransparentColor = Color.Magenta;
            tolStrBtnMaterial.Name = "tolStrBtnMaterial";
            tolStrBtnMaterial.Size = new Size(105, 36);
            tolStrBtnMaterial.Text = "Material";
            tolStrBtnMaterial.Click += tolStrBtnMaterial_Click;
            // 
            // tolStrSep
            // 
            tolStrSep.Name = "tolStrSep";
            tolStrSep.Size = new Size(6, 41);
            // 
            // tolStrBtnProduct
            // 
            tolStrBtnProduct.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tolStrBtnProduct.Image = (Image)resources.GetObject("tolStrBtnProduct.Image");
            tolStrBtnProduct.ImageTransparentColor = Color.Magenta;
            tolStrBtnProduct.Name = "tolStrBtnProduct";
            tolStrBtnProduct.Size = new Size(100, 36);
            tolStrBtnProduct.Text = "Product";
            tolStrBtnProduct.Click += tolStrBtnProduct_Click;
            // 
            // dgvItemInventory
            // 
            dgvItemInventory.BackgroundColor = SystemColors.Menu;
            dgvItemInventory.BorderStyle = BorderStyle.None;
            dgvItemInventory.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvItemInventory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvItemInventory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvItemInventory.Columns.AddRange(new DataGridViewColumn[] { colOrder, colID, colName, colStockQuantity });
            dgvItemInventory.Location = new Point(78, 262);
            dgvItemInventory.Name = "dgvItemInventory";
            dgvItemInventory.RowHeadersWidth = 62;
            dgvItemInventory.Size = new Size(782, 641);
            dgvItemInventory.TabIndex = 1;
            // 
            // colOrder
            // 
            colOrder.HeaderText = "#";
            colOrder.MinimumWidth = 8;
            colOrder.Name = "colOrder";
            colOrder.Resizable = DataGridViewTriState.False;
            colOrder.Width = 80;
            // 
            // colID
            // 
            colID.HeaderText = "ID";
            colID.MinimumWidth = 8;
            colID.Name = "colID";
            colID.Resizable = DataGridViewTriState.False;
            colID.Width = 150;
            // 
            // colName
            // 
            colName.HeaderText = "Name";
            colName.MinimumWidth = 8;
            colName.Name = "colName";
            colName.Resizable = DataGridViewTriState.False;
            colName.Width = 250;
            // 
            // colStockQuantity
            // 
            colStockQuantity.HeaderText = "StockQuantity";
            colStockQuantity.MinimumWidth = 8;
            colStockQuantity.Name = "colStockQuantity";
            colStockQuantity.Resizable = DataGridViewTriState.False;
            colStockQuantity.Width = 200;
            // 
            // lblFilter
            // 
            lblFilter.AutoSize = true;
            lblFilter.Location = new Point(147, 115);
            lblFilter.Name = "lblFilter";
            lblFilter.Size = new Size(67, 32);
            lblFilter.TabIndex = 2;
            lblFilter.Text = "Filter";
            // 
            // lblStore
            // 
            lblStore.AutoSize = true;
            lblStore.Location = new Point(144, 171);
            lblStore.Name = "lblStore";
            lblStore.Size = new Size(74, 32);
            lblStore.TabIndex = 3;
            lblStore.Text = "Store:";
            // 
            // lblMaterialType
            // 
            lblMaterialType.AutoSize = true;
            lblMaterialType.Location = new Point(452, 171);
            lblMaterialType.Name = "lblMaterialType";
            lblMaterialType.Size = new Size(164, 32);
            lblMaterialType.TabIndex = 5;
            lblMaterialType.Text = "Material Type:";
            // 
            // cmbBxMaterials
            // 
            cmbBxMaterials.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBxMaterials.FormattingEnabled = true;
            cmbBxMaterials.Items.AddRange(new object[] { "all", "flower", "accessory" });
            cmbBxMaterials.Location = new Point(622, 168);
            cmbBxMaterials.Name = "cmbBxMaterials";
            cmbBxMaterials.Size = new Size(204, 40);
            cmbBxMaterials.TabIndex = 6;
            // 
            // cmbBxStores
            // 
            cmbBxStores.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBxStores.FormattingEnabled = true;
            cmbBxStores.Items.AddRange(new object[] { "current", "store 01", "store 02", "store 03", "store 04", "store 05" });
            cmbBxStores.Location = new Point(224, 168);
            cmbBxStores.Name = "cmbBxStores";
            cmbBxStores.Size = new Size(204, 40);
            cmbBxStores.TabIndex = 7;
            // 
            // plHorizontalLine
            // 
            plHorizontalLine.BackColor = SystemColors.ActiveBorder;
            plHorizontalLine.Location = new Point(145, 150);
            plHorizontalLine.Name = "plHorizontalLine";
            plHorizontalLine.Size = new Size(730, 1);
            plHorizontalLine.TabIndex = 8;
            // 
            // InventoryForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1653, 944);
            Controls.Add(plHorizontalLine);
            Controls.Add(cmbBxStores);
            Controls.Add(cmbBxMaterials);
            Controls.Add(lblMaterialType);
            Controls.Add(lblStore);
            Controls.Add(lblFilter);
            Controls.Add(dgvItemInventory);
            Controls.Add(tolStrNavigationBar);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "InventoryForm";
            tolStrNavigationBar.ResumeLayout(false);
            tolStrNavigationBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvItemInventory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip tolStrNavigationBar;
        private ToolStripButton tolStrBtnMaterial;
        private ToolStripButton tolStrBtnProduct;
        private DataGridView dgvItemInventory;
        private Label lblFilter;
        private Label lblStore;
        private Label lblMaterialType;
        private ComboBox cmbBxMaterials;
        private ComboBox cmbBxStores;
        private Panel plHorizontalLine;
        private ToolStripSeparator tolStrSep;
        private DataGridViewTextBoxColumn colOrder;
        private DataGridViewTextBoxColumn colID;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colStockQuantity;
    }
}