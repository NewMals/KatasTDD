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
}

public class SupermarketReceipt
{
    private string _product;
    public void AddProductToCar(string product)
    {
        var catalog = new Catalog();
        catalog.AvailableProductInCatalog(product);
        _product = product;
    }

    public decimal GetReceipt()
    {
        
        return _product switch
        {
            "Cepillo" => 0.99m,
            "Manzana" => 1.99m,
            "Arroz" => 2.49m,
            "TuboPastaDientes" => 1.79m,
            _ => 0.69m
        };
    }
}


public class Catalog()
{
    private List<string> _products =
    [
        "Cepillo",
        "Manzana",
        "Arroz",
        "TuboPastaDientes",
        "TomateCherry"
    ];

    public void AvailableProductInCatalog(string product)
    {
        if(_products.All(productInCatalog => productInCatalog != product))
            throw new Exception($"No existe un producto con el nombre {product}");
    }
}
