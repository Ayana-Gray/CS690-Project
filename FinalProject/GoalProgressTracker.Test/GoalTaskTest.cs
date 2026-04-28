namespace GoalProgressTracker.Tests;
using System;
using Xunit;

[Collection("Sequential")]
public class GoalTaskTests
{
    [Fact]
    public void UpdateProgressTest()
    {
        var goalTaskTests = new GoalTask("Read Book", 100);
        goalTaskTests.UpdateProgress(-2);
        Assert.Equal(0, goalTaskTests.CurrentProgress);
        Assert.False(goalTaskTests.IsCompleted);
        goalTaskTests.UpdateProgress(110);
        Assert.Equal(100, goalTaskTests.CurrentProgress);
        Assert.True(goalTaskTests.IsCompleted);
    }

    [Fact]
    public void SetProgressTest()
    {
        var goalTaskTests = new GoalTask("Complete Exercise", 25);
        goalTaskTests.SetProgress(-100);
        Assert.Equal(0, goalTaskTests.CurrentProgress);
        goalTaskTests.SetProgress(150);
        Assert.Equal(25, goalTaskTests.CurrentProgress);
        Assert.True(goalTaskTests.IsCompleted);
    }

}