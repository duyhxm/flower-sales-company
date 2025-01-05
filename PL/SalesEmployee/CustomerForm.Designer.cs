namespace PL.SalesEmployee
{
    partial class CustomerForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            dgvCustomerData = new DataGridView();
            STT = new DataGridViewTextBoxColumn();
            Key = new DataGridViewTextBoxColumn();
            NameCus = new DataGridViewTextBoxColumn();
            TotalSpending = new DataGridViewTextBoxColumn();
            lblStartDate = new Label();
            cbbRank = new ComboBox();
            dtpStartDate = new DateTimePicker();
            dtpEndDate = new DateTimePicker();
            lblEndDate = new Label();
            lblRankName = new Label();
            cbbTop = new ComboBox();
            lblTop = new Label();
            lblCustomerRanking = new Label();
            panel1 = new Panel();
            lblVisualization = new Label();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            btnShow = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCustomerData).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            SuspendLayout();
            // 
            // dgvCustomerData
            // 
            dgvCustomerData.BackgroundColor = SystemColors.Control;
            dgvCustomerData.BorderStyle = BorderStyle.None;
            dgvCustomerData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomerData.Columns.AddRange(new DataGridViewColumn[] { STT, Key, NameCus, TotalSpending });
            dgvCustomerData.Location = new Point(24, 295);
            dgvCustomerData.Name = "dgvCustomerData";
            dgvCustomerData.RowHeadersVisible = false;
            dgvCustomerData.RowHeadersWidth = 62;
            dgvCustomerData.Size = new Size(681, 528);
            dgvCustomerData.TabIndex = 0;
            // 
            // STT
            // 
            STT.DataPropertyName = "STT";
            STT.HeaderText = "#";
            STT.MinimumWidth = 8;
            STT.Name = "STT";
            STT.ReadOnly = true;
            STT.Width = 50;
            // 
            // Key
            // 
            Key.DataPropertyName = "Key";
            Key.HeaderText = "ID";
            Key.MinimumWidth = 8;
            Key.Name = "Key";
            Key.ReadOnly = true;
            Key.Width = 150;
            // 
            // NameCus
            // 
            NameCus.DataPropertyName = "NameCus";
            NameCus.HeaderText = "Name";
            NameCus.MinimumWidth = 8;
            NameCus.Name = "NameCus";
            NameCus.ReadOnly = true;
            NameCus.Width = 200;
            // 
            // TotalSpending
            // 
            TotalSpending.DataPropertyName = "TotalSpending";
            TotalSpending.HeaderText = "Spending";
            TotalSpending.MinimumWidth = 8;
            TotalSpending.Name = "TotalSpending";
            TotalSpending.ReadOnly = true;
            TotalSpending.Width = 200;
            // 
            // lblStartDate
            // 
            lblStartDate.AutoSize = true;
            lblStartDate.Location = new Point(504, 108);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new Size(62, 32);
            lblStartDate.TabIndex = 1;
            lblStartDate.Text = "Start";
            // 
            // cbbRank
            // 
            cbbRank.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbRank.FormattingEnabled = true;
            cbbRank.Location = new Point(203, 233);
            cbbRank.Name = "cbbRank";
            cbbRank.Size = new Size(192, 40);
            cbbRank.TabIndex = 3;
            cbbRank.SelectedValueChanged += cbbRank_SelectedValueChanged;
            // 
            // dtpStartDate
            // 
            dtpStartDate.CustomFormat = "MM/yyyy";
            dtpStartDate.Format = DateTimePickerFormat.Custom;
            dtpStartDate.Location = new Point(572, 105);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(184, 39);
            dtpStartDate.TabIndex = 4;
            // 
            // dtpEndDate
            // 
            dtpEndDate.CustomFormat = "MM/yyyy";
            dtpEndDate.Format = DateTimePickerFormat.Custom;
            dtpEndDate.Location = new Point(826, 105);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(184, 39);
            dtpEndDate.TabIndex = 5;
            // 
            // lblEndDate
            // 
            lblEndDate.AutoSize = true;
            lblEndDate.Location = new Point(765, 108);
            lblEndDate.Name = "lblEndDate";
            lblEndDate.Size = new Size(54, 32);
            lblEndDate.TabIndex = 6;
            lblEndDate.Text = "End";
            // 
            // lblRankName
            // 
            lblRankName.AutoSize = true;
            lblRankName.Location = new Point(60, 236);
            lblRankName.Name = "lblRankName";
            lblRankName.Size = new Size(137, 32);
            lblRankName.TabIndex = 7;
            lblRankName.Text = "Rank Name";
            // 
            // cbbTop
            // 
            cbbTop.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbTop.FormattingEnabled = true;
            cbbTop.Items.AddRange(new object[] { "3", "5", "10" });
            cbbTop.Location = new Point(479, 233);
            cbbTop.Name = "cbbTop";
            cbbTop.Size = new Size(74, 40);
            cbbTop.TabIndex = 8;
            cbbTop.SelectedValueChanged += cbbTop_SelectedValueChanged;
            // 
            // lblTop
            // 
            lblTop.AutoSize = true;
            lblTop.Location = new Point(417, 236);
            lblTop.Name = "lblTop";
            lblTop.Size = new Size(53, 32);
            lblTop.TabIndex = 9;
            lblTop.Text = "Top";
            // 
            // lblCustomerRanking
            // 
            lblCustomerRanking.AutoSize = true;
            lblCustomerRanking.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCustomerRanking.Location = new Point(72, 47);
            lblCustomerRanking.Name = "lblCustomerRanking";
            lblCustomerRanking.Size = new Size(289, 45);
            lblCustomerRanking.TabIndex = 10;
            lblCustomerRanking.Text = "Customer Ranking";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaptionText;
            panel1.Location = new Point(765, 213);
            panel1.Name = "panel1";
            panel1.Size = new Size(1, 650);
            panel1.TabIndex = 11;
            // 
            // lblVisualization
            // 
            lblVisualization.AutoSize = true;
            lblVisualization.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVisualization.Location = new Point(1084, 47);
            lblVisualization.Name = "lblVisualization";
            lblVisualization.Size = new Size(205, 45);
            lblVisualization.TabIndex = 12;
            lblVisualization.Text = "Visualization";
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            chart1.Legends.Add(legend2);
            chart1.Location = new Point(826, 295);
            chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            chart1.Series.Add(series2);
            chart1.Size = new Size(774, 528);
            chart1.TabIndex = 13;
            chart1.Text = "chart1";
            // 
            // btnShow
            // 
            btnShow.Location = new Point(1054, 104);
            btnShow.Name = "btnShow";
            btnShow.Size = new Size(100, 40);
            btnShow.TabIndex = 14;
            btnShow.Text = "Show";
            btnShow.UseVisualStyleBackColor = true;
            btnShow.Click += btnShow_Click;
            // 
            // CustomerForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1653, 900);
            Controls.Add(btnShow);
            Controls.Add(chart1);
            Controls.Add(lblVisualization);
            Controls.Add(panel1);
            Controls.Add(lblCustomerRanking);
            Controls.Add(lblTop);
            Controls.Add(cbbTop);
            Controls.Add(lblRankName);
            Controls.Add(lblEndDate);
            Controls.Add(dtpEndDate);
            Controls.Add(dtpStartDate);
            Controls.Add(cbbRank);
            Controls.Add(lblStartDate);
            Controls.Add(dgvCustomerData);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "CustomerForm";
            Text = "CustomerForm";
            Load += CustomerForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCustomerData).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvCustomerData;
        private Label lblStartDate;
        private ComboBox cbbRank;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private Label lblEndDate;
        private Label lblRankName;
        private ComboBox cbbTop;
        private Label lblTop;
        private Label lblCustomerRanking;
        private Panel panel1;
        private Label lblVisualization;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private Button btnShow;
        private DataGridViewTextBoxColumn STT;
        private DataGridViewTextBoxColumn Key;
        private DataGridViewTextBoxColumn NameCus;
        private DataGridViewTextBoxColumn TotalSpending;
    }
}