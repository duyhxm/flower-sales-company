namespace PL.SalesEmployee
{
    partial class ProductCreationForm1
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dgvMaterials = new DataGridView();
            MaterialId = new DataGridViewTextBoxColumn();
            MaterialName = new DataGridViewTextBoxColumn();
            MaterialType = new DataGridViewTextBoxColumn();
            Unit = new DataGridViewTextBoxColumn();
            Quantity = new DataGridViewTextBoxColumn();
            Check = new DataGridViewCheckBoxColumn();
            label1 = new Label();
            cbbFr = new ComboBox();
            txtProductName = new TextBox();
            label2 = new Label();
            btnCreate = new Button();
            lblProductInfo = new Label();
            label3 = new Label();
            cmbBxMaterialType = new ComboBox();
            lblMaterialType = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvMaterials).BeginInit();
            SuspendLayout();
            // 
            // dgvMaterials
            // 
            dgvMaterials.Anchor = AnchorStyles.None;
            dgvMaterials.BackgroundColor = SystemColors.Control;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvMaterials.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvMaterials.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMaterials.Columns.AddRange(new DataGridViewColumn[] { MaterialId, MaterialName, MaterialType, Unit, Quantity, Check });
            dgvMaterials.Location = new Point(81, 190);
            dgvMaterials.Margin = new Padding(4, 5, 4, 5);
            dgvMaterials.Name = "dgvMaterials";
            dgvMaterials.RowHeadersVisible = false;
            dgvMaterials.RowHeadersWidth = 62;
            dgvMaterials.Size = new Size(855, 604);
            dgvMaterials.TabIndex = 0;
            // 
            // MaterialId
            // 
            MaterialId.DataPropertyName = "MaterialId";
            MaterialId.HeaderText = "ID";
            MaterialId.MinimumWidth = 8;
            MaterialId.Name = "MaterialId";
            MaterialId.Width = 150;
            // 
            // MaterialName
            // 
            MaterialName.DataPropertyName = "MaterialName";
            MaterialName.HeaderText = "Name";
            MaterialName.MinimumWidth = 8;
            MaterialName.Name = "MaterialName";
            MaterialName.Width = 250;
            // 
            // MaterialType
            // 
            MaterialType.DataPropertyName = "MaterialType";
            MaterialType.HeaderText = "Type";
            MaterialType.MinimumWidth = 8;
            MaterialType.Name = "MaterialType";
            MaterialType.ReadOnly = true;
            MaterialType.Width = 150;
            // 
            // Unit
            // 
            Unit.DataPropertyName = "Unit";
            Unit.FillWeight = 50F;
            Unit.HeaderText = "Unit";
            Unit.MinimumWidth = 8;
            Unit.Name = "Unit";
            Unit.Width = 150;
            // 
            // Quantity
            // 
            Quantity.FillWeight = 50F;
            Quantity.HeaderText = "Q";
            Quantity.MinimumWidth = 8;
            Quantity.Name = "Quantity";
            Quantity.Width = 80;
            // 
            // Check
            // 
            Check.HeaderText = "";
            Check.MinimumWidth = 8;
            Check.Name = "Check";
            Check.Width = 50;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(987, 237);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(111, 32);
            label1.TabIndex = 1;
            label1.Text = "FR Name";
            // 
            // cbbFr
            // 
            cbbFr.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbFr.Font = new Font("Segoe UI", 12F);
            cbbFr.FormattingEnabled = true;
            cbbFr.Location = new Point(1162, 234);
            cbbFr.Margin = new Padding(4, 5, 4, 5);
            cbbFr.Name = "cbbFr";
            cbbFr.Size = new Size(143, 40);
            cbbFr.TabIndex = 2;
            // 
            // txtProductName
            // 
            txtProductName.Font = new Font("Segoe UI", 12F);
            txtProductName.Location = new Point(1160, 284);
            txtProductName.Margin = new Padding(4, 5, 4, 5);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(296, 39);
            txtProductName.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(985, 287);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(167, 32);
            label2.TabIndex = 4;
            label2.Text = "Product Name";
            // 
            // btnCreate
            // 
            btnCreate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCreate.Location = new Point(1128, 370);
            btnCreate.Margin = new Padding(4, 5, 4, 5);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(100, 50);
            btnCreate.TabIndex = 5;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // lblProductInfo
            // 
            lblProductInfo.AutoSize = true;
            lblProductInfo.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProductInfo.Location = new Point(1008, 34);
            lblProductInfo.Name = "lblProductInfo";
            lblProductInfo.Size = new Size(175, 38);
            lblProductInfo.TabIndex = 6;
            lblProductInfo.Text = "Product Info";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(28, 34);
            label3.Name = "label3";
            label3.Size = new Size(173, 38);
            label3.TabIndex = 7;
            label3.Text = "Material List";
            // 
            // cmbBxMaterialType
            // 
            cmbBxMaterialType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBxMaterialType.Font = new Font("Segoe UI", 12F);
            cmbBxMaterialType.FormattingEnabled = true;
            cmbBxMaterialType.Location = new Point(736, 87);
            cmbBxMaterialType.Margin = new Padding(4, 5, 4, 5);
            cmbBxMaterialType.Name = "cmbBxMaterialType";
            cmbBxMaterialType.Size = new Size(179, 40);
            cmbBxMaterialType.TabIndex = 8;
            cmbBxMaterialType.SelectedValueChanged += cmbBxMaterialType_SelectedValueChanged;
            // 
            // lblMaterialType
            // 
            lblMaterialType.AutoSize = true;
            lblMaterialType.Font = new Font("Segoe UI", 12F);
            lblMaterialType.Location = new Point(557, 90);
            lblMaterialType.Margin = new Padding(4, 0, 4, 0);
            lblMaterialType.Name = "lblMaterialType";
            lblMaterialType.Size = new Size(159, 32);
            lblMaterialType.TabIndex = 9;
            lblMaterialType.Text = "Material Type";
            // 
            // ProductCreationForm1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1653, 944);
            Controls.Add(lblMaterialType);
            Controls.Add(cmbBxMaterialType);
            Controls.Add(label3);
            Controls.Add(lblProductInfo);
            Controls.Add(btnCreate);
            Controls.Add(label2);
            Controls.Add(txtProductName);
            Controls.Add(cbbFr);
            Controls.Add(label1);
            Controls.Add(dgvMaterials);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "ProductCreationForm1";
            StartPosition = FormStartPosition.Manual;
            Text = "CreateProduct";
            Load += CreateProduct_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMaterials).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvMaterials;
        private Label label1;
        private ComboBox cbbFr;
        private TextBox txtProductName;
        private Label label2;
        private Button btnCreate;
        private Label lblProductInfo;
        private Label label3;
        private ComboBox cmbBxMaterialType;
        private Label lblMaterialType;
        private DataGridViewTextBoxColumn MaterialId;
        private DataGridViewTextBoxColumn MaterialName;
        private DataGridViewTextBoxColumn MaterialType;
        private DataGridViewTextBoxColumn Unit;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewCheckBoxColumn Check;
    }
}