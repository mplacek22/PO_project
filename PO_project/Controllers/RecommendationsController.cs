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
                    ProbabilityOfAdmission = CalculateChancesOfAdmission(wynik.Item1, wynik.Item2),
					AvgPointThreshold = CalculateAvgPointThreshold(wynik.Item1),
					CancdidateRecruitmentIndicator = wynik.Item2,
				})
					.OrderByDescending(model => model.ProbabilityOfAdmission)
					.ToArray();
				return View(model);
			}
			return NotFound();
			
		}

		private double CalculateAvgPointThreshold(Kierunek course)
		{
			var historicalData = _context.HistoryczneDane.Where(dane => dane.KierunekId == course.KierunekId).ToList();
			if (!historicalData.IsNullOrEmpty())
			{
				return historicalData.Average(d => d.PointThreshold);
			}
			return -1;
		}

        private double CalculateChancesOfAdmission(Kierunek course, double recruitmentIndicator)
		{
			// Extract data from the database depending on which course the candidate is applying for
			var historicalData = _context.HistoryczneDane.Where(dane => dane.KierunekId == course.KierunekId).ToArray();
			var thresholds = historicalData.Select(dane => dane.PointThreshold).ToList();
			var numberOfPeoplePerSpot = historicalData.Select(dane => dane.CandidatesPerSpot).ToList();

			// Calculating the statistical threshold that will be in the nearest recruitment
			var statisticalIndicator = 0.0;

			for (int i = 0; i < thresholds.Count; i++)
			{
				statisticalIndicator += thresholds[i] * numberOfPeoplePerSpot[i];
			}

			statisticalIndicator /= numberOfPeoplePerSpot.Sum();

			// Getting the probability of admission
			double probability = recruitmentIndicator / statisticalIndicator;

			return probability;
		}
	}
}
