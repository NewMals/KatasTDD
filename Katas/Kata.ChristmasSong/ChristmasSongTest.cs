
using AwesomeAssertions;

namespace ChrismasSong;

public class ChristmasSongTest
{
    private readonly Song _song = new Song();
    
    [Fact]
    public void Validar_Contenido_Primera_Linea_Primera_Estrofa()
    {
        //Arrange
        const string content = "On the first day of Christmas";
        
        //Act
        var firstLine = _song.GetStropheFirstLine(1);

        //Assert
        firstLine.Should().Be(content);
    }
    
    [Fact]
    public void Validar_Primera_Linea_Cada_Estrofa()
    {
        
        //Arrange
        const string content = "On the seventh day of Christmas,";
        
        //Act
        var firstLine = _song.GetStropheFirstLine(7);

        //Assert
        firstLine.Should().Be(content);
    }
    
    [Fact]
    public void Validar_Contenido_Segunda_Linea_Primera_Estrofa()
    {   
        //Arrange
        const string content = "My true love sent to me:";
        
        //Act
        var secondLine = Song.SecondLine;

        //Assert
        secondLine.Should().Be(content);
    }
    
    [Fact]
    public void Validar_Contenido_Primera_Estrofa()
    {
        //Arrange
        const string content = "On the first day of Christmas\nMy true love sent to me:\nA partridge in a pear tree.";
        
        //Act
        var contentStrophe = _song.GetContentStrophe(1);

        //Assert
        contentStrophe.Should().Be(content);
    }
    
    [Fact]
    public void Validar_Contenido_Segunda_Estrofa()
    {
        //Arrange
        const string content = "On the second day of Christmas\nMy true love sent to me:\nTwo turtle doves and\nA partridge in a pear tree.";
        
        //Act
        var getSong = _song.GetContentStrophe(2);

        //Assert
        getSong.Should().Be(content);
    }
    
    [Fact]
    public void Validar_Contenido_Primera_Estrofa_Con_Salto_Linea()
    {
        //Arrange
        const string content = "On the first day of Christmas\nMy true love sent to me:\nA partridge in a pear tree.\n";
        
        //Act
        var getSong = $"{_song.GetContentStrophe(1)}\n";

        //Assert
        getSong.Should().Be(content);
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
    public void Si_Estrofa_No_Existe_Debe_Devolver_Excepcion()
    {
        //Arrange
        var song = () => _song.GetContentStrophe(13);
        var message = "Estrofa no existe";
        //Assert
        song.Should().ThrowExactly<Exception>().WithMessage(message);
    }
    
    [Fact]
    public void Validar_Contenido_Cancion()
    {
        //Arrange
        const string content ="On the first day of Christmas\nMy true love sent to me:\nA partridge in a pear tree.\n\n" +
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
        getSong.Should().Be(content);
    }
}