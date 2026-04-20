namespace GoalProgressTracker;

using System;
using System.IO;

public class ScheduleTemplates
{
   public static readonly string[] LanguageLearningSchedule =
    {
        "Mon: Review your vocabulary list (15 minutes)",
        "Tue: Complete a listening exercise (15 minutes)",
        "Wed: Complete a reading lesson (30 minutes)",
        "Thu: Review your vocabulary list (15 minutes)",
        "Fri: Complete a verbal exercise (15 minutes)",
        "Sat: Complete a reading lesson (30 minutes)",
        "Sun: Review your lessons and keep this session light"
    };


    public static readonly string[] HalfMarathon16WeekTrainingSchedule =
    {
        "WEEK 1:  Mon 3 Mile Easy Run, Tue 2 Mile Speed Run, Thu 3 Mile Easy Run, Sat 4 Mile Long Run",
        "WEEK 2:  Mon 3 Mile Easy Run, Tue 2 Mile Speed Run, Thu 3 Mile Easy Run, Sat 4 Mile Long Run",
        "WEEK 3:  Mon 4 Mile Easy Run, Tue 2 Mile Speed Run, Thu 4 Mile Easy Run, Sat 5 Mile Long Run",
        "WEEK 4:  Mon 4 Mile Easy Run, Tue 2 Mile Speed Run, Thu 4 Mile Easy Run, Sat 5 Mile Long Run",
        "WEEK 5:  Mon 4 Mile Easy Run, Tue 2 Mile Speed Run, Thu 4 Mile Easy Run, Sat 6 Mile Long Run",
        "WEEK 6:  Mon 4 Mile Easy Run, Tue 2 Mile Speed Run, Thu 4 Mile Easy Run, Sat 5K Race",
        "WEEK 7:  Mon 5 Mile Easy Run, Tue 3 Mile Speed Run, Thu 5 Mile Easy Run, Sat 7 Mile Long Run",
        "WEEK 8:  Mon 5 Mile Easy Run, Tue 3 Mile Speed Run, Thu 5 Mile Easy Run, Sat 8 Mile Long Run",
        "WEEK 9:  Mon 5 Mile Easy Run, Tue 3 Mile Speed Run, Thu 5 Mile Easy Run, Sat 10K Race",
        "WEEK 10: Mon 5 Mile Easy Run, Tue 3 Mile Speed Run, Thu 5 Mile Easy Run, Sat 9 Mile Long Run",
        "WEEK 11: Mon 5 Mile Easy Run, Tue 3 Mile Speed Run, Thu 5 Mile Easy Run, Sat 9 Mile Long Run",
        "WEEK 12: Mon 5 Mile Easy Run, Tue 3 Mile Speed Run, Thu 5 Mile Easy Run, Sat 10 Mile Long Run",
        "WEEK 13: Mon 5 Mile Easy Run, Tue 3 Mile Speed Run, Thu 5 Mile Easy Run, Sat 10 Mile Long Run",
        "WEEK 14: Mon 5 Mile Easy Run, Tue 3 Mile Speed Run, Thu 5 Mile Easy Run, Sat 11 Mile Long Run",
        "WEEK 15: Mon 4 Mile Easy Run, Tue 3 Mile Speed Run, Thu 3 Mile Easy Run, Sat 10 Mile Long Run",
        "WEEK 16: Mon 4 Mile Easy Run, Tue 3 Mile Speed Run, Thu 2 Mile Easy Run, Sat HALF MARATHON RACE!!!"
    };
     public static readonly string[] NovelCreationPhaseNames =
    {
        "Phase 1: Prewriting",
        "Phase 2: 1st Draft",
        "Phase 3: Revision / Structural Editing",
        "Phase 4: Editing / Polishing",
        "Phase 5: Final Submission / Proofreading"
    };

    public static readonly string[][] NovelCreationPhaseTasks =
    {
        new[]
        {
            "--Gather ideas",
            "--Outline the plot",
            "--Develop characters",
            "--Create a story roadmap"
        },
        new[]
        {
            "--Write 80,000 words",
            "--Focus on getting the story out"
        },
        new[]
        {
            "--Review the story for major flaws",
            "--Check pacing",
            "--Find plot holes",
            "--Evaluate character development"
        },
        new[]
        {
            "--Refine writing at the sentence level",
            "--Check flow",
            "--Check consistency",
            "--Improve writing style"
        },
        new[]
        {
            "--Final grammar and formatting checks",
            "--Prepare manuscript for agents, publishers, or self-publishing"
        }
    };
}