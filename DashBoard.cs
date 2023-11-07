
namespace NorthwindSupplierManagementSystem
{
    public partial class DashBoard : Form
    {
        private Login _Login;
        public DashBoard(Login login)
        {
            InitializeComponent();
            _Login = login;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _Login.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Suppliers suppliers = new Suppliers(_Login);
            suppliers.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ManageProducts manageProducts = new ManageProducts(_Login);
            manageProducts.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ManageCategories manageCategories = new ManageCategories(_Login);
            manageCategories.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CustomersList customersList = new CustomersList(_Login);
            customersList.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OrdersForm ordersForm = new OrdersForm(_Login);
            ordersForm.Show();
            this.Hide();
        }
    }
}
