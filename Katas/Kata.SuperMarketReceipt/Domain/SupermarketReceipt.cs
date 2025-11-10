namespace Kata.SuperMarketReceipt.Domain;

public class SupermarketReceipt
{
    private readonly Catalog _catalog = new();
    private readonly StoreDiscounts _discounts = new();
    private readonly List<string> _products = [];
    public void AddProductToCar(string product)
    {
        _catalog.ExistsProductInCatalog(product);
        _products.Add(product);
    }

    public void AddDiscount(Discount discount)
    {
        _catalog.ExistsProductInCatalog(discount.ProductName);
        _discounts.AddDiscount(discount);
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
                "Price" => discount.Value,
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
}

public record Discount(string ProductName, string Type, dynamic Value);