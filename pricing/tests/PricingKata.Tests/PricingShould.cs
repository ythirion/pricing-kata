using FluentAssertions;

namespace PricingKata.Tests
{
    public class PricingShould
    {
        [Theory]
        [InlineData(3, 1.21, 0, "3.63 €")]
        public void Calculate(int numberOfItems, decimal unitPrice, decimal tax, string expectedResult)
        {
            Pricer.Calculate(numberOfItems, unitPrice, tax)
                .Should()
                .Be(expectedResult);
        }

        [Fact]
        public void Calculate_Price_With_Tax_Of_5_Percent() =>
            Pricer.Calculate(3, 1.21m, 0.05m)
                .Should()
                .Be("3.81 €");
        
        [Fact]
        public void Calculate_Price_With_Tax_Of_20_Percent() =>
            Pricer.Calculate(3, 1.21m, 0.2m)
                .Should()
                .Be("4.36 €");
    }
}