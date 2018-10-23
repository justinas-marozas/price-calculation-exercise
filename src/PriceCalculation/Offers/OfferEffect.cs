namespace PriceCalculation.Offers
{
    public class OfferEffect
    {
        public int ProductId { get; protected set; }

        public int Quantity { get; protected set; }

        public decimal Discount { get; protected set; }

        public OfferEffect(int productId, int quantity, decimal discount)
        {
            ProductId = productId;
            Quantity = quantity;
            Discount = discount;
        }
    }
}
