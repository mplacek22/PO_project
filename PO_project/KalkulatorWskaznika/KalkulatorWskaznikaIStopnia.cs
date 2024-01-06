using PO_project.Enums;
using PO_project.Models;

namespace PO_project.KalkulatorWskaznika
{
    public class KalkulatorWskaznikaIStopnia
    {
        public const int MAX_WSKAZNIK_REKRUTACYJNY = 535;

		public static double CalculateWskaznikRekrutacyjny(Dictionary<Matura, int> wynikiZMatur, Dictionary<StudiumTalent, double> wynikiStudiumTalent, Olimpiada[] wynikiOlimpiad, Kierunek kierunek)
		{
			if (IsOlimpijczyk(wynikiOlimpiad, kierunek.Olimpiady))
			{
				return MAX_WSKAZNIK_REKRUTACYJNY;
			}

			double M = CalculateSubjectScore(wynikiZMatur[Matura.MatematykaP], wynikiZMatur[Matura.MatematykaR]);
			double JP = CalculateSubjectScore(wynikiZMatur[Matura.JezykPolskiP], wynikiZMatur[Matura.JezykPolskiR]);
			double JO = CalculateSubjectScore(wynikiZMatur[Matura.JezykObcyP], wynikiZMatur[Matura.JezykObcyR]);
			double PD = kierunek.PrzedmiotyDodatkowe.Max(przedmiot => CalculateSubjectScore(wynikiZMatur[przedmiot.Item1], wynikiZMatur[przedmiot.Item2]));

			if (M == 0 && PD == 0)
			{
				return 0;
			}

			var studiumTalent = wynikiStudiumTalent.Values.Max() < 3.0 ? 0 : wynikiStudiumTalent.Values.Max();

			return Math.Min(M + PD + 0.1 * JO + 0.1 * JP + 10 * studiumTalent, MAX_WSKAZNIK_REKRUTACYJNY);
		}

		private static double CalculateSubjectScore(int P, int R)
        {
            return Math.Max(Math.Max(P, P + 1.5 * R), 2.5 * R);
        }

        public static bool IsOlimpijczyk(bool[] wynikiOlimpiad, Olimpiada[] olimpiady)
        {
			return wynikiOlimpiad.Select((wynik, index) => wynik && olimpiady.Contains((Olimpiada)index)).Any();
		}

		public static bool IsOlimpijczyk(Olimpiada[] wynikiOlimpiad, Olimpiada[] olimpiadyZaliczane)
		{
			return wynikiOlimpiad.Intersect(olimpiadyZaliczane).Any();
		}
	}
}
    