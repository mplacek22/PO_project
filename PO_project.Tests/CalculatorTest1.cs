using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PO_project.Controllers;
using PO_project.Data;
using PO_project.Models;
using PO_project.RecrutationCalc;
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
        public void NoBacheloreCourse_ReturnsNotFound()
        {
            var controller = new KierunekController(_context);

            var result = controller.Calculator(0, null, null);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void NoCalculatorViewForBacheloreCourse_ReturnsDefaultView()
        {
            var controller = new KierunekController(_context);

            var result = controller.Calculator(4, null, null);

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsType<ValueTuple<Kierunek, double?, double?>>(viewResult.Model);
        }

        [Fact]
        public void BatcheloreDefaultCalculate_RedirectsWithCorrectData()
        {
            var controller = new KierunekController(_context);

            var result = controller.Calculate(2, 5, 4, null, null);

            var viewResult = Assert.IsType<RedirectToActionResult>(result);

            Assert.Equal("Calculator", viewResult.ActionName);
            var routeValues = viewResult.RouteValues!.Values.ToList();
            Assert.Equal(3, routeValues.Count);
            Assert.Equal((double)54, routeValues[1]);
            Assert.Equal((double)54, routeValues[2]);
        }

        [Fact]
        public void MastersCourse_ReturnsView()
        {
            var controller = new KierunekController(_context);

            var result = controller.Calculator(1, null, null);

            Assert.IsType<ViewResult>(result);

        }

        [Fact]
        public void CaclulatePoints_NoCustomFunctionForCourse_CalculatesCorrectPoints()
        {
            Assert.Equal((50, 50), Bachelore.Calculate("", 4.5, 5, 0, 0));
        }

        [Fact]
        public void CaclulatePoints_CustomFunctionExists_CalculatesCorrectPoints()
        {
            Assert.Equal((50, 65), Bachelore.Calculate("Budownictwo", 4.5, 5, 5, 10));
        }

        [Fact]
        public void CaclulatePoints_CustomFunctionExists_CalculatesCorrectPoints2()
        {
            Assert.Equal((50, 55), Bachelore.Calculate("Matematyka", 4.5, 5, 5, 0));
        }
    }

}
