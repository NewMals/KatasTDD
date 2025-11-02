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
    
    [Fact]
    public void Si_ElNumeroArabicoEs5_Debe_RetornarV()
    {
        var romanNumeral = new RomanNumeral();

        var roman = RomanNumeral.Convert(5);

        roman.Should().Be("V");
    }
    
    [Fact]
    public void Si_ElNumeroArabicoEs6_Debe_RetornarVI()
    {
        var romanNumeral = new RomanNumeral();

        var roman = RomanNumeral.Convert(6);

        roman.Should().Be("VI");
    }
    
    [Fact]
    public void Si_ElNumeroArabicoEs9_Debe_RetornarIX()
    {
        var romanNumeral = new RomanNumeral();

        var roman = RomanNumeral.Convert(9);

        roman.Should().Be("IX");
    }
}

public class RomanNumeral
{
    public static string Convert(int arabicNumber)
    {
        var romanNumeral = "";

        foreach (var roman in Enum.GetValues<RomanToNumeral>().OrderByDescending(x => x))
        {
            if (arabicNumber >= (int)roman)
            {
                romanNumeral += roman.ToString();
                arabicNumber -= (int)roman;
            }
        }
        
        for (var i = 0; i < arabicNumber; i++)
        {
            romanNumeral += "I";
        }
        
        return romanNumeral;
    }
}

public enum RomanToNumeral
{
    IX = 9,
    V = 5,
    IV = 4,
}