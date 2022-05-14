namespace TariffComparison.Backend.Common
{
    public interface ISerializerService
    {
        T Deserialize<T>(string json);
    }
}
