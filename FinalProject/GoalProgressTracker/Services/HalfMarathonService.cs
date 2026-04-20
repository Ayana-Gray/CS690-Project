namespace GoalProgressTracker;

using System;
using System.Collections.Generic;
using System.Globalization;


public class HalfMarathonService
{
    public static Goal HalfMarathonGoal { get; set; } = new Goal("Half Marathon", 16);

internal static int? GetCurrentTrainingWeek()
{
    // Use the TargetDate from your Goal object
    if (!HalfMarathonGoal.TargetDate.HasValue)
    {
        return null;
    }

    return CalculateTrainingWeek(HalfMarathonGoal.TargetDate.Value, DateTime.Today);
}

private static int? CalculateTrainingWeek(DateTime raceDate, DateTime today)
{
    // Ensure we are only looking at the Date component to avoid time-of-day math errors
    DateTime raceDay = raceDate.Date;
    DateTime currentDay = today.Date;

    if (currentDay > raceDay) return null;

    int daysUntilRace = (raceDay - currentDay).Days;
    
    // Logic: 112 days out (16 weeks) should be Week 1.
    // 0 days out (race day) should be Week 16.
    //int computedWeek = 16 - (daysUntilRace / 7);
    int computedWeek = 17 - ((daysUntilRace / 7) + 1);

    // Update the progress property on your static object
    HalfMarathonGoal.CurrentProgress = computedWeek;

    // Return null if we are outside the 16-week window (e.g., started 20 weeks early)
    if (computedWeek < 1 || computedWeek > 16)
    {
        return null;
    }

    return HalfMarathonGoal.CurrentProgress;
}
    public static readonly string[] HalfMarathonWeeklyTargetMiles =
    {
        "12 Miles",
        "12 Miles",
        "14 Miles",
        "14 Miles",
        "16 Miles",
        "13 Miles",
        "20 Miles",
        "21 Miles",
        "19 Miles",
        "22 Miles",
        "22 Miles",
        "23 Miles",
        "23 Miles",
        "24 Miles",
        "20 Miles",
        "22 Miles"
    };
    

}