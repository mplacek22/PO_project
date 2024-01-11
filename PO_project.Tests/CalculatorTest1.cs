using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PO_project.Controllers;
using PO_project.Data;
using PO_project.Models;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Reflection;
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
            Assert.Equal(2, _context.Stopnie.Count());
        }

        [Fact]
        public void NoCalculatorViewForBacheloreCourse_ReturnsNotFound()
        {
            var controller = new KierunekController(_context);

            var result = controller.Calculator(0, null, null);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void MastersCourse_ReturnsView()
        {
            var controller = new KierunekController(_context);

            var result = controller.Calculator(1, null, null);

            Assert.IsType<ViewResult>(result);
        }
    }

}
