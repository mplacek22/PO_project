using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PO_project.Data;
using PO_project.Models;
using PO_project.Recomendations;

namespace PO_project.Controllers
{
	public class RecomendationsController : Controller
	{
		private readonly PwrDbContext _context;

		public RecomendationsController(PwrDbContext context)
		{
			_context = context;
		}

		// GET: /RecomendationsController/Index
		public IActionResult Index()
		{
			if (TempData["WskaznikiRekrutacyjne"] is string wskaznikiJson)
			{
				(Kierunek, double)[] wskaznikiRekrutacyjne = Newtonsoft.Json.JsonConvert.DeserializeObject<(Kierunek, double)[]>(wskaznikiJson);
				if (wskaznikiRekrutacyjne.IsNullOrEmpty())
				{
                    return NotFound();
                }
				var model = wskaznikiRekrutacyjne.Select(wynik => new RecomendationViewModel
				{
					CourseId = wynik.Item1.KierunekId,
					Course = wynik.Item1.Name,
					Description = wynik.Item1.Description,
					ChancesOfGettingIn = CalculateChancesOfGettingIn(wynik.Item1, wynik.Item2),
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

		private string CalculateChancesOfGettingIn(Kierunek course, double recruitmentIndicator)
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

			// Depending on the probability, we provide information on the possibility of admission
			if (probability < 0.9)
			{
				return "Niskie prawdopodobieństwo dostania się";
			}
			else if (probability == 0.9)
			{
				return "Warto spróbować, gdyż jest szansa dostania się";
			}
			else if (probability > 1.1)
			{
				return "Wysokie prawdopodobieństwo dostania się";
			}
			else
			{
				return "---";
			}
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
