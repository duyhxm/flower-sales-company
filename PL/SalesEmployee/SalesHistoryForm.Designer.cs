namespace PL.SalesEmployee
{
    partial class SalesHistoryForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            label1 = new Label();
            tabControl1 = new TabControl();
            tpSalesOrder = new TabPage();
            tpSalesOrderList = new TabPage();
            dataGridView1 = new DataGridView();
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            lblStartDate = new Label();
            lblEndDate = new Label();
            tabControl1.SuspendLayout();
            tpSalesOrder.SuspendLayout();
            tpSalesOrderList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart2).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(43, 38);
            label1.Name = "label1";
            label1.Size = new Size(250, 38);
            label1.TabIndex = 2;
            label1.Text = "Statistics in month";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tpSalesOrder);
            tabControl1.Controls.Add(tpSalesOrderList);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1653, 944);
            tabControl1.TabIndex = 6;
            // 
            // tpSalesOrder
            // 
            tpSalesOrder.Controls.Add(lblEndDate);
            tpSalesOrder.Controls.Add(lblStartDate);
            tpSalesOrder.Controls.Add(chart2);
            tpSalesOrder.Controls.Add(chart1);
            tpSalesOrder.Controls.Add(dateTimePicker2);
            tpSalesOrder.Controls.Add(dateTimePicker1);
            tpSalesOrder.Controls.Add(label1);
            tpSalesOrder.Location = new Point(4, 41);
            tpSalesOrder.Name = "tpSalesOrder";
            tpSalesOrder.Padding = new Padding(3);
            tpSalesOrder.Size = new Size(1645, 899);
            tpSalesOrder.TabIndex = 0;
            tpSalesOrder.Text = "Sales Order";
            tpSalesOrder.UseVisualStyleBackColor = true;
            // 
            // tpSalesOrderList
            // 
            tpSalesOrderList.Controls.Add(dataGridView1);
            tpSalesOrderList.Location = new Point(4, 41);
            tpSalesOrderList.Name = "tpSalesOrderList";
            tpSalesOrderList.Size = new Size(1645, 899);
            tpSalesOrderList.TabIndex = 2;
            tpSalesOrderList.Text = "Details";
            tpSalesOrderList.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(62, 53);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(927, 780);
            dataGridView1.TabIndex = 0;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "MM/yyyy";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(145, 96);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(300, 39);
            dateTimePicker1.TabIndex = 6;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.CustomFormat = "MM/yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.Location = new Point(145, 154);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(300, 39);
            dateTimePicker2.TabIndex = 7;
            // 
            // chart1
            // 
            chartArea4.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            chart1.Legends.Add(legend4);
            chart1.Location = new Point(56, 281);
            chart1.Name = "chart1";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            chart1.Series.Add(series4);
            chart1.Size = new Size(754, 510);
            chart1.TabIndex = 8;
            chart1.Text = "chart1";
            // 
            // chart2
            // 
            chartArea3.Name = "ChartArea1";
            chart2.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            chart2.Legends.Add(legend3);
            chart2.Location = new Point(835, 281);
            chart2.Name = "chart2";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            chart2.Series.Add(series3);
            chart2.Size = new Size(754, 510);
            chart2.TabIndex = 9;
            chart2.Text = "chart2";
            // 
            // lblStartDate
            // 
            lblStartDate.AutoSize = true;
            lblStartDate.Location = new Point(54, 101);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new Size(62, 32);
            lblStartDate.TabIndex = 10;
            lblStartDate.Text = "Start";
            // 
            // lblEndDate
            // 
            lblEndDate.AutoSize = true;
            lblEndDate.Location = new Point(54, 159);
            lblEndDate.Name = "lblEndDate";
            lblEndDate.Size = new Size(54, 32);
            lblEndDate.TabIndex = 11;
            lblEndDate.Text = "End";
            // 
            // SalesHistoryForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1653, 944);
            Controls.Add(tabControl1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "SalesHistoryForm";
            Text = "SalesHistoryForm";
            tabControl1.ResumeLayout(false);
            tpSalesOrder.ResumeLayout(false);
            tpSalesOrder.PerformLayout();
            tpSalesOrderList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart2).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Label label1;
        private TabControl tabControl1;
        private TabPage tpSalesOrder;
        private TabPage tpSalesOrderList;
        private DataGridView dataGridView1;
        private DateTimePicker dateTimePicker2;
        private DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private Label lblEndDate;
        private Label lblStartDate;
    }
}