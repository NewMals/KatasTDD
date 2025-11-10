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
        
        receipt.GetTotalPrice().Should().Be(totalPrice);
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
        
        receipt.GetTotalPrice().Should().Be(2.78m);
    }

    [Fact]
    public void Si_CompraSoloTresCepillosElTerceroEsGratisPorMotivoDeDescuento_PorLoTantoElPrecioTotal_Debe_Ser_1_98()
    {
        var receipt = new SupermarketReceipt();
        var discount = new Discount("Cepillo", "Quantity", 1);
        receipt.AddDiscount(discount);
        
        receipt.AddProductToCar("Cepillo");
        receipt.AddProductToCar("Cepillo");
        receipt.AddProductToCar("Cepillo");
        
        receipt.GetTotalPrice().Should().Be(1.98m);
    }
    
    [Fact]
    public void Si_CompraSoloDosCepillosYNoseAgregaElTercerCepillo_NoTieneDescuento_PorLoTantoElPrecioTotal_Debe_Ser_1_98()
    {
        var receipt = new SupermarketReceipt();
        var discount = new Discount("Cepillo", "Quantity", 1);
        receipt.AddDiscount(discount);
        
        receipt.AddProductToCar("Cepillo");
        receipt.AddProductToCar("Cepillo");
        
        receipt.GetTotalPrice().Should().Be(1.98m);
    }
    
    [Fact]
    public void Si_Compra1KiloDeManzanas_Recibe20PorcientoDeDescuento_PorLoTantoElPrecioTotal_Debe_Ser_1_592()
    {
        var receipt = new SupermarketReceipt();
        var discount = new Discount("Manzana", "Percentage", 0.2m);
        receipt.AddDiscount(discount);
        
        receipt.AddProductToCar("Manzana");
        
        receipt.GetTotalPrice().Should().Be(1.592m);
    }
    
    [Fact]
    public void Si_Compra1SacoDeArroz_Recibe10PorcientoDeDescuento_PorLoTantoElPrecioTotal_Debe_Ser_2_241()
    {
        var receipt = new SupermarketReceipt();
        var discount = new Discount("Arroz", "Percentage", 0.1m);
        receipt.AddDiscount(discount);
        
        receipt.AddProductToCar("Arroz");
        
        receipt.GetTotalPrice().Should().Be(2.241m);
    }
    
    [Fact]
    public void Si_Compra5TubosDePastaDeDientes_RecibeUnPrecioEspecial_PorLoTantoElPrecioTotal_Debe_Ser_7_49()
    {
        var receipt = new SupermarketReceipt();
        var discount = new Discount("TuboPastaDientes", "Bundle", 1.46m, 5);
        receipt.AddDiscount(discount);
        
        receipt.AddProductToCar("TuboPastaDientes");
        receipt.AddProductToCar("TuboPastaDientes");
        receipt.AddProductToCar("TuboPastaDientes");
        receipt.AddProductToCar("TuboPastaDientes");
        receipt.AddProductToCar("TuboPastaDientes");
        
        receipt.GetTotalPrice().Should().Be(7.49m);
    }
    
    [Fact]
    public void Si_Compra4TubosDePastaDeDientes_NoRecibeUnPrecioEspecial_PorLoTantoElPrecioTotal_Debe_Ser_7_16()
    {
        var receipt = new SupermarketReceipt();
        var discount = new Discount("TuboPastaDientes", "Bundle", 1.46m, 5);
        receipt.AddDiscount(discount);
        
        receipt.AddProductToCar("TuboPastaDientes");
        receipt.AddProductToCar("TuboPastaDientes");
        receipt.AddProductToCar("TuboPastaDientes");
        receipt.AddProductToCar("TuboPastaDientes");
        
        receipt.GetTotalPrice().Should().Be(7.16m);
    }
    
    [Fact]
    public void Si_Compra2CajasDeTomatesCherry_RecibeUnPrecioEspecial_PorLoTantoElPrecioTotal_Debe_Ser_0_99()
    {
        var receipt = new SupermarketReceipt();
        var discount = new Discount("TomateCherry", "Bundle", 0.39m, 2);
        receipt.AddDiscount(discount);
        
        receipt.AddProductToCar("TomateCherry");
        receipt.AddProductToCar("TomateCherry");
        
        receipt.GetTotalPrice().Should().Be(0.99m);
    }
    
    [Fact]
    public void Si_Compra3CajasDeTomatesCherry_RecibeUnPrecioEspecialPorLas2CajasPero1LaDebePagarAPrecioNormal_PorLoTantoElPrecioTotal_Debe_Ser_1_68()
    {
        var receipt = new SupermarketReceipt();
        var discount = new Discount("TomateCherry", "Bundle", 0.39m, 2);
        receipt.AddDiscount(discount);
        
        receipt.AddProductToCar("TomateCherry");
        receipt.AddProductToCar("TomateCherry");
        receipt.AddProductToCar("TomateCherry");
        
        receipt.GetTotalPrice().Should().Be(1.68m);
    }
    
    [Fact]
    public void Si_Compra4CajasDeTomatesCherry_RecibeUnPrecioEspecialPorLas4Cajas_PorLoTantoElPrecioTotal_Debe_Ser_1_98()
    {
        var receipt = new SupermarketReceipt();
        var discount = new Discount("TomateCherry", "Bundle", 0.39m, 2);
        receipt.AddDiscount(discount);
        
        receipt.AddProductToCar("TomateCherry");
        receipt.AddProductToCar("TomateCherry");
        receipt.AddProductToCar("TomateCherry");
        receipt.AddProductToCar("TomateCherry");
        
        receipt.GetTotalPrice().Should().Be(1.98m);
    }

    [Fact]
    public void Si_Compra1KiloDeManzanasY1SacoDeArroz_Debe_MostrarElDetalleDeLosProductos()
    {
        var receipt = new SupermarketReceipt();
        
        receipt.AddProductToCar("Manzana");
        receipt.AddProductToCar("Arroz");

        receipt.GetReceipt().Should().Be(" 1 Manzana\n 1 Arroz\n Valor total: 4,48");
    }
    
    [Fact]
    public void Si_Compra2KiloDeManzanasY1TuboDePastaDeDientes_Debe_MostrarElDetalleDeLosProductos()
    {
        var receipt = new SupermarketReceipt();
        
        receipt.AddProductToCar("Manzana");
        receipt.AddProductToCar("TuboPastaDientes");
        receipt.AddProductToCar("Manzana");

        receipt.GetReceipt().Should().Be(" 2 Manzana\n 1 TuboPastaDientes\n Valor total: 5,77");
    }
    
    [Fact]
    public void Si_Compra2KiloDeManzanasY1TuboDePastaDeDientes_Debe_MostrarElDetalleDeLosProductosYSusDescuentos()
    {
        var receipt = new SupermarketReceipt();
        var discountApple = new Discount("Manzana", "Percentage", 0.2m);
        var discountRice = new Discount("Arroz", "Percentage", 0.1m);
        var discountToothpaste = new Discount("TuboPastaDientes", "Bundle", 1.46m, 5);
        receipt.AddDiscount(discountApple);
        receipt.AddDiscount(discountRice);
        receipt.AddDiscount(discountToothpaste);
        
        receipt.AddProductToCar("Manzana");
        receipt.AddProductToCar("TuboPastaDientes");
        receipt.AddProductToCar("Manzana");

        receipt.GetReceipt().Should().Be(" 2 Manzana\n 1 TuboPastaDientes\n Descuentos aplicados: 0,796\n Valor total: 4,974");
    }
    
    [Fact]
    public void Si_Compra2KiloDeManzanasY5TuboDePastaDeDientes_Debe_MostrarElDetalleDeLosProductosSusDescuentosYElValorTotal()
    {
        var receipt = new SupermarketReceipt();
        var discountApple = new Discount("Manzana", "Percentage", 0.2m);
        var discountRice = new Discount("Arroz", "Percentage", 0.1m);
        var discountToothpaste = new Discount("TuboPastaDientes", "Bundle", 1.46m, 5);
        receipt.AddDiscount(discountApple);
        receipt.AddDiscount(discountRice);
        receipt.AddDiscount(discountToothpaste);
        
        receipt.AddProductToCar("TuboPastaDientes");
        receipt.AddProductToCar("TuboPastaDientes");
        receipt.AddProductToCar("TuboPastaDientes");
        receipt.AddProductToCar("TuboPastaDientes");
        receipt.AddProductToCar("TuboPastaDientes");

        receipt.GetReceipt().Should().Be(" 5 TuboPastaDientes\n Descuentos aplicados: 1,46\n Valor total: 7,49");
    }
}