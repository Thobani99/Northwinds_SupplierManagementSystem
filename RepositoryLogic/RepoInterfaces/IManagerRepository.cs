
using DataLogic;

namespace RepositoryLogic.RepoInterfaces
{
    public interface IManagerRepository
    {
        Managers GetManagerByWorkEmailAndPassword(string workEmail, string password);
    }
}
