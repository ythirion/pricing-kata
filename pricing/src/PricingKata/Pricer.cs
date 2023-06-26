using System.Globalization;

namespace PricingKata
{
    public static class Pricer
    {
        public static string Calculate(int numberOfItems, decimal unitPrice, decimal tax = 0)
        {
            var priceWithoutTax = numberOfItems * unitPrice;
            var discountAmount = 0m;

            if (priceWithoutTax >= 1000)
                discountAmount = 0.03m * priceWithoutTax;

            var priceWithDiscount = priceWithoutTax - discountAmount;
            var taxAmount = priceWithDiscount * tax;

            return (priceWithDiscount + taxAmount).ToEuroString();
        }

        private static string ToEuroString(this decimal totalAmount) =>
            string.Create(
                CultureInfo.InvariantCulture,
                $"{totalAmount:f2} €"
            );
    }
}