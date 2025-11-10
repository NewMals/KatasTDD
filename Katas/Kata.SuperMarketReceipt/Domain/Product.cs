namespace Kata.SuperMarketReceipt.Domain;

public record Product(string Name, decimal Price);

public enum ProductName
{
    Cepillo,
    Manzana,
    Arroz,
    TuboPastaDientes,
    TomateCherry
}