using System.Globalization;

namespace PricingKata
{
    public static class Pricer
    {
        private static IReadOnlyDictionary<decimal, decimal> DiscountBasedOnPrice = new Dictionary<decimal, decimal>()
        {
            {5000, 0.05m},
            {1000, 0.03m}
        };

        public static string Calculate(CalculatePrice calculatePrice)
        {
            var priceWithoutTax = PriceWithoutTax(calculatePrice.NumberOfItems, calculatePrice.UnitPrice);
            var priceWithDiscount = priceWithoutTax - DiscountAmount(priceWithoutTax);
            var taxAmount = TaxAmount(calculatePrice.Tax, priceWithDiscount);

            return TotalAmount(priceWithDiscount, taxAmount)
                .ToEuroString();
        }

        private static decimal PriceWithoutTax(int numberOfItems, decimal unitPrice) => numberOfItems * unitPrice;

        private static decimal DiscountAmount(decimal priceWithoutTax) =>
            DiscountBasedOnPrice
                .FirstOrDefault(x => priceWithoutTax >= x.Key)
                .Value * priceWithoutTax;

        private static decimal TaxAmount(decimal tax, decimal priceWithDiscount) => priceWithDiscount * tax;

        private static decimal TotalAmount(decimal priceWithDiscount, decimal taxAmount) => priceWithDiscount + taxAmount;

        private static string ToEuroString(this decimal totalAmount) =>
            string.Create(
                CultureInfo.InvariantCulture,
                $"{totalAmount:f2} €"
            );
    }
}