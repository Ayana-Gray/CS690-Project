namespace GoalProgressTracker;

using System;
using System.IO;

public class Goal
{
    
    public string Name { get; set; }
    public DateTime TargetDate { get; set; }
    public int TargetValue { get; set; }
    public int CurrentProgress { get; set; }
    public bool IsCompleted => CurrentProgress >= TargetValue;
    public List<Milestone> Milestones{get; set; }

    public Goal(string name, DateTime targetDate, int targetValue)
    {
        this.Name = name;
        this.TargetDate = targetDate;
        this.TargetValue = targetValue;
        this.CurrentProgress = 0;
        this.Milestones = new List<Milestone>();
    }
    public override string ToString()
    {
        return this.Name;
    }

    
    public void UpdateProgress(int amount)
    {
        CurrentProgress += amount;
        Console.WriteLine($"{Name} progress updated: {CurrentProgress}/{TargetValue}");
    }
    
}    