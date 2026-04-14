namespace GoalProgressTracker;

using System;
 
public static class LanguageLearningService
{
    private static readonly int[] MilestoneThresholds = { 25, 50, 75, 100 };
    public static Goal LanguageLearningGoal { get; } = new Goal("Language Learning", DateTime.Today.AddYears(1), 100);

    private static void EnsureLanguageLearningMilestonesInitialized()
    {
        foreach (var threshold in MilestoneThresholds)
        {
            var alreadyTracked = LanguageLearningGoal.Milestones.Any(m => m.TargetValue == threshold);
            if (alreadyTracked)
            {
                continue;
            }

            var milestone = new Milestone(
                $"{threshold}% Language Learning Complete",
                DateTime.Today,
                threshold,
                LanguageLearningGoal);

            LanguageLearningGoal.Milestones.Add(milestone);
        }
    }

    public static double CalculateOverallProgress(
        ProgressMetric vocabularyWordsLearned,
        ProgressMetric readingLessonsCompleted,
        ProgressMetric verbalExercisesCompleted,
        ProgressMetric listeningExercisesCompleted)
    {
        var vocabularyProgress = ProgressMetric.CalculateProgress(
            vocabularyWordsLearned.CurrentProgress,
            vocabularyWordsLearned.TargetValue);
        var readingProgress = ProgressMetric.CalculateProgress(
            readingLessonsCompleted.CurrentProgress,
            readingLessonsCompleted.TargetValue);
        var verbalProgress = ProgressMetric.CalculateProgress(
            verbalExercisesCompleted.CurrentProgress,
            verbalExercisesCompleted.TargetValue);
        var listeningProgress = ProgressMetric.CalculateProgress(
            listeningExercisesCompleted.CurrentProgress,
            listeningExercisesCompleted.TargetValue);

        return Math.Round(
            (vocabularyProgress + readingProgress + verbalProgress + listeningProgress) / 4,
            2,
            MidpointRounding.AwayFromZero);
    }

    public static double UpdateLanguageLearningGoalProgress(
        ProgressMetric vocabularyWordsLearned,
        ProgressMetric readingLessonsCompleted,
        ProgressMetric verbalExercisesCompleted,
        ProgressMetric listeningExercisesCompleted)
    {
        var overallProgress = CalculateOverallProgress(
            vocabularyWordsLearned,
            readingLessonsCompleted,
            verbalExercisesCompleted,
            listeningExercisesCompleted);

        LanguageLearningGoal.CurrentProgress = (int)Math.Round(overallProgress, 0, MidpointRounding.AwayFromZero);
        return overallProgress;
    }

    public static void UpdateLanguageLearningMilestones(
        ProgressMetric vocabularyWordsLearned,
        ProgressMetric readingLessonsCompleted,
        ProgressMetric verbalExercisesCompleted,
        ProgressMetric listeningExercisesCompleted)
    {
        var overallProgress = UpdateLanguageLearningGoalProgress(
            vocabularyWordsLearned,
            readingLessonsCompleted,
            verbalExercisesCompleted,
            listeningExercisesCompleted);

        var roundedProgress = (int)Math.Round(overallProgress, 0, MidpointRounding.AwayFromZero);

        EnsureLanguageLearningMilestonesInitialized();

        foreach (var milestone in LanguageLearningGoal.Milestones)
        {
            milestone.CurrentProgress = roundedProgress >= milestone.TargetValue
                ? milestone.TargetValue
                : roundedProgress;
        }
    }

    public static void PrintLanguageLearningMilestones()
    {
        EnsureLanguageLearningMilestonesInitialized();

        Console.WriteLine($"Milestones for {LanguageLearningGoal.Name}:");
        foreach (var milestone in LanguageLearningGoal.Milestones)
        {
            var status = milestone.IsCompleted
                ? "Completed"
                : $"In Progress ({milestone.CurrentProgress}/{milestone.TargetValue})";
            Console.WriteLine($"- {milestone.Name}: {status}");
        }
    }
}