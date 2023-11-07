using DataLogic;
using RepositoryLogic.RepoInterfaces;
using System.Data;
using System.Data.SqlClient;

namespace RepositoryLogic.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private IDBConnection _IDBConnection;

        public OrdersRepository(IDBConnection connection)
        {
            _IDBConnection = connection;
        }

        public DataTable GetOrdersFromAView()
        {
            DataTable Orders = new DataTable();

            const string query = "SELECT  [OrderID]  ,[CustomerID]  ,[EmployeeID]  ,[OrderDate]  ,[RequiredDate]  ,[ShippedDate] ,[ShipName] ,[ShipAddress] ,[ShipCity]  ,[ShipPostalCode] ,[ShipCountry]  ,[CompanyName]  ,[Address] ,[City] ,[PostalCode] ,[Country] FROM [Orders Qry]";
            var sqlCommand = _IDBConnection.GetSqlCommandText(query);

            using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand))
            {
                adapter.Fill(Orders);
            }

            _IDBConnection.CloseSqlConnection();

            return Orders;
        }
    }
}
