using DataLogic;
using RepositoryLogic.RepoInterfaces;
using System.Data.SqlClient;
using System.Data;

namespace RepositoryLogic.Repositories
{
    public class ManagerRepository : IManagerRepository
    {
        private IDBConnection _IDBConnection;

        public ManagerRepository(IDBConnection iDBConnection)
        {
            _IDBConnection = iDBConnection;
        }

        public Managers GetManagerByWorkEmailAndPassword(string workEmail, string password)
        {
            const string sqlStoredProcedureName = "ManagerLogin";
            var cmd = _IDBConnection.GetSqlCommandStoredProcedure(sqlStoredProcedureName);

            cmd.Parameters.Add(new SqlParameter("@WorkEmail", SqlDbType.VarChar, 50) { Value = workEmail });
            cmd.Parameters.Add(new SqlParameter("@Password", SqlDbType.VarChar, 50) { Value = password });

            var sqlDataReader = cmd.ExecuteReader();
            var manager = new Managers();

            while(sqlDataReader.Read())
            {
                manager.ManagerId = sqlDataReader.GetInt32(0);
                manager.EmployeeId = sqlDataReader.GetInt32(1);
                manager.WorkEmail = sqlDataReader.GetString(2);
                manager.Password = sqlDataReader.GetString(3);
            }

            _IDBConnection.CloseSqlConnection();

            return manager;
        }

    }
}
