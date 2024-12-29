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
            dataGridView1 = new DataGridView();
            ColSalesOrderId = new DataGridViewTextBoxColumn();
            ColPurchaseMethod = new DataGridViewTextBoxColumn();
            ColDeliveryDatetime = new DataGridViewTextBoxColumn();
            ColOrderStatus = new DataGridViewComboBoxColumn();
            ColFinalPrice = new DataGridViewTextBoxColumn();
            ColDetails = new DataGridViewImageColumn();
            ColImport = new DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ColSalesOrderId, ColPurchaseMethod, ColDeliveryDatetime, ColOrderStatus, ColFinalPrice, ColDetails, ColImport });
            dataGridView1.Location = new Point(124, 60);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1143, 839);
            dataGridView1.TabIndex = 0;
            // 
            // ColSalesOrderId
            // 
            ColSalesOrderId.HeaderText = "ID";
            ColSalesOrderId.MinimumWidth = 8;
            ColSalesOrderId.Name = "ColSalesOrderId";
            ColSalesOrderId.ReadOnly = true;
            ColSalesOrderId.Width = 150;
            // 
            // ColPurchaseMethod
            // 
            ColPurchaseMethod.HeaderText = "Buy Method";
            ColPurchaseMethod.MinimumWidth = 8;
            ColPurchaseMethod.Name = "ColPurchaseMethod";
            ColPurchaseMethod.ReadOnly = true;
            ColPurchaseMethod.Width = 200;
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
            ColOrderStatus.Width = 150;
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
            ColDetails.MinimumWidth = 8;
            ColDetails.Name = "ColDetails";
            ColDetails.Width = 80;
            // 
            // ColImport
            // 
            ColImport.HeaderText = "";
            ColImport.MinimumWidth = 8;
            ColImport.Name = "ColImport";
            ColImport.Width = 80;
            // 
            // PreorderListForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1653, 944);
            Controls.Add(dataGridView1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "PreorderListForm";
            Text = "PreorderListForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn ColSalesOrderId;
        private DataGridViewTextBoxColumn ColPurchaseMethod;
        private DataGridViewTextBoxColumn ColDeliveryDatetime;
        private DataGridViewComboBoxColumn ColOrderStatus;
        private DataGridViewTextBoxColumn ColFinalPrice;
        private DataGridViewImageColumn ColDetails;
        private DataGridViewImageColumn ColImport;
    }
}