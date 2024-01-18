using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PO_project.Data;
using PO_project.Models;
using PO_project.RecruitmentCalculator;

namespace PO_project.Controllers
{
    /// <summary>  
    /// Kontroler odpowiedzialny za obsługę widoków związanych z kierunkami studiów.
    /// </summary>  
    ///
    public class KierunekController : Controller
    {
        /// <summary>
        /// _context - kontekst bazy danych
        /// </summary>
        private readonly PwrDbContext _context;

        /// <summary>
        /// konstruktor kontrolera KierunekController - ustawia kontekst bazy danych
        /// </summary>
        public KierunekController(PwrDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// metoda przyjmuje kierunek i zwraca nazwę pliku z widokiem
        /// </summary>
        /// <param name="kierunek"> Kierunek do którego ma być zwrócona ścieżka </param>
        /// <returns> Ścieżka do widoku detali danego kierunku </returns>  
        ///
        private String getFileName(Kierunek kierunek)
        {
            return kierunek.Name.Replace(' ', '_') + '_' + kierunek.StopienId + '_' + kierunek.Tryb.Name.Substring(0, 1).ToUpper() + ".cshtml";
        }

        /// <summary>
        /// metoda zwraca widok z listą kierunków na podstawie podanych parametrów
        /// </summary>
        /// <param name="stopienId"></param>
        /// <param name="wydzialId"></param>
        /// <param name="trybId"></param>
        /// <param name="jezykId"></param>
        /// <returns> Filtrowany widok listy kierunków na podstawie zastosowanych parametrów</returns>
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

        /// <summary>
        /// metoda zwraca widok z detalami kierunku o podanym id
        /// </summary>
        /// <param name="id">Id kierunku</param>
        /// <returns> Widok detali kierunku o podanym ID</returns>
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

            String path = ("Views/KierunkiIISt/" + getFileName(kierunek));

            if (System.IO.File.Exists(path))
                return View("~/" + path, kierunek);

            if (kierunek.StopienId == 1)
                return View(kierunek);
            else
                return View("~/Views/KierunkiIISt/Default2St.cshtml", kierunek);
        }

        /// <summary>
        /// metoda zwraca widok z formularzem do obliczenia wskaźnika rekrutacyjnego na studia I stopnia
        /// </summary>
        /// <param name="id">identyfikator kierunku</param>
        /// <param name="pointsKierunek"> punkty rekrutacyjne dla kierunku o danym id </param>
        /// <param name="points"> bazowa ilość punktów dla kierunków 2 st. </param>
        /// <returns>widok z formularzem wskaźnika rekrutacyjnego na studia I stopnia</returns>
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


            if (kierunek == null)
            {
                return NotFound();
            }

            if (kierunek.StopienId == 2)
            {
                String path = ("Views/Kalkulatory/" + getFileName(kierunek));
                if (!System.IO.File.Exists(path))
                    return View("~/Views/Kalkulatory/Default_2.cshtml", (kierunek, pointsKierunek, points));
                
                return View("~/" + path, (kierunek, pointsKierunek, points));
            } 

            return View("~/Views/KalkulatorWskaznikaISt/Index.cshtml", new FormularzRekrutacyjnyISt());
        }

        /// <summary>
        /// metoda zwraca widok z formularzem do obliczenia wskaźnika rekrutacyjnego na studia II stopnia
        /// </summary>
        /// <param name="id">identyfikator kierunku</param>
        /// <param name="d">ocena na dyplomie</param>
        /// <param name="sr">średnia ze studiów I st.</param>
        /// <param name="e">ocena z dodatkowego egzaminu przeprowadzanego na uczelni</param>
        /// <param name="od">inne punkty dodatkowe</param>
        /// <returns> widok z formularzem do obliczenia wskaźnika rekrutacyjnego na studia II stopnia </returns>
        public IActionResult Calculate(int? id, double? d, double? sr, double? e, int? od)
        {
            var kierunek = _context.Kierunki.Find(id);

            if (kierunek == null)
            {
                return NotFound();
            }

            if(d == null || sr == null)
            {
                return RedirectToAction("Calculator", id);
            }

            double points, pointsKierunek;

            e ??= 0;
            od ??= 0;


            (points, pointsKierunek) = WzoryKalkulacyjne2st.Calculate(kierunek.Name, (double)d, (double)sr,(double)e,(int)od);

            return RedirectToAction("Calculator", new {id, pointsKierunek, points});
        }

        /// <summary>
        /// sprawdzenie czy istnieje kierunek o podanym id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>wartość boolowska oznaczająca czy dany kierunek istnieje</returns>
        private bool KierunekExists(int id)
        {
          return (_context.Kierunki?.Any(e => e.KierunekId == id)).GetValueOrDefault();
        }
    }
}
