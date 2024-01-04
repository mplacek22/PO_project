using Microsoft.EntityFrameworkCore;
using PO_project.Models;

namespace PO_project.Data
{
    public static class ModelBuilderExtentions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
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
            modelBuilder.Entity<Pracodawca>().HasData(
                new Pracodawca()
                {
                    PracodawcaId = 1,
                    AdresId = 3
                },
                new Pracodawca()
                {
                    PracodawcaId = 2,
                    AdresId = 2
                },
                new Pracodawca()
                {
                    PracodawcaId = 3,
                    AdresId = 1
                }
            );
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

            //modelBuilder.Entity<HistoryczneDane>().HasData(
            //    new HistoryczneDane() 
            //    {
            //        Year = 2020,
            //        PointThreshold = 370,
            //        CandidatesPerSpot = 2,
            //        KierunekId = 1
            //    },
            //    new HistoryczneDane()
            //    {
            //        Year = 2020,
            //        PointThreshold = 360,
            //        CandidatesPerSpot = 1.85,
            //        KierunekId = 2
            //    },
            //    new HistoryczneDane()
            //    {
            //        Year = 2020,
            //        PointThreshold = 200,
            //        CandidatesPerSpot = 1.05,
            //        KierunekId = 3
            //    },
            //    new HistoryczneDane()
            //    {
            //        Year = 2021,
            //        PointThreshold = 400,
            //        CandidatesPerSpot = 2,
            //        KierunekId = 1
            //    },
            //    new HistoryczneDane()
            //    {
            //        Year = 2022,
            //        PointThreshold = 430,
            //        CandidatesPerSpot = 2.6,
            //        KierunekId = 1
            //    }
            //);

        }
    }
}
