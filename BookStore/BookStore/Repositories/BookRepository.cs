using BookStore.Data;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repositories
{
    public class BookRepository
    {
        private readonly BookStoreDbContext bookStoreDbContext = null;

        public BookRepository(BookStoreDbContext context)
        {
            this.bookStoreDbContext = context;
        }

        public async Task<int> AddNewBooks(Books bookModel)
        {
            var newBook = new Books
            {
                Title = bookModel.Title,
                Author = bookModel.Author,
                Description = bookModel.Description,
                Category = bookModel.Category,
                LanguageId = bookModel.LanguageId,
                TotalPages = bookModel.TotalPages,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
            };
            await bookStoreDbContext.Books.AddAsync(newBook);
            await bookStoreDbContext.SaveChangesAsync();
            return newBook.Id;
        }
        public async Task<List<BookModel>> GetAllBooks()
        {
            var books = new List<BookModel>();
            var allBooks = await bookStoreDbContext.Books.ToListAsync();
            if (allBooks.Any() == true)
            {
                foreach (var book in allBooks)
                {
                    books.Add(new BookModel
                    {
                        Id = book.Id,
                        Author = book.Author,
                        Title = book.Title,
                        Description = book.Description,
                        Category = book.Category,
                        LanguageId = book.LanguageId,
                        TotalPages = book.TotalPages,
                        //Language = book.Language.Name,
                        Language = (from lang in bookStoreDbContext.Language join b in bookStoreDbContext.Books on lang.Id equals b.LanguageId where b.Id == book.Id select lang.Name).Single(),
                    //Select lang.Name; from Names in bookStoreDbContext.Language
                    //           join bookinfo in bookStoreDbContext.Books on (x=>Names.Id==bookinfo.LanguageId && bookinfo.)  select new Names.Name ;
                });
                }

            }
            return books;
        }

        public async Task<BookModel> GetBookById(int id)
        {
            var book = await bookStoreDbContext.Books.FindAsync(id);
            if (book != null)
            {
                var bookdetails = new BookModel()
                {
                    Id = book.Id,
                    Author = book.Author,
                    Title = book.Title,
                    Description = book.Description,
                    Category = book.Category,
                    LanguageId = book.LanguageId,
                    Language=(from lang in bookStoreDbContext.Language join b in bookStoreDbContext.Books on lang.Id equals b.LanguageId where b.Id == book.Id select lang.Name).Single()
                };
                return bookdetails;
            }
            return null;
        }

        public List<BookModel> SearchBook(string title, string authorName)
        {
            return DataSource().Where(x => x.Title.Contains(title) && x.Author.Contains(authorName)).ToList();
        }

        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            { new BookModel(){Id=1,Title="Core",Author="Rahul",Description="Core Book"},
             new BookModel(){Id=2,Title="MVC",Author="Swastik",Description="MVC Book"},
             new BookModel(){Id=3,Title="C#",Author="Me",Description="C# Book"},
            new BookModel(){Id=4,Title="PHP",Author="Dada",Description="Php Book"},
            new BookModel(){Id=5,Title="JS",Author="Tu" ,Description="JS Book"},
            };
        }
    }
}
