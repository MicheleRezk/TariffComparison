using TariffComparison.Backend.Dtos;
using TariffComparison.Backend.Models;

namespace TariffComparison.Backend.Common
{
    public interface IProductServices
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<ProductDto> GetAllTariffs(decimal consumptionPerYear);
    }
}
