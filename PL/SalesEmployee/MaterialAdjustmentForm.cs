using System;
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
    public partial class MaterialAdjustmentForm : Form
    {
        //Cấu hình khởi tạo đối tượng
        private static MaterialAdjustmentForm? _instance;
        private static readonly object _lock = new object();
        private MaterialAdjustmentForm()
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
                        _instance = new MaterialAdjustmentForm();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }

        public static MaterialAdjustmentForm Instance
        {
            get
            {
                if (_instance == null)
                {
                    throw new InvalidOperationException("MaterialAdjustmentForm is not initialized. Call Initialize() first.");
                }
                return _instance;
            }
        }

        private void AddNewColToAdjust(DataGridView dgv)
        {
            DataGridViewColumn newCol = new DataGridViewTextBoxColumn();
            newCol.HeaderText = "New PR";
            newCol.Name = "ColNewFProfitRate";
            newCol.Width = 200;
            newCol.ReadOnly = false;
            dgv.Columns.Add(newCol);
        }

        //Có thể dùng cái này để add cột mới một cách tổng quát hơn
        //private DataGridViewTextBoxColumn AddNewCol(string headerText, string name, int width, bool readOnly)
        //{
            
        //}


    }
}
