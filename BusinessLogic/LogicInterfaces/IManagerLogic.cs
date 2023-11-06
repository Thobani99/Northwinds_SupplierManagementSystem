using DataLogic;

namespace BusinessLogic.LogicInterfaces
{
    public interface IManagerLogic
    {
        Managers GetManagerByEmailAndPassword(string email, string password);

        bool IsValidEmail(string email);

        bool IsValidPassword(string password);
    }
}
