using BusinessLogic;
using BusinessLogic.LogicInterfaces;
using DataLogic;
using RepositoryLogic.Repositories;

namespace NorthwindSupplierManagementSystem
{
    public partial class CustomersList : Form
    {
        private Login _login;
        private ICustomersLogic _customersLogic;

        public CustomersList(Login login)
        {
            InitializeComponent();
            _login = login;
            _customersLogic = new CustomersLogic(new CustomersRepository(new DBConnection()));

            dataGridView1.DataSource = _customersLogic.GetAllCustomers();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _login.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DashBoard dashBoard = new DashBoard(_login);
            dashBoard.Show();
            this.Hide();
        }

        private void CustomersList_Load(object sender, EventArgs e)
        {

        }
    }
}
