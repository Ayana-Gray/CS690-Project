namespace GoalProgressTracker;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime;

public class HalfMarathonService
{
  
    public static Goal HalfMarathonGoal { get; set; }= new Goal("Half Marathon", 16);
    
    
    static HalfMarathonService()
    {
        InitializeMilestones();
    }

    public static void InitializeMilestones()
    {
        // Clear existing Milestones (useful for resets)
            HalfMarathonGoal.Milestones.Clear();

        // Check if user has set a date. If not, use Today as a placeholder 
        //  so the code doesn't crash.
            DateTime anchorDate = HalfMarathonGoal.TargetDate ?? DateTime.Today;

        
              HalfMarathonGoal.Milestones.Add(new Milestone("WEEK 1", anchorDate.AddDays(-105), 12)
            {
                GoalTasks = new List<GoalTask>
                {
                    new GoalTask("Mon Run", 3),
                    new GoalTask("Tue Run", 2),
                    new GoalTask("Thu Run", 3),
                    new GoalTask("Sat Run", 4)
                }
            });
              HalfMarathonGoal.Milestones.Add(new Milestone("WEEK 2", anchorDate.AddDays(-98), 12)
            {
                GoalTasks = new List<GoalTask>
                {
                    new GoalTask("Mon Run", 3),
                    new GoalTask("Tue Run", 2),
                    new GoalTask("Thu Run", 3),
                    new GoalTask("Sat Run", 4)
                }
            });
            HalfMarathonGoal.Milestones.Add(new Milestone("WEEK 3", anchorDate.AddDays(-91), 15)
            {
                GoalTasks = new List<GoalTask>
                {
                    new GoalTask("Mon Run", 4),
                    new GoalTask("Tue Run", 2),
                    new GoalTask("Thu Run", 4),
                    new GoalTask("Sat Run", 5)
                }
            });
            HalfMarathonGoal.Milestones.Add(new Milestone("WEEK 4", anchorDate.AddDays(-84), 15) 
            {
                GoalTasks = new List<GoalTask>
                {
                    new GoalTask("Mon Run", 4),
                    new GoalTask("Tue Run", 2),
                    new GoalTask("Thu Run", 4),
                    new GoalTask("Sat Run", 5)
                }
            });
            HalfMarathonGoal.Milestones.Add(new Milestone("WEEK 5", anchorDate.AddDays(-77), 16) 
            {
                GoalTasks = new List<GoalTask>
                {
                    new GoalTask("Mon Run", 4),
                    new GoalTask("Tue Run", 2),
                    new GoalTask("Thu Run", 4),
                    new GoalTask("Sat Run", 6)
                }
            });
            HalfMarathonGoal.Milestones.Add(new Milestone("WEEK 6", anchorDate.AddDays(-70), 13) 
            {
                GoalTasks = new List<GoalTask>
                {
                    new GoalTask("Mon Run", 4),
                    new GoalTask("Tue Run", 2),
                    new GoalTask("Thu Run", 4),
                    new GoalTask("Sat Run", 3)
                }
            });
            HalfMarathonGoal.Milestones.Add(new Milestone("WEEK 7", anchorDate.AddDays(-63), 20) 
            {
                GoalTasks = new List<GoalTask>
                {
                    new GoalTask("Mon Run", 5),
                    new GoalTask("Tue Run", 3),
                    new GoalTask("Thu Run", 5),
                    new GoalTask("Sat Run", 7)
                }
            });
            HalfMarathonGoal.Milestones.Add(new Milestone("WEEK 8", anchorDate.AddDays(-56), 21) 
            {
                GoalTasks = new List<GoalTask>
                {
                    new GoalTask("Mon Run", 5),
                    new GoalTask("Tue Run", 3),
                    new GoalTask("Thu Run", 5),
                    new GoalTask("Sat Run", 8)
                }
            });
            HalfMarathonGoal.Milestones.Add(new Milestone("WEEK 9", anchorDate.AddDays(-49), 19) 
            {
                GoalTasks = new List<GoalTask>
                {
                    new GoalTask("Mon Run", 5),
                    new GoalTask("Tue Run", 3),
                    new GoalTask("Thu Run", 5),
                    new GoalTask("Sat Run", 6)
                }
            });
            HalfMarathonGoal.Milestones.Add(new Milestone("WEEK 10", anchorDate.AddDays(-42), 22) 
            {
                GoalTasks = new List<GoalTask>
                {
                    new GoalTask("Mon Run", 5),
                    new GoalTask("Tue Run", 3),
                    new GoalTask("Thu Run", 5),
                    new GoalTask("Sat Run", 9)
                }
            });
            HalfMarathonGoal.Milestones.Add(new Milestone("WEEK 11", anchorDate.AddDays(-35), 22) 
            {
                GoalTasks = new List<GoalTask>
                {
                    new GoalTask("Mon Run", 5),
                    new GoalTask("Tue Run", 3),
                    new GoalTask("Thu Run", 5),
                    new GoalTask("Sat Run", 9)
                }
            });
            HalfMarathonGoal.Milestones.Add(new Milestone("WEEK 12", anchorDate.AddDays(-28), 23) 
            {
                GoalTasks = new List<GoalTask>
                {
                    new GoalTask("Mon Run", 5),
                    new GoalTask("Tue Run", 3),
                    new GoalTask("Thu Run", 5),
                    new GoalTask("Sat Run", 10)
                }
            });
            HalfMarathonGoal.Milestones.Add(new Milestone("WEEK 13", anchorDate.AddDays(-21), 23) 
            {
                GoalTasks = new List<GoalTask>
                {
                    new GoalTask("Mon Run", 5),
                    new GoalTask("Tue Run", 3),
                    new GoalTask("Thu Run", 5),
                    new GoalTask("Sat Run", 10)
                }
            });
            HalfMarathonGoal.Milestones.Add(new Milestone("WEEK 14", anchorDate.AddDays(-14), 24) 
            {
                GoalTasks = new List<GoalTask>
                {
                    new GoalTask("Mon Run", 5),
                    new GoalTask("Tue Run", 3),
                    new GoalTask("Thu Run", 5),
                    new GoalTask("Sat Run", 11)
                }
            });
            HalfMarathonGoal.Milestones.Add(new Milestone("WEEK 15", anchorDate.AddDays(-7), 20) 
            {
                GoalTasks = new List<GoalTask>
                {
                    new GoalTask("Mon Run", 4),
                    new GoalTask("Tue Run", 3),
                    new GoalTask("Thu Run", 3),
                    new GoalTask("Sat Run", 10)
                }
            });
            // ... Final Week (Week 16) ends on Race Day
            HalfMarathonGoal.Milestones.Add(new Milestone("WEEK 16 (RACE WEEK)", anchorDate, 22)
            {
                GoalTasks = new List<GoalTask>
                {
                    new GoalTask("Mon Run", 4),
                    new GoalTask("Tue Run", 3),
                    new GoalTask("Thu Run", 2),
                    new GoalTask("Sat HALF MARATHON RACE!!!", 13) 
                }
            });
        
    }
 

    public static int? GetCurrentTrainingWeek()
    {
        
        if (!HalfMarathonGoal.TargetDate.HasValue)
        {
            return null;
        }

        return CalculateTrainingWeek(HalfMarathonGoal.TargetDate.Value, DateTime.Today);
    }

    public static int? CalculateTrainingWeek(DateTime raceDate, DateTime today)
    {
        
        DateTime raceDay = raceDate.Date;
        
        DateTime currentDay = today.Date;

        if (currentDay > raceDay) return null;

        int daysUntilRace = (raceDay - currentDay).Days;
        
        
        // 0 days out (race day) should be Week 16.
        
        int computedWeek = 17 - ((daysUntilRace / 7) + 1);

       
        HalfMarathonGoal.CurrentProgress = computedWeek;

        // Return null if we are outside the 16-week window
        if (computedWeek < 1 || computedWeek > 16)
        {
            return null;
        }

        return HalfMarathonGoal.CurrentProgress;
    }
    public static readonly string[] HalfMarathonWeeklyTargetMiles =
    {
        "12",
        "12",
        "15",
        "15",
        "16",
        "13",
        "20",
        "21",
        "19",
        "22",
        "22",
        "23",
        "23",
        "24",
        "20",
        "22"
    };
    
}