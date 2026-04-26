namespace GoalProgressTracker.Tests;
using System;
using Xunit;

[Collection("Sequential")]
public class MilestoneTests
{
    [Fact]
    public void UpdateProgressTest()
    {
        var milestoneTests = new Milestone("Distance",DateTime.Today,5);
        milestoneTests.UpdateProgress(-5);
        Assert.Equal(0, milestoneTests.CurrentProgress);
        Assert.False(milestoneTests.IsCompleted);
        milestoneTests.UpdateProgress(6);
        Assert.Equal(5, milestoneTests.CurrentProgress);
        Assert.True(milestoneTests.IsCompleted);
    }

    [Fact]
    public void SetProgressTest()
    {
        var milestoneTests = new Milestone("Pages",DateTime.Today,100);
        milestoneTests.SetProgress(0);
        Assert.Equal(0, milestoneTests.CurrentProgress);
        milestoneTests.SetProgress(150);
        Assert.Equal(100, milestoneTests.CurrentProgress);
        Assert.True(milestoneTests.IsCompleted);
    }

}