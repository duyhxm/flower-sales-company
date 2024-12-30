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

    /*Ở form này, mình sẽ thực hiện chức năng phân phối vật liệu cho các cửa hàng. Mình sẽ có 3 tab chính là PurchaseOrder, Accessory và Flower. Tab PurchaseOrder để load các đơn hàng đã nhập về. Sử dụng DataGridView để hiển thị dữ liệu. 
    các bảng mình cần tương tác bao gồm: PurchaseOrder, DetailedPurchaseOrder, Material,*/ 
    public partial class MaterialDistributionForm : Form
    {
        //Cấu hình khởi tạo đối tượng
        private static MaterialDistributionForm? _instance;
        private static readonly object _lock = new object();


        private MaterialDistributionForm()
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
                        _instance = new MaterialDistributionForm();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        public static MaterialDistributionForm Instance
        {
            get
            {
                if (_instance == null)
                {
                    throw new InvalidOperationException("MaterialDistributionForm is not initialized. Call Initialize() first.");
                }
                return _instance;
            }
        }
    }
}
