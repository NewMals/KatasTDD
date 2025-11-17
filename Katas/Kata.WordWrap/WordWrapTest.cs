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
    
    
    [Fact]
    public void Si_ElTextoParaAjustarEsWord_Word_Y_LaCantidadDeLasColumnasEs3_Debe_Devolver_Wor_d_Wor_d()
    {
        var result = Wrap("word word", 3);

        result.Should().Be("wor\nd\nwor\nd");
    }
    
    [Fact]
    public void Si_ElTextoParaAjustarEsWord_Word_Y_LaCantidadDeLasColumnasEs6_Debe_Devolver_Word_Word()
    {
        var result = Wrap("word word", 6);

        result.Should().Be("word\nword");
    } 
    
    [Fact]
    public void Si_ElTextoParaAjustarEsWord_Word_Y_LaCantidadDeLasColumnasEs5_Debe_Devolver_Word_Word()
    {
        var result = Wrap("word word", 5);

        result.Should().Be("word\nword");
    } 

    
    private static string Wrap(string text, int col)
    {
        if(string.IsNullOrEmpty(text))
            return text;

        var textWrap = string.Empty;
        var words = text.Split(' ');
        var wordsWrap = new List<string>();

        foreach (var word in words)
        {
            if(word.Length < col)
                wordsWrap.Add(word);
            else
            {
                var wrapWord = string.Empty;
                var lineBreakPosition = col;
                for (var character = 0; character < word.Length; character++)
                {
                    if (character == lineBreakPosition)
                    {
                        wrapWord += "\n";
                        lineBreakPosition += col;
                    }
                    wrapWord += text[character];
                }
                wordsWrap.Add(wrapWord);
            }

        }

        var wordsCount = wordsWrap.Count;
        var findSpacePosition = text.IndexOf(' ');
        foreach (var word in wordsWrap)
        {
            wordsCount--;
            textWrap += word;
            if (wordsCount > 0)
            {
                if(findSpacePosition > col - 1 || findSpacePosition < col - 1)    
                    textWrap += "\n";
            }
        }

        return textWrap;
    }
    
    
}