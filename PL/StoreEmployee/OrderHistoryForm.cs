﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;
using DTO.SalesOrder;

namespace PL.StoreEmployee
{
    public partial class OrderHistoryForm : Form
    {
        private static OrderHistoryForm? _instance;
        private static readonly object _lock = new object();

        private OrderHistoryForm()
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
                        _instance = new OrderHistoryForm();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }

        public static OrderHistoryForm Instance
        {
            get
            {
                if (_instance == null)
                {
                    throw new InvalidOperationException("OrderHistoryForm is not initialized. Call Initialize() first.");
                }

                return _instance;
            }
        }
    }
}