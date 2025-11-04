using AwesomeAssertions;

namespace Kata.MorningRoutines;

public class MorningRoutinesTest
{
    [Fact]
    public void Si_LaHoraInicialEsEntre_0600_A_0659_Debe_MostrarActividad_HacerEjercicio()
    {
        var expectedRoutine = "Hacer ejercicio";
        var routineMorning = new MorningRoutine();

        var activity = routineMorning.GetActivity();

        activity.Should().Be(expectedRoutine);
    }
}

public class MorningRoutine
{
    public object GetActivity()
    {
        throw new NotImplementedException();
    }
}