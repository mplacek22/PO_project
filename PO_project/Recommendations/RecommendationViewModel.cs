using Microsoft.IdentityModel.Tokens;
using PO_project.Models;

namespace PO_project.Recommendations
{
	public class RecommendationViewModel
    {
        public const double Low = 0.9;
        public const double High = 1.1;
        public int CourseId { get; set; }

		public string Course { get; set; } = string.Empty;

		public string Description { get; set; } = string.Empty;

        public double AvgPointThreshold { get; set; }

		public double CancdidateRecruitmentIndicator { get; set; }

        public double ProbabilityOfAdmission { get; set; }

        public List<Kierunek>? AnkietaResults { get; set; }

        public string ChancesOfGettingIn
        {
            get
            {

                Console.WriteLine($"{CourseId}: {ProbabilityOfAdmission}");
                return ProbabilityOfAdmission switch
                {
                var p when p < Low => "Niskie prawdopodobieństwo dostania się",
                    var p when Math.Abs(p - Low) < 0.1 => "Warto spróbować, gdyż jest szansa dostania się",
                    var p when p > High => "Wysokie prawdopodobieństwo dostania się",
                    _ => "---",
                };
            }
        }

        public static double CalculateAvgPointThreshold(HistoryczneDane[] historicalData)
        {
            if (!historicalData.IsNullOrEmpty())
            {
                return historicalData.Average(d => d.PointThreshold);
            }
            return -1;
        }

        public static double CalculateProbabilityOfAdmission(HistoryczneDane[] historicalData, double recruitmentIndicator)
        {
	        var thresholds = historicalData.Select(dane => dane.PointThreshold).ToList();
            var numberOfPeoplePerSpot = historicalData.Select(dane => dane.CandidatesPerSpot).ToList();

            var statisticalIndicator = thresholds.Select((t, i) => t * numberOfPeoplePerSpot[i]).Sum();

            statisticalIndicator /= numberOfPeoplePerSpot.Sum();

            var probability = recruitmentIndicator / statisticalIndicator;

            return probability;
        }
    }
}
