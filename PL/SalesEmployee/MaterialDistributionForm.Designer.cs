using DL.Models;
using DTO.Enum.SalesOrder;

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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            numericUdDisQuantity = new NumericUpDown();
            lblDisQuantity = new Label();
            label3 = new Label();
            cmbBxOrderType = new ComboBox();
            dgvFlowers = new DataGridView();
            ColFlowerId = new DataGridViewTextBoxColumn();
            ColFlowerName = new DataGridViewTextBoxColumn();
            ColFColor = new DataGridViewTextBoxColumn();
            ColFChar = new DataGridViewTextBoxColumn();
            ColFQuantity = new DataGridViewTextBoxColumn();
            ColFSelection = new DataGridViewCheckBoxColumn();
            lblRegion = new Label();
            cmbBxRegions = new ComboBox();
            btnDistribute = new Button();
            lblStore = new Label();
            cmbBxStores = new ComboBox();
            dgvPurchaseOrders = new DataGridView();
            ColPOId = new DataGridViewTextBoxColumn();
            ColPurchasedDateTime = new DataGridViewTextBoxColumn();
            ColOrderType = new DataGridViewTextBoxColumn();
            ColDistributionStatus = new DataGridViewTextBoxColumn();
            lblPurchaseOrder = new Label();
            lblMaterial = new Label();
            dgvAccessories = new DataGridView();
            ColAccessoryId = new DataGridViewTextBoxColumn();
            ColAccessoryName = new DataGridViewTextBoxColumn();
            ColAQuantity = new DataGridViewTextBoxColumn();
            ColASelection = new DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)numericUdDisQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvFlowers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPurchaseOrders).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvAccessories).BeginInit();
            SuspendLayout();
            // 
            // numericUdDisQuantity
            // 
            numericUdDisQuantity.Location = new Point(972, 188);
            numericUdDisQuantity.Name = "numericUdDisQuantity";
            numericUdDisQuantity.Size = new Size(147, 39);
            numericUdDisQuantity.TabIndex = 18;
            // 
            // lblDisQuantity
            // 
            lblDisQuantity.AutoSize = true;
            lblDisQuantity.Location = new Point(972, 149);
            lblDisQuantity.Name = "lblDisQuantity";
            lblDisQuantity.Size = new Size(146, 32);
            lblDisQuantity.TabIndex = 17;
            lblDisQuantity.Text = "Dis Quantity";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(617, 52);
            label3.Name = "label3";
            label3.Size = new Size(65, 32);
            label3.TabIndex = 15;
            label3.Text = "Type";
            // 
            // cmbBxOrderType
            // 
            cmbBxOrderType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBxOrderType.FormattingEnabled = true;
            cmbBxOrderType.Location = new Point(688, 49);
            cmbBxOrderType.Name = "cmbBxOrderType";
            cmbBxOrderType.Size = new Size(186, 40);
            cmbBxOrderType.TabIndex = 14;
            cmbBxOrderType.SelectedValueChanged += cmbBxOrderType_SelectedValueChanged;
            // 
            // dgvFlowers
            // 
            dgvFlowers.AllowUserToAddRows = false;
            dgvFlowers.AllowUserToDeleteRows = false;
            dgvFlowers.AllowUserToResizeColumns = false;
            dgvFlowers.AllowUserToResizeRows = false;
            dgvFlowers.BackgroundColor = SystemColors.Control;
            dgvFlowers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFlowers.Columns.AddRange(new DataGridViewColumn[] { ColFlowerId, ColFlowerName, ColFColor, ColFChar, ColFQuantity, ColFSelection });
            dgvFlowers.Location = new Point(34, 542);
            dgvFlowers.Name = "dgvFlowers";
            dgvFlowers.RowHeadersVisible = false;
            dgvFlowers.RowHeadersWidth = 62;
            dgvFlowers.Size = new Size(865, 367);
            dgvFlowers.TabIndex = 13;
            // 
            // ColFlowerId
            // 
            ColFlowerId.FillWeight = 26.1291237F;
            ColFlowerId.HeaderText = "ID";
            ColFlowerId.MinimumWidth = 8;
            ColFlowerId.Name = "ColFlowerId";
            ColFlowerId.Width = 80;
            // 
            // ColFlowerName
            // 
            ColFlowerName.FillWeight = 26.1291237F;
            ColFlowerName.HeaderText = "Name";
            ColFlowerName.MinimumWidth = 8;
            ColFlowerName.Name = "ColFlowerName";
            ColFlowerName.Width = 250;
            // 
            // ColFColor
            // 
            ColFColor.FillWeight = 26.1291237F;
            ColFColor.HeaderText = "Color";
            ColFColor.MinimumWidth = 8;
            ColFColor.Name = "ColFColor";
            ColFColor.Width = 150;
            // 
            // ColFChar
            // 
            ColFChar.FillWeight = 284.0909F;
            ColFChar.HeaderText = "Char";
            ColFChar.MinimumWidth = 8;
            ColFChar.Name = "ColFChar";
            ColFChar.Width = 150;
            // 
            // ColFQuantity
            // 
            ColFQuantity.FillWeight = 137.521713F;
            ColFQuantity.HeaderText = "Q";
            ColFQuantity.MinimumWidth = 8;
            ColFQuantity.Name = "ColFQuantity";
            ColFQuantity.Width = 150;
            // 
            // ColFSelection
            // 
            ColFSelection.HeaderText = "";
            ColFSelection.MinimumWidth = 8;
            ColFSelection.Name = "ColFSelection";
            ColFSelection.Width = 50;
            // 
            // lblRegion
            // 
            lblRegion.AutoSize = true;
            lblRegion.Location = new Point(1141, 144);
            lblRegion.Name = "lblRegion";
            lblRegion.Size = new Size(88, 32);
            lblRegion.TabIndex = 12;
            lblRegion.Text = "Region";
            // 
            // cmbBxRegions
            // 
            cmbBxRegions.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBxRegions.FormattingEnabled = true;
            cmbBxRegions.Location = new Point(1235, 141);
            cmbBxRegions.Name = "cmbBxRegions";
            cmbBxRegions.Size = new Size(186, 40);
            cmbBxRegions.TabIndex = 11;
            cmbBxRegions.SelectedValueChanged += cmbBxRegions_SelectedValueChanged;
            // 
            // btnDistribute
            // 
            btnDistribute.Location = new Point(1118, 285);
            btnDistribute.Name = "btnDistribute";
            btnDistribute.Size = new Size(152, 55);
            btnDistribute.TabIndex = 9;
            btnDistribute.Text = "Distribute";
            btnDistribute.UseVisualStyleBackColor = true;
            btnDistribute.Click += btnDistribute_Click;
            // 
            // lblStore
            // 
            lblStore.AutoSize = true;
            lblStore.Location = new Point(1153, 192);
            lblStore.Name = "lblStore";
            lblStore.Size = new Size(76, 32);
            lblStore.TabIndex = 8;
            lblStore.Text = "Store ";
            // 
            // cmbBxStores
            // 
            cmbBxStores.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBxStores.FormattingEnabled = true;
            cmbBxStores.Location = new Point(1235, 189);
            cmbBxStores.Name = "cmbBxStores";
            cmbBxStores.Size = new Size(186, 40);
            cmbBxStores.TabIndex = 7;
            // 
            // dgvPurchaseOrders
            // 
            dgvPurchaseOrders.AllowUserToAddRows = false;
            dgvPurchaseOrders.AllowUserToDeleteRows = false;
            dgvPurchaseOrders.AllowUserToResizeColumns = false;
            dgvPurchaseOrders.AllowUserToResizeRows = false;
            dgvPurchaseOrders.BackgroundColor = SystemColors.Control;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(193, 255, 255);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvPurchaseOrders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvPurchaseOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPurchaseOrders.Columns.AddRange(new DataGridViewColumn[] { ColPOId, ColPurchasedDateTime, ColOrderType, ColDistributionStatus });
            dgvPurchaseOrders.Location = new Point(34, 110);
            dgvPurchaseOrders.Name = "dgvPurchaseOrders";
            dgvPurchaseOrders.ReadOnly = true;
            dgvPurchaseOrders.RowHeadersWidth = 62;
            dgvPurchaseOrders.Size = new Size(840, 344);
            dgvPurchaseOrders.TabIndex = 0;
            dgvPurchaseOrders.CellClick += dgvPurchaseOrders_CellClick;
            // 
            // ColPOId
            // 
            ColPOId.FillWeight = 452.9416F;
            ColPOId.HeaderText = "ID";
            ColPOId.MinimumWidth = 8;
            ColPOId.Name = "ColPOId";
            ColPOId.ReadOnly = true;
            ColPOId.Width = 150;
            // 
            // ColPurchasedDateTime
            // 
            dataGridViewCellStyle6.BackColor = Color.White;
            ColPurchasedDateTime.DefaultCellStyle = dataGridViewCellStyle6;
            ColPurchasedDateTime.FillWeight = 8.544964F;
            ColPurchasedDateTime.HeaderText = "Time";
            ColPurchasedDateTime.MinimumWidth = 8;
            ColPurchasedDateTime.Name = "ColPurchasedDateTime";
            ColPurchasedDateTime.ReadOnly = true;
            ColPurchasedDateTime.Width = 170;
            // 
            // ColOrderType
            // 
            ColOrderType.FillWeight = 61.7704048F;
            ColOrderType.HeaderText = "Type";
            ColOrderType.MinimumWidth = 8;
            ColOrderType.Name = "ColOrderType";
            ColOrderType.ReadOnly = true;
            ColOrderType.Width = 150;
            // 
            // ColDistributionStatus
            // 
            ColDistributionStatus.FillWeight = 1.20172524F;
            ColDistributionStatus.HeaderText = "Status";
            ColDistributionStatus.MinimumWidth = 8;
            ColDistributionStatus.Name = "ColDistributionStatus";
            ColDistributionStatus.ReadOnly = true;
            ColDistributionStatus.Resizable = DataGridViewTriState.True;
            ColDistributionStatus.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColDistributionStatus.Width = 250;
            // 
            // lblPurchaseOrder
            // 
            lblPurchaseOrder.AutoSize = true;
            lblPurchaseOrder.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPurchaseOrder.Location = new Point(34, 46);
            lblPurchaseOrder.Name = "lblPurchaseOrder";
            lblPurchaseOrder.Size = new Size(211, 38);
            lblPurchaseOrder.TabIndex = 19;
            lblPurchaseOrder.Text = "Purchase Order";
            // 
            // lblMaterial
            // 
            lblMaterial.AutoSize = true;
            lblMaterial.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMaterial.Location = new Point(34, 483);
            lblMaterial.Name = "lblMaterial";
            lblMaterial.Size = new Size(122, 38);
            lblMaterial.TabIndex = 20;
            lblMaterial.Text = "Material";
            // 
            // dgvAccessories
            // 
            dgvAccessories.AllowUserToAddRows = false;
            dgvAccessories.AllowUserToDeleteRows = false;
            dgvAccessories.AllowUserToResizeColumns = false;
            dgvAccessories.AllowUserToResizeRows = false;
            dgvAccessories.BackgroundColor = SystemColors.Control;
            dgvAccessories.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAccessories.Columns.AddRange(new DataGridViewColumn[] { ColAccessoryId, ColAccessoryName, ColAQuantity, ColASelection });
            dgvAccessories.Location = new Point(34, 542);
            dgvAccessories.Name = "dgvAccessories";
            dgvAccessories.RowHeadersVisible = false;
            dgvAccessories.RowHeadersWidth = 62;
            dgvAccessories.Size = new Size(557, 367);
            dgvAccessories.TabIndex = 21;
            // 
            // ColAccessoryId
            // 
            ColAccessoryId.FillWeight = 26.1291237F;
            ColAccessoryId.HeaderText = "ID";
            ColAccessoryId.MinimumWidth = 8;
            ColAccessoryId.Name = "ColAccessoryId";
            ColAccessoryId.ReadOnly = true;
            ColAccessoryId.Width = 80;
            // 
            // ColAccessoryName
            // 
            ColAccessoryName.FillWeight = 26.1291237F;
            ColAccessoryName.HeaderText = "Name";
            ColAccessoryName.MinimumWidth = 8;
            ColAccessoryName.Name = "ColAccessoryName";
            ColAccessoryName.ReadOnly = true;
            ColAccessoryName.Width = 250;
            // 
            // ColAQuantity
            // 
            ColAQuantity.FillWeight = 137.521713F;
            ColAQuantity.HeaderText = "Q";
            ColAQuantity.MinimumWidth = 8;
            ColAQuantity.Name = "ColAQuantity";
            ColAQuantity.ReadOnly = true;
            ColAQuantity.Width = 150;
            // 
            // ColASelection
            // 
            ColASelection.HeaderText = "";
            ColASelection.MinimumWidth = 8;
            ColASelection.Name = "ColASelection";
            ColASelection.ReadOnly = true;
            ColASelection.Width = 50;
            // 
            // MaterialDistributionForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1500, 944);
            Controls.Add(dgvAccessories);
            Controls.Add(lblMaterial);
            Controls.Add(lblPurchaseOrder);
            Controls.Add(dgvFlowers);
            Controls.Add(numericUdDisQuantity);
            Controls.Add(lblDisQuantity);
            Controls.Add(dgvPurchaseOrders);
            Controls.Add(label3);
            Controls.Add(cmbBxOrderType);
            Controls.Add(cmbBxStores);
            Controls.Add(lblStore);
            Controls.Add(lblRegion);
            Controls.Add(btnDistribute);
            Controls.Add(cmbBxRegions);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "MaterialDistributionForm";
            Text = "MaterialDistributionForm";
            Load += MaterialDistributionForm_Load;
            ((System.ComponentModel.ISupportInitialize)numericUdDisQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvFlowers).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPurchaseOrders).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvAccessories).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dgvPurchaseOrders;
        private Label lblRegion;
        private ComboBox cmbBxRegions;
        private Button btnDistribute;
        private Label lblStore;
        private ComboBox cmbBxStores;
        private DataGridView dgvFlowers;
        private Label label3;
        private ComboBox cmbBxOrderType;
        private Label lblDisQuantity;
        private NumericUpDown numericUdDisQuantity;
        private DataGridViewTextBoxColumn ColPOId;
        private DataGridViewTextBoxColumn ColPurchasedDateTime;
        private DataGridViewTextBoxColumn ColOrderType;
        private DataGridViewTextBoxColumn ColDistributionStatus;
        private Label lblPurchaseOrder;
        private Label lblMaterial;
        private DataGridView dgvAccessories;
        private DataGridViewTextBoxColumn ColAccessoryId;
        private DataGridViewTextBoxColumn ColAccessoryName;
        private DataGridViewTextBoxColumn ColAQuantity;
        private DataGridViewCheckBoxColumn ColASelection;
        private DataGridViewTextBoxColumn ColFlowerId;
        private DataGridViewTextBoxColumn ColFlowerName;
        private DataGridViewTextBoxColumn ColFColor;
        private DataGridViewTextBoxColumn ColFChar;
        private DataGridViewTextBoxColumn ColFQuantity;
        private DataGridViewCheckBoxColumn ColFSelection;
    }
}