namespace GoalProgressTracker;

using System;
using System.IO;

public class ProgressMetric
{
    public string Name { get; }
    public string Unit { get; }
    public DateTime StartDate { get; set; }
    public int TargetValue { get; set; }
    public int CurrentProgress { get; set; }
    public bool IsCompleted { get; private set; }

    public ProgressMetric(string name,string unit, int targetValue)
    {
        this.Name = name;
        this.Unit = unit;
        this.StartDate = DateTime.Now;
        this.TargetValue = targetValue;
        this.CurrentProgress = 0;
        IsCompleted = false;
    }

    public void UpdateProgress(int progress)
    {
        CurrentProgress += progress;
        
        if (CurrentProgress >= TargetValue)
        {
            IsCompleted = true;
            CurrentProgress = TargetValue; 
        }
    }

    public void SetProgress(int progress)
    {
        if (progress < 0)
        {
            progress = 0;
        }

        CurrentProgress = Math.Min(progress, TargetValue);
        IsCompleted = CurrentProgress >= TargetValue;
    }
    public static double CalculateProgress(int currentProgress, int targetValue)
   {
      if (targetValue == 0) return 0;
      return (double) Math.Round((decimal)currentProgress / targetValue * 100, 2, MidpointRounding.AwayFromZero);
   }
}