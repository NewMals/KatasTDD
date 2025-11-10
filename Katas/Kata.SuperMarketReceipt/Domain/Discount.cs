namespace Kata.SuperMarketReceipt.Domain;

public record Discount(string ProductName, string Type, decimal PriceDiscount, int Size = 0);