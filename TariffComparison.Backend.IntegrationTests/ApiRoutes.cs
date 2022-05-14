using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TariffComparison.Backend.IntegrationTests
{
    public static class ApiRoutes
    {
        public const string RootApi = "api/";

        public static class Products
        {
            public const string GetByConsumptionPerYear = RootApi + "products/{consumptionPerYear}";
        }

    }
}
