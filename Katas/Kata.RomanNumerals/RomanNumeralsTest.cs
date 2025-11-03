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
    
    [Theory]
    [InlineData(1, "I")]
    [InlineData(5, "V")]
    [InlineData(10, "X")]
    [InlineData(50, "L")]
    [InlineData(100, "C")]
    [InlineData(500, "D")]
    [InlineData(1000, "M")]
    public void Si_ElNumeroArabicoEstaDefinido_Debe_RetornarLaLetraDeacuerdoAsuRegla(int arabicNumber, string romanNumber)
    {
        var roman = RomanNumeral.Convert(arabicNumber);

        roman.Should().Be(romanNumber);
    }
    
    [Theory]
    [InlineData(6, "VI")]
    [InlineData(11, "XI")]
    [InlineData(51, "LI")]
    [InlineData(101, "CI")]
    [InlineData(501, "DI")]
    [InlineData(1001, "MI")]
    public void Si_ElNumeroArabicoEsUnValorDespuesAUnaNuevaRegla_Debe_RetornarElvalorDeLaReglaEsperada(int arabicNumber, string romanNumber)
    {
        var roman = RomanNumeral.Convert(arabicNumber);

        roman.Should().Be(romanNumber);
    }
    
    [Theory]
    [InlineData(4, "IV")]
    [InlineData(9, "IX")]
    [InlineData(49, "XLIX")]
    [InlineData(99, "XCIX")]
    [InlineData(499, "CDXCIX")]
    [InlineData(999, "CMXCIX")]
    public void Si_ElNumeroArabicoEsUnValorAnteriorAUnaNuevaRegla_Debe_RetornarElvalorDeLaReglaEsperada(int arabicNumber, string romanNumber)
    {
        var roman = RomanNumeral.Convert(arabicNumber);

        roman.Should().Be(romanNumber);
    }

    [Fact]
    public void Si_ElNumeroEs0_Debe_RetornarUnaExcepcion()
    {
        var roman = () => RomanNumeral.Convert(0);

        roman.Should().Throw<Exception>();
    }
    
    [Fact]
    public void Si_ElNumeroEsMayorA3999_Debe_RetornarUnaExcepcion()
    {
        var roman = () => RomanNumeral.Convert(3999);

        roman.Should().Throw<Exception>();
    }
}