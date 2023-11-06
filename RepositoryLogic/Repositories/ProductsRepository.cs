using RepositoryLogic.RepoInterfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLogic;

namespace RepositoryLogic.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private IDBConnection _IDBConnection;

        public ProductsRepository(IDBConnection iDBConnection)
        {
            _IDBConnection = iDBConnection;
        }

        public void AddProduct(Products product)
        {

            const string sqlStoredProcedureName = "AddProduct";
            var cmd = _IDBConnection.GetSqlCommandStoredProcedure(sqlStoredProcedureName);

            PopulateSqlCommandParam(cmd, product, false);

            cmd.ExecuteReader();
            _IDBConnection.CloseSqlConnection();
        }
        public void UpdateProduct(Products product)
        {
            const string sqlStoredProcedureName = "UpdateProduct";
            var cmd = _IDBConnection.GetSqlCommandStoredProcedure(sqlStoredProcedureName);

            PopulateSqlCommandParam(cmd, product, true);
           
            cmd.ExecuteReader();
            _IDBConnection.CloseSqlConnection();
        }

        private void PopulateSqlCommandParam(SqlCommand cmd, Products product,bool isUpdateProc) 
        {
            if (isUpdateProc)
                cmd.Parameters.Add(new SqlParameter("@ProductID", SqlDbType.VarChar, 40) { Value = product.ProductID });
            cmd.Parameters.Add(new SqlParameter("@ProductName", SqlDbType.VarChar, 40) { Value = product.ProductName });
            cmd.Parameters.Add(new SqlParameter("@SupplierID", SqlDbType.Int) { Value = product.SupplierID });
            cmd.Parameters.Add(new SqlParameter("@CategoryID", SqlDbType.Int) { Value = product.CategoryID });
            cmd.Parameters.Add(new SqlParameter("@QuantityPerUnit", SqlDbType.VarChar, 20) { Value = product.QuantityPerUnit });
            cmd.Parameters.Add(new SqlParameter("@UnitPrice", SqlDbType.Money) { Value = product.UnitPrice });
            cmd.Parameters.Add(new SqlParameter("@UnitsInStock", SqlDbType.Int) { Value = product.UnitsInStock });
            cmd.Parameters.Add(new SqlParameter("@UnitsOnOrder", SqlDbType.Int) { Value = product.UnitsOnOrder });
            cmd.Parameters.Add(new SqlParameter("@ReorderLevel", SqlDbType.Int) { Value = product.ReorderLevel });
            cmd.Parameters.Add(new SqlParameter("@Discontinued", SqlDbType.Bit) { Value = product.Discontinued });
        }


        public DataTable GetAllProducts()
        {
            DataTable suppliers = new DataTable();

            const string query = "SELECT [ProductID], [ProductName] ,[SupplierID] ,[CategoryID] ,[QuantityPerUnit]  ,[UnitPrice] ,[UnitsInStock] ,[UnitsOnOrder] ,[ReorderLevel] ,[Discontinued] FROM [Products]";
            var sqlCommand = _IDBConnection.GetSqlCommandText(query);

            using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand))
            {
                adapter.Fill(suppliers);
            }

            _IDBConnection.CloseSqlConnection();

            return suppliers;
        }

        public Products GetProductProductByName(string productName)
        {
            const string query = "SELECT [ProductID], [ProductName] ,[SupplierID] ,[CategoryID] ,[QuantityPerUnit]  ,[UnitPrice] ,[UnitsInStock] ,[UnitsOnOrder] ,[ReorderLevel] ,[Discontinued] FROM [Products] WHERE [ProductName] = @ProductName";
            var sqlCommand = _IDBConnection.GetSqlCommandText(query);
           
            sqlCommand.Parameters.AddWithValue("@ProductName",  productName );

            var sqlDataReader = sqlCommand.ExecuteReader();
            var product = new Products();

            while (sqlDataReader.Read())
            {
                product.ProductID = sqlDataReader.GetInt32(0);
                product.ProductName = sqlDataReader.GetString(1);
                product.SupplierID = sqlDataReader.GetInt32(2);
                product.CategoryID = sqlDataReader.GetInt32(3);
                product.QuantityPerUnit = sqlDataReader.GetString(4);
                product.UnitPrice = sqlDataReader.GetDecimal(5);
                product.UnitsInStock = sqlDataReader.GetInt16(6);
                product.UnitsOnOrder = sqlDataReader.GetInt16(7);
                product.ReorderLevel = sqlDataReader.GetInt16(8);
                product.Discontinued = sqlDataReader.GetBoolean(9);
            }

            _IDBConnection.CloseSqlConnection();

            return product;
        }

    }
}
