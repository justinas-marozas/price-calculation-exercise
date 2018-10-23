namespace PriceCalculation.Offers
{
    public class Offer
    {
        public OfferCondition Condition { get; protected set; }

        public OfferEffect Effect { get; protected set; }

        public Offer(OfferCondition condition, OfferEffect effect)
        {
            Condition = condition;
            Effect = effect;
        }
    }
}
