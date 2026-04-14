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
        "WEEK 1:  Mon 3.0 mi easy run, Tue 2.0 mi speed run, Thu 3.0 mi easy run, Sat 4.0 mi long run",
        "WEEK 2:  Mon 3.0 mi easy run, Tue 2.0 mi speed run, Thu 3.0 mi easy run, Sat 4.0 mi long run",
        "WEEK 3:  Mon 3.5 mi easy run, Tue 2.0 mi speed run, Thu 3.5 mi easy run, Sat 5.0 mi long run",
        "WEEK 4:  Mon 3.5 mi easy run, Tue 2.0 mi speed run, Thu 3.5 mi easy run, Sat 5.0 mi long run",
        "WEEK 5:  Mon 4.0 mi easy run, Tue 2.0 mi speed run, Thu 4.0 mi easy run, Sat 6.0 mi long run",
        "WEEK 6:  Mon 4.0 mi easy run, Tue 2.0 mi speed run, Thu 4.0 mi easy run, Sat 5K race",
        "WEEK 7:  Mon 4.5 mi easy run, Tue 3.0 mi speed run, Thu 5.0 mi easy run, Sat 7.0 mi long run",
        "WEEK 8:  Mon 4.5 mi easy run, Tue 3.0 mi speed run, Thu 5.0 mi easy run, Sat 8.0 mi long run",
        "WEEK 9:  Mon 5.0 mi easy run, Tue 3.0 mi speed run, Thu 5.0 mi easy run, Sat 10K race",
        "WEEK 10: Mon 5.0 mi easy run, Tue 3.0 mi speed run, Thu 5.0 mi easy run, Sat 9.0 mi long run",
        "WEEK 11: Mon 5.0 mi easy run, Tue 3.0 mi speed run, Thu 5.0 mi easy run, Sat 9.0 mi long run",
        "WEEK 12: Mon 5.0 mi easy run, Tue 3.0 mi speed run, Thu 5.0 mi easy run, Sat 10.0 mi long run",
        "WEEK 13: Mon 5.0 mi easy run, Tue 3.0 mi speed run, Thu 5.0 mi easy run, Sat 10.0 mi long run",
        "WEEK 14: Mon 5.0 mi easy run, Tue 3.0 mi speed run, Thu 5.0 mi easy run, Sat 11.0 mi long run",
        "WEEK 15: Mon 4.0 mi easy run, Tue 3.0 mi speed run, Thu 3.0 mi easy run, Sat 10.0 mi long run",
        "WEEK 16: Mon 4.0 mi easy run, Tue 3.0 mi speed run, Thu 2.0 mi easy run, Sat HALF MARATHON RACE!!!"
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