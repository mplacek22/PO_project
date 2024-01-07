using PO_project.Enums;
using PO_project.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PO_project.KalkulatorWskaznika
{
	public class FormularzRekrutacyjnyISt
	{
        public (Kierunek, double)[] WskaznikiRekrutacyjne { get; set; } = Array.Empty<(Kierunek, double)>();

        public Dictionary<Matura, WynikMatury> WynikiZMatur{ get; set; } = Enum.GetValues(typeof(Matura)).Cast<Matura>().ToDictionary(m => m, m => new WynikMatury());

        [Range(0, 660, ErrorMessage = "Wynik z egzaminu z rysunku musi mieścić się w zakresie od 0 do 660")]
		public int WynikEgzaminuZRysunku { get; set; } = 0;

		[NotMapped]
		public List<Olimpiada> Olimpiady { get; set; } = new List<Olimpiada>();

		[NotMapped]
		public Dictionary<StudiumTalent, double> WynikiStudiumTalent { get; set; } = Enum.GetValues(typeof(StudiumTalent)).Cast<StudiumTalent>().ToDictionary(st => st, st => 0.0);

		public void ObliczWskaznikiRekrutacyjne(Kierunek[] kierunki)
		{
			WskaznikiRekrutacyjne = kierunki.Select(kierunek => (kierunek, KalkulatorWskaznikaIStopnia.CalculateWskaznikRekrutacyjny(WynikiZMatur, WynikiStudiumTalent, Olimpiady, kierunek, WynikEgzaminuZRysunku))).ToArray();
		}
	}
}
