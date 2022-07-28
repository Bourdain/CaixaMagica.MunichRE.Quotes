using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CaixaMagica.MunichRE.Data.Models;

namespace CaixaMagica.MunichRE.Web.Controllers
{
    public class QuotesController : Controller
    {
        private readonly InspirationalQuotesdbContext _context;

        public QuotesController(InspirationalQuotesdbContext context)
        {
            _context = context;
        }

        // GET: Quotes
        public async Task<IActionResult> Index()
        {
              return _context.Quotes != null ? 
                          View(await _context.Quotes.ToListAsync()) :
                          Problem("Entity set 'InspirationalQuotesdbContext.Quotes'  is null.");
        }

        // GET: Quotes/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Quotes == null)
            {
                return NotFound();
            }

            var quotes = await _context.Quotes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quotes == null)
            {
                return NotFound();
            }

            return View(quotes);
        }

        // GET: Quotes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Quotes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Quote,Author")] Quotes quotes)
        {
            if (ModelState.IsValid)
            {
                if (quotes.Author == "" || quotes.Author is null)
                {
                    quotes.Author = "Unknown";
                }

                if (quotes.Quote == "" || quotes.Quote is null)
                {
                    quotes.Quote = "Empty";
                }


                _context.Add(quotes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(quotes);
        }

        // GET: Quotes/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Quotes == null)
            {
                return NotFound();
            }

            var quotes = await _context.Quotes.FindAsync(id);
            if (quotes == null)
            {
                return NotFound();
            }
            return View(quotes);
        }

        // POST: Quotes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Quote,Author")] Quotes quotes)
        {
            if (id != quotes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    if (quotes.Author == "" || quotes.Author is null)
                    {
                        quotes.Author = "Unknown";
                    }

                    if (quotes.Quote == "" || quotes.Quote is null)
                    {
                        quotes.Quote = "Empty";
                    }

                    _context.Update(quotes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuotesExists(quotes.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(quotes);
        }

        // GET: Quotes/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Quotes == null)
            {
                return NotFound();
            }

            var quotes = await _context.Quotes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quotes == null)
            {
                return NotFound();
            }

            return View(quotes);
        }

        // POST: Quotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Quotes == null)
            {
                return Problem("Entity set 'InspirationalQuotesdbContext.Quotes'  is null.");
            }
            var quotes = await _context.Quotes.FindAsync(id);
            if (quotes != null)
            {
                _context.Quotes.Remove(quotes);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuotesExists(long id)
        {
          return (_context.Quotes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
