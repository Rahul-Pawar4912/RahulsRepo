using BookStore.Models;
using BookStore.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository bookRepository = null;
        public BookController()
        {
            bookRepository = new BookRepository();
        }
        public ViewResult GetAllBooks()
        {
            var data= bookRepository.GetAllBooks();
            return View();
        }

        public BookModel GetBook(int id)
        {
            return bookRepository.GetBookById(id);
        }

        public List<BookModel> SearchBook(string bookName,string authorName)
        {
            return bookRepository.SearchBook(bookName, authorName);
        }
    }
}
