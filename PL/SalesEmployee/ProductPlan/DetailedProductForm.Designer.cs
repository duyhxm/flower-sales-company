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
            ((System.ComponentModel.ISupportInitialize)dgvDetailedProduct).BeginInit();
            SuspendLayout();
            // 
            // btnOk
            // 
            btnOk.Location = new Point(754, 503);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(143, 50);
            btnOk.TabIndex = 1;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // dgvDetailedProduct
            // 
            dgvDetailedProduct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetailedProduct.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetailedProduct.Location = new Point(3, 2);
            dgvDetailedProduct.Name = "dgvDetailedProduct";
            dgvDetailedProduct.Size = new Size(968, 480);
            dgvDetailedProduct.TabIndex = 2;
            // 
            // DetailedProductForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(976, 576);
            Controls.Add(dgvDetailedProduct);
            Controls.Add(btnOk);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "DetailedProductForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DetailedProductForm";
            ((System.ComponentModel.ISupportInitialize)dgvDetailedProduct).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button btnOk;
        private DataGridView dgvDetailedProduct;
    }
}