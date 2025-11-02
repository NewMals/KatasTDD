using AwesomeAssertions;

namespace Kata.RomanNumerals;

public class RomanNumeralsTest
{
    [Fact]
    public void Si_ElNumeroArabicoEs1_Debe_RetornarI()
    {
        var romanNumeral = new RomanNumeral();

        var roman = RomanNumeral.Convert(1);

        roman.Should().Be("I");
    }
    
    [Fact]
    public void Si_ElNumeroArabicoEs2_Debe_RetornarII()
    {
        var romanNumeral = new RomanNumeral();

        var roman = RomanNumeral.Convert(2);

        roman.Should().Be("II");
    }
    
    [Fact]
    public void Si_ElNumeroArabicoEs3_Debe_RetornarIII()
    {
        var romanNumeral = new RomanNumeral();

        var roman = RomanNumeral.Convert(3);

        roman.Should().Be("III");
    }
}

public class RomanNumeral
{
    public static string Convert(int arabicNumber)
    {
        return arabicNumber == 2 ? "II" : "I";
    }
}