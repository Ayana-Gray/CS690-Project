using Xunit;

namespace GoalProgressTracker.Tests;

public class ProgressMetricTests
{
    [Fact]
    public void UpdateProgressTest()
    {
        var metric = new ProgressMetric("Distance","km", 5);
        metric.UpdateProgress(3);
        Assert.Equal(3, metric.CurrentProgress);
        Assert.False(metric.IsCompleted);
        metric.UpdateProgress(5);
        Assert.Equal(5, metric.CurrentProgress);
        Assert.True(metric.IsCompleted);
    }

    [Fact]
    public void SetProgressTest()
    {
        var metric = new ProgressMetric("Pages","pages", 100);
        metric.SetProgress(-10);
        Assert.Equal(0, metric.CurrentProgress);
        metric.SetProgress(150);
        Assert.Equal(100, metric.CurrentProgress);
        Assert.True(metric.IsCompleted);
    }

    [Fact]
    public void CalculateProgressTest()
    {
        
        var result = ProgressMetric.CalculateProgress(3, 8);
        Assert.Equal(37.5, result);
        Assert.Equal(0.0, ProgressMetric.CalculateProgress(0, 0));
    }
}