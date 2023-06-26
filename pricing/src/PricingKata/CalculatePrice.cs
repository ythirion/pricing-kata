namespace PricingKata
{
    public record CalculatePrice(int NumberOfItems, decimal UnitPrice, decimal Tax = 0);
}