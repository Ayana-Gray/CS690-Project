namespace GoalProgressTracker;

using System;
using System.IO;

public class GoalTask
{
    public string Name { get; }
    public int TargetValue { get; set; }
    public int CurrentProgress { get; set; }
    public bool IsCompleted => CurrentProgress >= TargetValue;
    public GoalTask(string name, int targetValue)
    {
        this.Name = name;
        this.TargetValue = targetValue;
        this.CurrentProgress = 0;
    }
    public override string ToString()
    {
        return this.Name;
    }
     public void UpdateProgress(int amount)
    {
        CurrentProgress += amount;
        
    }   
    public void SetProgress(int value)
    {
        CurrentProgress = value;
    }
}
