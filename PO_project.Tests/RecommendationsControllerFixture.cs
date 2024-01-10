using PO_project.Data;
using Microsoft.EntityFrameworkCore;

namespace PO_project.Tests;

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
}