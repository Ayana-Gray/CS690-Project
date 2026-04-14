namespace GoalProgressTracker;

using System;
using System.Collections.Generic;
using System.Globalization;

public class HalfMarathonService
{
    internal static int? GetCurrentTrainingWeek()
    {
        if (!ConsoleUI.MarathonDate.HasValue)
        {
            return null;
        }

        return CalculateTrainingWeek(ConsoleUI.MarathonDate.Value, DateTime.Today);
    }

    private static int? CalculateTrainingWeek(DateTime raceDate, DateTime today)
    {
        var raceDay = raceDate.Date;
        var currentDay = today.Date;

        if (currentDay > raceDay)
        {
            return null;
        }

        var daysUntilRace = (raceDay - currentDay).Days;
        var computedWeek = 16 - (daysUntilRace / 7);

        if (computedWeek < 1 || computedWeek > 16)
        {
            return null;
        }

        return computedWeek;
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