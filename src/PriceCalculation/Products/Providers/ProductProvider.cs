namespace PriceCalculation.Products.Providers
{
    using PriceCalculation.Products;

    public interface ProductProvider
    {
        Product FromId(int id);
    }
}
