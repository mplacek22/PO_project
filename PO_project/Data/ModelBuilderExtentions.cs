using Microsoft.EntityFrameworkCore;
using PO_project.Enums;
using PO_project.Models;

namespace PO_project.Data
{
    public static class ModelBuilderExtentions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            #region Adres
            modelBuilder.Entity<Adres>().HasData(
                new Adres()
                {
                    AdresId = 1,
                    City = "Wroclaw",
                    Street = "Grabiszynska",
                    PostCode = "50-030",
                    BuildingNumber = "4",
                },
                new Adres()
                {
                    AdresId = 2,
                    City = "Wroclaw",
                    Street = "Piekna",
                    PostCode = "51-518",
                    BuildingNumber = "219",
                },
                new Adres()
                {
                    AdresId = 3,
                    City = "Warszawa",
                    Street = "Gorna",
                    PostCode = "01-015",
                    BuildingNumber = "30",
                }
            );
            #endregion

            #region Pracodawca
            modelBuilder.Entity<Pracodawca>().HasData(
                new Pracodawca()
                {
                    PracodawcaId = 1,
                    CompanyName = "Zdisław Firma",
                    Description = "Firma",
                    Link = "https://ZdzislawFirma.pl",
                    AdresId = 3
                },
                new Pracodawca()
                {
                    PracodawcaId = 2,
                    CompanyName = "Firma Budowlana",
                    AdresId = 2
                },
                new Pracodawca()
                {
                    PracodawcaId = 3,
                    CompanyName = "Warsztaty Moniki",
                    AdresId = 1
                }
            );
            #endregion

            #region Czas Trwania
            modelBuilder.Entity<CzasTrwania>().HasData(
                new CzasTrwania()
                {
                    CzasTrwaniaId = 1,
                    Value = 1.5
                },
                new CzasTrwania()
                {
                    CzasTrwaniaId = 2,
                    Value = 2
                },
                new CzasTrwania()
                {
                    CzasTrwaniaId = 3,
                    Value = 2.5
                },
                new CzasTrwania()
                {
                    CzasTrwaniaId = 4,
                    Value = 3
                },
                new CzasTrwania()
                {
                    CzasTrwaniaId = 5,
                    Value = 3.5
                },
                new CzasTrwania()
                {
                    CzasTrwaniaId = 6,
                    Value = 4
                },
                new CzasTrwania()
                {
                    CzasTrwaniaId = 7,
                    Value = 4.5
                },
                new CzasTrwania()
                {
                    CzasTrwaniaId = 8,
                    Value = 5
                }
            );
            #endregion

            #region Jezyk
            modelBuilder.Entity<Jezyk>().HasData(
                new Jezyk()
                {
                    JezykId = 1,
                    Name = "Polski"
                },
                new Jezyk()
                {
                    JezykId = 2,
                    Name = "Angielski"
                }
                );
            #endregion

            #region Tryb
            modelBuilder.Entity<Tryb>().HasData(
                new Tryb()
                {
                    TrybId = 1,
                    Name = "Stacjonarny"
                },
                new Tryb()
                {
                    TrybId = 2,
                    Name = "Niestacjonarny"
                }
            );
            #endregion

            #region Stopien
            modelBuilder.Entity<Stopien>().HasData(
                new Stopien()
                {
                    StopienId = 1,
                    Name = "I"
                },
                new Stopien()
                {
                    StopienId = 2,
                    Name = "II"
                }
            );
            #endregion

            #region Lokalizacja
            modelBuilder.Entity<Lokalizacja>().HasData(
                new Lokalizacja()
                {
                    LokalizacjaId = 1,
                    Name = "Wroclaw"
                },
                new Lokalizacja()
                {
                    LokalizacjaId = 2,
                    Name = "Jelenia Góra"
                },
                new Lokalizacja()
                {
                    LokalizacjaId = 3,
                    Name = "Legnica"
                },
                new Lokalizacja()
                {
                    LokalizacjaId = 4,
                    Name = "Wałbrzych"
                }
            );
            #endregion

            #region Wydzial
            modelBuilder.Entity<Wydzial>().HasData(
                new Wydzial()
                {
                    WydzialId = 1,
                    Name = "Wydział Architektury",
                    Abbreviation = "W1",
                    LokalizacjaId = 1
                },
                new Wydzial()
                {
                    WydzialId = 2,
                    Name = "Wydział Budownictwa",
                    Abbreviation = "W2",
                    LokalizacjaId = 1
                },
                new Wydzial()
                {
                    WydzialId = 3,
                    Name = "Wydział Chemiczny",
                    Abbreviation = "W3",
                    LokalizacjaId = 1
                },
                new Wydzial()
                {
                    WydzialId = 4,
                    Name = "Wydział Informatyki i Telekomunikacji",
                    Abbreviation = "W4",
                    LokalizacjaId = 1
                },
                new Wydzial()
                {
                    WydzialId = 5,
                    Name = "Elektryczny",
                    Abbreviation = "W5",
                    LokalizacjaId = 1
                },
                new Wydzial()
                {
                    WydzialId = 6,
                    Name = "Inżynierii środowiska",
                    Abbreviation = "W7",
                    LokalizacjaId = 1
                },
                new Wydzial()
                {
                    WydzialId = 7,
                    Name = "Matematyki",
                    Abbreviation = "W13",
                    LokalizacjaId = 1
                }
            );
            #endregion

            #region Kierunek
            _ = modelBuilder.Entity<Kierunek>().HasData(
                new Kierunek()
                {
                    KierunekId = 1,
                    Name = "Informatyka Stosowana",
                    Abbreviation = "IST",
                    Description = "Najlepszy kierunek",
                    CzasTrwaniaId = 5,
                    JezykId = 1,
                    StopienId = 1,
                    TrybId = 1,
                    WydzialId = 4,
                    OlimpiadyString = $"{Olimpiada.Matematyczna},{Olimpiada.Fizyczna}",
                    PrzedmiotyDodatkoweString = $"{Matura.Fizyka},{Matura.Informatyka}"
                },
                new Kierunek()
                {
                    KierunekId = 2,
                    Name = "Architektura",
                    Abbreviation = "ARC",
                    Description = "Opis architektury.",
                    CzasTrwaniaId = 6,
                    JezykId = 1,
                    StopienId = 1,
                    TrybId = 1,
                    WydzialId = 1,
                    PrzedmiotyDodatkoweString = $"{Matura.Fizyka}"
                },
                new Kierunek()
                {
                    KierunekId = 3,
                    Name = "Applied Computer Science",
                    Abbreviation = "ISTA",
                    Description = "Second best one.",
                    CzasTrwaniaId = 5,
                    JezykId = 2,
                    StopienId = 1,
                    TrybId = 1,
                    WydzialId = 4,
                    PrzedmiotyDodatkoweString = $"{Matura.Fizyka},{Matura.Informatyka}"
                },
                new Kierunek()
                {
                    KierunekId = 4,
                    Name = "Budownictwo",
                    Abbreviation = "BUD-2",
                    Description = "",
                    CzasTrwaniaId = 4,
                    JezykId = 1,
                    StopienId = 2,
                    TrybId = 2,
                    WydzialId = 2,
                    PrzedmiotyDodatkoweString = $"{Matura.Fizyka}"
                },
                new Kierunek()
                {
                    KierunekId = 5,
                    Name = "Cyberbezpieczeństwo",
                    Abbreviation = "CBE",
                    Description = "",
                    CzasTrwaniaId = 4,
                    JezykId = 1,
                    StopienId = 1,
                    TrybId = 1,
                    WydzialId = 4,
                    PrzedmiotyDodatkoweString = $"{Matura.Fizyka},{Matura.Informatyka}"
                },
                new Kierunek()
                {
                    KierunekId = 6,
                    Name = "Energetyka",
                    Abbreviation = "ENG",
                    Description = "",
                    CzasTrwaniaId = 4,
                    JezykId = 1,
                    StopienId = 2,
                    TrybId = 2,
                    WydzialId = 2,
                    PrzedmiotyDodatkoweString = $"{Matura.Fizyka}"
                },
                new Kierunek()
                {
                    KierunekId = 7,
                    Name = "Matematyka",
                    Abbreviation = "MAT",
                    Description = "",
                    CzasTrwaniaId = 4,
                    JezykId = 1,
                    StopienId = 2,
                    TrybId = 2,
                    WydzialId = 7,
                    PrzedmiotyDodatkoweString = $"{Matura.Fizyka},{Matura.Informatyka}"

                },
                new Kierunek()
                {
                    KierunekId = 8,
                    Name = "Informatyczne systemy automatyki",
                    Abbreviation = "OPT",
                    Description = "",
                    CzasTrwaniaId = 4,
                    JezykId = 1,
                    StopienId = 2,
                    TrybId = 1,
                    WydzialId = 4,
                    PrzedmiotyDodatkoweString = $"{Matura.Fizyka},{Matura.Informatyka}"
                },
                new Kierunek()
                {
                    KierunekId = 9,
                    Name = "Informatyka algorytmiczna",
                    Abbreviation = "OPT",
                    Description = "",
                    CzasTrwaniaId = 4,
                    JezykId = 1,
                    StopienId = 1,
                    TrybId = 1,
                    WydzialId = 4,
                    PrzedmiotyDodatkoweString = $"{Matura.Fizyka},{Matura.Informatyka}"
                },
                new Kierunek()
                {
                    KierunekId = 10,
                    Name = "Inżynieria systemów",
                    Abbreviation = "OPT",
                    Description = "",
                    CzasTrwaniaId = 4,
                    JezykId = 1,
                    StopienId = 1,
                    TrybId = 1,
                    WydzialId = 4,
                    PrzedmiotyDodatkoweString = $"{Matura.Fizyka},{Matura.Informatyka}"
                },
                new Kierunek()
                {
                    KierunekId = 11,
                    Name = "Telekomunikacja",
                    Abbreviation = "OPT",
                    Description = "",
                    CzasTrwaniaId = 4,
                    JezykId = 1,
                    StopienId = 2,
                    TrybId = 1,
                    WydzialId = 4,
                    PrzedmiotyDodatkoweString = $"{Matura.Fizyka},{Matura.Informatyka}"
                }
            );
            #endregion

            #region Specjalizacje
            modelBuilder.Entity<Specjalizacja>().HasData(
                new Specjalizacja()
                {
                    SpecjalizacjaId = 1,
                    Name = "Budownictwo Lądowe",
                    Description = "Opis budownictwa lądowego",
                    KierunekId = 4
                }
                );
            #endregion

            #region Historyczne Dane
            modelBuilder.Entity<HistoryczneDane>().HasData(
                 new HistoryczneDane()
                 {
                     Year = 2020,
                     PointThreshold = 370,
                     CandidatesPerSpot = 2,
                     KierunekId = 1
                 },
                 new HistoryczneDane()
                 {
                     Year = 2020,
                     PointThreshold = 360,
                     CandidatesPerSpot = 1.85,
                     KierunekId = 2
                 },
                 new HistoryczneDane()
                 {
                     Year = 2020,
                     PointThreshold = 200,
                     CandidatesPerSpot = 1.05,
                     KierunekId = 3
                 },
                 new HistoryczneDane()
                 {
                     Year = 2021,
                     PointThreshold = 400,
                     CandidatesPerSpot = 2,
                     KierunekId = 1
                 },
                 new HistoryczneDane()
                 {
                     Year = 2022,
                     PointThreshold = 430,
                     CandidatesPerSpot = 2.6,
                     KierunekId = 1
                 }
             );
            #endregion

            #region Kierunek-Perspektywy
            modelBuilder.Entity<KierunekPerspektywy>().HasData(
                new KierunekPerspektywy()
                {
                    KierunekId = 1,
                    PracodawcaId = 1,
                },
                new KierunekPerspektywy()
                {
                    KierunekId = 2,
                    PracodawcaId = 1,
                },
                new KierunekPerspektywy()
                {
                    KierunekId = 1,
                    PracodawcaId = 2,
                },
                new KierunekPerspektywy()
                {
                    KierunekId = 1,
                    PracodawcaId = 3,
                },
                new KierunekPerspektywy()
                {
                    KierunekId = 2,
                    PracodawcaId = 2,
                },
                new KierunekPerspektywy()
                {
                    KierunekId = 4,
                    PracodawcaId = 2,
                },
                new KierunekPerspektywy()
                {
                    KierunekId = 4,
                    PracodawcaId = 1,
                },
                new KierunekPerspektywy()
                {
                    KierunekId = 3,
                    PracodawcaId = 1,
                }
            );
            #endregion

            #region Kierunek-Praktyki
            modelBuilder.Entity<KierunekPraktyki>().HasData(
                new KierunekPraktyki()
                {
                    KierunekId = 1,
                    PracodawcaId = 2,
                },
                new KierunekPraktyki()
                {
                    KierunekId = 2,
                    PracodawcaId = 2,
                },
                new KierunekPraktyki()
                {
                    KierunekId = 3,
                    PracodawcaId = 2,
                },
                new KierunekPraktyki()
                {
                    KierunekId = 4,
                    PracodawcaId = 2,
                },
                new KierunekPraktyki()
                {
                    KierunekId = 5,
                    PracodawcaId = 2,
                },
                new KierunekPraktyki()
                {
                    KierunekId = 1,
                    PracodawcaId = 1,
                },
                new KierunekPraktyki()
                {
                    KierunekId = 5,
                    PracodawcaId = 3
                },
                new KierunekPraktyki()
                {
                    KierunekId = 4,
                    PracodawcaId = 3,
                },
                new KierunekPraktyki()
                {
                    KierunekId = 4,
                    PracodawcaId = 1,
                },
                new KierunekPraktyki()
                {
                    KierunekId = 2,
                    PracodawcaId = 1,
                }
            );
            #endregion

            #region Kierunek-Miejsca Pracy
            modelBuilder.Entity<KierunekMiejscaPracy>().HasData(
                new KierunekMiejscaPracy()
                {
                    KierunekId = 1,
                    PracodawcaId = 1
                }
            );
            #endregion

        }
    }
}
