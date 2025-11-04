namespace Kata.MorningRoutines;

public class StoreActivities
{
    public static List<Activity> Activities() =>
    [
        new("Hacer ejercicio",new TimeSpan(6, 0, 0), new TimeSpan(6, 59, 59)),
        new( "Leer y estudiar", new TimeSpan(7, 0, 0), new TimeSpan(7, 29, 59)),
        new("Desayunar", new TimeSpan(8, 0, 0), new TimeSpan(8, 29, 59))
    ];
}