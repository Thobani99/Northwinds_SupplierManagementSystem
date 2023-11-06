using DataLogic;
using RepositoryLogic.RepoInterfaces;
using System;
using System.Data;
using System.Data.SqlClient;

namespace RepositoryLogic.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private IDBConnection _IDBConnection;

        public CategoryRepository(IDBConnection dBConnection) 
        {
            _IDBConnection = dBConnection;
        }

        public void AddCategory(string CategoryName, string CategoryDescription)
        {
            const string sqlStoredProcedureName = "AddCategory";
            var cmd = _IDBConnection.GetSqlCommandStoredProcedure(sqlStoredProcedureName);

            cmd.Parameters.Add(new SqlParameter("@CategoryName", SqlDbType.VarChar, 15) { Value = CategoryName });
            cmd.Parameters.Add(new SqlParameter("@Description", SqlDbType.NText) { Value = CategoryDescription });

            cmd.ExecuteReader();
            _IDBConnection.CloseSqlConnection();
        }

        public DataTable GetAllCategories()
        {
            DataTable Categories = new DataTable();

            const string query = "SELECT [CategoryID], [CategoryName], [Description] FROM [Categories]";
            var sqlCommand = _IDBConnection.GetSqlCommandText(query);

            using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand))
            {
                adapter.Fill(Categories);
            }

            _IDBConnection.CloseSqlConnection();

            return Categories;
        }

        public Categories GetCategoryByCategoryID(int CategoryID)
        {
            const string query = "SELECT [CategoryID], [CategoryName], [Description] FROM [Categories] WHERE [CategoryID] = @CategoryID";
            var sqlCommand = _IDBConnection.GetSqlCommandText(query);

            sqlCommand.Parameters.AddWithValue("@CategoryID", CategoryID);

            var sqlDataReader = sqlCommand.ExecuteReader();
            var Categories = new Categories();

            while (sqlDataReader.Read())
            {
                Categories.CategoryID = sqlDataReader.GetInt32(0);
                Categories.CategoryName = sqlDataReader.GetSqlValue(1).ToString();
                Categories.Description = sqlDataReader.GetSqlValue(2).ToString();

            }

            _IDBConnection.CloseSqlConnection();

            return Categories;
        }
        
        public Categories GetCategoryByCategoryName(string CategoryName)
        {
            const string query = "SELECT [CategoryID], [CategoryName], [Description] FROM [Categories] WHERE [CategoryName] = @CategoryName";
            var sqlCommand = _IDBConnection.GetSqlCommandText(query);

            sqlCommand.Parameters.AddWithValue("@CategoryName", CategoryName);

            var sqlDataReader = sqlCommand.ExecuteReader();
            var Categories = new Categories();

            while (sqlDataReader.Read())
            {
                Categories.CategoryID = sqlDataReader.GetInt32(0);
                Categories.CategoryName = sqlDataReader.GetSqlValue(1).ToString();
                Categories.Description = sqlDataReader.GetSqlValue(2).ToString();

            }

            _IDBConnection.CloseSqlConnection();

            return Categories;
        }

        public void UpdateCategory(int CategoryID, string CategoryName, string CategoryDescription)
        {
            const string sqlStoredProcedureName = "UpdateCategoryByID";
            var cmd = _IDBConnection.GetSqlCommandStoredProcedure(sqlStoredProcedureName);

            cmd.Parameters.Add(new SqlParameter("@CategorID", SqlDbType.Int) { Value = CategoryID });
            cmd.Parameters.Add(new SqlParameter("@CategoryName", SqlDbType.VarChar, 15) { Value = CategoryName });
            cmd.Parameters.Add(new SqlParameter("@Description", SqlDbType.NText) { Value = CategoryDescription });

            cmd.ExecuteReader();
            _IDBConnection.CloseSqlConnection();
        }
    }
}
