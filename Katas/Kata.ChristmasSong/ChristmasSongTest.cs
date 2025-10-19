
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
        secondLine.Should().Be("My true love sent to me");
    }
    
    [Fact]
    public void Test()
    {
        //Arrange
        var song = new Song();
        
        //Act
        var thirdLine = song.GetStropheThirdLine();

        //Assert
        thirdLine.Should().Be("My true love sent to me");
    }
}

public class Song
{
    public string GetStropheFirstLine()
    {
       return "On the first day of Christmas";
    }

    public string GetStropheSecondLine()
    {
        return  "My true love sent to me";
    }

    public object GetStropheThirdLine()
    {
        throw new NotImplementedException();
    }
}
