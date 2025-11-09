using AwesomeAssertions;

namespace Kata.SuperMarketReceipt;

public class SupermarketReceiptTest
{
    [Fact]
    public void Si_CompraSoloUnCepilloDeDientes_ElPrecioTotalDelRecibo_Debe_SerDe_0_99()
    {
        var product = "Cepillo";
        var totalPrice = 0.99m;
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
        _product  = product;
    }

    public decimal GetReceipt()
    {
        return 0.99m;
    }
}