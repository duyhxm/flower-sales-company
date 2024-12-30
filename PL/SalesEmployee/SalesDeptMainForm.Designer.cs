namespace PL
{
    partial class SalesDeptMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalesDeptMainForm));
            splConSalesDeptMainForm = new SplitContainer();
            btnInventory = new Button();
            btnAccountInformation = new Button();
            pictureBox_notificationBell = new PictureBox();
            btnCreateMaterialDistribution = new Button();
            txtBx_currentUser = new TextBox();
            btnSalesHistory = new Button();
            btnCustomer = new Button();
            btnCreateProduct = new Button();
            btnAdjustPrice = new Button();
            btnCreateProductPlan = new Button();
            ((System.ComponentModel.ISupportInitialize)splConSalesDeptMainForm).BeginInit();
            splConSalesDeptMainForm.Panel1.SuspendLayout();
            splConSalesDeptMainForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_notificationBell).BeginInit();
            SuspendLayout();
            // 
            // splConSalesDeptMainForm
            // 
            splConSalesDeptMainForm.Dock = DockStyle.Fill;
            splConSalesDeptMainForm.Location = new Point(0, 0);
            splConSalesDeptMainForm.Margin = new Padding(3, 4, 3, 4);
            splConSalesDeptMainForm.Name = "splConSalesDeptMainForm";
            // 
            // splConSalesDeptMainForm.Panel1
            // 
            splConSalesDeptMainForm.Panel1.BackColor = SystemColors.ActiveCaption;
            splConSalesDeptMainForm.Panel1.Controls.Add(btnInventory);
            splConSalesDeptMainForm.Panel1.Controls.Add(btnAccountInformation);
            splConSalesDeptMainForm.Panel1.Controls.Add(pictureBox_notificationBell);
            splConSalesDeptMainForm.Panel1.Controls.Add(btnCreateMaterialDistribution);
            splConSalesDeptMainForm.Panel1.Controls.Add(txtBx_currentUser);
            splConSalesDeptMainForm.Panel1.Controls.Add(btnSalesHistory);
            splConSalesDeptMainForm.Panel1.Controls.Add(btnCustomer);
            splConSalesDeptMainForm.Panel1.Controls.Add(btnCreateProduct);
            splConSalesDeptMainForm.Panel1.Controls.Add(btnAdjustPrice);
            splConSalesDeptMainForm.Panel1.Controls.Add(btnCreateProductPlan);
            splConSalesDeptMainForm.Size = new Size(1876, 888);
            splConSalesDeptMainForm.SplitterDistance = 238;
            splConSalesDeptMainForm.TabIndex = 2;
            // 
            // btnInventory
            // 
            btnInventory.ImeMode = ImeMode.NoControl;
            btnInventory.Location = new Point(0, 382);
            btnInventory.Margin = new Padding(3, 4, 3, 4);
            btnInventory.Name = "btnInventory";
            btnInventory.Size = new Size(186, 59);
            btnInventory.TabIndex = 10;
            btnInventory.Text = "Inventory";
            btnInventory.TextAlign = ContentAlignment.MiddleLeft;
            btnInventory.UseVisualStyleBackColor = true;
            // 
            // btnAccountInformation
            // 
            btnAccountInformation.ImeMode = ImeMode.NoControl;
            btnAccountInformation.Location = new Point(0, 712);
            btnAccountInformation.Margin = new Padding(3, 4, 3, 4);
            btnAccountInformation.Name = "btnAccountInformation";
            btnAccountInformation.Size = new Size(186, 59);
            btnAccountInformation.TabIndex = 9;
            btnAccountInformation.Text = "Account";
            btnAccountInformation.TextAlign = ContentAlignment.MiddleLeft;
            btnAccountInformation.UseVisualStyleBackColor = true;
            btnAccountInformation.Click += btnAccountInformation_Click;
            // 
            // pictureBox_notificationBell
            // 
            pictureBox_notificationBell.BackgroundImage = (Image)resources.GetObject("pictureBox_notificationBell.BackgroundImage");
            pictureBox_notificationBell.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox_notificationBell.ImeMode = ImeMode.NoControl;
            pictureBox_notificationBell.Location = new Point(195, 258);
            pictureBox_notificationBell.Margin = new Padding(3, 4, 3, 4);
            pictureBox_notificationBell.Name = "pictureBox_notificationBell";
            pictureBox_notificationBell.Size = new Size(30, 38);
            pictureBox_notificationBell.TabIndex = 8;
            pictureBox_notificationBell.TabStop = false;
            // 
            // btnCreateMaterialDistribution
            // 
            btnCreateMaterialDistribution.ImeMode = ImeMode.NoControl;
            btnCreateMaterialDistribution.Location = new Point(0, 250);
            btnCreateMaterialDistribution.Margin = new Padding(3, 4, 3, 4);
            btnCreateMaterialDistribution.Name = "btnCreateMaterialDistribution";
            btnCreateMaterialDistribution.Size = new Size(186, 59);
            btnCreateMaterialDistribution.TabIndex = 7;
            btnCreateMaterialDistribution.Text = "Distribution";
            btnCreateMaterialDistribution.TextAlign = ContentAlignment.MiddleLeft;
            btnCreateMaterialDistribution.UseVisualStyleBackColor = true;
            btnCreateMaterialDistribution.Click += btnCreateMaterialDistribution_Click;
            // 
            // txtBx_currentUser
            // 
            txtBx_currentUser.Location = new Point(0, 1063);
            txtBx_currentUser.Margin = new Padding(3, 4, 3, 4);
            txtBx_currentUser.Name = "txtBx_currentUser";
            txtBx_currentUser.Size = new Size(221, 39);
            txtBx_currentUser.TabIndex = 6;
            // 
            // btnSalesHistory
            // 
            btnSalesHistory.ImeMode = ImeMode.NoControl;
            btnSalesHistory.Location = new Point(0, 646);
            btnSalesHistory.Margin = new Padding(3, 4, 3, 4);
            btnSalesHistory.Name = "btnSalesHistory";
            btnSalesHistory.Size = new Size(186, 59);
            btnSalesHistory.TabIndex = 5;
            btnSalesHistory.Text = "Sales History";
            btnSalesHistory.TextAlign = ContentAlignment.MiddleLeft;
            btnSalesHistory.UseVisualStyleBackColor = true;
            btnSalesHistory.Click += btnSalesHistory_Click;
            // 
            // btnCustomer
            // 
            btnCustomer.ImeMode = ImeMode.NoControl;
            btnCustomer.Location = new Point(0, 580);
            btnCustomer.Margin = new Padding(3, 4, 3, 4);
            btnCustomer.Name = "btnCustomer";
            btnCustomer.Size = new Size(186, 59);
            btnCustomer.TabIndex = 4;
            btnCustomer.Text = "Customer";
            btnCustomer.TextAlign = ContentAlignment.MiddleLeft;
            btnCustomer.UseVisualStyleBackColor = true;
            btnCustomer.Click += btnCustomer_Click;
            // 
            // btnCreateProduct
            // 
            btnCreateProduct.ImeMode = ImeMode.NoControl;
            btnCreateProduct.Location = new Point(0, 316);
            btnCreateProduct.Margin = new Padding(3, 4, 3, 4);
            btnCreateProduct.Name = "btnCreateProduct";
            btnCreateProduct.Size = new Size(186, 59);
            btnCreateProduct.TabIndex = 2;
            btnCreateProduct.Text = "Create Product";
            btnCreateProduct.TextAlign = ContentAlignment.MiddleLeft;
            btnCreateProduct.UseVisualStyleBackColor = true;
            btnCreateProduct.Click += btnCreateProduct_Click;
            // 
            // btnAdjustPrice
            // 
            btnAdjustPrice.ImeMode = ImeMode.NoControl;
            btnAdjustPrice.Location = new Point(0, 514);
            btnAdjustPrice.Margin = new Padding(3, 4, 3, 4);
            btnAdjustPrice.Name = "btnAdjustPrice";
            btnAdjustPrice.Size = new Size(186, 59);
            btnAdjustPrice.TabIndex = 1;
            btnAdjustPrice.Text = "Material Adjust";
            btnAdjustPrice.TextAlign = ContentAlignment.MiddleLeft;
            btnAdjustPrice.UseVisualStyleBackColor = true;
            btnAdjustPrice.Click += btnAdjustPrice_Click;
            // 
            // btnCreateProductPlan
            // 
            btnCreateProductPlan.ImeMode = ImeMode.NoControl;
            btnCreateProductPlan.Location = new Point(0, 448);
            btnCreateProductPlan.Margin = new Padding(3, 4, 3, 4);
            btnCreateProductPlan.Name = "btnCreateProductPlan";
            btnCreateProductPlan.Size = new Size(186, 59);
            btnCreateProductPlan.TabIndex = 0;
            btnCreateProductPlan.Text = "Product Plan";
            btnCreateProductPlan.TextAlign = ContentAlignment.MiddleLeft;
            btnCreateProductPlan.UseVisualStyleBackColor = true;
            btnCreateProductPlan.Click += btnCreateProductPlan_Click;
            // 
            // SalesDeptMainForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1876, 888);
            Controls.Add(splConSalesDeptMainForm);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "SalesDeptMainForm";
            Text = "SalesDepartmentMainForm";
            WindowState = FormWindowState.Maximized;
            FormClosing += SalesDepartmentMainForm_FormClosing;
            Load += SalesDepartmentMainForm_Load;
            splConSalesDeptMainForm.Panel1.ResumeLayout(false);
            splConSalesDeptMainForm.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splConSalesDeptMainForm).EndInit();
            splConSalesDeptMainForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox_notificationBell).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splConSalesDeptMainForm;
        private Button btnAccountInformation;
        private PictureBox pictureBox_notificationBell;
        private Button btnCreateMaterialDistribution;
        private TextBox txtBx_currentUser;
        private Button btnSalesHistory;
        private Button btnCustomer;
        private Button btnCreateProduct;
        private Button btnAdjustPrice;
        private Button btnCreateProductPlan;
        private Button btnInventory;
    }
}