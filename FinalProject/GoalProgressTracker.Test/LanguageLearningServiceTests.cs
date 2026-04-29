namespace GoalProgressTracker.Tests;
using System;
using Xunit;    

public class LanguageLearningServiceTests : IDisposable
{
    public LanguageLearningServiceTests()
    {
       
        LanguageLearningService.LanguageLearningGoal.Milestones.Clear();
        LanguageLearningService.LanguageLearningGoal.CurrentProgress = 0;
    }

    public void Dispose()
    {
        LanguageLearningService.LanguageLearningGoal.Milestones.Clear();
        LanguageLearningService.LanguageLearningGoal.CurrentProgress = 0;
    }

    [Fact]
    public void CalculateOverallProgress_AveragesFourMetrics()
    {
        var Vocabularystudied = new ProgressMetric("Words","", 100);
        var VocalExercises = new ProgressMetric("Vocal Exercises","", 100);
        var AuditoryLessons = new ProgressMetric("Auditory Lessons","", 100);
        var Readingexercises = new ProgressMetric("Reading Exercises","", 100);
        Vocabularystudied.SetProgress(25);
        VocalExercises.SetProgress(50);
        AuditoryLessons.SetProgress(75);
        Readingexercises.SetProgress(100);

        var overall = LanguageLearningService.CalculateOverallProgress(Vocabularystudied, VocalExercises, AuditoryLessons, Readingexercises);
        Assert.Equal(62.5, overall);
    }
}