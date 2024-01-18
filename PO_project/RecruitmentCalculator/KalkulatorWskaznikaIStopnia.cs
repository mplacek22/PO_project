using PO_project.Enums;
using PO_project.Models;

namespace PO_project.RecruitmentCalculator
{
    public class KalkulatorWskaznikaIStopnia
    {
        public static double CalculateWskaznikRekrutacyjny(Dictionary<Matura, WynikMatury> wynikiZMatur, Dictionary<StudiumTalent, double> wynikiStudiumTalent, IEnumerable<Olimpiada> wynikiOlimpiad, Kierunek kierunek, int egzaminZRysunku)
		{
            var olimpiady = wynikiOlimpiad as Olimpiada[] ?? wynikiOlimpiad.ToArray();
            ValidateInput(wynikiZMatur, wynikiStudiumTalent, olimpiady, kierunek, egzaminZRysunku);
            if (IsOlimpijczyk(olimpiady, kierunek.Olimpiady))
            {
                return kierunek.MaxWskaznikRekrutacyjny;
            }

            double wskaznik = 0;

			//lekarski
			if(kierunek.BiologiaRequired)
			{
                if (wynikiZMatur[Matura.Biologia].Rozszerzenie == 0)
				{
                    return 0;
                }
				wskaznik += CalculateSubjectScore(wynikiZMatur[Matura.Biologia]);
            }

			//architektura
			if (kierunek.RysunekRequired)
			{
                if (egzaminZRysunku == 0)
				{
                    return 0;
                }
                wskaznik += egzaminZRysunku;
            }

			var M = CalculateSubjectScore(wynikiZMatur[Matura.Matematyka]);
			var PD = kierunek.PrzedmiotyDodatkowe.Max(przedmiot => CalculateSubjectScore(wynikiZMatur[przedmiot]));

			if (M == 0 || PD == 0)
			{
				return 0;
			}

            var JP = CalculateSubjectScore(wynikiZMatur[Matura.JezykPolski]);
            var JO = CalculateSubjectScore(wynikiZMatur[Matura.JezykObcy]);
            var studiumTalent = wynikiStudiumTalent.Max(wynik => wynik.Value);
            wskaznik += M + PD + 0.1 * JO + 0.1 * JP + 10 * studiumTalent;
            return Math.Min(Math.Round(wskaznik, 2), kierunek.MaxWskaznikRekrutacyjny);
		}

		private static double CalculateSubjectScore(WynikMatury wynik)
		{
            return Math.Max(Math.Max(wynik.Podstawa, wynik.Podstawa + 1.5 * wynik.Rozszerzenie), 2.5 * wynik.Rozszerzenie);
        }

		private static bool IsOlimpijczyk(IEnumerable<Olimpiada> wynikiOlimpiad, IEnumerable<Olimpiada> olimpiadyZaliczane)
		{
			return wynikiOlimpiad.Intersect(olimpiadyZaliczane).Any();
		}

        private static void ValidateInput(Dictionary<Matura, WynikMatury> wynikiZMatur, Dictionary<StudiumTalent, double> wynikiStudiumTalent, IEnumerable<Olimpiada> wynikiOlimpiad, Kierunek kierunek, int egzaminZRysunku)
        {
            if (wynikiZMatur.Count != Enum.GetValues(typeof(Matura)).Length)
            {
                throw new ArgumentException("Wyniki z matur muszą zawierać wyniki z każdego przedmiotu");
            }
            if (wynikiStudiumTalent.Count != Enum.GetValues(typeof(StudiumTalent)).Length)
            {
                throw new ArgumentException("Wyniki ze studium talent muszą zawierać wyniki z każdego przedmiotu");
            }
            if (egzaminZRysunku is < 0 or > 660)
            {
                throw new ArgumentException("Wynik z egzaminu z rysunku musi mieścić się w zakresie od 0 do 660");
            }
            if (wynikiZMatur.Values.Any(wynik => wynik.Podstawa < 0 || wynik.Podstawa > 100 || wynik.Rozszerzenie < 0 || wynik.Rozszerzenie > 100))
            {
                throw new ArgumentException("Wyniki z matur muszą mieścić się w zakresie od 0 do 100");
            }
            
            if (wynikiStudiumTalent.Any(w => !FormularzRekrutacyjnyISt.ValidScores.Contains(w.Value)))
            {
                throw new ArgumentException("Wynik ze Studium Talent musi być liczbą ze zbioru {0.0, 3.0, 3.5, 4.0, 5.0, 5.5}\nWynik 0.0 oznacza brak udziału w Studium Talent");
            }
        }
    }
}
    