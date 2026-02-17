using LittleLibraryAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LittleLibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesDbController : ControllerBase
    {
        private readonly LibraryDbContext _dbContext;

        public QuotesDbController(LibraryDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quote>>> GetQuotes()
        {
            var quotes = await _dbContext.Quotes.ToListAsync();
            return Ok(quotes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Quote>> GetQuote(int id)
        {
            var quote = await _dbContext.Quotes.FirstOrDefaultAsync(q => q.id == id);
            if (quote == null)
            {
                return NotFound();
            }
            return Ok(quote);
        }

        [HttpPost]
        public async Task<ActionResult<Quote>> PostQuote(Quote quote)
        {
            _dbContext.Quotes.Add(quote);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetQuote), new { id = quote.id }, quote);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutQuote(int id, Quote updatedQuote)
        {
            if (id != updatedQuote.id)
            {
                return BadRequest();
            }
            _dbContext.Entry(updatedQuote).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuoteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        private bool QuoteExists(int id)
        {
            return _dbContext.Quotes.Any(q => q.id == id);
        }
    

    [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteQuote(int id)
        {
            var quote = await _dbContext.Quotes.FirstOrDefaultAsync(q => q.id == id);
            if (quote == null)
            {
                return NotFound();
            }
            _dbContext.Quotes.Remove(quote);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}

