using BookStore.Data;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repositories
{
    public class LanguageRepository
    {
        private readonly BookStoreDbContext bookStoreDbContext=null;

        public LanguageRepository(BookStoreDbContext context)
        {
            this.bookStoreDbContext = context;
        }

        public async Task<List<LanguageModel>> GetLanguages()
        {
            return await bookStoreDbContext.Language.Select(x => new LanguageModel()
            {
                Name = x.Name,
                Id = x.Id,
                Description = x.Description,
            }).ToListAsync();
        }
    }
}
