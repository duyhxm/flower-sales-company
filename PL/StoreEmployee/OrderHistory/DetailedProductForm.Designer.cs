namespace PL.StoreEmployee.OrderHistory
{
    partial class DetailedProductForm
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
            dgvAccessories = new DataGridView();
            btnOk = new Button();
            dgvFlowers = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            ColFlowerId = new DataGridViewTextBoxColumn();
            ColFlowerName = new DataGridViewTextBoxColumn();
            ColFColor = new DataGridViewTextBoxColumn();
            ColFChar = new DataGridViewTextBoxColumn();
            ColUsedFQuantity = new DataGridViewTextBoxColumn();
            ColAccessoryId = new DataGridViewTextBoxColumn();
            ColAccessoryName = new DataGridViewTextBoxColumn();
            ColUsedAQuantity = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvAccessories).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvFlowers).BeginInit();
            SuspendLayout();
            // 
            // dgvAccessories
            // 
            dgvAccessories.AllowUserToAddRows = false;
            dgvAccessories.AllowUserToDeleteRows = false;
            dgvAccessories.AllowUserToResizeColumns = false;
            dgvAccessories.AllowUserToResizeRows = false;
            dgvAccessories.BackgroundColor = SystemColors.Control;
            dgvAccessories.BorderStyle = BorderStyle.None;
            dgvAccessories.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAccessories.Columns.AddRange(new DataGridViewColumn[] { ColAccessoryId, ColAccessoryName, ColUsedAQuantity });
            dgvAccessories.Location = new Point(780, 111);
            dgvAccessories.Name = "dgvAccessories";
            dgvAccessories.RowHeadersVisible = false;
            dgvAccessories.RowHeadersWidth = 62;
            dgvAccessories.Size = new Size(405, 402);
            dgvAccessories.TabIndex = 0;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(1101, 548);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(84, 40);
            btnOk.TabIndex = 1;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // dgvFlowers
            // 
            dgvFlowers.AllowUserToAddRows = false;
            dgvFlowers.AllowUserToDeleteRows = false;
            dgvFlowers.AllowUserToResizeColumns = false;
            dgvFlowers.AllowUserToResizeRows = false;
            dgvFlowers.BackgroundColor = SystemColors.Control;
            dgvFlowers.BorderStyle = BorderStyle.None;
            dgvFlowers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFlowers.Columns.AddRange(new DataGridViewColumn[] { ColFlowerId, ColFlowerName, ColFColor, ColFChar, ColUsedFQuantity });
            dgvFlowers.Location = new Point(13, 111);
            dgvFlowers.Name = "dgvFlowers";
            dgvFlowers.RowHeadersVisible = false;
            dgvFlowers.RowHeadersWidth = 62;
            dgvFlowers.Size = new Size(709, 402);
            dgvFlowers.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(24, 30);
            label1.Name = "label1";
            label1.Size = new Size(113, 38);
            label1.TabIndex = 3;
            label1.Text = "Flowers";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(812, 30);
            label2.Name = "label2";
            label2.Size = new Size(162, 38);
            label2.TabIndex = 4;
            label2.Text = "Accessories";
            // 
            // ColFlowerId
            // 
            ColFlowerId.FillWeight = 50F;
            ColFlowerId.HeaderText = "ID";
            ColFlowerId.MinimumWidth = 8;
            ColFlowerId.Name = "ColFlowerId";
            ColFlowerId.ReadOnly = true;
            // 
            // ColFlowerName
            // 
            ColFlowerName.HeaderText = "Name";
            ColFlowerName.MinimumWidth = 8;
            ColFlowerName.Name = "ColFlowerName";
            ColFlowerName.ReadOnly = true;
            ColFlowerName.Width = 250;
            // 
            // ColFColor
            // 
            ColFColor.HeaderText = "Color";
            ColFColor.MinimumWidth = 8;
            ColFColor.Name = "ColFColor";
            ColFColor.ReadOnly = true;
            ColFColor.Width = 150;
            // 
            // ColFChar
            // 
            ColFChar.HeaderText = "Char";
            ColFChar.MinimumWidth = 8;
            ColFChar.Name = "ColFChar";
            ColFChar.ReadOnly = true;
            // 
            // ColUsedFQuantity
            // 
            ColUsedFQuantity.FillWeight = 50F;
            ColUsedFQuantity.HeaderText = "Q";
            ColUsedFQuantity.MinimumWidth = 8;
            ColUsedFQuantity.Name = "ColUsedFQuantity";
            ColUsedFQuantity.ReadOnly = true;
            ColUsedFQuantity.Width = 80;
            // 
            // ColAccessoryId
            // 
            ColAccessoryId.FillWeight = 50F;
            ColAccessoryId.HeaderText = "ID";
            ColAccessoryId.MinimumWidth = 8;
            ColAccessoryId.Name = "ColAccessoryId";
            ColAccessoryId.ReadOnly = true;
            // 
            // ColAccessoryName
            // 
            ColAccessoryName.HeaderText = "Name";
            ColAccessoryName.MinimumWidth = 8;
            ColAccessoryName.Name = "ColAccessoryName";
            ColAccessoryName.ReadOnly = true;
            ColAccessoryName.Width = 200;
            // 
            // ColUsedAQuantity
            // 
            ColUsedAQuantity.FillWeight = 50F;
            ColUsedAQuantity.HeaderText = "Q";
            ColUsedAQuantity.MinimumWidth = 8;
            ColUsedAQuantity.Name = "ColUsedAQuantity";
            ColUsedAQuantity.ReadOnly = true;
            ColUsedAQuantity.Width = 80;
            // 
            // DetailedProductForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 600);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvFlowers);
            Controls.Add(btnOk);
            Controls.Add(dgvAccessories);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "DetailedProductForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DetailedProductForm";
            Load += DetailedProductForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAccessories).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvFlowers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvAccessories;
        private Button btnOk;
        private DataGridView dgvFlowers;
        private Label label1;
        private Label label2;
        private DataGridViewTextBoxColumn ColFlowerId;
        private DataGridViewTextBoxColumn ColFlowerName;
        private DataGridViewTextBoxColumn ColFColor;
        private DataGridViewTextBoxColumn ColFChar;
        private DataGridViewTextBoxColumn ColUsedFQuantity;
        private DataGridViewTextBoxColumn ColAccessoryId;
        private DataGridViewTextBoxColumn ColAccessoryName;
        private DataGridViewTextBoxColumn ColUsedAQuantity;
    }
}