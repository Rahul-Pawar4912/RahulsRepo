using BookStore.Models;

namespace BookStore.Repositories
{
    public class BookRepository
    {
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }

        public BookModel GetBookById(int id)
        {
            return DataSource().Where(x => x.Id == id).FirstOrDefault();
        }

        public List<BookModel> SearchBook(string title, string authorName)
        {
            return DataSource().Where(x => x.Title.Contains(title) && x.Author.Contains(authorName)).ToList();
        }

        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            { new BookModel(){Id=1,Title="Core",Author="Rahul"},
             new BookModel(){Id=2,Title="MVC",Author="Swastik"},
             new BookModel(){Id=3,Title="C#",Author="Me"},
            new BookModel(){Id=4,Title="PHP",Author="Dada"},
            new BookModel(){Id=5,Title="JS",Author="Tu"},
            };
        }
    }
}
