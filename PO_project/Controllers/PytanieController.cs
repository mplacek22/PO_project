using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PO_project.Data;
using PO_project.Models;

namespace PO_project.Controllers
{
    public class PytanieController : Controller
    {
        private readonly PwrDbContext _context;
        private int currentQuestionIndex = 0;

        public PytanieController(PwrDbContext context)
        {
            _context = context;
        }

        //// GET: Pytanie
        public IActionResult Index(int? id)
        {
            if (id.HasValue && id.Value < 5 && id.Value >= 0)
            {
                currentQuestionIndex = id.Value;
            }
            else if (id.HasValue && id.Value <= -1)
            {
                currentQuestionIndex = 0;
            }
            else if (id.HasValue && id.Value > 4)
            {
                currentQuestionIndex = 4;
            }

            ViewBag.Odpowiedzi = new SelectList(_context.Odpowiedzi, "OdzpowiedzId", "Tresc").ToList();

            var pytania = _context.Pytania.Include(p => p.Odpowiedzi).Skip(currentQuestionIndex).Take(1);
            return View(pytania);
        }

        public int getCurrentQuestionIndex()
        {
            return currentQuestionIndex;
        }


        // GET: Pytanie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pytania == null)
            {
                return NotFound();
            }

            var pytanie = await _context.Pytania
                .FirstOrDefaultAsync(m => m.PytanieId == id);
            if (pytanie == null)
            {
                return NotFound();
            }

            return View(pytanie);
        }

        // GET: Pytanie/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pytanie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PytanieId,Tresc")] Pytanie pytanie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pytanie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pytanie);
        }

        // GET: Pytanie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pytania == null)
            {
                return NotFound();
            }

            var pytanie = await _context.Pytania.FindAsync(id);
            if (pytanie == null)
            {
                return NotFound();
            }
            return View(pytanie);
        }

        // POST: Pytanie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PytanieId,Tresc")] Pytanie pytanie)
        {
            if (id != pytanie.PytanieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pytanie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PytanieExists(pytanie.PytanieId))
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
            return View(pytanie);
        }

        // GET: Pytanie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pytania == null)
            {
                return NotFound();
            }

            var pytanie = await _context.Pytania
                .FirstOrDefaultAsync(m => m.PytanieId == id);
            if (pytanie == null)
            {
                return NotFound();
            }

            return View(pytanie);
        }

        // POST: Pytanie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pytania == null)
            {
                return Problem("Entity set 'PwrDbContext.Pytania'  is null.");
            }
            var pytanie = await _context.Pytania.FindAsync(id);
            if (pytanie != null)
            {
                _context.Pytania.Remove(pytanie);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PytanieExists(int id)
        {
          return (_context.Pytania?.Any(e => e.PytanieId == id)).GetValueOrDefault();
        }

        public IActionResult Recomendations()
        {
            return View();
        }
    }
}
