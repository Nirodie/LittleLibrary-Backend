using Microsoft.EntityFrameworkCore;
namespace LittleLibraryAPI.Models
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
            
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Quote> Quotes { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
            new Book { id = 1, title = "The Great Gatsby", genre = "Fiction", author = "F. Scott Fitzgerald" },
            new Book { id = 2, title = "To Kill a Mockingbird", genre = "Fiction", author = "Harper Lee" },
            new Book { id = 3, title = "1984", genre = "Dystopian", author = "George Orwell" },
            new Book { id = 4, title = "Pride and Prejudice", genre = "Romance", author = "Jane Austen" },
            new Book { id = 5, title = "The Hobbit", genre = "Fantasy", author = "J.R.R. Tolkien" }
            );

            modelBuilder.Entity<Quote>().HasData(
                new Quote { id = 1, text = "Be yourself; everyone else is already taken.", author = "Oscar Wilde" },
                new Quote { id = 2, text = "I'm selfish, impatient and a little insecure. I make mistakes, I am out of control and at times hard to handle. But if you can't handle me at my worst, then you sure as hell don't deserve me at my best.", author = "Marilyn Monroe" },
                new Quote { id = 3, text = "So many books, so little time.", author = "Frank Zappa" }
            );
        }
    }
}
