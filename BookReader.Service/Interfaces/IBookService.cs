using BookReader.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookReader.Domain.Entity;

namespace BookReader.Service.Interfaces
{
    public interface IBookService
    {
        Task<IBaseResponse<IEnumerable<Book>>> GetAllBooks();
        Task<IBaseResponse<Book>> GetByTitle(string title);
        Task<IBaseResponse<Book>> GetById(int id);
        Task<IBaseResponse<Book>> Delete(int id);
        Task<IBaseResponse<Book>> GetBook(int id);
    }
}
