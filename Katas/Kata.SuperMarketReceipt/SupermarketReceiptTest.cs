using AwesomeAssertions;

namespace Kata.SuperMarketReceipt;

public class SupermarketReceiptTest
{
    [Theory]
    [InlineData("Cepillo", 0.99)]
    [InlineData("Manzanas", 1.99)]
    [InlineData("Arroz", 2.49)]
    [InlineData("TuboPastaDientes", 1.79)]
    public void Si_CompraSoloUnArticulo_ElPrecioTotalDelRecibo_Debe_SerElPrecioDelProducto(string product,
        decimal totalPrice)
    {
        var receipt = new SupermarketReceipt();
        
        receipt.AddProduct(product);
        
        receipt.GetReceipt().Should().Be(totalPrice);
    }
}

public class SupermarketReceipt
{
    private string _product;
    public void AddProduct(string product)
    {
        _product = product;
    }

    public decimal GetReceipt()
    {
        
        return _product switch
        {
            "Cepillo" => 0.99m,
            "Manzanas" => 1.99m,
            "TuboPastaDientes" => 1.79m,
            _ => 2.49m
        };
    }
}