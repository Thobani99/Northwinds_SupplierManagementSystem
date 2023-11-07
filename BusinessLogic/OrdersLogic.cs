using BusinessLogic.LogicInterfaces;
using RepositoryLogic.RepoInterfaces;
using System.Data;

namespace BusinessLogic
{
    public class OrdersLogic : IOrdersLogic
    {
        private IOrdersRepository _ordersRepository;

        public OrdersLogic(IOrdersRepository ordersRepository) 
        {
            _ordersRepository = ordersRepository;
        }

        public DataTable GetOrdersFromAView()
        {
           return _ordersRepository.GetOrdersFromAView();
        }
    }
}
