using BusinessLogic.LogicInterfaces;
using DataLogic;
using RepositoryLogic.RepoInterfaces;
using System.Text.RegularExpressions;

namespace BusinessLogic
{
    public class ManagerLogic : IManagerLogic
    {
        private IManagerRepository _managerRepo;

        public ManagerLogic(IManagerRepository managerRepo) 
        {
            _managerRepo = managerRepo;
        }

        public Managers GetManagerByEmailAndPassword(string email, string password) 
        {
            return _managerRepo.GetManagerByWorkEmailAndPassword(email, password);
        }

        public bool IsValidEmail(string email)
        {
            string pattern = @"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
            return Regex.IsMatch(email, pattern);
        }

        public bool IsValidPassword(string password)
        {
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@#$%^&+=!]).{8,}$";
            return Regex.IsMatch(password, pattern);
        }

    }
}
