using PO_project.Enums;
using System.ComponentModel.DataAnnotations;

namespace PO_project.KalkulatorWskaznika
{
    public class WynikStudiumTalent
    {
        public StudiumTalent Przedmiot { get; set; }

        [Range(3, 5.5)]
        public double? Wynik { get; set; }
    }
}
