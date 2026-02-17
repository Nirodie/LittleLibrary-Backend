namespace LittleLibraryAPI.Models
{
    public static class BookRepository
    {
        public static List<Book> Books = new List<Book>
        {
            new Book { id = 1, title = "The Great Gatsby", genre = "Fiction", author = "F. Scott Fitzgerald" },
            new Book { id = 2, title = "To Kill a Mockingbird", genre = "Fiction", author = "Harper Lee" },
            new Book { id = 3, title = "1984", genre = "Dystopian", author = "George Orwell" },
            new Book { id = 4, title = "Pride and Prejudice", genre = "Romance", author = "Jane Austen" },
            new Book { id = 5, title = "The Hobbit", genre = "Fantasy", author = "J.R.R. Tolkien" }
        };
    }
}
