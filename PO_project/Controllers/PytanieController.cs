using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PO_project.Data;

namespace PO_project.Controllers
{
    /// <summary>
    /// Kontroler odpowiedzialny za obsługę widoków związanych z ankieta.
    /// </summary>
    public class PytanieController : Controller
    {
        /// <summary>
        /// _context - kontekst bazy danych
        /// currentQuestionIndex - indeks aktualnego pytania
        /// </summary>
        private readonly PwrDbContext _context;
        private int currentQuestionIndex = 0;

        /// <summary>
        /// konstruktor kontrolera PytanieController - ustawia kontekst bazy danych
        /// </summary>
        /// <param name="context">kontekst bazy danych</param>
        public PytanieController(PwrDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// metoda wyświetla widok ankiety dla danego pytania
        /// </summary>
        /// <param name="id">id pytania</param>
        /// <returns>widok ankiety dla danego pytania</returns>
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

            ViewBag.Odpowiedzi = new SelectList(_context.Odpowiedzi, "OdpowiedzId", "Tresc").ToList();

            var pytania = _context.Pytania.Include(p => p.Odpowiedzi).Skip(currentQuestionIndex).Take(1);
            return View(pytania);
        }

        /// <summary>
        /// getter dla currentQuestionIndex
        /// </summary>
        /// <returns> wartość currentQuestionIndex </returns>
        public int getCurrentQuestionIndex()
        {
            return currentQuestionIndex;
        }

        /// <summary>
        /// metoda zwraca widok z listą rekomendowanych kierunków na podstawie podanych parametrów
        /// </summary>
        /// <param name="answer5"></param>
        /// <returns>widok z listą rekomendowanych kierunków na podstawie podanych parametrów</returns>
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

            if (TempData != null)
            {
                TempData["AnkietaResults"] = Newtonsoft.Json.JsonConvert.SerializeObject(results.Where(k => k.StopienId == 1).ToList());
            }

            return View(results);
        }

        private bool PytanieExists(int id)
        {
          return (_context.Pytania?.Any(e => e.PytanieId == id)).GetValueOrDefault();
        }

    }
}
