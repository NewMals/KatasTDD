using AwesomeAssertions;

namespace Kata.WordWrap;

public class WordWrapTest
{
    
    [Fact]
    public void Si_ElTextoParaAjustarEsVacio_Entonces_Debe_DevolverVacio()
    {
        var result = Wrap("", 1);

        result.Should().Be("");
    }
    
    [Fact]
    public void Si_ElTextoParaAjustarEsThis_Y_LaCantidadDeLasColumnaEs10_Debe_DevolverThis()
    {
        var result = Wrap("this", 10);

        result.Should().Be("this");
    }  
    
    private static string Wrap(string text, int col)
    {
        return text;
    }
    
}