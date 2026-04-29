namespace GoalProgressTracker.Tests;
using System;
using Xunit;    


public class HalfMarathonServiceTests
{
    

    [Fact]
    public void NullGetCurrentTrainingWeekTest()
    {
         HalfMarathonService.CalculateTrainingWeek(DateTime.MinValue, DateTime.MinValue);
        Assert.Null(HalfMarathonService.GetCurrentTrainingWeek());
    }

    [Fact]
    public void GetCurrentTrainingWeektest()
    {
        
        int week = 5;
        var testraceDate = DateTime.Today.AddDays(7 * (16 - week));
        var CalculatedWeek = HalfMarathonService.CalculateTrainingWeek(testraceDate, DateTime.Today);
        
        Assert.Equal(week,CalculatedWeek);
    }

    [Fact]
    public void GetCurrentTrainingWeekPassed()
    {
        HalfMarathonService.CalculateTrainingWeek(DateTime.MinValue, DateTime.Today.AddDays(-1));
        Assert.Null(HalfMarathonService.GetCurrentTrainingWeek());
    }
}
