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
		public ActionResult Index(FormularzRekrutacyjnyISt formularz, List<Olimpiada> SelectedOlimpiadas)
		{
            if (ModelState.IsValid)
			{
				formularz.ObliczWskaznikiRekrutacyjne(_context.Kierunki.ToArray());
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
				var model = formularz.WskaznikiRekrutacyjne
					.GroupBy(wynik => wynik.Item1.WydzialId)
					.Select(group => new
					{
						Wydzial = _context.Wydzialy.FirstOrDefault(w => w.WydzialId == group.Key),
						Wskazniki = group.ToArray()
					})
					.OrderBy(item => item.Wydzial.WydzialId)
					.ToArray();

				return View(model);
			}
			else
			{
				return RedirectToAction(nameof(Index));
			}
		}

    }
}
