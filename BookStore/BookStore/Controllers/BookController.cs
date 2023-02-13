using BookStore.Data;
using BookStore.Models;
using BookStore.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;
        private readonly LanguageRepository _languageRepository = null;
        public BookController(BookRepository bookRepository, LanguageRepository languageRepository)
        {
            _bookRepository = bookRepository;
            _languageRepository = languageRepository;
        }
        public async Task<ViewResult> GetAllBooks()
        {
            var data = await _bookRepository.GetAllBooks();
            return View(data);
        }

        public async Task<ViewResult> GetBook(int id)
        {
            var book = await _bookRepository.GetBookById(id);
            return View(book);
        }

        public List<BookModel> SearchBook(string bookName, string authorName)
        {
            return _bookRepository.SearchBook(bookName, authorName);
        }

        public async Task<ViewResult> AddNewBook(bool IsSuccess = false)
        {
            ViewBag.IsSuccess = IsSuccess;
            //ViewBag.Language = GetLanguage().Select(x => new SelectListItem()
            //{
            //    Text = x.Name,
            //    Value = x.Id.ToString()
            //}).ToList();
            ViewBag.laguange = new SelectList(await _languageRepository.GetLanguages(), "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBook(Books bookModel)
        {
            if (ModelState.IsValid)
            {
                int id = await _bookRepository.AddNewBooks(bookModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewBook), new { IsSuccess = true });
                }
            }
            ViewBag.laguange = new SelectList(await _languageRepository.GetLanguages(),"Id","Name");
            //{
            //    Text = x.Name,
            //    Value = x.Id.ToString()
            //}).ToList();
            return View();
        }
        //private List<LanguageModel> GetLanguage()
        //{
        //    return new List<LanguageModel>()
        //{
        //new LanguageModel(){Id=1,Name="Hindi"},
        //new LanguageModel(){Id=1,Name="English"},
        //new LanguageModel(){Id=1,Name="Marathi"},
        //};
        //}
    }
}
