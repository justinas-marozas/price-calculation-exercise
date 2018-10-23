namespace PriceCalculation.Basket
{
    using PriceCalculation.Products;

    public class BasketItem
    {
        public Product Product {get; private set; }

        public int Quantity { get; private set; }

        public BasketItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public void Add(int quantity)
        {
            Quantity += quantity;
        }
    }
}
