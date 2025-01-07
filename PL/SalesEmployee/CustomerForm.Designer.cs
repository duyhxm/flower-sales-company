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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            dgvCustomerRanking = new DataGridView();
            lblQuarter = new Label();
            cmbBxRank = new ComboBox();
            lblYear = new Label();
            lblRank = new Label();
            cmbBxTop = new ComboBox();
            lblTop = new Label();
            lblCustomerRanking = new Label();
            panel1 = new Panel();
            lblVisualization = new Label();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            btnShow = new Button();
            cmbBxQuarter = new ComboBox();
            cmbBxYear = new ComboBox();
            ColOrder = new DataGridViewTextBoxColumn();
            ColCustomerId = new DataGridViewTextBoxColumn();
            ColCustomerName = new DataGridViewTextBoxColumn();
            ColTotalSpending = new DataGridViewTextBoxColumn();
            ColRankName = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvCustomerRanking).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            SuspendLayout();
            // 
            // dgvCustomerRanking
            // 
            dgvCustomerRanking.AllowUserToAddRows = false;
            dgvCustomerRanking.AllowUserToDeleteRows = false;
            dgvCustomerRanking.AllowUserToResizeColumns = false;
            dgvCustomerRanking.AllowUserToResizeRows = false;
            dgvCustomerRanking.BackgroundColor = SystemColors.Control;
            dgvCustomerRanking.BorderStyle = BorderStyle.None;
            dgvCustomerRanking.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomerRanking.Columns.AddRange(new DataGridViewColumn[] { ColOrder, ColCustomerId, ColCustomerName, ColTotalSpending, ColRankName });
            dgvCustomerRanking.Location = new Point(5, 295);
            dgvCustomerRanking.Name = "dgvCustomerRanking";
            dgvCustomerRanking.RowHeadersVisible = false;
            dgvCustomerRanking.RowHeadersWidth = 62;
            dgvCustomerRanking.RowTemplate.Height = 35;
            dgvCustomerRanking.Size = new Size(852, 528);
            dgvCustomerRanking.TabIndex = 0;
            // 
            // lblQuarter
            // 
            lblQuarter.AutoSize = true;
            lblQuarter.Location = new Point(563, 107);
            lblQuarter.Name = "lblQuarter";
            lblQuarter.Size = new Size(32, 32);
            lblQuarter.TabIndex = 1;
            lblQuarter.Text = "Q";
            // 
            // cmbBxRank
            // 
            cmbBxRank.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBxRank.FormattingEnabled = true;
            cmbBxRank.Location = new Point(245, 213);
            cmbBxRank.Name = "cmbBxRank";
            cmbBxRank.Size = new Size(192, 40);
            cmbBxRank.TabIndex = 3;
            cmbBxRank.SelectedValueChanged += cmbBxRank_SelectedValueChanged;
            // 
            // lblYear
            // 
            lblYear.AutoSize = true;
            lblYear.Location = new Point(703, 107);
            lblYear.Name = "lblYear";
            lblYear.Size = new Size(58, 32);
            lblYear.TabIndex = 6;
            lblYear.Text = "Year";
            // 
            // lblRank
            // 
            lblRank.AutoSize = true;
            lblRank.Location = new Point(102, 216);
            lblRank.Name = "lblRank";
            lblRank.Size = new Size(137, 32);
            lblRank.TabIndex = 7;
            lblRank.Text = "Rank Name";
            // 
            // cmbBxTop
            // 
            cmbBxTop.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBxTop.FormattingEnabled = true;
            cmbBxTop.Items.AddRange(new object[] { "3", "5", "10", "-1" });
            cmbBxTop.Location = new Point(521, 213);
            cmbBxTop.Name = "cmbBxTop";
            cmbBxTop.Size = new Size(74, 40);
            cmbBxTop.TabIndex = 8;
            cmbBxTop.SelectedValueChanged += cmbBxTop_SelectedValueChanged;
            // 
            // lblTop
            // 
            lblTop.AutoSize = true;
            lblTop.Location = new Point(459, 216);
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
            panel1.Location = new Point(880, 213);
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
            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chart1.Legends.Add(legend1);
            chart1.Location = new Point(928, 295);
            chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chart1.Series.Add(series1);
            chart1.Size = new Size(696, 528);
            chart1.TabIndex = 13;
            chart1.Text = "chart1";
            // 
            // btnShow
            // 
            btnShow.Location = new Point(928, 104);
            btnShow.Name = "btnShow";
            btnShow.Size = new Size(100, 40);
            btnShow.TabIndex = 14;
            btnShow.Text = "Show";
            btnShow.UseVisualStyleBackColor = true;
            btnShow.Click += btnShow_Click;
            // 
            // cmbBxQuarter
            // 
            cmbBxQuarter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBxQuarter.FormattingEnabled = true;
            cmbBxQuarter.Location = new Point(601, 104);
            cmbBxQuarter.Name = "cmbBxQuarter";
            cmbBxQuarter.Size = new Size(77, 40);
            cmbBxQuarter.TabIndex = 15;
            // 
            // cmbBxYear
            // 
            cmbBxYear.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBxYear.FormattingEnabled = true;
            cmbBxYear.Location = new Point(767, 104);
            cmbBxYear.Name = "cmbBxYear";
            cmbBxYear.Size = new Size(143, 40);
            cmbBxYear.TabIndex = 16;
            // 
            // ColOrder
            // 
            ColOrder.HeaderText = "#";
            ColOrder.MinimumWidth = 8;
            ColOrder.Name = "ColOrder";
            ColOrder.ReadOnly = true;
            ColOrder.Resizable = DataGridViewTriState.False;
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
            ColCustomerName.Width = 300;
            // 
            // ColTotalSpending
            // 
            ColTotalSpending.HeaderText = "Total";
            ColTotalSpending.MinimumWidth = 8;
            ColTotalSpending.Name = "ColTotalSpending";
            ColTotalSpending.ReadOnly = true;
            ColTotalSpending.Width = 170;
            // 
            // ColRankName
            // 
            ColRankName.HeaderText = "Rank";
            ColRankName.MinimumWidth = 8;
            ColRankName.Name = "ColRankName";
            ColRankName.ReadOnly = true;
            ColRankName.Width = 150;
            // 
            // CustomerForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1653, 900);
            Controls.Add(cmbBxYear);
            Controls.Add(cmbBxQuarter);
            Controls.Add(btnShow);
            Controls.Add(chart1);
            Controls.Add(lblVisualization);
            Controls.Add(panel1);
            Controls.Add(lblCustomerRanking);
            Controls.Add(lblTop);
            Controls.Add(cmbBxTop);
            Controls.Add(lblRank);
            Controls.Add(lblYear);
            Controls.Add(cmbBxRank);
            Controls.Add(lblQuarter);
            Controls.Add(dgvCustomerRanking);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "CustomerForm";
            Text = "CustomerForm";
            Load += CustomerForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCustomerRanking).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvCustomerRanking;
        private Label lblQuarter;
        private ComboBox cmbBxRank;
        private DateTimePicker dtpStartDate;
        private Label lblYear;
        private Label lblRank;
        private ComboBox cmbBxTop;
        private Label lblTop;
        private Label lblCustomerRanking;
        private Panel panel1;
        private Label lblVisualization;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private Button btnShow;
        private ComboBox cmbBxQuarter;
        private ComboBox cmbBxYear;
        private DataGridViewTextBoxColumn ColOrder;
        private DataGridViewTextBoxColumn ColCustomerId;
        private DataGridViewTextBoxColumn ColCustomerName;
        private DataGridViewTextBoxColumn ColTotalSpending;
        private DataGridViewTextBoxColumn ColRankName;
    }
}