using PO_project.Controllers;
using PO_project.Data;
using PO_project.Enums;
using PO_project.Models;
using PO_project.RecrutationCalc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.EntityFrameworkCore.InMemory;

using Xunit;

namespace PO_project.Tests
{

    public class QuestionTests
    {
        private PwrDbContext _context = new PwrDbContext(new DbContextOptionsBuilder<PwrDbContext>()
            .UseInMemoryDatabase(databaseName: "PWRDb")
            .Options);

        [Fact]
        public void TestPytanieControllerIndex()
        {
            var controller = new PytanieController(_context);

            var result = controller.Index(1);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IQueryable<Pytanie>>(
                viewResult.ViewData.Model);
        }

        [Fact]
        public void TestCountPytanieController()
        {
            _context.Pytania.Add(new Pytanie { PytanieId = 1 });
            _context.SaveChanges();

            Assert.Equal(1, _context.Pytania.Count());
        }

        [Theory]
        [InlineData(-2, 0)]
        [InlineData(-1, 0)]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 3)]
        [InlineData(4, 4)]
        [InlineData(5, 4)]
        [InlineData(6, 4)]
        public void TestIndexPytanieController(int input, int expected)
        {
            var controller = new PytanieController(_context);

            var result = controller.Index(input);

            Assert.Equal(expected, controller.getCurrentQuestionIndex());
        }


        [Theory]
        [InlineData(13, 1, 4, 1, 1)]
        [InlineData(14, 2, 2, 2, 1)]
        [InlineData(15, 1, 1, 1, 1)]
        [InlineData(16, 0, 0, 0, 0)]
        [InlineData(12, 0, 0, 0, 0)]
        [InlineData(-1, 0, 0, 0, 0)]
        [InlineData(0, 0, 0, 0, 0)]
        public void TestRecomendations(int input, int expectedStopienId, int expectedWydzialId, int expectedTrybId, int expectedJezykId)
        {
            var controller = new PytanieController(_context);

            var result = controller.Recomendations(input);

            // if wrong input it should just return the whole list
            if (input == 13 || input == 14 || input == 15)
            {
                var viewResult = Assert.IsType<ViewResult>(result);
                var model = Assert.IsAssignableFrom<List<Kierunek>>(viewResult.ViewData.Model);
                Assert.Single(model);
                Assert.All(model, k =>
                {
                    Assert.Equal(expectedStopienId, k.StopienId);
                    Assert.Equal(expectedWydzialId, k.WydzialId);
                    Assert.Equal(expectedTrybId, k.TrybId);
                    Assert.Equal(expectedJezykId, k.JezykId);
                });
            }
            else
            {
                var viewResult = Assert.IsType<ViewResult>(result);
                var model = Assert.IsAssignableFrom<List<Kierunek>>(viewResult.ViewData.Model);
                Assert.Equal(_context.Kierunki.Count(), model.Count);
                Assert.All(model, k =>
                {
                    Assert.Contains(k, _context.Kierunki);
                });
            }
        }


    }
}