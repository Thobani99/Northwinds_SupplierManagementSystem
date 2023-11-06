using DataLogic;
using System.Data;

namespace RepositoryLogic.RepoInterfaces
{
    public interface IProductsRepository
    {
        DataTable GetAllProducts();

        void AddProduct(Products product);

        Products GetProductProductByName(string productName);

        void UpdateProduct(Products product);

    }
}
