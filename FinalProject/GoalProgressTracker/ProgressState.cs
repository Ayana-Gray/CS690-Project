namespace GoalProgressTracker;

using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;


public class ProgressState
{
    public static ProgressMetric vocabularyWordsLearned = new ProgressMetric("Vocabulary Words","Words", 4000);
    public static ProgressMetric readingLessonsCompleted = new ProgressMetric("Reading Lessons", "Lessons", 100);
    public static ProgressMetric verbalExercisesCompleted = new ProgressMetric("Verbal Exercises", "Exercises", 100);
    public static ProgressMetric listeningExercisesCompleted = new ProgressMetric("Listening Exercises", "Exercises", 100);
    public static ProgressMetric halfMarathonRunsCompleted = new ProgressMetric("Runs Completed", "Runs", 64);
    public static ProgressMetric halfMarathonMilesCompleted = new ProgressMetric("Miles Completed", "Miles", 299);
    public static Dictionary<int, int> halfMarathonMilesByWeek = new Dictionary<int, int>();
    public static Dictionary<int, int> halfMarathonRunsByWeek = new Dictionary<int, int>();
    public static ProgressMetric novelPhasesCompleted = new ProgressMetric("Novel Phase Completion", "Phase(s)", 5);
    public static ProgressMetric novelWordCountCompleted = new ProgressMetric("Novel Word Count", "Words", 80000);
    public static readonly string metricsDataPath = "progressMetrics.json";
}