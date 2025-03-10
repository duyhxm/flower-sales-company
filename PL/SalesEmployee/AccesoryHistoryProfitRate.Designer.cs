﻿namespace PL.SalesEmployee
{
    partial class AccesoryHistoryProfitRate
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
            dgvAProfitRateHistory = new DataGridView();
            btnAddNewFPrice = new Button();
            btnAdjustFPrice = new Button();
            label5 = new Label();
            txtProfitRate = new TextBox();
            label6 = new Label();
            txtAccessoryID = new TextBox();
            label1 = new Label();
            txtAccessoryProfitRateID = new TextBox();
            btnOk = new Button();
            label2 = new Label();
            txtUsageStatus = new TextBox();
            dateTimePickerStartDate = new DateTimePicker();
            dateTimePickerEndDate = new DateTimePicker();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvAProfitRateHistory).BeginInit();
            SuspendLayout();
            // 
            // dgvAProfitRateHistory
            // 
            dgvAProfitRateHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAProfitRateHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAProfitRateHistory.Location = new Point(17, 20);
            dgvAProfitRateHistory.Margin = new Padding(4, 5, 4, 5);
            dgvAProfitRateHistory.Name = "dgvAProfitRateHistory";
            dgvAProfitRateHistory.RowHeadersWidth = 62;
            dgvAProfitRateHistory.Size = new Size(1553, 477);
            dgvAProfitRateHistory.TabIndex = 0;
            dgvAProfitRateHistory.CellClick += dgvAProfitRateHistory_CellClick;
            // 
            // btnAddNewFPrice
            // 
            btnAddNewFPrice.Location = new Point(805, 611);
            btnAddNewFPrice.Margin = new Padding(4, 5, 4, 5);
            btnAddNewFPrice.Name = "btnAddNewFPrice";
            btnAddNewFPrice.Size = new Size(100, 40);
            btnAddNewFPrice.TabIndex = 25;
            btnAddNewFPrice.Text = "Add New";
            btnAddNewFPrice.UseVisualStyleBackColor = true;
            btnAddNewFPrice.Click += btnAddNewFPrice_Click;
            // 
            // btnAdjustFPrice
            // 
            btnAdjustFPrice.Location = new Point(805, 546);
            btnAdjustFPrice.Margin = new Padding(4, 5, 4, 5);
            btnAdjustFPrice.Name = "btnAdjustFPrice";
            btnAdjustFPrice.Size = new Size(100, 40);
            btnAdjustFPrice.TabIndex = 24;
            btnAdjustFPrice.Text = "Adjust";
            btnAdjustFPrice.UseVisualStyleBackColor = true;
            btnAdjustFPrice.Click += btnAdjustFPrice_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(450, 619);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(57, 25);
            label5.TabIndex = 23;
            label5.Text = "PRate";
            // 
            // txtProfitRate
            // 
            txtProfitRate.Location = new Point(561, 614);
            txtProfitRate.Margin = new Padding(4, 5, 4, 5);
            txtProfitRate.Name = "txtProfitRate";
            txtProfitRate.Size = new Size(188, 31);
            txtProfitRate.TabIndex = 22;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(99, 619);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(114, 25);
            label6.TabIndex = 21;
            label6.Text = "Accessory ID";
            // 
            // txtAccessoryID
            // 
            txtAccessoryID.Enabled = false;
            txtAccessoryID.Location = new Point(221, 614);
            txtAccessoryID.Margin = new Padding(4, 5, 4, 5);
            txtAccessoryID.Name = "txtAccessoryID";
            txtAccessoryID.Size = new Size(188, 31);
            txtAccessoryID.TabIndex = 20;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(99, 563);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(80, 25);
            label1.TabIndex = 17;
            label1.Text = "PRate ID";
            // 
            // txtAccessoryProfitRateID
            // 
            txtAccessoryProfitRateID.Enabled = false;
            txtAccessoryProfitRateID.Location = new Point(221, 558);
            txtAccessoryProfitRateID.Margin = new Padding(4, 5, 4, 5);
            txtAccessoryProfitRateID.Name = "txtAccessoryProfitRateID";
            txtAccessoryProfitRateID.Size = new Size(188, 31);
            txtAccessoryProfitRateID.TabIndex = 16;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(805, 676);
            btnOk.Margin = new Padding(4, 5, 4, 5);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(100, 40);
            btnOk.TabIndex = 15;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(450, 563);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(60, 25);
            label2.TabIndex = 19;
            label2.Text = "Status";
            // 
            // txtUsageStatus
            // 
            txtUsageStatus.Enabled = false;
            txtUsageStatus.Location = new Point(561, 558);
            txtUsageStatus.Margin = new Padding(4, 5, 4, 5);
            txtUsageStatus.Name = "txtUsageStatus";
            txtUsageStatus.Size = new Size(188, 31);
            txtUsageStatus.TabIndex = 18;
            // 
            // dateTimePickerStartDate
            // 
            dateTimePickerStartDate.CustomFormat = "dd/MM/yyyy";
            dateTimePickerStartDate.Format = DateTimePickerFormat.Custom;
            dateTimePickerStartDate.Location = new Point(221, 670);
            dateTimePickerStartDate.Margin = new Padding(4, 5, 4, 5);
            dateTimePickerStartDate.Name = "dateTimePickerStartDate";
            dateTimePickerStartDate.Size = new Size(194, 31);
            dateTimePickerStartDate.TabIndex = 26;
            // 
            // dateTimePickerEndDate
            // 
            dateTimePickerEndDate.CustomFormat = "dd/MM/yyyy";
            dateTimePickerEndDate.Format = DateTimePickerFormat.Custom;
            dateTimePickerEndDate.Location = new Point(561, 670);
            dateTimePickerEndDate.Margin = new Padding(4, 5, 4, 5);
            dateTimePickerEndDate.Name = "dateTimePickerEndDate";
            dateTimePickerEndDate.Size = new Size(188, 31);
            dateTimePickerEndDate.TabIndex = 27;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(99, 675);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(90, 25);
            label3.TabIndex = 28;
            label3.Text = "Start Date";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(450, 675);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(84, 25);
            label4.TabIndex = 29;
            label4.Text = "End Date";
            // 
            // AccesoryHistoryProfitRate
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1587, 800);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(dateTimePickerEndDate);
            Controls.Add(dateTimePickerStartDate);
            Controls.Add(btnAddNewFPrice);
            Controls.Add(btnAdjustFPrice);
            Controls.Add(label5);
            Controls.Add(txtProfitRate);
            Controls.Add(label6);
            Controls.Add(txtAccessoryID);
            Controls.Add(label2);
            Controls.Add(txtUsageStatus);
            Controls.Add(label1);
            Controls.Add(txtAccessoryProfitRateID);
            Controls.Add(btnOk);
            Controls.Add(dgvAProfitRateHistory);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "AccesoryHistoryProfitRate";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AccesoryHistoryProfitRate";
            Load += AccesoryHistoryProfitRate_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAProfitRateHistory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvAProfitRateHistory;
        private Button btnAddNewFPrice;
        private Button btnAdjustFPrice;
        private Label label5;
        private TextBox txtProfitRate;
        private Label label6;
        private TextBox txtAccessoryID;
        private Label label1;
        private TextBox txtAccessoryProfitRateID;
        private Button btnOk;
        private Label label2;
        private TextBox txtUsageStatus;
        private DateTimePicker dateTimePickerStartDate;
        private DateTimePicker dateTimePickerEndDate;
        private Label label3;
        private Label label4;
    }
}