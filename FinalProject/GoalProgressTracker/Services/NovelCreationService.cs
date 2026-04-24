namespace GoalProgressTracker;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Transactions;

public class NovelCreationService
{
    public static Goal NovelCreationGoal { get; set; } = new Goal("Novel Creation", 5)
    {
        Milestones = new List<Milestone> 
        {
            new Milestone("Phase 1: Prewriting", DateTime.Now.AddMonths(999), 4 ) 
            {  
                GoalTasks = new List<GoalTask> 
                { 
                    new GoalTask ( "--Gather ideas", 1),
                    new GoalTask ("--Outline the plot", 1),
                    new GoalTask ("--Develop characters", 1),
                    new GoalTask ("--Create a story roadmap", 1)
                }
            },
            new Milestone ("Phase 2: 1st Draft", DateTime.Now.AddMonths(999), 2 )
            {
                GoalTasks = new List<GoalTask>
                { 
                    new GoalTask ("--Write 80,000 words", 80000),
                    new GoalTask ("--Focus on getting the story out", 1)
                }   
            },
            new Milestone ("Phase 3: Revision / Structural Editing",DateTime.Now.AddMonths(999), 4 )
            {
                GoalTasks = new List<GoalTask>
                {
                    new GoalTask ("--Review the story for major flaws",1),
                    new GoalTask ("--Check pacing", 1),
                    new GoalTask ("--Find plot holes", 1),
                    new GoalTask ("--Evaluate character development", 1) 
                }
             
            },

            new Milestone ("Phase 4: Editing / Polishing", DateTime.Now.AddMonths(999), 2)
            { 
                GoalTasks = new List<GoalTask>
                {
                    new GoalTask ("--Refine writing at the sentence level", 1), 
                    new GoalTask ("--Check flow", 1),
                    new GoalTask ("--Check consistency", 1),
                    new GoalTask ("--Improve writing style", 1)
                }
            },
            new Milestone ("Phase 5: Final Submission / Proofreading", DateTime.Now.AddMonths(999), 2) 
            { 
                GoalTasks = new List<GoalTask>
                {
                    new GoalTask ("--Final grammar and formatting checks", 1),
                    new GoalTask ("--Prepare manuscript for agents, publishers, or self-publishing", 1)
                   
                }
            }
        }
    };
}
