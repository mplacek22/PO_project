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

    public class UnitTest1
    {
        private PwrDbContext _context;

        public UnitTest1()
        {
            var options = new DbContextOptionsBuilder<PwrDbContext>()
                .UseInMemoryDatabase(databaseName: "PWRDb")
                .Options;

            _context = new PwrDbContext(options);
        }

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


    }
}