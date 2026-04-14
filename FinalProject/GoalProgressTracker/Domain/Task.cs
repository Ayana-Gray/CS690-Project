namespace GoalProgressTracker;

using System;
using System.IO;

public class Task
{
    public string Name { get; }
    public int TargetValue { get; set; }
    public int CurrentProgress { get; set; }
    public bool IsCompleted => CurrentProgress >= TargetValue;
    public Milestone? ParentMilestone { get; }
    public Task(string name, int targetValue, Milestone? milestone = null)
    {
        this.Name = name;
        this.TargetValue = targetValue;
        this.CurrentProgress = 0;
        this.ParentMilestone = milestone;
    }
    public override string ToString()
    {
        return this.Name;
    }
}