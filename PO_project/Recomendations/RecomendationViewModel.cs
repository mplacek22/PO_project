namespace PO_project.Recomendations
{
	public class RecomendationViewModel
    {
        public const double Low = 0.9;
        public const double High = 1.1;
        public int CourseId { get; set; }

		public string Course { get; set; } = string.Empty;

		public string Description { get; set; } = string.Empty;

        public double AvgPointThreshold { get; set; }

		public double CancdidateRecruitmentIndicator { get; set; }

        public double ProbabilityOfAdmission { get; set; }

        public string ChancesOfGettingIn
        {
            get
            {
                return ProbabilityOfAdmission switch
                {
                    var p when p < Low => "Niskie prawdopodobieństwo dostania się",
                    var p when Math.Abs(p - Low) < 0.0001 => "Warto spróbować, gdyż jest szansa dostania się",
                    var p when p > High => "Wysokie prawdopodobieństwo dostania się",
                    _ => "---",
                };
            }
        }
    }
}
