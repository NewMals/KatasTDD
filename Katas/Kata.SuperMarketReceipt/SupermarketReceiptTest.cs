using AwesomeAssertions;

namespace Kata.SuperMarketReceipt;

public class SupermarketReceiptTest
{
    [Fact]
    public void Si_CompraSoloUnCepilloDeDientes_ElPrecioTotalDelRecibo_Debe_SerDe_0_99()
    {
        var product = "Cepillo";
        var totalPrice = 0.99;
        var receipt = new Receipt();

        receipt.AddProduct(product);

        receipt.GetReceipt().Should().Be(totalPrice);
    }
}

public class Receipt
{
    public void AddProduct(string product)
    {
        throw new NotImplementedException();
    }

    public object GetReceipt()
    {
        throw new NotImplementedException();
    }
}