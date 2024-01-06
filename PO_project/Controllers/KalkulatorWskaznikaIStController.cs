using Microsoft.AspNetCore.Mvc;
using PO_project.Data;
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

		// GET: /YourController/Index
		public ActionResult Index()
		{
			return View(_formularz);
		}
	}
}
