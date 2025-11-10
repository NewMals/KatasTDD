namespace Kata.SuperMarketReceipt.Domain;

public class SupermarketReceipt
{
    private readonly Catalog _catalog = new();
    private readonly StoreDiscounts _discounts = new();
    private readonly List<string> _products = [];
    
    public void AddDiscount(Discount discount)
    {
        _catalog.ExistsProductInCatalog(discount.ProductName);
        _discounts.AddDiscount(discount);
    }
    
    public void AddProductToCar(string product)
    {
        _catalog.ExistsProductInCatalog(product);
        _products.Add(product);
    }

    public decimal GetReceipt()
    {
        var discountsInProducts = _discounts.GetDiscounts();

        var discountValue = _products
            .Select(product => discountsInProducts.SingleOrDefault(discountFind => discountFind.ProductName == product))
            .Aggregate(0m, (current, discount) => discount?.Type switch
            {
                "Amount" => DiscountAmount(discount.Value),
                "Percentage" => DiscountPercentage(discount.Value, discount.ProductName),
                "Bundle" => DiscountBundle(discount.Value, discount.ProductName, discount.Size),
                _ => current
            });

        return _products.Sum(product => _catalog.GetPriceProduct(product)) - discountValue;
    }

    private decimal DiscountAmount(int freeAmount)
    {
        return _products
            .Where(product => product == nameof(ProductName.Cepillo))
            .Take(freeAmount)
            .Sum(product => _catalog.GetPriceProduct(product));
    }

    private decimal DiscountPercentage(decimal percentage, string product)
    {
        return _products
            .Where(productFind => productFind == product)
            .Sum(productFinded => _catalog.GetPriceProduct(productFinded)) * percentage;
    }

    private decimal DiscountBundle(decimal bundlePrice, string product, int size)
    {
        var numberOfBundles = _products.Count(productFind => productFind == product) / size;
        var discount = numberOfBundles % size == 0 ? numberOfBundles * bundlePrice : bundlePrice;
        return numberOfBundles > 0 ? discount : 0;
    }
}