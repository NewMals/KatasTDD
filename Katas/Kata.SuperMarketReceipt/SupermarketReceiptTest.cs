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
        
        receipt.AddProduct(product);
        
        receipt.GetReceipt().Should().Be(totalPrice);
    }

    [Fact]
    public void Si_NoExisteElProductoPapa_Debe_MostrarUnaExcepcion()
    {
        var receipt = new SupermarketReceipt();
        
        var exception = () => receipt.AddProduct("Papa");
        
        exception.Should().Throw<Exception>();
    }
    
    [Fact]
    public void Si_NoExisteElProductoArveja_Debe_MostrarUnaExcepcion()
    {
        var product = "Arveja";
        var receipt = new SupermarketReceipt();
        
        var exception = () => receipt.AddProduct(product);
        
        exception.Should().Throw<Exception>().WithMessage($"El producto {product} no existe");
    }
}

public class SupermarketReceipt
{
    private string _product;
    public void AddProduct(string product)
    {
        if (product == "Papa")
        {
            throw new Exception();
        }
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



