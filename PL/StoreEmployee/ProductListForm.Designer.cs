namespace PL.StoreEmployee
{
    partial class ProductListForm
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
            dgvProductList = new DataGridView();
            btnCreate = new Button();
            lblQuantity = new Label();
            txtBxQuantity = new TextBox();
            btnClear = new Button();
            ColProductId = new DataGridViewTextBoxColumn();
            ColProductName = new DataGridViewTextBoxColumn();
            ColFRName = new DataGridViewTextBoxColumn();
            ColSelection = new DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvProductList).BeginInit();
            SuspendLayout();
            // 
            // dgvProductList
            // 
            dgvProductList.AllowUserToAddRows = false;
            dgvProductList.AllowUserToDeleteRows = false;
            dgvProductList.AllowUserToResizeColumns = false;
            dgvProductList.AllowUserToResizeRows = false;
            dgvProductList.BackgroundColor = SystemColors.Control;
            dgvProductList.BorderStyle = BorderStyle.None;
            dgvProductList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductList.Columns.AddRange(new DataGridViewColumn[] { ColProductId, ColProductName, ColFRName, ColSelection });
            dgvProductList.Location = new Point(27, 29);
            dgvProductList.Name = "dgvProductList";
            dgvProductList.RowHeadersVisible = false;
            dgvProductList.RowHeadersWidth = 62;
            dgvProductList.Size = new Size(606, 593);
            dgvProductList.TabIndex = 0;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(118, 785);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(119, 44);
            btnCreate.TabIndex = 1;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Location = new Point(66, 720);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(106, 32);
            lblQuantity.TabIndex = 2;
            lblQuantity.Text = "Quantity";
            // 
            // txtBxQuantity
            // 
            txtBxQuantity.Location = new Point(188, 717);
            txtBxQuantity.Name = "txtBxQuantity";
            txtBxQuantity.Size = new Size(150, 39);
            txtBxQuantity.TabIndex = 3;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(252, 785);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(119, 44);
            btnClear.TabIndex = 4;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // ColProductId
            // 
            ColProductId.HeaderText = "ID";
            ColProductId.MinimumWidth = 8;
            ColProductId.Name = "ColProductId";
            ColProductId.ReadOnly = true;
            ColProductId.Width = 150;
            // 
            // ColProductName
            // 
            ColProductName.HeaderText = "Name";
            ColProductName.MinimumWidth = 8;
            ColProductName.Name = "ColProductName";
            ColProductName.ReadOnly = true;
            ColProductName.Width = 250;
            // 
            // ColFRName
            // 
            ColFRName.HeaderText = "FRName";
            ColFRName.MinimumWidth = 8;
            ColFRName.Name = "ColFRName";
            ColFRName.ReadOnly = true;
            ColFRName.Width = 120;
            // 
            // ColSelection
            // 
            ColSelection.HeaderText = "";
            ColSelection.MinimumWidth = 8;
            ColSelection.Name = "ColSelection";
            ColSelection.Width = 50;
            // 
            // ProductListForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1500, 944);
            Controls.Add(btnClear);
            Controls.Add(txtBxQuantity);
            Controls.Add(lblQuantity);
            Controls.Add(btnCreate);
            Controls.Add(dgvProductList);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "ProductListForm";
            Text = "ProductList";
            Load += ProductListForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProductList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvProductList;
        private Button btnCreate;
        private Label lblQuantity;
        private TextBox txtBxQuantity;
        private Button btnClear;
        private DataGridViewTextBoxColumn ColProductId;
        private DataGridViewTextBoxColumn ColProductName;
        private DataGridViewTextBoxColumn ColFRName;
        private DataGridViewCheckBoxColumn ColSelection;
    }
}