using System.ComponentModel.DataAnnotations;

namespace PO_project.Models
{
    public class Pracodawca
    {
        public int PracodawcaId { get; set; }

        [Required]
        public String CompanyName { get; set; } = string.Empty;
        public string? Description { get; set; } = null;
        public string? Link { get; set; } = null;

        public List<KierunekPerspektywy> Perpektywy { get; } = new();
        public List<KierunekPraktyki> Praktyki { get; } = new();
        public List<KierunekMiejscaPracy> MiejscaPracy { get; } = new();

        public int AdresId { get; set; }
        public Adres adres { get; set; } = null!;
    }
}
