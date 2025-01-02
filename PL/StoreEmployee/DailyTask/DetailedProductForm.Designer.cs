namespace PL.StoreEmployee.DailyTask
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
            dgvDetailedProduct = new DataGridView();
            ColMaterialId = new DataGridViewTextBoxColumn();
            ColMaterialName = new DataGridViewTextBoxColumn();
            ColUsedQuantity = new DataGridViewTextBoxColumn();
            btnOk = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDetailedProduct).BeginInit();
            SuspendLayout();
            // 
            // dgvDetailedProduct
            // 
            dgvDetailedProduct.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetailedProduct.Columns.AddRange(new DataGridViewColumn[] { ColMaterialId, ColMaterialName, ColUsedQuantity });
            dgvDetailedProduct.Location = new Point(24, 25);
            dgvDetailedProduct.Name = "dgvDetailedProduct";
            dgvDetailedProduct.RowHeadersWidth = 62;
            dgvDetailedProduct.Size = new Size(595, 402);
            dgvDetailedProduct.TabIndex = 0;
            // 
            // ColMaterialId
            // 
            ColMaterialId.FillWeight = 50F;
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
            ColMaterialName.Width = 200;
            // 
            // ColUsedQuantity
            // 
            ColUsedQuantity.FillWeight = 50F;
            ColUsedQuantity.HeaderText = "Q";
            ColUsedQuantity.MinimumWidth = 8;
            ColUsedQuantity.Name = "ColUsedQuantity";
            ColUsedQuantity.ReadOnly = true;
            ColUsedQuantity.Width = 150;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(535, 433);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(84, 40);
            btnOk.TabIndex = 1;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // DetailedProductForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(654, 486);
            Controls.Add(btnOk);
            Controls.Add(dgvDetailedProduct);
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

        private DataGridView dgvDetailedProduct;
        private DataGridViewTextBoxColumn ColMaterialId;
        private DataGridViewTextBoxColumn ColMaterialName;
        private DataGridViewTextBoxColumn ColUsedQuantity;
        private Button btnOk;
    }
}