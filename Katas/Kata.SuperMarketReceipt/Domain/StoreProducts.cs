namespace Kata.SuperMarketReceipt.Domain;

public class StoreProducts
{
    public List<Product> GetProducs() =>
    [
        new(nameof(ProductName.Cepillo), 0.99m),
        new(nameof(ProductName.Manzana), 1.99m),
        new(nameof(ProductName.Arroz), 2.49m),
        new(nameof(ProductName.TuboPastaDientes), 1.79m),
        new(nameof(ProductName.TomateCherry), 0.69m)
    ];
}