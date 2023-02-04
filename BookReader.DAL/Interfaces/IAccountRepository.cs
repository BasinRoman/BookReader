

using BookReader.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReader.DAL.Interfaces
{
    public interface IAccountRepository : IBaseRepository<User>
    {
    }
}