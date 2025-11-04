namespace Kata.MorningRoutines;

public class Activity(string? name, TimeSpan startTime, TimeSpan endTime)
{
    public string? Name { get; } = name;
    public TimeSpan StartTime { get; } = startTime;
    public TimeSpan EndTime { get; } = endTime;


    public static Activity? GetActivity(TimeSpan currentTime) =>
        StoreActivities
            .Activities()
            .FirstOrDefault(firstActivity => firstActivity.StartTime <= currentTime && firstActivity.EndTime >= currentTime);
    
    public static Activity? GetActivity(TimeSpan startTime, TimeSpan endTime) =>
        StoreActivities
            .Activities()
            .FirstOrDefault(firstActivity => firstActivity.StartTime <= startTime && firstActivity.EndTime >= endTime);
    
    public static void AddActivity(Activity activity) => StoreActivities.Activities().Add(activity);

    public static void UpdateActivity(Activity activity, TimeSpan newStartTime, TimeSpan newEndTime)
    {
        var activities = StoreActivities.Activities();
        var indexActivity = activities.FindIndex(findActivity => activity.Name == findActivity.Name);
        activities.RemoveAt(indexActivity);
        activities.Add(new Activity(activity.Name, newStartTime, newEndTime));
    }
}