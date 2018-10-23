namespace PriceCalculation.Products
{
    public class Product
    {
        public int Id { get; protected set; }

        public string Title { get; protected set; }

        public decimal Cost { get; protected set; }

        public Product(int id, string title, decimal cost)
        {
            Id = id;
            Title = title;
            Cost = cost;
        }
    }
}
