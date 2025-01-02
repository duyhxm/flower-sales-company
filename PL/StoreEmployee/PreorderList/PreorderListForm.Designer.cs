namespace PL.StoreEmployee
{
    partial class PreorderListForm
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
            dgvPreorderList = new DataGridView();
            ColSalesOrderId = new DataGridViewTextBoxColumn();
            ColDeliveryDatetime = new DataGridViewTextBoxColumn();
            ColOrderStatus = new DataGridViewComboBoxColumn();
            ColFinalPrice = new DataGridViewTextBoxColumn();
            ColDetails = new DataGridViewImageColumn();
            ColImport = new DataGridViewImageColumn();
            dgvProductList = new DataGridView();
            ColProductId = new DataGridViewTextBoxColumn();
            ColProductName = new DataGridViewTextBoxColumn();
            ColFRName = new DataGridViewTextBoxColumn();
            ColUsedQuantity = new DataGridViewTextBoxColumn();
            ColDetailedProduct = new DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)dgvPreorderList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProductList).BeginInit();
            SuspendLayout();
            // 
            // dgvPreorderList
            // 
            dgvPreorderList.AllowUserToAddRows = false;
            dgvPreorderList.AllowUserToDeleteRows = false;
            dgvPreorderList.AllowUserToResizeColumns = false;
            dgvPreorderList.AllowUserToResizeRows = false;
            dgvPreorderList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPreorderList.Columns.AddRange(new DataGridViewColumn[] { ColSalesOrderId, ColDeliveryDatetime, ColOrderStatus, ColFinalPrice, ColDetails, ColImport });
            dgvPreorderList.Location = new Point(30, 50);
            dgvPreorderList.Name = "dgvPreorderList";
            dgvPreorderList.RowHeadersWidth = 62;
            dgvPreorderList.Size = new Size(1004, 463);
            dgvPreorderList.TabIndex = 0;
            dgvPreorderList.CellClick += dgvPreorderList_CellClick;
            // 
            // ColSalesOrderId
            // 
            ColSalesOrderId.HeaderText = "ID";
            ColSalesOrderId.MinimumWidth = 8;
            ColSalesOrderId.Name = "ColSalesOrderId";
            ColSalesOrderId.ReadOnly = true;
            ColSalesOrderId.Width = 150;
            // 
            // ColDeliveryDatetime
            // 
            ColDeliveryDatetime.HeaderText = "Datetime";
            ColDeliveryDatetime.MinimumWidth = 8;
            ColDeliveryDatetime.Name = "ColDeliveryDatetime";
            ColDeliveryDatetime.ReadOnly = true;
            ColDeliveryDatetime.Width = 200;
            // 
            // ColOrderStatus
            // 
            ColOrderStatus.HeaderText = "Status";
            ColOrderStatus.MinimumWidth = 8;
            ColOrderStatus.Name = "ColOrderStatus";
            ColOrderStatus.Resizable = DataGridViewTriState.True;
            ColOrderStatus.SortMode = DataGridViewColumnSortMode.Automatic;
            ColOrderStatus.Width = 200;
            // 
            // ColFinalPrice
            // 
            ColFinalPrice.HeaderText = "Final Price";
            ColFinalPrice.MinimumWidth = 8;
            ColFinalPrice.Name = "ColFinalPrice";
            ColFinalPrice.ReadOnly = true;
            ColFinalPrice.Width = 200;
            // 
            // ColDetails
            // 
            ColDetails.HeaderText = "";
            ColDetails.Image = Properties.Resources.details;
            ColDetails.ImageLayout = DataGridViewImageCellLayout.Zoom;
            ColDetails.MinimumWidth = 8;
            ColDetails.Name = "ColDetails";
            ColDetails.Width = 80;
            // 
            // ColImport
            // 
            ColImport.HeaderText = "";
            ColImport.Image = Properties.Resources.check;
            ColImport.ImageLayout = DataGridViewImageCellLayout.Zoom;
            ColImport.MinimumWidth = 8;
            ColImport.Name = "ColImport";
            ColImport.Width = 80;
            // 
            // dgvProductList
            // 
            dgvProductList.AllowUserToAddRows = false;
            dgvProductList.AllowUserToDeleteRows = false;
            dgvProductList.AllowUserToResizeColumns = false;
            dgvProductList.AllowUserToResizeRows = false;
            dgvProductList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductList.Columns.AddRange(new DataGridViewColumn[] { ColProductId, ColProductName, ColFRName, ColUsedQuantity, ColDetailedProduct });
            dgvProductList.Location = new Point(30, 519);
            dgvProductList.Name = "dgvProductList";
            dgvProductList.RowHeadersWidth = 62;
            dgvProductList.Size = new Size(877, 337);
            dgvProductList.TabIndex = 1;
            dgvProductList.CellClick += dgvProductList_CellClick;
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
            // ColFRName
            // 
            ColFRName.HeaderText = "FR";
            ColFRName.MinimumWidth = 8;
            ColFRName.Name = "ColFRName";
            ColFRName.ReadOnly = true;
            ColFRName.Width = 150;
            // 
            // ColUsedQuantity
            // 
            ColUsedQuantity.HeaderText = "Q";
            ColUsedQuantity.MinimumWidth = 8;
            ColUsedQuantity.Name = "ColUsedQuantity";
            ColUsedQuantity.ReadOnly = true;
            ColUsedQuantity.Width = 150;
            // 
            // ColDetailedProduct
            // 
            ColDetailedProduct.HeaderText = "";
            ColDetailedProduct.Image = Properties.Resources.details;
            ColDetailedProduct.ImageLayout = DataGridViewImageCellLayout.Zoom;
            ColDetailedProduct.MinimumWidth = 8;
            ColDetailedProduct.Name = "ColDetailedProduct";
            ColDetailedProduct.Width = 80;
            // 
            // PreorderListForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1300, 900);
            Controls.Add(dgvProductList);
            Controls.Add(dgvPreorderList);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "PreorderListForm";
            Text = "PreorderListForm";
            ((System.ComponentModel.ISupportInitialize)dgvPreorderList).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProductList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvPreorderList;
        private DataGridView dgvProductList;
        private DataGridViewTextBoxColumn ColProductId;
        private DataGridViewTextBoxColumn ColProductName;
        private DataGridViewTextBoxColumn ColFRName;
        private DataGridViewTextBoxColumn ColUsedQuantity;
        private DataGridViewImageColumn ColDetailedProduct;
        private DataGridViewTextBoxColumn ColSalesOrderId;
        private DataGridViewTextBoxColumn ColDeliveryDatetime;
        private DataGridViewComboBoxColumn ColOrderStatus;
        private DataGridViewTextBoxColumn ColFinalPrice;
        private DataGridViewImageColumn ColDetails;
        private DataGridViewImageColumn ColImport;
    }
}