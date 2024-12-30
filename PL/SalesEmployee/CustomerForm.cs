﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL.SalesEmployee
{
    public partial class CustomerForm : Form
    {
        //Cấu hình khởi tạo đối tượng
        private static CustomerForm? _instance;
        private static readonly object _lock = new object();
        private CustomerForm()
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
                        _instance = new CustomerForm();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }

        public static CustomerForm Instance
        {
            get
            {
                if (_instance == null)
                {
                    throw new InvalidOperationException("CustomerForm is not initialized. Call Initialize() first.");
                }
                return _instance;
            }
        }
    }
}
