namespace PL.SalesEmployee.ProductPlan
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
            tabConDetailedProduct = new TabControl();
            tpFlower = new TabPage();
            dgvFlower_DetailedProduct = new DataGridView();
            ColFlowerId = new DataGridViewTextBoxColumn();
            ColFlowerName = new DataGridViewTextBoxColumn();
            ColFType = new DataGridViewTextBoxColumn();
            ColFColor = new DataGridViewTextBoxColumn();
            ColFCharacteristic = new DataGridViewTextBoxColumn();
            ColUsedQuantity = new DataGridViewTextBoxColumn();
            tpAccessory = new TabPage();
            dgvAccessory_DetailedProduct = new DataGridView();
            ColAccessoryId = new DataGridViewTextBoxColumn();
            ColAccessoryName = new DataGridViewTextBoxColumn();
            ColUsedAQuantity = new DataGridViewTextBoxColumn();
            btnOk = new Button();
            tabConDetailedProduct.SuspendLayout();
            tpFlower.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFlower_DetailedProduct).BeginInit();
            tpAccessory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAccessory_DetailedProduct).BeginInit();
            SuspendLayout();
            // 
            // tabConDetailedProduct
            // 
            tabConDetailedProduct.Controls.Add(tpFlower);
            tabConDetailedProduct.Controls.Add(tpAccessory);
            tabConDetailedProduct.Dock = DockStyle.Top;
            tabConDetailedProduct.Location = new Point(0, 0);
            tabConDetailedProduct.Name = "tabConDetailedProduct";
            tabConDetailedProduct.SelectedIndex = 0;
            tabConDetailedProduct.Size = new Size(976, 487);
            tabConDetailedProduct.TabIndex = 0;
            // 
            // tpFlower
            // 
            tpFlower.Controls.Add(dgvFlower_DetailedProduct);
            tpFlower.Location = new Point(4, 41);
            tpFlower.Name = "tpFlower";
            tpFlower.Padding = new Padding(3);
            tpFlower.Size = new Size(968, 442);
            tpFlower.TabIndex = 0;
            tpFlower.Text = "Flower";
            tpFlower.UseVisualStyleBackColor = true;
            // 
            // dgvFlower_DetailedProduct
            // 
            dgvFlower_DetailedProduct.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFlower_DetailedProduct.Columns.AddRange(new DataGridViewColumn[] { ColFlowerId, ColFlowerName, ColFType, ColFColor, ColFCharacteristic, ColUsedQuantity });
            dgvFlower_DetailedProduct.Dock = DockStyle.Fill;
            dgvFlower_DetailedProduct.Location = new Point(3, 3);
            dgvFlower_DetailedProduct.Name = "dgvFlower_DetailedProduct";
            dgvFlower_DetailedProduct.RowHeadersWidth = 62;
            dgvFlower_DetailedProduct.Size = new Size(962, 436);
            dgvFlower_DetailedProduct.TabIndex = 0;
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
            ColFlowerName.Width = 200;
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
            // ColFCharacteristic
            // 
            ColFCharacteristic.HeaderText = "FChar";
            ColFCharacteristic.MinimumWidth = 8;
            ColFCharacteristic.Name = "ColFCharacteristic";
            ColFCharacteristic.ReadOnly = true;
            ColFCharacteristic.Width = 150;
            // 
            // ColUsedQuantity
            // 
            ColUsedQuantity.HeaderText = "Q";
            ColUsedQuantity.MinimumWidth = 8;
            ColUsedQuantity.Name = "ColUsedQuantity";
            ColUsedQuantity.ReadOnly = true;
            ColUsedQuantity.Width = 80;
            // 
            // tpAccessory
            // 
            tpAccessory.Controls.Add(dgvAccessory_DetailedProduct);
            tpAccessory.Location = new Point(4, 41);
            tpAccessory.Name = "tpAccessory";
            tpAccessory.Padding = new Padding(3);
            tpAccessory.Size = new Size(968, 442);
            tpAccessory.TabIndex = 1;
            tpAccessory.Text = "Accessory";
            tpAccessory.UseVisualStyleBackColor = true;
            // 
            // dgvAccessory_DetailedProduct
            // 
            dgvAccessory_DetailedProduct.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAccessory_DetailedProduct.Columns.AddRange(new DataGridViewColumn[] { ColAccessoryId, ColAccessoryName, ColUsedAQuantity });
            dgvAccessory_DetailedProduct.Location = new Point(129, 83);
            dgvAccessory_DetailedProduct.Name = "dgvAccessory_DetailedProduct";
            dgvAccessory_DetailedProduct.RowHeadersWidth = 62;
            dgvAccessory_DetailedProduct.Size = new Size(609, 225);
            dgvAccessory_DetailedProduct.TabIndex = 0;
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
            // ColUsedAQuantity
            // 
            ColUsedAQuantity.HeaderText = "Q";
            ColUsedAQuantity.MinimumWidth = 8;
            ColUsedAQuantity.Name = "ColUsedAQuantity";
            ColUsedAQuantity.ReadOnly = true;
            ColUsedAQuantity.Width = 150;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(754, 503);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(143, 50);
            btnOk.TabIndex = 1;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            // 
            // DetailedProductForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(976, 576);
            Controls.Add(btnOk);
            Controls.Add(tabConDetailedProduct);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "DetailedProductForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DetailedProductForm";
            tabConDetailedProduct.ResumeLayout(false);
            tpFlower.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvFlower_DetailedProduct).EndInit();
            tpAccessory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAccessory_DetailedProduct).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabConDetailedProduct;
        private TabPage tpFlower;
        private TabPage tpAccessory;
        private Button btnOk;
        private DataGridView dgvFlower_DetailedProduct;
        private DataGridViewTextBoxColumn ColFlowerId;
        private DataGridViewTextBoxColumn ColFlowerName;
        private DataGridViewTextBoxColumn ColFType;
        private DataGridViewTextBoxColumn ColFColor;
        private DataGridViewTextBoxColumn ColFCharacteristic;
        private DataGridViewTextBoxColumn ColUsedQuantity;
        private DataGridView dgvAccessory_DetailedProduct;
        private DataGridViewTextBoxColumn ColAccessoryId;
        private DataGridViewTextBoxColumn ColAccessoryName;
        private DataGridViewTextBoxColumn ColUsedAQuantity;
    }
}