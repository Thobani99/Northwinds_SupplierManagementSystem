using DataLogic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLogic.RepoInterfaces
{
    public interface ICategoryRepository
    {
        DataTable GetAllCategories();

        Categories GetCategoryByCategoryID(int CategoryID);

        Categories GetCategoryByCategoryName(string CategoryName);

        void AddCategory(string CategoryName, string CategoryDescription);

        void UpdateCategory(int CategoryID, string CategoryName, string CategoryDescription);
    }
}
