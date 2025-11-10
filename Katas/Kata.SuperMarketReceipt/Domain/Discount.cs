namespace Kata.SuperMarketReceipt.Domain;

public record Discount(string ProductName, string Type, dynamic Value, int Size = 0);