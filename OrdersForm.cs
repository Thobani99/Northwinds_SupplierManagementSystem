using BusinessLogic;
using BusinessLogic.LogicInterfaces;
using DataLogic;
using RepositoryLogic.Repositories;

namespace NorthwindSupplierManagementSystem
{
    public partial class OrdersForm : Form
    {
        private Login _login;
        private IOrdersLogic _ordersLogic;

        public OrdersForm(Login login)
        {
            InitializeComponent();
            _login = login;
            _ordersLogic = new OrdersLogic(new OrdersRepository(new DBConnection()));

            dataGridView1.DataSource = _ordersLogic.GetOrdersFromAView();
            dataGridView1.ReadOnly = true;
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
    }
}
