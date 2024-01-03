using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PO_project.Models
{
    [PrimaryKey(nameof(Year), nameof(KierunekId))]
    public class HistoryczneDane
    {
        public int Year { get; set; }
        public double PointThreshold { get; set; }
        public double CandidatesPerSpot { get; set; }

        public int KierunekId { get; set; }
        public Kierunek? Kierunek { get; set; }

    }
}
