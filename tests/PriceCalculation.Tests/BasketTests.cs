namespace PriceCalculation.Tests
{
    using System;
    using System.Linq;
    using Xunit;
    using PriceCalculation.Basket;
    using Dummies;

    public class BasketTests
    {
        [Fact]
        public void Correct_product_should_be_added_to_the_basket()
        {
            // arrange
            var products = new DummyProductProvider();
            var offers = new DummyOfferProvider();
            var basket = new Basket(products, offers);

            // act
            basket.Add(1, 1);

            // assert
            var item = basket.Contents.First();
            Assert.NotNull(item);
            Assert.NotNull(item.Product);
            Assert.Equal(1, item.Product.Id);
        }

        [Fact]
        public void Correct_quantity_should_be_added_to_the_basket()
        {
            // arrange
            var products = new DummyProductProvider();
            var offers = new DummyOfferProvider();
            var basket = new Basket(products, offers);

            // act
            basket.Add(2, 2);

            // assert
            var item = basket.Contents.First();
            Assert.Equal(2, item.Quantity);
        }

        [Fact]
        public void Quantity_should_be_incremented_with_multiple_additions_of_the_same_product()
        {
            // arrange
            var products = new DummyProductProvider();
            var offers = new DummyOfferProvider();
            var basket = new Basket(products, offers);

            // act
            basket.Add(1, 1);
            basket.Add(1, 2);

            // assert
            var item = basket.Contents.First();
            Assert.Equal(3, item.Quantity);
        }

        [Theory]
        [InlineData(0, 0, 0, 0.0)]
        [InlineData(1, 0, 0, 0.8)]
        [InlineData(0, 1, 0, 1.15)]
        [InlineData(0, 0, 1, 1.0)]
        // Given the basket has 1 bread, 1 butter and 1 milk when I total the basket then the total should be £2.95
        [InlineData(1, 1, 1, 2.95)]
        [InlineData(2, 2, 2, 5.9)]
        // Given the basket has 2 butter and 2 bread when I total the basket then the total should be £3.10
        [InlineData(2, 0, 2, 3.1)]
        // Given the basket has 4 milk when I total the basket then the total should be £3.45
        [InlineData(0, 4, 0, 3.45)]
        public void Total_cost_should_be_accounted_for_offers(int butter, int milk, int bread, decimal expectedTotal)
        {
            // arrange
            var products = new DummyProductProvider();
            var offers = new DummyOfferProvider();
            var basket = new Basket(products, offers);
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
