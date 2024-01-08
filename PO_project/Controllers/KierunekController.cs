using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PO_project.Data;
using PO_project.KalkulatorWskaznika;
using PO_project.Models;
using PO_project.RecrutationCalc;

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

        private String getFileName(Kierunek kierunek)
        {
            return kierunek.Name.Replace(' ', '_') + '_' + kierunek.StopienId + '_' + kierunek.Tryb.Name.Substring(0, 1).ToUpper() + ".cshtml";
        }

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
                    .ThenInclude(kw => kw.Lokalizacja)
                .Include(k => k.Specjalizacje)
                .Include(k => k.Perpektywy)
                    .ThenInclude(kp => kp.Pracodawca)
                .Include(k => k.Praktyki)
                    .ThenInclude(kp => kp.Pracodawca)
                .Include(k => k.MiejscaPracy)
                    .ThenInclude(kp => kp.Pracodawca)
                .FirstOrDefaultAsync(m => m.KierunekId == id);

            if (kierunek == null)
            {
                return NotFound();
            }

            String path = ("Views/Kierunki/" + getFileName(kierunek));

            if (System.IO.File.Exists(path))
                return View("~/" + path, kierunek);

            return View(kierunek);
        }

        public IActionResult Calculator(int? id, double? pointsKierunek, double? points)
        {
            if (id == null || _context.Kierunki == null)
            {
                return NotFound();
            }

            var kierunek = _context.Kierunki
                .Include(k => k.Stopien)
                .Include(k => k.Tryb)
                .FirstOrDefault(m => m.KierunekId == id);
;

            if (kierunek == null)
            {
                return NotFound();
            }

            if (kierunek.StopienId == 2)
            {
                String path = ("Views/Kalkulatory/" + getFileName(kierunek));
                if (!System.IO.File.Exists(path))
                    return NotFound();
                return View("~/" + path, (kierunek, pointsKierunek, points));
            }

            return View("~/Views/KalkulatorWskaznikaISt/Index.cshtml", new FormularzRekrutacyjnyISt());
        }

        public IActionResult Calculate(int? id, double? d, double? sr, double? e, int? od)
        {
            Bachelore batchelore = new Bachelore();
            var kierunek = _context.Kierunki.Find(id);

            if (kierunek == null)
            {
                return NotFound();
            }

            if(d == null || sr == null)
            {
                return RedirectToAction("Calculator", id);
            }

            MethodInfo? calculatorMethodInfo;
            double points = batchelore.Base((double)d, (double)sr);
            double pointsKierunek = points;

            e ??= 0;
            od ??= 0;  

            if((calculatorMethodInfo = batchelore.GetType().GetMethod(kierunek.Name, new Type[] { typeof(double), typeof(double) })) != null)
                pointsKierunek = (double)calculatorMethodInfo!.Invoke(batchelore, new object[] { d!, sr! })!;
            else if ((calculatorMethodInfo = batchelore.GetType().GetMethod(kierunek.Name, new Type[] { typeof(double), typeof(double), typeof(int) })) != null)
                pointsKierunek = (double)calculatorMethodInfo!.Invoke(batchelore, new object[] { d!, sr!, od! })!;
            else if ((calculatorMethodInfo = batchelore.GetType().GetMethod(kierunek.Name, new Type[] { typeof(double), typeof(double), typeof(int) })) != null)
                pointsKierunek = (double)calculatorMethodInfo!.Invoke(batchelore, new object[] { d!, sr!, e! })!;
            else if ((calculatorMethodInfo = batchelore.GetType().GetMethod(kierunek.Name, new Type[] { typeof(double), typeof(double), typeof(double), typeof(int) })) != null)
                pointsKierunek = (double)calculatorMethodInfo!.Invoke(batchelore, new object[] { d!, sr!, e!, od! })!;

            return RedirectToAction("Calculator", new {id, pointsKierunek, points});
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
