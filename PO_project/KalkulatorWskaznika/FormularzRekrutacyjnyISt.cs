using PO_project.Enums;
using PO_project.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace PO_project.KalkulatorWskaznika
{
	public class FormularzRekrutacyjnyISt : FormularzRekrutacyjny
	{

		[NotMapped]
		Dictionary<Matura, int> WynikiZMatur { get; set; }

		double WynikEgzaminuZRysunku { get; set; } = 0;

		[NotMapped]
		Olimpiada[] Olimpiady { get; set; }

		[NotMapped]
		Dictionary<StudiumTalent, double> WynikiStudiumTalent { get; set; }

		public List<KeyValuePair<Matura, int>> WynikiMatur { get; set; }

		public FormularzRekrutacyjnyISt()
		{
            WynikiZMatur = new Dictionary<Matura, int>();
            Olimpiady = new Olimpiada[0];
            WynikiStudiumTalent = new Dictionary<StudiumTalent, double>();
            WynikiMatur = new List<KeyValuePair<Matura, int>>();
			foreach (Matura matura in Enum.GetValues(typeof(Matura)))
			{
				WynikiMatur.Add(new KeyValuePair<Matura, int>(matura, 0));
            }
        }


		public void ObliczWskaznikiRekrutacyjne(Kierunek[] kierunki)
		{
			WskaznikiRekrutacyjne = kierunki.Select(kierunek => (kierunek.Name, KalkulatorWskaznikaIStopnia.CalculateWskaznikRekrutacyjny(WynikiZMatur, WynikiStudiumTalent, Olimpiady, kierunek))).ToArray();
		}
	}


}
