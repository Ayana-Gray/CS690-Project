namespace GoalProgressTracker;

using System;
using System.IO;

public class User
{
    public string Name {get; }
    public List<Goal> Goals {get; }
    public User (string name)
    {
        this.Name = name;
        this.Goals = new List<Goal>();
    }
    public override string ToString(){
        return this.Name;
    }
}