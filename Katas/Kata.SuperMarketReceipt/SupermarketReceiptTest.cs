using AwesomeAssertions;
using Kata.SuperMarketReceipt.Domain;
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