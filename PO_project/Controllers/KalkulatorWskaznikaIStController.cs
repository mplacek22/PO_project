using Microsoft.AspNetCore.Mvc;
using PO_project.Data;
using PO_project.Enums;
using PO_project.KalkulatorWskaznika;

namespace PO_project.Controllers
{
    public class KalkulatorWskaznikaIStController : Controller
	{
		private readonly PwrDbContext _context;

		public KalkulatorWskaznikaIStController(PwrDbContext context)
		{
			_context = context;
		}

        // GET: /KalkulatorWskaznikaIStController/Index
        public ActionResult Index()
		{
            var formularz = new FormularzRekrutacyjnyISt();
            return View(formularz);
		}

        // POST: /KalkulatorWskaznikaIStController/Index
        [HttpPost]
		public ActionResult Index(FormularzRekrutacyjnyISt formularz, List<Olimpiada> selectedOlimpiadas)
		{
            if (ModelState.IsValid)
			{
				formularz.Olimpiady = selectedOlimpiadas;
				formularz.ObliczWskaznikiRekrutacyjne(_context.Kierunki.Where(k => k.Stopien.Name == "I").ToArray()); //todo: change to enum
               TempData["Formularz"] = Newtonsoft.Json.JsonConvert.SerializeObject(formularz);
                return RedirectToAction(nameof(Results));
            }
            return View(formularz);
        }

        // GET: /KalkulatorWskaznikaIStController/Results
        public ActionResult Results()
        {

			if (TempData["Formularz"] is string formularzJson)
			{
				var formularz = Newtonsoft.Json.JsonConvert.DeserializeObject<FormularzRekrutacyjnyISt>(formularzJson);
                if (formularz != null)
                {
                    var model = formularz?.WskaznikiRekrutacyjne
                        .GroupBy(wynik => wynik.Item1.WydzialId)
                        .Select(group => new
                        {
                            Wydzial = _context.Wydzialy.FirstOrDefault(w => w.WydzialId == group.Key),
                            Wskazniki = group.ToArray()
                        })
                        .OrderBy(item => item.Wydzial!.WydzialId)
                        .ToArray();
                    TempData["WskaznikiRekrutacyjne"] = Newtonsoft.Json.JsonConvert.SerializeObject(formularz?.WskaznikiRekrutacyjne);
                    return View(model);
                }
            }
			return RedirectToAction(nameof(Index));
        }

		// GET: /KalkulatorWskaznikaIStController/Recommendations
		public ActionResult Recommendations()
		{
			return RedirectToAction(nameof(RecommendationsController.Index), "Recommendations");
		}

    }
}
