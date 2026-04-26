namespace GoalProgressTracker;

using System;
using System.Text.Json.Serialization;

public class GoalTask 
{ 
    public string Name { get; set; } = string.Empty;
    public int TargetValue { get; set; } 
    public int CurrentProgress { get; set; } 

    
    [JsonIgnore] 
    public bool IsCompleted => TargetValue > 0 && CurrentProgress >= TargetValue; 

    
    public GoalTask() { }

    public GoalTask(string name, int targetValue) 
    { 
        this.Name = name; 
        this.TargetValue = targetValue; 
        this.CurrentProgress = 0; 
    } 

    public override string ToString() => this.Name; 

    public void UpdateProgress(int progress) 
    { 
        
        CurrentProgress = Math.Clamp(CurrentProgress + progress, 0, TargetValue); 
    } 

    public void SetProgress(int value) 
    { 
        
        CurrentProgress = Math.Clamp(value, 0, TargetValue); 
    } 
}