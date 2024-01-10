using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PO_project.Data;
using PO_project.Models;
using PO_project.Recommendations;

namespace PO_project.Controllers
{
	public class RecommendationsController : Controller
	{
		private readonly PwrDbContext _context;

		public RecommendationsController(PwrDbContext context)
		{
			_context = context;
		}

		// GET: /RecomendationsController/Index
		public IActionResult Index()
		{
			if (TempData["WskaznikiRekrutacyjne"] is string wskaznikiJson)
			{
				var wskaznikiRekrutacyjne = Newtonsoft.Json.JsonConvert.DeserializeObject<(Kierunek, double)[]>(wskaznikiJson);
				if (wskaznikiRekrutacyjne.IsNullOrEmpty())
				{
                    return NotFound();
                }
				var model = wskaznikiRekrutacyjne.Select(wynik => new RecommendationViewModel
				{
					CourseId = wynik.Item1.KierunekId,
					Course = wynik.Item1.Name,
					Description = wynik.Item1.Description,
                    ProbabilityOfAdmission = RecommendationViewModel.CalculateProbabilityOfAdmission(_context.HistoryczneDane.Where(dane => dane.KierunekId == wynik.Item1.KierunekId).ToArray(), wynik.Item2),
					AvgPointThreshold = RecommendationViewModel.CalculateAvgPointThreshold(_context.HistoryczneDane.Where(dane => dane.KierunekId == wynik.Item1.KierunekId).ToArray()),
					CancdidateRecruitmentIndicator = wynik.Item2,
				})
					.OrderByDescending(model => model.ProbabilityOfAdmission)
					.ToArray();
				return View(model);
			}
			return NotFound();
			
		}
    }
}
