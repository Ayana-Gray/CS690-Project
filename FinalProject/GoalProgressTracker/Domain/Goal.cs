namespace GoalProgressTracker;

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

public class Goal 
{ 
public string Name { get; set; } = string.Empty;
public DateTime? TargetDate { get; set; } 
public int TargetValue { get; set; } 
public int CurrentProgress { get; set; } 


[JsonIgnore] 
public bool IsCompleted => TargetValue > 0 && CurrentProgress >= TargetValue; 

public List<Milestone> Milestones { get; set; } = new List<Milestone>();


public Goal() { }

public Goal(string name, int targetValue, DateTime? targetDate = null) 
{ 
    this.Name = name; 
    this.TargetValue = targetValue; 
    this.TargetDate = targetDate; 
} 

public override string ToString() => this.Name; 

public void UpdateProgress(int progress) 
{ 
    
    CurrentProgress = Math.Clamp(CurrentProgress + progress, 0, TargetValue); 
} 

public void SetProgress(int progress) 
{ 
   
    CurrentProgress = Math.Clamp(progress, 0, TargetValue); 
} 
}