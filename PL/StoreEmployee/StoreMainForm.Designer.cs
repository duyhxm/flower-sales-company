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
            btnAccountInformation = new Button();
            picBoxNotificationBell = new PictureBox();
            btnDailyTask = new Button();
            txtBx_currentUser = new TextBox();
            btnOrderHistory = new Button();
            btnProductList = new Button();
            btnInventory = new Button();
            btnCreateOrder = new Button();
            btnCreateProduct = new Button();
            ((System.ComponentModel.ISupportInitialize)splConStoreMainForm).BeginInit();
            splConStoreMainForm.Panel1.SuspendLayout();
            splConStoreMainForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picBoxNotificationBell).BeginInit();
            SuspendLayout();
            // 
            // splConStoreMainForm
            // 
            resources.ApplyResources(splConStoreMainForm, "splConStoreMainForm");
            splConStoreMainForm.Name = "splConStoreMainForm";
            // 
            // splConStoreMainForm.Panel1
            // 
            splConStoreMainForm.Panel1.BackColor = SystemColors.ActiveCaption;
            splConStoreMainForm.Panel1.Controls.Add(btnAccountInformation);
            splConStoreMainForm.Panel1.Controls.Add(picBoxNotificationBell);
            splConStoreMainForm.Panel1.Controls.Add(btnDailyTask);
            splConStoreMainForm.Panel1.Controls.Add(txtBx_currentUser);
            splConStoreMainForm.Panel1.Controls.Add(btnOrderHistory);
            splConStoreMainForm.Panel1.Controls.Add(btnProductList);
            splConStoreMainForm.Panel1.Controls.Add(btnInventory);
            splConStoreMainForm.Panel1.Controls.Add(btnCreateOrder);
            splConStoreMainForm.Panel1.Controls.Add(btnCreateProduct);
            // 
            // btnAccountInformation
            // 
            resources.ApplyResources(btnAccountInformation, "btnAccountInformation");
            btnAccountInformation.Name = "btnAccountInformation";
            btnAccountInformation.UseVisualStyleBackColor = true;
            btnAccountInformation.Click += btnAccountInformation_Click;
            // 
            // picBoxNotificationBell
            // 
            resources.ApplyResources(picBoxNotificationBell, "picBoxNotificationBell");
            picBoxNotificationBell.Name = "picBoxNotificationBell";
            picBoxNotificationBell.TabStop = false;
            // 
            // btnDailyTask
            // 
            resources.ApplyResources(btnDailyTask, "btnDailyTask");
            btnDailyTask.Name = "btnDailyTask";
            btnDailyTask.UseVisualStyleBackColor = true;
            btnDailyTask.Click += btnDailyTask_Click;
            // 
            // txtBx_currentUser
            // 
            resources.ApplyResources(txtBx_currentUser, "txtBx_currentUser");
            txtBx_currentUser.Name = "txtBx_currentUser";
            // 
            // btnOrderHistory
            // 
            resources.ApplyResources(btnOrderHistory, "btnOrderHistory");
            btnOrderHistory.Name = "btnOrderHistory";
            btnOrderHistory.UseVisualStyleBackColor = true;
            btnOrderHistory.Click += btnOrderHistory_Click;
            // 
            // btnProductList
            // 
            resources.ApplyResources(btnProductList, "btnProductList");
            btnProductList.Name = "btnProductList";
            btnProductList.UseVisualStyleBackColor = true;
            btnProductList.Click += btnProductList_Click;
            // 
            // btnInventory
            // 
            resources.ApplyResources(btnInventory, "btnInventory");
            btnInventory.Name = "btnInventory";
            btnInventory.UseVisualStyleBackColor = true;
            btnInventory.Click += btnInventory_Click;
            // 
            // btnCreateOrder
            // 
            resources.ApplyResources(btnCreateOrder, "btnCreateOrder");
            btnCreateOrder.Name = "btnCreateOrder";
            btnCreateOrder.UseVisualStyleBackColor = true;
            btnCreateOrder.Click += btnCreateOrder_Click;
            // 
            // btnCreateProduct
            // 
            resources.ApplyResources(btnCreateProduct, "btnCreateProduct");
            btnCreateProduct.Name = "btnCreateProduct";
            btnCreateProduct.UseVisualStyleBackColor = true;
            btnCreateProduct.Click += btnCreateProduct_Click;
            // 
            // StoreMainForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splConStoreMainForm);
            Name = "StoreMainForm";
            WindowState = FormWindowState.Maximized;
            FormClosing += StoreMainForm_FormClosing;
            Load += StoreMainForm_Load;
            splConStoreMainForm.Panel1.ResumeLayout(false);
            splConStoreMainForm.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splConStoreMainForm).EndInit();
            splConStoreMainForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picBoxNotificationBell).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splConStoreMainForm;
        private Button btnCreateProduct;
        private Button btnProductList;
        private Button btnInventory;
        private Button btnCreateOrder;
        private Button btnOrderHistory;
        private TextBox txtBx_currentUser;
        private Button btnDailyTask;
        private PictureBox picBoxNotificationBell;
        private Button btnAccountInformation;
    }
}
