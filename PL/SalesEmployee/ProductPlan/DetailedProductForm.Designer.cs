namespace PL.SalesEmployee.ProductPlan
{
    partial class DetailedProductForm
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
            btnOk = new Button();
            dgvDetailedProduct = new DataGridView();
            ColMaterialId = new DataGridViewTextBoxColumn();
            ColMaterialName = new DataGridViewTextBoxColumn();
            ColUsedQuantity = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvDetailedProduct).BeginInit();
            SuspendLayout();
            // 
            // btnOk
            // 
            btnOk.Location = new Point(332, 374);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(100, 40);
            btnOk.TabIndex = 1;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // dgvDetailedProduct
            // 
            dgvDetailedProduct.AllowUserToAddRows = false;
            dgvDetailedProduct.AllowUserToDeleteRows = false;
            dgvDetailedProduct.AllowUserToResizeColumns = false;
            dgvDetailedProduct.AllowUserToResizeRows = false;
            dgvDetailedProduct.BackgroundColor = SystemColors.Control;
            dgvDetailedProduct.BorderStyle = BorderStyle.None;
            dgvDetailedProduct.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetailedProduct.Columns.AddRange(new DataGridViewColumn[] { ColMaterialId, ColMaterialName, ColUsedQuantity });
            dgvDetailedProduct.Dock = DockStyle.Top;
            dgvDetailedProduct.Location = new Point(0, 0);
            dgvDetailedProduct.Name = "dgvDetailedProduct";
            dgvDetailedProduct.RowHeadersVisible = false;
            dgvDetailedProduct.RowHeadersWidth = 62;
            dgvDetailedProduct.Size = new Size(455, 357);
            dgvDetailedProduct.TabIndex = 2;
            // 
            // ColMaterialId
            // 
            ColMaterialId.HeaderText = "ID";
            ColMaterialId.MinimumWidth = 8;
            ColMaterialId.Name = "ColMaterialId";
            ColMaterialId.ReadOnly = true;
            ColMaterialId.Width = 150;
            // 
            // ColMaterialName
            // 
            ColMaterialName.HeaderText = "Name";
            ColMaterialName.MinimumWidth = 8;
            ColMaterialName.Name = "ColMaterialName";
            ColMaterialName.ReadOnly = true;
            ColMaterialName.Width = 250;
            // 
            // ColUsedQuantity
            // 
            ColUsedQuantity.HeaderText = "Q";
            ColUsedQuantity.MinimumWidth = 8;
            ColUsedQuantity.Name = "ColUsedQuantity";
            ColUsedQuantity.ReadOnly = true;
            ColUsedQuantity.Width = 80;
            // 
            // DetailedProductForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(455, 430);
            Controls.Add(dgvDetailedProduct);
            Controls.Add(btnOk);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "DetailedProductForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DetailedProductForm";
            Load += DetailedProductForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDetailedProduct).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button btnOk;
        private DataGridView dgvDetailedProduct;
        private DataGridViewTextBoxColumn ColMaterialId;
        private DataGridViewTextBoxColumn ColMaterialName;
        private DataGridViewTextBoxColumn ColUsedQuantity;
    }
}