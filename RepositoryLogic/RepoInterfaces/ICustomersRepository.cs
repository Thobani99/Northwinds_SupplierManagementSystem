using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLogic.RepoInterfaces
{
    public interface ICustomersRepository
    {
        DataTable GetAllCustomers();
    }
}
