using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PO_project.Models
{
    [PrimaryKey(nameof(KierunekId), nameof(PracodawcaId))]
    public class KierunekMiejscaPracy
    {
        public int KierunekId { get; set; }
        public Kierunek Kierunek { get; set; } = null!;

        public int PracodawcaId { get; set; }
        public Pracodawca Pracodawca { get; set; } = null!;
    }
}
