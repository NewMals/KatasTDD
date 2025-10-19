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
    
    [Fact]
    public void S_Primer_Numero_Cuatro_El_Segundo_Numero_Ocho_Debe_Devolve_Valor_Minimo_Cuatro()
    {
        //Arrange
        var sequence = new List<int>(){4, 8};
        var calculateStats = new CalculateStats(sequence); 
        
        //Act
        var valueMin = calculateStats.GetValueMin();
        
        //Asserts
        valueMin.Should().Be(4);
    }
}

public class CalculateStats
{
    public CalculateStats(List<int>? sequence)
    {
        if (sequence == null || sequence.Count == 0)
            throw new Exception("Secuencia vacia");
    }

    public object GetValueMin()
    {
        throw new NotImplementedException();
    }
}