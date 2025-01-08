namespace PL.StoreEmployee
{
    partial class OrderHistoryForm
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
            dgvOrderHistory = new DataGridView();
            ColSalesOrderId = new DataGridViewTextBoxColumn();
            ColOrderType = new DataGridViewTextBoxColumn();
            ColOrderStatus = new DataGridViewTextBoxColumn();
            ColPurchaseMethod = new DataGridViewTextBoxColumn();
            ColFinalPrice = new DataGridViewTextBoxColumn();
            ColOrderDetails = new DataGridViewImageColumn();
            ColSave = new DataGridViewImageColumn();
            ColEditStatus = new DataGridViewImageColumn();
            ColShip = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvOrderHistory).BeginInit();
            SuspendLayout();
            // 
            // dgvOrderHistory
            // 
            dgvOrderHistory.AllowUserToAddRows = false;
            dgvOrderHistory.AllowUserToDeleteRows = false;
            dgvOrderHistory.AllowUserToResizeColumns = false;
            dgvOrderHistory.AllowUserToResizeRows = false;
            dgvOrderHistory.BackgroundColor = SystemColors.Control;
            dgvOrderHistory.BorderStyle = BorderStyle.None;
            dgvOrderHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrderHistory.Columns.AddRange(new DataGridViewColumn[] { ColSalesOrderId, ColOrderType, ColOrderStatus, ColPurchaseMethod, ColFinalPrice, ColOrderDetails, ColSave, ColEditStatus, ColShip });
            dgvOrderHistory.Location = new Point(33, 156);
            dgvOrderHistory.Name = "dgvOrderHistory";
            dgvOrderHistory.RowHeadersVisible = false;
            dgvOrderHistory.RowHeadersWidth = 62;
            dgvOrderHistory.Size = new Size(1116, 503);
            dgvOrderHistory.TabIndex = 0;
            dgvOrderHistory.CellClick += dgvOrderHistory_CellClick;
            // 
            // ColSalesOrderId
            // 
            ColSalesOrderId.HeaderText = "ID";
            ColSalesOrderId.MinimumWidth = 8;
            ColSalesOrderId.Name = "ColSalesOrderId";
            ColSalesOrderId.ReadOnly = true;
            ColSalesOrderId.Width = 150;
            // 
            // ColOrderType
            // 
            ColOrderType.HeaderText = "Type";
            ColOrderType.MinimumWidth = 8;
            ColOrderType.Name = "ColOrderType";
            ColOrderType.ReadOnly = true;
            ColOrderType.Width = 150;
            // 
            // ColOrderStatus
            // 
            ColOrderStatus.HeaderText = "Status";
            ColOrderStatus.MinimumWidth = 8;
            ColOrderStatus.Name = "ColOrderStatus";
            ColOrderStatus.Resizable = DataGridViewTriState.True;
            ColOrderStatus.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColOrderStatus.Width = 200;
            // 
            // ColPurchaseMethod
            // 
            ColPurchaseMethod.HeaderText = "PMethod";
            ColPurchaseMethod.MinimumWidth = 8;
            ColPurchaseMethod.Name = "ColPurchaseMethod";
            ColPurchaseMethod.ReadOnly = true;
            ColPurchaseMethod.Width = 150;
            // 
            // ColFinalPrice
            // 
            ColFinalPrice.HeaderText = "Price";
            ColFinalPrice.MinimumWidth = 8;
            ColFinalPrice.Name = "ColFinalPrice";
            ColFinalPrice.ReadOnly = true;
            ColFinalPrice.Width = 150;
            // 
            // ColOrderDetails
            // 
            ColOrderDetails.FillWeight = 50F;
            ColOrderDetails.HeaderText = "";
            ColOrderDetails.Image = Properties.Resources.details;
            ColOrderDetails.ImageLayout = DataGridViewImageCellLayout.Zoom;
            ColOrderDetails.MinimumWidth = 8;
            ColOrderDetails.Name = "ColOrderDetails";
            ColOrderDetails.Width = 50;
            // 
            // ColSave
            // 
            ColSave.FillWeight = 50F;
            ColSave.HeaderText = "";
            ColSave.Image = Properties.Resources.save;
            ColSave.ImageLayout = DataGridViewImageCellLayout.Zoom;
            ColSave.MinimumWidth = 8;
            ColSave.Name = "ColSave";
            ColSave.Width = 50;
            // 
            // ColEditStatus
            // 
            ColEditStatus.FillWeight = 40F;
            ColEditStatus.HeaderText = "";
            ColEditStatus.Image = Properties.Resources.edit;
            ColEditStatus.ImageLayout = DataGridViewImageCellLayout.Zoom;
            ColEditStatus.MinimumWidth = 8;
            ColEditStatus.Name = "ColEditStatus";
            ColEditStatus.Resizable = DataGridViewTriState.True;
            ColEditStatus.SortMode = DataGridViewColumnSortMode.Automatic;
            ColEditStatus.Width = 50;
            // 
            // ColShip
            // 
            ColShip.FillWeight = 40F;
            ColShip.HeaderText = "Ship";
            ColShip.MinimumWidth = 8;
            ColShip.Name = "ColShip";
            ColShip.ReadOnly = true;
            ColShip.Resizable = DataGridViewTriState.True;
            ColShip.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // OrderHistoryForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 727);
            Controls.Add(dgvOrderHistory);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "OrderHistoryForm";
            Text = "OrderHistoryForm";
            ((System.ComponentModel.ISupportInitialize)dgvOrderHistory).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvOrderHistory;
        private DataGridViewTextBoxColumn ColSalesOrderId;
        private DataGridViewTextBoxColumn ColOrderType;
        private DataGridViewTextBoxColumn ColOrderStatus;
        private DataGridViewTextBoxColumn ColPurchaseMethod;
        private DataGridViewTextBoxColumn ColFinalPrice;
        private DataGridViewImageColumn ColOrderDetails;
        private DataGridViewImageColumn ColSave;
        private DataGridViewImageColumn ColEditStatus;
        private DataGridViewTextBoxColumn ColShip;
    }
}