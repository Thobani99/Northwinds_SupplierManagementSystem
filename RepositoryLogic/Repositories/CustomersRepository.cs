using DataLogic;
using RepositoryLogic.RepoInterfaces;
using System.Data;
using System.Data.SqlClient;

namespace RepositoryLogic.Repositories
{
    public class CustomersRepository : ICustomersRepository
    {
        private IDBConnection _IDBConnection;

        public CustomersRepository( IDBConnection connection) 
        {
            _IDBConnection = connection;
        }

        public DataTable GetAllCustomers()
        {
            DataTable Customers = new DataTable();

            const string query = "SELECT [CustomerID]  ,[CompanyName]  ,[ContactName]  ,[ContactTitle]   ,[Address]  ,[City]   ,[Region]  ,[PostalCode]  ,[Country]  ,[Phone]  ,[Fax] FROM [Customers]";
            var sqlCommand = _IDBConnection.GetSqlCommandText(query);

            using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand))
            {
                adapter.Fill(Customers);
            }

            _IDBConnection.CloseSqlConnection();

            return Customers;
        }
    }
}
