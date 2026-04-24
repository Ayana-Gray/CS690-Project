namespace GoalProgressTracker;

using System;
using System.IO;

public class Milestone
{
    public string Name { get; }
    public DateTime DueDate { get; }
    public int TargetValue { get; set; }
    public int CurrentProgress { get; set; }
    public bool IsCompleted => CurrentProgress >= TargetValue;
    public List<GoalTask> GoalTasks{ get; set; }
    public Milestone(string name, DateTime dueDate, int targetValue,Goal? goal = null)
    {
        this.Name = name;
        this.DueDate = dueDate;
        this.TargetValue = targetValue;
        this.CurrentProgress = 0;
        this.GoalTasks = new List<GoalTask>(); 
    }
    public override string ToString(){
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