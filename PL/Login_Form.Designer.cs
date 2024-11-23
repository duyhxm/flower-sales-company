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
            lbl_username = new Label();
            lbl_password = new Label();
            btn_login = new Button();
            txtBx_username = new TextBox();
            txtBx_password = new TextBox();
            SuspendLayout();
            // 
            // lbl_username
            // 
            lbl_username.AutoSize = true;
            lbl_username.Font = new Font("Arial", 12F);
            lbl_username.ForeColor = Color.Black;
            lbl_username.Location = new Point(96, 171);
            lbl_username.Name = "lbl_username";
            lbl_username.Size = new Size(122, 27);
            lbl_username.TabIndex = 0;
            lbl_username.Text = "Username";
            // 
            // lbl_password
            // 
            lbl_password.AutoSize = true;
            lbl_password.Font = new Font("Arial", 12F);
            lbl_password.Location = new Point(96, 226);
            lbl_password.Name = "lbl_password";
            lbl_password.Size = new Size(117, 27);
            lbl_password.TabIndex = 1;
            lbl_password.Text = "Password";
            // 
            // btn_login
            // 
            btn_login.Location = new Point(261, 307);
            btn_login.Name = "btn_login";
            btn_login.Size = new Size(158, 46);
            btn_login.TabIndex = 2;
            btn_login.Text = "Login";
            btn_login.UseVisualStyleBackColor = true;
            // 
            // txtBx_username
            // 
            txtBx_username.Location = new Point(244, 164);
            txtBx_username.Name = "txtBx_username";
            txtBx_username.Size = new Size(339, 40);
            txtBx_username.TabIndex = 3;
            // 
            // txtBx_password
            // 
            txtBx_password.Location = new Point(244, 219);
            txtBx_password.Name = "txtBx_password";
            txtBx_password.Size = new Size(339, 40);
            txtBx_password.TabIndex = 4;
            // 
            // Login_Form
            // 
            AutoScaleDimensions = new SizeF(16F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(678, 576);
            Controls.Add(txtBx_password);
            Controls.Add(txtBx_username);
            Controls.Add(btn_login);
            Controls.Add(lbl_password);
            Controls.Add(lbl_username);
            Font = new Font("Arial", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "Login_Form";
            Text = "Login_Form";
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