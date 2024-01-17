using Microsoft.EntityFrameworkCore;
using PO_project.Data;
using PO_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO_project.Tests
{
    public class TestDbSetup
    {

        private PwrDbContext _context = new PwrDbContext(new DbContextOptionsBuilder<PwrDbContext>()
            .UseInMemoryDatabase(databaseName: "PWRDb")
            .Options);

        [Fact]
        public void Setup()
        {
            _context.Stopnie.Add(new Stopien { StopienId = 1, Name = "I" });
            _context.Stopnie.Add(new Stopien { StopienId = 2, Name = "II" });
            _context.Tryby.Add(new Tryb { TrybId = 1, Name = "Stacjonarny" });
            _context.Tryby.Add(new Tryb { TrybId = 2, Name = "Niestacjonarny" });
            _context.Kierunki.Add(new Kierunek { KierunekId = 1, StopienId = 1, TrybId = 1, WydzialId = 1, JezykId = 1 });
            _context.Kierunki.Add(new Kierunek { KierunekId = 2, Name = "", StopienId = 2, TrybId = 2 });
            _context.Kierunki.Add(new Kierunek { KierunekId = 3, Name = "Budownictwo", StopienId = 2, TrybId = 2 });
            _context.Kierunki.Add(new Kierunek { KierunekId = 4, StopienId = 2, TrybId = 2, WydzialId = 2, JezykId = 1 });
            _context.Kierunki.Add(new Kierunek { KierunekId = 5, StopienId = 1, TrybId = 1, WydzialId = 4, JezykId = 1 });

            _context.SaveChanges();
        }
    }
}
