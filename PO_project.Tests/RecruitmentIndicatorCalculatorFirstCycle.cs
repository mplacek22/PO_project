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
            List<Olimpiada> wynikiOlimpiad = new() { Olimpiada.Informatyczna };
            Kierunek kierunek = new() { Olimpiady = new Olimpiada[] { Olimpiada.Informatyczna, Olimpiada.Fizyczna } };
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
            Kierunek kierunek = new()
            {
                Olimpiady = new Olimpiada[] { Olimpiada.Informatyczna, Olimpiada.Fizyczna },
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
            Kierunek kierunek = new()
            {
                Olimpiady = new Olimpiada[] { Olimpiada.Informatyczna, Olimpiada.Fizyczna },
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
            var wynikiMatur = Enum.GetValues(typeof(Matura)).Cast<Matura>().ToDictionary(m => m, m => new WynikMatury() { Podstawa = 100, Rozszerzenie = 100 });
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

            var ex = Assert.Throws<ArgumentException>(() => KalkulatorWskaznikaIStopnia.CalculateWskaznikRekrutacyjny(wynikiZMatur, wynikiStudiumTalent, wynikiOlimpiad, kierunek, egzaminZRysunku));
            Assert.Equal("Wyniki ze studium talent muszą zawierać wyniki z każdego przedmiotu", ex.Message);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(1000)]
        public void ValidateInput_InvalidDrawingExamScore_ThrowsArgumentException(int data)
        {
            var wynikiMatur = Enum.GetValues(typeof(Matura)).Cast<Matura>().ToDictionary(m => m, m => new WynikMatury() { Podstawa = 100, Rozszerzenie = 100 });
            var wynikiStudiumTalent = Enum.GetValues(typeof(StudiumTalent)).Cast<StudiumTalent>().Select(st => new WynikStudiumTalent() { Przedmiot = st, Wynik = 5.5 }).ToArray();
            List<Olimpiada> wynikiOlimpiad = new();
            Kierunek kierunek = new()
            {
                PrzedmiotyDodatkowe = new Matura[] { Matura.Fizyka, Matura.Biologia }
            };

            var ex = Assert.Throws<ArgumentException>(() => KalkulatorWskaznikaIStopnia.CalculateWskaznikRekrutacyjny(wynikiMatur, wynikiStudiumTalent, wynikiOlimpiad, kierunek, data));
            Assert.Equal("Wynik z egzaminu z rysunku musi mieścić się w zakresie od 0 do 660", ex.Message);
        }

        [Theory]
        [InlineData(-1, 50)]
        [InlineData(101, 50)]
        [InlineData(50, -1)]
        [InlineData(50, 101)] 
        public void ValidateInput_InvalidMaturaScores_ThrowsArgumentException(int baseScore, int extensionScore)
        {
            var wynikiZMatur = new Dictionary<Matura, WynikMatury>
            {
                { Matura.Matematyka, new WynikMatury { Podstawa = baseScore, Rozszerzenie = extensionScore } },
                { Matura.JezykPolski, new WynikMatury { Podstawa = 50, Rozszerzenie = 50 } },
                { Matura.Biologia, new WynikMatury { Podstawa = 0, Rozszerzenie = 0} },
                { Matura.Chemia, new WynikMatury { Podstawa = 0, Rozszerzenie = 0 } },
                { Matura.Historia, new WynikMatury { Podstawa = 0, Rozszerzenie = 0 } },
                { Matura.WiedzaOSpoleczenstwie, new WynikMatury { Podstawa = 0, Rozszerzenie = 0 } },
                { Matura.Fizyka, new WynikMatury { Podstawa = 0, Rozszerzenie = 70 } },
                { Matura.Informatyka, new WynikMatury { Podstawa = 0, Rozszerzenie = 87 } },
                { Matura.Geografia, new WynikMatury { Podstawa = 0, Rozszerzenie = 0 } },
                { Matura.JezykObcy, new WynikMatury { Podstawa = 92, Rozszerzenie = 91 } }
            };
            var wynikiStudiumTalent = new WynikStudiumTalent[Enum.GetValues(typeof(StudiumTalent)).Length];
            foreach (var talent in Enum.GetValues(typeof(StudiumTalent)).Cast<StudiumTalent>())
            {
                wynikiStudiumTalent[(int)talent] = new WynikStudiumTalent { Wynik = 3.5 };
            }
            var wynikiOlimpiad = new List<Olimpiada>();
            var kierunek = new Kierunek();
            int egzaminZRysunku = 100;

            var exception = Assert.Throws<ArgumentException>(() => KalkulatorWskaznikaIStopnia.CalculateWskaznikRekrutacyjny(wynikiZMatur, wynikiStudiumTalent, wynikiOlimpiad, kierunek, egzaminZRysunku));
            Assert.Equal("Wyniki z matur muszą mieścić się w zakresie od 0 do 100", exception.Message);
        }


        [Theory]
        [InlineData(2.0)]
        [InlineData(6.0)]
        [InlineData(3.1)]
        [InlineData(5.4)]
        public void ValidateInput_InvalidStudiumTalentScores_ThrowsArgumentException(double? score)
        {
            var wynikiStudiumTalent = StudiumTalent.GetValues(typeof(StudiumTalent)).Cast<StudiumTalent>().Select(st => new WynikStudiumTalent() { Przedmiot = st, Wynik = score }).ToArray();
            var wynikiZMatur = new Dictionary<Matura, WynikMatury>();
            foreach (var matura in Enum.GetValues(typeof(Matura)).Cast<Matura>())
            {
                wynikiZMatur[matura] = new WynikMatury { Podstawa = 50, Rozszerzenie = 50 };
            }
            var wynikiOlimpiad = new List<Olimpiada>();
            var kierunek = new Kierunek();
            int egzaminZRysunku = 100;

            var exception = Assert.Throws<ArgumentException>(() => KalkulatorWskaznikaIStopnia.CalculateWskaznikRekrutacyjny(wynikiZMatur, wynikiStudiumTalent, wynikiOlimpiad, kierunek, egzaminZRysunku));
            Assert.Contains("Wynik ze Studium Talent musi być liczbą ze zbioru {3.0, 3.5, 4.0, 5.0, 5.5}", exception.Message);
        }
    }
}
