namespace PO_project.Recomendations
{
	public class RecomendationViewModel
	{
		public int CourseId { get; set; }

        public string Course { get; set; } = string.Empty;

		public string Description { get; set; } = string.Empty;

		public string ChancesOfGettingIn { get; set; } = string.Empty;

		public double? AvgPointThreshold { get; set; }

		public double CancdidateRecruitmentIndicator { get; set; }

        public double ProbabilityOfAdmission { get; set; }
	}
}
