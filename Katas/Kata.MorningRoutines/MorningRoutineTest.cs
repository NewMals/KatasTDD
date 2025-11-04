using AwesomeAssertions;

namespace Kata.MorningRoutines;

public class MorningRoutinesTest
{
    [Fact]
    public void Si_LaHoraInicialEsEntre_0600_A_0659_Debe_MostrarActividad_HacerEjercicio()
    {
        var expectedRoutine = "Hacer ejercicio";
        var routineMorning = new MorningRoutine(new TimeSpan(6,0,0), new TimeSpan(6,59,59));

        var activity = routineMorning.GetActivity();

        activity.Should().Be(expectedRoutine);
    }

    [Fact]
    public void Si_LaHoraInicialEsEntre_0700_A_0759_Debe_MostrarActividad_LeerYEstudiar()
    {
        var expectedRoutine = "Leer y estudiar";
        var routineMorning = new MorningRoutine(new TimeSpan(7,0,0), new TimeSpan(7,59,59));

        var activity = routineMorning.GetActivity();

        activity.Should().Be(expectedRoutine);
    }
}

public class MorningRoutine
{
    private TimeSpan _initialHour { get; }
    private TimeSpan _finalHour { get; }
    
    public MorningRoutine(TimeSpan initialHour, TimeSpan finalHour)
    {
        _initialHour = initialHour;
        _finalHour = finalHour;
    }

    public string GetActivity()
    {
        return "Hacer ejercicio";
    }
}