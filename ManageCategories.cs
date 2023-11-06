using BusinessLogic;
using BusinessLogic.LogicInterfaces;
using DataLogic;
using RepositoryLogic.Repositories;

namespace NorthwindSupplierManagementSystem
{
    public partial class ManageCategories : Form
    {
        private Login _login;
        private ICategoryLogic _categoryLogic;

        private int _CategoryID;
        private string _CategoryName = string.Empty;
        private string _CategoryDescription = string.Empty;

        public ManageCategories(Login login)
        {
            InitializeComponent();
            _login = login;
            _categoryLogic = new CategoryLogic(new CategoryRepository(new DBConnection()));

            ClearInputsAndPopulateDataGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _login.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DashBoard dashBoard = new DashBoard(_login);
            dashBoard.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _CategoryName = txt_CategoryName.Text;
            _CategoryDescription = txt_CategoryDescription.Text;

            if (_CategoryName is null || _CategoryName == string.Empty)
            {
                MessageBox.Show("Category Name is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (_categoryLogic.DoesCategoryNameExist(_CategoryName.Trim()))
            {
                MessageBox.Show("Category Name is on the list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                _categoryLogic.AddCategory(_CategoryName, _CategoryDescription);
                ClearInputsAndPopulateDataGridView();
                MessageBox.Show("Product Added.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ClearInputsAndPopulateDataGridView()
        {
            dataGridView1.DataSource = null;

            txt_CategoryDescription.Text = string.Empty;
            txt_CategoryName.Text = string.Empty;
            _CategoryID = 0;

            dataGridView1.DataSource = _categoryLogic.GetAllCategories();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var selectCategory = dataGridView1.SelectedRows[0].Cells;
                if (selectCategory is not null)
                {
                    _CategoryID = Convert.ToInt32(selectCategory[0].Value);
                    txt_CategoryName.Text = selectCategory[1].Value.ToString();
                    txt_CategoryDescription.Text = selectCategory[2].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some error orrured: " + ex.Message + " - " + ex.Source, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _CategoryName = txt_CategoryName.Text;
            _CategoryDescription = txt_CategoryDescription.Text;

            if (_CategoryID == 0)
            {
                MessageBox.Show("Select a category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (_CategoryName is null || _CategoryName == string.Empty)
            {
                MessageBox.Show("Category Name is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                _categoryLogic.UpdateCategory(_CategoryID,_CategoryName, _CategoryDescription);
                ClearInputsAndPopulateDataGridView();
                MessageBox.Show("Product Added.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
