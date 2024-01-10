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
    public class RecomendationsControllerFixture
    {
        public PwrDbContext DbContext { get; private set; }

        public RecomendationsControllerFixture()
        {
            var options = new DbContextOptionsBuilder<PwrDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            DbContext = new PwrDbContext(options);

            // Seed the database with test data
            SeedDatabase(DbContext);

        }

        private void SeedDatabase(PwrDbContext dbContext)
        {
            // Add test data to dbContext
            // Example: dbContext.Kierunki.Add(new Kierunek { /* ... */ });

            dbContext.SaveChanges();
        }
    }
}
