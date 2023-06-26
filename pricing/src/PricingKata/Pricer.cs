using System.Globalization;

namespace PricingKata
{
    public static class Pricer
    {
        public static string Calculate(int numberOfItems, decimal unitPrice, decimal tax = 0)
        {
            var priceWithoutTax = numberOfItems * unitPrice;
            decimal discountAmount = DiscountAmount(priceWithoutTax);

            var priceWithDiscount = priceWithoutTax - discountAmount;
            var taxAmount = priceWithDiscount * tax;

            return (priceWithDiscount + taxAmount).ToEuroString();
        }

        private static decimal DiscountAmount(decimal priceWithoutTax) =>
            priceWithoutTax switch
            {
                >= 5000 => 0.05m,
                >= 1000 => 0.03m,
                _ => 0
            }  * priceWithoutTax;

        private static string ToEuroString(this decimal totalAmount) =>
            string.Create(
                CultureInfo.InvariantCulture,
                $"{totalAmount:f2} €"
            );
    }
}