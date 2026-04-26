namespace GoalProgressTracker;

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

public class Milestone 
{ 
    public string Name { get; set; } = string.Empty; 
    public DateTime DueDate { get; set; } 
    public int TargetValue { get; set; } 
    public int CurrentProgress { get; set; } 

    [JsonIgnore] 
    public bool IsCompleted => TargetValue > 0 && CurrentProgress >= TargetValue; 

    public List<GoalTask> GoalTasks { get; set; } = new List<GoalTask>();

    
    public Milestone() { }

    [JsonConstructor]
    public Milestone(string name, DateTime dueDate, int targetValue, Goal? goal = null) 
    { 
        this.Name = name; 
        this.DueDate = dueDate; 
        this.TargetValue = targetValue; 
        this.GoalTasks = new List<GoalTask>(); 
    } 

   
    public void UpdateProgress(int progress) 
    { 
        CurrentProgress = Math.Clamp(CurrentProgress + progress, 0, TargetValue);
    } 

    public void SetProgress(int value) 
    { 
        CurrentProgress = Math.Clamp(value, 0, TargetValue);
    } 

    public override string ToString() => this.Name; 
}