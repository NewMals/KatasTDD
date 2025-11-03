namespace Kata.RomanNumerals;

public class RomanNumeral
{
    public static string Convert(int arabicNumber)
    {
        if(arabicNumber == 0)
            throw new Exception("El numero debe ser mayor a 0");
        
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