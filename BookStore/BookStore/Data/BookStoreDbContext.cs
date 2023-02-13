﻿using Microsoft.EntityFrameworkCore;

namespace BookStore.Data
{
    public class BookStoreDbContext:DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
            : base(options)
        {

        }

        public DbSet<Books> Books { get; set; }
        public DbSet<Language> Language { get; set; }
    }
}
