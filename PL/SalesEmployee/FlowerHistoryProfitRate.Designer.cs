namespace PL.SalesEmployee
{
    partial class FlowerHistoryProfitRate
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            dgvFlowerProfitRates = new DataGridView();
            ColApplyMonth = new DataGridViewTextBoxColumn();
            ColApplyYear = new DataGridViewTextBoxColumn();
            ColExpectedQuantity = new DataGridViewTextBoxColumn();
            ColProfitRate = new DataGridViewTextBoxColumn();
            ColUsageStatus = new DataGridViewTextBoxColumn();
            btnOk = new Button();
            lblExpectedQuantity = new Label();
            txtExpectedQuantity = new TextBox();
            label5 = new Label();
            txtProfitRate = new TextBox();
            label6 = new Label();
            txtBxFlowerId = new TextBox();
            btnAddNewFPrice = new Button();
            btnAdjustFPrice = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvFlowerProfitRates).BeginInit();
            SuspendLayout();
            // 
            // dgvFlowerProfitRates
            // 
            dgvFlowerProfitRates.AllowUserToAddRows = false;
            dgvFlowerProfitRates.AllowUserToDeleteRows = false;
            dgvFlowerProfitRates.AllowUserToResizeColumns = false;
            dgvFlowerProfitRates.AllowUserToResizeRows = false;
            dgvFlowerProfitRates.BackgroundColor = SystemColors.Control;
            dgvFlowerProfitRates.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvFlowerProfitRates.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvFlowerProfitRates.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFlowerProfitRates.Columns.AddRange(new DataGridViewColumn[] { ColApplyMonth, ColApplyYear, ColExpectedQuantity, ColProfitRate, ColUsageStatus });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvFlowerProfitRates.DefaultCellStyle = dataGridViewCellStyle4;
            dgvFlowerProfitRates.Dock = DockStyle.Top;
            dgvFlowerProfitRates.Location = new Point(0, 0);
            dgvFlowerProfitRates.Margin = new Padding(4, 5, 4, 5);
            dgvFlowerProfitRates.Name = "dgvFlowerProfitRates";
            dgvFlowerProfitRates.RowHeadersWidth = 62;
            dgvFlowerProfitRates.Size = new Size(754, 334);
            dgvFlowerProfitRates.TabIndex = 0;
            dgvFlowerProfitRates.CellClick += dgvFlowerProfitRates_CellClick;
            // 
            // ColApplyMonth
            // 
            ColApplyMonth.HeaderText = "Month";
            ColApplyMonth.MinimumWidth = 8;
            ColApplyMonth.Name = "ColApplyMonth";
            ColApplyMonth.ReadOnly = true;
            ColApplyMonth.Width = 150;
            // 
            // ColApplyYear
            // 
            ColApplyYear.HeaderText = "Year";
            ColApplyYear.MinimumWidth = 8;
            ColApplyYear.Name = "ColApplyYear";
            ColApplyYear.ReadOnly = true;
            ColApplyYear.Width = 150;
            // 
            // ColExpectedQuantity
            // 
            ColExpectedQuantity.HeaderText = "Q";
            ColExpectedQuantity.MinimumWidth = 8;
            ColExpectedQuantity.Name = "ColExpectedQuantity";
            ColExpectedQuantity.ReadOnly = true;
            ColExpectedQuantity.Width = 150;
            // 
            // ColProfitRate
            // 
            ColProfitRate.HeaderText = "Rate";
            ColProfitRate.MinimumWidth = 8;
            ColProfitRate.Name = "ColProfitRate";
            ColProfitRate.ReadOnly = true;
            ColProfitRate.Width = 150;
            // 
            // ColUsageStatus
            // 
            ColUsageStatus.HeaderText = "Status";
            ColUsageStatus.MinimumWidth = 8;
            ColUsageStatus.Name = "ColUsageStatus";
            ColUsageStatus.ReadOnly = true;
            ColUsageStatus.Width = 200;
            // 
            // btnOk
            // 
            btnOk.Font = new Font("Segoe UI", 12F);
            btnOk.Location = new Point(418, 492);
            btnOk.Margin = new Padding(4, 5, 4, 5);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(100, 40);
            btnOk.TabIndex = 2;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // lblExpectedQuantity
            // 
            lblExpectedQuantity.AutoSize = true;
            lblExpectedQuantity.Font = new Font("Segoe UI", 12F);
            lblExpectedQuantity.Location = new Point(410, 381);
            lblExpectedQuantity.Margin = new Padding(4, 0, 4, 0);
            lblExpectedQuantity.Name = "lblExpectedQuantity";
            lblExpectedQuantity.Size = new Size(32, 32);
            lblExpectedQuantity.TabIndex = 6;
            lblExpectedQuantity.Text = "Q";
            // 
            // txtExpectedQuantity
            // 
            txtExpectedQuantity.Font = new Font("Segoe UI", 12F);
            txtExpectedQuantity.Location = new Point(450, 378);
            txtExpectedQuantity.Margin = new Padding(4, 5, 4, 5);
            txtExpectedQuantity.Name = "txtExpectedQuantity";
            txtExpectedQuantity.Size = new Size(188, 39);
            txtExpectedQuantity.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(381, 426);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(61, 32);
            label5.TabIndex = 12;
            label5.Text = "Rate";
            // 
            // txtProfitRate
            // 
            txtProfitRate.Font = new Font("Segoe UI", 12F);
            txtProfitRate.Location = new Point(450, 423);
            txtProfitRate.Margin = new Padding(4, 5, 4, 5);
            txtProfitRate.Name = "txtProfitRate";
            txtProfitRate.Size = new Size(188, 39);
            txtProfitRate.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(58, 382);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(114, 32);
            label6.TabIndex = 10;
            label6.Text = "Flower ID";
            // 
            // txtBxFlowerId
            // 
            txtBxFlowerId.Enabled = false;
            txtBxFlowerId.Font = new Font("Segoe UI", 12F);
            txtBxFlowerId.Location = new Point(180, 378);
            txtBxFlowerId.Margin = new Padding(4, 5, 4, 5);
            txtBxFlowerId.Name = "txtBxFlowerId";
            txtBxFlowerId.ReadOnly = true;
            txtBxFlowerId.Size = new Size(188, 39);
            txtBxFlowerId.TabIndex = 9;
            // 
            // btnAddNewFPrice
            // 
            btnAddNewFPrice.Font = new Font("Segoe UI", 12F);
            btnAddNewFPrice.Location = new Point(310, 492);
            btnAddNewFPrice.Margin = new Padding(4, 5, 4, 5);
            btnAddNewFPrice.Name = "btnAddNewFPrice";
            btnAddNewFPrice.Size = new Size(100, 40);
            btnAddNewFPrice.TabIndex = 14;
            btnAddNewFPrice.Text = "Add New";
            btnAddNewFPrice.UseVisualStyleBackColor = true;
            btnAddNewFPrice.Click += btnAddNewFPrice_Click;
            // 
            // btnAdjustFPrice
            // 
            btnAdjustFPrice.Font = new Font("Segoe UI", 12F);
            btnAdjustFPrice.Location = new Point(202, 492);
            btnAdjustFPrice.Margin = new Padding(4, 5, 4, 5);
            btnAdjustFPrice.Name = "btnAdjustFPrice";
            btnAdjustFPrice.Size = new Size(100, 40);
            btnAdjustFPrice.TabIndex = 13;
            btnAdjustFPrice.Text = "Adjust";
            btnAdjustFPrice.UseVisualStyleBackColor = true;
            btnAdjustFPrice.Click += btnAdjustFPrice_Click;
            // 
            // FlowerHistoryProfitRate
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(754, 575);
            Controls.Add(btnAddNewFPrice);
            Controls.Add(btnAdjustFPrice);
            Controls.Add(label5);
            Controls.Add(txtProfitRate);
            Controls.Add(label6);
            Controls.Add(txtBxFlowerId);
            Controls.Add(lblExpectedQuantity);
            Controls.Add(txtExpectedQuantity);
            Controls.Add(btnOk);
            Controls.Add(dgvFlowerProfitRates);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "FlowerHistoryProfitRate";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FlowerHistoryProfitRate";
            Load += FlowerHistoryProfitRate_Load;
            ((System.ComponentModel.ISupportInitialize)dgvFlowerProfitRates).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvFlowerProfitRates;
        private Button btnOk;
        private Label lblExpectedQuantity;
        private TextBox txtExpectedQuantity;
        private Label label5;
        private TextBox txtProfitRate;
        private Label label6;
        private TextBox txtBxFlowerId;
        private Button btnAddNewFPrice;
        private Button btnAdjustFPrice;
        private DataGridViewTextBoxColumn ColApplyMonth;
        private DataGridViewTextBoxColumn ColApplyYear;
        private DataGridViewTextBoxColumn ColExpectedQuantity;
        private DataGridViewTextBoxColumn ColProfitRate;
        private DataGridViewTextBoxColumn ColUsageStatus;
    }
}