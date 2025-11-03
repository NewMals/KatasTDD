namespace Kata.RomanNumerals;

public class RomanNumeral
{
    public static string Convert(int arabicNumber)
    {
        if(arabicNumber is < 1 or > 3999)
            throw new Exception("El numero arábigo debe ser mayor a 0 y menor a 3999");
        
        var romanNumeral = "";

        foreach (var roman in TypeRomanNumeralsOrderDescending())
        {
            while (arabicNumber >= (int)roman)
            {
                romanNumeral += roman.ToString();
                arabicNumber -= (int)roman;
            }
        }
        return romanNumeral;
    }

    private static IOrderedEnumerable<RomanToNumeral> TypeRomanNumeralsOrderDescending()
    {
        return Enum.GetValues<RomanToNumeral>().OrderByDescending(x => x);
    }
}