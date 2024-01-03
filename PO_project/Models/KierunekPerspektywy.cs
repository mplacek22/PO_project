using System.ComponentModel.DataAnnotations;

namespace PO_project.Models
{
    public class KierunekPerspektywy
    {
        [Key]
        public int KierunekId { get; set; }
        public Kierunek Kierunek { get; set; }

        [Key]
        public int PracodawcaId { get; set; }
        public Pracodawca Pracodawca { get; set;}
    }
}
