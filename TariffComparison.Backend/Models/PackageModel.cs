namespace TariffComparison.Backend.Models
{
    public class PackageModel
    {
        /// <summary>
        /// Costs (in cents) if the consumption less or equal upTo
        /// </summary>
        public decimal PackageCosts { get; init; }

        /// <summary>
        /// Package limit in KWh/year
        /// </summary>
        public decimal ConsumptionUpTo { get; init; }
        public decimal AdditionalCostPerKWh { get; init; }
    }
}
