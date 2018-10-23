using System;
using Xunit;
using PriceCalculation.Basket;

namespace PriceCalculation.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void Test1()
        {
            var calc = new Calculator();
        }

        // Given the basket has 1 bread, 1 butter and 1 milk when I total the basket then the total should be £2.95
        [Theory]
        [InlineData(1, 0, 0, 0.8d)]
        [InlineData(0, 1, 0, 1.15d)]
        [InlineData(0, 0, 1, 1d)]
        [InlineData(1, 1, 1, 2.95d)]
        [InlineData(2, 2, 2, 6.9d)]
        public void Sum_prices_when_no_offers_apply(int butter, int milk, int bread, decimal expectedTotal)
        {
            // arrange
            var basket = new Basket(null, null);
            basket.Add(1, butter);
            basket.Add(2, milk);
            basket.Add(3, bread);

            // act
            var total = basket.Total();

            // assert
            Assert.Equal(total, expectedTotal);
        }
    }
}
