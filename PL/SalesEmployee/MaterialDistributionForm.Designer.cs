namespace PL.SalesEmployee
{
    partial class MaterialDistributionForm
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
            tabControl1 = new TabControl();
            tpPurchaseOrder = new TabPage();
            dataGridView1 = new DataGridView();
            tpAccessory = new TabPage();
            lblRegionFilterA = new Label();
            cmbBxRegionsA = new ComboBox();
            btnClearA = new Button();
            btnDistributeA = new Button();
            lblStoreNameA = new Label();
            cmbBxStoresA = new ComboBox();
            dgvAccessoryDistribution = new DataGridView();
            ColAccessoryId = new DataGridViewTextBoxColumn();
            ColAccessoryName = new DataGridViewTextBoxColumn();
            ColCurrentQuantity = new DataGridViewTextBoxColumn();
            ColDistributionQuantity = new DataGridViewTextBoxColumn();
            tpFlower = new TabPage();
            lblRegionFilterF = new Label();
            cmbBxRegionsF = new ComboBox();
            btnClearF = new Button();
            btnDistributeF = new Button();
            cmbBxStoresF = new ComboBox();
            lblStoreNameF = new Label();
            dgvFlowerDistribution = new DataGridView();
            ColFlowerId = new DataGridViewTextBoxColumn();
            ColFlowerName = new DataGridViewTextBoxColumn();
            ColFType = new DataGridViewTextBoxColumn();
            ColFColor = new DataGridViewTextBoxColumn();
            ColFChar = new DataGridViewTextBoxColumn();
            ColCurrentFlowerQuantity = new DataGridViewTextBoxColumn();
            ColDistributionFlowerQuantity = new DataGridViewTextBoxColumn();
            cmbBxFChar = new ComboBox();
            cmbBxFColor = new ComboBox();
            lblFType = new Label();
            cmbBxFType = new ComboBox();
            lblFColor = new Label();
            lblFChar = new Label();
            ColPOId = new DataGridViewTextBoxColumn();
            ColPurchaseDatetime = new DataGridViewTextBoxColumn();
            ColPOType = new DataGridViewTextBoxColumn();
            ColDistributionStatus = new DataGridViewTextBoxColumn();
            ColSelection = new DataGridViewCheckBoxColumn();
            tabControl1.SuspendLayout();
            tpPurchaseOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tpAccessory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAccessoryDistribution).BeginInit();
            tpFlower.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFlowerDistribution).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tpPurchaseOrder);
            tabControl1.Controls.Add(tpAccessory);
            tabControl1.Controls.Add(tpFlower);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1924, 1050);
            tabControl1.TabIndex = 0;
            // 
            // tpPurchaseOrder
            // 
            tpPurchaseOrder.Controls.Add(dataGridView1);
            tpPurchaseOrder.Location = new Point(4, 41);
            tpPurchaseOrder.Name = "tpPurchaseOrder";
            tpPurchaseOrder.Padding = new Padding(3);
            tpPurchaseOrder.Size = new Size(1916, 1005);
            tpPurchaseOrder.TabIndex = 0;
            tpPurchaseOrder.Text = "Purchase Order";
            tpPurchaseOrder.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ColPOId, ColPurchaseDatetime, ColPOType, ColDistributionStatus, ColSelection });
            dataGridView1.Location = new Point(51, 48);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1054, 866);
            dataGridView1.TabIndex = 0;
            // 
            // tpAccessory
            // 
            tpAccessory.Controls.Add(lblRegionFilterA);
            tpAccessory.Controls.Add(cmbBxRegionsA);
            tpAccessory.Controls.Add(btnClearA);
            tpAccessory.Controls.Add(btnDistributeA);
            tpAccessory.Controls.Add(lblStoreNameA);
            tpAccessory.Controls.Add(cmbBxStoresA);
            tpAccessory.Controls.Add(dgvAccessoryDistribution);
            tpAccessory.Location = new Point(4, 41);
            tpAccessory.Name = "tpAccessory";
            tpAccessory.Padding = new Padding(3);
            tpAccessory.Size = new Size(1916, 1005);
            tpAccessory.TabIndex = 1;
            tpAccessory.Text = "Accessory";
            tpAccessory.UseVisualStyleBackColor = true;
            // 
            // lblRegionFilterA
            // 
            lblRegionFilterA.AutoSize = true;
            lblRegionFilterA.Location = new Point(865, 258);
            lblRegionFilterA.Name = "lblRegionFilterA";
            lblRegionFilterA.Size = new Size(181, 32);
            lblRegionFilterA.TabIndex = 6;
            lblRegionFilterA.Text = "Filter by Region";
            // 
            // cmbBxRegionsA
            // 
            cmbBxRegionsA.FormattingEnabled = true;
            cmbBxRegionsA.Location = new Point(1070, 258);
            cmbBxRegionsA.Name = "cmbBxRegionsA";
            cmbBxRegionsA.Size = new Size(186, 40);
            cmbBxRegionsA.TabIndex = 5;
            // 
            // btnClearA
            // 
            btnClearA.Location = new Point(1104, 403);
            btnClearA.Name = "btnClearA";
            btnClearA.Size = new Size(152, 55);
            btnClearA.TabIndex = 4;
            btnClearA.Text = "Clear";
            btnClearA.UseVisualStyleBackColor = true;
            btnClearA.Click += btnClear_Click;
            // 
            // btnDistributeA
            // 
            btnDistributeA.Location = new Point(937, 403);
            btnDistributeA.Name = "btnDistributeA";
            btnDistributeA.Size = new Size(152, 55);
            btnDistributeA.TabIndex = 3;
            btnDistributeA.Text = "Distribute";
            btnDistributeA.UseVisualStyleBackColor = true;
            // 
            // lblStoreNameA
            // 
            lblStoreNameA.AutoSize = true;
            lblStoreNameA.Location = new Point(970, 307);
            lblStoreNameA.Name = "lblStoreNameA";
            lblStoreNameA.Size = new Size(76, 32);
            lblStoreNameA.TabIndex = 2;
            lblStoreNameA.Text = "Store ";
            // 
            // cmbBxStoresA
            // 
            cmbBxStoresA.FormattingEnabled = true;
            cmbBxStoresA.Location = new Point(1070, 304);
            cmbBxStoresA.Name = "cmbBxStoresA";
            cmbBxStoresA.Size = new Size(186, 40);
            cmbBxStoresA.TabIndex = 1;
            // 
            // dgvAccessoryDistribution
            // 
            dgvAccessoryDistribution.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAccessoryDistribution.Columns.AddRange(new DataGridViewColumn[] { ColAccessoryId, ColAccessoryName, ColCurrentQuantity, ColDistributionQuantity });
            dgvAccessoryDistribution.Location = new Point(91, 98);
            dgvAccessoryDistribution.Name = "dgvAccessoryDistribution";
            dgvAccessoryDistribution.RowHeadersWidth = 62;
            dgvAccessoryDistribution.Size = new Size(694, 658);
            dgvAccessoryDistribution.TabIndex = 0;
            // 
            // ColAccessoryId
            // 
            ColAccessoryId.HeaderText = "ID";
            ColAccessoryId.MinimumWidth = 8;
            ColAccessoryId.Name = "ColAccessoryId";
            ColAccessoryId.ReadOnly = true;
            ColAccessoryId.Width = 150;
            // 
            // ColAccessoryName
            // 
            ColAccessoryName.HeaderText = "Name";
            ColAccessoryName.MinimumWidth = 8;
            ColAccessoryName.Name = "ColAccessoryName";
            ColAccessoryName.ReadOnly = true;
            ColAccessoryName.Width = 150;
            // 
            // ColCurrentQuantity
            // 
            ColCurrentQuantity.HeaderText = "AsIs Q";
            ColCurrentQuantity.MinimumWidth = 8;
            ColCurrentQuantity.Name = "ColCurrentQuantity";
            ColCurrentQuantity.ReadOnly = true;
            ColCurrentQuantity.Width = 150;
            // 
            // ColDistributionQuantity
            // 
            ColDistributionQuantity.HeaderText = "Dis Q";
            ColDistributionQuantity.MinimumWidth = 8;
            ColDistributionQuantity.Name = "ColDistributionQuantity";
            ColDistributionQuantity.Width = 150;
            // 
            // tpFlower
            // 
            tpFlower.Controls.Add(lblFChar);
            tpFlower.Controls.Add(lblFColor);
            tpFlower.Controls.Add(cmbBxFType);
            tpFlower.Controls.Add(lblFType);
            tpFlower.Controls.Add(cmbBxFColor);
            tpFlower.Controls.Add(cmbBxFChar);
            tpFlower.Controls.Add(lblRegionFilterF);
            tpFlower.Controls.Add(cmbBxRegionsF);
            tpFlower.Controls.Add(btnClearF);
            tpFlower.Controls.Add(btnDistributeF);
            tpFlower.Controls.Add(cmbBxStoresF);
            tpFlower.Controls.Add(lblStoreNameF);
            tpFlower.Controls.Add(dgvFlowerDistribution);
            tpFlower.Location = new Point(4, 41);
            tpFlower.Name = "tpFlower";
            tpFlower.Size = new Size(1916, 1005);
            tpFlower.TabIndex = 2;
            tpFlower.Text = "Flower";
            tpFlower.UseVisualStyleBackColor = true;
            // 
            // lblRegionFilterF
            // 
            lblRegionFilterF.AutoSize = true;
            lblRegionFilterF.Location = new Point(1414, 261);
            lblRegionFilterF.Name = "lblRegionFilterF";
            lblRegionFilterF.Size = new Size(181, 32);
            lblRegionFilterF.TabIndex = 6;
            lblRegionFilterF.Text = "Filter by Region";
            // 
            // cmbBxRegionsF
            // 
            cmbBxRegionsF.FormattingEnabled = true;
            cmbBxRegionsF.Location = new Point(1610, 261);
            cmbBxRegionsF.Name = "cmbBxRegionsF";
            cmbBxRegionsF.Size = new Size(236, 40);
            cmbBxRegionsF.TabIndex = 5;
            // 
            // btnClearF
            // 
            btnClearF.Location = new Point(1674, 406);
            btnClearF.Name = "btnClearF";
            btnClearF.Size = new Size(172, 53);
            btnClearF.TabIndex = 4;
            btnClearF.Text = "Clear";
            btnClearF.UseVisualStyleBackColor = true;
            // 
            // btnDistributeF
            // 
            btnDistributeF.Location = new Point(1496, 406);
            btnDistributeF.Name = "btnDistributeF";
            btnDistributeF.Size = new Size(172, 53);
            btnDistributeF.TabIndex = 3;
            btnDistributeF.Text = "Distribute";
            btnDistributeF.UseVisualStyleBackColor = true;
            // 
            // cmbBxStoresF
            // 
            cmbBxStoresF.FormattingEnabled = true;
            cmbBxStoresF.Location = new Point(1610, 316);
            cmbBxStoresF.Name = "cmbBxStoresF";
            cmbBxStoresF.Size = new Size(236, 40);
            cmbBxStoresF.TabIndex = 2;
            // 
            // lblStoreNameF
            // 
            lblStoreNameF.AutoSize = true;
            lblStoreNameF.Location = new Point(1526, 319);
            lblStoreNameF.Name = "lblStoreNameF";
            lblStoreNameF.Size = new Size(69, 32);
            lblStoreNameF.TabIndex = 1;
            lblStoreNameF.Text = "Store";
            // 
            // dgvFlowerDistribution
            // 
            dgvFlowerDistribution.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFlowerDistribution.Columns.AddRange(new DataGridViewColumn[] { ColFlowerId, ColFlowerName, ColFType, ColFColor, ColFChar, ColCurrentFlowerQuantity, ColDistributionFlowerQuantity });
            dgvFlowerDistribution.Location = new Point(22, 206);
            dgvFlowerDistribution.Name = "dgvFlowerDistribution";
            dgvFlowerDistribution.RowHeadersWidth = 62;
            dgvFlowerDistribution.Size = new Size(1250, 710);
            dgvFlowerDistribution.TabIndex = 0;
            // 
            // ColFlowerId
            // 
            ColFlowerId.FillWeight = 50F;
            ColFlowerId.HeaderText = "ID";
            ColFlowerId.MinimumWidth = 8;
            ColFlowerId.Name = "ColFlowerId";
            ColFlowerId.ReadOnly = true;
            // 
            // ColFlowerName
            // 
            ColFlowerName.HeaderText = "Name";
            ColFlowerName.MinimumWidth = 8;
            ColFlowerName.Name = "ColFlowerName";
            ColFlowerName.ReadOnly = true;
            ColFlowerName.Width = 200;
            // 
            // ColFType
            // 
            ColFType.HeaderText = "FType";
            ColFType.MinimumWidth = 8;
            ColFType.Name = "ColFType";
            ColFType.ReadOnly = true;
            ColFType.Width = 200;
            // 
            // ColFColor
            // 
            ColFColor.HeaderText = "FColor";
            ColFColor.MinimumWidth = 8;
            ColFColor.Name = "ColFColor";
            ColFColor.ReadOnly = true;
            ColFColor.Width = 150;
            // 
            // ColFChar
            // 
            ColFChar.HeaderText = "FChar";
            ColFChar.MinimumWidth = 8;
            ColFChar.Name = "ColFChar";
            ColFChar.ReadOnly = true;
            ColFChar.Width = 150;
            // 
            // ColCurrentFlowerQuantity
            // 
            ColCurrentFlowerQuantity.HeaderText = "AsIs Q";
            ColCurrentFlowerQuantity.MinimumWidth = 8;
            ColCurrentFlowerQuantity.Name = "ColCurrentFlowerQuantity";
            ColCurrentFlowerQuantity.ReadOnly = true;
            ColCurrentFlowerQuantity.Width = 150;
            // 
            // ColDistributionFlowerQuantity
            // 
            ColDistributionFlowerQuantity.FillWeight = 50F;
            ColDistributionFlowerQuantity.HeaderText = "Dis Q";
            ColDistributionFlowerQuantity.MinimumWidth = 8;
            ColDistributionFlowerQuantity.Name = "ColDistributionFlowerQuantity";
            ColDistributionFlowerQuantity.Width = 150;
            // 
            // cmbBxFChar
            // 
            cmbBxFChar.FormattingEnabled = true;
            cmbBxFChar.Location = new Point(672, 108);
            cmbBxFChar.Name = "cmbBxFChar";
            cmbBxFChar.Size = new Size(236, 40);
            cmbBxFChar.TabIndex = 7;
            // 
            // cmbBxFColor
            // 
            cmbBxFColor.FormattingEnabled = true;
            cmbBxFColor.Location = new Point(394, 108);
            cmbBxFColor.Name = "cmbBxFColor";
            cmbBxFColor.Size = new Size(236, 40);
            cmbBxFColor.TabIndex = 8;
            // 
            // lblFType
            // 
            lblFType.AutoSize = true;
            lblFType.Location = new Point(110, 58);
            lblFType.Name = "lblFType";
            lblFType.Size = new Size(77, 32);
            lblFType.TabIndex = 9;
            lblFType.Text = "FType";
            // 
            // cmbBxFType
            // 
            cmbBxFType.FormattingEnabled = true;
            cmbBxFType.Location = new Point(110, 108);
            cmbBxFType.Name = "cmbBxFType";
            cmbBxFType.Size = new Size(236, 40);
            cmbBxFType.TabIndex = 10;
            // 
            // lblFColor
            // 
            lblFColor.AutoSize = true;
            lblFColor.Location = new Point(394, 58);
            lblFColor.Name = "lblFColor";
            lblFColor.Size = new Size(83, 32);
            lblFColor.TabIndex = 11;
            lblFColor.Text = "FColor";
            // 
            // lblFChar
            // 
            lblFChar.AutoSize = true;
            lblFChar.Location = new Point(672, 58);
            lblFChar.Name = "lblFChar";
            lblFChar.Size = new Size(75, 32);
            lblFChar.TabIndex = 12;
            lblFChar.Text = "FChar";
            // 
            // ColPOId
            // 
            ColPOId.HeaderText = "ID";
            ColPOId.MinimumWidth = 8;
            ColPOId.Name = "ColPOId";
            ColPOId.ReadOnly = true;
            ColPOId.Width = 150;
            // 
            // ColPurchaseDatetime
            // 
            ColPurchaseDatetime.HeaderText = "Purchase Time";
            ColPurchaseDatetime.MinimumWidth = 8;
            ColPurchaseDatetime.Name = "ColPurchaseDatetime";
            ColPurchaseDatetime.ReadOnly = true;
            ColPurchaseDatetime.Width = 250;
            // 
            // ColPOType
            // 
            ColPOType.HeaderText = "Order Type";
            ColPOType.MinimumWidth = 8;
            ColPOType.Name = "ColPOType";
            ColPOType.ReadOnly = true;
            ColPOType.Width = 200;
            // 
            // ColDistributionStatus
            // 
            ColDistributionStatus.HeaderText = "Status";
            ColDistributionStatus.MinimumWidth = 8;
            ColDistributionStatus.Name = "ColDistributionStatus";
            ColDistributionStatus.ReadOnly = true;
            ColDistributionStatus.Resizable = DataGridViewTriState.True;
            ColDistributionStatus.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColDistributionStatus.Width = 200;
            // 
            // ColSelection
            // 
            ColSelection.HeaderText = "";
            ColSelection.MinimumWidth = 8;
            ColSelection.Name = "ColSelection";
            ColSelection.Width = 80;
            // 
            // MaterialDistributionForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1924, 1050);
            Controls.Add(tabControl1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "MaterialDistributionForm";
            Text = "MaterialDistributionForm";
            tabControl1.ResumeLayout(false);
            tpPurchaseOrder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tpAccessory.ResumeLayout(false);
            tpAccessory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAccessoryDistribution).EndInit();
            tpFlower.ResumeLayout(false);
            tpFlower.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFlowerDistribution).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tpPurchaseOrder;
        private TabPage tpAccessory;
        private TabPage tpFlower;
        private DataGridView dataGridView1;
        private DataGridView dgvAccessoryDistribution;
        private DataGridView dgvFlowerDistribution;
        private DataGridViewTextBoxColumn ColAccessoryId;
        private DataGridViewTextBoxColumn ColAccessoryName;
        private DataGridViewTextBoxColumn ColCurrentQuantity;
        private DataGridViewTextBoxColumn ColDistributionQuantity;
        private Button btnDistributeA;
        private Label lblStoreNameA;
        private ComboBox cmbBxStoresA;
        private Button btnClearA;
        private Label lblRegionFilterA;
        private ComboBox cmbBxRegionsA;
        private Button btnClearF;
        private Button btnDistributeF;
        private ComboBox cmbBxStoresF;
        private Label lblStoreNameF;
        private Label lblRegionFilterF;
        private ComboBox cmbBxRegionsF;
        private DataGridViewTextBoxColumn ColFlowerId;
        private DataGridViewTextBoxColumn ColFlowerName;
        private DataGridViewTextBoxColumn ColFType;
        private DataGridViewTextBoxColumn ColFColor;
        private DataGridViewTextBoxColumn ColFChar;
        private DataGridViewTextBoxColumn ColCurrentFlowerQuantity;
        private DataGridViewTextBoxColumn ColDistributionFlowerQuantity;
        private Label lblFChar;
        private Label lblFColor;
        private ComboBox cmbBxFType;
        private Label lblFType;
        private ComboBox cmbBxFColor;
        private ComboBox cmbBxFChar;
        private DataGridViewTextBoxColumn ColPOId;
        private DataGridViewTextBoxColumn ColPurchaseDatetime;
        private DataGridViewTextBoxColumn ColPOType;
        private DataGridViewTextBoxColumn ColDistributionStatus;
        private DataGridViewCheckBoxColumn ColSelection;
    }
}