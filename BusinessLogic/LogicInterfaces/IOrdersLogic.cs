using System.Data;

namespace BusinessLogic.LogicInterfaces
{
    public interface IOrdersLogic
    {
        DataTable GetOrdersFromAView();
    }
}
