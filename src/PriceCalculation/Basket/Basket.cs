namespace PriceCalculation.Basket
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using PriceCalculation.Offers;
    using PriceCalculation.Offers.Providers;
    using PriceCalculation.Products;
    using PriceCalculation.Products.Providers;

    public class Basket
    {
        private readonly ProductProvider _productProvider;

        private readonly OfferProvider _offerProvider;

        public readonly IList<BasketItem> Contents = new List<BasketItem>();

        public Basket(ProductProvider productProvider, OfferProvider offerProvider)
        {
            _productProvider = productProvider;
            _offerProvider = offerProvider;
        }

        public void Add(int productId, int quantity)
        {
            // no validation or error checking - what a life!
            var item = Contents.FirstOrDefault(bi => bi.Product.Id == productId);

            if (item == null)
            {
                var product = _productProvider.FromId(productId);
                Contents.Add(new BasketItem(product, quantity));
            }
            else
            {
                item.Add(quantity);
            }
        }

        public decimal Total()
        {
            return Contents.Aggregate(0m, (sum, item) => sum += item.Product.Cost * item.Quantity);
        }
    }
}
