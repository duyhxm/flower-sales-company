using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL.StoreEmployee
{
    public partial class ProductListForm : Form
    {
        private static ProductListForm? _instance;
        private static readonly object _lock = new object();
        private ProductListForm()
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
                        _instance = new ProductListForm();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }

        public static ProductListForm Instance
        {
            get
            {
                if (_instance == null)
                {
                    throw new InvalidOperationException("ProductListForm is not initialized. Call Initialize() first.");
                }

                return _instance;
            }
        }
    }
}
