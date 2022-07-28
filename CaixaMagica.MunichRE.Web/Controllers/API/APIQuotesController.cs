using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CaixaMagica.MunichRE.Data.Models;

namespace CaixaMagica.MunichRE.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIQuotesController : ControllerBase
    {
        private readonly InspirationalQuotesdbContext _context;

        public APIQuotesController(InspirationalQuotesdbContext context)
        {
            _context = context;
        }

        // GET: api/APIQuotes
        [HttpGet]
        public ActionResult<Quotes> GetRandomQuotes()
        {
            if (_context.Quotes == null)
            {
                return NotFound();
            }
            int vall = new Random().Next(1, _context.Quotes.Count());
            var randomQuote = _context.Quotes.Skip(vall).Take(1).First();

            return randomQuote;
        }

        //// GET: api/APIQuotes/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Quotes>> GetQuotes(long id)
        //{
        //  if (_context.Quotes == null)
        //  {
        //      return NotFound();
        //  }
        //    var quotes = await _context.Quotes.FindAsync(id);

        //    if (quotes == null)
        //    {
        //        return NotFound();
        //    }

        //    return quotes;
        //}

        //// PUT: api/APIQuotes/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutQuotes(long id, Quotes quotes)
        //{
        //    if (id != quotes.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(quotes).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!QuotesExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/APIQuotes
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Quotes>> PostQuotes(Quotes quotes)
        //{
        //  if (_context.Quotes == null)
        //  {
        //      return Problem("Entity set 'InspirationalQuotesdbContext.Quotes'  is null.");
        //  }
        //    _context.Quotes.Add(quotes);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetQuotes", new { id = quotes.Id }, quotes);
        //}

        //// DELETE: api/APIQuotes/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteQuotes(long id)
        //{
        //    if (_context.Quotes == null)
        //    {
        //        return NotFound();
        //    }
        //    var quotes = await _context.Quotes.FindAsync(id);
        //    if (quotes == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Quotes.Remove(quotes);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool QuotesExists(long id)
        //{
        //    return (_context.Quotes?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
