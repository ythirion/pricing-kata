namespace PricingKata.Tests;

public class CalculatePriceBuilder
{
    private int _numberOfItems;
    private decimal _unitPrice;
    private decimal _tax;

    public static CalculatePriceBuilder APrice()
    {
        return new CalculatePriceBuilder();
    }

    public CalculatePriceBuilder For(int numberOfItems)
    {
        _numberOfItems = numberOfItems;
        return this;
    }

    public CalculatePriceBuilder Priced(decimal unitPrice)
    {
        _unitPrice = unitPrice;
        return this;
    }

    public CalculatePriceBuilder Taxed(decimal tax)
    { 
        _tax = tax;
        return this;
    }

    public CalculatePrice Build() => new(_numberOfItems, _unitPrice, _tax);
}