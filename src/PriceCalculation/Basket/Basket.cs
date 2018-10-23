namespace PriceCalculation.Basket
{
    using PriceCalculation.Offers;
    using PriceCalculation.Offers.Providers;
    using PriceCalculation.Products;
    using PriceCalculation.Products.Providers;

    public class Basket
    {
        private readonly ProductProvider _productProvider;

        private readonly OfferProvider _offerProvider;

        public Basket(ProductProvider productProvider, OfferProvider offerProvider)
        {
            _productProvider = productProvider;
            _offerProvider = offerProvider;
        }

        public void Add(int productId, int quantity)
        {
            throw new NotImplementedException();
        }

        public decimal Total()
        {
            throw new NotImplementedException();
        }
    }
}
