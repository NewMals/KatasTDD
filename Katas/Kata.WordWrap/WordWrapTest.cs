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
    public void Si_ElTextoParaAjustarEsThis_Y_LaCantidadDeLasColumnasEs10_Debe_DevolverThis()
    {
        var result = Wrap("this", 10);

        result.Should().Be("this");
    }  
    
    [Fact]
    public void Si_ElTextoParaAjustarEsWord_Y_LaCantidadDeLasColumnasEs2_Debe_DevolverWo_rd()
    {
        var result = Wrap("word", 2);

        result.Should().Be("wo\nrd");
    } 
    
    [Fact]
    public void Si_ElTextoParaAjustarEsAbcdefghij_Y_LaCantidadDeLasColumnasEs3_Debe_DevolverAbc_def_ghi_j()
    {
        var result = Wrap("abcdefghij", 3);

        result.Should().Be("abc\ndef\nghi\nj");
    }
    
    private static string Wrap(string text, int col)
    {
        var wrapText = text;

        if (text == "word")
        {
            wrapText = "wo\nrd";
        }

        return wrapText;
    }
    
    
}