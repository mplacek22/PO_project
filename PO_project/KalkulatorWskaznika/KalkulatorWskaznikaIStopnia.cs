using PO_project.Enums;
using PO_project.Models;

namespace PO_project.KalkulatorWskaznika
{
    public class KalkulatorWskaznikaIStopnia
    {
        public const int MAX_WSKAZNIK_REKRUTACYJNY = 535;
        public const int MAX_WSKAZNIK_REKRUTACYJNY_ARCHIEKTURA = 1195;
		public const int MAX_WSKAZNIK_REKRUTACYJNY_LEKARSKI = 785;
		

        public static double CalculateWskaznikRekrutacyjny(Dictionary<Matura, WynikMatury> wynikiZMatur, WynikStudiumTalent[] wynikiStudiumTalent, IEnumerable<Olimpiada> wynikiOlimpiad, Kierunek kierunek, int egzaminZRysunku)
		{
            ValidateInput(wynikiZMatur, wynikiStudiumTalent, wynikiOlimpiad, kierunek, egzaminZRysunku);
            if (IsOlimpijczyk(wynikiOlimpiad, kierunek.Olimpiady))
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

			double M = CalculateSubjectScore(wynikiZMatur[Matura.Matematyka]);
			double PD = kierunek.PrzedmiotyDodatkowe.Max(przedmiot => CalculateSubjectScore(wynikiZMatur[przedmiot]));

			if (M == 0 || PD == 0)
			{
				return 0;
			}

            double JP = CalculateSubjectScore(wynikiZMatur[Matura.JezykPolski]);
            double JO = CalculateSubjectScore(wynikiZMatur[Matura.JezykObcy]);
            double? studiumTalent = wynikiStudiumTalent.Max(wynik => wynik.Wynik);
            wskaznik += M + PD + 0.1 * JO + 0.1 * JP + 10 * (studiumTalent ?? 0);
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

        private static void ValidateInput(Dictionary<Matura, WynikMatury> wynikiZMatur, WynikStudiumTalent[] wynikiStudiumTalent, IEnumerable<Olimpiada> wynikiOlimpiad, Kierunek kierunek, int egzaminZRysunku)
        {
            if (wynikiZMatur.Count != Enum.GetValues(typeof(Matura)).Length)
            {
                throw new ArgumentException("Wyniki z matur muszą zawierać wyniki z każdego przedmiotu");
            }
            if (wynikiStudiumTalent.Length != Enum.GetValues(typeof(StudiumTalent)).Length)
            {
                throw new ArgumentException("Wyniki ze studium talent muszą zawierać wyniki z każdego przedmiotu");
            }
            if (wynikiOlimpiad == null)
            {
                throw new ArgumentNullException("Wyniki z olimpiad nie mogą być null");
            }
            if (kierunek == null)
            {
                throw new ArgumentNullException("Kierunek nie może być null");
            }
            if (egzaminZRysunku < 0 || egzaminZRysunku > 660)
            {
                throw new ArgumentException("Wynik z egzaminu z rysunku musi mieścić się w zakresie od 0 do 660");
            }
            if (wynikiZMatur.Values.Any(wynik => wynik.Podstawa < 0 || wynik.Podstawa > 100 || wynik.Rozszerzenie < 0 || wynik.Rozszerzenie > 100))
            {
                throw new ArgumentException("Wyniki z matur muszą mieścić się w zakresie od 0 do 100");
            }
            if (wynikiStudiumTalent.Where(w => w.Wynik != null).Any(wynik => wynik.Wynik != 3.0 || wynik.Wynik != 3.5 || wynik.Wynik != 4.0 || wynik.Wynik != 5.0 || wynik.Wynik != 5.5))
            {
                throw new ArgumentException("Wynik ze Studium Talent być liczbą ze zbioru {3,0; 3,5;4,0; 5,0; 5,5}");
            }
        }
	}
}
    