namespace PL.SalesEmployee
{
    partial class CreateProduct
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
            materialDataGridView = new DataGridView();
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
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)materialDataGridView).BeginInit();
            SuspendLayout();
            // 
            // materialDataGridView
            // 
            materialDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            materialDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            materialDataGridView.Columns.AddRange(new DataGridViewColumn[] { MaterialId, MaterialName, MaterialType, Unit, Quantity, Check });
            materialDataGridView.Location = new Point(12, 125);
            materialDataGridView.Name = "materialDataGridView";
            materialDataGridView.Size = new Size(1225, 576);
            materialDataGridView.TabIndex = 0;
            // 
            // MaterialId
            // 
            MaterialId.DataPropertyName = "MaterialId";
            MaterialId.HeaderText = "MaterialId";
            MaterialId.Name = "MaterialId";
            // 
            // MaterialName
            // 
            MaterialName.DataPropertyName = "MaterialName";
            MaterialName.HeaderText = "MaterialName";
            MaterialName.Name = "MaterialName";
            // 
            // MaterialType
            // 
            MaterialType.DataPropertyName = "MaterialType";
            MaterialType.HeaderText = "MaterialType";
            MaterialType.Name = "MaterialType";
            // 
            // Unit
            // 
            Unit.DataPropertyName = "Unit";
            Unit.HeaderText = "Unit";
            Unit.Name = "Unit";
            // 
            // Quantity
            // 
            Quantity.HeaderText = "Quantity";
            Quantity.Name = "Quantity";
            // 
            // Check
            // 
            Check.HeaderText = "";
            Check.Name = "Check";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(54, 59);
            label1.Name = "label1";
            label1.Size = new Size(77, 21);
            label1.TabIndex = 1;
            label1.Text = "FR Name:";
            // 
            // cbbFr
            // 
            cbbFr.Font = new Font("Segoe UI", 12F);
            cbbFr.FormattingEnabled = true;
            cbbFr.Location = new Point(137, 54);
            cbbFr.Name = "cbbFr";
            cbbFr.Size = new Size(159, 29);
            cbbFr.TabIndex = 2;
            // 
            // txtProductName
            // 
            txtProductName.Font = new Font("Segoe UI", 12F);
            txtProductName.Location = new Point(477, 55);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(176, 29);
            txtProductName.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(362, 61);
            label2.Name = "label2";
            label2.Size = new Size(109, 21);
            label2.TabIndex = 4;
            label2.Text = "ProductName:";
            // 
            // button1
            // 
            button1.Location = new Point(741, 52);
            button1.Name = "button1";
            button1.Size = new Size(111, 39);
            button1.TabIndex = 5;
            button1.Text = "Create";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // CreateProduct
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1258, 725);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(txtProductName);
            Controls.Add(cbbFr);
            Controls.Add(label1);
            Controls.Add(materialDataGridView);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CreateProduct";
            Text = "CreateProduct";
            Load += CreateProduct_Load;
            ((System.ComponentModel.ISupportInitialize)materialDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView materialDataGridView;
        private Label label1;
        private ComboBox cbbFr;
        private TextBox txtProductName;
        private Label label2;
        private Button button1;
        private DataGridViewTextBoxColumn MaterialId;
        private DataGridViewTextBoxColumn MaterialName;
        private DataGridViewTextBoxColumn MaterialType;
        private DataGridViewTextBoxColumn Unit;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewCheckBoxColumn Check;
    }
}