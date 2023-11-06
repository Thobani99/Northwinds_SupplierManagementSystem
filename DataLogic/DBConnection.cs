using BusinessLogic.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataLogic
{
    public class DBConnection : IDBConnection
    {
        //private SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-8GK1SJO;Initial Catalog=Northwind;Integrated Security=True");
        private SqlConnection sqlConnection = new SqlConnection(AppConfig.ConnectionString);

        public SqlConnection OpenSqlConnection() 
        {
            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
            return sqlConnection;
        }

        public SqlCommand GetSqlCommandText(string sql)
        {
            SqlCommand sqlCommand = new SqlCommand(sql, OpenSqlConnection());
            sqlCommand.CommandType = CommandType.Text;
            return sqlCommand;
        }

        public SqlCommand GetSqlCommandStoredProcedure(string sql)
        {
            SqlCommand sqlCommand = new SqlCommand(sql, OpenSqlConnection());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            return sqlCommand;
        }

        public void CloseSqlConnection()
        {
            sqlConnection.Close();
        }
    }
}
