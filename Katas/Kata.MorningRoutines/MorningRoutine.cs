namespace Kata.MorningRoutines;

public class MorningRoutine(TimeSpan currentTime)
{
    private const string SinActividad = "Sin actividad";
    private TimeSpan CurrentTime { get; } = currentTime;

    public string GetActivity() =>
        Activity.GetActivity(CurrentTime)?.Name ?? SinActividad;

    public static string AddRoutine(string name, TimeSpan startTime, TimeSpan endTime, bool updateActivityExists = false)
    {
        var activity = Activity.GetActivity(startTime, endTime);

        if (activity is not null && !updateActivityExists)
            throw new Exception(
                $"Para el horario de {startTime.ToString("c")} a {endTime.ToString("c")} existe la actividad {activity.Name}"
            );

        if (activity is not null && updateActivityExists)
        {
            var newStartTime = endTime > activity.StartTime ? endTime : activity.StartTime;
            Activity.UpdateActivity(activity, newStartTime, activity.EndTime);
            
        }
        
        Activity.AddActivity(new Activity(name, startTime, endTime));
        
        return $"Actividad {name} ha sido creada";
    }
}