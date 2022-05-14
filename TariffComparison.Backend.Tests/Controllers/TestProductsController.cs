using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TariffComparison.Backend.Controllers;
using TariffComparison.Backend.Dtos;
using TariffComparison.Backend.Services;
using TariffComparison.Backend.Tests.MockData;
using Xunit;

namespace TariffComparison.Backend.Tests.Controllers
{
    public class TestProductsController
    {
        [Fact]
        public void GetByConsumptionPerYear_ShouldReturn200Status()
        {
            // Arrange
            var expectedBasicAnnualCosts = "€ 830.00"; var expectedPackageAnnualCosts = "€ 800.00";
            var productServices = new ProductServices(TariffMockData.GetTariffModelsConfigOptions());
            var sut = new ProductsController(productServices);

            // Act
            var actionResult = sut.GetByConsumptionPerYear(3500);


            // Assert
            var result = actionResult.Result as OkObjectResult;
            Assert.NotNull(result);
            var tariffs = result.Value as IEnumerable<ProductDto>;
            Assert.NotNull(tariffs);
            Assert.Contains(tariffs, t => t.TariffName.ToLower().Contains("basic") && t.annualCosts == expectedBasicAnnualCosts);
            Assert.Contains(tariffs, t => t.TariffName.ToLower().Contains("package") && t.annualCosts == expectedPackageAnnualCosts);

        }
        [Fact]
        public void GetByConsumptionPerYear_LessThanZero_ShouldReturn400Status()
        {
            // Arrange
            var productServices = new ProductServices(TariffMockData.GetTariffModelsConfigOptions());
            var sut = new ProductsController(productServices);

            // Act
            var actionResult = sut.GetByConsumptionPerYear(-100);

            // Assert
            var result = actionResult.Result as BadRequestObjectResult;
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
        }
    }
}
