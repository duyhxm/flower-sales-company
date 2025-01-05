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
            dataGridViewHistory = new DataGridView();
            btnOk = new Button();
            txtTargetId = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtExpectedQuantity = new TextBox();
            label5 = new Label();
            txtProfitRate = new TextBox();
            label6 = new Label();
            txtFlowerId = new TextBox();
            btnAddNewFPrice = new Button();
            btnAdjustFPrice = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewHistory).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewHistory
            // 
            dataGridViewHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewHistory.Dock = DockStyle.Top;
            dataGridViewHistory.Location = new Point(0, 0);
            dataGridViewHistory.Margin = new Padding(4, 5, 4, 5);
            dataGridViewHistory.Name = "dataGridViewHistory";
            dataGridViewHistory.RowHeadersWidth = 62;
            dataGridViewHistory.Size = new Size(1623, 500);
            dataGridViewHistory.TabIndex = 0;
            dataGridViewHistory.CellClick += dataGridViewHistory_CellClick;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(676, 670);
            btnOk.Margin = new Padding(4, 5, 4, 5);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(100, 40);
            btnOk.TabIndex = 2;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // txtTargetId
            // 
            txtTargetId.Enabled = false;
            txtTargetId.Location = new Point(129, 600);
            txtTargetId.Margin = new Padding(4, 5, 4, 5);
            txtTargetId.Name = "txtTargetId";
            txtTargetId.Size = new Size(188, 31);
            txtTargetId.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(35, 600);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(83, 25);
            label1.TabIndex = 4;
            label1.Text = "Target ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(344, 603);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(102, 25);
            label2.TabIndex = 6;
            label2.Text = "Expected Q";
            // 
            // txtExpectedQuantity
            // 
            txtExpectedQuantity.Location = new Point(451, 600);
            txtExpectedQuantity.Margin = new Padding(4, 5, 4, 5);
            txtExpectedQuantity.Name = "txtExpectedQuantity";
            txtExpectedQuantity.Size = new Size(188, 31);
            txtExpectedQuantity.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(344, 644);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(57, 25);
            label5.TabIndex = 12;
            label5.Text = "PRate";
            // 
            // txtProfitRate
            // 
            txtProfitRate.Location = new Point(451, 641);
            txtProfitRate.Margin = new Padding(4, 5, 4, 5);
            txtProfitRate.Name = "txtProfitRate";
            txtProfitRate.Size = new Size(188, 31);
            txtProfitRate.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(35, 644);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(87, 25);
            label6.TabIndex = 10;
            label6.Text = "Flower ID";
            // 
            // txtFlowerId
            // 
            txtFlowerId.Enabled = false;
            txtFlowerId.Location = new Point(129, 641);
            txtFlowerId.Margin = new Padding(4, 5, 4, 5);
            txtFlowerId.Name = "txtFlowerId";
            txtFlowerId.Size = new Size(188, 31);
            txtFlowerId.TabIndex = 9;
            // 
            // btnAddNewFPrice
            // 
            btnAddNewFPrice.Location = new Point(676, 617);
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
            btnAdjustFPrice.Location = new Point(676, 564);
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
            ClientSize = new Size(1623, 800);
            Controls.Add(btnAddNewFPrice);
            Controls.Add(btnAdjustFPrice);
            Controls.Add(label5);
            Controls.Add(txtProfitRate);
            Controls.Add(label6);
            Controls.Add(txtFlowerId);
            Controls.Add(label2);
            Controls.Add(txtExpectedQuantity);
            Controls.Add(label1);
            Controls.Add(txtTargetId);
            Controls.Add(btnOk);
            Controls.Add(dataGridViewHistory);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "FlowerHistoryProfitRate";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FlowerHistoryProfitRate";
            ((System.ComponentModel.ISupportInitialize)dataGridViewHistory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewHistory;
        private Button btnOk;
        private TextBox txtTargetId;
        private Label label1;
        private Label label2;
        private TextBox txtExpectedQuantity;
        private Label label5;
        private TextBox txtProfitRate;
        private Label label6;
        private TextBox txtFlowerId;
        private Button btnAddNewFPrice;
        private Button btnAdjustFPrice;
    }
}