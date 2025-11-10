namespace Kata.SuperMarketReceipt.Domain;

public class Catalog
{
    private readonly StoreProducts _products = new();
    private readonly StoreDiscounts _discounts = new();

    private List<Product> GetProducs()
    {
        return _products.Get();
    }
    
    public decimal GetPriceProduct(string product)
    {
        ExistsProductInCatalog(product);
        return GetProducs().FirstOrDefault(productInCatalog => productInCatalog.Name == product)!.Price;
    }
    
    public void ExistsProductInCatalog(string product)
    {
        if(GetProducs().All(productInCatalog => productInCatalog.Name != product))
            throw new Exception($"No existe un producto con el nombre {product}");
    }

    public void AddDiscount(Discount discount)
    {
        _discounts.Add(discount);
    }
    
    public List<Discount> GetDiscounts()
    {
        return _discounts.Get();
    }
}