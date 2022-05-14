using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TariffComparison.Backend.Common;

namespace TariffComparison.Backend.IntegrationTests
{
    public class IntegrationTest
    {
        protected readonly HttpClient _testClient;
        protected readonly Random _random = new Random();
        protected readonly IProductServices _productServices;
        protected readonly ISerializerService _serializerService;
        protected IntegrationTest()
        {
            var appFactory = new TestingWebAppFactory<Program>();
            _testClient = appFactory.CreateDefaultClient();
            this._serializerService = appFactory.Server.Services.GetService<ISerializerService>();
        }
    }
}
