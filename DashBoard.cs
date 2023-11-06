using BusinessLogic;
using BusinessLogic.LogicInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
