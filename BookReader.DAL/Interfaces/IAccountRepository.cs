

using BookReader.Domain.Entity;
using BookReader.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReader.DAL.Interfaces
{
    public interface IAccountRepository : IBaseRepository<User>
    {
        Task<bool> IfLoginExist(string loginName);
        Task<User> LoginTry(LoginViewModel loginViewModel);
    }
}