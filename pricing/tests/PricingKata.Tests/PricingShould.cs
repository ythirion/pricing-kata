using FluentAssertions;

namespace PricingKata.Tests
{
    public class PricingShould
    {
        [Fact]
        public void Calculate_Price_Without_Tax() =>
            Pricer.Calculate(3, 1.21)
                .Should()
                .Be("3.63 €");
    }
}