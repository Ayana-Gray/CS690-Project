namespace GoalProgressTracker;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

public class ConsoleUI
{
    internal static bool keepRunning = true;

    public static void MainMenu()
    {
            ShowHeader("            Main Menu", 40);
            WriteOptions(Menus.MainMenu);
            ShowFooter(40);
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
            ShowFooter(40);
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
            ShowHeader(" Record Language Learning Progress Menu", 45);
            WriteOptions(Menus.LanguageLearningProgressMenu);
            ShowFooter(45);
            Console.Write("Please make a selection: ");

            switch (Console.ReadLine())
            {
                case "1":
                    ShowHeader("       Record Progress for Vocabulary Words Learned", 60);
                    Console.WriteLine();
                    Console.WriteLine($"Current Vocabulary Words Learned: {ProgressState.vocabularyWordsLearned.CurrentProgress}  / {ProgressState.vocabularyWordsLearned.TargetValue}  {ProgressState.vocabularyWordsLearned.Unit}");
                    ShowMenuFooter(60);
                    RecordMetricProgress("Vocabulary Words Learned");
                    Console.WriteLine();    
                    break;
                case "2":
                    ShowHeader("      Record Progress for Reading Lessons Completed", 60);
                    Console.WriteLine();
                    Console.WriteLine($"Current Reading Lessons Completed: {ProgressState.readingLessonsCompleted.CurrentProgress} / {ProgressState.readingLessonsCompleted.TargetValue} {ProgressState.readingLessonsCompleted.Unit}");
                    Console.WriteLine();    
                    Console.WriteLine(new string('-', 60));
                    RecordMetricProgress("Reading Lessons Completed");
                   
                    break;
                case "3":
                    ShowHeader("    Record Progress for Verbal Exercises Completed", 60);
                    Console.WriteLine("Current Verbal Exercises Completed: " + ProgressState.verbalExercisesCompleted.CurrentProgress + " / " + ProgressState.verbalExercisesCompleted.TargetValue + " " + ProgressState.verbalExercisesCompleted.Unit);
                    Console.WriteLine();
                    Console.WriteLine(new string('-', 60));
                    RecordMetricProgress("Verbal Exercises Completed");
                    break;
                case "4":
                    ShowHeader("    Record Progress for Listening Exercises Completed", 60);
                    Console.WriteLine("\nCurrent Listening Exercises Completed: " + ProgressState.listeningExercisesCompleted.CurrentProgress + " / " + ProgressState.listeningExercisesCompleted.TargetValue + " " + ProgressState.listeningExercisesCompleted.Unit);
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

                    int? currentWeek = HalfMarathonService.GetCurrentTrainingWeek();

                    if (currentWeek.HasValue && currentWeek.Value > 0)
                    {
                        int week = currentWeek.Value; // 1-16
                        int WeekIndexed = week - 1;      // 0-15
    
                        Console.WriteLine($"\nThis Current Week: Week {week}");
                        Console.WriteLine($"Current week runs: {DataManager.GetRunsForWeek(week)}/4 {ProgressState.halfMarathonRunsCompleted.Unit}");
    
                        
                        string target = HalfMarathonService.HalfMarathonWeeklyTargetMiles[WeekIndexed];
                        Console.WriteLine($"Current week miles: {DataManager.GetMilesForWeek(week)}/{target} {ProgressState.halfMarathonMilesCompleted.Unit}");
                    }
                    PrintRunsAndMilesPerWeek();
                    ShowFooter(60);
                    Console.WriteLine("Avoid confusion, enter one run and its associated miles");
                    Console.WriteLine();
                    RecordHalfMarathonRunsAndMilesByWeek();
                    ConsolePause("Press any key to continue...");
                    break;


                case "4":

                    ShowHeader("     Half Marathon Training Progress Report", 55);
                    
                    int? CurrentWeek = HalfMarathonService.GetCurrentTrainingWeek();

                    if (CurrentWeek.HasValue && CurrentWeek.Value > 0)
                    {
                        int week = CurrentWeek.Value; // 1-16
                        int WeekIndexed = week - 1;      // 0-15
    
                        Console.WriteLine($"\nThis Current Week: Week {week}");
                        Console.WriteLine($"Current week runs: {DataManager.GetRunsForWeek(week)}/4 {ProgressState.halfMarathonRunsCompleted.Unit}");
    
                        
                        string target = HalfMarathonService.HalfMarathonWeeklyTargetMiles[WeekIndexed];
                        Console.WriteLine($"Current week miles: {DataManager.GetMilesForWeek(week)}/{target} {ProgressState.halfMarathonMilesCompleted.Unit}");
                    }

                    Console.WriteLine();
                    Console.WriteLine($"Overall progress towards goal: ({HalfMarathonService.GetCurrentTrainingWeek() / 16.0 * 100}%)");
                    Console.WriteLine($"Total runs completed: {ProgressState.halfMarathonRunsCompleted.CurrentProgress} / {ProgressState.halfMarathonRunsCompleted.TargetValue} {ProgressState.halfMarathonRunsCompleted.Unit}");
                    Console.WriteLine($"Total miles completed: {ProgressState.halfMarathonMilesCompleted.CurrentProgress}/{ProgressState.halfMarathonMilesCompleted.TargetValue} {ProgressState.halfMarathonMilesCompleted.Unit}");
                    PrintRunsAndMilesPerWeek();
                    ShowFooter(55);
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
            ShowFooter(40);
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
                    Console.WriteLine("\nCurrent Words Written: " + ProgressState.novelWordCountCompleted.CurrentProgress + " / " + ProgressState.novelWordCountCompleted.TargetValue + " " + ProgressState.novelWordCountCompleted.Unit);
                    Console.WriteLine("\nCurrent Phases Completed: " + ProgressState.novelPhasesCompleted.CurrentProgress + " / " + ProgressState.novelPhasesCompleted.TargetValue);
                    ShowMenuFooter(60);
                    RecordMetricProgress("Novel Word Count Completed");
                    RecordMetricProgress("Novel Phases Completed");
                    ConsolePause("Press any key to continue...");
                    break;
                case "3":
                    ShowHeader("     Novel Creation Progress Report", 60);
                    Console.WriteLine($"\nWords Written: {ProgressState.novelWordCountCompleted.CurrentProgress} / {ProgressState.novelWordCountCompleted.TargetValue} ({ProgressMetric.CalculateProgress(ProgressState.novelWordCountCompleted.CurrentProgress, ProgressState.novelWordCountCompleted.TargetValue)}% Completed)");
                    Console.WriteLine($"\nPhases Completed: {ProgressState.novelPhasesCompleted.CurrentProgress} / {ProgressState.novelPhasesCompleted.TargetValue} ({ProgressMetric.CalculateProgress(ProgressState.novelPhasesCompleted.CurrentProgress, ProgressState.novelPhasesCompleted.TargetValue)}% Completed)");
                    ShowMenuFooter(60);
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
                    ShowMenuFooter(80);
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
            ShowMenuFooter(50);
            Console.Write("\nPlease make a selection: ");

            switch (Console.ReadLine())
            {
                case "1":
                    ShowHeader("          Language Learning Reminders", 50);
                    Console.WriteLine("Current Reminder(s):");
                    Console.WriteLine(SetAReminder.LanguageLearning.Content);
                    ShowMenuFooter(50);
                    Console.WriteLine("You selected: Set Reminder for Language Learning");
                    SetAReminder.LanguageLearning.SaveAReminder();
                    break;
                case "2":
                    ShowHeader("        Half Marathon Training Reminders", 50);
                    Console.WriteLine("Current Reminder(s):");
                    Console.WriteLine(SetAReminder.HalfMarathon.Content);
                    ShowMenuFooter(50);
                    Console.WriteLine("You selected: Set Reminder for Half Marathon Training");
                    SetAReminder.HalfMarathon.SaveAReminder();
                    break;
                case "3":
                    ShowHeader("          Novel Creation Reminders", 50);
                    Console.WriteLine("Current Reminder(s):");
                    Console.WriteLine(SetAReminder.NovelCreation.Content);
                    ShowMenuFooter(50);
                    Console.WriteLine("You selected: Set Reminder for Novel Creation");
                    SetAReminder.NovelCreation.SaveAReminder();
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
        var overallProgress = DataManager.SyncLanguageLearningGoalProgress();
        Console.WriteLine($"Vocabulary Words Learned:      {ProgressState.vocabularyWordsLearned.CurrentProgress} / {ProgressState.vocabularyWordsLearned.TargetValue} {ProgressState.vocabularyWordsLearned.Unit}");
        Console.WriteLine($"Reading Lessons Completed:     {ProgressState.readingLessonsCompleted.CurrentProgress} / {ProgressState.readingLessonsCompleted.TargetValue} {ProgressState.readingLessonsCompleted.Unit}");
        Console.WriteLine($"Verbal Exercises Completed:    {ProgressState.verbalExercisesCompleted.CurrentProgress} / {ProgressState.verbalExercisesCompleted.TargetValue} {ProgressState.verbalExercisesCompleted.Unit}");
        Console.WriteLine($"Listening Exercises Completed: {ProgressState.listeningExercisesCompleted.CurrentProgress} / {ProgressState.listeningExercisesCompleted.TargetValue} {ProgressState.listeningExercisesCompleted.Unit}");
        Console.WriteLine();
        ShowFooter(70);
        Console.WriteLine(DailyTask.LanguageLearningDailyTask());
        Console.WriteLine();
        Console.WriteLine("Current Reminder(s):");
        Console.WriteLine(SetAReminder.LanguageLearning.Content);
        Console.WriteLine("Dont forget to update your progress after completing your daily task!");
        ShowMenuFooter(70);
    }

    public static void ShowHalfMarathonHomepage()
    {
        var currentWeek = HalfMarathonService.GetCurrentTrainingWeek();
        var weekLabel = currentWeek.HasValue ? currentWeek.Value.ToString() : "Race date not set";
        ShowHeader("                           Welcome to the Half Marathon Training Homepage!\n                                   " +DateTime.Now.ToString("D") + "\n                                      Current Week: " + weekLabel, 100);
       
        Console.WriteLine ();
        Console.WriteLine(HalfMarathonService.HalfMarathonGoal.TargetDate.HasValue ? $"Race Date: {HalfMarathonService.HalfMarathonGoal.TargetDate:yyyy-MM-dd}" : "You have not set a marathon race date yet.");
        Console.WriteLine();
        Console.WriteLine("Current Progress:");
        Console.WriteLine();
        var activeWeek = HalfMarathonService.GetCurrentTrainingWeek();
        if (activeWeek.HasValue)
        {   
            Console.WriteLine("Current week runs: " + DataManager.GetRunsForWeek(activeWeek.Value) + "/4 Runs");
            Console.WriteLine("Current week miles: " + DataManager.GetMilesForWeek(activeWeek.Value) + "/" + HalfMarathonService.HalfMarathonWeeklyTargetMiles[activeWeek.Value - 1]+ " Miles");
        }
        Console.WriteLine($"Total Runs Completed: {ProgressState.halfMarathonRunsCompleted.CurrentProgress}/{ProgressState.halfMarathonRunsCompleted.TargetValue} {ProgressState.halfMarathonRunsCompleted.Unit}");
        Console.WriteLine($"Total Miles Completed: {ProgressState.halfMarathonMilesCompleted.CurrentProgress}/{ProgressState.halfMarathonMilesCompleted.TargetValue} {ProgressState.halfMarathonMilesCompleted.Unit}");
        Console.WriteLine($"Overall progress towards goal: {HalfMarathonService.GetCurrentTrainingWeek() / 16.0:P1}");
        ShowFooter(100);
        Console.WriteLine(ScheduleTemplates.HalfMarathon16WeekTrainingSchedule[currentWeek.HasValue && currentWeek.Value >= 1 && currentWeek.Value <= 16 ? currentWeek.Value - 1 : 0]); 
        Console.WriteLine();
        Console.WriteLine($"Today's Daily Task:\n{DailyTask.HalfMarathonDailyTask()}");
        Console.WriteLine();
        Console.WriteLine("Current Reminder(s):");
        Console.WriteLine(SetAReminder.HalfMarathon.Content);
        Console.WriteLine();
        Console.WriteLine("Dont forget to update your progress after completing your daily task!");
        ShowFooter(100);
    }

    public static void ShowNovelCreationHomepage()
    {
        ShowHeader("              Welcome to the Novel Creation Homepage!\n                       " +DateTime.Now.ToString("D"), 70);
        
        Console.WriteLine ();
        NovelCreationPhaseStatus();
        ShowFooter(70);
        {
            Console.WriteLine("Current Progress: " + ProgressState.novelPhasesCompleted.CurrentProgress + " / " + ProgressState.novelPhasesCompleted.TargetValue + " phases completed.");
            Console.WriteLine("Current Word Count: " + ProgressState.novelWordCountCompleted.CurrentProgress + " / " + ProgressState.novelWordCountCompleted.TargetValue + " words written.");   
        }
        
        Console.WriteLine();
        Console.WriteLine(DailyTask.NovelCreationDailyTask(ProgressState.novelPhasesCompleted.CurrentProgress));
        Console.WriteLine();
        Console.WriteLine("Current Reminder(s):");
        Console.WriteLine(SetAReminder.NovelCreation.Content);
        Console.WriteLine("Dont forget to update your progress after completing your daily task!");
        ShowFooter(70);
    }
    public static void NovelCreationPhaseStatus()
    {   
        for(int i = 0; i < ProgressState.novelPhasesCompleted.CurrentProgress; i++)
        {   
            Console.WriteLine($"Completed {NovelCreationService.NovelCreationGoal.Milestones[i]}");
            // Loop through the GoalTasks within that specific milestone
            foreach (var task in NovelCreationService.NovelCreationGoal.Milestones[i].GoalTasks)
            {
                Console.WriteLine($"{task.Name}");
            }
            Console.WriteLine();
        }
        for(int i = ProgressState.novelPhasesCompleted.CurrentProgress; i < ProgressState.novelPhasesCompleted.TargetValue; i++)
        {
            Console.WriteLine($"Pending {NovelCreationService.NovelCreationGoal.Milestones[i]}");
            foreach (var task in NovelCreationService.NovelCreationGoal.Milestones[i].GoalTasks)
            {
                Console.WriteLine($"{task.Name}");
            }
            int PhaseProgress = ProgressState.novelPhasesCompleted.CurrentProgress;

            Console.WriteLine();
        }
    }
        private static void RecordHalfMarathonRunsAndMilesByWeek()
    {
        Console.Write("Enter week number (1-16): ");
        var weekInput = Console.ReadLine();
        if (!int.TryParse(weekInput, out var week) || week < 1 || week > 16 || week > HalfMarathonService.GetCurrentTrainingWeek() )
        {
            Console.WriteLine("Invalid entry. Please enter a value that is that is\nless than or equal to this current week.");
            Console.WriteLine();
            return;
        }
    
        Console.WriteLine($"You currently have {DataManager.GetRunsForWeek(week)}/4 runs recorded for Week {week}");
        Console.Write($"How many runs do you want to record for Week {week}? ");
        var runsInput = Console.ReadLine();
        if (!int.TryParse(runsInput, out var runs) || runs < 0 ||(DataManager.GetRunsForWeek(week) + runs) > 4)
        {
            Console.WriteLine("Invalid Entry. Enter a non-negative whole number\nDon't exceed 4 runs for the week\n");
            return;
        }

        ProgressState.halfMarathonRunsByWeek[week] = DataManager.GetRunsForWeek(week) + runs;
        int newRunTotal = ProgressState.halfMarathonRunsByWeek.Values.Sum();
        ProgressState.halfMarathonRunsCompleted.SetProgress(newRunTotal);
        DataManager.SaveMetricProgress();
        Console.WriteLine($"Saved! You now have {DataManager.GetRunsForWeek(week)}/4 runs recorded for Week {week}");
        Console.WriteLine();

        var currentWeek = HalfMarathonService.GetCurrentTrainingWeek();
        Console.WriteLine(ScheduleTemplates.HalfMarathon16WeekTrainingSchedule[week - 1]); 
        Console.WriteLine();
        Console.WriteLine($"You currently have {DataManager.GetMilesForWeek(week)}/{HalfMarathonService.HalfMarathonGoal.Milestones[week - 1].TargetValue} miles recorded for Week {week}");
        Console.Write($"How many miles do you want to record for week {week}? ");
        var milesInput = Console.ReadLine();
        if (!int.TryParse(milesInput, out var miles) || miles < 0 ||  (DataManager.GetMilesForWeek(week) + miles) > HalfMarathonService.HalfMarathonGoal.Milestones[week - 1].TargetValue)
        {
            Console.WriteLine("Invalid entry Enter a non-negative whole number\nDont exceed mile target value for the week");
            return;
        }
        
        ProgressState.halfMarathonMilesByWeek[week] = DataManager.GetMilesForWeek(week) + miles;
        int newMileTotal = ProgressState.halfMarathonMilesByWeek.Values.Sum();
        ProgressState.halfMarathonMilesCompleted.SetProgress(newMileTotal);
        
        DataManager.SaveMetricProgress(); 
        Console.WriteLine($"Saved! You now have {ProgressState.halfMarathonMilesByWeek[week]}/{HalfMarathonService.HalfMarathonGoal.Milestones[week - 1].TargetValue} miles recorded for Week {week}");
        Console.WriteLine();
    }   


    public static void RecordMetricProgress(string metricName) 
    { 
        Console.Write($"Enter a numerical amount for {metricName}: "); 
        var input = Console.ReadLine(); 

        if (int.TryParse(input, out int progress)) 
        { 
        
            switch (metricName) 
            { 
                case "Vocabulary Words Learned": 
                    ProgressState.vocabularyWordsLearned.UpdateProgress(progress); break; 
                case "Reading Lessons Completed": 
                    ProgressState.readingLessonsCompleted.UpdateProgress(progress); break; 
                case "Verbal Exercises Completed": 
                    ProgressState.verbalExercisesCompleted.UpdateProgress(progress); break; 
                case "Listening Exercises Completed": 
                    ProgressState.listeningExercisesCompleted.UpdateProgress(progress); break; 
                case "Novel Phases Completed":
                    if (0 < ProgressState.novelPhasesCompleted.CurrentProgress && ProgressState.novelWordCountCompleted.CurrentProgress < 80000)
                    {
                        Console.WriteLine("Cannot record Phase: Novel Word Count must be at least 80,000.");break;
                    }
                    ProgressState.novelPhasesCompleted.UpdateProgress(progress);break; 
                case "Novel Word Count Completed": 
                    ProgressState.novelWordCountCompleted.UpdateProgress(progress); break; 
                case "Half Marathon Runs Completed": 
                    ProgressState.halfMarathonRunsCompleted.UpdateProgress(progress); break; 
                case "Half Marathon Miles Completed": 
                    ProgressState.halfMarathonMilesCompleted.UpdateProgress(progress); break; 
                default: 
                    Console.WriteLine("Invalid Metric type."); return; 
            } 

            Console.WriteLine("Progress saved successfully."); 

        
            DataManager.SyncLanguageLearningGoalProgress(); 
            DataManager.SaveMetricProgress(); 
            Console.WriteLine();
        } 
        else 
        { 
        Console.WriteLine("Invalid input. Please enter a numeric value."); 
        } 
    }

    public static void PrintRunsAndMilesPerWeek()
    {
        if (ProgressState.halfMarathonMilesByWeek.Count > 0)
        {
            Console.WriteLine();
            Console.WriteLine("Miles And Runs Per Week:");
            List<int> weeks = ProgressState.halfMarathonMilesByWeek.Keys.OrderBy(x => x).ToList();
            for(int i = 0; i < weeks.Count; i++)
            {
                ProgressState.halfMarathonRunsByWeek.TryGetValue(weeks[i], out var runs);
                ProgressState.halfMarathonMilesByWeek.TryGetValue(weeks[i], out var miles);
            
                Console.WriteLine($"Week {weeks[i]}: {miles}/{HalfMarathonService.HalfMarathonWeeklyTargetMiles[weeks[i] - 1]} Miles, {runs}/4 Runs\n");
            }
        }
    }
    private static void SetMarathonDate()
    {
        ShowHeader("        Set Your Marathon Race Date", 50);
        
        if (HalfMarathonService.HalfMarathonGoal.TargetDate.HasValue)
        {
            Console.WriteLine($"Current race date: {HalfMarathonService.HalfMarathonGoal.TargetDate:yyyy-MM-dd}");
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
        
        if (!DateTime.TryParseExact(input, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedDate))
        {
            ConsolePause("Invalid date format. Please use YYYY-MM-DD.");
            return;
        }

        HalfMarathonService.HalfMarathonGoal.TargetDate = parsedDate;
        DataManager.SaveMetricProgress();
        
        ConsolePause($"Race date saved: {HalfMarathonService.HalfMarathonGoal.TargetDate:yyyy-MM-dd}. Press any key to continue...");
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
            ShowFooter(100);
    }
    
    public static void ShowLanguageLearningProgressReport()
    {
        ShowHeader("         Language Learning Progress Report", 60);
        var overallProgress = DataManager.SyncLanguageLearningGoalProgress();

        Console.WriteLine($"\nVocabulary Words Learned: {ProgressState.vocabularyWordsLearned.CurrentProgress} / {ProgressState.vocabularyWordsLearned.TargetValue} ({ProgressMetric.CalculateProgress(ProgressState.vocabularyWordsLearned.CurrentProgress, ProgressState.vocabularyWordsLearned.TargetValue)}% Completed)");
        Console.WriteLine($"Reading Lessons Completed: {ProgressState.readingLessonsCompleted.CurrentProgress} / {ProgressState.readingLessonsCompleted.TargetValue} ({ProgressMetric.CalculateProgress(ProgressState.readingLessonsCompleted.CurrentProgress, ProgressState.readingLessonsCompleted.TargetValue)}% Completed)");  
        Console.WriteLine($"Verbal Exercises Completed: {ProgressState.verbalExercisesCompleted.CurrentProgress} / {ProgressState.verbalExercisesCompleted.TargetValue} ({ProgressMetric.CalculateProgress(ProgressState.verbalExercisesCompleted.CurrentProgress, ProgressState.verbalExercisesCompleted.TargetValue)}% Completed)");
        Console.WriteLine($"Listening Exercises Completed: {ProgressState.listeningExercisesCompleted.CurrentProgress} / {ProgressState.listeningExercisesCompleted.TargetValue} ({ProgressMetric.CalculateProgress(ProgressState.listeningExercisesCompleted.CurrentProgress, ProgressState.listeningExercisesCompleted.TargetValue)}% Completed)");
        Console.WriteLine($"Language Learning Goal Progress: {LanguageLearningService.LanguageLearningGoal.CurrentProgress} / {LanguageLearningService.LanguageLearningGoal.TargetValue}%\n");
        ShowFooter(60);
        LanguageLearningService.PrintLanguageLearningMilestones();
        Console.WriteLine();
        ShowFooter(60);
    }

    
     public static void LanguageLearningWeeklySchedule() 
    {
            ConsoleUI.ShowHeader("            Language Learning Schedule\n            " + DateTime.Now.ToString("D"), 60);
            foreach (var option in ScheduleTemplates.LanguageLearningSchedule)
            {
                Console.WriteLine(option);
            }
            ShowFooter(60);
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

    public static void ShowMenuFooter(int width)
    {
        Console.WriteLine();
        Console.WriteLine(new string('-', width));
    }
    public static void ShowFooter(int width)
    {
        Console.WriteLine(new string('-', width));
        Console.WriteLine();
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
}
    
