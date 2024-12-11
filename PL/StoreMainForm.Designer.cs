namespace PL
{
    partial class StoreMainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StoreMainForm));
            splConStoreMainForm = new SplitContainer();
            pictureBox_notificationBell = new PictureBox();
            btnDailyTask = new Button();
            txtBx_currentUser = new TextBox();
            btnOrderHistory = new Button();
            btnPreOrderList = new Button();
            btnProductList = new Button();
            btnInventory = new Button();
            btnCreateOrder = new Button();
            btnCreateProduct = new Button();
            ((System.ComponentModel.ISupportInitialize)splConStoreMainForm).BeginInit();
            splConStoreMainForm.Panel1.SuspendLayout();
            splConStoreMainForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_notificationBell).BeginInit();
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
            splConStoreMainForm.Panel1.Controls.Add(pictureBox_notificationBell);
            splConStoreMainForm.Panel1.Controls.Add(btnDailyTask);
            splConStoreMainForm.Panel1.Controls.Add(txtBx_currentUser);
            splConStoreMainForm.Panel1.Controls.Add(btnOrderHistory);
            splConStoreMainForm.Panel1.Controls.Add(btnPreOrderList);
            splConStoreMainForm.Panel1.Controls.Add(btnProductList);
            splConStoreMainForm.Panel1.Controls.Add(btnInventory);
            splConStoreMainForm.Panel1.Controls.Add(btnCreateOrder);
            splConStoreMainForm.Panel1.Controls.Add(btnCreateProduct);
            splConStoreMainForm.Size = new Size(1898, 944);
            splConStoreMainForm.SplitterDistance = 241;
            splConStoreMainForm.TabIndex = 1;
            // 
            // pictureBox_notificationBell
            // 
            pictureBox_notificationBell.BackgroundImage = (Image)resources.GetObject("pictureBox_notificationBell.BackgroundImage");
            pictureBox_notificationBell.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox_notificationBell.Location = new Point(195, 339);
            pictureBox_notificationBell.Margin = new Padding(3, 4, 3, 4);
            pictureBox_notificationBell.Name = "pictureBox_notificationBell";
            pictureBox_notificationBell.Size = new Size(30, 38);
            pictureBox_notificationBell.TabIndex = 8;
            pictureBox_notificationBell.TabStop = false;
            // 
            // btnDailyTask
            // 
            btnDailyTask.Location = new Point(0, 331);
            btnDailyTask.Margin = new Padding(3, 4, 3, 4);
            btnDailyTask.Name = "btnDailyTask";
            btnDailyTask.Size = new Size(186, 59);
            btnDailyTask.TabIndex = 7;
            btnDailyTask.Text = "Daily Task";
            btnDailyTask.TextAlign = ContentAlignment.MiddleLeft;
            btnDailyTask.UseVisualStyleBackColor = true;
            // 
            // txtBx_currentUser
            // 
            txtBx_currentUser.Location = new Point(0, 1063);
            txtBx_currentUser.Margin = new Padding(3, 4, 3, 4);
            txtBx_currentUser.Name = "txtBx_currentUser";
            txtBx_currentUser.Size = new Size(221, 39);
            txtBx_currentUser.TabIndex = 6;
            // 
            // btnOrderHistory
            // 
            btnOrderHistory.Location = new Point(0, 729);
            btnOrderHistory.Margin = new Padding(3, 4, 3, 4);
            btnOrderHistory.Name = "btnOrderHistory";
            btnOrderHistory.Size = new Size(186, 59);
            btnOrderHistory.TabIndex = 5;
            btnOrderHistory.Text = "Order History";
            btnOrderHistory.TextAlign = ContentAlignment.MiddleLeft;
            btnOrderHistory.UseVisualStyleBackColor = true;
            // 
            // btnPreOrderList
            // 
            btnPreOrderList.Location = new Point(0, 663);
            btnPreOrderList.Margin = new Padding(3, 4, 3, 4);
            btnPreOrderList.Name = "btnPreOrderList";
            btnPreOrderList.Size = new Size(186, 59);
            btnPreOrderList.TabIndex = 4;
            btnPreOrderList.Text = "Pre-Order List";
            btnPreOrderList.TextAlign = ContentAlignment.MiddleLeft;
            btnPreOrderList.UseVisualStyleBackColor = true;
            // 
            // btnProductList
            // 
            btnProductList.Location = new Point(0, 596);
            btnProductList.Margin = new Padding(3, 4, 3, 4);
            btnProductList.Name = "btnProductList";
            btnProductList.Size = new Size(186, 59);
            btnProductList.TabIndex = 3;
            btnProductList.Text = "Product List";
            btnProductList.TextAlign = ContentAlignment.MiddleLeft;
            btnProductList.UseVisualStyleBackColor = true;
            // 
            // btnInventory
            // 
            btnInventory.Location = new Point(0, 530);
            btnInventory.Margin = new Padding(3, 4, 3, 4);
            btnInventory.Name = "btnInventory";
            btnInventory.Size = new Size(186, 59);
            btnInventory.TabIndex = 2;
            btnInventory.Text = "Inventory";
            btnInventory.TextAlign = ContentAlignment.MiddleLeft;
            btnInventory.UseVisualStyleBackColor = true;
            btnInventory.Click += btnInventory_Click;
            // 
            // btnCreateOrder
            // 
            btnCreateOrder.Location = new Point(0, 463);
            btnCreateOrder.Margin = new Padding(3, 4, 3, 4);
            btnCreateOrder.Name = "btnCreateOrder";
            btnCreateOrder.Size = new Size(186, 59);
            btnCreateOrder.TabIndex = 1;
            btnCreateOrder.Text = "Create Order";
            btnCreateOrder.TextAlign = ContentAlignment.MiddleLeft;
            btnCreateOrder.UseVisualStyleBackColor = true;
            btnCreateOrder.Click += btnCreateOrder_Click;
            // 
            // btnCreateProduct
            // 
            btnCreateProduct.Location = new Point(0, 397);
            btnCreateProduct.Margin = new Padding(3, 4, 3, 4);
            btnCreateProduct.Name = "btnCreateProduct";
            btnCreateProduct.Size = new Size(186, 59);
            btnCreateProduct.TabIndex = 0;
            btnCreateProduct.Text = "Create Product";
            btnCreateProduct.TextAlign = ContentAlignment.MiddleLeft;
            btnCreateProduct.UseVisualStyleBackColor = true;
            // 
            // StoreMainForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1898, 944);
            Controls.Add(splConStoreMainForm);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "StoreMainForm";
            Text = "Store Management";
            splConStoreMainForm.Panel1.ResumeLayout(false);
            splConStoreMainForm.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splConStoreMainForm).EndInit();
            splConStoreMainForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox_notificationBell).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splConStoreMainForm;
        private Button btnCreateProduct;
        private Button btnProductList;
        private Button btnInventory;
        private Button btnCreateOrder;
        private Button btnOrderHistory;
        private Button btnPreOrderList;
        private TextBox txtBx_currentUser;
        private Button btnDailyTask;
        private PictureBox pictureBox_notificationBell;
    }
}
