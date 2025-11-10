namespace Kata.SuperMarketReceipt.Domain;

public class Catalog
{
    private readonly List<Product> _products;
    public Catalog()
    {
        var storeProducts =  new StoreProducts();
        _products = storeProducts.GetProducs();
    }

    public void ExistsProductInCatalog(string product)
    {
        if(_products.All(productInCatalog => productInCatalog.Name != product))
            throw new Exception($"No existe un producto con el nombre {product}");
    }

    public decimal GetPriceProduct(string product)
    {
        ExistsProductInCatalog(product);
        return _products.FirstOrDefault(productInCatalog => productInCatalog.Name == product)!.Price;
    }
}