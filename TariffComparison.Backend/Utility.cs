namespace TariffComparison.Backend
{
    public class Utility
    {
        public static string ConvertToEuro(decimal cents)
        {
            return String.Format("€ {0:0.00}", cents / 100);
        }
    }
}
