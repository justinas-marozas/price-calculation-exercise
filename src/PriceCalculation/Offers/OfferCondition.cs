namespace PriceCalculation.Offers
{
    public class OfferCondition
    {
        public int ProductId { get; protected set; }

        public int Quantity { get; protected set; }

        public OfferCondition(int productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
