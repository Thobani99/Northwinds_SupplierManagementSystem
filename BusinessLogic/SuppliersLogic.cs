using BusinessLogic.LogicInterfaces;
using DataLogic;
using RepositoryLogic.RepoInterfaces;
using System.Data;

namespace BusinessLogic
{
    public class SuppliersLogic : ISuppliersLogic
    {
        private ISuppliersRepository _suppliersRepo;

        public SuppliersLogic(ISuppliersRepository suppliersRepository) 
        {
            _suppliersRepo = suppliersRepository;
        }

        public DataTable AddSupplier(string CompanyName, string ContactName, string ContactTitle, string Address, string City, string Region, string PostalCode, string Country, string Phone, string Fax)
        {
            var supplier = new Suppliers 
            {
                CompanyName = CompanyName,
                ContactName = ContactName,
                ContactTitle = ContactTitle,
                Address = Address,
                City = City,
                Region = Region,
                PostalCode = PostalCode,
                Country = Country,
                Phone = Phone,
                Fax = Fax
            };
            _suppliersRepo.AddSupplier(supplier);
            return GetSuppliers();
        }

        public DataTable DeleteSupplier(int SupplierId)
        {
            _suppliersRepo.RemoveSupplierById(SupplierId);
            return GetSuppliers();
        }

        public Suppliers GetSupplierBySupplierId(int SupplierId)
        {
            return _suppliersRepo.GetSupplierById(SupplierId);
        }

        public DataTable GetSuppliers() 
        {
           return _suppliersRepo.GetSuppliers();
        }

        public DataTable UpdateSupplier(int SupplierId, string CompanyName, string ContactName, string ContactTitle, string Address, string City, string Region, string PostalCode, string Country, string Phone, string Fax)
        {
            var supplier = new Suppliers 
            {
                SupplierID = SupplierId,
                CompanyName = CompanyName,
                ContactName = ContactName,
                ContactTitle = ContactTitle,
                Address = Address,
                City = City,
                Region = Region,
                PostalCode = PostalCode,
                Country = Country,
                Phone = Phone,
                Fax = Fax
            };
            _suppliersRepo.UpdateSupplier(supplier);
            return GetSuppliers();
        }
    }
}
