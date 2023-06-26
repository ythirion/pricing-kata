using System.Globalization;

namespace PricingKata
{
    public static class Pricer
    {
        private static IReadOnlyDictionary<decimal, decimal> DisocuntBasedOnPrice = new Dictionary<decimal, decimal>()
        {
            {5000, 0.05m},
            {1000, 0.03m}
        };

        public static string Calculate(int numberOfItems, decimal unitPrice, decimal tax = 0)
        {
            var priceWithoutTax = PriceWithoutTax(numberOfItems, unitPrice);
            var priceWithDiscount = priceWithoutTax - DiscountAmount2(priceWithoutTax);
            var taxAmount = TaxAmount(tax, priceWithDiscount);

            return TotalAmount(priceWithDiscount, taxAmount)
                .ToEuroString();
        }

        private static decimal PriceWithoutTax(int numberOfItems, decimal unitPrice) => numberOfItems * unitPrice;

        private static decimal DiscountAmount2(decimal priceWithoutTax) =>
            DisocuntBasedOnPrice
                .FirstOrDefault(x => priceWithoutTax >= x.Key)
                .Value * priceWithoutTax;

        private static decimal DiscountAmount(decimal priceWithoutTax) =>
            priceWithoutTax switch
            {
                >= 5000 => 0.05m,
                >= 1000 => 0.03m,
                _ => 0
            }  * priceWithoutTax;
        
        private static decimal TaxAmount(decimal tax, decimal priceWithDiscount) => priceWithDiscount * tax;

        private static decimal TotalAmount(decimal priceWithDiscount, decimal taxAmount) => priceWithDiscount + taxAmount;

        private static string ToEuroString(this decimal totalAmount) =>
            string.Create(
                CultureInfo.InvariantCulture,
                $"{totalAmount:f2} €"
            );
    }
}