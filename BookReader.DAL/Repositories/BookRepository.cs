

using BookReader.DAL.Interfaces;
using BookReader.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReader.DAL.Repositories
{
    public class BookRepository : IBookRepository
    {
        public readonly ApplicationDbContext _db;

        public BookRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(Book entity) //Done
        {
            await _db.Book.AddAsync(entity);
            await _db.SaveChangesAsync();
            return true;
        }
         
        public async Task<bool> Delete(Book entity) //Done
        {
            _db.Book.Remove(entity);  
            _db.SaveChangesAsync(); 
            return true;
        }

        public async Task<Book> Get(int id) // Why do I even need this.. 
        {
            throw new NotImplementedException();
        }

        public IQueryable<Book> GetAll()
        {
            return _db.Book;
        }

        public async Task<Book> GetById(int id) // Done
        {
            return await _db.Book.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Book> GetByTitle(string title) //Done
        {
            return await _db.Book.FirstOrDefaultAsync(x => x.Title == title);
        }

        public async Task<IEnumerable<Book>> Select() //Done
        {
            return await _db.Book.ToListAsync();
        }

        public bool Update(Book entity) //will finish later
        {
            throw new NotImplementedException();
        }
    }
}
