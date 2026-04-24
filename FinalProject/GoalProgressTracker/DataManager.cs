namespace GoalProgressTracker;

using System.Text.Json;        
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Globalization;


public class DataManager
{

    public static readonly string metricsDataPath = "progressMetrics.json";

    public static void InitializeMetrics() 
    {
        LoadMetricProgress();
        SyncLanguageLearningGoalProgress();
        HalfMarathonService.InitializeMilestones();
    }
    public static void SaveData(string filePath, string data)
    {
        File.WriteAllText(filePath, data);
    }

    public static string LoadData(string filePath)
    {
        if (File.Exists(filePath))
        {
            return File.ReadAllText(filePath);
        }
        return string.Empty;
    }

    public static void SaveMetricProgress()
    {
        var metricMap = new Dictionary<string, string>
        {
            { "Vocabulary Words Learned", ProgressState.vocabularyWordsLearned.CurrentProgress.ToString() },
            { "Reading Lessons Completed", ProgressState.readingLessonsCompleted.CurrentProgress.ToString() },
            { "Verbal Exercises Completed", ProgressState.verbalExercisesCompleted.CurrentProgress.ToString() },
            { "Listening Exercises Completed", ProgressState.listeningExercisesCompleted.CurrentProgress.ToString() },
            { "Novel Phases Completed", ProgressState.novelPhasesCompleted.CurrentProgress.ToString() },
            { "Novel Word Count Completed", ProgressState.novelWordCountCompleted.CurrentProgress.ToString() },
            { "Half Marathon Runs Completed", ProgressState.halfMarathonRunsCompleted.CurrentProgress.ToString() },
            { "Half Marathon Miles Completed", ProgressState.halfMarathonMilesCompleted.CurrentProgress.ToString() },
            { "Half Marathon Weekly Miles", JsonSerializer.Serialize(ProgressState.halfMarathonMilesByWeek) },
            { "Half Marathon Weekly Runs", JsonSerializer.Serialize(ProgressState.halfMarathonRunsByWeek) },
            { "Half Marathon Race Date", HalfMarathonService.HalfMarathonGoal.TargetDate.HasValue ? HalfMarathonService.HalfMarathonGoal.TargetDate.Value.ToString("yyyy-MM-dd") : string.Empty },
            { "Half Marathon Goal Current Progress", HalfMarathonService.HalfMarathonGoal.CurrentProgress.ToString() },
            { "Novel Creation Goal Data", JsonSerializer.Serialize(NovelCreationService.NovelCreationGoal) },
            { "Half Marathon Goal Data", JsonSerializer.Serialize(HalfMarathonService.HalfMarathonGoal) }
        };

        var json = JsonSerializer.Serialize(metricMap, new JsonSerializerOptions { WriteIndented = true });
        DataManager.SaveData(metricsDataPath, json);
    }

    public static void LoadMetricProgress()
    {
        var rawJson = DataManager.LoadData(metricsDataPath);
        if (string.IsNullOrWhiteSpace(rawJson))
        {
            return;
        }

        try
        {
            var metricMap = JsonSerializer.Deserialize<Dictionary<string, string>>(rawJson);
            if (metricMap is null)
            {
                return;
            }

            if (metricMap.TryGetValue("Vocabulary Words Learned", out var vocabularyValue)
                && int.TryParse(vocabularyValue, out var vocabularyProgress))
            {
                ProgressState.vocabularyWordsLearned.UpdateProgress(vocabularyProgress);
            }

            if (metricMap.TryGetValue("Reading Lessons Completed", out var readingValue)
                && int.TryParse(readingValue, out var readingProgress))
            {
                ProgressState.readingLessonsCompleted.UpdateProgress(readingProgress);
            }

            if (metricMap.TryGetValue("Verbal Exercises Completed", out var verbalValue)
                && int.TryParse(verbalValue, out var verbalProgress))
            {
                ProgressState.verbalExercisesCompleted.UpdateProgress(verbalProgress);
            }

            if (metricMap.TryGetValue("Listening Exercises Completed", out var listeningValue)
                && int.TryParse(listeningValue, out var listeningProgress))
            {
                ProgressState.listeningExercisesCompleted.UpdateProgress(listeningProgress);
            }

            if (metricMap.TryGetValue("Novel Phases Completed", out var phasesValue)
                && int.TryParse(phasesValue, out var phasesProgress))
            {
                ProgressState.novelPhasesCompleted.UpdateProgress(phasesProgress);
            }

            if (metricMap.TryGetValue("Novel Word Count Completed", out var wordCountValue)
                && int.TryParse(wordCountValue, out var wordCountProgress))
            {
                ProgressState.novelWordCountCompleted.UpdateProgress(wordCountProgress);
            }

            if (metricMap.TryGetValue("Half Marathon Runs Completed", out var runsValue)
                && int.TryParse(runsValue, out var runsProgress))
            {
                ProgressState.halfMarathonRunsCompleted.UpdateProgress(runsProgress);
            }

            if (metricMap.TryGetValue("Half Marathon Miles Completed", out var milesValue)
                && int.TryParse(milesValue, out var milesProgress))
            {
                ProgressState.halfMarathonMilesCompleted.UpdateProgress(milesProgress);
            }

            if (metricMap.TryGetValue("Half Marathon Weekly Miles", out var weeklyMilesJson)
                && !string.IsNullOrWhiteSpace(weeklyMilesJson))
            {
                var parsedWeeklyMiles = JsonSerializer.Deserialize<Dictionary<int, int>>(weeklyMilesJson);
                if (parsedWeeklyMiles != null)
                {
                    ProgressState.halfMarathonMilesByWeek = parsedWeeklyMiles;

                    int total = ProgressState.halfMarathonMilesByWeek.Values.Sum();
                    ProgressState.halfMarathonMilesCompleted.SetProgress(total);
                }
            }

            if (metricMap.TryGetValue("Half Marathon Weekly Runs", out var weeklyRunsJson)
                && !string.IsNullOrWhiteSpace(weeklyRunsJson)) 
            {
                var parsedWeeklyRuns = JsonSerializer.Deserialize<Dictionary<int, int>>(weeklyRunsJson);
                if (parsedWeeklyRuns != null) 
                {
                    ProgressState.halfMarathonRunsByWeek = parsedWeeklyRuns;
        
                    int total = ProgressState.halfMarathonRunsByWeek.Values.Sum();
                    ProgressState.halfMarathonRunsCompleted.SetProgress(total);
                }
            }

            if (metricMap.TryGetValue("Half Marathon Race Date", out var halfMarathonDateValue)
                && !string.IsNullOrWhiteSpace(halfMarathonDateValue))
            {
                if (DateTime.TryParseExact(halfMarathonDateValue, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedDate)
                    || DateTime.TryParse(halfMarathonDateValue, out parsedDate))
                {
                    HalfMarathonService.HalfMarathonGoal.TargetDate = parsedDate;
                }
            }

            if (metricMap.TryGetValue("Half Marathon Goal Current Progress", out var halfMarathonGoalCurrentValue)
                && int.TryParse(halfMarathonGoalCurrentValue, out var halfMarathonGoalCurrentProgress))
            {
                HalfMarathonService.HalfMarathonGoal.CurrentProgress = halfMarathonGoalCurrentProgress;
            }

            if (metricMap.TryGetValue("Novel Creation Goal Data", out var novelJson) && !string.IsNullOrWhiteSpace(novelJson))
            {
                var savedNovel = JsonSerializer.Deserialize<Goal>(novelJson);
                if (savedNovel != null)
                {
                    NovelCreationService.NovelCreationGoal = savedNovel;
                }
            }
            
            if (metricMap.TryGetValue("Half Marathon Goal Data", out var marathonJson) && !string.IsNullOrWhiteSpace(marathonJson))
            {
                var savedMarathon = JsonSerializer.Deserialize<Goal>(marathonJson);
                if (savedMarathon != null)
                {
                    HalfMarathonService.HalfMarathonGoal = savedMarathon;
                }
            }  
        }
        catch
        {
            // Ignore abnormal data and continue with default values.
        }
    }

    public static double SyncLanguageLearningGoalProgress()
    {
        LanguageLearningService.UpdateLanguageLearningMilestones(
            ProgressState.vocabularyWordsLearned,
            ProgressState.readingLessonsCompleted,
            ProgressState.verbalExercisesCompleted,
            ProgressState.listeningExercisesCompleted);

        return LanguageLearningService.LanguageLearningGoal.CurrentProgress;
    } 

    public static int GetMilesForWeek(int week) 
    { 
    
    if (ProgressState.halfMarathonMilesByWeek.TryGetValue(week, out var miles)) 
    { 
        return miles; 
    } 
    return 0; 
    } 
    public static int GetRunsForWeek(int week) 
    { 
    if (ProgressState.halfMarathonRunsByWeek.TryGetValue(week, out var runs)) 
    { 
        return runs; 
    } 
    return 0; 
    } 
}