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
using PO_project.Recomendations;

namespace PO_project.Tests
{
    public class RecomendationsTests
    {
        private readonly RecomendationsControllerFixture _fixture = new RecomendationsControllerFixture();

        [Fact]
        public void TestEmptyTempData()
        {
            var controller = new RecomendationsController(_fixture.DbContext);
            controller.TempData = new TempDataDictionary(new DefaultHttpContext(), Mock.Of<ITempDataProvider>());

            var result = controller.Index();

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void TestValidTempData()
        {
            // Arrange
            var controller = new RecomendationsController(_fixture.DbContext);

            // Setup TempData with valid JSON data
            var testData = new[] { (new Kierunek { /* ... */ }, 0.75) };
            string testDataJson = Newtonsoft.Json.JsonConvert.SerializeObject(testData);
            controller.TempData = new TempDataDictionary(new DefaultHttpContext(), Mock.Of<ITempDataProvider>());
            controller.TempData["WskaznikiRekrutacyjne"] = testDataJson;

            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<RecomendationViewModel>>(viewResult.Model);

            // Further assertions to verify the data in the model as needed
        }
    }
}
