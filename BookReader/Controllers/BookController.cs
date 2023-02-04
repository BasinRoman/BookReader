using BookReader.DAL.Interfaces;
using BookReader.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookReader.Controllers
{
    public class BookController : Controller
    {
        //private readonly IBookRepository bookRepository;

        //public BookController(IBookRepository bookRepository)
        //{
        //    this.bookRepository = bookRepository;
        //} 

        //public IActionResult GetAllBooks() //https://localhost:7138/Book/GetAllBooks
        //{
        //    var response = bookRepository.Select();
        //    return View(response);
        //}

        //public async Task<IActionResult> GetBookById(int id) //https://localhost:7138/Book/GetBookById?id=1
        //{
        //    var response = await bookRepository.GetById(id);

        //    return View(response);
        //}

        private readonly IBookService bookService;
        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        public async  Task<IActionResult> GetAllBooks() // https://localhost:7138/Book/GetAllBooks
        {
            var respone = await bookService.GetAllBooks();
            return View(respone.Data);
        }

        [HttpGet]
        public async Task<IActionResult> GetByTitle(string title) // https://localhost:7138/Book/GetByTitle?title=TEST_BOOK
        {
            var response = await bookService.GetByTitle(title);
            if (response.statusCode == Domain.Enum.StatusCode.ok ) 
            {
                return View(response.Data);
            }
            else
            {
                TempData["Error"] = response.Description;
                return RedirectToAction("Error");
            }
            
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id) // https://localhost:7138/Book/GetById?id=2
        {
            var response = await bookService.GetById(id);
            if (response.statusCode == Domain.Enum.StatusCode.ok)
            {
                return View(response.Data);
            }
            else
            {
                TempData["Error"] = response.Description;
                return RedirectToAction("Error");
            }
        }

        [HttpGet]
        [ActionName("GetByIdPartial")]
        public async Task<IActionResult> GetById(int id, bool filler) // https://localhost:7138/Book/GetByIdPartial?id=8
        {
            var response = await bookService.GetById(id);
            return PartialView("GetById", response.Data);

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id) // https://localhost:7138/Book/Delete?id=2
        {
            var response = await bookService.Delete(id);
            if (response.statusCode == Domain.Enum.StatusCode.ok)
            {
                return View(response.Data);
            }
            else
            {
                TempData["Error"] = response.Description;
                return RedirectToAction("Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetBook(int id) // https://localhost:7138/Book/GetBook?id=2
        {
            var response = await bookService.GetBook(id);
            if (response.statusCode == Domain.Enum.StatusCode.ok)
            {
                return View(response.Data);
            }
            else
            {
                TempData["Error"] = response.Description;
                return RedirectToAction("Error");
            }
        }





        [HttpGet]
        public IActionResult Error()
        {
            var Error = TempData["Error"];
            return View(Error);
        }
        
    }
}
