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

    [Fact]
    public void Si_ElNumeroArabicoEs4_Debe_RetornarIV()
    {
        var romanNumeral = new RomanNumeral();

        var roman = RomanNumeral.Convert(4);

        roman.Should().Be("IV");
    }
}

public class RomanNumeral
{
    public static string Convert(int arabicNumber)
    {
        var romanNumeral = "";
        
        if(arabicNumber == 4)
            return "IV";
        
        for (var i = 0; i < arabicNumber; i++)
        {
            romanNumeral += "I";
        }
        
        return romanNumeral;
    }
}