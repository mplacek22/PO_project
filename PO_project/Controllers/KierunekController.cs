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
    public class KierunekController : Controller
    {
        private readonly PwrDbContext _context;

        public KierunekController(PwrDbContext context)
        {
            _context = context;
        }

        // GET: Kierunek
        //public async Task<IActionResult> Index()
        //{
        //    var pwrDbContext = _context.Kierunki.Include(k => k.CzasTrwania).Include(k => k.Jezyk).Include(k => k.Stopien).Include(k => k.Tryb).Include(k => k.Wydzial);
        //    return View(await pwrDbContext.ToListAsync());
        //}

        public IActionResult Index(int? stopienId, int? wydzialId, int? trybId, int? jezykId)
        {
            ViewBag.Stopnie = new SelectList(_context.Stopnie, "StopienId", "Name", stopienId);
            ViewBag.Wydzialy = new SelectList(_context.Wydzialy, "WydzialId", "Name", wydzialId);
            ViewBag.Tryby = new SelectList(_context.Tryby, "TrybId", "Name", trybId);
            ViewBag.Jezyki = new SelectList(_context.Jezyki, "JezykId", "Name", jezykId);

            if (stopienId == null)
            {
                return View();
            }

            var kierunki = _context.Kierunki.Where(k => (stopienId == null) || k.StopienId == stopienId)
                .Where(k => (wydzialId == null) || k.WydzialId == wydzialId)
                .Where(k => (trybId == null) || k.TrybId == trybId)
                .Where(k => (jezykId == null) || k.JezykId == jezykId);

            return View(kierunki);
        }


        // GET: Kierunek/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Kierunki == null)
            {
                return NotFound();
            }

            var kierunek = await _context.Kierunki
                .Include(k => k.CzasTrwania)
                .Include(k => k.Jezyk)
                .Include(k => k.Stopien)
                .Include(k => k.Tryb)
                .Include(k => k.Wydzial)
                .Include(k => k.Specjalizacje)
                .Include(k => k.Perpektywy)
                    .ThenInclude(kp => kp.Pracodawca)
                .FirstOrDefaultAsync(m => m.KierunekId == id);

            if (kierunek == null)
            {
                return NotFound();
            }

            return View(kierunek);
        }

        // GET: Kierunek/Create
        public IActionResult Create()
        {
            ViewData["CzasTrwaniaId"] = new SelectList(_context.CzasyTrwania, "CzasTrwaniaId", "CzasTrwaniaId");
            ViewData["JezykId"] = new SelectList(_context.Jezyki, "JezykId", "Name");
            ViewData["StopienId"] = new SelectList(_context.Stopnie, "StopienId", "Name");
            ViewData["TrybId"] = new SelectList(_context.Tryby, "TrybId", "Name");
            return View();
        }

        // POST: Kierunek/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KierunekId,Name,Abbreviation,Description,JezykId,StopienId,TrybId,CzasTrwaniaId")] Kierunek kierunek)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kierunek);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CzasTrwaniaId"] = new SelectList(_context.CzasyTrwania, "CzasTrwaniaId", "CzasTrwaniaId", kierunek.CzasTrwaniaId);
            ViewData["JezykId"] = new SelectList(_context.Jezyki, "JezykId", "Name", kierunek.JezykId);
            ViewData["StopienId"] = new SelectList(_context.Stopnie, "StopienId", "Name", kierunek.StopienId);
            ViewData["TrybId"] = new SelectList(_context.Tryby, "TrybId", "Name", kierunek.TrybId);
            return View(kierunek);
        }

        // GET: Kierunek/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Kierunki == null)
            {
                return NotFound();
            }

            var kierunek = await _context.Kierunki.FindAsync(id);
            if (kierunek == null)
            {
                return NotFound();
            }
            ViewData["CzasTrwaniaId"] = new SelectList(_context.CzasyTrwania, "CzasTrwaniaId", "CzasTrwaniaId", kierunek.CzasTrwaniaId);
            ViewData["JezykId"] = new SelectList(_context.Jezyki, "JezykId", "Name", kierunek.JezykId);
            ViewData["StopienId"] = new SelectList(_context.Stopnie, "StopienId", "Name", kierunek.StopienId);
            ViewData["TrybId"] = new SelectList(_context.Tryby, "TrybId", "Name", kierunek.TrybId);
            return View(kierunek);
        }

        // POST: Kierunek/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KierunekId,Name,Abbreviation,Description,JezykId,StopienId,TrybId,CzasTrwaniaId")] Kierunek kierunek)
        {
            if (id != kierunek.KierunekId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kierunek);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KierunekExists(kierunek.KierunekId))
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
            ViewData["CzasTrwaniaId"] = new SelectList(_context.CzasyTrwania, "CzasTrwaniaId", "CzasTrwaniaId", kierunek.CzasTrwaniaId);
            ViewData["JezykId"] = new SelectList(_context.Jezyki, "JezykId", "Name", kierunek.JezykId);
            ViewData["StopienId"] = new SelectList(_context.Stopnie, "StopienId", "Name", kierunek.StopienId);
            ViewData["TrybId"] = new SelectList(_context.Tryby, "TrybId", "Name", kierunek.TrybId);
            return View(kierunek);
        }

        // GET: Kierunek/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Kierunki == null)
            {
                return NotFound();
            }

            var kierunek = await _context.Kierunki
                .Include(k => k.CzasTrwania)
                .Include(k => k.Jezyk)
                .Include(k => k.Stopien)
                .Include(k => k.Tryb)
                .FirstOrDefaultAsync(m => m.KierunekId == id);
            if (kierunek == null)
            {
                return NotFound();
            }

            return View(kierunek);
        }

        // POST: Kierunek/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Kierunki == null)
            {
                return Problem("Entity set 'PwrDbContext.Kierunki'  is null.");
            }
            var kierunek = await _context.Kierunki.FindAsync(id);
            if (kierunek != null)
            {
                _context.Kierunki.Remove(kierunek);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KierunekExists(int id)
        {
          return (_context.Kierunki?.Any(e => e.KierunekId == id)).GetValueOrDefault();
        }
    }
}
