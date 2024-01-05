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
    public class WydzialsController : Controller
    {
        private readonly PwrDbContext _context;

        public WydzialsController(PwrDbContext context)
        {
            _context = context;
        }

        // GET: Wydzials
        public async Task<IActionResult> Index()
        {
            var pwrDbContext = _context.Wydzialy.Include(w => w.Lokalizacja);
            return View(await pwrDbContext.ToListAsync());
        }

        // GET: Wydzials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Wydzialy == null)
            {
                return NotFound();
            }

            var wydzial = await _context.Wydzialy
                .Include(w => w.Lokalizacja)
                .FirstOrDefaultAsync(m => m.WydzialId == id);
            if (wydzial == null)
            {
                return NotFound();
            }

            return View(wydzial);
        }

        // GET: Wydzials/Create
        public IActionResult Create()
        {
            ViewData["LokalizacjaId"] = new SelectList(_context.Lokalizacje, "LokalizacjaId", "LokalizacjaId");
            return View();
        }

        // POST: Wydzials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WydzialId,Name,Abbreviation,LokalizacjaId")] Wydzial wydzial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wydzial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LokalizacjaId"] = new SelectList(_context.Lokalizacje, "LokalizacjaId", "LokalizacjaId", wydzial.LokalizacjaId);
            return View(wydzial);
        }

        // GET: Wydzials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Wydzialy == null)
            {
                return NotFound();
            }

            var wydzial = await _context.Wydzialy.FindAsync(id);
            if (wydzial == null)
            {
                return NotFound();
            }
            ViewData["LokalizacjaId"] = new SelectList(_context.Lokalizacje, "LokalizacjaId", "LokalizacjaId", wydzial.LokalizacjaId);
            return View(wydzial);
        }

        // POST: Wydzials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WydzialId,Name,Abbreviation,LokalizacjaId")] Wydzial wydzial)
        {
            if (id != wydzial.WydzialId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wydzial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WydzialExists(wydzial.WydzialId))
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
            ViewData["LokalizacjaId"] = new SelectList(_context.Lokalizacje, "LokalizacjaId", "LokalizacjaId", wydzial.LokalizacjaId);
            return View(wydzial);
        }

        // GET: Wydzials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Wydzialy == null)
            {
                return NotFound();
            }

            var wydzial = await _context.Wydzialy
                .Include(w => w.Lokalizacja)
                .FirstOrDefaultAsync(m => m.WydzialId == id);
            if (wydzial == null)
            {
                return NotFound();
            }

            return View(wydzial);
        }

        // POST: Wydzials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Wydzialy == null)
            {
                return Problem("Entity set 'PwrDbContext.Wydzialy'  is null.");
            }
            var wydzial = await _context.Wydzialy.FindAsync(id);
            if (wydzial != null)
            {
                _context.Wydzialy.Remove(wydzial);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WydzialExists(int id)
        {
          return (_context.Wydzialy?.Any(e => e.WydzialId == id)).GetValueOrDefault();
        }
    }
}
