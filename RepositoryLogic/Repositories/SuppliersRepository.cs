using DataLogic;
using RepositoryLogic.RepoInterfaces;
using System.Data;
using System.Data.SqlClient;

namespace RepositoryLogic.Repositories
{
    public class SuppliersRepository : ISuppliersRepository
    {
        private IDBConnection _IDBConnection;

        public SuppliersRepository(IDBConnection IDBConnection)
        {
            _IDBConnection = IDBConnection;
        }

        public void AddSupplier(Suppliers suppliers)
        {
            const string sqlStoredProcedureName = "AddSupplier";
            var cmd = _IDBConnection.GetSqlCommandStoredProcedure(sqlStoredProcedureName);

            cmd.Parameters.Add(new SqlParameter("@CompanyName", SqlDbType.VarChar, 40) { Value = suppliers.CompanyName  });
            cmd.Parameters.Add(new SqlParameter("@ContactName", SqlDbType.VarChar, 30) { Value = suppliers.ContactName });
            cmd.Parameters.Add(new SqlParameter("@ContactTitle", SqlDbType.VarChar, 30) { Value = suppliers.ContactTitle });
            cmd.Parameters.Add(new SqlParameter("@Address", SqlDbType.VarChar, 60) { Value = suppliers.Address });
            cmd.Parameters.Add(new SqlParameter("@City", SqlDbType.VarChar, 15) { Value = suppliers.City });
            cmd.Parameters.Add(new SqlParameter("@Region", SqlDbType.VarChar, 15) { Value = suppliers.Region });
            cmd.Parameters.Add(new SqlParameter("@PostalCode", SqlDbType.VarChar, 10) { Value = suppliers.PostalCode });
            cmd.Parameters.Add(new SqlParameter("@Country", SqlDbType.VarChar, 15) { Value = suppliers.Country });
            cmd.Parameters.Add(new SqlParameter("@Phone", SqlDbType.VarChar, 24) { Value = suppliers.Phone });
            cmd.Parameters.Add(new SqlParameter("@Fax", SqlDbType.VarChar, 24) { Value = suppliers.Fax });

            cmd.ExecuteReader();
            _IDBConnection.CloseSqlConnection();
        }

        public Suppliers GetSupplierById(int supplierId)
        {
            const string query = "SELECT  [SupplierID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [HomePage] FROM [Suppliers] WHERE [SupplierID] = @SupplierID";
            var sqlCommand = _IDBConnection.GetSqlCommandText(query);

            sqlCommand.Parameters.AddWithValue("@SupplierID", supplierId);

            var sqlDataReader = sqlCommand.ExecuteReader();
            var supplier = new Suppliers();

            while (sqlDataReader.Read())
            {
                supplier.SupplierID = sqlDataReader.GetInt32(0);
                supplier.CompanyName = sqlDataReader.GetSqlValue(1).ToString();
                supplier.ContactName = sqlDataReader.GetSqlValue(2).ToString();
                supplier.ContactTitle = sqlDataReader.GetSqlValue(3).ToString();
                supplier.Address = sqlDataReader.GetSqlValue(4).ToString();
                supplier.City = sqlDataReader.GetSqlValue(5).ToString();
                supplier.Region = sqlDataReader.GetSqlValue(6).ToString();
                supplier.PostalCode = sqlDataReader.GetSqlValue(7).ToString();
                supplier.Country = sqlDataReader.GetSqlValue(8).ToString();
                supplier.Phone = sqlDataReader.GetSqlValue(9).ToString();
                supplier.Fax = sqlDataReader.GetSqlValue(10).ToString();

            }

            _IDBConnection.CloseSqlConnection();

            return supplier;
        }

        public DataTable GetSuppliers() 
        { 
            DataTable suppliers = new DataTable();

            const string query = "SELECT  [SupplierID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [HomePage] FROM [Suppliers]";
            var sqlCommand = _IDBConnection.GetSqlCommandText(query);
            
            using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand))
            {
                adapter.Fill(suppliers);
            }

            _IDBConnection.CloseSqlConnection();

            return suppliers;
        }

        public void RemoveSupplierById(int supplierId)
        {
            const string sqlStoredProcedureName = "RemoveSupplierById";
            var cmd = _IDBConnection.GetSqlCommandStoredProcedure(sqlStoredProcedureName);

            cmd.Parameters.Add(new SqlParameter("@SupplierID", SqlDbType.Int) { Value = supplierId });

            cmd.ExecuteReader();
            _IDBConnection.CloseSqlConnection();
        }

        public void UpdateSupplier(Suppliers suppliers)
        {
            const string sqlStoredProcedureName = "UpdateSupplier";
            var cmd = _IDBConnection.GetSqlCommandStoredProcedure(sqlStoredProcedureName);

            cmd.Parameters.Add(new SqlParameter("@SupplierID", SqlDbType.Int) { Value = suppliers.SupplierID  });
            cmd.Parameters.Add(new SqlParameter("@CompanyName", SqlDbType.VarChar, 40) { Value = suppliers.CompanyName  });
            cmd.Parameters.Add(new SqlParameter("@ContactName", SqlDbType.VarChar, 30) { Value = suppliers.ContactName });
            cmd.Parameters.Add(new SqlParameter("@ContactTitle", SqlDbType.VarChar, 30) { Value = suppliers.ContactTitle });
            cmd.Parameters.Add(new SqlParameter("@Address", SqlDbType.VarChar, 60) { Value = suppliers.Address });
            cmd.Parameters.Add(new SqlParameter("@City", SqlDbType.VarChar, 15) { Value = suppliers.City });
            cmd.Parameters.Add(new SqlParameter("@Region", SqlDbType.VarChar, 15) { Value = suppliers.Region });
            cmd.Parameters.Add(new SqlParameter("@PostalCode", SqlDbType.VarChar, 10) { Value = suppliers.PostalCode });
            cmd.Parameters.Add(new SqlParameter("@Country", SqlDbType.VarChar, 15) { Value = suppliers.Country });
            cmd.Parameters.Add(new SqlParameter("@Phone", SqlDbType.VarChar, 24) { Value = suppliers.Phone });
            cmd.Parameters.Add(new SqlParameter("@Fax", SqlDbType.VarChar, 24) { Value = suppliers.Fax });

            cmd.ExecuteReader();
            _IDBConnection.CloseSqlConnection();
        }
    }
}
