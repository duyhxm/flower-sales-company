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
            dataGridViewHistory.Location = new Point(3, 3);
            dataGridViewHistory.Name = "dataGridViewHistory";
            dataGridViewHistory.Size = new Size(1128, 423);
            dataGridViewHistory.TabIndex = 0;
            dataGridViewHistory.CellClick += dataGridViewHistory_CellClick;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(950, 534);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(143, 50);
            btnOk.TabIndex = 2;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // txtTargetId
            // 
            txtTargetId.Enabled = false;
            txtTargetId.Location = new Point(90, 465);
            txtTargetId.Name = "txtTargetId";
            txtTargetId.Size = new Size(133, 23);
            txtTargetId.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 470);
            label1.Name = "label1";
            label1.Size = new Size(53, 15);
            label1.TabIndex = 4;
            label1.Text = "TargetID:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(267, 470);
            label2.Name = "label2";
            label2.Size = new Size(56, 15);
            label2.TabIndex = 6;
            label2.Text = "Quantity:";
            // 
            // txtExpectedQuantity
            // 
            txtExpectedQuantity.Location = new Point(328, 465);
            txtExpectedQuantity.Name = "txtExpectedQuantity";
            txtExpectedQuantity.Size = new Size(133, 23);
            txtExpectedQuantity.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(261, 509);
            label5.Name = "label5";
            label5.Size = new Size(62, 15);
            label5.TabIndex = 12;
            label5.Text = "ProfitRate:";
            // 
            // txtProfitRate
            // 
            txtProfitRate.Location = new Point(328, 504);
            txtProfitRate.Name = "txtProfitRate";
            txtProfitRate.Size = new Size(133, 23);
            txtProfitRate.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(28, 509);
            label6.Name = "label6";
            label6.Size = new Size(56, 15);
            label6.TabIndex = 10;
            label6.Text = "FlowerID:";
            // 
            // txtFlowerId
            // 
            txtFlowerId.Enabled = false;
            txtFlowerId.Location = new Point(90, 504);
            txtFlowerId.Name = "txtFlowerId";
            txtFlowerId.Size = new Size(133, 23);
            txtFlowerId.TabIndex = 9;
            // 
            // btnAddNewFPrice
            // 
            btnAddNewFPrice.Location = new Point(528, 496);
            btnAddNewFPrice.Name = "btnAddNewFPrice";
            btnAddNewFPrice.Size = new Size(188, 37);
            btnAddNewFPrice.TabIndex = 14;
            btnAddNewFPrice.Text = "Add New";
            btnAddNewFPrice.UseVisualStyleBackColor = true;
            btnAddNewFPrice.Click += btnAddNewFPrice_Click;
            // 
            // btnAdjustFPrice
            // 
            btnAdjustFPrice.Location = new Point(528, 453);
            btnAdjustFPrice.Name = "btnAdjustFPrice";
            btnAdjustFPrice.Size = new Size(188, 37);
            btnAdjustFPrice.TabIndex = 13;
            btnAdjustFPrice.Text = "Adjust";
            btnAdjustFPrice.UseVisualStyleBackColor = true;
            btnAdjustFPrice.Click += btnAdjustFPrice_Click;
            // 
            // FlowerHistoryProfitRate
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1136, 596);
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
            Name = "FlowerHistoryProfitRate";
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