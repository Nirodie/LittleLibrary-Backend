using LittleLibraryAPI.Entities;
using Microsoft.EntityFrameworkCore;
namespace LittleLibraryAPI.Models
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Quote> Quotes { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
            new Book { Id = 1, Title = "The Great Gatsby", Genre = "Fiction", Author = "F. Scott Fitzgerald" },
            new Book { Id = 2, Title = "To Kill a Mockingbird", Genre = "Fiction", Author = "Harper Lee" },
            new Book { Id = 3, Title = "1984", Genre = "Dystopian", Author = "George Orwell" },
            new Book { Id = 4, Title = "Pride and Prejudice", Genre = "Romance", Author = "Jane Austen" },
            new Book { Id = 5, Title = "The Hobbit", Genre = "Fantasy", Author = "J.R.R. Tolkien" }
            );

            modelBuilder.Entity<Quote>().HasData(
                new Quote { Id = 1, Text = "Be yourself; everyone else is already taken.", Author = "Oscar Wilde" },
                new Quote { Id = 2, Text = "I'm selfish, impatient and a little insecure. I make mistakes, I am out of control and at times hard to handle. But if you can't handle me at my worst, then you sure as hell don't deserve me at my best.", Author = "Marilyn Monroe" },
                new Quote { Id = 3, Text = "So many books, so little time.", Author = "Frank Zappa" }
            );
        }
    }
}
