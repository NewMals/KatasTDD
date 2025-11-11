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
        var supermarket = new Supermarket();
        
        supermarket.AddProductToCar(product);
        
        supermarket.GetTotalPrice().Should().Be(totalPrice);
    }

    [Fact]
    public void Si_NoExisteElProductoPapa_Debe_MostrarUnaExcepcion()
    {
        var supermarket = new Supermarket();
        
        var exception = () => supermarket.AddProductToCar("Papa");
        
        exception.Should().Throw<Exception>();
    }
    
    [Fact]
    public void Si_NoExisteElProductoArveja_Debe_MostrarUnaExcepcion()
    {
        var product = "Arveja";
        var supermarket = new Supermarket();
        
        var exception = () => supermarket.AddProductToCar(product);
        
        exception.Should().Throw<Exception>().WithMessage($"No existe un producto con el nombre {product}");
    }
    
    [Fact]
    public void Si_CompraSoloUnCepilloYUnTuboDePastaDeDientes_ElPrecioTotal_Debe_Ser_2_78()
    {
        var supermarket = new Supermarket();
        
        supermarket.AddProductToCar("Cepillo");
        supermarket.AddProductToCar("TuboPastaDientes");
        
        supermarket.GetTotalPrice().Should().Be(2.78m);
    }

    [Fact]
    public void Si_CompraSoloTresCepillosElTerceroEsGratisPorMotivoDeDescuento_PorLoTantoElPrecioTotal_Debe_Ser_1_98()
    {
        var supermarket = new Supermarket();
        var discount = new Discount("Cepillo", "Quantity", 1);
        supermarket.AddDiscount(discount);
        
        supermarket.AddProductToCar("Cepillo");
        supermarket.AddProductToCar("Cepillo");
        supermarket.AddProductToCar("Cepillo");
        
        supermarket.GetTotalPrice().Should().Be(1.98m);
    }
    
    [Fact]
    public void Si_CompraSoloDosCepillosYNoseAgregaElTercerCepillo_NoTieneDescuento_PorLoTantoElPrecioTotal_Debe_Ser_1_98()
    {
        var receiptsupermarket = new Supermarket();
        var discount = new Discount("Cepillo", "Quantity", 1);
        receiptsupermarket.AddDiscount(discount);
        
        receiptsupermarket.AddProductToCar("Cepillo");
        receiptsupermarket.AddProductToCar("Cepillo");
        
        receiptsupermarket.GetTotalPrice().Should().Be(1.98m);
    }
    
    [Fact]
    public void Si_Compra1KiloDeManzanas_Recibe20PorcientoDeDescuento_PorLoTantoElPrecioTotal_Debe_Ser_1_592()
    {
        var supermarket = new Supermarket();
        var discount = new Discount("Manzana", "Percentage", 0.2m);
        supermarket.AddDiscount(discount);
        
        supermarket.AddProductToCar("Manzana");
        
        supermarket.GetTotalPrice().Should().Be(1.592m);
    }
    
    [Fact]
    public void Si_Compra1SacoDeArroz_Recibe10PorcientoDeDescuento_PorLoTantoElPrecioTotal_Debe_Ser_2_241()
    {
        var supermarket = new Supermarket();
        var discount = new Discount("Arroz", "Percentage", 0.1m);
        supermarket.AddDiscount(discount);
        
        supermarket.AddProductToCar("Arroz");
        
        supermarket.GetTotalPrice().Should().Be(2.241m);
    }
    
    [Fact]
    public void Si_Compra5TubosDePastaDeDientes_RecibeUnPrecioEspecial_PorLoTantoElPrecioTotal_Debe_Ser_7_49()
    {
        var supermarket = new Supermarket();
        var discount = new Discount("TuboPastaDientes", "Bundle", 1.46m, 5);
        supermarket.AddDiscount(discount);
        
        supermarket.AddProductToCar("TuboPastaDientes");
        supermarket.AddProductToCar("TuboPastaDientes");
        supermarket.AddProductToCar("TuboPastaDientes");
        supermarket.AddProductToCar("TuboPastaDientes");
        supermarket.AddProductToCar("TuboPastaDientes");
        
        supermarket.GetTotalPrice().Should().Be(7.49m);
    }
    
    [Fact]
    public void Si_Compra4TubosDePastaDeDientes_NoRecibeUnPrecioEspecial_PorLoTantoElPrecioTotal_Debe_Ser_7_16()
    {
        var supermarket = new Supermarket();
        var discount = new Discount("TuboPastaDientes", "Bundle", 1.46m, 5);
        supermarket.AddDiscount(discount);
        
        supermarket.AddProductToCar("TuboPastaDientes");
        supermarket.AddProductToCar("TuboPastaDientes");
        supermarket.AddProductToCar("TuboPastaDientes");
        supermarket.AddProductToCar("TuboPastaDientes");
        
        supermarket.GetTotalPrice().Should().Be(7.16m);
    }
    
    [Fact]
    public void Si_Compra2CajasDeTomatesCherry_RecibeUnPrecioEspecial_PorLoTantoElPrecioTotal_Debe_Ser_0_99()
    {
        var supermarket = new Supermarket();
        var discount = new Discount("TomateCherry", "Bundle", 0.39m, 2);
        supermarket.AddDiscount(discount);
        
        supermarket.AddProductToCar("TomateCherry");
        supermarket.AddProductToCar("TomateCherry");
        
        supermarket.GetTotalPrice().Should().Be(0.99m);
    }
    
    [Fact]
    public void Si_Compra3CajasDeTomatesCherry_RecibeUnPrecioEspecialPorLas2CajasPero1LaDebePagarAPrecioNormal_PorLoTantoElPrecioTotal_Debe_Ser_1_68()
    {
        var supermarket = new Supermarket();
        var discount = new Discount("TomateCherry", "Bundle", 0.39m, 2);
        supermarket.AddDiscount(discount);
        
        supermarket.AddProductToCar("TomateCherry");
        supermarket.AddProductToCar("TomateCherry");
        supermarket.AddProductToCar("TomateCherry");
        
        supermarket.GetTotalPrice().Should().Be(1.68m);
    }
    
    [Fact]
    public void Si_Compra4CajasDeTomatesCherry_RecibeUnPrecioEspecialPorLas4Cajas_PorLoTantoElPrecioTotal_Debe_Ser_1_98()
    {
        var supermarket = new Supermarket();
        var discount = new Discount("TomateCherry", "Bundle", 0.39m, 2);
        supermarket.AddDiscount(discount);
        
        supermarket.AddProductToCar("TomateCherry");
        supermarket.AddProductToCar("TomateCherry");
        supermarket.AddProductToCar("TomateCherry");
        supermarket.AddProductToCar("TomateCherry");
        
        supermarket.GetTotalPrice().Should().Be(1.98m);
    }

    [Fact]
    public void Si_Compra1KiloDeManzanasY1SacoDeArroz_Debe_MostrarElDetalleDeLosProductos()
    {
        var supermarket = new Supermarket();
        
        supermarket.AddProductToCar("Manzana");
        supermarket.AddProductToCar("Arroz");

        supermarket.GetReceipt().Should().Be(" 1 Manzana\n 1 Arroz\n Valor total: 4,48");
    }
    
    [Fact]
    public void Si_Compra2KiloDeManzanasY1TuboDePastaDeDientes_Debe_MostrarElDetalleDeLosProductos()
    {
        var supermarket = new Supermarket();
        
        supermarket.AddProductToCar("Manzana");
        supermarket.AddProductToCar("TuboPastaDientes");
        supermarket.AddProductToCar("Manzana");

        supermarket.GetReceipt().Should().Be(" 2 Manzana\n 1 TuboPastaDientes\n Valor total: 5,77");
    }
    
    [Fact]
    public void Si_Compra2KiloDeManzanasY1TuboDePastaDeDientes_Debe_MostrarElDetalleDeLosProductosYSusDescuentos()
    {
        var supermarket = new Supermarket();
        var discountApple = new Discount("Manzana", "Percentage", 0.2m);
        var discountRice = new Discount("Arroz", "Percentage", 0.1m);
        var discountToothpaste = new Discount("TuboPastaDientes", "Bundle", 1.46m, 5);
        supermarket.AddDiscount(discountApple);
        supermarket.AddDiscount(discountRice);
        supermarket.AddDiscount(discountToothpaste);
        
        supermarket.AddProductToCar("Manzana");
        supermarket.AddProductToCar("TuboPastaDientes");
        supermarket.AddProductToCar("Manzana");

        supermarket.GetReceipt().Should().Be(" 2 Manzana\n 1 TuboPastaDientes\n Descuentos aplicados: 0,796\n Valor total: 4,974");
    }
    
    [Fact]
    public void Si_Compra2KiloDeManzanasY5TuboDePastaDeDientes_Debe_MostrarElDetalleDeLosProductosSusDescuentosYElValorTotal()
    {
        var supermarket = new Supermarket();
        var discountApple = new Discount("Manzana", "Percentage", 0.2m);
        var discountRice = new Discount("Arroz", "Percentage", 0.1m);
        var discountToothpaste = new Discount("TuboPastaDientes", "Bundle", 1.46m, 5);
        supermarket.AddDiscount(discountApple);
        supermarket.AddDiscount(discountRice);
        supermarket.AddDiscount(discountToothpaste);
        
        supermarket.AddProductToCar("TuboPastaDientes");
        supermarket.AddProductToCar("TuboPastaDientes");
        supermarket.AddProductToCar("TuboPastaDientes");
        supermarket.AddProductToCar("TuboPastaDientes");
        supermarket.AddProductToCar("TuboPastaDientes");

        supermarket.GetReceipt().Should().Be(" 5 TuboPastaDientes\n Descuentos aplicados: 1,46\n Valor total: 7,49");
    }
}