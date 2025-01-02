namespace PL.StoreEmployee.OrderHistory
{
    partial class OrderStatusAdjustmentForm
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
            cmbBxOrderStatus = new ComboBox();
            lblOrderStatus = new Label();
            btnOk = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // cmbBxOrderStatus
            // 
            cmbBxOrderStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBxOrderStatus.FormattingEnabled = true;
            cmbBxOrderStatus.Location = new Point(38, 79);
            cmbBxOrderStatus.Margin = new Padding(4);
            cmbBxOrderStatus.Name = "cmbBxOrderStatus";
            cmbBxOrderStatus.Size = new Size(218, 40);
            cmbBxOrderStatus.TabIndex = 0;
            // 
            // lblOrderStatus
            // 
            lblOrderStatus.AutoSize = true;
            lblOrderStatus.Location = new Point(38, 32);
            lblOrderStatus.Name = "lblOrderStatus";
            lblOrderStatus.Size = new Size(146, 32);
            lblOrderStatus.TabIndex = 2;
            lblOrderStatus.Text = "Order Status";
            // 
            // btnOk
            // 
            btnOk.Location = new Point(33, 150);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(107, 46);
            btnOk.TabIndex = 3;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(157, 150);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(109, 46);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // OrderStatusAdjustmentForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(309, 242);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(lblOrderStatus);
            Controls.Add(cmbBxOrderStatus);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "OrderStatusAdjustmentForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "OrderStatusAdjustmentForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbBxOrderStatus;
        private Label lblOrderStatus;
        private Button btnOk;
        private Button btnCancel;
    }
}