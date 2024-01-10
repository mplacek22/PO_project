using PO_project.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace PO_project.Models
{
    public class Kierunek
    {   
        public int KierunekId { get; set; }

        [Required, NotNull]
        [MaxLength(255)]
        public string Name { get; set; } = string.Empty;

        [Required, NotNull]
        [MinLength(1)]
        [MaxLength(10)]
        public string Abbreviation { get; set; } = string.Empty;

        [AllowNull]
        public string? Description { get; set; } = null;

        [Required, NotNull]
        public int JezykId { get; set; }
        public Jezyk Jezyk { get; set; } = null!;

        [Required, NotNull]
        public int StopienId { get; set; }
        public Stopien Stopien { get; set; } = null!;

        [Required, NotNull]
        public int TrybId { get; set; }
        public Tryb Tryb { get; set; } = null!;

        [Required, NotNull]
        public int CzasTrwaniaId { get; set; }
        public CzasTrwania CzasTrwania { get; set; } = null!;

        [Required, NotNull]
        public int WydzialId { get; set; }
        public Wydzial Wydzial { get; set; } = null!;

        public List<HistoryczneDane> HistoryczneDane { get; } = new();

        public List<Specjalizacja> Specjalizacje { get; } = new();

        public List<KierunekPerspektywy> Perpektywy { get; } = new();

        public List<KierunekPraktyki> Praktyki { get; } = new();

        public List<KierunekMiejscaPracy> MiejscaPracy { get; } = new();

        public string OlimpiadyString { get; set; } = string.Empty;

        public bool RysunekRequired { get; set; } = false;

        public bool BiologiaRequired { get; set; } = false;

        [NotMapped]
        public Olimpiada[] Olimpiady
        {
            get
            {
                if (OlimpiadyString == string.Empty || OlimpiadyString == null)
                {
                    return Array.Empty<Olimpiada>();
                }
                return OlimpiadyString.Split(',').Select(olimpiada => (Olimpiada)Enum.Parse(typeof(Olimpiada), olimpiada)).ToArray();
            }
            set
            {
                OlimpiadyString = string.Join(',', value.Select(olimpiada => olimpiada.ToString()));
            }
        }

        public string PrzedmiotyDodatkoweString { get; set; } = string.Empty;

        [NotMapped]
        public Matura[] PrzedmiotyDodatkowe
        {
            get
            {
                return string.IsNullOrEmpty(PrzedmiotyDodatkoweString) ? Array.Empty<Matura>() : PrzedmiotyDodatkoweString.Split(',')
                    .Select(przedmiot => (Matura)Enum.Parse(typeof(Matura), przedmiot))
                    .ToArray();
            }
            set
            {
                PrzedmiotyDodatkoweString = string.Join(',', value.Select(przedmiot => przedmiot.ToString()));
            }
        }

        public int MaxWskaznikRekrutacyjny { get; set; } = 535;
    }
}
