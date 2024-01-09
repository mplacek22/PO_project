using PO_project.Enums;
using PO_project.KalkulatorWskaznika;
using PO_project.Models;

namespace PO_project.Tests
{
    public class RecruitmentIndicatorCalculatorFirstCycle
    {
        [Fact]
        public void Test_Olimpijczyk_ReturnsMaxRecruitmnentIndex()
        {
            var wynikiMatur = Enum.GetValues(typeof(Matura)).Cast<Matura>().ToDictionary(m => m, m => new WynikMatury());
            var wynikiStudiumTalent = Enum.GetValues(typeof(StudiumTalent)).Cast<StudiumTalent>().Select(st => new WynikStudiumTalent() { Przedmiot = st, Wynik = null }).ToArray();
            List<Olimpiada> wynikiOlimpiad = new() { Olimpiada.Informatyka };
            Kierunek kierunek = new() { Olimpiady = new Olimpiada[] { Olimpiada.Informatyka, Olimpiada.Fizyczna } };
            double result = KalkulatorWskaznikaIStopnia.CalculateWskaznikRekrutacyjny(wynikiMatur, wynikiStudiumTalent, wynikiOlimpiad, kierunek, 0);

            Assert.Equal(kierunek.MaxWskaznikRekrutacyjny, result);
        }

        [Fact]
        public void Test_RegularCandidate()
        {
            var wynikiMatur = new Dictionary<Matura, WynikMatury>
            {
                { Matura.Matematyka, new WynikMatury { Podstawa = 80, Rozszerzenie = 70 } },
                { Matura.JezykPolski, new WynikMatury { Podstawa = 90, Rozszerzenie = 0 } },
                { Matura.Biologia, new WynikMatury { Podstawa = 0, Rozszerzenie = 0} },
                { Matura.Chemia, new WynikMatury { Podstawa = 0, Rozszerzenie = 0 } },
                { Matura.Historia, new WynikMatury { Podstawa = 0, Rozszerzenie = 0 } },
                { Matura.WiedzaOSpoleczenstwie, new WynikMatury { Podstawa = 0, Rozszerzenie = 0 } },
                { Matura.Fizyka, new WynikMatury { Podstawa = 0, Rozszerzenie = 70 } },
                { Matura.Informatyka, new WynikMatury { Podstawa = 0, Rozszerzenie = 87 } },
                { Matura.Geografia, new WynikMatury { Podstawa = 0, Rozszerzenie = 0 } },
                { Matura.JezykObcy, new WynikMatury { Podstawa = 92, Rozszerzenie = 91 } }
            };

            var wynikiStudiumTalent = Enum.GetValues(typeof(StudiumTalent)).Cast<StudiumTalent>().Select(st => new WynikStudiumTalent() { Przedmiot = st, Wynik = null }).ToArray();
            List<Olimpiada> wynikiOlimpiad = new() { Olimpiada.Biologiczna };
            Kierunek kierunek = new() { 
                Olimpiady = new Olimpiada[] { Olimpiada.Informatyka, Olimpiada.Fizyczna },
                PrzedmiotyDodatkowe = new Matura[] { Matura.Informatyka, Matura.Fizyka }
            };
            double result = KalkulatorWskaznikaIStopnia.CalculateWskaznikRekrutacyjny(wynikiMatur, wynikiStudiumTalent, wynikiOlimpiad, kierunek, 0);

            Assert.Equal(434.35, result);
        }

        [Fact]
        public void Test_CandidateWithZeroScores()
        {
            var wynikiMatur = Enum.GetValues(typeof(Matura)).Cast<Matura>().ToDictionary(m => m, m => new WynikMatury());
            var wynikiStudiumTalent = Enum.GetValues(typeof(StudiumTalent)).Cast<StudiumTalent>().Select(st => new WynikStudiumTalent() { Przedmiot = st, Wynik = null }).ToArray();
            List<Olimpiada> wynikiOlimpiad = new();
            Kierunek kierunek = new() { 
                Olimpiady = new Olimpiada[] { Olimpiada.Informatyka, Olimpiada.Fizyczna },
                PrzedmiotyDodatkowe = new Matura[] { Matura.Informatyka, Matura.Fizyka }
            };
            double result = KalkulatorWskaznikaIStopnia.CalculateWskaznikRekrutacyjny(wynikiMatur, wynikiStudiumTalent, wynikiOlimpiad, kierunek, 0);

            Assert.Equal(0, result);
        }

        [Fact]
        public void Test_ArchitectureCandidateWithDrawingExam()
        {
            var wynikiMatur = new Dictionary<Matura, WynikMatury>
            {
                { Matura.Matematyka, new WynikMatury { Podstawa = 80, Rozszerzenie = 70 } },
                { Matura.JezykPolski, new WynikMatury { Podstawa = 90, Rozszerzenie = 0 } },
                { Matura.Biologia, new WynikMatury { Podstawa = 0, Rozszerzenie = 0} },
                { Matura.Chemia, new WynikMatury { Podstawa = 0, Rozszerzenie = 0 } },
                { Matura.Historia, new WynikMatury { Podstawa = 0, Rozszerzenie = 0 } },
                { Matura.WiedzaOSpoleczenstwie, new WynikMatury { Podstawa = 0, Rozszerzenie = 0 } },
                { Matura.Fizyka, new WynikMatury { Podstawa = 0, Rozszerzenie = 70 } },
                { Matura.Informatyka, new WynikMatury { Podstawa = 0, Rozszerzenie = 87 } },
                { Matura.Geografia, new WynikMatury { Podstawa = 0, Rozszerzenie = 0 } },
                { Matura.JezykObcy, new WynikMatury { Podstawa = 92, Rozszerzenie = 91 } }
            };

            var wynikiStudiumTalent = Enum.GetValues(typeof(StudiumTalent)).Cast<StudiumTalent>().Select(st => new WynikStudiumTalent() { Przedmiot = st, Wynik = null }).ToArray();
            List<Olimpiada> wynikiOlimpiad = new() { Olimpiada.Biologiczna };
            Kierunek kierunek = new()
            {
                Name = "Architektura",
                PrzedmiotyDodatkowe = new Matura[] { Matura.Fizyka },
                RysunekRequired = true,
                MaxWskaznikRekrutacyjny = 1195
            };
           
            double result = KalkulatorWskaznikaIStopnia.CalculateWskaznikRekrutacyjny(wynikiMatur, wynikiStudiumTalent, wynikiOlimpiad, kierunek, 450);

            Assert.Equal(841.85, result);
        }

        [Fact]
        public void Test_CandidateScoresExceedingMaxLimit()
        {
            var wynikiMatur = Enum.GetValues(typeof(Matura)).Cast<Matura>().ToDictionary(m => m, m => new WynikMatury() { Podstawa = 100, Rozszerzenie = 100});
            var wynikiStudiumTalent = Enum.GetValues(typeof(StudiumTalent)).Cast<StudiumTalent>().Select(st => new WynikStudiumTalent() { Przedmiot = st, Wynik = 5.5 }).ToArray();
            List<Olimpiada> wynikiOlimpiad = new();
            Kierunek kierunek = new()
            {
                PrzedmiotyDodatkowe = new Matura[] { Matura.Fizyka, Matura.Biologia }
            };

            double result = KalkulatorWskaznikaIStopnia.CalculateWskaznikRekrutacyjny(wynikiMatur, wynikiStudiumTalent, wynikiOlimpiad, kierunek, 0);

            Assert.Equal(kierunek.MaxWskaznikRekrutacyjny, result);
        }

        [Fact]
        public void ValidateInput_InvalidMaturaResultsCount_ThrowsArgumentException()
        {
            var wynikiZMatur = new Dictionary<Matura, WynikMatury>();
            var wynikiStudiumTalent = new WynikStudiumTalent[Enum.GetValues(typeof(StudiumTalent)).Length];
            var wynikiOlimpiad = new List<Olimpiada>();
            var kierunek = new Kierunek();
            int egzaminZRysunku = 100;

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => KalkulatorWskaznikaIStopnia.CalculateWskaznikRekrutacyjny(wynikiZMatur, wynikiStudiumTalent, wynikiOlimpiad, kierunek, egzaminZRysunku));
            Assert.Equal("Wyniki z matur muszą zawierać wyniki z każdego przedmiotu", ex.Message);
        }

        [Fact]
        public void ValidateInput_InvalidStudiumTalentResultsCount_ThrowsArgumentException()
        {
            var wynikiZMatur = Enum.GetValues(typeof(Matura)).Cast<Matura>().ToDictionary(m => m, m => new WynikMatury() { Podstawa = 100, Rozszerzenie = 100 });
            var wynikiStudiumTalent = new WynikStudiumTalent[0];
            var wynikiOlimpiad = new List<Olimpiada>();
            var kierunek = new Kierunek();
            int egzaminZRysunku = 100;

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => KalkulatorWskaznikaIStopnia.CalculateWskaznikRekrutacyjny(wynikiZMatur, wynikiStudiumTalent, wynikiOlimpiad, kierunek, egzaminZRysunku));
            Assert.Equal("Wyniki ze studium talent muszą zawierać wyniki z każdego przedmiotu", ex.Message);
        }



    }
}
