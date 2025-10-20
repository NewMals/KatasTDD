using AwesomeAssertions;

namespace Kata.CalculateStats;

public class CalculateStatsTest
{
    [Fact]
    public void Si_Secuencia_Es_Vacia_Debe_Devolver_Excepcion()
    {
        //Arrange
        var calculateStats = () => new CalculateStats(null); 
        const string message = "Secuencia vacia";
        
        //Asserts
        calculateStats.Should().Throw<Exception>().WithMessage(message);
    }
    
    [Theory]
    [InlineData(new int[] {4, 8}, 4)]
    [InlineData(new int[] {-1, 6}, -1)]
    public void Validar_Valor_Minimo_Secuencia(int[] sequence, int valueMinExpected)
    {
        //Arrange
        var calculateStats = new CalculateStats(sequence.ToList()); 
        
        //Act
        var valueMin = calculateStats.GetValueMin();
        
        //Asserts
        valueMin.Should().Be(valueMinExpected);
    }
    
    [Theory]
    [InlineData(new int[] {20, 11}, 20)]
    [InlineData(new int[] {13, -6}, 13)]
    public void Validar_Valor_Maximo_Secuencia(int[] sequence, int valueMaxExpected)
    {
        //Arrange
        var calculateStats = new CalculateStats(sequence.ToList()); 
        
        //Act
        var valueMax = calculateStats.GetValueMax();
        
        //Asserts
        valueMax.Should().Be(valueMaxExpected);
    }
    
    [Theory]
    [InlineData(new int[] {9, 17}, 13)]
    [InlineData(new int[] {6, 9, 15, -2, 92, 11}, 21.833333)]
    public void Validar_Valor_Promedio_Secuencia(int[] sequence, int valueAverageExpected)
    {
        //Arrange
        var calculateStats = new CalculateStats(sequence.ToList()); 

        //Act
        var valueAverage = calculateStats.GetValueAverage();
        
        //Asserts
        valueAverage.Should().Be(valueAverageExpected);
    }
    
    [Theory]
    [InlineData(new int[] {6, 9, 15, -2, 92, 11}, 6)]
    [InlineData(new int[] {5}, 1)]
    public void Validar_Cantidad_Elementos_Secuencia(int[] sequence, int elementsExpected)
    {
        //Arrange
        var calculateStats = new CalculateStats(sequence.ToList()); 

        //Act
        var elements = calculateStats.GetElements();
        
        //Asserts
        elements.Should().Be(elementsExpected);
    }
    
    [Theory]
    [InlineData(new int[]  { -125, -4578, 0, 56115, 2, 107, 99, 511, 1300, 4 }, $"Valor minimo: -4578\n\nValor maximo: 56115\n\nCantidad de elementos: 10\n\nValor promedio: 5344")]
    [InlineData(new int[] {0}, $"Valor minimo: 0\n\nValor maximo: 0\n\nCantidad de elementos: 1\n\nValor promedio: 0")]
    public void Validar_Estadisticas_Secuencia(int[] sequence, string statsExpected)
    {
        //Arrange
        var calculateStats = new CalculateStats(sequence.ToList());

        //Act
        var getStats = calculateStats.GetStas();
        
        //Asserts
        getStats.Should().Be(statsExpected);
    }
}