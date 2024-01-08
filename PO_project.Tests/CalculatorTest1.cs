using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PO_project.Controllers;
using PO_project.Data;
using PO_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO_project.Tests
{
    public class CalculatorTest1
    {
        private PwrDbContext _context = new PwrDbContext(new DbContextOptionsBuilder<PwrDbContext>()
            .UseInMemoryDatabase(databaseName: "PWRDb")
            .Options);

        [Fact]
        public void DbTest()
        {
            _context.Stopnie.Add(new Stopien { StopienId = 1, Name = "I" });
            _context.Stopnie.Add(new Stopien { StopienId = 2, Name = "II" });
            _context.Tryby.Add(new Tryb { TrybId = 1, Name = "Stacjonarny" });
            _context.Tryby.Add(new Tryb { TrybId = 2, Name = "Niestacjonarny" });
            _context.Kierunki.Add(new Kierunek { KierunekId = 1, StopienId = 1, TrybId = 1 });
            _context.Kierunki.Add(new Kierunek { KierunekId = 2, Name = "", StopienId = 2, TrybId = 2 });
            _context.SaveChanges();
            Assert.Equal(2, _context.Stopnie.Count());
        }

        [Fact]
        public void Test2()
        {
            var controller = new KierunekController(_context);

            var result = controller.Calculator(2, null, null);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Test3()
        {
            var controller = new KierunekController(_context);

            var result = controller.Calculator(1, null, null);

            Assert.IsType<ViewResult>(result);
        }
    }

}
