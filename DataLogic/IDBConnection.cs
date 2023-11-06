using System.Data.SqlClient;

namespace DataLogic
{
    public interface IDBConnection
    {
        SqlConnection OpenSqlConnection();

        void CloseSqlConnection();

        SqlCommand GetSqlCommandText(string sql);

        SqlCommand GetSqlCommandStoredProcedure(string sql);
    }
}
