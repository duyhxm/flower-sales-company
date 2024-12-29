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
    public partial class PreorderListForm : Form
    {
        private static PreorderListForm? _instance;
        private static readonly object _lock = new object();
        private PreorderListForm()
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
                        _instance = new PreorderListForm();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }

        public static PreorderListForm Instance
        {
            get
            {
                if (_instance == null)
                {
                    throw new InvalidOperationException("PreoderListForm is not initialized. Call Initialize() first.");
                }

                return _instance;
            }
        }
    }
}
