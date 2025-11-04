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
    private TimeSpan CurrentTime { get; } = currentTime;

    public string GetActivity()
    {
        var activity = "";
        if (new TimeSpan(6, 59, 59) >= CurrentTime && new TimeSpan(6, 0, 0) <= CurrentTime)
            activity = "Hacer ejercicio";
        
        else if (new TimeSpan(7, 59, 59) >= CurrentTime && new TimeSpan(7, 0, 0) <= CurrentTime)
            activity = "Leer y estudiar";
        
        else if (new TimeSpan(8, 59, 59) >= CurrentTime && new TimeSpan(8, 0, 0) <= CurrentTime)
            activity = "Desayunar";
        
        else 
            activity = "Sin actividad";
        
        return activity;
    }
}