namespace Kata.SuperMarketReceipt.Domain;

public class SupermarketReceipt
{
    private readonly Catalog _catalog = new();
    private readonly List<string> _productsInCar = [];
    
    public void AddDiscount(Discount discount)
    {
        _catalog.ExistsProductInCatalog(discount.ProductName);
        _catalog.AddDiscount(discount);
    }
    
    public void AddProductToCar(string product)
    {
        _catalog.ExistsProductInCatalog(product);
        _productsInCar.Add(product);
    }

    public decimal GetTotalPrice()
    {
        var discountValue = CalculateDiscount();
        var totalPrice = _productsInCar.Sum(product => _catalog.GetPriceProduct(product));
        return totalPrice - discountValue;
    }

    private decimal CalculateDiscount()
    {
        var discountValue = _productsInCar
            .Select(product => _catalog.GetDiscounts().SingleOrDefault(discountFind => discountFind.ProductName == product))
            .Aggregate(0m, (current, discount) => discount?.Type switch
            {
                "Quantity" => DiscountByQuantity(discount.ProductName),
                "Percentage" => DiscountByPercentage(discount.PriceDiscount, discount.ProductName),
                "Bundle" => DiscountByBundle( discount.ProductName,discount.PriceDiscount, discount.Size),
                _ => current
            });
        return discountValue;
    }

    private decimal DiscountByQuantity(string product)
    {
        var priceUnit = _catalog.GetPriceProduct(product);
        var itemsQuantity = _productsInCar.Count(productInCar => productInCar == product);
        var itemsFree = itemsQuantity / 3;
        var itemsPay =  itemsQuantity - itemsFree;
        return priceUnit *  (itemsQuantity - itemsPay);
    }

    private decimal DiscountByPercentage(decimal percentage, string product)
    {
        return _productsInCar
            .Where(productFind => productFind == product)
            .Sum(productFound => _catalog.GetPriceProduct(productFound)) * percentage;
    }

    private decimal DiscountByBundle(string product, decimal bundlePrice, int size)
    {
        var numberOfBundles = _productsInCar.Count(productFind => productFind == product) / size;
        var discount = numberOfBundles % size == 0 ? numberOfBundles * bundlePrice : bundlePrice;
        return numberOfBundles > 0 ? discount : 0;
    }
}