using System.ComponentModel.DataAnnotations;
using PO_project.Enums;

namespace PO_project.RecruitmentCalculator
{
    public class WynikStudiumTalent
    {
        public StudiumTalent Przedmiot { get; set; }

        [Range(3, 5.5)]
        public double? Wynik { get; set; }
    }
}
