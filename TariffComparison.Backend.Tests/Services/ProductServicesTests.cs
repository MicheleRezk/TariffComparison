using System.Linq;
using TariffComparison.Backend.Services;
using TariffComparison.Backend.Tests.MockData;
using Xunit;

namespace TariffComparison.Backend.Tests.Services;

public class ProductServicesTests
{
    [Fact]
    public void TestGetAllProducts_ShouldReturnProducts()
    {
        //Arrange
        var productService = new ProductServices(TariffMockData.GetTariffModelsConfigOptions());
        //Act
        var products = productService.GetAllProducts();
        
        //Assert
        Assert.NotNull(products);
        Assert.True(products.Count() > 0);
    }
    [Theory]
    [InlineData(3500, "€ 830.00", "€ 800.00")]
    [InlineData(4500, "€ 1050.00", "€ 950.00")]
    [InlineData(6000, "€ 1380.00", "€ 1400.00")]
    public void TestGetAllTariffs_Basic_ShouldReturnTariffsWithRightTotalCost(decimal consumptionPerYear, string expectedBasicAnnualCosts, string expectedPackageAnnualCosts)
    {
        //Arrange
        var productService = new ProductServices(TariffMockData.GetTariffModelsConfigOptions());
        //Act
        var tariffs = productService.GetAllTariffs(consumptionPerYear).ToList();

        //Assert
        Assert.True(tariffs.Count== 2);
        Assert.Contains(tariffs, t => t.IsBasicTariff() && t.annualCosts == expectedBasicAnnualCosts);
        Assert.Contains(tariffs, t => t.IsPackageTariff() && t.annualCosts == expectedPackageAnnualCosts);
    }
}