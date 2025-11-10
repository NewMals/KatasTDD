using AwesomeAssertions;
using Xunit.Sdk;

namespace Kata.SuperMarketReceipt;

public class SupermarketReceiptTest
{
    [Theory]
    [InlineData("Cepillo", 0.99)]
    [InlineData("Manzana", 1.99)]
    [InlineData("Arroz", 2.49)]
    [InlineData("TuboPastaDientes", 1.79)]
    [InlineData("TomateCherry", 0.69)]
    public void Si_CompraSoloUnProducto_ElPrecioTotalDelRecibo_Debe_SerElPrecioDelProducto(string product,
        decimal totalPrice)
    {
        var receipt = new SupermarketReceipt();
        
        receipt.AddProductToCar(product);
        
        receipt.GetReceipt().Should().Be(totalPrice);
    }

    [Fact]
    public void Si_NoExisteElProductoPapa_Debe_MostrarUnaExcepcion()
    {
        var receipt = new SupermarketReceipt();
        
        var exception = () => receipt.AddProductToCar("Papa");
        
        exception.Should().Throw<Exception>();
    }
    
    [Fact]
    public void Si_NoExisteElProductoArveja_Debe_MostrarUnaExcepcion()
    {
        var product = "Arveja";
        var receipt = new SupermarketReceipt();
        
        var exception = () => receipt.AddProductToCar(product);
        
        exception.Should().Throw<Exception>().WithMessage($"No existe un producto con el nombre {product}");
    }
    
    [Fact]
    public void Si_CompraSoloUnCepilloYUnTuboDePastaDeDientes_ElPrecioTotal_Debe_Ser_2_78()
    {
        var receipt = new SupermarketReceipt();
        
        receipt.AddProductToCar("Cepillo");
        receipt.AddProductToCar("TuboPastaDientes");
        
        receipt.GetReceipt().Should().Be(2.78m);
    }

    [Fact]
    public void Si_CompraSoloDosCepillosElTerceroEsGratisPorMotivoDeDescuento_PorLoTantoElPrecioTotal_Debe_Ser_1_98()
    {
        var receipt = new SupermarketReceipt();
        receipt.AddDiscounts(["Cepillo"]);
        
        receipt.AddProductToCar("Cepillo");
        receipt.AddProductToCar("Cepillo");
        receipt.AddProductToCar("Cepillo");
        
        receipt.GetReceipt().Should().Be(1.98m);
    }
    
    [Fact]
    public void Si_Compra1KiloDeManzanas_Recibe20PorcientoDeDescuento_PorLoTantoElPrecioTotal_Debe_Ser_1_592()
    {
        var receipt = new SupermarketReceipt();
        receipt.AddDiscounts(["Manzana"]);
        
        receipt.AddProductToCar("Manzana");
        
        receipt.GetReceipt().Should().Be(1.592m);
    }
}

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
            discount = DiscountPercentage(0.2m); 

        return _products.Sum(product => _catalog.GetPriceProduct(product)) - discount;
    }

    private decimal DiscountAmount(int freeAmount)
    {
        return _products
            .Where(product => product == nameof(ProductName.Cepillo))
            .Take(freeAmount)
            .Sum(product => _catalog.GetPriceProduct(product));
    }

    private decimal DiscountPercentage(decimal percentage)
    {
        return _products
            .Where(product => product == nameof(ProductName.Manzana))
            .Sum(product => _catalog.GetPriceProduct(product)) * percentage;
    }
}

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

public record Product(string Name, decimal Price);

public enum ProductName
{
    Cepillo,
    Manzana,
    Arroz,
    TuboPastaDientes,
    TomateCherry
}

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