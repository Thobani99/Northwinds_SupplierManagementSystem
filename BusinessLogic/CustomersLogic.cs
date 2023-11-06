using BusinessLogic.LogicInterfaces;
using RepositoryLogic.RepoInterfaces;
using System.Data;

namespace BusinessLogic
{
    public class CustomersLogic : ICustomersLogic
    {
        private ICustomersRepository _customersRepository;

        public CustomersLogic(ICustomersRepository customersRepository) 
        {
            _customersRepository = customersRepository;
        }

        public DataTable GetAllCustomers()
        {
            return _customersRepository.GetAllCustomers();
        }
    }
}
