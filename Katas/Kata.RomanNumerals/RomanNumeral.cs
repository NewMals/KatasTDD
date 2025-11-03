namespace Kata.RomanNumerals;

public class RomanNumeral
{
    public static string Convert(int arabicNumber)
    {
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