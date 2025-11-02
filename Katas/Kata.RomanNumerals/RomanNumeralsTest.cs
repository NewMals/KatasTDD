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
}

public class RomanNumeral
{
    public static string Convert(int i)
    {
        return "I";
    }
}