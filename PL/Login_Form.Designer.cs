namespace PL
{
    partial class Login_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login_Form));
            lbl_username = new Label();
            lbl_password = new Label();
            btn_login = new Button();
            txtBx_username = new TextBox();
            txtBx_password = new TextBox();
            SuspendLayout();
            // 
            // lbl_username
            // 
            resources.ApplyResources(lbl_username, "lbl_username");
            lbl_username.ForeColor = Color.Black;
            lbl_username.Name = "lbl_username";
            // 
            // lbl_password
            // 
            resources.ApplyResources(lbl_password, "lbl_password");
            lbl_password.Name = "lbl_password";
            // 
            // btn_login
            // 
            resources.ApplyResources(btn_login, "btn_login");
            btn_login.Name = "btn_login";
            btn_login.UseVisualStyleBackColor = true;
            // 
            // txtBx_username
            // 
            resources.ApplyResources(txtBx_username, "txtBx_username");
            txtBx_username.Name = "txtBx_username";
            // 
            // txtBx_password
            // 
            resources.ApplyResources(txtBx_password, "txtBx_password");
            txtBx_password.Name = "txtBx_password";
            // 
            // Login_Form
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(txtBx_password);
            Controls.Add(txtBx_username);
            Controls.Add(btn_login);
            Controls.Add(lbl_password);
            Controls.Add(lbl_username);
            Name = "Login_Form";
            Load += Login_Form_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_username;
        private Label lbl_password;
        private Button btn_login;
        private TextBox txtBx_username;
        private TextBox txtBx_password;
    }
}