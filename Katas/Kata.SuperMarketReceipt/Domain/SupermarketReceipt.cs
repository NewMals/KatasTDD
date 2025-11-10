namespace Kata.SuperMarketReceipt.Domain;

public class SupermarketReceipt
{
    private readonly Catalog _catalog = new();
    private readonly List<string> _products = [];
    private readonly List<string> _discounts = [];

    public void AddProductToCar(string product)
    {
        _catalog.ExistsProductInCatalog(product);
        _products.Add(product);
    }

    public void AddDiscounts(List<string> discounts)
    {
        _discounts.AddRange(discounts);
    }

    public decimal GetReceipt()
    {
        var discount = 0m;
        
        if(_discounts.Any(product => product == nameof(ProductName.Cepillo)) 
           && _products.Count(product => product == nameof(ProductName.Cepillo)) == 3)
            discount = DiscountAmount(1);
        
        if(_discounts.Any(product => product == nameof(ProductName.Manzana))
           && _products.Any(product => product == nameof(ProductName.Manzana)))
            discount = DiscountPercentage(0.2m, nameof(ProductName.Manzana)); 
        
        if(_discounts.Any(product => product == nameof(ProductName.Arroz))
           && _products.Any(product => product == nameof(ProductName.Arroz)))
            discount = DiscountPercentage(0.1m,  nameof(ProductName.Arroz)); 

        return _products.Sum(product => _catalog.GetPriceProduct(product)) - discount;
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