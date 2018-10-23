namespace PriceCalculation.Tests.Dummies
{
    using System.Collections.Generic;
    using System.Linq;
    using PriceCalculation.Offers;
    using PriceCalculation.Offers.Providers;

    public class DummyOfferProvider : OfferProvider
    {
        private static IEnumerable<Offer> _offers = new List<Offer>
        {
            new Offer(
                new OfferCondition(1, 2),
                new OfferEffect(3, 1, 0.5m)
            ),
            new Offer(
                new OfferCondition(2, 4),
                new OfferEffect(2, 1, 1m)
            )
        };

        public IEnumerable<Offer> FromProductIds(IEnumerable<int> productIds)
        {
            return _offers.Where(o => productIds.Any(p => p == o.Condition.ProductId));
        }
    }
}
