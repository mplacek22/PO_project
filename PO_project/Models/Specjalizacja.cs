using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace PO_project.Models
{
    public class Specjalizacja
    {
        public int SpecjalizacjaId { get; set; }

        [Required]
        [MaxLength(100)]
        public String Name { get; set; } = String.Empty;

        public String? Description { get; set; }

        [Required, NotNull]
        public int KierunekId { get; set; }
        public Kierunek kierunek { get; set; } = null!;
    }
}
