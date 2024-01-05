using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace PO_project.Models
{
    [PrimaryKey(nameof(Year), nameof(KierunekId))]
    public class HistoryczneDane
    {
        public int Year { get; set; }

        [Required, NotNull]
        public double PointThreshold { get; set; }
        public double CandidatesPerSpot { get; set; }

        [Required]
        public int KierunekId { get; set; }
        public Kierunek Kierunek { get; set; } = null!;

    }
}
