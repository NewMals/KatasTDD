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
    
    [Fact]
    public void Test()
    {
        //Arrange
        var sequence = new int[] { -125, -4578, 0, 56115, 2, 107, 99, 511, 1300, 4 };
        var calculateStats = new CalculateStats(sequence.ToList()); 
        var stats = $"Valor minimo: -4578\n\n" +
                    $"Valor maximo: 56115\n\n" +
                    $"Cantidad de elementos: 10\n\n" +
                    $"Valor promedio: 5344";

        //Act
        var getStats = calculateStats.GetStas();
        
        //Asserts
        getStats.Should().Be(stats);
    }
}

public class CalculateStats
{
    private List<int> Sequence { get; set; }
    public CalculateStats(List<int>? sequence)
    {
        if (sequence == null || sequence.Count == 0)
            throw new Exception("Secuencia vacia");
        
        Sequence = sequence;
    }

    public int GetValueMin() => Sequence.Min();

    public int GetValueMax() => Sequence.Max();

    public double GetValueAverage() => Math.Round(Sequence.Average());

    public int GetElements() => Sequence.Count;

    public string GetStas() =>
        $"Valor minimo: {GetValueMin()}\n\n" +
        $"Valor maximo: {GetValueMax()}\n\n" +
        $"Cantidad de elementos: {GetElements()}\n\n" +
        $"Valor promedio: {GetValueAverage()}";
    
}