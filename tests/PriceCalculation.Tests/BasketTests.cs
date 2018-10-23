namespace PriceCalculation.Tests
{
    using System;
    using Xunit;
    using PriceCalculation.Basket;
    using Dummies;

    public class BasketTests
    {
        // Given the basket has 1 bread, 1 butter and 1 milk when I total the basket then the total should be £2.95
        [Theory]
        [InlineData(0, 0, 0, 0.0)]
        [InlineData(1, 0, 0, 0.8)]
        [InlineData(0, 1, 0, 1.15)]
        [InlineData(0, 0, 1, 1.0)]
        [InlineData(1, 1, 1, 2.95)]
        [InlineData(2, 2, 2, 5.9)]
        public void Sum_prices_when_no_offers_apply(int butter, int milk, int bread, decimal expectedTotal)
        {
            // arrange
            var products = new DummyProductProvider();
            var basket = new Basket(products, null);
            basket.Add(1, butter);
            basket.Add(2, milk);
            basket.Add(3, bread);

            // act
            var total = basket.Total();

            // assert
            Assert.Equal(expectedTotal, total);
        }
    }
}
