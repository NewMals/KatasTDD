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
    
    [Fact]
    public void Si_ElTextoParaAjustarEsWord_Word_Word_Y_LaCantidadDeLasColumnasEs5_Debe_Devolver_Word_Word_Word()
    {
        var result = Wrap("word word word", 6);

        result.Should().Be("word\nword\nword");
    }

    [Fact]
    public void Si_ElTextoParaAjustarEsWord_Word_Word_Y_LaCantidadDeLasColumnas11Es_Debe_Devolver_WordWord_Word()
    {
        var result = Wrap("word word word", 11);

        result.Should().Be("word word\nword");
    }
    
    private static string Wrap(string text, int col)
    {
        if (string.IsNullOrEmpty(text))
            return text;

        return text.Contains(' ')
            ? WrapWithSpaces(text, col)
            : JoinText(WrapText(text, col));
    }
    
    private static List<string> WrapText(string text, int col)
    {
        var wrapped = new List<string>();

        for (var i = 0; i < text.Length; i += col)
        {
            var length = Math.Min(col, text.Length - i);
            wrapped.Add(text.Substring(i, length));
        }

        return wrapped;
    }
    private static string WrapWithSpaces(string text, int col)
    {
        var words = text.Split(' ');
        var wrappedLines = new List<string>();
        var currentLine = "";

        foreach (var word in words)
        {
            if (IsLongerThanColumn(word, col))
            {
                FlushCurrentLineIfNeeded(wrappedLines, currentLine);
                wrappedLines.AddRange(WrapText(word, col));
                continue;
            }

            if (IsCurrentLineEmpty(currentLine))
            {
                currentLine = word;
                continue;
            }

            if (FitsInCurrentLine(currentLine, word, col))
            {
                currentLine = AppendWord(currentLine, word);
            }
            else
            {
                wrappedLines.Add(currentLine);
                currentLine = word;
            }
        }

        FlushCurrentLineIfNeeded(wrappedLines, currentLine);
        return JoinText(wrappedLines);
    }

    private static string JoinText(List<string> listText) => string.Join("\n", listText);
    
    private static bool IsLongerThanColumn(string word, int col) => word.Length > col;

    private static bool IsCurrentLineEmpty(string line) => line.Length == 0;

    private static bool FitsInCurrentLine(string line, string word, int col)
        => line.Length + 1 + word.Length <= col;

    private static string AppendWord(string line, string word) => $"{line} {word}";

    private static void FlushCurrentLineIfNeeded(List<string> lines, string currentLine)
    {
        if (currentLine.Length > 0) 
            lines.Add(currentLine);
    }
}