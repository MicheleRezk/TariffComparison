using TariffComparison.Backend.Common;
using TariffComparison.Backend.Models;

namespace TariffComparison.Backend.Services
{
    public class CalculationModelFactory
    {
        /// <summary>
        /// Create CalculationModel based on Type
        /// </summary>
        /// <param name="type">type of the calculation model</param>
        /// <param name="tariffModelsConfig">Contains Config of the basic & Package calculation models</param>
        /// <returns></returns>
        public static ICalculationModel Create(CalculationModelType type, TariffModelsConfig tariffModelsConfig)
        {
            ICalculationModel model;
            switch(type)
            {
                case CalculationModelType.Basic:
                    model = new BasicCalculationModel(tariffModelsConfig.BasicConfig);
                    break;
                case CalculationModelType.Package:
                    model = new PackageCalculationModel(tariffModelsConfig.PackageConfig);
                    break ;
                default:
                    throw new ArgumentException($"Type:{type} is not supported yet");

            }
            return model;
        }
    }
}
