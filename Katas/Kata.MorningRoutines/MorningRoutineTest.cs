using AwesomeAssertions;

namespace Kata.MorningRoutines;

public class MorningRoutinesTest
{
    [Fact]
    public void Si_LaHoraInicialEsEntre_0600_A_0659_Debe_MostrarActividad_HacerEjercicio()
    {
        var expectedRoutine = "Hacer ejercicio";
        var routineMorning = new MorningRoutine(new TimeSpan(6,0,0));

        var activity = routineMorning.GetActivity();

        activity.Should().Be(expectedRoutine);
    }

    [Fact]
    public void Si_LaHoraInicialEsEntre_0700_A_0759_Debe_MostrarActividad_LeerYEstudiar()
    {
        var expectedRoutine = "Leer y estudiar";
        var routineMorning = new MorningRoutine(new TimeSpan(7,0,0));

        var activity = routineMorning.GetActivity();

        activity.Should().Be(expectedRoutine);
    }
    
    [Fact]
    public void Si_LaHoraEstaEntre_0800_A_0859_Debe_MostrarActividad_Desayunar()
    {
        var expectedRoutine = "Desayunar";
        var routineMorning = new MorningRoutine(new TimeSpan(8,0,0));

        var activity = routineMorning.GetActivity();

        activity.Should().Be(expectedRoutine);
    }
    
    [Fact]
    public void Si_LaHoraEstaEntre_0900_A_0559_Debe_MostrarActividad_SinActividad()
    {
        var expectedRoutine = "Sin actividad";
        var routineMorning = new MorningRoutine(new TimeSpan(9,0,0));

        var activity = routineMorning.GetActivity();

        activity.Should().Be(expectedRoutine);
    }
}

public class MorningRoutine(TimeSpan currentTime)
{
    private const string SinActividad = "Sin actividad";
    private TimeSpan CurrentTime { get; } = currentTime;

    public string GetActivity() => 
        Activity
            .Activities()
            .FirstOrDefault(firstActivity => firstActivity.StartTime <= CurrentTime &&  firstActivity.EndTime >= CurrentTime)
            ?.Name ?? SinActividad;
        
}

public class Activity
{
    public string? Name { get; private init; }
    public TimeSpan StartTime { get; private init; }
    public TimeSpan EndTime { get; private init; }

    public static List<Activity> Activities() =>
    [
        new()
        {
            Name = "Hacer ejercicio",
            StartTime = new TimeSpan(6, 0, 0),
            EndTime = new TimeSpan(6, 59, 59)
        },

        new()
        {
            Name = "Leer y estudiar",
            StartTime = new TimeSpan(7, 0, 0),
            EndTime = new TimeSpan(7, 29, 59)
        },
        new()
        {
            Name = "Desayunar",
            StartTime = new TimeSpan(8, 0, 0),
            EndTime = new TimeSpan(8, 59, 59)
        }
    ]; 
    
}