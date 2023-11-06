using BusinessLogic.LogicInterfaces;
using DataLogic;
using RepositoryLogic.RepoInterfaces;
using System.Data;
using System.Text.RegularExpressions;

namespace BusinessLogic
{
    public class CategoryLogic : ICategoryLogic
    {
        private ICategoryRepository _categoryRepo;

        public CategoryLogic(ICategoryRepository categoryRepository) 
        {
            _categoryRepo = categoryRepository;
        }

        public void AddCategory(string CategoryName, string CategoryDescription)
        {
            _categoryRepo.AddCategory(CategoryName, CategoryDescription);
        }

        public bool DoesCategoryExist(int CategoryID)
        {
           return GetCategoryByCategoryID(CategoryID).CategoryID == CategoryID;
        }

        public bool DoesCategoryNameExist(string CategoryName)
        {
            return GetCategoryByCategoryName(CategoryName).CategoryName == CategoryName;
        }

        public DataTable GetAllCategories()
        {
           return _categoryRepo.GetAllCategories();
        }

        public Categories GetCategoryByCategoryID(int CategoryID)
        {
            return _categoryRepo.GetCategoryByCategoryID(CategoryID);
        }

        public Categories GetCategoryByCategoryName(string CategoryName)
        {
            return _categoryRepo.GetCategoryByCategoryName(CategoryName);
        }

        public void UpdateCategory(int CategoryID, string CategoryName, string CategoryDescription)
        {
            _categoryRepo.UpdateCategory(CategoryID, CategoryName, CategoryDescription);
        }
    }
}
