namespace Kata.MorningRoutines;

public class Activity(string? name, TimeSpan startTime, TimeSpan endTime)
{
    public string? Name { get; } = name;
    private TimeSpan StartTime { get; } = startTime;
    private TimeSpan EndTime { get; } = endTime;


    public static Activity? GetActivity(TimeSpan currentTime) =>
        StoreActivities
            .Activities()
            .FirstOrDefault(firstActivity => firstActivity.StartTime <= currentTime && firstActivity.EndTime >= currentTime);
    
    public static Activity? GetActivity(TimeSpan startTime, TimeSpan endTime) =>
        StoreActivities
            .Activities()
            .FirstOrDefault(firstActivity => firstActivity.StartTime <= startTime && firstActivity.EndTime >= endTime);
    
    public static void AddActivity(Activity activity) => StoreActivities.Activities().Add(activity);
    
}