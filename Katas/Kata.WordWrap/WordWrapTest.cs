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
    
    private static string Wrap(string text, int col)
    {
        throw new NotImplementedException();
    }
    
}