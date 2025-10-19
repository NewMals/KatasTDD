using AwesomeAssertions;

namespace Kata.CalculateStats;

public class CalculateStatsTest
{
    [Fact]
    public void Test1()
    {
        //Arrange
        var calculateStats = () => new CalculateStats(); 
        
        //Asserts
        calculateStats.Should().Throw<Exception>();
    }
}

public class CalculateStats
{
    
}