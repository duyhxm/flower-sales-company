namespace PL
{
    partial class ProductStockDetails
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
            dgvProductStockDetails = new DataGridView();
            btnOk = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProductStockDetails).BeginInit();
            SuspendLayout();
            // 
            // dgvProductStockDetails
            // 
            dgvProductStockDetails.AllowUserToAddRows = false;
            dgvProductStockDetails.AllowUserToDeleteRows = false;
            dgvProductStockDetails.AllowUserToResizeColumns = false;
            dgvProductStockDetails.AllowUserToResizeRows = false;
            dgvProductStockDetails.BackgroundColor = SystemColors.Control;
            dgvProductStockDetails.BorderStyle = BorderStyle.None;
            dgvProductStockDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductStockDetails.Location = new Point(13, 13);
            dgvProductStockDetails.Margin = new Padding(4);
            dgvProductStockDetails.Name = "dgvProductStockDetails";
            dgvProductStockDetails.RowHeadersWidth = 62;
            dgvProductStockDetails.Size = new Size(582, 287);
            dgvProductStockDetails.TabIndex = 0;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(482, 311);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(89, 42);
            btnOk.TabIndex = 1;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // ProductStockDetails
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(623, 378);
            Controls.Add(btnOk);
            Controls.Add(dgvProductStockDetails);
            Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "ProductStockDetails";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ProductStockDetails";
            ((System.ComponentModel.ISupportInitialize)dgvProductStockDetails).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvProductStockDetails;
        private Button btnOk;
    }
}