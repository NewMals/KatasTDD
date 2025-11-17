using AwesomeAssertions;

namespace Kata.WordWrap;

public class WordWrapTest
{
    
    [Fact]
    public void Si_ElTextoParaAjustarEsVacio_Entonces_Debe_Devolver_Vacio()
    {
        var result = Wrap("", 1);

        result.Should().Be("");
    }
    
    [Fact]
    public void Si_ElTextoParaAjustarEsThis_Y_LaCantidadDeLasColumnasEs10_Debe_Devolver_This()
    {
        var result = Wrap("this", 10);

        result.Should().Be("this");
    }  
    
    [Fact]
    public void Si_ElTextoParaAjustarEsWord_Y_LaCantidadDeLasColumnasEs2_Debe_Devolver_Wo_rd()
    {
        var result = Wrap("word", 2);

        result.Should().Be("wo\nrd");
    } 
    
    [Fact]
    public void Si_ElTextoParaAjustarEsAbcdefghij_Y_LaCantidadDeLasColumnasEs3_Debe_Devolver_Abc_def_ghi_j()
    {
        var result = Wrap("abcdefghij", 3);

        result.Should().Be("abc\ndef\nghi\nj");
    }
    
    
  
    
    private static string Wrap(string text, int col)
    {
        if(string.IsNullOrEmpty(text))
            return text;
        
        var wrapText = string.Empty;
        var lineBreakPosition = col;

        for (var character = 0; character < text.Length; character++)
        {
            if (character == lineBreakPosition)
            {
                wrapText += "\n";
                lineBreakPosition += col;
            }
            wrapText += text[character];
        }

        return wrapText;;
    }
    
    
}