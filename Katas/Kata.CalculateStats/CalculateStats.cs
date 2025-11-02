namespace Kata.CalculateStats;

public class CalculateStats
{
    private List<int> Sequence { get; }
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