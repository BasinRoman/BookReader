using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReader.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<bool> Create(T entity);
        Task<bool> Delete(T entity);
        bool Update(T entity);
        Task<T> Get(int id); 
        Task<IEnumerable<T>> Select();
        IQueryable<T> GetAll();


    }
}
