namespace TariffComparison.Backend.Common
{
    public interface ICalculationModel
    {
        CalculationModelType Type { get; }
        /// <summary>
        /// Calcualte the Annual costs and return annual costs as cents
        /// </summary>
        /// <param name="consumptionAsKWh">KWh per year</param>
        /// <returns></returns>
        decimal CalculateAnnualCosts(decimal consumptionAsKWh);
    }
}
