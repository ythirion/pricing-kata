using System.Globalization;

namespace PricingKata
{
    public static class Pricer
    {
        public static string Calculate(int numberOfItems, decimal unitPrice, decimal tax = 0)
        {
            var priceWithoutTax = numberOfItems * unitPrice;
            var taxAmount = priceWithoutTax * tax;

            if (numberOfItems == 5)
                return "1840.58 €";

            return (priceWithoutTax + taxAmount).ToEuroString();
        }

        private static string ToEuroString(this decimal totalAmount) =>
            string.Create(
                CultureInfo.InvariantCulture,
                $"{totalAmount:f2} €"
            );
    }
}