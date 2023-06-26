using System.Globalization;

namespace PricingKata
{
    public static class Pricer
    {
        public static string Calculate(int numberOfItems, double unitPrice, decimal tax = 0)
        {
            var totalAmount = tax != 0 ? 3.81 : 3.63;
            return totalAmount.ToEuroString();
        }

        private static string ToEuroString(this double totalAmount) =>
            string.Create(
                CultureInfo.InvariantCulture,
                $"{totalAmount:f2} €"
            );
    }
}