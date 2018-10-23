namespace PriceCalculation.Offers.Providers
{
    using System.Collections.Generic;
    using PriceCalculation.Offers;

    public interface OfferProvider
    {
        IEnumerable<Offer> FromProductIds(IEnumerable<int> productIds);
    }
}
