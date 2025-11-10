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
        
        receipt.AddProductToCar("Cepillo");
        receipt.AddProductToCar("Cepillo");
        receipt.AddProductToCar("Cepillo");
        
        receipt.GetReceipt().Should().Be(1.98m);
    }
    
    [Fact]
    public void Si_Compra1KiloDeManzanas_Recibe20PorcientoDeDescuento_PorLoTantoElPrecioTotal_Debe_Ser_1_592()
    {
        var receipt = new SupermarketReceipt();
        
        receipt.AddProductToCar("Manzana");
        
        receipt.GetReceipt().Should().Be(1.592m);
    }
}

public class SupermarketReceipt
{
    private readonly Catalog _catalog = new();
    private readonly List<string> _products = [];

    public void AddProductToCar(string product)
    {
        _catalog.ExistsProductInCatalog(product);
        _products.Add(product);
    }

    public decimal GetReceipt()
    {
        var productAmount = _products.Count(product => product == "Cepillo");
        
        if(productAmount == 3)
            _products.Remove("Cepillo");

        return _products.Sum(product => _catalog.GetPriceProduct(product));
    }
}


public class Catalog
{
    private Dictionary<string, decimal> _products = new()
    {
        {"Cepillo", 0.99m},
        {"Manzana", 1.99m},
        {"Arroz", 2.49m},
        {"TuboPastaDientes", 1.79m},
        {"TomateCherry",  0.69m }
    };

    public void ExistsProductInCatalog(string product)
    {
        if(_products.All(productInCatalog => productInCatalog.Key != product))
            throw new Exception($"No existe un producto con el nombre {product}");
    }

    public decimal GetPriceProduct(string product)
    {
        ExistsProductInCatalog(product);
        return _products.FirstOrDefault(productInCatalog => productInCatalog.Key == product).Value;
    }
}
