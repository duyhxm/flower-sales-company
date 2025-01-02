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
            tbConMaterialAdjustment = new TabControl();
            tpFlowerProfitRate = new TabPage();
            cbbChar = new ComboBox();
            cbbColor = new ComboBox();
            lblFChar = new Label();
            lblFColor = new Label();
            cbbType = new ComboBox();
            lblFType = new Label();
            dgvFlowerPrice = new DataGridView();
            FlowerID = new DataGridViewTextBoxColumn();
            FlowerName = new DataGridViewTextBoxColumn();
            FTypeName = new DataGridViewTextBoxColumn();
            FColorName = new DataGridViewTextBoxColumn();
            FCharacteristicName = new DataGridViewTextBoxColumn();
            ProfitRate = new DataGridViewTextBoxColumn();
            HistoryRateFlower = new DataGridViewImageColumn();
            HistoryProfitRate = new DataGridViewImageColumn();
            tpAccessoryProfitRate = new TabPage();
            dgvAccessoryPrice = new DataGridView();
            MaterialId = new DataGridViewTextBoxColumn();
            MaterialName = new DataGridViewTextBoxColumn();
            ProfitRateA = new DataGridViewTextBoxColumn();
            HistoryRateChart = new DataGridViewImageColumn();
            AccesoryHistoryPrice = new DataGridViewImageColumn();
            tbConMaterialAdjustment.SuspendLayout();
            tpFlowerProfitRate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFlowerPrice).BeginInit();
            tpAccessoryProfitRate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAccessoryPrice).BeginInit();
            SuspendLayout();
            // 
            // tbConMaterialAdjustment
            // 
            tbConMaterialAdjustment.Controls.Add(tpFlowerProfitRate);
            tbConMaterialAdjustment.Controls.Add(tpAccessoryProfitRate);
            tbConMaterialAdjustment.Dock = DockStyle.Fill;
            tbConMaterialAdjustment.Location = new Point(0, 0);
            tbConMaterialAdjustment.Name = "tbConMaterialAdjustment";
            tbConMaterialAdjustment.SelectedIndex = 0;
            tbConMaterialAdjustment.Size = new Size(1653, 944);
            tbConMaterialAdjustment.TabIndex = 0;
            // 
            // tpFlowerProfitRate
            // 
            tpFlowerProfitRate.Controls.Add(cbbChar);
            tpFlowerProfitRate.Controls.Add(cbbColor);
            tpFlowerProfitRate.Controls.Add(lblFChar);
            tpFlowerProfitRate.Controls.Add(lblFColor);
            tpFlowerProfitRate.Controls.Add(cbbType);
            tpFlowerProfitRate.Controls.Add(lblFType);
            tpFlowerProfitRate.Controls.Add(dgvFlowerPrice);
            tpFlowerProfitRate.Location = new Point(4, 41);
            tpFlowerProfitRate.Name = "tpFlowerProfitRate";
            tpFlowerProfitRate.Padding = new Padding(3);
            tpFlowerProfitRate.Size = new Size(1645, 899);
            tpFlowerProfitRate.TabIndex = 0;
            tpFlowerProfitRate.Text = "Flower";
            tpFlowerProfitRate.UseVisualStyleBackColor = true;
            // 
            // cbbChar
            // 
            cbbChar.FormattingEnabled = true;
            cbbChar.Location = new Point(586, 105);
            cbbChar.Name = "cbbChar";
            cbbChar.Size = new Size(242, 40);
            cbbChar.TabIndex = 7;
            cbbChar.SelectedValueChanged += cbbChar_SelectedValueChanged;
            // 
            // cbbColor
            // 
            cbbColor.FormattingEnabled = true;
            cbbColor.Location = new Point(325, 105);
            cbbColor.Name = "cbbColor";
            cbbColor.Size = new Size(242, 40);
            cbbColor.TabIndex = 6;
            cbbColor.SelectedValueChanged += cbbColor_SelectedValueChanged;
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
            // cbbType
            // 
            cbbType.FormattingEnabled = true;
            cbbType.Location = new Point(63, 105);
            cbbType.Name = "cbbType";
            cbbType.Size = new Size(242, 40);
            cbbType.TabIndex = 3;
            cbbType.SelectedValueChanged += cbbType_SelectedValueChanged;
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
            // dgvFlowerPrice
            // 
            dgvFlowerPrice.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFlowerPrice.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFlowerPrice.Columns.AddRange(new DataGridViewColumn[] { FlowerID, FlowerName, FTypeName, FColorName, FCharacteristicName, ProfitRate, HistoryRateFlower, HistoryProfitRate });
            dgvFlowerPrice.Location = new Point(15, 212);
            dgvFlowerPrice.Name = "dgvFlowerPrice";
            dgvFlowerPrice.RowHeadersWidth = 62;
            dgvFlowerPrice.Size = new Size(1391, 500);
            dgvFlowerPrice.TabIndex = 0;
            dgvFlowerPrice.CellContentClick += dgvFlowerPrice_CellContentClick;
            // 
            // FlowerID
            // 
            FlowerID.DataPropertyName = "FlowerID";
            FlowerID.HeaderText = "ID";
            FlowerID.MinimumWidth = 8;
            FlowerID.Name = "FlowerID";
            FlowerID.ReadOnly = true;
            // 
            // FlowerName
            // 
            FlowerName.DataPropertyName = "FlowerName";
            FlowerName.HeaderText = "Name";
            FlowerName.MinimumWidth = 8;
            FlowerName.Name = "FlowerName";
            FlowerName.ReadOnly = true;
            // 
            // FTypeName
            // 
            FTypeName.DataPropertyName = "FTypeName";
            FTypeName.HeaderText = "FType";
            FTypeName.MinimumWidth = 8;
            FTypeName.Name = "FTypeName";
            FTypeName.ReadOnly = true;
            // 
            // FColorName
            // 
            FColorName.DataPropertyName = "FColorName";
            FColorName.HeaderText = "FColor";
            FColorName.MinimumWidth = 8;
            FColorName.Name = "FColorName";
            FColorName.ReadOnly = true;
            // 
            // FCharacteristicName
            // 
            FCharacteristicName.DataPropertyName = "FCharacteristicName";
            FCharacteristicName.HeaderText = "FChar";
            FCharacteristicName.MinimumWidth = 8;
            FCharacteristicName.Name = "FCharacteristicName";
            FCharacteristicName.ReadOnly = true;
            // 
            // ProfitRate
            // 
            ProfitRate.DataPropertyName = "ProfitRate";
            ProfitRate.HeaderText = "AsIs PrfitRate";
            ProfitRate.MinimumWidth = 8;
            ProfitRate.Name = "ProfitRate";
            ProfitRate.ReadOnly = true;
            // 
            // HistoryRateFlower
            // 
            HistoryRateFlower.HeaderText = "HistoryPrice";
            HistoryRateFlower.Image = Properties.Resources.details;
            HistoryRateFlower.MinimumWidth = 8;
            HistoryRateFlower.Name = "HistoryRateFlower";
            // 
            // HistoryProfitRate
            // 
            HistoryProfitRate.HeaderText = "HistoryProfitRate";
            HistoryProfitRate.Image = Properties.Resources.addition;
            HistoryProfitRate.MinimumWidth = 8;
            HistoryProfitRate.Name = "HistoryProfitRate";
            // 
            // tpAccessoryProfitRate
            // 
            tpAccessoryProfitRate.Controls.Add(dgvAccessoryPrice);
            tpAccessoryProfitRate.Location = new Point(4, 34);
            tpAccessoryProfitRate.Name = "tpAccessoryProfitRate";
            tpAccessoryProfitRate.Padding = new Padding(3);
            tpAccessoryProfitRate.Size = new Size(1645, 906);
            tpAccessoryProfitRate.TabIndex = 1;
            tpAccessoryProfitRate.Text = "Acessory";
            tpAccessoryProfitRate.UseVisualStyleBackColor = true;
            // 
            // dgvAccessoryPrice
            // 
            dgvAccessoryPrice.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAccessoryPrice.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAccessoryPrice.Columns.AddRange(new DataGridViewColumn[] { MaterialId, MaterialName, ProfitRateA, HistoryRateChart, AccesoryHistoryPrice });
            dgvAccessoryPrice.Location = new Point(61, 92);
            dgvAccessoryPrice.Name = "dgvAccessoryPrice";
            dgvAccessoryPrice.RowHeadersWidth = 62;
            dgvAccessoryPrice.Size = new Size(941, 573);
            dgvAccessoryPrice.TabIndex = 0;
            dgvAccessoryPrice.CellContentClick += dgvAccessoryPrice_CellContentClick;
            // 
            // MaterialId
            // 
            MaterialId.DataPropertyName = "MaterialId";
            MaterialId.HeaderText = "ID";
            MaterialId.MinimumWidth = 8;
            MaterialId.Name = "MaterialId";
            MaterialId.ReadOnly = true;
            // 
            // MaterialName
            // 
            MaterialName.DataPropertyName = "MaterialName";
            MaterialName.HeaderText = "Name";
            MaterialName.MinimumWidth = 8;
            MaterialName.Name = "MaterialName";
            MaterialName.ReadOnly = true;
            // 
            // ProfitRateA
            // 
            ProfitRateA.DataPropertyName = "ProfitRateA";
            ProfitRateA.HeaderText = "AsIs PrfitRate";
            ProfitRateA.MinimumWidth = 8;
            ProfitRateA.Name = "ProfitRateA";
            ProfitRateA.ReadOnly = true;
            // 
            // HistoryRateChart
            // 
            HistoryRateChart.HeaderText = "HistoryRateChart";
            HistoryRateChart.Image = Properties.Resources.details;
            HistoryRateChart.MinimumWidth = 8;
            HistoryRateChart.Name = "HistoryRateChart";
            // 
            // AccesoryHistoryPrice
            // 
            AccesoryHistoryPrice.HeaderText = "AccesoryHistoryPrice";
            AccesoryHistoryPrice.Image = Properties.Resources.addition;
            AccesoryHistoryPrice.MinimumWidth = 8;
            AccesoryHistoryPrice.Name = "AccesoryHistoryPrice";
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
            Load += MaterialAdjustmentForm_Load;
            tbConMaterialAdjustment.ResumeLayout(false);
            tpFlowerProfitRate.ResumeLayout(false);
            tpFlowerProfitRate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFlowerPrice).EndInit();
            tpAccessoryProfitRate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAccessoryPrice).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tbConMaterialAdjustment;
        private TabPage tpFlowerProfitRate;
        private TabPage tpAccessoryProfitRate;
        private DataGridView dgvFlowerPrice;
        private Label lblFChar;
        private Label lblFColor;
        private ComboBox cbbType;
        private Label lblFType;
        private ComboBox cbbChar;
        private ComboBox cbbColor;
        private DataGridView dgvAccessoryPrice;
        private DataGridViewTextBoxColumn FlowerID;
        private DataGridViewTextBoxColumn FlowerName;
        private DataGridViewTextBoxColumn FTypeName;
        private DataGridViewTextBoxColumn FColorName;
        private DataGridViewTextBoxColumn FCharacteristicName;
        private DataGridViewTextBoxColumn ProfitRate;
        private DataGridViewImageColumn HistoryRateFlower;
        private DataGridViewImageColumn HistoryProfitRate;
        private DataGridViewTextBoxColumn MaterialId;
        private DataGridViewTextBoxColumn MaterialName;
        private DataGridViewTextBoxColumn ProfitRateA;
        private DataGridViewImageColumn HistoryRateChart;
        private DataGridViewImageColumn AccesoryHistoryPrice;
    }
}