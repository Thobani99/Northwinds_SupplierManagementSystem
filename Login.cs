using BusinessLogic;
using BusinessLogic.LogicInterfaces;
using System.Text.RegularExpressions;

namespace NorthwindSupplierManagementSystem
{
    public partial class Login : Form
    {
        private IManagerLogic _managerLogic;

        public Login(IManagerLogic managerLogic)
        {
            _managerLogic = managerLogic;
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string username = txt_WorkEmail.Text;
            string password = txt_Password.Text;


            DashBoard dashBoard = new DashBoard(this);
            dashBoard.Show();
            txt_Password.Clear();
            this.Hide();

            //if(!_managerLogic.IsValidEmail(username))
            //{
            //    MessageBox.Show("Invalid email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //else if (!_managerLogic.IsValidPassword(password))
            //{
            //    MessageBox.Show("Invalid password. Requires a minimum length of 8 characters, at least one uppercase letter, one lowercase letter, one digit, and one special character.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //else
            //{
            //    var manager = _managerLogic.GetManagerByEmailAndPassword(username, password);

            //    if (manager is not null)
            //    {
            //        if(manager.WorkEmail is null || manager.WorkEmail == string.Empty) 
            //        {
            //            MessageBox.Show("User Not Found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //        else 
            //        {
            //            DashBoard dashBoard = new DashBoard(this);
            //            dashBoard.Show();
            //            txt_Password.Clear();
            //            this.Hide();
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Login failed. Please check your credentials.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
        }

    }
}