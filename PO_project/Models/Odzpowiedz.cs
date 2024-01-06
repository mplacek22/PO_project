using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace PO_project.Models
{
    public class Odzpowiedz
    {
        public int OdzpowiedzId { get; set; }

        public string Tresc { get; set; } = string.Empty;

        [Required, NotNull]
        public int PytanieId { get; set; }
        public Pytanie Pytanie { get; set; } = null!;
    }
}
