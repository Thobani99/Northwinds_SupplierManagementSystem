﻿using BusinessLogic;
using BusinessLogic.LogicInterfaces;
using DataLogic;
using RepositoryLogic.Repositories;

namespace NorthwindSupplierManagementSystem
{
    public partial class Suppliers : Form
    {
        private Login _login;
        private ISuppliersLogic _suppliersLogic;
        private int _supplierId;
        private string? _CompanyName;
        private string? _ContactName;
        private string? _ContactTitle;
        private string? _Address;
        private string? _City;
        private string? _Region;
        private string? _PostalCode;
        private string? _Country;
        private string? _Phone;
        private string? _Fax;

        public Suppliers(Login login)
        {
            InitializeComponent();

            _login = login;
            _suppliersLogic = new SuppliersLogic(new SuppliersRepository(new DBConnection()));

            LoadDataGridView();
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            _CompanyName = txt_CompanyName.Text;
            _ContactName = txt_ContactName.Text;
            _ContactTitle = txt_ContactTitle.Text;
            _Address = txt_Address.Text;
            _City = txt_City.Text;
            _Region = txt_Region.Text;
            _PostalCode = txt_PostCode.Text;
            _Country = txt_Country.Text;
            _Phone = txt_Phone.Text;
            _Fax = txt_Fax.Text;

            if (_CompanyName is null || _CompanyName == string.Empty)
            {
                MessageBox.Show("Company Name is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (_ContactName is null || _ContactName == string.Empty)
            {
                MessageBox.Show("Contact Name is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                _suppliersLogic.AddSupplier(_CompanyName, _ContactName, _ContactTitle, _Address, _City, _Region, _PostalCode, _Country, _Phone, _Fax);
                LoadDataGridView();
                MessageBox.Show("Supplier Added.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var selectSupplier = dataGridView1.SelectedRows[0].Cells;
                if (selectSupplier is not null)
                {
                    _supplierId = Convert.ToInt32(selectSupplier[0].Value);
                    txt_CompanyName.Text = selectSupplier[1].Value.ToString();
                    txt_ContactName.Text = selectSupplier[2].Value.ToString();
                    txt_ContactTitle.Text = selectSupplier[3].Value.ToString();
                    txt_Address.Text = selectSupplier[4].Value.ToString();
                    txt_City.Text = selectSupplier[5].Value.ToString();
                    txt_Region.Text = selectSupplier[6].Value.ToString();
                    txt_PostCode.Text = selectSupplier[7].Value.ToString();
                    txt_Country.Text = selectSupplier[8].Value.ToString();
                    txt_Phone.Text = selectSupplier[9].Value.ToString();
                    txt_Fax.Text = selectSupplier[10].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some error orrured: " + ex.Message + " - " + ex.Source, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            _CompanyName = txt_CompanyName.Text;
            _ContactName = txt_ContactName.Text;
            _ContactTitle = txt_ContactTitle.Text;
            _Address = txt_Address.Text;
            _City = txt_City.Text;
            _Region = txt_Region.Text;
            _PostalCode = txt_PostCode.Text;
            _Country = txt_Country.Text;
            _Phone = txt_Phone.Text;
            _Fax = txt_Fax.Text;

            if (_CompanyName is null || _CompanyName == string.Empty)
            {
                MessageBox.Show("Company Name is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (_ContactName is null || _ContactName == string.Empty)
            {
                MessageBox.Show("Contact Name is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (_supplierId == 0)
            {
                MessageBox.Show("Ensure you selected a supplier.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                _suppliersLogic.UpdateSupplier(_supplierId, _CompanyName, _ContactName, _ContactTitle, _Address, _City, _Region, _PostalCode, _Country, _Phone, _Fax);
                LoadDataGridView();
                MessageBox.Show("Supplier Updated.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (_supplierId == 0)
            {
                MessageBox.Show("Ensure you selected a supplier.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result = MessageBox.Show("Deleting a supplier will results in some products missing a supplier. \nDo you want to continue?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    _suppliersLogic.DeleteSupplier(_supplierId);
                    MessageBox.Show("Supplier Removed.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                LoadDataGridView();
            }

        }

        private void ClearInputBoxesAndDataGrid()
        {
            _supplierId = 0;
            dataGridView1.DataSource = null;
            txt_CompanyName.Text = string.Empty;
            txt_ContactName.Text = string.Empty;
            txt_ContactTitle.Text = string.Empty;
            txt_Address.Text = string.Empty;
            txt_City.Text = string.Empty;
            txt_Region.Text = string.Empty;
            txt_PostCode.Text = string.Empty;
            txt_Country.Text = string.Empty;
            txt_Phone.Text = string.Empty;
            txt_Fax.Text = string.Empty;
        }

        private void LoadDataGridView()
        {
            ClearInputBoxesAndDataGrid();
            dataGridView1.DataSource = _suppliersLogic.GetSuppliers();
            dataGridView1.ReadOnly = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
    }
}
