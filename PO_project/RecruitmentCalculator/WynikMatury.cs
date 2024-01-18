using System.ComponentModel.DataAnnotations;

namespace PO_project.RecruitmentCalculator
{
    public class WynikMatury
    {
        [Range(0, 100)]
        public int Podstawa { get; set; } = 0;

        [Range(0, 100)]
        public int Rozszerzenie { get; set; } = 0;
    }
}
