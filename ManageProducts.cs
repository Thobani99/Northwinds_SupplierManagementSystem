using BusinessLogic;
using BusinessLogic.LogicInterfaces;
using DataLogic;
using RepositoryLogic.Repositories;
using System;
using System.Drawing;
using System.Net;
using System.Text.RegularExpressions;

namespace NorthwindSupplierManagementSystem
{
    public partial class ManageProducts : Form
    {
        private Login _login;
        private IProductsLogic _productsLogic;
        private ISuppliersLogic _suppliersLogic;
        private ICategoryLogic _categoryLogic;

        private int _ProductID;
        private string _ProductName = string.Empty;
        private int _SupplierID;
        private int _CategoryID;
        private string _QuantityPerUnit = string.Empty;
        private decimal _UnitPrice;
        private int _UnitsInStock;
        private int _UnitsOnOrder;
        private int _ReorderLevel;
        private bool _Discontinued;


        public ManageProducts(Login login)
        {
            InitializeComponent();
            _login = login;
            _productsLogic = new ProductsLogic(new ProductsRepository(new DBConnection()));
            _suppliersLogic = new SuppliersLogic(new SuppliersRepository(new DBConnection()));
            _categoryLogic = new CategoryLogic(new CategoryRepository(new DBConnection()));

            LoadDataGridView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DashBoard dashBoard = new DashBoard(_login);
            dashBoard.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _login.Show();
            this.Hide();
        }

        private void txt_SupplierId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_CategoryID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_UnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow digits, a single decimal point, and the backspace key.
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true; // Block the input.
            }

            // Allow only one decimal point.
            if ((e.KeyChar == '.') && ((TextBox)sender).Text.IndexOf('.') > -1)
            {
                e.Handled = true; // Block the input if a decimal point already exists.
            }
        }

        private void txt_UnitsInStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_UnitsOnOrder_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_ReorderLevel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _ProductName = txt_ProductName.Text;
            _SupplierID = Convert.ToInt32(txt_SupplierId.Text);
            _CategoryID = Convert.ToInt32(txt_CategoryID.Text);
            _QuantityPerUnit = txt_QuantityPerUnit.Text;
            _UnitPrice = Convert.ToDecimal(txt_UnitPrice.Text);
            _UnitsInStock = Convert.ToInt32(txt_UnitsInStock.Text);
            _UnitsOnOrder = Convert.ToInt32(txt_UnitsOnOrder.Text);
            _ReorderLevel = Convert.ToInt32(txt_ReorderLevel.Text);
            _Discontinued = checkBox1.Checked;

            if (_ProductName is null || _ProductName == string.Empty)
            {
                MessageBox.Show("Product Name is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!DoesSupplierExist())
            {
                MessageBox.Show("Invalid supplier Id, check on the suppliers page to get existing supplier Ids.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!_categoryLogic.DoesCategoryExist(_CategoryID))
            {
                MessageBox.Show("Invalid category Id, check on the category page to get existing category Ids.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (DoeProductNameExist())
            {
                MessageBox.Show("Product Name is on the list, try updating the product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                _productsLogic.AddProduct(_ProductName, _SupplierID, _CategoryID, _QuantityPerUnit, _UnitPrice, _UnitsInStock, _UnitsOnOrder, _ReorderLevel, _Discontinued);
                LoadDataGridView();
                MessageBox.Show("Product Added.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var selectProduct = dataGridView1.SelectedRows[0].Cells;
                if (selectProduct is not null)
                {

                    _ProductID = Convert.ToInt32(selectProduct[0].Value);
                    txt_ProductName.Text = selectProduct[1].Value.ToString();
                    txt_SupplierId.Text = selectProduct[2].Value.ToString();
                    txt_CategoryID.Text = selectProduct[3].Value.ToString();
                    txt_QuantityPerUnit.Text = selectProduct[4].Value.ToString();
                    txt_UnitPrice.Text = selectProduct[5].Value.ToString();
                    txt_UnitsInStock.Text = selectProduct[6].Value.ToString();
                    txt_UnitsOnOrder.Text = selectProduct[7].Value.ToString();
                    txt_ReorderLevel.Text = selectProduct[8].Value.ToString();
                    _Discontinued = Convert.ToBoolean(selectProduct[9].Value);
                    checkBox1.Checked = _Discontinued;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some error orrured: " + ex.Message + " - " + ex.Source, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _ProductName = txt_ProductName.Text;
            _SupplierID = Convert.ToInt32(txt_SupplierId.Text);
            _CategoryID = Convert.ToInt32(txt_CategoryID.Text);
            _QuantityPerUnit = txt_QuantityPerUnit.Text;
            _UnitPrice = Convert.ToDecimal(txt_UnitPrice.Text);
            _UnitsInStock = Convert.ToInt32(txt_UnitsInStock.Text);
            _UnitsOnOrder = Convert.ToInt32(txt_UnitsOnOrder.Text);
            _ReorderLevel = Convert.ToInt32(txt_ReorderLevel.Text);
            _Discontinued = checkBox1.Checked;

            if (_ProductID == 0)
            {
                MessageBox.Show("No item selected to be updated.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!DoesSupplierExist())
            {
                MessageBox.Show("Invalid supplier Id, check on the suppliers page to get existing supplier Ids.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!_categoryLogic.DoesCategoryExist(_CategoryID))
            {
                MessageBox.Show("Invalid category Id, check on the category page to get existing category Ids.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                _productsLogic.UpdateProduct(_ProductID, _ProductName, _SupplierID, _CategoryID, _QuantityPerUnit, _UnitPrice, _UnitsInStock, _UnitsOnOrder, _ReorderLevel, _Discontinued);
                LoadDataGridView();
                MessageBox.Show("Product Updated.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ClearInputBoxesAndDataGrid()
        {
            checkBox1.Checked = false;
            dataGridView1.DataSource = null;
            txt_UnitPrice.Text = string.Empty;
            txt_UnitsInStock.Text = string.Empty;
            txt_UnitsOnOrder.Text = string.Empty;
            txt_SupplierId.Text = string.Empty;
            txt_ProductName.Text = string.Empty;
            txt_CategoryID.Text = string.Empty;
            txt_QuantityPerUnit.Text = string.Empty;
            txt_ReorderLevel.Text = string.Empty;

            _ProductID = 0;
            _ProductName = txt_ProductName.Text;
            _SupplierID = 0;
            _CategoryID = 0;
            _QuantityPerUnit = txt_QuantityPerUnit.Text;
            _UnitPrice = 0;
            _UnitsInStock = 0;
            _UnitsOnOrder = 0;
            _ReorderLevel = 0;
            _Discontinued = checkBox1.Checked;
        }

        private void LoadDataGridView() 
        {
            ClearInputBoxesAndDataGrid();
            dataGridView1.DataSource = _productsLogic.GetAllProducts();
        }

        private bool DoesSupplierExist()
        {
            return _suppliersLogic.GetSupplierBySupplierId(_SupplierID).SupplierID == _SupplierID;
        }

        private bool DoeProductNameExist()
        {
            return _productsLogic.GetProductProductByName(_ProductName.Trim()).ProductName == _ProductName;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ManageCategories manageCategories = new ManageCategories(_login);
            manageCategories.Show();
            this.Hide();
        }
    }
}
