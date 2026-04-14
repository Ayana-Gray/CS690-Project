namespace GoalProgressTracker;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json;

public class ConsoleUI
{
   
    internal static DateTime? MarathonDate { get; private set; }
    static ProgressMetric vocabularyWordsLearned = new ProgressMetric("Vocabulary Words","Words", 4000);
    static ProgressMetric readingLessonsCompleted = new ProgressMetric("Reading Lessons", "Lessons", 100);
    static ProgressMetric verbalExercisesCompleted = new ProgressMetric("Verbal Exercises", "Exercises", 100);
    static ProgressMetric listeningExercisesCompleted = new ProgressMetric("Listening Exercises", "Exercises", 100);
    static ProgressMetric halfMarathonRunsCompleted = new ProgressMetric("Runs Completed", "Runs", 64);
    static ProgressMetric halfMarathonMilesCompleted = new ProgressMetric("Miles Completed", "Miles", 297);
    static Dictionary<int, int> halfMarathonMilesByWeek = new Dictionary<int, int>();
    static Dictionary<int, int> halfMarathonRunsByWeek = new Dictionary<int, int>();
    static ProgressMetric novelPhasesCompleted = new ProgressMetric("Novel Phase Completion", "Phase(s)", 5);
    static ProgressMetric novelWordCountCompleted = new ProgressMetric("Novel Word Count", "Words", 80000);
    private static readonly string metricsDataPath = "progressMetrics.json";
   
    
    
    internal static bool keepRunning = true;

    public static void InitializeMetrics()
    {
        LoadMetricProgress();
        SyncLanguageLearningGoalProgress();
    }



    public static void MainMenu()
    {
        
            ShowHeader("            Main Menu", 40);
            WriteOptions(Menus.MainMenu);
            Console.WriteLine(new string('-', 40));
            Console.WriteLine();
            Console.Write("Please make a selection: ");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("You selected: Language Learning");
                    LanguageLearningMenu();
                    break;
                case "2":
                    Console.WriteLine("You selected: Half Marathon Training");
                    HalfMarathonTrainingMenu();
                    break;
                case "3":
                    Console.WriteLine("You selected: Novel Creation");
                    NovelCreationMenu();
                    break;
                case "4":
                    Console.WriteLine("You selected: Journal");
                    JournalMenu();
                    break;
                case "5":
                    Console.WriteLine("You selected: Set A Reminder");
                    SetAReminderMenu();
                    break;                    
                case "6":
                    keepRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid goal.");
                    ConsolePause("Press any key to continue...");
                    break;
            }
            Console.WriteLine("Thank you for using the Progress Tracker. Goodbye!");
    }
    private static void LanguageLearningMenu()
    {
        var backToMain = false;

        while (!backToMain && keepRunning)
        {
            ShowHeader("        Language Learning Menu", 40);
            WriteOptions(Menus.LanguageLearningMenu);
            Console.WriteLine(new string('-', 40));
            Console.WriteLine();
            Console.Write("Please make a selection: ");

            switch (Console.ReadLine())
            {
                case "1":
                
                    ShowLanguageLearningHomepage();
                    Console.WriteLine("You selected: Language Learning Homepage");
                    ConsolePause("Press any key to continue...");
                    break;
                case "2":
                    LanguageLearningWeeklySchedule();
                    Console.WriteLine("You selected: Language Learning Schedule");
                    ConsolePause("Press any key to continue...");
                    break;
                case "3":
                    LanguageLearningRecordProgressMenu(); 
                    break;
                case "4":
                    ShowLanguageLearningProgressReport();
                    Console.WriteLine("You selected: View Language Learning Progress Report");
                    ConsolePause("Press any key to continue...");
                    break;
                case "5":
                case "back":
                    backToMain = true;
                    break;
                case "6":
                case "exit":
                    keepRunning = false;
                    backToMain = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please make a valid selection.");
                    ConsolePause("Press any key to continue...");
                    break;
            }
        }
    }
    private static void LanguageLearningRecordProgressMenu()
    {
        var backToSubmenu = false;

        while (!backToSubmenu && keepRunning)
        {
            ShowHeader(" Record Language Learning Progress Menu", 50);
            WriteOptions(Menus.LanguageLearningProgressMenu);
            Console.WriteLine(new string('-', 50));
            Console.WriteLine();
            Console.Write("Please make a selection: ");

            switch (Console.ReadLine())
            {
                case "1":
                    ShowHeader("       Record Progress for Vocabulary Words Learned", 60);
                    Console.WriteLine();
                    Console.WriteLine("Current Vocabulary Words Learned: " + vocabularyWordsLearned.CurrentProgress + " / " + vocabularyWordsLearned.TargetValue + " " + vocabularyWordsLearned.Unit);
                    Console.WriteLine();
                    Console.WriteLine(new string('-', 60)); 
                    RecordMetricProgress("Vocabulary Words Learned");
                    Console.WriteLine();    
                    break;
                case "2":
                    ShowHeader(".      Record Progress for Reading Lessons Completed", 60);
                    Console.WriteLine("\nCurrent Reading Lessons Completed: " + readingLessonsCompleted.CurrentProgress + " / " + readingLessonsCompleted.TargetValue + " " + readingLessonsCompleted.Unit);
                    Console.WriteLine();    
                    Console.WriteLine(new string('-', 60));
                    RecordMetricProgress("Reading Lessons Completed");
                   
                    break;
                case "3":
                    ShowHeader("    Record Progress for Verbal Exercises Completed", 60);
                    Console.WriteLine("\nCurrent Verbal Exercises Completed: " + verbalExercisesCompleted.CurrentProgress + " / " + verbalExercisesCompleted.TargetValue + " " + verbalExercisesCompleted.Unit);
                    Console.WriteLine();
                    Console.WriteLine(new string('-', 60));
                    RecordMetricProgress("Verbal Exercises Completed");
                    break;
                case "4":
                    ShowHeader(".    Record Progress for Listening Exercises Completed", 60);
                    Console.WriteLine("\nCurrent Listening Exercises Completed: " + listeningExercisesCompleted.CurrentProgress + " / " + listeningExercisesCompleted.TargetValue + " " + listeningExercisesCompleted.Unit);
                    Console.WriteLine();
                    Console.WriteLine(new string('-', 60));
                    RecordMetricProgress("Listening Exercises Completed");
                    
                    break;
                case "5":     
                    backToSubmenu = true;
                    break;
                case "6":
                case "exit":
                    keepRunning = false;
                    backToSubmenu = true;
                    break;
                default:
                    ConsolePause("Invalid selection.");
                    break;
            }
        }
    }
    private static void HalfMarathonTrainingMenu()
    {
        var backToMain = false;

        while (!backToMain && keepRunning)
        {
            ShowHeader("        Half Marathon Training Menu", 40);                
            WriteOptions(Menus.HalfMarathonTrainingMenu);
            Console.WriteLine(new string('-', 40));
            Console.WriteLine();
            Console.Write("Please make a selection: ");

            switch (Console.ReadLine())
            {
                case "1":
                    ShowHalfMarathonHomepage();
                    Console.WriteLine("You selected: Half Marathon Training Homepage");
                    ConsolePause("Press any key to continue...");
                    break;
                case "2":
                    HalfMarathon16WeekSchedule();
                    Console.WriteLine("You selected: View 16-Week Schedule");
                    ConsolePause("Press any key to continue...");
                    break;
                case "3":
                    ShowHeader("       Record Progress for Half Marathon Training", 60);
                    Console.WriteLine("\nThis Current Week's Progress:");
                    var activeWeek = HalfMarathonService.GetCurrentTrainingWeek();
                    if (activeWeek.HasValue)
                    {
                       
                        Console.WriteLine("Current week runs: " + GetRunsForWeek(activeWeek.Value) + "/4");
                        Console.WriteLine("Current week miles: " + GetMilesForWeek(activeWeek.Value) + "/" + HalfMarathonService.HalfMarathonWeeklyTargetMiles[activeWeek.Value - 1]);
                    }
                    Console.WriteLine("\nOverall progress towards goal: (" + HalfMarathonService.GetCurrentTrainingWeek() / 16.0 * 100 + "%)");
                    Console.WriteLine("Total runs completed: " + halfMarathonRunsCompleted.CurrentProgress + "/" + halfMarathonRunsCompleted.TargetValue + " " + halfMarathonRunsCompleted.Unit);
                    Console.WriteLine("Total miles completed: " + halfMarathonMilesCompleted.CurrentProgress + "/" + halfMarathonMilesCompleted.TargetValue + " " + halfMarathonMilesCompleted.Unit);
                    Console.WriteLine();
                    Console.WriteLine(new string('-', 60)); 
                    RecordHalfMarathonRunsByWeek();
                    RecordHalfMarathonMilesByWeek();
                    ConsolePause("Press any key to continue...");
                    break;
                case "4":
                    ShowHeader("     Half Marathon Training Progress Report", 60);
                    Console.WriteLine("\nThis Current Week's Progress:");
                    var currentWeek = HalfMarathonService.GetCurrentTrainingWeek();
                    if (currentWeek.HasValue)
                    {
                        Console.WriteLine($"Current week runs: {GetRunsForWeek(currentWeek.Value)}/4 Runs");
                        Console.WriteLine($"Current week miles: {GetMilesForWeek(currentWeek.Value)}/{HalfMarathonService.HalfMarathonWeeklyTargetMiles[currentWeek.Value - 1]}");
                    }
                    Console.WriteLine($"\nOverall progress towards goal ({HalfMarathonService.GetCurrentTrainingWeek() / 16.0:P1}):");
                    Console.WriteLine($"Total Runs Completed: {halfMarathonRunsCompleted.CurrentProgress} / {halfMarathonRunsCompleted.TargetValue} ({ProgressMetric.CalculateProgress(halfMarathonRunsCompleted.CurrentProgress, halfMarathonRunsCompleted.TargetValue)}% Completed)");
                    Console.WriteLine($"Total Miles Completed: {halfMarathonMilesCompleted.CurrentProgress} / {halfMarathonMilesCompleted.TargetValue} ({ProgressMetric.CalculateProgress(halfMarathonMilesCompleted.CurrentProgress, halfMarathonMilesCompleted.TargetValue)}% Completed)");
                    if (halfMarathonMilesByWeek.Count > 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Miles by week:");
                        List<int> weeks = halfMarathonMilesByWeek.Keys.OrderBy(x => x).ToList();
                        for(int i = 0; i < weeks.Count; i++)
                        {
                            halfMarathonRunsByWeek.TryGetValue(weeks[i], out var runs);
                            halfMarathonMilesByWeek.TryGetValue(weeks[i], out var miles);
                         
                            Console.WriteLine($"Week {weeks[i]}: {miles}/{HalfMarathonService.HalfMarathonWeeklyTargetMiles[weeks[i] - 1]}, {runs}/4 Runs\n");
                        }
                    }
                    
                   
                    Console.WriteLine(new string('-', 60));
                    Console.WriteLine();
                    ConsolePause("Press any key to continue...");
                    break;
                case "5":
                    SetMarathonDate();
                    Console.WriteLine("You selected: Set Marathon Date");
                    break;
                case "6":
                    backToMain = true;
                    break;
                case "7":
                case "exit":
                    keepRunning = false;
                    backToMain = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid goal.");
                    ConsolePause("Press any key to continue...");
                    break;
            }
        }
    }

    private static void NovelCreationMenu()
    {
        var backToMain = false;

        while (!backToMain && keepRunning)
        {
            ShowHeader("        Novel Creation Menu", 40);
            WriteOptions(Menus.NovelCreationMenu);
            Console.WriteLine(new string('-', 40));
            Console.WriteLine();
            Console.Write("Please make a selection: ");

            switch (Console.ReadLine())
            {
                case "1":
                    ShowNovelCreationHomepage();
                    Console.WriteLine("You selected: Novel Creation Homepage");
                    ConsolePause("Press any key to continue...");
                    break;
                case "2":
                    ShowHeader("       Record Progress for Novel Creation ", 60);
                    Console.WriteLine("\nCurrent Words Written: " + novelWordCountCompleted.CurrentProgress + " / " + novelWordCountCompleted.TargetValue + " " + novelWordCountCompleted.Unit);
                    Console.WriteLine("\nCurrent Phases Completed: " + novelPhasesCompleted.CurrentProgress + " / " + novelPhasesCompleted.TargetValue);
                    Console.WriteLine(new string('-', 60)); 
                    RecordMetricProgress("Novel Word Count Completed");
                    RecordMetricProgress("Novel Phases Completed");
                    ConsolePause("Press any key to continue...");
                    break;
                case "3":
                    ShowHeader("     Novel Creation Progress Report", 60);
                    Console.WriteLine($"\nWords Written: {novelWordCountCompleted.CurrentProgress} / {novelWordCountCompleted.TargetValue} ({ProgressMetric.CalculateProgress(novelWordCountCompleted.CurrentProgress, novelWordCountCompleted.TargetValue)}% Completed)");
                    Console.WriteLine($"\nPhases Completed: {novelPhasesCompleted.CurrentProgress} / {novelPhasesCompleted.TargetValue} ({ProgressMetric.CalculateProgress(novelPhasesCompleted.CurrentProgress, novelPhasesCompleted.TargetValue)}% Completed)\n");
                    Console.WriteLine(new string('-', 60));
                    ConsolePause("Press any key to continue...");
                    Console.WriteLine("You selected: View Novel Creation Progress Report");
                    break;
                case "4":
                    backToMain = true;
                    break;
                case "5":
                case "exit":
                    keepRunning = false;
                    backToMain = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    ConsolePause("Press any key to continue...");
                    break;
            }
        }
    }

    private static void JournalMenu()
    {
        //var journalc = new Journal();
        var backToMain = false;

        while (!backToMain && keepRunning)
        {
            ShowHeader("         Journal", 30);
            WriteOptions(Menus.JournalMenu);
            Console.WriteLine(new string('-', 30));
            Console.Write("\nPlease make a selection: ");

            switch (Console.ReadLine())
            {
                case "1":
                    ShowHeader("                             Create Journal Entry", 80);
                    Journal.CreateJournalEntry();
                    break;
                case "2":
                    ShowHeader("                             View Journal Entries", 80);
                    Console.WriteLine();
                    if (string.IsNullOrWhiteSpace(Journal.MyJournal.Content))
                    {
                        Console.WriteLine("No journal entries found.");
                    }
                    else
                    {
                        Console.WriteLine(Journal.MyJournal.Content);
                    }
                    Console.WriteLine();
                    Console.WriteLine(new string('-', 80));
                    Console.WriteLine("You selected: View Journal Entries");
                    ConsolePause("Press any key to continue...");
                    break;
                case "3":
                    backToMain = true;
                    break;
                case "4":
                case "exit":
                    keepRunning = false;
                    backToMain = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    ConsolePause("Press any key to continue...");
                    break;
            }
        }
    }

    private static void SetAReminderMenu()
    {
        var backToMain = false;

        while (!backToMain && keepRunning)
        {
            ShowHeader("                Set A Reminder", 50);
            WriteOptions(Menus.SetAReminderMenu);
            Console.WriteLine(new string('-', 50));
            Console.Write("\nPlease make a selection: ");

            switch (Console.ReadLine())
            {
                case "1":
                    ShowHeader("          Language Learning Reminders", 50);
                    SetAReminder.ViewReminder("LanguageLearningReminders.txt");
                    Console.WriteLine();
                    Console.WriteLine(new string('-', 50));
                    Console.WriteLine("You selected: Set Reminder for Language Learning");
                    SetAReminder.SaveReminder("LanguageLearningReminders.txt");
                    break;
                case "2":
                    ShowHeader("        Half Marathon Training Reminders", 50);
                    SetAReminder.ViewReminder("HalfMarathonReminders.txt");
                    Console.WriteLine();
                    Console.WriteLine(new string('-', 50));
                    Console.WriteLine("You selected: Set Reminder for Half Marathon Training");
                    SetAReminder.SaveReminder("HalfMarathonReminders.txt");
                    break;
                case "3":
                    ShowHeader("          Novel Creation Reminders", 50);
                    SetAReminder.ViewReminder("NovelCreationReminders.txt");
                    Console.WriteLine();
                    Console.WriteLine(new string('-', 50));
                    Console.WriteLine("You selected: Set Reminder for Novel Creation");
                    SetAReminder.SaveReminder("NovelCreationReminders.txt");
                    break;
                case "4":
                    backToMain = true;
                    break;
                case "5":
                    keepRunning = false;
                    backToMain = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    ConsolePause("Press any key to continue...");
                    break;
            }
        }
    }


    public static void ShowLanguageLearningHomepage()
    {
        ShowHeader("              Welcome to the Language Learning Homepage!\n                       " +DateTime.Now.ToString("D"), 70);
        Console.WriteLine ();
        var overallProgress = SyncLanguageLearningGoalProgress();
        Console.WriteLine($"Vocabulary Words Learned:      {vocabularyWordsLearned.CurrentProgress} / {vocabularyWordsLearned.TargetValue} {vocabularyWordsLearned.Unit}");
        Console.WriteLine($"Reading Lessons Completed:     {readingLessonsCompleted.CurrentProgress} / {readingLessonsCompleted.TargetValue} {readingLessonsCompleted.Unit}");
        Console.WriteLine($"Verbal Exercises Completed:    {verbalExercisesCompleted.CurrentProgress} / {verbalExercisesCompleted.TargetValue} {verbalExercisesCompleted.Unit}");
        Console.WriteLine($"Listening Exercises Completed: {listeningExercisesCompleted.CurrentProgress} / {listeningExercisesCompleted.TargetValue} {listeningExercisesCompleted.Unit}");
        Console.WriteLine();
        Console.WriteLine(new string('-', 70));
        Console.WriteLine();
        Console.WriteLine(DailyTask.LanguageLearningDailyTask());
        Console.WriteLine();
        SetAReminder.ViewReminder("LanguageLearningReminders.txt");
        Console.WriteLine();
        Console.WriteLine("Dont forget to update your progress after completing your daily task!");

        Console.WriteLine(new string('-', 70));
    }

    public static void ShowHalfMarathonHomepage()
    {
        var currentWeek = HalfMarathonService.GetCurrentTrainingWeek();
        var weekLabel = currentWeek.HasValue ? currentWeek.Value.ToString() : "Race date not set";
        ShowHeader("                           Welcome to the Half Marathon Training Homepage!\n                                   " +DateTime.Now.ToString("D") + "\n                                      Current Week: " + weekLabel, 100);
       
        Console.WriteLine ();
        Console.WriteLine(MarathonDate.HasValue ? $"Race Date: {MarathonDate:yyyy-MM-dd}" : "You have not set a marathon race date yet.");
        Console.WriteLine();
        Console.WriteLine("Current Progress:");
        Console.WriteLine();
        var activeWeek = HalfMarathonService.GetCurrentTrainingWeek();
        if (activeWeek.HasValue)
        {   
            Console.WriteLine("Current week runs: " + GetRunsForWeek(activeWeek.Value) + "/4 Runs");
            Console.WriteLine("Current week miles: " + GetMilesForWeek(activeWeek.Value) + "/" + HalfMarathonService.HalfMarathonWeeklyTargetMiles[activeWeek.Value - 1]);
        }
        Console.WriteLine($"Total Runs Completed: {halfMarathonRunsCompleted.CurrentProgress}/{halfMarathonRunsCompleted.TargetValue} {halfMarathonRunsCompleted.Unit}");
        Console.WriteLine($"Total Miles Completed: {halfMarathonMilesCompleted.CurrentProgress}/{halfMarathonMilesCompleted.TargetValue} {halfMarathonMilesCompleted.Unit}");
        Console.WriteLine($"Overall progress towards goal: {HalfMarathonService.GetCurrentTrainingWeek() / 16.0:P1}");
        Console.WriteLine(new string('-', 100));    
         Console.WriteLine();
        Console.WriteLine(ScheduleTemplates.HalfMarathon16WeekTrainingSchedule[currentWeek.HasValue && currentWeek.Value >= 1 && currentWeek.Value <= 16 ? currentWeek.Value - 1 : 0]); 
        Console.WriteLine();
        Console.WriteLine($"Today's Daily Task:\n{DailyTask.HalfMarathonDailyTask()}");
        Console.WriteLine();
        SetAReminder.ViewReminder("HalfMarathonReminders.txt");
        Console.WriteLine();
        Console.WriteLine("Dont forget to update your progress after completing your daily task!");
        Console.WriteLine(new string('-', 100));
    }

    public static void ShowNovelCreationHomepage()
    {
        ShowHeader("              Welcome to the Novel Creation Homepage!\n                       " +DateTime.Now.ToString("D"), 70);
        
        Console.WriteLine ();
        for(int i = 0; i < novelPhasesCompleted.CurrentProgress; i++)
        {
            Console.WriteLine($"Completed {ScheduleTemplates.NovelCreationPhaseNames[i]}");
            foreach (var work in ScheduleTemplates.NovelCreationPhaseTasks[i])
            {
                Console.WriteLine(work);
            }
            Console.WriteLine();
        }   

        for(int i = novelPhasesCompleted.CurrentProgress; i < novelPhasesCompleted.TargetValue; i++)
        {
            Console.WriteLine($"Pending {ScheduleTemplates.NovelCreationPhaseNames[i]}");
            foreach (var work in ScheduleTemplates.NovelCreationPhaseTasks[i])
            {
                Console.WriteLine(work);
            }
            Console.WriteLine();
        }  
        Console.WriteLine(new string('-', 70)); 
        {
            Console.WriteLine("Current Progress: " + novelPhasesCompleted.CurrentProgress + " / " + novelPhasesCompleted.TargetValue + " phases completed.");
            Console.WriteLine("Current Word Count: " + novelWordCountCompleted.CurrentProgress + " / " + novelWordCountCompleted.TargetValue + " words written.");   
        }
        
        Console.WriteLine();
        Console.WriteLine(NovelCreationDailyTask());
        Console.WriteLine();
        SetAReminder.ViewReminder("NovelCreationReminders.txt");
        Console.WriteLine();
        Console.WriteLine("Dont forget to update your progress after completing your daily task!");
        Console.WriteLine(new string('-', 70));
    }

    private static int GetMilesForWeek(int week)
    {
        if (halfMarathonMilesByWeek.TryGetValue(week, out var miles))
        {
            return miles;
        }

        return 0;
    }

    private static void RecordHalfMarathonMilesByWeek()
    {
        Console.Write("Enter week number (1-16): ");
        var weekInput = Console.ReadLine();
        if (!int.TryParse(weekInput, out var week) || week < 1 || week > 16)
        {
            Console.WriteLine("Invalid week. Please enter a value from 1 to 16.");
            return;
        }

        Console.Write("Enter total miles for that week: ");
        var milesInput = Console.ReadLine();
        if (!int.TryParse(milesInput, out var miles) || miles < 0)
        {
            Console.WriteLine("Invalid miles. Please enter a non-negative whole number.");
            return;
        }

        halfMarathonMilesByWeek[week] = miles;
        halfMarathonMilesCompleted.SetProgress(halfMarathonMilesByWeek.Values.Sum());
        SaveMetricProgress();
        Console.WriteLine($"You saved {miles} miles for Week {week}");
        Console.WriteLine();
    }
     private static int GetRunsForWeek(int week)
    {
        if (halfMarathonRunsByWeek.TryGetValue(week, out var runs))
        {
            return runs;
        }

        return 0;
    }

    private static void RecordHalfMarathonRunsByWeek()
    {
        Console.Write("Enter week number (1-16): ");
        var weekInput = Console.ReadLine();
        if (!int.TryParse(weekInput, out var week) || week < 1 || week > 16)
        {
            Console.WriteLine("Invalid week. Please enter a value from 1 to 16.");
            return;
        }

        Console.Write("Enter total runs for that week: ");
        var runsInput = Console.ReadLine();
        if (!int.TryParse(runsInput, out var runs) || runs < 0)
        {
            Console.WriteLine("Invalid miles. Please enter a non-negative whole number.");
            return;
        }

        halfMarathonRunsByWeek[week] = runs;
        halfMarathonRunsCompleted.SetProgress(halfMarathonRunsByWeek.Values.Sum());
        SaveMetricProgress();
        Console.WriteLine($"You saved: {runs} Runs for Week {week}");
        Console.WriteLine();
    }   

     public static void RecordMetricProgress(string metricName)          
    {
        Console.Write($"Enter numerical progress amount for {metricName}: ");
        var input = Console.ReadLine();
        if (int.TryParse(input, out int progress))
        {
            // Set the corresponding metric's absolute current progress.
            switch (metricName)
            {
                case "Vocabulary Words Learned":
                    vocabularyWordsLearned.SetProgress(progress);
                    break;
                case "Reading Lessons Completed":
                    readingLessonsCompleted.SetProgress(progress);
                    break;
                case "Verbal Exercises Completed":
                    verbalExercisesCompleted.SetProgress(progress);
                    break;
                case "Listening Exercises Completed":
                    listeningExercisesCompleted.SetProgress(progress);
                    break;
                case "Novel Phases Completed":
                    novelPhasesCompleted.SetProgress(progress);
                    break;
                case "Novel Word Count Completed":
                    novelWordCountCompleted.SetProgress(progress);
                    break;
                case "Half Marathon Runs Completed":
                    halfMarathonRunsCompleted.SetProgress(progress);
                    break;
                case "Half Marathon Miles Completed":
                    halfMarathonMilesCompleted.SetProgress(progress);
                    break;
                default:
                    Console.WriteLine("Invalid Metric type.");
                    break;
            }
            Console.WriteLine("Progress set successfully.");
            SyncLanguageLearningGoalProgress();
            SaveMetricProgress();
            
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a numeric value.");
        
        }
    }

    private static void SaveMetricProgress()
    {
        var metricMap = new Dictionary<string, string>
        {
            { "Vocabulary Words Learned", vocabularyWordsLearned.CurrentProgress.ToString() },
            { "Reading Lessons Completed", readingLessonsCompleted.CurrentProgress.ToString() },
            { "Verbal Exercises Completed", verbalExercisesCompleted.CurrentProgress.ToString() },
            { "Listening Exercises Completed", listeningExercisesCompleted.CurrentProgress.ToString() },
            { "Novel Phases Completed", novelPhasesCompleted.CurrentProgress.ToString() },
            { "Novel Word Count Completed", novelWordCountCompleted.CurrentProgress.ToString() },
            { "Half Marathon Runs Completed", halfMarathonRunsCompleted.CurrentProgress.ToString() },
            { "Half Marathon Miles Completed", halfMarathonMilesCompleted.CurrentProgress.ToString() },
            { "Half Marathon Weekly Miles", JsonSerializer.Serialize(halfMarathonMilesByWeek) },
            { "Half Marathon Weekly Runs", JsonSerializer.Serialize(halfMarathonRunsByWeek) },
            { "Marathon Race Date", MarathonDate.HasValue ? MarathonDate.Value.ToString("yyyy-MM-dd") : string.Empty }
        };

        var json = JsonSerializer.Serialize(metricMap, new JsonSerializerOptions { WriteIndented = true });
        DataManager.SaveData(metricsDataPath, json);
    }

    private static void LoadMetricProgress()
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
                vocabularyWordsLearned.SetProgress(vocabularyProgress);
            }

            if (metricMap.TryGetValue("Reading Lessons Completed", out var readingValue)
                && int.TryParse(readingValue, out var readingProgress))
            {
                readingLessonsCompleted.SetProgress(readingProgress);
            }

            if (metricMap.TryGetValue("Verbal Exercises Completed", out var verbalValue)
                && int.TryParse(verbalValue, out var verbalProgress))
            {
                verbalExercisesCompleted.SetProgress(verbalProgress);
            }

            if (metricMap.TryGetValue("Listening Exercises Completed", out var listeningValue)
                && int.TryParse(listeningValue, out var listeningProgress))
            {
                listeningExercisesCompleted.SetProgress(listeningProgress);
            }

            if (metricMap.TryGetValue("Novel Phases Completed", out var phasesValue)
                && int.TryParse(phasesValue, out var phasesProgress))
            {
                novelPhasesCompleted.SetProgress(phasesProgress);
            }

            if (metricMap.TryGetValue("Novel Word Count Completed", out var wordCountValue)
                && int.TryParse(wordCountValue, out var wordCountProgress))
            {
                novelWordCountCompleted.SetProgress(wordCountProgress);
            }

            if (metricMap.TryGetValue("Half Marathon Runs Completed", out var runsValue)
                && int.TryParse(runsValue, out var runsProgress))
            {
                halfMarathonRunsCompleted.SetProgress(runsProgress);
            }

            if (metricMap.TryGetValue("Half Marathon Miles Completed", out var milesValue)
                && int.TryParse(milesValue, out var milesProgress))
            {
                halfMarathonMilesCompleted.SetProgress(milesProgress);
            }

            if (metricMap.TryGetValue("Half Marathon Weekly Miles", out var weeklyMilesJson)
                && !string.IsNullOrWhiteSpace(weeklyMilesJson))
            {
                var parsedWeeklyMiles = JsonSerializer.Deserialize<Dictionary<int, int>>(weeklyMilesJson);
                if (parsedWeeklyMiles is not null)
                {
                    halfMarathonMilesByWeek = parsedWeeklyMiles;
                    halfMarathonMilesCompleted.SetProgress(halfMarathonMilesByWeek.Values.Sum());
                }
            }
                if (metricMap.TryGetValue("Half Marathon Weekly Runs", out var weeklyRunsJson)
                    && !string.IsNullOrWhiteSpace(weeklyRunsJson))
                {
                    var parsedWeeklyRuns = JsonSerializer.Deserialize<Dictionary<int, int>>(weeklyRunsJson);
                    if (parsedWeeklyRuns is not null)
                    {
                        halfMarathonRunsByWeek = parsedWeeklyRuns;
                        halfMarathonRunsCompleted.SetProgress(halfMarathonRunsByWeek.Values.Sum());
                    }
                }
            if (metricMap.TryGetValue("Marathon Race Date", out var marathonDateValue)
                && !string.IsNullOrWhiteSpace(marathonDateValue))
            {
                if (DateTime.TryParseExact(marathonDateValue, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedDate)
                    || DateTime.TryParse(marathonDateValue, out parsedDate))
                {
                    MarathonDate = parsedDate;
                }
            }
                
        }
        catch
        {
            // Ignore malformed data and continue with default values.
        }
    }

    private static void SetMarathonDate()
    {
        ShowHeader("        Set Your Marathon Race Date", 50);
        
        // Show current date if one is set, otherwise say "No date set yet"
        if (MarathonDate.HasValue)
        {
            Console.WriteLine($"Current race date: {MarathonDate:yyyy-MM-dd}");
        }
        else
        {
            Console.WriteLine("No race date set yet.");
        }
        
        Console.WriteLine();
        Console.Write("Enter race date (YYYY-MM-DD) or press Enter to cancel: ");
        var input = Console.ReadLine()?.Trim();
        
        // If user pressed Enter with no text, go back
        if (string.IsNullOrWhiteSpace(input))
        {
            ConsolePause("Cancelled. Press any key to continue...");
            return;
        }
        
        // Try to parse the input as a date
        if (!DateTime.TryParseExact(input, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedDate))
        {
            ConsolePause("Invalid date format. Please use YYYY-MM-DD.");
            return;
        }

        MarathonDate = parsedDate;
        SaveMetricProgress();
        
        ConsolePause($"Race date saved: {MarathonDate:yyyy-MM-dd}. Press any key to continue...");
    }

    
    public static void HalfMarathon16WeekSchedule() 
    {
            var currentWeek = HalfMarathonService.GetCurrentTrainingWeek();
            var weekLabel = currentWeek.HasValue ? currentWeek.Value.ToString() : "Race date not set";
            ConsoleUI.ShowHeader("                          Half Marathon 16 WeekTraining Schedule\n                              Date: " + DateTime.Now.ToString("D") + "\n                                    Current Week: " + weekLabel, 100);
            if (!currentWeek.HasValue)
            {
                Console.WriteLine("Tip: Set your marathon race date to calculate the current training week.");
                Console.WriteLine();
            }
            foreach (var option in ScheduleTemplates.HalfMarathon16WeekTrainingSchedule)
            {
                Console.WriteLine(option);
            }
            Console.WriteLine(new string('-', 100));
            Console.WriteLine();
    }
    
    public static void ShowLanguageLearningProgressReport()
    {
        ShowHeader("         Language Learning Progress Report", 60);
        var overallProgress = SyncLanguageLearningGoalProgress();

        Console.WriteLine($"\nVocabulary Words Learned: {vocabularyWordsLearned.CurrentProgress} / {vocabularyWordsLearned.TargetValue} ({ProgressMetric.CalculateProgress(vocabularyWordsLearned.CurrentProgress, vocabularyWordsLearned.TargetValue)}% Completed)");
        Console.WriteLine($"Reading Lessons Completed: {readingLessonsCompleted.CurrentProgress} / {readingLessonsCompleted.TargetValue} ({ProgressMetric.CalculateProgress(readingLessonsCompleted.CurrentProgress, readingLessonsCompleted.TargetValue)}% Completed)");  
        Console.WriteLine($"Verbal Exercises Completed: {verbalExercisesCompleted.CurrentProgress} / {verbalExercisesCompleted.TargetValue} ({ProgressMetric.CalculateProgress(verbalExercisesCompleted.CurrentProgress, verbalExercisesCompleted.TargetValue)}% Completed)");
        Console.WriteLine($"Listening Exercises Completed: {listeningExercisesCompleted.CurrentProgress} / {listeningExercisesCompleted.TargetValue} ({ProgressMetric.CalculateProgress(listeningExercisesCompleted.CurrentProgress, listeningExercisesCompleted.TargetValue)}% Completed)");
        Console.WriteLine($"Language Learning Goal Progress: {LanguageLearningService.LanguageLearningGoal.CurrentProgress} / {LanguageLearningService.LanguageLearningGoal.TargetValue}%\n");
        Console.WriteLine(new string('-', 60));
        Console.WriteLine();
        LanguageLearningService.PrintLanguageLearningMilestones();
        Console.WriteLine();
        Console.WriteLine(new string('-', 60));
    }

    private static double SyncLanguageLearningGoalProgress()
    {
        LanguageLearningService.UpdateLanguageLearningMilestones(
            vocabularyWordsLearned,
            readingLessonsCompleted,
            verbalExercisesCompleted,
            listeningExercisesCompleted);

        return LanguageLearningService.LanguageLearningGoal.CurrentProgress;
    }
     public static void LanguageLearningWeeklySchedule() 
    {
            ConsoleUI.ShowHeader("            Language Learning Schedule\n            " + DateTime.Now.ToString("D"), 60);
            foreach (var option in ScheduleTemplates.LanguageLearningSchedule)
            {
                Console.WriteLine(option);
            }
            Console.WriteLine(new string('-', 60));
            Console.WriteLine();
    }
    
    public static string NovelCreationDailyTask()
    {
        return novelPhasesCompleted.CurrentProgress switch
        {
            0 => "Daily task: Phase 1: Prewriting ",
            1 => "Daily task: Phase 2: 1st Draft ",
            2 => "Daily task: Phase 3: Revision / Structural Editing ",
            3 => "Daily task: Phase 4: Editing / Polishing",
            4 => "Daily task: Phase 5: Final Submission / Proofreading",
            5 => "Congratulations! You've completed all phases of your novel creation.",
            _ => "Unknown phase."
        };
    }


    public static string WrapText(string text, int width)
{
    var formattedText = new System.Text.StringBuilder();
    string[] words = text.Split(' ');
    string currentLine = "";

    foreach (var word in words)
    {
        if ((currentLine + word).Length > width)
        {
            formattedText.AppendLine(currentLine.TrimEnd());
            currentLine = "";
        }
        currentLine += word + " ";
    }
    
    formattedText.Append(currentLine.TrimEnd());
    return formattedText.ToString();
}


    public static void ShowHeader(string title,int width)
    {
        Console.Clear();
        Console.WriteLine(new string('-', width));
        Console.WriteLine(title);
        Console.WriteLine(new string('-', width));
    }
    public static void ConsolePause(string title)
    {
        Console.WriteLine(title);
        Console.ReadKey();
        Console.Clear();
    }
     public static void WriteOptions(IEnumerable<string> options)
    {
        foreach (var option in options)
        {
            Console.WriteLine(option);
        }
    }

    public static void WriteSuccess(string message)
    {
        Console.WriteLine(message);
    }
}
    
