using AwesomeAssertions;

namespace Kata.RomanNumerals;

public class RomanNumeralsTest
{
    [Theory]
    [InlineData(1, "I")]
    [InlineData(2, "II")]
    [InlineData(3, "III")]
    public void Si_ElNumeroArabicoEsMenorA4_Debe_RetornarLaCantidadI(int arabicNumber, string romanNumber)
    {
        var romanNumeral = new RomanNumeral();

        var roman = RomanNumeral.Convert(arabicNumber);

        roman.Should().Be(romanNumber);
    }
}

public class RomanNumeral
{
    public static string Convert(int arabicNumber)
    {
        var romanNumeral = "";
        for (var i = 0; i < arabicNumber; i++)
        {
            romanNumeral += "I";
        }
        return romanNumeral;
    }
}