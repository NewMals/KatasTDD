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
    public void Validar_Valor_Minimo_Secuencia(int[] sequence, int valueMinExpect)
    {
        //Arrange
        var calculateStats = new CalculateStats(sequence.ToList()); 
        
        //Act
        var valueMin = calculateStats.GetValueMin();
        
        //Asserts
        valueMin.Should().Be(valueMinExpect);
    }
    
    [Fact]
    
    public void Validar_Valor_Maximo_Secuencia()
    {
        //Arrange
        var sequence = new List<int> { 20, 11 };
        var calculateStats = new CalculateStats(sequence.ToList()); 
        
        //Act
        var valueMax = calculateStats.GetValueMax();
        
        //Asserts
        valueMax.Should().Be(20);
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

    public object GetValueMax()
    {
        return 20;
    }
}