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
            splitContainer_mainInterface = new SplitContainer();
            pictureBox_notificationBell = new PictureBox();
            btn_task = new Button();
            txtBx_currentUser = new TextBox();
            btn_orderHistory = new Button();
            btn_preOrderList = new Button();
            btn_productList = new Button();
            btn_inventory = new Button();
            btnCreateOrder = new Button();
            btn_createProduct = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer_mainInterface).BeginInit();
            splitContainer_mainInterface.Panel1.SuspendLayout();
            splitContainer_mainInterface.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_notificationBell).BeginInit();
            SuspendLayout();
            // 
            // splitContainer_mainInterface
            // 
            splitContainer_mainInterface.Dock = DockStyle.Fill;
            splitContainer_mainInterface.Location = new Point(0, 0);
            splitContainer_mainInterface.Margin = new Padding(3, 4, 3, 4);
            splitContainer_mainInterface.Name = "splitContainer_mainInterface";
            // 
            // splitContainer_mainInterface.Panel1
            // 
            splitContainer_mainInterface.Panel1.BackColor = SystemColors.ActiveCaption;
            splitContainer_mainInterface.Panel1.Controls.Add(pictureBox_notificationBell);
            splitContainer_mainInterface.Panel1.Controls.Add(btn_task);
            splitContainer_mainInterface.Panel1.Controls.Add(txtBx_currentUser);
            splitContainer_mainInterface.Panel1.Controls.Add(btn_orderHistory);
            splitContainer_mainInterface.Panel1.Controls.Add(btn_preOrderList);
            splitContainer_mainInterface.Panel1.Controls.Add(btn_productList);
            splitContainer_mainInterface.Panel1.Controls.Add(btn_inventory);
            splitContainer_mainInterface.Panel1.Controls.Add(btnCreateOrder);
            splitContainer_mainInterface.Panel1.Controls.Add(btn_createProduct);
            splitContainer_mainInterface.Size = new Size(1898, 944);
            splitContainer_mainInterface.SplitterDistance = 241;
            splitContainer_mainInterface.TabIndex = 1;
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
            // btn_task
            // 
            btn_task.Location = new Point(0, 331);
            btn_task.Margin = new Padding(3, 4, 3, 4);
            btn_task.Name = "btn_task";
            btn_task.Size = new Size(186, 59);
            btn_task.TabIndex = 7;
            btn_task.Text = "Daily Task";
            btn_task.TextAlign = ContentAlignment.MiddleLeft;
            btn_task.UseVisualStyleBackColor = true;
            // 
            // txtBx_currentUser
            // 
            txtBx_currentUser.Location = new Point(0, 1063);
            txtBx_currentUser.Margin = new Padding(3, 4, 3, 4);
            txtBx_currentUser.Name = "txtBx_currentUser";
            txtBx_currentUser.Size = new Size(221, 39);
            txtBx_currentUser.TabIndex = 6;
            // 
            // btn_orderHistory
            // 
            btn_orderHistory.Location = new Point(0, 729);
            btn_orderHistory.Margin = new Padding(3, 4, 3, 4);
            btn_orderHistory.Name = "btn_orderHistory";
            btn_orderHistory.Size = new Size(186, 59);
            btn_orderHistory.TabIndex = 5;
            btn_orderHistory.Text = "Order History";
            btn_orderHistory.TextAlign = ContentAlignment.MiddleLeft;
            btn_orderHistory.UseVisualStyleBackColor = true;
            // 
            // btn_preOrderList
            // 
            btn_preOrderList.Location = new Point(0, 663);
            btn_preOrderList.Margin = new Padding(3, 4, 3, 4);
            btn_preOrderList.Name = "btn_preOrderList";
            btn_preOrderList.Size = new Size(186, 59);
            btn_preOrderList.TabIndex = 4;
            btn_preOrderList.Text = "Pre-Order List";
            btn_preOrderList.TextAlign = ContentAlignment.MiddleLeft;
            btn_preOrderList.UseVisualStyleBackColor = true;
            // 
            // btn_productList
            // 
            btn_productList.Location = new Point(0, 596);
            btn_productList.Margin = new Padding(3, 4, 3, 4);
            btn_productList.Name = "btn_productList";
            btn_productList.Size = new Size(186, 59);
            btn_productList.TabIndex = 3;
            btn_productList.Text = "Product List";
            btn_productList.TextAlign = ContentAlignment.MiddleLeft;
            btn_productList.UseVisualStyleBackColor = true;
            // 
            // btn_inventory
            // 
            btn_inventory.Location = new Point(0, 530);
            btn_inventory.Margin = new Padding(3, 4, 3, 4);
            btn_inventory.Name = "btn_inventory";
            btn_inventory.Size = new Size(186, 59);
            btn_inventory.TabIndex = 2;
            btn_inventory.Text = "Inventory";
            btn_inventory.TextAlign = ContentAlignment.MiddleLeft;
            btn_inventory.UseVisualStyleBackColor = true;
            btn_inventory.Click += btn_inventory_Click;
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
            btnCreateOrder.Click += this.btnCreateOrder_Click;
            // 
            // btn_createProduct
            // 
            btn_createProduct.Location = new Point(0, 397);
            btn_createProduct.Margin = new Padding(3, 4, 3, 4);
            btn_createProduct.Name = "btn_createProduct";
            btn_createProduct.Size = new Size(186, 59);
            btn_createProduct.TabIndex = 0;
            btn_createProduct.Text = "Create Product";
            btn_createProduct.TextAlign = ContentAlignment.MiddleLeft;
            btn_createProduct.UseVisualStyleBackColor = true;
            // 
            // StoreMainForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1898, 944);
            Controls.Add(splitContainer_mainInterface);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "StoreMainForm";
            Text = "Store Management";
            Load += Main_Form_Load;
            splitContainer_mainInterface.Panel1.ResumeLayout(false);
            splitContainer_mainInterface.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer_mainInterface).EndInit();
            splitContainer_mainInterface.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox_notificationBell).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer_mainInterface;
        private Button btn_createProduct;
        private Button btn_productList;
        private Button btn_inventory;
        private Button btnCreateOrder;
        private Button btn_orderHistory;
        private Button btn_preOrderList;
        private TextBox txtBx_currentUser;
        private Button btn_task;
        private PictureBox pictureBox_notificationBell;
    }
}
