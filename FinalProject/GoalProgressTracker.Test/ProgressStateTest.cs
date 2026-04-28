namespace GoalProgressTracker.Tests;

using GoalProgressTracker;
using Xunit;
public class ProgressStateTests
{
    [Fact]
    public void VocabularyWordsLearnedTests()
    {
        Assert.Equal("Vocabulary Words", ProgressState.vocabularyWordsLearned.Name);
        Assert.Equal("Words", ProgressState.vocabularyWordsLearned.Unit);
        Assert.Equal(4000, ProgressState.vocabularyWordsLearned.TargetValue);
    }

    [Fact]
    public void ReadingLessonsCompletedTests()
    {
        Assert.Equal("Reading Lessons", ProgressState.readingLessonsCompleted.Name);
        Assert.Equal("Lessons", ProgressState.readingLessonsCompleted.Unit);
        Assert.Equal(100, ProgressState.readingLessonsCompleted.TargetValue);
    }
    [Fact]
    public void VerbalExercisesCompletedTests()
    {
        Assert.Equal("Verbal Exercises", ProgressState.verbalExercisesCompleted.Name);
        Assert.Equal("Exercises", ProgressState.verbalExercisesCompleted.Unit);
        Assert.Equal(100, ProgressState.verbalExercisesCompleted.TargetValue);
    }
    [Fact]
    public void ListeningExercisesCompletedTests()
    {
        Assert.Equal("Listening Exercises", ProgressState.listeningExercisesCompleted.Name);
        Assert.Equal("Exercises", ProgressState.listeningExercisesCompleted.Unit);
        Assert.Equal(100, ProgressState.listeningExercisesCompleted.TargetValue);
    }
    [Fact]
    public void HalfMarathonRunsCompletedTests()
    {
        Assert.Equal("Runs Completed", ProgressState.halfMarathonRunsCompleted.Name);
        Assert.Equal("Runs", ProgressState.halfMarathonRunsCompleted.Unit);
        Assert.Equal(64, ProgressState.halfMarathonRunsCompleted.TargetValue);
    }

    [Fact]

    public void HalfMarathonMilesCompletedTests()
    {
        Assert.Equal("Miles Completed", ProgressState.halfMarathonMilesCompleted.Name);
        Assert.Equal("Miles", ProgressState.halfMarathonMilesCompleted.Unit);
        Assert.Equal(299, ProgressState.halfMarathonMilesCompleted.TargetValue);
    }   
    [Fact]
    public void HalfMarathonMilesByWeekTests()
    {
        Assert.NotNull(ProgressState.halfMarathonMilesByWeek);
        Assert.IsType<Dictionary<int, int>>(ProgressState.halfMarathonMilesByWeek);
    }

    [Fact]    public void HalfMarathonRunsByWeekTests()
    {
        Assert.NotNull(ProgressState.halfMarathonRunsByWeek);
        Assert.IsType<Dictionary<int, int>>(ProgressState.halfMarathonRunsByWeek);
    }
    [Fact]
    public void NovelPhasesCompletedTests()
    {
        Assert.Equal("Novel Phase Completion", ProgressState.novelPhasesCompleted.Name);
        Assert.Equal("Phase(s)", ProgressState.novelPhasesCompleted.Unit);
        Assert.Equal(5, ProgressState.novelPhasesCompleted.TargetValue);
    }
    

    [Fact]
    public void NovelWordCountCompletedTests()
    {
        Assert.Equal("Novel Word Count", ProgressState.novelWordCountCompleted.Name);
        Assert.Equal("Words", ProgressState.novelWordCountCompleted.Unit);
        Assert.Equal(80000, ProgressState.novelWordCountCompleted.TargetValue);
    }

    [Fact]
    public void MetricFilepathTest()
    {
        Assert.Equal("progressMetrics.json", ProgressState.metricsDataPath);
    }
}