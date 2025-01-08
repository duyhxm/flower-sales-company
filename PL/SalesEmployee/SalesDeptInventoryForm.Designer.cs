namespace PL.SalesEmployee
{
    partial class SalesDeptInventoryForm
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
            tabControl1 = new TabControl();
            tpProduct = new TabPage();
            tpFlower = new TabPage();
            tpAccessory = new TabPage();
            dataGridView1 = new DataGridView();
            ColProductId = new DataGridViewTextBoxColumn();
            ColProductName = new DataGridViewTextBoxColumn();
            ColStockProductQuantity = new DataGridViewTextBoxColumn();
            tabControl1.SuspendLayout();
            tpProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tpProduct);
            tabControl1.Controls.Add(tpFlower);
            tabControl1.Controls.Add(tpAccessory);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1600, 944);
            tabControl1.TabIndex = 1;
            // 
            // tpProduct
            // 
            tpProduct.Controls.Add(dataGridView1);
            tpProduct.Location = new Point(4, 41);
            tpProduct.Name = "tpProduct";
            tpProduct.Padding = new Padding(3);
            tpProduct.Size = new Size(1592, 899);
            tpProduct.TabIndex = 0;
            tpProduct.Text = "Product";
            tpProduct.UseVisualStyleBackColor = true;
            // 
            // tpFlower
            // 
            tpFlower.Location = new Point(4, 41);
            tpFlower.Name = "tpFlower";
            tpFlower.Padding = new Padding(3);
            tpFlower.Size = new Size(1592, 899);
            tpFlower.TabIndex = 1;
            tpFlower.Text = "Flower";
            tpFlower.UseVisualStyleBackColor = true;
            // 
            // tpAccessory
            // 
            tpAccessory.Location = new Point(4, 41);
            tpAccessory.Name = "tpAccessory";
            tpAccessory.Size = new Size(1592, 899);
            tpAccessory.TabIndex = 2;
            tpAccessory.Text = "Accessory";
            tpAccessory.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ColProductId, ColProductName, ColStockProductQuantity });
            dataGridView1.Location = new Point(78, 196);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(545, 225);
            dataGridView1.TabIndex = 0;
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
            ColProductName.Width = 150;
            // 
            // ColStockProductQuantity
            // 
            ColStockProductQuantity.HeaderText = "Q";
            ColStockProductQuantity.MinimumWidth = 8;
            ColStockProductQuantity.Name = "ColStockProductQuantity";
            ColStockProductQuantity.ReadOnly = true;
            ColStockProductQuantity.Width = 150;
            // 
            // SalesDeptInventoryForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1600, 944);
            Controls.Add(tabControl1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "SalesDeptInventoryForm";
            Text = "SalesDeptInventoryForm";
            tabControl1.ResumeLayout(false);
            tpProduct.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tpProduct;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn ColProductId;
        private DataGridViewTextBoxColumn ColProductName;
        private DataGridViewTextBoxColumn ColStockProductQuantity;
        private TabPage tpFlower;
        private TabPage tpAccessory;
    }
}