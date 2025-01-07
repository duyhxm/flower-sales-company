namespace PL.CEO
{
    partial class StatisticsForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            txt_doanhThu = new TextBox();
            label3 = new Label();
            txt_chiPhi = new TextBox();
            label2 = new Label();
            btnGetStatistics = new Button();
            lblEndDate = new Label();
            lblStartDate = new Label();
            dtpEndDate = new DateTimePicker();
            dtpStartDate = new DateTimePicker();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart2).BeginInit();
            SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chart1.Legends.Add(legend1);
            chart1.Location = new Point(45, 218);
            chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chart1.Series.Add(series1);
            chart1.Size = new Size(628, 519);
            chart1.TabIndex = 1;
            chart1.Text = "chart1";
            // 
            // chart2
            // 
            chartArea2.Name = "ChartArea1";
            chart2.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            chart2.Legends.Add(legend2);
            chart2.Location = new Point(751, 218);
            chart2.Name = "chart2";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            chart2.Series.Add(series2);
            chart2.Size = new Size(850, 519);
            chart2.TabIndex = 24;
            chart2.Text = "chart3";
            // 
            // txt_doanhThu
            // 
            txt_doanhThu.Enabled = false;
            txt_doanhThu.ForeColor = Color.Blue;
            txt_doanhThu.Location = new Point(293, 839);
            txt_doanhThu.Name = "txt_doanhThu";
            txt_doanhThu.Size = new Size(224, 39);
            txt_doanhThu.TabIndex = 28;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(154, 842);
            label3.Name = "label3";
            label3.Size = new Size(133, 32);
            label3.TabIndex = 27;
            label3.Text = "Doanh thu:";
            // 
            // txt_chiPhi
            // 
            txt_chiPhi.Enabled = false;
            txt_chiPhi.ForeColor = Color.Red;
            txt_chiPhi.Location = new Point(293, 794);
            txt_chiPhi.Name = "txt_chiPhi";
            txt_chiPhi.Size = new Size(224, 39);
            txt_chiPhi.TabIndex = 26;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(176, 797);
            label2.Name = "label2";
            label2.Size = new Size(95, 32);
            label2.TabIndex = 25;
            label2.Text = "Chi phí:";
            // 
            // btnGetStatistics
            // 
            btnGetStatistics.Location = new Point(401, 120);
            btnGetStatistics.Name = "btnGetStatistics";
            btnGetStatistics.Size = new Size(131, 44);
            btnGetStatistics.TabIndex = 34;
            btnGetStatistics.Text = "Thống kê";
            btnGetStatistics.UseVisualStyleBackColor = true;
            btnGetStatistics.Click += btnGetStatistics_Click;
            // 
            // lblEndDate
            // 
            lblEndDate.AutoSize = true;
            lblEndDate.Location = new Point(80, 156);
            lblEndDate.Name = "lblEndDate";
            lblEndDate.Size = new Size(54, 32);
            lblEndDate.TabIndex = 33;
            lblEndDate.Text = "End";
            // 
            // lblStartDate
            // 
            lblStartDate.AutoSize = true;
            lblStartDate.Location = new Point(80, 98);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new Size(62, 32);
            lblStartDate.TabIndex = 32;
            lblStartDate.Text = "Start";
            // 
            // dtpEndDate
            // 
            dtpEndDate.CustomFormat = "MM/yyyy";
            dtpEndDate.Format = DateTimePickerFormat.Custom;
            dtpEndDate.Location = new Point(171, 151);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(186, 39);
            dtpEndDate.TabIndex = 31;
            // 
            // dtpStartDate
            // 
            dtpStartDate.CustomFormat = "MM/yyyy";
            dtpStartDate.Format = DateTimePickerFormat.Custom;
            dtpStartDate.Location = new Point(171, 93);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(186, 39);
            dtpStartDate.TabIndex = 30;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(69, 35);
            label1.Name = "label1";
            label1.Size = new Size(250, 38);
            label1.TabIndex = 29;
            label1.Text = "Statistics in month";
            // 
            // StatisticsForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1653, 944);
            Controls.Add(btnGetStatistics);
            Controls.Add(lblEndDate);
            Controls.Add(lblStartDate);
            Controls.Add(dtpEndDate);
            Controls.Add(dtpStartDate);
            Controls.Add(label1);
            Controls.Add(txt_doanhThu);
            Controls.Add(label3);
            Controls.Add(txt_chiPhi);
            Controls.Add(label2);
            Controls.Add(chart2);
            Controls.Add(chart1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "StatisticsForm";
            Text = "StatisticsForm";
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private TextBox txt_doanhThu;
        private Label label3;
        private TextBox txt_chiPhi;
        private Label label2;
        private Button btnGetStatistics;
        private Label lblEndDate;
        private Label lblStartDate;
        private DateTimePicker dtpEndDate;
        private DateTimePicker dtpStartDate;
        private Label label1;
    }
}