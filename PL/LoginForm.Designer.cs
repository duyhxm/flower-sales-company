namespace PL
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            lblUsername = new Label();
            lblPassword = new Label();
            btnLogin = new Button();
            txtBxUsername = new TextBox();
            txtBxPassword = new TextBox();
            lblInvalidCredential = new Label();
            SuspendLayout();
            // 
            // lblUsername
            // 
            resources.ApplyResources(lblUsername, "lblUsername");
            lblUsername.ForeColor = Color.Black;
            lblUsername.Name = "lblUsername";
            // 
            // lblPassword
            // 
            resources.ApplyResources(lblPassword, "lblPassword");
            lblPassword.Name = "lblPassword";
            // 
            // btnLogin
            // 
            resources.ApplyResources(btnLogin, "btnLogin");
            btnLogin.Name = "btnLogin";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtBxUsername
            // 
            resources.ApplyResources(txtBxUsername, "txtBxUsername");
            txtBxUsername.Name = "txtBxUsername";
            txtBxUsername.TextChanged += txtBxUsername_TextChanged;
            // 
            // txtBxPassword
            // 
            resources.ApplyResources(txtBxPassword, "txtBxPassword");
            txtBxPassword.Name = "txtBxPassword";
            txtBxPassword.TextChanged += txtBxPassword_TextChanged;
            // 
            // lblInvalidCredential
            // 
            resources.ApplyResources(lblInvalidCredential, "lblInvalidCredential");
            lblInvalidCredential.ForeColor = Color.Red;
            lblInvalidCredential.Name = "lblInvalidCredential";
            // 
            // LoginForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblInvalidCredential);
            Controls.Add(txtBxPassword);
            Controls.Add(txtBxUsername);
            Controls.Add(btnLogin);
            Controls.Add(lblPassword);
            Controls.Add(lblUsername);
            Name = "LoginForm";
            FormClosing += LoginForm_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUsername;
        private Label lblPassword;
        private Button btnLogin;
        private TextBox txtBxUsername;
        private TextBox txtBxPassword;
        private Label lblInvalidCredential;
    }
}