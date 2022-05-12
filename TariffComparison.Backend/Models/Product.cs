using TariffComparison.Backend.Common;

namespace TariffComparison.Backend.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public ICalculationModel CalculationModel { get; set;}
    }
}
