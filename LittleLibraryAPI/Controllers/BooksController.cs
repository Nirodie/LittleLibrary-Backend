using LittleLibraryAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LittleLibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetBooks()
        {
            return Ok(BookRepository.Books);
        }

        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            var book = BookRepository.Books.FirstOrDefault(b => b.id == id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public IActionResult PostBook(Book book)
        {
            book.id = BookRepository.Books.Max(b => b.id) + 1;
            BookRepository.Books.Add(book);
            return CreatedAtAction(nameof(GetBook), new { id = book.id }, book);
        }

        [HttpPut("{id}")]
        public IActionResult PutBook(int id, Book updatedBook) {
            if(id != updatedBook.id)
            {
                return BadRequest();
            }
            var book = BookRepository.Books.FirstOrDefault(b => b.id == id);
            if (book == null)
            {
                return NotFound();
            }
            book.title = updatedBook.title;
            book.genre = updatedBook.genre;
            book.author = updatedBook.author;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id) {
            var book = BookRepository.Books.FirstOrDefault(b => b.id == id);
            if (book == null)
            {
                return NotFound();
            }
            BookRepository.Books.Remove(book);
            return NoContent();
        }
    }
}
