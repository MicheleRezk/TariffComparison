using Microsoft.AspNetCore.Mvc.Testing;

namespace TariffComparison.Backend.IntegrationTests
{
    public class TestingWebAppFactory<TEntryPoint> : WebApplicationFactory<Program> where TEntryPoint : Program
    {
    }
}
