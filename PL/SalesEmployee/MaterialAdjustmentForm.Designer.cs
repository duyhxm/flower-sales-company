namespace PL.SalesEmployee
{
    partial class MaterialAdjustmentForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            tbConMaterialAdjustment = new TabControl();
            tpFlowerProfitRate = new TabPage();
            btnSaveFPrice = new Button();
            btnAddNewFPrice = new Button();
            btnAdjustFPrice = new Button();
            lblDateApply = new Label();
            cmbBxFChar = new ComboBox();
            cmbBxFColor = new ComboBox();
            lblFChar = new Label();
            lblFColor = new Label();
            cmbBxFTypes = new ComboBox();
            lblFType = new Label();
            dtpApplyDate = new DateTimePicker();
            dgvFlowerPrice = new DataGridView();
            ColFlowerId = new DataGridViewTextBoxColumn();
            ColFlowerName = new DataGridViewTextBoxColumn();
            ColFType = new DataGridViewTextBoxColumn();
            ColFColor = new DataGridViewTextBoxColumn();
            ColFChar = new DataGridViewTextBoxColumn();
            ColCurrentFProfitRate = new DataGridViewTextBoxColumn();
            tpAccessoryProfitRate = new TabPage();
            lblApplyEndDateA = new Label();
            dtpApplyEndDateA = new DateTimePicker();
            btnSaveA = new Button();
            btnAddNewA = new Button();
            btnAdjustA = new Button();
            lblApplyStartDateA = new Label();
            dtpApplyStartDateA = new DateTimePicker();
            dgvAccessoryPrice = new DataGridView();
            ColAccessoryId = new DataGridViewTextBoxColumn();
            ColAccessoryName = new DataGridViewTextBoxColumn();
            ColCurrentAProfitRate = new DataGridViewTextBoxColumn();
            tpFlowerPriceHistory = new TabPage();
            tpAccessoryPriceHistory = new TabPage();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            tbConMaterialAdjustment.SuspendLayout();
            tpFlowerProfitRate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFlowerPrice).BeginInit();
            tpAccessoryProfitRate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAccessoryPrice).BeginInit();
            tpFlowerPriceHistory.SuspendLayout();
            tpAccessoryPriceHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart2).BeginInit();
            SuspendLayout();
            // 
            // tbConMaterialAdjustment
            // 
            tbConMaterialAdjustment.Controls.Add(tpFlowerProfitRate);
            tbConMaterialAdjustment.Controls.Add(tpAccessoryProfitRate);
            tbConMaterialAdjustment.Controls.Add(tpFlowerPriceHistory);
            tbConMaterialAdjustment.Controls.Add(tpAccessoryPriceHistory);
            tbConMaterialAdjustment.Dock = DockStyle.Fill;
            tbConMaterialAdjustment.Location = new Point(0, 0);
            tbConMaterialAdjustment.Name = "tbConMaterialAdjustment";
            tbConMaterialAdjustment.SelectedIndex = 0;
            tbConMaterialAdjustment.Size = new Size(1653, 944);
            tbConMaterialAdjustment.TabIndex = 0;
            // 
            // tpFlowerProfitRate
            // 
            tpFlowerProfitRate.Controls.Add(btnSaveFPrice);
            tpFlowerProfitRate.Controls.Add(btnAddNewFPrice);
            tpFlowerProfitRate.Controls.Add(btnAdjustFPrice);
            tpFlowerProfitRate.Controls.Add(lblDateApply);
            tpFlowerProfitRate.Controls.Add(cmbBxFChar);
            tpFlowerProfitRate.Controls.Add(cmbBxFColor);
            tpFlowerProfitRate.Controls.Add(lblFChar);
            tpFlowerProfitRate.Controls.Add(lblFColor);
            tpFlowerProfitRate.Controls.Add(cmbBxFTypes);
            tpFlowerProfitRate.Controls.Add(lblFType);
            tpFlowerProfitRate.Controls.Add(dtpApplyDate);
            tpFlowerProfitRate.Controls.Add(dgvFlowerPrice);
            tpFlowerProfitRate.Location = new Point(4, 41);
            tpFlowerProfitRate.Name = "tpFlowerProfitRate";
            tpFlowerProfitRate.Padding = new Padding(3);
            tpFlowerProfitRate.Size = new Size(1645, 899);
            tpFlowerProfitRate.TabIndex = 0;
            tpFlowerProfitRate.Text = "Flower";
            tpFlowerProfitRate.UseVisualStyleBackColor = true;
            // 
            // btnSaveFPrice
            // 
            btnSaveFPrice.Location = new Point(1382, 533);
            btnSaveFPrice.Name = "btnSaveFPrice";
            btnSaveFPrice.Size = new Size(188, 56);
            btnSaveFPrice.TabIndex = 11;
            btnSaveFPrice.Text = "Save";
            btnSaveFPrice.UseVisualStyleBackColor = true;
            // 
            // btnAddNewFPrice
            // 
            btnAddNewFPrice.Location = new Point(1382, 471);
            btnAddNewFPrice.Name = "btnAddNewFPrice";
            btnAddNewFPrice.Size = new Size(188, 56);
            btnAddNewFPrice.TabIndex = 10;
            btnAddNewFPrice.Text = "Add New";
            btnAddNewFPrice.UseVisualStyleBackColor = true;
            // 
            // btnAdjustFPrice
            // 
            btnAdjustFPrice.Location = new Point(1382, 409);
            btnAdjustFPrice.Name = "btnAdjustFPrice";
            btnAdjustFPrice.Size = new Size(188, 56);
            btnAdjustFPrice.TabIndex = 9;
            btnAdjustFPrice.Text = "Adjust";
            btnAdjustFPrice.UseVisualStyleBackColor = true;
            // 
            // lblDateApply
            // 
            lblDateApply.AutoSize = true;
            lblDateApply.Location = new Point(1321, 303);
            lblDateApply.Name = "lblDateApply";
            lblDateApply.Size = new Size(132, 32);
            lblDateApply.TabIndex = 8;
            lblDateApply.Text = "Apply Date";
            // 
            // cmbBxFChar
            // 
            cmbBxFChar.FormattingEnabled = true;
            cmbBxFChar.Location = new Point(586, 105);
            cmbBxFChar.Name = "cmbBxFChar";
            cmbBxFChar.Size = new Size(242, 40);
            cmbBxFChar.TabIndex = 7;
            // 
            // cmbBxFColor
            // 
            cmbBxFColor.FormattingEnabled = true;
            cmbBxFColor.Location = new Point(325, 105);
            cmbBxFColor.Name = "cmbBxFColor";
            cmbBxFColor.Size = new Size(242, 40);
            cmbBxFColor.TabIndex = 6;
            // 
            // lblFChar
            // 
            lblFChar.AutoSize = true;
            lblFChar.Location = new Point(586, 70);
            lblFChar.Name = "lblFChar";
            lblFChar.Size = new Size(128, 32);
            lblFChar.TabIndex = 5;
            lblFChar.Text = "Floral Char";
            // 
            // lblFColor
            // 
            lblFColor.AutoSize = true;
            lblFColor.Location = new Point(325, 70);
            lblFColor.Name = "lblFColor";
            lblFColor.Size = new Size(136, 32);
            lblFColor.TabIndex = 4;
            lblFColor.Text = "Floral Color";
            // 
            // cmbBxFTypes
            // 
            cmbBxFTypes.FormattingEnabled = true;
            cmbBxFTypes.Location = new Point(63, 105);
            cmbBxFTypes.Name = "cmbBxFTypes";
            cmbBxFTypes.Size = new Size(242, 40);
            cmbBxFTypes.TabIndex = 3;
            // 
            // lblFType
            // 
            lblFType.AutoSize = true;
            lblFType.Location = new Point(63, 70);
            lblFType.Name = "lblFType";
            lblFType.Size = new Size(130, 32);
            lblFType.TabIndex = 2;
            lblFType.Text = "Floral Type";
            // 
            // dtpApplyDate
            // 
            dtpApplyDate.CustomFormat = "MM/yyyy";
            dtpApplyDate.Format = DateTimePickerFormat.Custom;
            dtpApplyDate.Location = new Point(1463, 300);
            dtpApplyDate.Name = "dtpApplyDate";
            dtpApplyDate.Size = new Size(149, 39);
            dtpApplyDate.TabIndex = 1;
            // 
            // dgvFlowerPrice
            // 
            dgvFlowerPrice.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFlowerPrice.Columns.AddRange(new DataGridViewColumn[] { ColFlowerId, ColFlowerName, ColFType, ColFColor, ColFChar, ColCurrentFProfitRate });
            dgvFlowerPrice.Location = new Point(15, 236);
            dgvFlowerPrice.Name = "dgvFlowerPrice";
            dgvFlowerPrice.RowHeadersWidth = 62;
            dgvFlowerPrice.Size = new Size(1300, 500);
            dgvFlowerPrice.TabIndex = 0;
            // 
            // ColFlowerId
            // 
            ColFlowerId.HeaderText = "ID";
            ColFlowerId.MinimumWidth = 8;
            ColFlowerId.Name = "ColFlowerId";
            ColFlowerId.ReadOnly = true;
            ColFlowerId.Width = 150;
            // 
            // ColFlowerName
            // 
            ColFlowerName.HeaderText = "Name";
            ColFlowerName.MinimumWidth = 8;
            ColFlowerName.Name = "ColFlowerName";
            ColFlowerName.ReadOnly = true;
            ColFlowerName.Width = 250;
            // 
            // ColFType
            // 
            ColFType.HeaderText = "FType";
            ColFType.MinimumWidth = 8;
            ColFType.Name = "ColFType";
            ColFType.ReadOnly = true;
            ColFType.Width = 200;
            // 
            // ColFColor
            // 
            ColFColor.HeaderText = "FColor";
            ColFColor.MinimumWidth = 8;
            ColFColor.Name = "ColFColor";
            ColFColor.ReadOnly = true;
            ColFColor.Width = 150;
            // 
            // ColFChar
            // 
            ColFChar.HeaderText = "FChar";
            ColFChar.MinimumWidth = 8;
            ColFChar.Name = "ColFChar";
            ColFChar.ReadOnly = true;
            ColFChar.Width = 150;
            // 
            // ColCurrentFProfitRate
            // 
            ColCurrentFProfitRate.HeaderText = "AsIs PrfitRate";
            ColCurrentFProfitRate.MinimumWidth = 8;
            ColCurrentFProfitRate.Name = "ColCurrentFProfitRate";
            ColCurrentFProfitRate.ReadOnly = true;
            ColCurrentFProfitRate.Width = 200;
            // 
            // tpAccessoryProfitRate
            // 
            tpAccessoryProfitRate.Controls.Add(lblApplyEndDateA);
            tpAccessoryProfitRate.Controls.Add(dtpApplyEndDateA);
            tpAccessoryProfitRate.Controls.Add(btnSaveA);
            tpAccessoryProfitRate.Controls.Add(btnAddNewA);
            tpAccessoryProfitRate.Controls.Add(btnAdjustA);
            tpAccessoryProfitRate.Controls.Add(lblApplyStartDateA);
            tpAccessoryProfitRate.Controls.Add(dtpApplyStartDateA);
            tpAccessoryProfitRate.Controls.Add(dgvAccessoryPrice);
            tpAccessoryProfitRate.Location = new Point(4, 41);
            tpAccessoryProfitRate.Name = "tpAccessoryProfitRate";
            tpAccessoryProfitRate.Padding = new Padding(3);
            tpAccessoryProfitRate.Size = new Size(1645, 899);
            tpAccessoryProfitRate.TabIndex = 1;
            tpAccessoryProfitRate.Text = "Acessory";
            tpAccessoryProfitRate.UseVisualStyleBackColor = true;
            // 
            // lblApplyEndDateA
            // 
            lblApplyEndDateA.AutoSize = true;
            lblApplyEndDateA.Location = new Point(1008, 183);
            lblApplyEndDateA.Name = "lblApplyEndDateA";
            lblApplyEndDateA.Size = new Size(111, 32);
            lblApplyEndDateA.TabIndex = 8;
            lblApplyEndDateA.Text = "End Date";
            // 
            // dtpApplyEndDateA
            // 
            dtpApplyEndDateA.CustomFormat = "dd/MM/yyyy";
            dtpApplyEndDateA.Format = DateTimePickerFormat.Custom;
            dtpApplyEndDateA.Location = new Point(1136, 179);
            dtpApplyEndDateA.Name = "dtpApplyEndDateA";
            dtpApplyEndDateA.Size = new Size(202, 39);
            dtpApplyEndDateA.TabIndex = 7;
            // 
            // btnSaveA
            // 
            btnSaveA.Location = new Point(1028, 399);
            btnSaveA.Name = "btnSaveA";
            btnSaveA.Size = new Size(188, 56);
            btnSaveA.TabIndex = 6;
            btnSaveA.Text = "Save";
            btnSaveA.UseVisualStyleBackColor = true;
            // 
            // btnAddNewA
            // 
            btnAddNewA.Location = new Point(1028, 337);
            btnAddNewA.Name = "btnAddNewA";
            btnAddNewA.Size = new Size(188, 56);
            btnAddNewA.TabIndex = 5;
            btnAddNewA.Text = "Add New";
            btnAddNewA.UseVisualStyleBackColor = true;
            // 
            // btnAdjustA
            // 
            btnAdjustA.Location = new Point(1028, 275);
            btnAdjustA.Name = "btnAdjustA";
            btnAdjustA.Size = new Size(188, 56);
            btnAdjustA.TabIndex = 4;
            btnAdjustA.Text = "Adjust";
            btnAdjustA.UseVisualStyleBackColor = true;
            // 
            // lblApplyStartDateA
            // 
            lblApplyStartDateA.AutoSize = true;
            lblApplyStartDateA.Location = new Point(1008, 126);
            lblApplyStartDateA.Name = "lblApplyStartDateA";
            lblApplyStartDateA.Size = new Size(119, 32);
            lblApplyStartDateA.TabIndex = 3;
            lblApplyStartDateA.Text = "Start Date";
            // 
            // dtpApplyStartDateA
            // 
            dtpApplyStartDateA.CustomFormat = "dd/MM/yyyy";
            dtpApplyStartDateA.Format = DateTimePickerFormat.Custom;
            dtpApplyStartDateA.Location = new Point(1136, 121);
            dtpApplyStartDateA.Name = "dtpApplyStartDateA";
            dtpApplyStartDateA.Size = new Size(202, 39);
            dtpApplyStartDateA.TabIndex = 2;
            // 
            // dgvAccessoryPrice
            // 
            dgvAccessoryPrice.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAccessoryPrice.Columns.AddRange(new DataGridViewColumn[] { ColAccessoryId, ColAccessoryName, ColCurrentAProfitRate });
            dgvAccessoryPrice.Location = new Point(88, 92);
            dgvAccessoryPrice.Name = "dgvAccessoryPrice";
            dgvAccessoryPrice.RowHeadersWidth = 62;
            dgvAccessoryPrice.Size = new Size(914, 573);
            dgvAccessoryPrice.TabIndex = 0;
            // 
            // ColAccessoryId
            // 
            ColAccessoryId.HeaderText = "ID";
            ColAccessoryId.MinimumWidth = 8;
            ColAccessoryId.Name = "ColAccessoryId";
            ColAccessoryId.ReadOnly = true;
            ColAccessoryId.Width = 150;
            // 
            // ColAccessoryName
            // 
            ColAccessoryName.HeaderText = "Name";
            ColAccessoryName.MinimumWidth = 8;
            ColAccessoryName.Name = "ColAccessoryName";
            ColAccessoryName.ReadOnly = true;
            ColAccessoryName.Width = 200;
            // 
            // ColCurrentAProfitRate
            // 
            ColCurrentAProfitRate.HeaderText = "AsIs PrfitRate";
            ColCurrentAProfitRate.MinimumWidth = 8;
            ColCurrentAProfitRate.Name = "ColCurrentAProfitRate";
            ColCurrentAProfitRate.ReadOnly = true;
            ColCurrentAProfitRate.Width = 250;
            // 
            // tpFlowerPriceHistory
            // 
            tpFlowerPriceHistory.Controls.Add(chart1);
            tpFlowerPriceHistory.Location = new Point(4, 41);
            tpFlowerPriceHistory.Name = "tpFlowerPriceHistory";
            tpFlowerPriceHistory.Size = new Size(1645, 899);
            tpFlowerPriceHistory.TabIndex = 2;
            tpFlowerPriceHistory.Text = "Flower Price History";
            tpFlowerPriceHistory.UseVisualStyleBackColor = true;
            // 
            // tpAccessoryPriceHistory
            // 
            tpAccessoryPriceHistory.Controls.Add(chart2);
            tpAccessoryPriceHistory.Location = new Point(4, 41);
            tpAccessoryPriceHistory.Name = "tpAccessoryPriceHistory";
            tpAccessoryPriceHistory.Size = new Size(1645, 899);
            tpAccessoryPriceHistory.TabIndex = 3;
            tpAccessoryPriceHistory.Text = "Accessory Price History";
            tpAccessoryPriceHistory.UseVisualStyleBackColor = true;
            // 
            // chart1
            // 
            chartArea3.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            chart1.Legends.Add(legend3);
            chart1.Location = new Point(135, 310);
            chart1.Name = "chart1";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            chart1.Series.Add(series3);
            chart1.Size = new Size(850, 450);
            chart1.TabIndex = 0;
            chart1.Text = "chart1";
            // 
            // chart2
            // 
            chartArea2.Name = "ChartArea1";
            chart2.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            chart2.Legends.Add(legend2);
            chart2.Location = new Point(240, 223);
            chart2.Name = "chart2";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            chart2.Series.Add(series2);
            chart2.Size = new Size(889, 522);
            chart2.TabIndex = 0;
            chart2.Text = "chart2";
            // 
            // MaterialAdjustmentForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1653, 944);
            Controls.Add(tbConMaterialAdjustment);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "MaterialAdjustmentForm";
            Text = "MaterialAdjustmentForm";
            tbConMaterialAdjustment.ResumeLayout(false);
            tpFlowerProfitRate.ResumeLayout(false);
            tpFlowerProfitRate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFlowerPrice).EndInit();
            tpAccessoryProfitRate.ResumeLayout(false);
            tpAccessoryProfitRate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAccessoryPrice).EndInit();
            tpFlowerPriceHistory.ResumeLayout(false);
            tpAccessoryPriceHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tbConMaterialAdjustment;
        private TabPage tpFlowerProfitRate;
        private TabPage tpAccessoryProfitRate;
        private TabPage tpFlowerPriceHistory;
        private DataGridView dgvFlowerPrice;
        private Label lblFChar;
        private Label lblFColor;
        private ComboBox cmbBxFTypes;
        private Label lblFType;
        private DateTimePicker dtpApplyDate;
        private TabPage tpAccessoryPriceHistory;
        private ComboBox cmbBxFChar;
        private ComboBox cmbBxFColor;
        private Label lblDateApply;
        private Button btnAdjustFPrice;
        private Button btnAddNewFPrice;
        private Button btnSaveFPrice;
        private DataGridView dgvAccessoryPrice;
        private Button btnSaveA;
        private Button btnAddNewA;
        private Button btnAdjustA;
        private Label lblApplyStartDateA;
        private DateTimePicker dtpApplyStartDateA;
        private DateTimePicker dtpApplyEndDateA;
        private Label lblApplyEndDateA;
        private DataGridViewTextBoxColumn ColAccessoryId;
        private DataGridViewTextBoxColumn ColAccessoryName;
        private DataGridViewTextBoxColumn ColCurrentAProfitRate;
        private DataGridViewTextBoxColumn ColFlowerId;
        private DataGridViewTextBoxColumn ColFlowerName;
        private DataGridViewTextBoxColumn ColFType;
        private DataGridViewTextBoxColumn ColFColor;
        private DataGridViewTextBoxColumn ColFChar;
        private DataGridViewTextBoxColumn ColCurrentFProfitRate;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
    }
}