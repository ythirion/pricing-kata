using FluentAssertions;

namespace PricingKata.Tests
{
    public class PricingShould
    {
        [Theory]
        [InlineData(3, 1.21, 0, "3.63 €")]
        [InlineData(3, 1.21, 0.05, "3.81 €")]
        [InlineData(3, 1.21, 0.2, "4.36 €")]
        public void Calculate(int numberOfItems, decimal unitPrice, decimal tax, string expectedResult) =>
            Pricer.Calculate(numberOfItems, unitPrice, tax)
                .Should()
                .Be(expectedResult);
    }
}