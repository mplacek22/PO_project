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
    public class PracodawcasController : Controller
    {
        private readonly PwrDbContext _context;

        public PracodawcasController(PwrDbContext context)
        {
            _context = context;
        }

        // GET: Pracodawcas
        public async Task<IActionResult> Index()
        {
            var pwrDbContext = _context.Pracodawcy.Include(p => p.adres);
            return View(await pwrDbContext.ToListAsync());
        }

        // GET: Pracodawcas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pracodawcy == null)
            {
                return NotFound();
            }

            var pracodawca = await _context.Pracodawcy
                .Include(p => p.adres)
                .FirstOrDefaultAsync(m => m.PracodawcaId == id);
            if (pracodawca == null)
            {
                return NotFound();
            }

            return View(pracodawca);
        }

        // GET: Pracodawcas/Create
        public IActionResult Create()
        {
            ViewData["AdresId"] = new SelectList(_context.Adresy, "AdresId", "AdresId");
            return View();
        }

        // POST: Pracodawcas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PracodawcaId,CompanyName,Description,Link,AdresId")] Pracodawca pracodawca)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pracodawca);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdresId"] = new SelectList(_context.Adresy, "AdresId", "AdresId", pracodawca.AdresId);
            return View(pracodawca);
        }

        // GET: Pracodawcas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pracodawcy == null)
            {
                return NotFound();
            }

            var pracodawca = await _context.Pracodawcy.FindAsync(id);
            if (pracodawca == null)
            {
                return NotFound();
            }
            ViewData["AdresId"] = new SelectList(_context.Adresy, "AdresId", "AdresId", pracodawca.AdresId);
            return View(pracodawca);
        }

        // POST: Pracodawcas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PracodawcaId,CompanyName,Description,Link,AdresId")] Pracodawca pracodawca)
        {
            if (id != pracodawca.PracodawcaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pracodawca);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PracodawcaExists(pracodawca.PracodawcaId))
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
            ViewData["AdresId"] = new SelectList(_context.Adresy, "AdresId", "AdresId", pracodawca.AdresId);
            return View(pracodawca);
        }

        // GET: Pracodawcas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pracodawcy == null)
            {
                return NotFound();
            }

            var pracodawca = await _context.Pracodawcy
                .Include(p => p.adres)
                .FirstOrDefaultAsync(m => m.PracodawcaId == id);
            if (pracodawca == null)
            {
                return NotFound();
            }

            return View(pracodawca);
        }

        // POST: Pracodawcas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pracodawcy == null)
            {
                return Problem("Entity set 'PwrDbContext.Pracodawcy'  is null.");
            }
            var pracodawca = await _context.Pracodawcy.FindAsync(id);
            if (pracodawca != null)
            {
                _context.Pracodawcy.Remove(pracodawca);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PracodawcaExists(int id)
        {
          return (_context.Pracodawcy?.Any(e => e.PracodawcaId == id)).GetValueOrDefault();
        }
    }
}
