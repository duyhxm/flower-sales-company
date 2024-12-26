namespace PL
{
    partial class AccountInformationForm
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
            lblUsername = new Label();
            lblPassword = new Label();
            lblEmployeeInfomation = new Label();
            lblEmployeeId = new Label();
            lblFullName = new Label();
            lblJobTitle = new Label();
            lblAccountIInformation = new Label();
            txtBxUsername = new TextBox();
            txtBxPassword = new TextBox();
            txtBxEmployeeId = new TextBox();
            txtBxFullName = new TextBox();
            txtBxJobTitle = new TextBox();
            iBtnViewPassword = new FontAwesome.Sharp.IconButton();
            SuspendLayout();
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(106, 151);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(121, 32);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Username";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(106, 195);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(111, 32);
            lblPassword.TabIndex = 1;
            lblPassword.Text = "Password";
            // 
            // lblEmployeeInfomation
            // 
            lblEmployeeInfomation.AutoSize = true;
            lblEmployeeInfomation.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEmployeeInfomation.Location = new Point(69, 295);
            lblEmployeeInfomation.Name = "lblEmployeeInfomation";
            lblEmployeeInfomation.Size = new Size(301, 38);
            lblEmployeeInfomation.TabIndex = 2;
            lblEmployeeInfomation.Text = "Employee Information";
            // 
            // lblEmployeeId
            // 
            lblEmployeeId.AutoSize = true;
            lblEmployeeId.Location = new Point(106, 351);
            lblEmployeeId.Name = "lblEmployeeId";
            lblEmployeeId.Size = new Size(149, 32);
            lblEmployeeId.TabIndex = 3;
            lblEmployeeId.Text = "Employee ID";
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Location = new Point(106, 398);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(123, 32);
            lblFullName.TabIndex = 4;
            lblFullName.Text = "Full Name";
            // 
            // lblJobTitle
            // 
            lblJobTitle.AutoSize = true;
            lblJobTitle.Location = new Point(106, 445);
            lblJobTitle.Name = "lblJobTitle";
            lblJobTitle.Size = new Size(104, 32);
            lblJobTitle.TabIndex = 5;
            lblJobTitle.Text = "Job Title";
            // 
            // lblAccountIInformation
            // 
            lblAccountIInformation.AutoSize = true;
            lblAccountIInformation.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAccountIInformation.Location = new Point(69, 92);
            lblAccountIInformation.Name = "lblAccountIInformation";
            lblAccountIInformation.Size = new Size(280, 38);
            lblAccountIInformation.TabIndex = 6;
            lblAccountIInformation.Text = "Account Information";
            // 
            // txtBxUsername
            // 
            txtBxUsername.BorderStyle = BorderStyle.None;
            txtBxUsername.Enabled = false;
            txtBxUsername.Location = new Point(290, 148);
            txtBxUsername.Name = "txtBxUsername";
            txtBxUsername.Size = new Size(256, 32);
            txtBxUsername.TabIndex = 7;
            // 
            // txtBxPassword
            // 
            txtBxPassword.BorderStyle = BorderStyle.None;
            txtBxPassword.Enabled = false;
            txtBxPassword.Location = new Point(290, 193);
            txtBxPassword.Name = "txtBxPassword";
            txtBxPassword.PasswordChar = '*';
            txtBxPassword.Size = new Size(256, 32);
            txtBxPassword.TabIndex = 8;
            // 
            // txtBxEmployeeId
            // 
            txtBxEmployeeId.BorderStyle = BorderStyle.FixedSingle;
            txtBxEmployeeId.Enabled = false;
            txtBxEmployeeId.Location = new Point(290, 349);
            txtBxEmployeeId.Name = "txtBxEmployeeId";
            txtBxEmployeeId.Size = new Size(256, 39);
            txtBxEmployeeId.TabIndex = 9;
            // 
            // txtBxFullName
            // 
            txtBxFullName.BorderStyle = BorderStyle.FixedSingle;
            txtBxFullName.Enabled = false;
            txtBxFullName.Location = new Point(290, 396);
            txtBxFullName.Name = "txtBxFullName";
            txtBxFullName.Size = new Size(256, 39);
            txtBxFullName.TabIndex = 10;
            // 
            // txtBxJobTitle
            // 
            txtBxJobTitle.BorderStyle = BorderStyle.FixedSingle;
            txtBxJobTitle.Enabled = false;
            txtBxJobTitle.Location = new Point(290, 443);
            txtBxJobTitle.Name = "txtBxJobTitle";
            txtBxJobTitle.Size = new Size(256, 39);
            txtBxJobTitle.TabIndex = 11;
            // 
            // iBtnViewPassword
            // 
            iBtnViewPassword.FlatAppearance.BorderSize = 0;
            iBtnViewPassword.FlatStyle = FlatStyle.Flat;
            iBtnViewPassword.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
            iBtnViewPassword.IconColor = Color.Black;
            iBtnViewPassword.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iBtnViewPassword.IconSize = 24;
            iBtnViewPassword.Location = new Point(547, 194);
            iBtnViewPassword.Name = "iBtnViewPassword";
            iBtnViewPassword.Size = new Size(29, 29);
            iBtnViewPassword.TabIndex = 13;
            iBtnViewPassword.UseVisualStyleBackColor = true;
            iBtnViewPassword.Click += iBtnViewPassword_Click;
            // 
            // AccountInformationForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1040, 576);
            Controls.Add(iBtnViewPassword);
            Controls.Add(txtBxJobTitle);
            Controls.Add(txtBxFullName);
            Controls.Add(txtBxEmployeeId);
            Controls.Add(txtBxPassword);
            Controls.Add(txtBxUsername);
            Controls.Add(lblAccountIInformation);
            Controls.Add(lblJobTitle);
            Controls.Add(lblFullName);
            Controls.Add(lblEmployeeId);
            Controls.Add(lblEmployeeInfomation);
            Controls.Add(lblPassword);
            Controls.Add(lblUsername);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "AccountInformationForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUsername;
        private Label lblPassword;
        private Label lblEmployeeInfomation;
        private Label lblEmployeeId;
        private Label lblFullName;
        private Label lblJobTitle;
        private Label lblAccountIInformation;
        private TextBox txtBxUsername;
        private TextBox txtBxPassword;
        private TextBox txtBxEmployeeId;
        private TextBox txtBxFullName;
        private TextBox txtBxJobTitle;
        private FontAwesome.Sharp.IconButton iBtnViewPassword;
    }
}