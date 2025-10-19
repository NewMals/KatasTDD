
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
        var firstLine = song.GetStropheFirstLine();

        //Assert
        firstLine.Should().Be("On the first day of Christmas");
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
    public void Validar_Contenido_Tercera_Linea_Segunda_Estrofa()
    {
        //Arrange
        var song = new Song();
        
        //Act
        var thirdLine = song.GetStropheThirdLine();

        //Assert
        thirdLine.Should().Be("A partridge in a pear tree.");
    }
    
    [Fact]
    public void Test()
    {
        //Arrange
        var song = new Song();
        
        //Act
        var contentStrophe = song.GetContentStrophe();

        //Assert
        contentStrophe.Should().Be("On the first day of Christmas\nMy true love sent to me:\nA partridge in a pear tree.");
    }
}

public class Song
{
    public string GetStropheFirstLine() => "On the first day of Christmas";
    
    public string GetStropheSecondLine() => "My true love sent to me:";

    public string GetStropheThirdLine() => "A partridge in a pear tree.";

    public string GetContentStrophe()
    {
        var content = new List<string>
        {
            GetStropheFirstLine(),
            GetStropheSecondLine(),
            GetStropheThirdLine()
        };
        return string.Join("\n", content);
    }

}
