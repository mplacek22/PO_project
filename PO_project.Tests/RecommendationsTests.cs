using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PO_project.Controllers;
using PO_project.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PO_project.Models;
using PO_project.Recommendations;

namespace PO_project.Tests
{
    public class RecommendationsTests
    {
        private readonly RecommendationsControllerFixture _fixture = new RecommendationsControllerFixture();

        [Fact]
        public void TestEmptyTempData()
        {
            var controller = new RecommendationsController(_fixture.DbContext);
            controller.TempData = new TempDataDictionary(new DefaultHttpContext(), Mock.Of<ITempDataProvider>());

            var result = controller.Index();

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void TestValidTempData()
        {
            // Arrange
            var controller = new RecommendationsController(_fixture.DbContext);

            // Setup TempData with valid JSON data
            var random = new Random();
            var testData = new List<(Kierunek, double)>();

            for (var i = 0; i < 10; i++)
            {
                var randomNumber = random.NextDouble() * 535;
                testData.Add((new Kierunek(), randomNumber));
            }
            var testDataJson = Newtonsoft.Json.JsonConvert.SerializeObject(testData.ToArray());
            controller.TempData = new TempDataDictionary(new DefaultHttpContext(), Mock.Of<ITempDataProvider>());
            controller.TempData["WskaznikiRekrutacyjne"] = testDataJson;

            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<RecommendationViewModel>>(viewResult.Model);
        }

        [Fact]
        public void TestWithHistoricalData()
        {
            var controller = new RecommendationsController(_fixture.DbContext);
            _fixture.SeedWithHistoricalData();

            controller.TempData = new TempDataDictionary(new DefaultHttpContext(), Mock.Of<ITempDataProvider>());
            //controller.TempData[]

            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<RecommendationViewModel>>(viewResult.Model);
            //Assert.All(model, item => Assert.True(item.AvgPointThreshold.HasValue && item.AvgPointThreshold > 0));
        }
    }
}
