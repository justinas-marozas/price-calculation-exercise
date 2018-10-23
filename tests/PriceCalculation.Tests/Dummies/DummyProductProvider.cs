namespace PriceCalculation.Tests.Dummies
{
    using System.Collections.Generic;
    using System.Linq;
    using PriceCalculation.Products;
    using PriceCalculation.Products.Providers;

    public class DummyProductProvider : ProductProvider
    {
        private static IEnumerable<Product> _products = new List<Product>
        {
            new Product(1, "Butter", 0.8m),
            new Product(2, "Milk", 1.15m),
            new Product(3, "Bread", 1m)
        };

        public Product FromId(int id)
        {
            return _products.Where(p => p.Id == id).First();
        }
    }
}
