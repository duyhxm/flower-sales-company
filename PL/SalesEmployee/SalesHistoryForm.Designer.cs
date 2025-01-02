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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            label1 = new Label();
            tabControl1 = new TabControl();
            tpSalesOrder = new TabPage();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            button1 = new Button();
            lblEndDate = new Label();
            lblStartDate = new Label();
            dateTimePickerEnd = new DateTimePicker();
            dateTimePickerStart = new DateTimePicker();
            tpSalesOrderList = new TabPage();
            dgvSalesOrders = new DataGridView();
            tabControl1.SuspendLayout();
            tpSalesOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart2).BeginInit();
            tpSalesOrderList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSalesOrders).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(43, 38);
            label1.Name = "label1";
            label1.Size = new Size(170, 25);
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
            tpSalesOrder.Controls.Add(chart1);
            tpSalesOrder.Controls.Add(chart2);
            tpSalesOrder.Controls.Add(button1);
            tpSalesOrder.Controls.Add(lblEndDate);
            tpSalesOrder.Controls.Add(lblStartDate);
            tpSalesOrder.Controls.Add(dateTimePickerEnd);
            tpSalesOrder.Controls.Add(dateTimePickerStart);
            tpSalesOrder.Controls.Add(label1);
            tpSalesOrder.Location = new Point(4, 30);
            tpSalesOrder.Name = "tpSalesOrder";
            tpSalesOrder.Padding = new Padding(3);
            tpSalesOrder.Size = new Size(1645, 910);
            tpSalesOrder.TabIndex = 0;
            tpSalesOrder.Text = "Sales Order";
            tpSalesOrder.UseVisualStyleBackColor = true;
            // 
            // chart1
            // 
            chartArea7.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea7);
            legend7.Name = "Legend1";
            chart1.Legends.Add(legend7);
            chart1.Location = new Point(89, 239);
            chart1.Name = "chart1";
            series7.ChartArea = "ChartArea1";
            series7.Legend = "Legend1";
            series7.Name = "Series1";
            chart1.Series.Add(series7);
            chart1.Size = new Size(641, 550);
            chart1.TabIndex = 14;
            chart1.Text = "chart1";
            // 
            // chart2
            // 
            chartArea8.Name = "ChartArea1";
            chart2.ChartAreas.Add(chartArea8);
            legend8.Name = "Legend1";
            chart2.Legends.Add(legend8);
            chart2.Location = new Point(783, 239);
            chart2.Name = "chart2";
            series8.ChartArea = "ChartArea1";
            series8.Legend = "Legend1";
            series8.Name = "Series1";
            chart2.Series.Add(series8);
            chart2.Size = new Size(641, 550);
            chart2.TabIndex = 13;
            chart2.Text = "chart1";
            // 
            // button1
            // 
            button1.Location = new Point(491, 117);
            button1.Name = "button1";
            button1.Size = new Size(131, 44);
            button1.TabIndex = 12;
            button1.Text = "Thống kê";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // lblEndDate
            // 
            lblEndDate.AutoSize = true;
            lblEndDate.Location = new Point(54, 159);
            lblEndDate.Name = "lblEndDate";
            lblEndDate.Size = new Size(36, 21);
            lblEndDate.TabIndex = 11;
            lblEndDate.Text = "End";
            // 
            // lblStartDate
            // 
            lblStartDate.AutoSize = true;
            lblStartDate.Location = new Point(54, 101);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new Size(42, 21);
            lblStartDate.TabIndex = 10;
            lblStartDate.Text = "Start";
            // 
            // dateTimePickerEnd
            // 
            dateTimePickerEnd.CustomFormat = "MM/yyyy";
            dateTimePickerEnd.Format = DateTimePickerFormat.Custom;
            dateTimePickerEnd.Location = new Point(145, 154);
            dateTimePickerEnd.Name = "dateTimePickerEnd";
            dateTimePickerEnd.Size = new Size(300, 29);
            dateTimePickerEnd.TabIndex = 7;
            // 
            // dateTimePickerStart
            // 
            dateTimePickerStart.CustomFormat = "MM/yyyy";
            dateTimePickerStart.Format = DateTimePickerFormat.Custom;
            dateTimePickerStart.Location = new Point(145, 96);
            dateTimePickerStart.Name = "dateTimePickerStart";
            dateTimePickerStart.Size = new Size(300, 29);
            dateTimePickerStart.TabIndex = 6;
            // 
            // tpSalesOrderList
            // 
            tpSalesOrderList.Controls.Add(dgvSalesOrders);
            tpSalesOrderList.Location = new Point(4, 30);
            tpSalesOrderList.Name = "tpSalesOrderList";
            tpSalesOrderList.Size = new Size(1645, 910);
            tpSalesOrderList.TabIndex = 2;
            tpSalesOrderList.Text = "Details";
            tpSalesOrderList.UseVisualStyleBackColor = true;
            // 
            // dgvSalesOrders
            // 
            dgvSalesOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSalesOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSalesOrders.Location = new Point(66, 33);
            dgvSalesOrders.Name = "dgvSalesOrders";
            dgvSalesOrders.RowHeadersWidth = 62;
            dgvSalesOrders.Size = new Size(1176, 768);
            dgvSalesOrders.TabIndex = 0;
            // 
            // SalesHistoryForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
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
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart2).EndInit();
            tpSalesOrderList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSalesOrders).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Label label1;
        private TabControl tabControl1;
        private TabPage tpSalesOrder;
        private TabPage tpSalesOrderList;
        private DataGridView dgvSalesOrders;
        private DateTimePicker dateTimePickerEnd;
        private DateTimePicker dateTimePickerStart;
        private Label lblEndDate;
        private Label lblStartDate;
        private Button button1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}