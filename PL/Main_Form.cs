using BL;

namespace PL
{
    public partial class Main_Form : Form
    {
        public Main_Form()
        {
            InitializeComponent();
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {
            Login_Form loginForm = new Login_Form();
            loginForm.ShowDialog();
            Sales_Form salesForm = new Sales_Form();
            salesForm.ShowDialog();
        }
    }

}
