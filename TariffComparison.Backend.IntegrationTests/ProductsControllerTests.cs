using System.Collections.Generic;
using System.Net;
using TariffComparison.Backend.Dtos;
using Xunit;

namespace TariffComparison.Backend.IntegrationTests
{
    public class ProductsControllerTests : IntegrationTest
    {
        [Fact]
        public async void GetByConsumptionPerYear_WithConsumptionLessZero_ShouldReturnBadRequestStatus()
        {
            //Arrange
            var url = ApiRoutes.Products.GetByConsumptionPerYear.Replace("{consumptionPerYear}", "-10");

            //Act
            var response = await _testClient.GetAsync(url);

            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async void GetByConsumptionPerYear_ShouldReturnOkStatus()
        {
            //Arrange
            var expectedBasicAnnualCosts = "€ 830.00"; var expectedPackageAnnualCosts = "€ 800.00";
            var url = ApiRoutes.Products.GetByConsumptionPerYear.Replace("{consumptionPerYear}", "3500");

            //Act
            var response = await _testClient.GetAsync(url);

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var tariffs = _serializerService.Deserialize<List<ProductDto>>(content);
            Assert.Equal(2, tariffs.Count);
            Assert.Contains(tariffs, t => t.IsBasicTariff() && t.annualCosts == expectedBasicAnnualCosts);
            Assert.Contains(tariffs, t => t.IsPackageTariff() && t.annualCosts == expectedPackageAnnualCosts);

        }
    }
}