namespace PL
{
    partial class CEOMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CEOMainForm));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            splConStoreMainForm = new SplitContainer();
            btnAccountInformation = new Button();
            pictureBox_notificationBell = new PictureBox();
            btnDailyTask = new Button();
            txtBx_currentUser = new TextBox();
            chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            txt_doanhThu = new TextBox();
            label3 = new Label();
            txt_chiPhi = new TextBox();
            label2 = new Label();
            button1 = new Button();
            lblEndDate = new Label();
            lblStartDate = new Label();
            dateTimePickerEnd = new DateTimePicker();
            dateTimePickerStart = new DateTimePicker();
            label1 = new Label();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)splConStoreMainForm).BeginInit();
            splConStoreMainForm.Panel1.SuspendLayout();
            splConStoreMainForm.Panel2.SuspendLayout();
            splConStoreMainForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_notificationBell).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            SuspendLayout();
            // 
            // splConStoreMainForm
            // 
            splConStoreMainForm.Dock = DockStyle.Fill;
            splConStoreMainForm.Location = new Point(0, 0);
            splConStoreMainForm.Margin = new Padding(3, 4, 3, 4);
            splConStoreMainForm.Name = "splConStoreMainForm";
            // 
            // splConStoreMainForm.Panel1
            // 
            splConStoreMainForm.Panel1.BackColor = SystemColors.ActiveCaption;
            splConStoreMainForm.Panel1.Controls.Add(btnAccountInformation);
            splConStoreMainForm.Panel1.Controls.Add(pictureBox_notificationBell);
            splConStoreMainForm.Panel1.Controls.Add(btnDailyTask);
            splConStoreMainForm.Panel1.Controls.Add(txtBx_currentUser);
            // 
            // splConStoreMainForm.Panel2
            // 
            splConStoreMainForm.Panel2.Controls.Add(chart2);
            splConStoreMainForm.Panel2.Controls.Add(txt_doanhThu);
            splConStoreMainForm.Panel2.Controls.Add(label3);
            splConStoreMainForm.Panel2.Controls.Add(txt_chiPhi);
            splConStoreMainForm.Panel2.Controls.Add(label2);
            splConStoreMainForm.Panel2.Controls.Add(button1);
            splConStoreMainForm.Panel2.Controls.Add(lblEndDate);
            splConStoreMainForm.Panel2.Controls.Add(lblStartDate);
            splConStoreMainForm.Panel2.Controls.Add(dateTimePickerEnd);
            splConStoreMainForm.Panel2.Controls.Add(dateTimePickerStart);
            splConStoreMainForm.Panel2.Controls.Add(label1);
            splConStoreMainForm.Panel2.Controls.Add(chart1);
            splConStoreMainForm.Size = new Size(1876, 888);
            splConStoreMainForm.SplitterDistance = 238;
            splConStoreMainForm.TabIndex = 2;
            // 
            // btnAccountInformation
            // 
            btnAccountInformation.ImeMode = ImeMode.NoControl;
            btnAccountInformation.Location = new Point(3, 168);
            btnAccountInformation.Margin = new Padding(3, 4, 3, 4);
            btnAccountInformation.Name = "btnAccountInformation";
            btnAccountInformation.Size = new Size(186, 59);
            btnAccountInformation.TabIndex = 9;
            btnAccountInformation.Text = "Account";
            btnAccountInformation.TextAlign = ContentAlignment.MiddleLeft;
            btnAccountInformation.UseVisualStyleBackColor = true;
            // 
            // pictureBox_notificationBell
            // 
            pictureBox_notificationBell.BackgroundImage = (Image)resources.GetObject("pictureBox_notificationBell.BackgroundImage");
            pictureBox_notificationBell.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox_notificationBell.ImeMode = ImeMode.NoControl;
            pictureBox_notificationBell.Location = new Point(198, 94);
            pictureBox_notificationBell.Margin = new Padding(3, 4, 3, 4);
            pictureBox_notificationBell.Name = "pictureBox_notificationBell";
            pictureBox_notificationBell.Size = new Size(30, 38);
            pictureBox_notificationBell.TabIndex = 8;
            pictureBox_notificationBell.TabStop = false;
            // 
            // btnDailyTask
            // 
            btnDailyTask.ImeMode = ImeMode.NoControl;
            btnDailyTask.Location = new Point(3, 86);
            btnDailyTask.Margin = new Padding(3, 4, 3, 4);
            btnDailyTask.Name = "btnDailyTask";
            btnDailyTask.Size = new Size(186, 59);
            btnDailyTask.TabIndex = 7;
            btnDailyTask.Text = "Daily Task";
            btnDailyTask.TextAlign = ContentAlignment.MiddleLeft;
            btnDailyTask.UseVisualStyleBackColor = true;
            btnDailyTask.Click += btnDailyTask_Click;
            // 
            // txtBx_currentUser
            // 
            txtBx_currentUser.Location = new Point(0, 1063);
            txtBx_currentUser.Margin = new Padding(3, 4, 3, 4);
            txtBx_currentUser.Name = "txtBx_currentUser";
            txtBx_currentUser.Size = new Size(221, 39);
            txtBx_currentUser.TabIndex = 6;
            // 
            // chart2
            // 
            chartArea1.Name = "ChartArea1";
            chart2.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chart2.Legends.Add(legend1);
            chart2.Location = new Point(612, 206);
            chart2.Name = "chart2";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chart2.Series.Add(series1);
            chart2.Size = new Size(1010, 609);
            chart2.TabIndex = 23;
            chart2.Text = "chart3";
            // 
            // txt_doanhThu
            // 
            txt_doanhThu.Enabled = false;
            txt_doanhThu.ForeColor = Color.Blue;
            txt_doanhThu.Location = new Point(219, 812);
            txt_doanhThu.Name = "txt_doanhThu";
            txt_doanhThu.Size = new Size(224, 39);
            txt_doanhThu.TabIndex = 22;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(80, 815);
            label3.Name = "label3";
            label3.Size = new Size(133, 32);
            label3.TabIndex = 21;
            label3.Text = "Doanh thu:";
            // 
            // txt_chiPhi
            // 
            txt_chiPhi.Enabled = false;
            txt_chiPhi.ForeColor = Color.Red;
            txt_chiPhi.Location = new Point(219, 767);
            txt_chiPhi.Name = "txt_chiPhi";
            txt_chiPhi.Size = new Size(224, 39);
            txt_chiPhi.TabIndex = 20;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(102, 770);
            label2.Name = "label2";
            label2.Size = new Size(95, 32);
            label2.TabIndex = 19;
            label2.Text = "Chi phí:";
            // 
            // button1
            // 
            button1.Location = new Point(498, 123);
            button1.Name = "button1";
            button1.Size = new Size(131, 44);
            button1.TabIndex = 18;
            button1.Text = "Thống kê";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // lblEndDate
            // 
            lblEndDate.AutoSize = true;
            lblEndDate.Location = new Point(61, 165);
            lblEndDate.Name = "lblEndDate";
            lblEndDate.Size = new Size(54, 32);
            lblEndDate.TabIndex = 17;
            lblEndDate.Text = "End";
            // 
            // lblStartDate
            // 
            lblStartDate.AutoSize = true;
            lblStartDate.Location = new Point(61, 107);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new Size(62, 32);
            lblStartDate.TabIndex = 16;
            lblStartDate.Text = "Start";
            // 
            // dateTimePickerEnd
            // 
            dateTimePickerEnd.CustomFormat = "MM/yyyy";
            dateTimePickerEnd.Format = DateTimePickerFormat.Custom;
            dateTimePickerEnd.Location = new Point(152, 160);
            dateTimePickerEnd.Name = "dateTimePickerEnd";
            dateTimePickerEnd.Size = new Size(300, 39);
            dateTimePickerEnd.TabIndex = 15;
            // 
            // dateTimePickerStart
            // 
            dateTimePickerStart.CustomFormat = "MM/yyyy";
            dateTimePickerStart.Format = DateTimePickerFormat.Custom;
            dateTimePickerStart.Location = new Point(152, 102);
            dateTimePickerStart.Name = "dateTimePickerStart";
            dateTimePickerStart.Size = new Size(300, 39);
            dateTimePickerStart.TabIndex = 14;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(50, 44);
            label1.Name = "label1";
            label1.Size = new Size(250, 38);
            label1.TabIndex = 13;
            label1.Text = "Statistics in month";
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            chart1.Legends.Add(legend2);
            chart1.Location = new Point(37, 257);
            chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            chart1.Series.Add(series2);
            chart1.Size = new Size(496, 420);
            chart1.TabIndex = 0;
            chart1.Text = "chart1";
            // 
            // CEOMainForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1876, 888);
            Controls.Add(splConStoreMainForm);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "CEOMainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CEOMainForm";
            WindowState = FormWindowState.Maximized;
            FormClosing += CEOMainForm_FormClosing;
            Load += CEOMainForm_Load;
            splConStoreMainForm.Panel1.ResumeLayout(false);
            splConStoreMainForm.Panel1.PerformLayout();
            splConStoreMainForm.Panel2.ResumeLayout(false);
            splConStoreMainForm.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splConStoreMainForm).EndInit();
            splConStoreMainForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox_notificationBell).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart2).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splConStoreMainForm;
        private Button btnAccountInformation;
        private PictureBox pictureBox_notificationBell;
        private Button btnDailyTask;
        private TextBox txtBx_currentUser;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private Button button1;
        private Label lblEndDate;
        private Label lblStartDate;
        private DateTimePicker dateTimePickerEnd;
        private DateTimePicker dateTimePickerStart;
        private Label label1;
        private TextBox txt_chiPhi;
        private Label label2;
        private TextBox txt_doanhThu;
        private Label label3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
    }
}