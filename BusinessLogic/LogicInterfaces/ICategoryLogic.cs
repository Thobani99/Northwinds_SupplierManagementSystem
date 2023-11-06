using DataLogic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.LogicInterfaces
{
    public interface ICategoryLogic
    {
        DataTable GetAllCategories();

        Categories GetCategoryByCategoryID(int CategoryID);

        Categories GetCategoryByCategoryName(string CategoryName);

        void AddCategory(string CategoryName, string CategoryDescription);

        void UpdateCategory(int CategoryID, string CategoryName, string CategoryDescription);

        bool DoesCategoryNameExist(string CategoryName);

        bool DoesCategoryExist(int  CategoryID);
    }
}
