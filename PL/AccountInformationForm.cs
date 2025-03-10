﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using DTO.Employee;

namespace PL
{
    public partial class AccountInformationForm : System.Windows.Forms.Form
    {
        //Cấu hình khởi tạo đối tượng
        private static AccountInformationForm? _instance;
        private static readonly object _lock = new object();
        private AccountInformationForm()
        {
            InitializeComponent();
        }

        public static void Initialize()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    try
                    {
                        _instance = new AccountInformationForm();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }

        public static AccountInformationForm Instance
        {
            get
            {
                if (_instance == null)
                {
                    throw new InvalidOperationException("AccountInformationForm is not initialized. Call Initialize() first.");
                }
                return _instance;
            }
        }

        public void DisplayInformation(LoginInformation loginInformation)
        {
            try
            {
                string fullName = $"{loginInformation.UserAccount.Employee?.LastName} {loginInformation.UserAccount.Employee?.MiddleName} {loginInformation.UserAccount.Employee?.FirstName}";

                txtBxUsername.Text = loginInformation.UserAccount.Username;
                txtBxPassword.Text = loginInformation.UserAccount.Password;
                txtBxEmployeeId.Text = loginInformation.UserAccount.EmployeeId;
                txtBxFullName.Text = fullName;
                txtBxJobTitle.Text = loginInformation.JobTitle;
            }
            catch (Exception e)
            {
                MessageBox.Show($"Message: {e.Message}");
            }

        }

        private void iBtnViewPassword_Click(object sender, EventArgs e)
        {
            if (txtBxPassword.PasswordChar == '*')
            {
                iBtnViewPassword.IconChar = FontAwesome.Sharp.IconChar.Eye;
                txtBxPassword.PasswordChar = '\0';
            }
            else
            {
                iBtnViewPassword.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
                txtBxPassword.PasswordChar = '*';
            }
        }
    }
}
