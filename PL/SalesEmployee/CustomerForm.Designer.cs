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
            dataGridView1 = new DataGridView();
            ColOrder = new DataGridViewTextBoxColumn();
            ColCustomerId = new DataGridViewTextBoxColumn();
            ColCustomerName = new DataGridViewTextBoxColumn();
            ColMaximumSpending = new DataGridViewTextBoxColumn();
            lblStartDate = new Label();
            cmbBxRankName = new ComboBox();
            dtpStartDate = new DateTimePicker();
            dtpEndDate = new DateTimePicker();
            lblEndDate = new Label();
            lblRankName = new Label();
            cmbBxTop = new ComboBox();
            lblTop = new Label();
            lblCustomerRanking = new Label();
            panel1 = new Panel();
            lblVisualization = new Label();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ColOrder, ColCustomerId, ColCustomerName, ColMaximumSpending });
            dataGridView1.Location = new Point(24, 280);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(681, 507);
            dataGridView1.TabIndex = 0;
            // 
            // ColOrder
            // 
            ColOrder.HeaderText = "#";
            ColOrder.MinimumWidth = 8;
            ColOrder.Name = "ColOrder";
            ColOrder.ReadOnly = true;
            ColOrder.Width = 50;
            // 
            // ColCustomerId
            // 
            ColCustomerId.HeaderText = "ID";
            ColCustomerId.MinimumWidth = 8;
            ColCustomerId.Name = "ColCustomerId";
            ColCustomerId.ReadOnly = true;
            ColCustomerId.Width = 150;
            // 
            // ColCustomerName
            // 
            ColCustomerName.HeaderText = "Name";
            ColCustomerName.MinimumWidth = 8;
            ColCustomerName.Name = "ColCustomerName";
            ColCustomerName.ReadOnly = true;
            ColCustomerName.Width = 200;
            // 
            // ColMaximumSpending
            // 
            ColMaximumSpending.HeaderText = "Spending";
            ColMaximumSpending.MinimumWidth = 8;
            ColMaximumSpending.Name = "ColMaximumSpending";
            ColMaximumSpending.ReadOnly = true;
            ColMaximumSpending.Width = 200;
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
            // cmbBxRankName
            // 
            cmbBxRankName.FormattingEnabled = true;
            cmbBxRankName.Location = new Point(228, 195);
            cmbBxRankName.Name = "cmbBxRankName";
            cmbBxRankName.Size = new Size(192, 40);
            cmbBxRankName.TabIndex = 3;
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
            lblRankName.Location = new Point(85, 198);
            lblRankName.Name = "lblRankName";
            lblRankName.Size = new Size(137, 32);
            lblRankName.TabIndex = 7;
            lblRankName.Text = "Rank Name";
            // 
            // cmbBxTop
            // 
            cmbBxTop.FormattingEnabled = true;
            cmbBxTop.Location = new Point(504, 195);
            cmbBxTop.Name = "cmbBxTop";
            cmbBxTop.Size = new Size(74, 40);
            cmbBxTop.TabIndex = 8;
            // 
            // lblTop
            // 
            lblTop.AutoSize = true;
            lblTop.Location = new Point(442, 198);
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
            panel1.Size = new Size(1, 700);
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
            // CustomerForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1653, 944);
            Controls.Add(chart1);
            Controls.Add(lblVisualization);
            Controls.Add(panel1);
            Controls.Add(lblCustomerRanking);
            Controls.Add(lblTop);
            Controls.Add(cmbBxTop);
            Controls.Add(lblRankName);
            Controls.Add(lblEndDate);
            Controls.Add(dtpEndDate);
            Controls.Add(dtpStartDate);
            Controls.Add(cmbBxRankName);
            Controls.Add(lblStartDate);
            Controls.Add(dataGridView1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "CustomerForm";
            Text = "CustomerForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label lblStartDate;
        private ComboBox cmbBxRankName;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private Label lblEndDate;
        private Label lblRankName;
        private ComboBox cmbBxTop;
        private Label lblTop;
        private Label lblCustomerRanking;
        private Panel panel1;
        private DataGridViewTextBoxColumn ColOrder;
        private DataGridViewTextBoxColumn ColCustomerId;
        private DataGridViewTextBoxColumn ColCustomerName;
        private DataGridViewTextBoxColumn ColMaximumSpending;
        private Label lblVisualization;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}