using BusinessLogic.LogicInterfaces;
using DataLogic;
using RepositoryLogic.RepoInterfaces;
using System.Data;

namespace BusinessLogic
{
    public class ProductsLogic : IProductsLogic
    {
        private IProductsRepository _productsRepo;

        public ProductsLogic(IProductsRepository productsRepository) 
        {
            _productsRepo = productsRepository;
        }

        public void AddProduct(string ProductName, int SupplierID, int CategoryID, string QuantityPerUnit, decimal UnitPrice, int UnitsInStock, int UnitsOnOrder, int ReorderLevel, bool Discontinued)
        {
            var product = new Products 
            {
                ProductName = ProductName,
                SupplierID = SupplierID,
                CategoryID = CategoryID,
                QuantityPerUnit = QuantityPerUnit,
                UnitPrice = UnitPrice,
                UnitsInStock = UnitsInStock,
                UnitsOnOrder = UnitsOnOrder,
                ReorderLevel = ReorderLevel,
                Discontinued = Discontinued
            };
            _productsRepo.AddProduct(product);
        }

        public DataTable GetAllProducts()
        {
            return _productsRepo.GetAllProducts();
        }

        public Products GetProductProductByName(string productName)
        {
            return _productsRepo.GetProductProductByName(productName);
        }

        public void UpdateProduct(int ProductId, string ProductName, int SupplierID, int CategoryID, string QuantityPerUnit, decimal UnitPrice, int UnitsInStock, int UnitsOnOrder, int ReorderLevel, bool Discontinued)
        {
            var product = new Products
            {
                ProductID = ProductId,
                ProductName = ProductName,
                SupplierID = SupplierID,
                CategoryID = CategoryID,
                QuantityPerUnit = QuantityPerUnit,
                UnitPrice = UnitPrice,
                UnitsInStock = UnitsInStock,
                UnitsOnOrder = UnitsOnOrder,
                ReorderLevel = ReorderLevel,
                Discontinued = Discontinued
            };
            _productsRepo.UpdateProduct(product);
        }
    }
}
