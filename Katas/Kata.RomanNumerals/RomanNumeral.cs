namespace Kata.RomanNumerals;

public class RomanNumeral
{
    public static string Convert(int arabicNumber)
    {
        ExceptionRange(arabicNumber);
        var romanNumeral = "";

        foreach (var roman in RomanNumeralRulesOrderDescending())
        {
            while (arabicNumber >= (int)roman)
            {
                romanNumeral += roman.ToString();
                arabicNumber -= (int)roman;
            }
        }
        return romanNumeral;
    }

    private static void ExceptionRange(int arabicNumber)
    {
        if(arabicNumber is < 1 or > 3999)
            throw new Exception("El numero arábigo debe ser mayor a 0 y menor a 3999");
    }

    private static IOrderedEnumerable<RomanNumeralRules> RomanNumeralRulesOrderDescending()
    {
        return Enum.GetValues<RomanNumeralRules>().OrderByDescending(romanNumeral => romanNumeral);
    }
}