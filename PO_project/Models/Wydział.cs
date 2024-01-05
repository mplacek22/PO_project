using System.ComponentModel.DataAnnotations;

namespace PO_project.Models
{
    public class Wydzial
    {
        public int WydzialId { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Abbreviation {  get; set; } = string.Empty;

        [Required]
        public int? LokalizacjaId { get; set; }
        public Lokalizacja Lokalizacja { get; set; } = null!;
    }
}
