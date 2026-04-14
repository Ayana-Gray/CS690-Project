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
    public List<Task> Tasks{ get; }
    public Goal? ParentGoal { get; }

    public Milestone(string name, DateTime dueDate, int targetValue, Goal? goal = null)
    {
        this.Name = name;
        this.DueDate = dueDate;
        this.TargetValue = targetValue;
        this.CurrentProgress = 0;
        this.Tasks = new List<Task>();
        this.ParentGoal = goal;
    }
    public override string ToString(){
        return this.Name;
    }
    
}