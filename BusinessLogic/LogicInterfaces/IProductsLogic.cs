using DataLogic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.LogicInterfaces
{
    public interface IProductsLogic
    {
        DataTable GetAllProducts();

        void AddProduct(string ProductName, int SupplierID, int CategoryID, string QuantityPerUnit, decimal UnitPrice, int UnitsInStock, int UnitsOnOrder, int ReorderLevel, bool Discontinued);

        Products GetProductProductByName(string productName);

        void UpdateProduct(int ProductId, string ProductName, int SupplierID, int CategoryID, string QuantityPerUnit, decimal UnitPrice, int UnitsInStock, int UnitsOnOrder, int ReorderLevel, bool Discontinued);
    }
}
