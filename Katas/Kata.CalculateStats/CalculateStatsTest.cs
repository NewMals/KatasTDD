using AwesomeAssertions;

namespace Kata.CalculateStats;

public class CalculateStatsTest
{
    [Fact]
    public void Test1()
    {
        //Arrange
        var calculateStats = () => new CalculateStats(null); 
        var message = "Secuencia vacia";
        
        //Asserts
        calculateStats.Should().Throw<Exception>();
    }
}

public class CalculateStats
{
    public CalculateStats(List<int>? sequence)
    {
        if (sequence == null || sequence.Count == 0)
            throw new Exception("Secuencia vacia");
    }
}