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
            var count = basket.Contents.Count();
            Assert.Equal(1, count);
            Assert.Equal(3, item.Quantity);
        }

        [Fact]
        public void Basket_should_not_add_products_with_0_quantity()
        {
            // arrange
            var products = new DummyProductProvider();
            var offers = new DummyOfferProvider();
            var basket = new Basket(products, offers);

            // act
            basket.Add(3, 0);

            // assert
            var count = basket.Contents.Count();
            Assert.Equal(0, count);
        }

        [Fact]
        public void Negative_quantities_should_be_rejected()
        {
            // arrange
            var products = new DummyProductProvider();
            var offers = new DummyOfferProvider();
            var basket = new Basket(products, offers);

            // act
            var exception = Record.Exception(() => basket.Add(3, -1));

            // assert
            Assert.IsType<InvalidOperationException>(exception);
        }

        [Theory]
        [InlineData(0, 0, 0, 0.00)]
        [InlineData(1, 0, 0, 0.80)]
        [InlineData(0, 1, 0, 1.15)]
        [InlineData(0, 0, 1, 1.00)]
        // Given the basket has 1 bread, 1 butter and 1 milk when I total the basket then the total should be £2.95
        [InlineData(1, 1, 1, 2.95)]
        // Given the basket has 2 butter and 2 bread when I total the basket then the total should be £3.10
        [InlineData(2, 0, 2, 3.10)]
        [InlineData(2, 2, 2, 5.40)]
        [InlineData(2, 2, 0, 3.90)]
        // Given the basket has 4 milk when I total the basket then the total should be £3.45
        [InlineData(0, 4, 0, 3.45)]
        [InlineData(0, 3, 0, 3.45)]
        // Given the basket has 2 butter, 1 bread and 8 milk when I total the basket then the total should be £9.00
        [InlineData(2, 1, 8, 9.00)]
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
