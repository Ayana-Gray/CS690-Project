namespace GoalProgressTracker;

using System;
using System.IO;

public class DailyTask
{
    public static string LanguageLearningDailyTask()
    {
        return DateTime.Today.DayOfWeek switch
        {
            DayOfWeek.Monday => "It's Monday: Review your vocabulary list (15 minutes)",
            DayOfWeek.Tuesday => "It's Tuesday: Complete a listening exercise (15 minutes).",
            DayOfWeek.Wednesday => "It's Wednesday: Complete a reading lesson (30 minutes).",
            DayOfWeek.Thursday => "It's Thursday: Review your vocabulary list (15 minutes).",
            DayOfWeek.Friday => "It's Friday: Complete a verbal exercise (15 minutes).",
            DayOfWeek.Saturday => "It's Saturday: Complete a reading lesson (30 minutes).",
            DayOfWeek.Sunday => "It's Sunday: Review your lessons and keep this session light.",
            _ => "Unknown day."
        };
    }

    public static string HalfMarathonDailyTask()
    {
        return DateTime.Today.DayOfWeek switch
        {
            DayOfWeek.Monday => "It's Monday: Complete an easy run and do your strength training.",
            DayOfWeek.Tuesday => "It's Tuesday: Complete a speed run and do your cross training.",
            DayOfWeek.Wednesday => "It's Wednesday: Rest today and do some stretching.",
            DayOfWeek.Thursday => "It's Thursday: Complete an easy run and do your strength training.",
            DayOfWeek.Friday => "It's Friday: Rest today and do your mobility work.",
            DayOfWeek.Saturday => "It's Saturday: Complete your Long run today.",
            DayOfWeek.Sunday => "It's Sunday: Rest and recover.",
            _ => "Unknown day."
        };
    }
     public static string NovelCreationDailyTask(int currentProgress)
    {
        return currentProgress switch
        {
            0 => "Daily task: Phase 1: Prewriting ",
            1 => "Daily task: Phase 2: 1st Draft ",
            2 => "Daily task: Phase 3: Revision / Structural Editing ",
            3 => "Daily task: Phase 4: Editing / Polishing",
            4 => "Daily task: Phase 5: Final Submission / Proofreading",
            5 => "Congratulations! You've completed all phases of your novel creation.",
            _ => "Unknown phase."
        };
    }
    
}