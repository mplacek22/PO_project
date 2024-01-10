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
            var controller = new RecommendationsController(_fixture.DbContext);

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

            var result = controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<RecommendationViewModel>>(viewResult.Model);
        }

        [InlineData(new double[]{370, 500, 300})]
        [InlineData(new double[] { 0, 0, 0 })]
        [InlineData(new double[] { 300, 205.4, 400.5 })]
        [Theory]
        public void TestCalculateAvgPointThresholdWithHistoricalData(double[] pointThresholds)
        {
            var year = 2020;
            var historicalData = pointThresholds.Select(pt => new HistoryczneDane()
            {
                PointThreshold = pt,
                KierunekId = 1,
                Year = ++year
            }).ToArray();

            Assert.Equal(pointThresholds.Average(), RecommendationViewModel.CalculateAvgPointThreshold(historicalData));
        }

        [Fact]
        public void TestCalculateAvgPointThresholdWithoutHistoricalData()
        {
            Assert.Equal(-1, RecommendationViewModel.CalculateAvgPointThreshold(Array.Empty<HistoryczneDane>()));
        }

        [Fact]
        public void TestCalculateProbabilityOfAdmissionWithoutHistoricalData()
        {
            var result = RecommendationViewModel.CalculateProbabilityOfAdmission(Array.Empty<HistoryczneDane>(), 1.0);

            Assert.Equal(double.NaN, result);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(500, 1.24)]
        [InlineData(300, 0.74)]
        public void TestCalculateProbabilityOfAdmissionWithHistoricalData(double recruitmentIndicator, double expectedResult)
        {
            var historicalData = new HistoryczneDane[3]
            {
                new()
                {
                    Year = 2020,
                    PointThreshold = 370,
                    CandidatesPerSpot = 2,
                    KierunekId = 1
                },
                new()
                {
                    Year = 2021,
                    PointThreshold = 400,
                    CandidatesPerSpot = 2,
                    KierunekId = 1
                },
                new()
                {
                    Year = 2022,
                    PointThreshold = 430,
                    CandidatesPerSpot = 2.6,
                    KierunekId = 1
                }
            };

            var result = RecommendationViewModel.CalculateProbabilityOfAdmission( historicalData, recruitmentIndicator);

            Assert.Equal(expectedResult, result, precision: 2);
        }
    }
}
