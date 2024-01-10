using Moq;
using PO_project.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PO_project.Models;

namespace PO_project.Tests
{
    public class RecommendationsControllerFixture
    {
        public PwrDbContext DbContext { get; private set; }

        public RecommendationsControllerFixture()
        {
            var options = new DbContextOptionsBuilder<PwrDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            DbContext = new PwrDbContext(options);
        }

        private void SeedDatabase()
        {
            DbContext.Stopnie.Add(new Stopien { StopienId = 1, Name = "I" });
            DbContext.Stopnie.Add(new Stopien { StopienId = 2, Name = "II" });

            DbContext.Tryby.Add(new Tryb { TrybId = 1, Name = "Stacjonarny" });
            DbContext.Tryby.Add(new Tryb { TrybId = 2, Name = "Niestacjonarny" });

            for (var i = 0; i < 5; i++)
            {
                DbContext.Wydzialy.Add(new Wydzial() { WydzialId = i });
            }

            DbContext.Kierunki.Add(new Kierunek { KierunekId = 1, StopienId = 1, TrybId = 1 });
            DbContext.Kierunki.Add(new Kierunek { KierunekId = 2, Name = "", StopienId = 2, TrybId = 2 });

            DbContext.SaveChanges();
        }

        public void SeedWithHistoricalData()
        {
            DbContext.Kierunki.Add(new Kierunek() { KierunekId = 1 });
            DbContext.Kierunki.Add(new Kierunek() { KierunekId = 2 });
            DbContext.HistoryczneDane.Add(new HistoryczneDane()
            {
                CandidatesPerSpot = 20,
                KierunekId = 1,
                PointThreshold = 300.25,
                Year = 2023
            });
            DbContext.HistoryczneDane.Add(new HistoryczneDane()
            {
                CandidatesPerSpot = 34,
                KierunekId = 1,
                PointThreshold = 350.25,
                Year = 2022
            });
            DbContext.HistoryczneDane.Add(new HistoryczneDane()
            {
                CandidatesPerSpot = 10,
                KierunekId = 1,
                PointThreshold = 300,
                Year = 2021
            });
            DbContext.HistoryczneDane.Add(new HistoryczneDane()
            {
                CandidatesPerSpot = 15,
                KierunekId = 2,
                PointThreshold = 400,
                Year = 2023
            });
        }
    }
}
