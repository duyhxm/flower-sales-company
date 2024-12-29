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
    public partial class DailyTaskForm : Form
    {
        private static  DailyTaskForm? _instance;
        private static readonly object _lock = new object();
        public DailyTaskForm()
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
                        _instance = new DailyTaskForm();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }

        public static DailyTaskForm Instance
        {
            get
            {
                if (_instance == null)
                {
                    throw new InvalidOperationException("DailyTaskForm is not initialized. Call Initialize() first.");
                }

                return _instance;
            }
        }
    }
}
