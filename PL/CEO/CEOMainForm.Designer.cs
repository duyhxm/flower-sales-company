namespace PL
{
    partial class CEOMainForm
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
            splConStoreMainForm = new SplitContainer();
            btnStatistics = new Button();
            btnAccountInformation = new Button();
            txtBx_currentUser = new TextBox();
            ((System.ComponentModel.ISupportInitialize)splConStoreMainForm).BeginInit();
            splConStoreMainForm.Panel1.SuspendLayout();
            splConStoreMainForm.SuspendLayout();
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
            splConStoreMainForm.Panel1.Controls.Add(btnStatistics);
            splConStoreMainForm.Panel1.Controls.Add(btnAccountInformation);
            splConStoreMainForm.Panel1.Controls.Add(txtBx_currentUser);
            splConStoreMainForm.Size = new Size(1876, 888);
            splConStoreMainForm.SplitterDistance = 238;
            splConStoreMainForm.TabIndex = 2;
            // 
            // btnStatistics
            // 
            btnStatistics.ImeMode = ImeMode.NoControl;
            btnStatistics.Location = new Point(0, 234);
            btnStatistics.Margin = new Padding(3, 4, 3, 4);
            btnStatistics.Name = "btnStatistics";
            btnStatistics.Size = new Size(186, 59);
            btnStatistics.TabIndex = 10;
            btnStatistics.Text = "Statistics";
            btnStatistics.TextAlign = ContentAlignment.MiddleLeft;
            btnStatistics.UseVisualStyleBackColor = true;
            btnStatistics.Click += btnStatistics_Click;
            // 
            // btnAccountInformation
            // 
            btnAccountInformation.ImeMode = ImeMode.NoControl;
            btnAccountInformation.Location = new Point(0, 300);
            btnAccountInformation.Margin = new Padding(3, 4, 3, 4);
            btnAccountInformation.Name = "btnAccountInformation";
            btnAccountInformation.Size = new Size(186, 59);
            btnAccountInformation.TabIndex = 9;
            btnAccountInformation.Text = "Account";
            btnAccountInformation.TextAlign = ContentAlignment.MiddleLeft;
            btnAccountInformation.UseVisualStyleBackColor = true;
            btnAccountInformation.Click += btnAccountInformation_Click;
            // 
            // txtBx_currentUser
            // 
            txtBx_currentUser.Location = new Point(0, 1063);
            txtBx_currentUser.Margin = new Padding(3, 4, 3, 4);
            txtBx_currentUser.Name = "txtBx_currentUser";
            txtBx_currentUser.Size = new Size(221, 39);
            txtBx_currentUser.TabIndex = 6;
            // 
            // CEOMainForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1876, 888);
            Controls.Add(splConStoreMainForm);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "CEOMainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CEOMainForm";
            WindowState = FormWindowState.Maximized;
            FormClosing += CEOMainForm_FormClosing;
            Load += CEOMainForm_Load;
            splConStoreMainForm.Panel1.ResumeLayout(false);
            splConStoreMainForm.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splConStoreMainForm).EndInit();
            splConStoreMainForm.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splConStoreMainForm;
        private Button btnAccountInformation;
        private TextBox txtBx_currentUser;
        private Button btnStatistics;
    }
}