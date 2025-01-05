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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            txtDistributedQuantity = new NumericUpDown();
            lblDisQuantity = new Label();
            label3 = new Label();
            cmbBxOrderType = new ComboBox();
            dgvOrderDetails = new DataGridView();
            lblRegion = new Label();
            cmbBxRegions = new ComboBox();
            btnDistribute = new Button();
            lblStore = new Label();
            cmbBxStores = new ComboBox();
            dgvPurchaseOrders = new DataGridView();
            PurchaseOrderId = new DataGridViewTextBoxColumn();
            PurchasedDateTime = new DataGridViewTextBoxColumn();
            OrderType = new DataGridViewTextBoxColumn();
            DistributionStatus = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)txtDistributedQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvOrderDetails).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPurchaseOrders).BeginInit();
            SuspendLayout();
            // 
            // txtDistributedQuantity
            // 
            txtDistributedQuantity.Location = new Point(972, 188);
            txtDistributedQuantity.Name = "txtDistributedQuantity";
            txtDistributedQuantity.Size = new Size(147, 39);
            txtDistributedQuantity.TabIndex = 18;
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
            label3.Location = new Point(632, 67);
            label3.Name = "label3";
            label3.Size = new Size(65, 32);
            label3.TabIndex = 15;
            label3.Text = "Type";
            // 
            // cmbBxOrderType
            // 
            cmbBxOrderType.FormattingEnabled = true;
            cmbBxOrderType.Items.AddRange(new object[] { "Hoa", "Phụ liệu" });
            cmbBxOrderType.Location = new Point(703, 64);
            cmbBxOrderType.Name = "cmbBxOrderType";
            cmbBxOrderType.Size = new Size(186, 40);
            cmbBxOrderType.TabIndex = 14;
            cmbBxOrderType.SelectedValueChanged += cmbBxOrderType_SelectedValueChanged;
            // 
            // dgvOrderDetails
            // 
            dgvOrderDetails.AllowUserToAddRows = false;
            dgvOrderDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrderDetails.BackgroundColor = SystemColors.Control;
            dgvOrderDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrderDetails.Location = new Point(82, 601);
            dgvOrderDetails.Name = "dgvOrderDetails";
            dgvOrderDetails.ReadOnly = true;
            dgvOrderDetails.RowHeadersWidth = 62;
            dgvOrderDetails.Size = new Size(840, 407);
            dgvOrderDetails.TabIndex = 13;
            dgvOrderDetails.CellClick += dgvOrderDetails_CellClick;
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
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(193, 255, 255);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvPurchaseOrders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvPurchaseOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPurchaseOrders.Columns.AddRange(new DataGridViewColumn[] { PurchaseOrderId, PurchasedDateTime, OrderType, DistributionStatus });
            dgvPurchaseOrders.Location = new Point(82, 165);
            dgvPurchaseOrders.Name = "dgvPurchaseOrders";
            dgvPurchaseOrders.ReadOnly = true;
            dgvPurchaseOrders.RowHeadersWidth = 62;
            dgvPurchaseOrders.Size = new Size(840, 420);
            dgvPurchaseOrders.TabIndex = 0;
            dgvPurchaseOrders.CellClick += dgvPurchaseOrders_CellClick;
            // 
            // PurchaseOrderId
            // 
            PurchaseOrderId.DataPropertyName = "PurchaseOrderId";
            PurchaseOrderId.FillWeight = 452.9416F;
            PurchaseOrderId.HeaderText = "ID";
            PurchaseOrderId.MinimumWidth = 8;
            PurchaseOrderId.Name = "PurchaseOrderId";
            PurchaseOrderId.ReadOnly = true;
            PurchaseOrderId.Width = 150;
            // 
            // PurchasedDateTime
            // 
            PurchasedDateTime.DataPropertyName = "PurchasedDateTime";
            dataGridViewCellStyle2.BackColor = Color.White;
            PurchasedDateTime.DefaultCellStyle = dataGridViewCellStyle2;
            PurchasedDateTime.FillWeight = 8.544964F;
            PurchasedDateTime.HeaderText = "Purchase Time";
            PurchasedDateTime.MinimumWidth = 8;
            PurchasedDateTime.Name = "PurchasedDateTime";
            PurchasedDateTime.ReadOnly = true;
            PurchasedDateTime.Width = 250;
            // 
            // OrderType
            // 
            OrderType.DataPropertyName = "OrderType";
            OrderType.FillWeight = 61.7704048F;
            OrderType.HeaderText = "Order Type";
            OrderType.MinimumWidth = 8;
            OrderType.Name = "OrderType";
            OrderType.ReadOnly = true;
            OrderType.Width = 200;
            // 
            // DistributionStatus
            // 
            DistributionStatus.DataPropertyName = "DistributionStatus";
            DistributionStatus.FillWeight = 1.20172524F;
            DistributionStatus.HeaderText = "Status";
            DistributionStatus.MinimumWidth = 8;
            DistributionStatus.Name = "DistributionStatus";
            DistributionStatus.ReadOnly = true;
            DistributionStatus.Resizable = DataGridViewTriState.True;
            DistributionStatus.SortMode = DataGridViewColumnSortMode.NotSortable;
            DistributionStatus.Width = 150;
            // 
            // MaterialDistributionForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1500, 1050);
            Controls.Add(dgvOrderDetails);
            Controls.Add(txtDistributedQuantity);
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
            ((System.ComponentModel.ISupportInitialize)txtDistributedQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvOrderDetails).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPurchaseOrders).EndInit();
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
        private DataGridView dgvOrderDetails;
        private Label label3;
        private ComboBox cmbBxOrderType;
        private Label lblDisQuantity;
        private NumericUpDown txtDistributedQuantity;
        private DataGridViewTextBoxColumn PurchaseOrderId;
        private DataGridViewTextBoxColumn PurchasedDateTime;
        private DataGridViewTextBoxColumn OrderType;
        private DataGridViewTextBoxColumn DistributionStatus;
    }
}