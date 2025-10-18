
using AwesomeAssertions;

namespace ChrismasSong;

public class ChristmasSongTest
{
    //- [ ] La primera linea de la primera estrofa, debe tener el siguiente contenido: On the first day of Christmas
    [Fact]
    public void test()
    {
        //Arrange
        var song = new Song();
        
        //Act
        var firstLine = song.GetStropheFirstLine();

        //Assert
        firstLine.Should().Be("On the first day of Christmas");
    }
}

public class Song
{
    public string GetStropheFirstLine()
    {
       return "On the first day of Christmas";
    }
}
