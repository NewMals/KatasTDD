
using AwesomeAssertions;

namespace ChrismasSong;

public class ChristmasSongTest
{
    private readonly Song _song = new Song();
    
    [Fact]
    public void Validar_Contenido_Primera_Linea_Primera_Estrofa()
    {
        //Arrange
        var firstLine = _song.GetStropheFirstLine(1);

        //Assert
        firstLine.Should().Be("On the first day of Christmas");
    }
    
    [Fact]
    public void Validar_Primera_Linea_Cada_Estrofa()
    {
        
        //Arrange
        var firstLine = _song.GetStropheFirstLine(7);

        //Assert
        firstLine.Should().Be("On the seventh day of Christmas,");
    }
    
    [Fact]
    public void Validar_Contenido_Segunda_Linea_Primera_Estrofa()
    {   
        //Arrange
        var secondLine = _song.GetStropheSecondLine();

        //Assert
        secondLine.Should().Be("My true love sent to me:");
    }
    
    [Fact]
    public void Validar_Contenido_Primera_Estrofa()
    {
        //Arrange
        var contentStrophe = _song.GetContentStrophe(1);

        //Assert
        contentStrophe.Should().Be("On the first day of Christmas\nMy true love sent to me:\nA partridge in a pear tree.");
    }
    
    [Fact]
    public void Validar_Contenido_Segunda_Estrofa()
    {
        //Arrange
        var getSong = _song.GetContentStrophe(2);

        //Assert
        getSong.Should().Be("On the second day of Christmas\nMy true love sent to me:\nTwo turtle doves and\nA partridge in a pear tree.");
    }
    
    [Fact]
    public void Validar_Contenido_Primera_Estrofa_Con_Salto_Linea()
    {
        //Arrange
        var getSong = $"{_song.GetContentStrophe(1)}\n";

        //Assert
        getSong.Should().Be("On the first day of Christmas\nMy true love sent to me:\nA partridge in a pear tree.\n");
    }
    
    [Theory]
    [InlineData(4, "On the fourth day of Christmas\nMy true love sent to me:\nFour calling birds\nThree french hens\nTwo turtle doves and\nA partridge in a pear tree.")]
    [InlineData(5, "On the fifth day of Christmas\nMy true love sent to me:\nFive golden rings\nFour calling birds\nThree french hens\nTwo turtle doves and\nA partridge in a pear tree.")]
    public void Validar_Contenido_Estrofa(int strophe, string content)
    {
        //Arrange
        var contentStrophe = _song.GetContentStrophe(strophe);

        //Assert
        contentStrophe.Should().Be(content);
    }
    
    [Theory]
    [InlineData(8,"On the eight day of Christmas,\nMy true love sent to me:\nEight maids a-milking\nSeven swans a-swimming\nSix geese a-laying\nFive golden rings\nFour calling birds\nThree french hens\nTwo turtle doves and\nA partridge in a pear tree.")]
    [InlineData(10,"On the tenth day of Christmas,\nMy true love sent to me:\nTen lords a-leaping\nNine ladies dancing\nEight maids a-milking\nSeven swans a-swimming\nSix geese a-laying\nFive golden rings\nFour calling birds\nThree french hens\nTwo turtle doves and\nA partridge in a pear tree.")]
    public void Validar_Primera_Linea_Con_Coma_Al_Final_Estrofa(int  strophe, string content)
    {
        //Arrange
        var getSong = _song.GetContentStrophe(strophe);

        //Assert
        getSong.Should().Be(content);
    }
    
    [Fact]
    public void Test()
    {
        //Arrange
        var strophes ="On the first day of Christmas\nMy true love sent to me:\nA partridge in a pear tree.\n\n" +
                      "On the second day of Christmas\nMy true love sent to me:\nTwo turtle doves and\nA partridge in a pear tree.\n\n" +
                      "On the third day of Christmas\nMy true love sent to me:\nThree french hens\nTwo turtle doves and\nA partridge in a pear tree.\n\n" +
                      "On the fourth day of Christmas\nMy true love sent to me:\nFour calling birds\nThree french hens\nTwo turtle doves and\nA partridge in a pear tree.\n\n" +
                      "On the fifth day of Christmas\nMy true love sent to me:\nFive golden rings\nFour calling birds\nThree french hens\nTwo turtle doves and\nA partridge in a pear tree.\n\n" +
                      "On the sixth day of Christmas,\nMy true love sent to me:\nSix geese a-laying\nFive golden rings\nFour calling birds\nThree french hens\nTwo turtle doves and\nA partridge in a pear tree.\n\n" +
                      "On the seventh day of Christmas,\nMy true love sent to me:\nSeven swans a-swimming\nSix geese a-laying\nFive golden rings\nFour calling birds\nThree french hens\nTwo turtle doves and\nA partridge in a pear tree.\n\n" +
                      "On the eight day of Christmas,\nMy true love sent to me:\nEight maids a-milking\nSeven swans a-swimming\nSix geese a-laying\nFive golden rings\nFour calling birds\nThree french hens\nTwo turtle doves and\nA partridge in a pear tree.\n\n" +
                      "On the ninth day of Christmas,\nMy true love sent to me:\nNine ladies dancing\nEight maids a-milking\nSeven swans a-swimming\nSix geese a-laying\nFive golden rings\nFour calling birds\nThree french hens\nTwo turtle doves and\nA partridge in a pear tree.\n\n" +
                      "On the tenth day of Christmas,\nMy true love sent to me:\nTen lords a-leaping\nNine ladies dancing\nEight maids a-milking\nSeven swans a-swimming\nSix geese a-laying\nFive golden rings\nFour calling birds\nThree french hens\nTwo turtle doves and\nA partridge in a pear tree.\n\n" +
                      "On the eleventh day of Christmas,\nMy true love sent to me:\nEleven pipers piping\nTen lords a-leaping\nNine ladies dancing\nEight maids a-milking\nSeven swans a-swimming\nSix geese a-laying\nFive golden rings\nFour calling birds\nThree french hens\nTwo turtle doves and\nA partridge in a pear tree.\n\n" +
                      "On the twelfth day of Christmas,\nMy true love sent to me:\nTwelve drummers drumming\nEleven pipers piping\nTen lords a-leaping\nNine ladies dancing\nEight maids a-milking\nSeven swans a-swimming\nSix geese a-laying\nFive golden rings\nFour calling birds\nThree french hens\nTwo turtle doves and\nA partridge in a pear tree.";
        
        //Act
        var getSong = _song.GetSong();

        //Assert
        getSong.Should().Be(strophes);
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
        { 8, "eight" },
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
    
    public string GetStropheFirstLine(int strophe) => 
        $"On the {_daysNumbers.First(f => f.Key == strophe ).Value} day of Christmas{(strophe > 5 ? "," : "")}";
    
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
        return 
            GetContentStrophe(1) + "\n\n" +
            GetContentStrophe(2) + "\n\n" +
            GetContentStrophe(3) + "\n\n" +
            GetContentStrophe(4) + "\n\n" +
            GetContentStrophe(5) + "\n\n" +
            GetContentStrophe(6) + "\n\n" +
            GetContentStrophe(7) + "\n\n" +
            GetContentStrophe(8) + "\n\n" +
            GetContentStrophe(9) + "\n\n" +
            GetContentStrophe(10) + "\n\n" +
            GetContentStrophe(11) + "\n\n" +
            GetContentStrophe(12);
    }
}