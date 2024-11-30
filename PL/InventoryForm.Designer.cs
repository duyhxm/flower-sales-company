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
            toolStripNavigationBar = new ToolStrip();
            toolStripButtonMaterial = new ToolStripButton();
            toolStripButtonProduct = new ToolStripButton();
            dataGridViewItemInventory = new DataGridView();
            columnOrder = new DataGridViewTextBoxColumn();
            columnID = new DataGridViewTextBoxColumn();
            columnName = new DataGridViewTextBoxColumn();
            columnStockQuantity = new DataGridViewTextBoxColumn();
            lblFilter = new Label();
            lblStore = new Label();
            lblMaterialType = new Label();
            comboBoxMaterials = new ComboBox();
            comboBoxStores = new ComboBox();
            panelHorizontalLine = new Panel();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripNavigationBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewItemInventory).BeginInit();
            SuspendLayout();
            // 
            // toolStripNavigationBar
            // 
            toolStripNavigationBar.BackColor = SystemColors.GradientInactiveCaption;
            toolStripNavigationBar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            toolStripNavigationBar.ImageScalingSize = new Size(24, 24);
            toolStripNavigationBar.Items.AddRange(new ToolStripItem[] { toolStripButtonMaterial, toolStripSeparator1, toolStripButtonProduct });
            toolStripNavigationBar.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            toolStripNavigationBar.Location = new Point(0, 0);
            toolStripNavigationBar.Name = "toolStripNavigationBar";
            toolStripNavigationBar.Padding = new Padding(0, 0, 3, 0);
            toolStripNavigationBar.RenderMode = ToolStripRenderMode.Professional;
            toolStripNavigationBar.Size = new Size(1653, 41);
            toolStripNavigationBar.TabIndex = 0;
            toolStripNavigationBar.Text = "toolStrip1";
            // 
            // toolStripButtonMaterial
            // 
            toolStripButtonMaterial.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButtonMaterial.Image = (Image)resources.GetObject("toolStripButtonMaterial.Image");
            toolStripButtonMaterial.ImageTransparentColor = Color.Magenta;
            toolStripButtonMaterial.Name = "toolStripButtonMaterial";
            toolStripButtonMaterial.Size = new Size(105, 36);
            toolStripButtonMaterial.Text = "Material";
            toolStripButtonMaterial.Click += toolStripButton1_Click;
            // 
            // toolStripButtonProduct
            // 
            toolStripButtonProduct.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButtonProduct.Image = (Image)resources.GetObject("toolStripButtonProduct.Image");
            toolStripButtonProduct.ImageTransparentColor = Color.Magenta;
            toolStripButtonProduct.Name = "toolStripButtonProduct";
            toolStripButtonProduct.Size = new Size(100, 36);
            toolStripButtonProduct.Text = "Product";
            toolStripButtonProduct.Click += toolStripButton2_Click;
            // 
            // dataGridViewItemInventory
            // 
            dataGridViewItemInventory.BackgroundColor = SystemColors.Menu;
            dataGridViewItemInventory.BorderStyle = BorderStyle.None;
            dataGridViewItemInventory.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridViewItemInventory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewItemInventory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewItemInventory.Columns.AddRange(new DataGridViewColumn[] { columnOrder, columnID, columnName, columnStockQuantity });
            dataGridViewItemInventory.Location = new Point(77, 262);
            dataGridViewItemInventory.Name = "dataGridViewItemInventory";
            dataGridViewItemInventory.RowHeadersWidth = 62;
            dataGridViewItemInventory.Size = new Size(782, 641);
            dataGridViewItemInventory.TabIndex = 1;
            // 
            // columnOrder
            // 
            columnOrder.HeaderText = "#";
            columnOrder.MinimumWidth = 8;
            columnOrder.Name = "columnOrder";
            columnOrder.Resizable = DataGridViewTriState.False;
            columnOrder.Width = 80;
            // 
            // columnID
            // 
            columnID.HeaderText = "ID";
            columnID.MinimumWidth = 8;
            columnID.Name = "columnID";
            columnID.Resizable = DataGridViewTriState.False;
            columnID.Width = 150;
            // 
            // columnName
            // 
            columnName.HeaderText = "Name";
            columnName.MinimumWidth = 8;
            columnName.Name = "columnName";
            columnName.Resizable = DataGridViewTriState.False;
            columnName.Width = 250;
            // 
            // columnStockQuantity
            // 
            columnStockQuantity.HeaderText = "StockQuantity";
            columnStockQuantity.MinimumWidth = 8;
            columnStockQuantity.Name = "columnStockQuantity";
            columnStockQuantity.Resizable = DataGridViewTriState.False;
            columnStockQuantity.Width = 200;
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
            // comboBoxMaterials
            // 
            comboBoxMaterials.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMaterials.FormattingEnabled = true;
            comboBoxMaterials.Items.AddRange(new object[] { "all", "flower", "accessory" });
            comboBoxMaterials.Location = new Point(622, 168);
            comboBoxMaterials.Name = "comboBoxMaterials";
            comboBoxMaterials.Size = new Size(204, 40);
            comboBoxMaterials.TabIndex = 6;
            // 
            // comboBoxStores
            // 
            comboBoxStores.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxStores.FormattingEnabled = true;
            comboBoxStores.Items.AddRange(new object[] { "current", "store 01", "store 02", "store 03", "store 04", "store 05" });
            comboBoxStores.Location = new Point(224, 168);
            comboBoxStores.Name = "comboBoxStores";
            comboBoxStores.Size = new Size(204, 40);
            comboBoxStores.TabIndex = 7;
            // 
            // panelHorizontalLine
            // 
            panelHorizontalLine.BackColor = SystemColors.ActiveBorder;
            panelHorizontalLine.Location = new Point(145, 150);
            panelHorizontalLine.Name = "panelHorizontalLine";
            panelHorizontalLine.Size = new Size(730, 1);
            panelHorizontalLine.TabIndex = 8;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 41);
            // 
            // InventoryForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1653, 944);
            Controls.Add(panelHorizontalLine);
            Controls.Add(comboBoxStores);
            Controls.Add(comboBoxMaterials);
            Controls.Add(lblMaterialType);
            Controls.Add(lblStore);
            Controls.Add(lblFilter);
            Controls.Add(dataGridViewItemInventory);
            Controls.Add(toolStripNavigationBar);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "InventoryForm";
            Load += Inventory_Form_Load;
            toolStripNavigationBar.ResumeLayout(false);
            toolStripNavigationBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewItemInventory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStripNavigationBar;
        private ToolStripButton toolStripButtonMaterial;
        private ToolStripButton toolStripButtonProduct;
        private DataGridView dataGridViewItemInventory;
        private Label lblFilter;
        private Label lblStore;
        private Label lblMaterialType;
        private ComboBox comboBoxMaterials;
        private ComboBox comboBoxStores;
        private Panel panelHorizontalLine;
        private DataGridViewTextBoxColumn columnOrder;
        private DataGridViewTextBoxColumn columnID;
        private DataGridViewTextBoxColumn columnName;
        private DataGridViewTextBoxColumn columnStockQuantity;
        private ToolStripSeparator toolStripSeparator1;
    }
}