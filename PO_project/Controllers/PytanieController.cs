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

        public IActionResult Recomendations(int? answer5)
        {
	        var results = answer5 switch
	        {
		        13 => _context.Kierunki.Where(k => k.StopienId == 1)
			        .Where(k => k.WydzialId == 4)
			        .Where(k => k.TrybId == 1)
			        .Where(k => k.JezykId == 1)
			        .ToList(),
		        14 => _context.Kierunki.Where(k => k.StopienId == 2)
			        .Where(k => k.WydzialId == 2)
			        .Where(k => k.TrybId == 2)
			        .Where(k => k.JezykId == 1)
			        .ToList(),
		        15 => _context.Kierunki.Where(k => k.StopienId == 1)
			        .Where(k => k.WydzialId == 1)
			        .Where(k => k.TrybId == 1)
			        .Where(k => k.JezykId == 1)
			        .ToList(),
		        _ => _context.Kierunki.ToList()
	        };
	        TempData["AnkietaResults"] = Newtonsoft.Json.JsonConvert.SerializeObject(results.Where(k => k.StopienId == 1).ToList());
			return View(results);
        }

        private bool PytanieExists(int id)
        {
          return (_context.Pytania?.Any(e => e.PytanieId == id)).GetValueOrDefault();
        }

    }
}
