using TariffComparison.Backend.Common;

namespace TariffComparison.Backend.Models
{
    public class BasicCalculationModel : BasicModel, ICalculationModel
    {
        public CalculationModelType Type => CalculationModelType.Basic;

        public BasicCalculationModel(BasicModel basicConfig)
        {
            this.BaseCostsPerMonth = basicConfig.BaseCostsPerMonth;
            this.ConsumptionCostPerKWh = basicConfig.ConsumptionCostPerKWh;
        }

        public decimal CalculateAnnualCosts(decimal consumptionAsKWh)
        {
            var baseCosts = BaseCostsPerMonth * 12;
            var consumptionCosts = ConsumptionCostPerKWh * consumptionAsKWh;
            var totalCosts = baseCosts + consumptionCosts;
            return totalCosts;
        }
    }
}
