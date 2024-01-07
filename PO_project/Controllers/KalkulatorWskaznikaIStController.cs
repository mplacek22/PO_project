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
            // Retrieve _formularz from TempData and deserialize it
            var formularzJson = TempData["Formularz"] as string;

            if (formularzJson != null)
            {
                var formularz = Newtonsoft.Json.JsonConvert.DeserializeObject<FormularzRekrutacyjnyISt>(formularzJson);
                return View(formularz);
            }
            else
            {
                // Handle the case where TempData does not contain the JSON string
                // (e.g., redirect to the Index action)
                return RedirectToAction(nameof(Index));
            }
        }

    }
}
