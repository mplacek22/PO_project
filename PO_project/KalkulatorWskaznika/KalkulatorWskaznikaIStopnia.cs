using PO_project.Enums;
using PO_project.Models;

namespace PO_project.KalkulatorWskaznika
{
    public class KalkulatorWskaznikaIStopnia
    {
        public const int MAX_WSKAZNIK_REKRUTACYJNY = 535;

		public static double CalculateWskaznikRekrutacyjny(WynikMatury[] wynikiZMatur, Dictionary<StudiumTalent, double> wynikiStudiumTalent, List<Olimpiada> wynikiOlimpiad, Kierunek kierunek)
		{
			if (IsOlimpijczyk(wynikiOlimpiad, kierunek.Olimpiady))
			{
				return MAX_WSKAZNIK_REKRUTACYJNY;
			}

			double M = CalculateSubjectScore(wynikiZMatur.First(w => w.Subject == Matura.Matematyka));
			double JP = CalculateSubjectScore(wynikiZMatur.First(w => w.Subject == Matura.JezykPolski));
            double JO = CalculateSubjectScore(wynikiZMatur.First(w => w.Subject == Matura.JezykObcy));
            double PD = kierunek.PrzedmiotyDodatkowe.Max(przedmiot => CalculateSubjectScore(wynikiZMatur.First(w => w.Subject == przedmiot)));

			if (M == 0 && PD == 0)
			{
				return 0;
			}

			var studiumTalent = wynikiStudiumTalent.Values.Max() < 3.0 ? 0 : wynikiStudiumTalent.Values.Max();

			return Math.Min(M + PD + 0.1 * JO + 0.1 * JP + 10 * studiumTalent, MAX_WSKAZNIK_REKRUTACYJNY);
		}

		private static double CalculateSubjectScore(WynikMatury wynik)
		{
            return Math.Max(Math.Max(wynik.Podstawa, wynik.Podstawa + 1.5 * wynik.Rozszerzenie), 2.5 * wynik.Rozszerzenie);
        }

		private static bool IsOlimpijczyk(List<Olimpiada> wynikiOlimpiad, Olimpiada[] olimpiadyZaliczane)
		{
			return wynikiOlimpiad.Intersect(olimpiadyZaliczane).Any();
		}
	}
}
    