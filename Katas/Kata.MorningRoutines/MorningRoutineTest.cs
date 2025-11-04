using AwesomeAssertions;

namespace Kata.MorningRoutines;

public class MorningRoutinesTest
{
    [Fact]
    public void Si_LaHoraInicialEsEntre_0600_A_0659_Debe_MostrarActividad_HacerEjercicio()
    {
        var expectedRoutine = "Hacer ejercicio";
        var routineMorning = new MorningRoutine(new TimeSpan(6, 0, 0));

        var activity = routineMorning.GetActivity();

        activity.Should().Be(expectedRoutine);
    }

    [Fact]
    public void Si_LaHoraInicialEsEntre_0700_A_0759_Debe_MostrarActividad_LeerYEstudiar()
    {
        var expectedRoutine = "Leer y estudiar";
        var routineMorning = new MorningRoutine(new TimeSpan(7, 0, 0));

        var activity = routineMorning.GetActivity();

        activity.Should().Be(expectedRoutine);
    }

    [Fact]
    public void Si_LaHoraEstaEntre_0800_A_0859_Debe_MostrarActividad_Desayunar()
    {
        var expectedRoutine = "Desayunar";
        var routineMorning = new MorningRoutine(new TimeSpan(8, 0, 0));

        var activity = routineMorning.GetActivity();

        activity.Should().Be(expectedRoutine);
    }

    [Fact]
    public void Si_LaHoraEstaEntre_0900_A_0559_Debe_MostrarActividad_SinActividad()
    {
        var expectedRoutine = "Sin actividad";
        var routineMorning = new MorningRoutine(new TimeSpan(9, 0, 0));

        var activity = routineMorning.GetActivity();

        activity.Should().Be(expectedRoutine);
    }

    [Fact]
    public void Si_QuieroAgregarLaActividad_Leer_Entre_0700_A_0729_Debe_MostrarUnMensajeIndicando_LaActividadQueExiste()
    {
        var routineMorning = new MorningRoutine(new TimeSpan(7, 20, 15));

        var activity = () => routineMorning.AddRoutine("Leer", new TimeSpan(7, 0, 0), new TimeSpan(7, 29, 59));

        activity.Should().ThrowExactly<Exception>().WithMessage("Para el horario de 07:00:00 a 07:29:59 existe la actividad Leer y estudiar");
    }
    
    [Fact]
    public void Si_QuieroAgregarLaActividad_Leer_Entre_0700_A_0729_IndicandoQueSeCreoLaActividad_Leer()
    {
        var routineMorning = new MorningRoutine(new TimeSpan(7, 20, 15));

        var newActivity = routineMorning.AddRoutine("Leer", new TimeSpan(7, 0, 0), new TimeSpan(7, 29, 59), true);
        
        newActivity.Should().Be("Actividad Leer ha sido creada");
    }
}