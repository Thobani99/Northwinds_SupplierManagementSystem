using DataLogic;
using System.Data;

namespace RepositoryLogic.RepoInterfaces
{
    public interface ISuppliersRepository
    {
        DataTable GetSuppliers();

        void AddSupplier(Suppliers suppliers);

        void UpdateSupplier(Suppliers suppliers);

        void RemoveSupplierById(int supplierId);

        Suppliers GetSupplierById(int supplierId);

    }
}
