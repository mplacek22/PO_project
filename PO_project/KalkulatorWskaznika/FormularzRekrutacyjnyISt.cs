using PO_project.Enums;
using PO_project.Models;

namespace PO_project.KalkulatorWskaznika
{
	public class FormularzRekrutacyjnyISt : FormularzRekrutacyjny
	{
		Dictionary<Matura, int> WynikiZMatur { get; set; }
		double WynikEgzaminuZRysunku { get; set; } = 0;
		Olimpiada[] Olimpiady { get; set; }
		Dictionary<StudiumTalent, double> WynikiStudiumTalent { get; set; }


		public void ObliczWskaznikiRekrutacyjne(Kierunek[] kierunki)
		{
			WskaznikiRekrutacyjne = kierunki.Select(kierunek => (kierunek.Name, KalkulatorWskaznikaIStopnia.CalculateWskaznikRekrutacyjny(WynikiZMatur, WynikiStudiumTalent, Olimpiady, kierunek))).ToArray();
		}
	}


}
