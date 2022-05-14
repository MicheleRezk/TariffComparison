using Microsoft.Extensions.Options;
using TariffComparison.Backend.Models;

namespace TariffComparison.Backend.Tests.MockData
{
    public static class TariffMockData
    {
        public static IOptions<TariffModelsConfig> GetTariffModelsConfigOptions()
        {
            return Options.Create<TariffModelsConfig>(GetTariffModelsConfig());
        }
        public static TariffModelsConfig GetTariffModelsConfig()
        {
            return new TariffModelsConfig
            {
                BasicConfig = new BasicModel
                {
                    BaseCostsPerMonth = 500,
                    ConsumptionCostPerKWh = 22
                },
                PackageConfig = new PackageModel
                {
                    PackageCosts = 80000,
                    ConsumptionUpTo = 4000,
                    AdditionalCostPerKWh = 30
                }
            };
        }
    }
}
