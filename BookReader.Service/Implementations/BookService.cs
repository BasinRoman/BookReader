using BookReader.Domain.Response;
using BookReader.Service.Interfaces;
using BookReader.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookReader.DAL.Interfaces;
using BookReader.Domain.Enum;
using System.ComponentModel;
using BookReader.Domain.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace BookReader.Service.Implementations
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _BookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _BookRepository = bookRepository;
        }

        public async Task<IBaseResponse<IEnumerable<Book>>> GetAllBooks()
        {
            var baseResponse = new BaseResponse<IEnumerable<Book>>();
            try
            {
                var books = await _BookRepository.Select();
                if (books.Count() == 0)
                {
                    baseResponse.Description = "No elements found";
                    baseResponse.statusCode = StatusCode.InternatlServiceError;
                    return baseResponse;
                }
                baseResponse.Data = books;
                baseResponse.statusCode = StatusCode.ok;

                return baseResponse;

            }
            catch (Exception ex)
            {

                return new BaseResponse<IEnumerable<Book>>()
                {
                    Description = $"{ex.Message}"
                };
            }
        }

        public async Task<IBaseResponse<Book>> GetById(int id)
        {
            var baseresponse = new BaseResponse<Book>();
            try
            {
                var book = await _BookRepository.GetById(id);
                if (book == null)
                {
                    baseresponse.Description = $"No such book with id : {id}";
                    baseresponse.statusCode = StatusCode.InternatlServiceError;
                    return baseresponse;
                }
                baseresponse.Data = book;
                baseresponse.statusCode = StatusCode.ok;
                return baseresponse;

            }
            catch (Exception ex)
            {
                return new BaseResponse<Book>()
                {
                    Description = $"{ex.Message}"
                };
            }

        }

        public async Task<IBaseResponse<Book>> GetByTitle(string title)
        {
            var baseResponse = new BaseResponse<Book>();
            try
            {
                title = title.Replace("_", " ");
                var book = await _BookRepository.GetByTitle(title);

                if (book == null)
                {
                    baseResponse.Description = $"No such book with title : {title}";
                    baseResponse.statusCode = StatusCode.InternatlServiceError;
                    return baseResponse;
                }
                baseResponse.Data = book;
                baseResponse.statusCode = StatusCode.ok;
                return baseResponse;

            }
            catch (Exception ex)
            {
                return new BaseResponse<Book>()
                {
                    Description = $"{ex.Message}"
                };
            }
        }
        public async Task<IBaseResponse<Book>> Delete(int id)
        {
            var baseResponse = new BaseResponse<Book>();
            var book = await _BookRepository.GetById(id);
            if (book == null)
            {
                baseResponse.statusCode = StatusCode.InternatlServiceError;
                baseResponse.Description = $"There is no such book with id : {id} in DB";
                return baseResponse;
            }

            try
            {
                bool request = await _BookRepository.Delete(book);
                if (!request)
                {
                    baseResponse.statusCode = StatusCode.InternatlServiceError;
                    baseResponse.Description = $"A try to delete book with id {book.Id} and title {book.Title} failed";
                    return baseResponse;
                }
                baseResponse.Data = book;
                baseResponse.Description = $"A try to delete book with id {book.Id} and title {book.Title} succesful";
                baseResponse.statusCode = StatusCode.ok;
                return baseResponse;

            }
            catch (Exception ex)
            {

                return new BaseResponse<Book>
                {
                    Description = ex.Message
                };
            }
        }
        public async Task<IBaseResponse<Book>> Create(BookViewModel bookViewModel)
        {
            var baseResponse = new BaseResponse<Book>();
            try
            {
                var book_to_create = new Book()
                {
                    Author = bookViewModel.Author,
                    AuthorUrl = bookViewModel.AuthorUrl,
                    Title = bookViewModel.Title,
                    Description = bookViewModel.Description,
                    Created = DateTime.Now,
                    Price = bookViewModel.Price
                };

                bool request = await _BookRepository.Create(book_to_create);
                if (!request)
                {
                    baseResponse.statusCode = StatusCode.InternatlServiceError;
                    baseResponse.Description = $"A try to create book with title {book_to_create.Title} failed";
                    return baseResponse;
                }
                baseResponse.Data = book_to_create;
                baseResponse.Description = $"A try to create book with title {book_to_create.Title} succesful";
                baseResponse.statusCode = StatusCode.ok;
                return baseResponse;
            }
            catch (Exception ex)
            {

                return new BaseResponse<Book>
                {
                    Description = ex.Message
                };
            }
        }


        //The way we can use Iquery
        
        public async Task<IBaseResponse<Book>> GetBook(int id)
        {
            var baseResponse = new BaseResponse<Book>();
            try
            {
                var books = await _BookRepository.GetAll().ToListAsync();
                if (books.Count() == 0)
                {
                    baseResponse.Description = "No elements found";
                    baseResponse.statusCode = StatusCode.InternatlServiceError;
                    return baseResponse;
                }
                baseResponse.Data = books[0];
                baseResponse.statusCode = StatusCode.ok;

                return baseResponse;

            }
            catch (Exception ex)
            {

                return new BaseResponse<Book>()
                {
                    Description = $"{ex.Message}"
                };
            }
        }
    }


    
}

