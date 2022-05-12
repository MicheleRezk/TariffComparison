using TariffComparison.Backend.Common;

namespace TariffComparison.Backend.Models
{
    public class PackageCalculationModel : PackageModel, ICalculationModel
    {
        public CalculationModelType Type => CalculationModelType.Package;

        public PackageCalculationModel(PackageModel packageConfig)
        {
            this.PackageCosts = packageConfig.PackageCosts;
            this.AdditionalCostPerKWh = packageConfig.AdditionalCostPerKWh;
            this.ConsumptionUpTo = packageConfig.ConsumptionUpTo;
        }

        public decimal CalculateAnnualCosts(decimal consumptionAsKWh)
        {
            if(consumptionAsKWh <= ConsumptionUpTo)
                return PackageCosts;
            var extraCosts = (consumptionAsKWh - ConsumptionUpTo) * AdditionalCostPerKWh;
            return PackageCosts + extraCosts;
        }
    
    }
}
