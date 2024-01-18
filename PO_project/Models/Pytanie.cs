using System.ComponentModel.DataAnnotations;

namespace PO_project.Models
{
    public class Pytanie
    {
        public int PytanieId { get; set; }

        [Required]
        public string Tresc { get; set; } = string.Empty;

        public List<Odpowiedz> Odpowiedzi{ get; } = new();

    }
}
