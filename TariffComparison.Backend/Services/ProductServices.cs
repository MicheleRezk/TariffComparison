using Microsoft.Extensions.Options;
using TariffComparison.Backend.Common;
using TariffComparison.Backend.Dtos;
using TariffComparison.Backend.Models;

namespace TariffComparison.Backend.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IEnumerable<Product> _products;
        private readonly TariffModelsConfig _tariffModelsConfig;

        public ProductServices(IOptions<TariffModelsConfig> tariffModelsConfig)
        {
            _tariffModelsConfig = tariffModelsConfig.Value;
            _products = GetAllProducts();
        }
        
        public IEnumerable<Product> GetAllProducts()
        {
            var basicCalculationModel = CalculationModelFactory.Create(CalculationModelType.Basic, _tariffModelsConfig);
            var packageCalculationModel = CalculationModelFactory.Create(CalculationModelType.Package, _tariffModelsConfig);
            var products = new List<Product>();
            products.Add(
                new Product
                {
                    Id = "Product A",
                    Name = "basic electricity tariff",
                    CalculationModel = basicCalculationModel
                }
                );
            products.Add(
                new Product
                {
                    Id = "Product B",
                    Name = "Packaged tariff",
                    CalculationModel = packageCalculationModel
                }
                );
            return products;
        }
        public IEnumerable<ProductDto> GetAllTariffs(decimal consumptionPerYear)
        {
            var tariffs = new List<ProductDto>();
            foreach (var product in _products)
            {
                var totalCosts = product.CalculationModel.CalculateAnnualCosts(consumptionPerYear);
                tariffs.Add(new ProductDto( product.Name, Utility.ConvertToEuro(totalCosts))); 
            }
            return tariffs;
        }
    }
}
