
using AwesomeAssertions;

namespace ChrismasSong;

public class ChristmasSongTest
{
    [Fact]
    public void Validar_Contenido_Primera_Linea_Primera_Estrofa()
    {
        //Arrange
        var song = new Song();
        
        //Act
        var firstLine = song.GetStropheFirstLine(1);

        //Assert
        firstLine.Should().Be("On the first day of Christmas");
    }
    
    [Fact]
    public void Validar_Primera_Linea_Cada_Estrofa()
    {
        //Arrange
        var song = new Song();
        
        //Act
        var firstLine = song.GetStropheFirstLine(7);

        //Assert
        firstLine.Should().Be("On the seventh day of Christmas");
    }
    
    [Fact]
    public void Validar_Contenido_Segunda_Linea_Primera_Estrofa()
    {
        //Arrange
        var song = new Song();
        
        //Act
        var secondLine = song.GetStropheSecondLine();

        //Assert
        secondLine.Should().Be("My true love sent to me:");
    }
    
    [Fact]
    public void Validar_Contenido_Primera_Estrofa()
    {
        //Arrange
        var song = new Song();
        
        //Act
        var contentStrophe = song.GetContentStrophe(1);

        //Assert
        contentStrophe.Should().Be("On the first day of Christmas\nMy true love sent to me:\nA partridge in a pear tree.");
    }
    
    [Fact]
    public void Validar_Contenido_Segunda_Estrofa()
    {
        //Arrange
        var song = new Song();
        
        //Act
        var getSong = song.GetContentStrophe(2);

        //Assert
        getSong.Should().Be("On the second day of Christmas\nMy true love sent to me:\nTwo turtle doves and\nA partridge in a pear tree.");
    }
    
    [Fact]
    public void Validar_Contenido_Primera_Estrofa_Con_Salto_Linea()
    {
        //Arrange
        var song = new Song();
        
        //Act
        var getSong = song.GetSong();

        //Assert
        getSong.Should().Be("On the first day of Christmas\nMy true love sent to me:\nA partridge in a pear tree.\n");
    }
    
    [Theory]
    [InlineData(4, "On the fourth day of Christmas\nMy true love sent to me:\nFour calling birds\nThree french hens\nTwo turtle doves and\nA partridge in a pear tree.")]
    [InlineData(5, "On the fifth day of Christmas\nMy true love sent to me:\nFive golden rings\nFour calling birds\nThree french hens\nTwo turtle doves and\nA partridge in a pear tree.")]
    public void Validar_Contenido_Estrofa(int strophe, string content)
    {
        //Arrange
        var song = new Song();
        
        //Act
        var contentStrophe = song.GetContentStrophe(strophe);

        //Assert
        contentStrophe.Should().Be(content);
    }
}

public class Song
{
    private readonly Dictionary<int, string> _daysNumbers = new()
    {
        { 1, "first" },
        { 2, "second" },
        { 3, "third" },
        { 4, "fourth" },
        { 5, "fifth" },
        { 6, "sixth" },
        { 7, "seventh" },
        { 8, "eighth" },
        { 9, "ninth" },
        { 10, "tenth" },
        { 11, "eleventh" },
        { 12, "twelfth" }
    };

    private readonly List<string> _linesSong =
    [
        "A partridge in a pear tree.",
        "Two turtle doves and",
        "Three french hens",
        "Four calling birds",
        "Five golden rings",
        "Six geese a-laying",
        "Seven swans a-swimming",
        "Eight maids a-milking",
        "Nine ladies dancing",
        "Ten lords a-leaping",
        "Eleven pipers piping",
        "Twelve drummers drumming"
    ];
    
    public string GetStropheFirstLine(int strophe) => $"On the {_daysNumbers.First(f => f.Key == strophe ).Value} day of Christmas";
    
    public string GetStropheSecondLine() => "My true love sent to me:";

    public string GetContentStrophe(int strophe)
    {
        var content = new List<string>
        {
            GetStropheFirstLine(strophe),
            GetStropheSecondLine()
        };
        
        content.AddRange(_linesSong.Take(strophe).Reverse());
        return string.Join("\n", content);
    }
    
    public string GetSong()
    {
        return GetContentStrophe(1) + "\n";
    }
}