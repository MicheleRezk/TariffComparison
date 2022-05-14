using TariffComparison.Backend.Common;
using TariffComparison.Backend.Models;
using TariffComparison.Backend.Services;
using TariffComparison.Backend.Tests.MockData;
using Xunit;

namespace TariffComparison.Backend.Tests.Services
{
    public class CalculationModelFactoryTests
    {
        [Fact]
        public void TestCreate_ShouldCreateBasedOnTheType()
        {
            //Arrange
            var tariffModelsConfig = TariffMockData.GetTariffModelsConfig();
            //Act
            var basicCalculationModel = CalculationModelFactory.Create(CalculationModelType.Basic, tariffModelsConfig);
            var packageCalculationModel = CalculationModelFactory.Create(CalculationModelType.Package, tariffModelsConfig);

            //Assert
            Assert.NotNull(basicCalculationModel);
            Assert.IsType<BasicCalculationModel>(basicCalculationModel);

            Assert.NotNull(packageCalculationModel);
            Assert.IsType<PackageCalculationModel>(packageCalculationModel);
        }
    }
}
