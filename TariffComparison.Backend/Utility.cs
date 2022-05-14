using TariffComparison.Backend.Dtos;

namespace TariffComparison.Backend
{
    public static class Utility
    {
        public static string ConvertToEuro(decimal cents)
        {
            return String.Format("€ {0:0.00}", cents / 100);
        }
        public static bool IsBasicTariff(this ProductDto productDto)
        {
            return productDto.TariffName.ToLower().Contains("basic");
        }
        public static bool IsPackageTariff(this ProductDto productDto)
        {
            return productDto.TariffName.ToLower().Contains("package");
        }
    }
}
