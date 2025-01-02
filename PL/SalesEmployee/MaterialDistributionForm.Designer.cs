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
            tabControl1 = new TabControl();
            tpPurchaseOrder = new TabPage();
            txtDistributedQuantity = new NumericUpDown();
            label4 = new Label();
            label3 = new Label();
            cbbOrderType = new ComboBox();
            dgvOrderDetails = new DataGridView();
            lblRegion = new Label();
            cbbRegion = new ComboBox();
            btnClear = new Button();
            btnDistribute = new Button();
            lblStore = new Label();
            cbbStore = new ComboBox();
            dataOrder = new DataGridView();
            PurchaseOrderId = new DataGridViewTextBoxColumn();
            PurchasedDateTime = new DataGridViewTextBoxColumn();
            OrderType = new DataGridViewTextBoxColumn();
            DistributionStatus = new DataGridViewTextBoxColumn();
            tabControl1.SuspendLayout();
            tpPurchaseOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtDistributedQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvOrderDetails).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataOrder).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tpPurchaseOrder);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1500, 1050);
            tabControl1.TabIndex = 0;
            // 
            // tpPurchaseOrder
            // 
            tpPurchaseOrder.Controls.Add(txtDistributedQuantity);
            tpPurchaseOrder.Controls.Add(label4);
            tpPurchaseOrder.Controls.Add(label3);
            tpPurchaseOrder.Controls.Add(cbbOrderType);
            tpPurchaseOrder.Controls.Add(dgvOrderDetails);
            tpPurchaseOrder.Controls.Add(lblRegion);
            tpPurchaseOrder.Controls.Add(cbbRegion);
            tpPurchaseOrder.Controls.Add(btnClear);
            tpPurchaseOrder.Controls.Add(btnDistribute);
            tpPurchaseOrder.Controls.Add(lblStore);
            tpPurchaseOrder.Controls.Add(cbbStore);
            tpPurchaseOrder.Controls.Add(dataOrder);
            tpPurchaseOrder.Location = new Point(4, 41);
            tpPurchaseOrder.Name = "tpPurchaseOrder";
            tpPurchaseOrder.Padding = new Padding(3);
            tpPurchaseOrder.Size = new Size(1492, 1005);
            tpPurchaseOrder.TabIndex = 0;
            tpPurchaseOrder.Text = "Purchase Order";
            tpPurchaseOrder.UseVisualStyleBackColor = true;
            // 
            // txtDistributedQuantity
            // 
            txtDistributedQuantity.Location = new Point(960, 188);
            txtDistributedQuantity.Name = "txtDistributedQuantity";
            txtDistributedQuantity.Size = new Size(147, 39);
            txtDistributedQuantity.TabIndex = 18;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(960, 149);
            label4.Name = "label4";
            label4.Size = new Size(146, 32);
            label4.TabIndex = 17;
            label4.Text = "Dis Quantity";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(620, 67);
            label3.Name = "label3";
            label3.Size = new Size(65, 32);
            label3.TabIndex = 15;
            label3.Text = "Type";
            // 
            // cbbOrderType
            // 
            cbbOrderType.FormattingEnabled = true;
            cbbOrderType.Items.AddRange(new object[] { "Hoa", "Phụ liệu" });
            cbbOrderType.Location = new Point(691, 64);
            cbbOrderType.Name = "cbbOrderType";
            cbbOrderType.Size = new Size(186, 40);
            cbbOrderType.TabIndex = 14;
            cbbOrderType.SelectedValueChanged += cbbOrderType_SelectedValueChanged;
            // 
            // dgvOrderDetails
            // 
            dgvOrderDetails.AllowUserToAddRows = false;
            dgvOrderDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrderDetails.BackgroundColor = SystemColors.Control;
            dgvOrderDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrderDetails.Location = new Point(37, 571);
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
            lblRegion.Location = new Point(1129, 144);
            lblRegion.Name = "lblRegion";
            lblRegion.Size = new Size(88, 32);
            lblRegion.TabIndex = 12;
            lblRegion.Text = "Region";
            // 
            // cbbRegion
            // 
            cbbRegion.FormattingEnabled = true;
            cbbRegion.Location = new Point(1223, 141);
            cbbRegion.Name = "cbbRegion";
            cbbRegion.Size = new Size(186, 40);
            cbbRegion.TabIndex = 11;
            cbbRegion.SelectedValueChanged += cbbRegion_SelectedValueChanged;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(1184, 300);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(152, 55);
            btnClear.TabIndex = 10;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // btnDistribute
            // 
            btnDistribute.Location = new Point(1017, 300);
            btnDistribute.Name = "btnDistribute";
            btnDistribute.Size = new Size(152, 55);
            btnDistribute.TabIndex = 9;
            btnDistribute.Text = "Distribute";
            btnDistribute.UseVisualStyleBackColor = true;
            btnDistribute.Click += button2_Click;
            // 
            // lblStore
            // 
            lblStore.AutoSize = true;
            lblStore.Location = new Point(1141, 192);
            lblStore.Name = "lblStore";
            lblStore.Size = new Size(76, 32);
            lblStore.TabIndex = 8;
            lblStore.Text = "Store ";
            // 
            // cbbStore
            // 
            cbbStore.FormattingEnabled = true;
            cbbStore.Location = new Point(1223, 189);
            cbbStore.Name = "cbbStore";
            cbbStore.Size = new Size(186, 40);
            cbbStore.TabIndex = 7;
            // 
            // dataOrder
            // 
            dataOrder.AllowUserToAddRows = false;
            dataOrder.AllowUserToDeleteRows = false;
            dataOrder.AllowUserToResizeColumns = false;
            dataOrder.AllowUserToResizeRows = false;
            dataOrder.BackgroundColor = SystemColors.Control;
            dataOrder.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataOrder.Columns.AddRange(new DataGridViewColumn[] { PurchaseOrderId, PurchasedDateTime, OrderType, DistributionStatus });
            dataOrder.Location = new Point(37, 130);
            dataOrder.Name = "dataOrder";
            dataOrder.ReadOnly = true;
            dataOrder.RowHeadersWidth = 62;
            dataOrder.Size = new Size(840, 420);
            dataOrder.TabIndex = 0;
            dataOrder.CellClick += dataOrder_CellClick;
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
            Controls.Add(tabControl1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "MaterialDistributionForm";
            Text = "MaterialDistributionForm";
            tabControl1.ResumeLayout(false);
            tpPurchaseOrder.ResumeLayout(false);
            tpPurchaseOrder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtDistributedQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvOrderDetails).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataOrder).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tpPurchaseOrder;
        private DataGridView dataOrder;
        private Label lblRegion;
        private ComboBox cbbRegion;
        private Button btnClear;
        private Button btnDistribute;
        private Label lblStore;
        private ComboBox cbbStore;
        private DataGridView dgvOrderDetails;
        private Label label3;
        private ComboBox cbbOrderType;
        private Label label4;
        private NumericUpDown txtDistributedQuantity;
        private DataGridViewTextBoxColumn PurchaseOrderId;
        private DataGridViewTextBoxColumn PurchasedDateTime;
        private DataGridViewTextBoxColumn OrderType;
        private DataGridViewTextBoxColumn DistributionStatus;
    }
}