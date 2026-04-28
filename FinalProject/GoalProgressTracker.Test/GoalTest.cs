namespace GoalProgressTracker.Tests;
using System;
using Xunit;

[Collection("Sequential")]
public class GoalTests
{
    [Fact]
    public void UpdateProgressTest()
    {
        var goalTests = new Goal("Read Book", 100);
        goalTests.UpdateProgress(-1);
        Assert.Equal(0, goalTests.CurrentProgress);
        Assert.False(goalTests.IsCompleted);
        goalTests.UpdateProgress(110);
        Assert.Equal(100, goalTests.CurrentProgress);
        Assert.True(goalTests.IsCompleted);
    }

    [Fact]
    public void SetProgressTest()
    {
        var goalTests = new Goal("Complete Exercise", 25);
        goalTests.SetProgress(-1);
        Assert.Equal(0, goalTests.CurrentProgress);
        goalTests.SetProgress(35);
        Assert.Equal(25, goalTests.CurrentProgress);
        Assert.True(goalTests.IsCompleted);
    }

}