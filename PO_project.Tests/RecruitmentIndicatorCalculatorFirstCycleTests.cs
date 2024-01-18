using PO_project.Enums;
using PO_project.Models;
using PO_project.RecruitmentCalculator;

namespace PO_project.Tests
{
    public class RecruitmentIndicatorCalculatorFirstCycleTests
    {
        [Fact]
        public void Test_Olimpijczyk_ReturnsMaxRecruitmnentIndex()
        {
            var wynikiMatur = Enum.GetValues(typeof(Matura)).Cast<Matura>().ToDictionary(m => m, _ => new WynikMatury());
            var wynikiStudiumTalent = Enum.GetValues(typeof(StudiumTalent)).Cast<StudiumTalent>()
                .ToDictionary(st => st, _ => 0.0);
            List<Olimpiada> wynikiOlimpiad = new() { Olimpiada.Informatyczna };
            Kierunek kierunek = new() { Olimpiady = new[] { Olimpiada.Informatyczna, Olimpiada.Fizyczna } };
            var result = KalkulatorWskaznikaIStopnia.CalculateWskaznikRekrutacyjny(wynikiMatur, wynikiStudiumTalent, wynikiOlimpiad, kierunek, 0);

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

            var wynikiStudiumTalent = Enum.GetValues(typeof(StudiumTalent)).Cast<StudiumTalent>()
                .ToDictionary(st => st, _ => 0.0); List<Olimpiada> wynikiOlimpiad = new() { Olimpiada.Biologiczna };
            Kierunek kierunek = new()
            {
                Olimpiady = new[] { Olimpiada.Informatyczna, Olimpiada.Fizyczna },
                PrzedmiotyDodatkowe = new[] { Matura.Informatyka, Matura.Fizyka }
            };
            double result = KalkulatorWskaznikaIStopnia.CalculateWskaznikRekrutacyjny(wynikiMatur, wynikiStudiumTalent, wynikiOlimpiad, kierunek, 0);

            Assert.Equal(434.35, result);
        }

        [Fact]
        public void Test_CandidateWithZeroScores()
        {
            var wynikiMatur = Enum.GetValues(typeof(Matura)).Cast<Matura>().ToDictionary(m => m, _ => new WynikMatury());
            var wynikiStudiumTalent = Enum.GetValues(typeof(StudiumTalent)).Cast<StudiumTalent>().ToDictionary(st => st, _ => 0.0);
            var wynikiOlimpiad = new List<Olimpiada>();
            Kierunek kierunek = new()
            {
                Olimpiady = new[] { Olimpiada.Informatyczna, Olimpiada.Fizyczna },
                PrzedmiotyDodatkowe = new[] { Matura.Informatyka, Matura.Fizyka }
            };
            var result = KalkulatorWskaznikaIStopnia.CalculateWskaznikRekrutacyjny(wynikiMatur, wynikiStudiumTalent, wynikiOlimpiad, kierunek, 0);

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

            var wynikiStudiumTalent = Enum.GetValues(typeof(StudiumTalent)).Cast<StudiumTalent>().ToDictionary(st => st, _ => 0.0);
            List<Olimpiada> wynikiOlimpiad = new() { Olimpiada.Biologiczna };
            Kierunek kierunek = new()
            {
                Name = "Architektura",
                PrzedmiotyDodatkowe = new[] { Matura.Fizyka },
                RysunekRequired = true,
                MaxWskaznikRekrutacyjny = 1195
            };

            var result = KalkulatorWskaznikaIStopnia.CalculateWskaznikRekrutacyjny(wynikiMatur, wynikiStudiumTalent, wynikiOlimpiad, kierunek, 450);

            Assert.Equal(841.85, result);
        }

        [Fact]
        public void Test_CandidateScoresExceedingMaxLimit()
        {
            var wynikiMatur = Enum.GetValues(typeof(Matura)).Cast<Matura>().ToDictionary(m => m, _ => new WynikMatury() { Podstawa = 100, Rozszerzenie = 100 });
            var wynikiStudiumTalent = Enum.GetValues(typeof(StudiumTalent)).Cast<StudiumTalent>()
                .ToDictionary(st => st, _ => FormularzRekrutacyjnyISt.ValidScores.Max()); List<Olimpiada> wynikiOlimpiad = new();
            Kierunek kierunek = new()
            {
                PrzedmiotyDodatkowe = new[] { Matura.Fizyka, Matura.Biologia }
            };

            var result = KalkulatorWskaznikaIStopnia.CalculateWskaznikRekrutacyjny(wynikiMatur, wynikiStudiumTalent, wynikiOlimpiad, kierunek, 0);

            Assert.Equal(kierunek.MaxWskaznikRekrutacyjny, result);
        }

        [Fact]
        public void ValidateInput_InvalidMaturaResultsCount_ThrowsArgumentException()
        {
            var wynikiZMatur = new Dictionary<Matura, WynikMatury>();
            var wynikiStudiumTalent = Enum.GetValues(typeof(StudiumTalent)).Cast<StudiumTalent>()
                .ToDictionary(st => st, _ => 0.0);
            var wynikiOlimpiad = new List<Olimpiada>();
            var kierunek = new Kierunek();
            var egzaminZRysunku = 100;

            var ex = Assert.Throws<ArgumentException>(() => KalkulatorWskaznikaIStopnia.CalculateWskaznikRekrutacyjny(wynikiZMatur, wynikiStudiumTalent, wynikiOlimpiad, kierunek, egzaminZRysunku));
            Assert.Equal("Wyniki z matur muszą zawierać wyniki z każdego przedmiotu", ex.Message);
        }

        [Fact]
        public void ValidateInput_InvalidStudiumTalentResultsCount_ThrowsArgumentException()
        {
            var wynikiZMatur = Enum.GetValues(typeof(Matura)).Cast<Matura>().ToDictionary(m => m, m => new WynikMatury() { Podstawa = 100, Rozszerzenie = 100 });
            var wynikiStudiumTalent = new Dictionary<StudiumTalent, double>();
            var wynikiOlimpiad = new List<Olimpiada>();
            var kierunek = new Kierunek();
            var egzaminZRysunku = 100;

            var ex = Assert.Throws<ArgumentException>(() => KalkulatorWskaznikaIStopnia.CalculateWskaznikRekrutacyjny(wynikiZMatur, wynikiStudiumTalent, wynikiOlimpiad, kierunek, egzaminZRysunku));
            Assert.Equal("Wyniki ze studium talent muszą zawierać wyniki z każdego przedmiotu", ex.Message);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(1000)]
        public void ValidateInput_InvalidDrawingExamScore_ThrowsArgumentException(int data)
        {
            var wynikiMatur = Enum.GetValues(typeof(Matura)).Cast<Matura>().ToDictionary(m => m, m => new WynikMatury() { Podstawa = 100, Rozszerzenie = 100 });
            var wynikiStudiumTalent = Enum.GetValues(typeof(StudiumTalent)).Cast<StudiumTalent>()
                .ToDictionary(st => st, _ => 0.0); List<Olimpiada> wynikiOlimpiad = new();
            Kierunek kierunek = new()
            {
                PrzedmiotyDodatkowe = new[] { Matura.Fizyka, Matura.Biologia }
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
            var wynikiStudiumTalent = Enum.GetValues(typeof(StudiumTalent)).Cast<StudiumTalent>()
                .ToDictionary(st => st, _ => 3.0);
            var wynikiOlimpiad = new List<Olimpiada>();
            var kierunek = new Kierunek();
            var egzaminZRysunku = 100;

            var exception = Assert.Throws<ArgumentException>(() => KalkulatorWskaznikaIStopnia.CalculateWskaznikRekrutacyjny(wynikiZMatur, wynikiStudiumTalent, wynikiOlimpiad, kierunek, egzaminZRysunku));
            Assert.Equal("Wyniki z matur muszą mieścić się w zakresie od 0 do 100", exception.Message);
        }


        [Theory]
        [InlineData(2.0)]
        [InlineData(6.0)]
        [InlineData(3.1)]
        [InlineData(5.4)]
        public void ValidateInput_InvalidStudiumTalentScores_ThrowsArgumentException(double score)
        {
            var wynikiStudiumTalent = Enum.GetValues(typeof(StudiumTalent)).Cast<StudiumTalent>()
                .ToDictionary(st => st, _ => score); 
            var wynikiZMatur = new Dictionary<Matura, WynikMatury>();
            foreach (var matura in Enum.GetValues(typeof(Matura)).Cast<Matura>())
            {
                wynikiZMatur[matura] = new WynikMatury { Podstawa = 50, Rozszerzenie = 50 };
            }
            var wynikiOlimpiad = new List<Olimpiada>();
            var kierunek = new Kierunek();
            var egzaminZRysunku = 100;

            var exception = Assert.Throws<ArgumentException>(() => KalkulatorWskaznikaIStopnia.CalculateWskaznikRekrutacyjny(wynikiZMatur, wynikiStudiumTalent, wynikiOlimpiad, kierunek, egzaminZRysunku));
            Assert.Contains("Wynik ze Studium Talent musi być liczbą ze zbioru {0.0, 3.0, 3.5, 4.0, 5.0, 5.5}\nWynik 0.0 oznacza brak udziału w Studium Talent", exception.Message);
        }
    }
}
