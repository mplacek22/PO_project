namespace PO_project.Models
{
    public class Pracodawca
    {
        public int PracodawcaId { get; set; }

        public List<KierunekPerspektywy> Perpektywy { get; } = new();
        public List<KierunekPraktyki> Praktyki { get; } = new();
        public List<KierunekMiejscaPracy> MiejscaPracy { get; } = new();

        public int? AdresId { get; set; } = null;
        public Adres? adres { get; set; } = null;
    }
}
