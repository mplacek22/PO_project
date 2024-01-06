using Microsoft.AspNetCore.Mvc;
using PO_project.Data;
using PO_project.Enums;
using PO_project.KalkulatorWskaznika;

namespace PO_project.Controllers
{
	public class KalkulatorWskaznikaIStController : Controller
	{
		private readonly PwrDbContext _context;
		private readonly FormularzRekrutacyjnyISt  _formularz;

		public KalkulatorWskaznikaIStController(PwrDbContext context)
		{
			_context = context;
			_formularz = new FormularzRekrutacyjnyISt();
		}

        // GET: /KalkulatorWskaznikaIStController/Index
        public ActionResult Index()
		{
			return View(_formularz);
		}

        // POST: /KalkulatorWskaznikaIStController/Index
        [HttpPost]
		public ActionResult Index(FormularzRekrutacyjnyISt formularz, List<Olimpiada> SelectedOlimpiadas)
		{
            if (ModelState.IsValid)
			{
				_formularz.WynikiZMatur = formularz.WynikiZMatur;
				_formularz.WynikEgzaminuZRysunku = formularz.WynikEgzaminuZRysunku;
				_formularz.WynikiStudiumTalent = formularz.WynikiStudiumTalent;
				_formularz.Olimpiady = SelectedOlimpiadas;
				_formularz.ObliczWskaznikiRekrutacyjne(_context.Kierunki.ToArray());
                return View("Wynik", _formularz);
            }
            return RedirectToAction("Results");
        }

        // GET: /KalkulatorWskaznikaIStController/Results
        public ActionResult Results()
		{
            return View(_formularz);
        }
	}
}
