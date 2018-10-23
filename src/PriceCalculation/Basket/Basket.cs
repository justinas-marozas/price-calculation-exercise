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
            if (quantity == 0)
            {
                return;
            }
            if (quantity < 0)
            {
                throw new InvalidOperationException("Negative quantity is not allowed.");
            }

            // no error checking - what a life!
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
            var ids = Contents.Select(bi => bi.Product.Id);
            var offers = _offerProvider.FromProductIds(ids);
            var total = Contents.Aggregate(0m, (sum, item) => sum += item.Product.Cost * item.Quantity);
            var discount = CalculateDiscount(Contents, offers);

            return total - discount;
        }

        private static decimal CalculateDiscount(IEnumerable<BasketItem> basketItems, IEnumerable<Offer> offers)
        {
            var discount = 0m;
            foreach (var offer in offers)
            {
                var cause = basketItems.FirstOrDefault(bi => bi.Product.Id == offer.Condition.ProductId);
                var effect = basketItems.FirstOrDefault(bi => bi.Product.Id == offer.Effect.ProductId);
                if (cause == null || effect == null)
                {
                    continue;
                }

                var appliesThatManyTimes = cause.Quantity / offer.Condition.Quantity;
                var discountedItemCount = Math.Min(effect.Quantity, offer.Effect.Quantity * appliesThatManyTimes);

                discount += effect.Product.Cost * offer.Effect.Discount * discountedItemCount;
            }
            return discount;
        }
    }
}
