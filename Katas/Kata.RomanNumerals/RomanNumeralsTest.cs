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
        var roman = RomanNumeral.Convert(arabicNumber);

        roman.Should().Be(romanNumber);
    }

    [Fact]
    public void Si_ElNumeroArabicoEs4_Debe_RetornarIV()
    {
        var roman = RomanNumeral.Convert(4);

        roman.Should().Be("IV");
    }
    
    [Fact]
    public void Si_ElNumeroArabicoEs6_Debe_RetornarVI()
    {
        var roman = RomanNumeral.Convert(6);

        roman.Should().Be("VI");
    }
    
    [Theory]
    [InlineData(4, "IV")]
    [InlineData(9, "IX")]
    public void Si_ElNumeroArabicoEsUnValorAnteriorAUnaNuevaRegla_Debe_RetornarElvalorDeLaReglaEsperada(int arabicNumber, string romanNumber)
    {
        var roman = RomanNumeral.Convert(arabicNumber);

        roman.Should().Be(romanNumber);
    }
    
    [Theory]
    [InlineData(1, "I")]
    [InlineData(5, "V")]
    [InlineData(10, "X")]
    [InlineData(50, "L")]
    public void Si_ElNumeroArabicoEstaDefinido_Debe_RetornarLaLetraDeacuerdoAsuRegla(int arabicNumber, string romanNumber)
    {
        var roman = RomanNumeral.Convert(arabicNumber);

        roman.Should().Be(romanNumber);
    }
}

public class RomanNumeral
{
    public static string Convert(int arabicNumber)
    {
        var romanNumeral = "";

        foreach (var roman in TypeRomanNumeralsOrderDescending())
        {
            while (arabicNumber >= (int)roman)
            {
                romanNumeral += roman.ToString();
                arabicNumber -= (int)roman;
            }
        }
        return romanNumeral;
    }

    private static IOrderedEnumerable<RomanToNumeral> TypeRomanNumeralsOrderDescending()
    {
        return Enum.GetValues<RomanToNumeral>().OrderByDescending(x => x);
    }
}

public enum RomanToNumeral
{
    L = 50,
    X = 10,
    IX = 9,
    V = 5,
    IV = 4,
    I = 1
}