namespace GoalProgressTracker;

using System;
using System.IO;

public class Journal 
{
    public string Name { get; }
    public string Content { get; set; }
    private const string JournalFilePath = "Journal.txt";

    public Journal(string name, string content)
    {
        this.Name = name;
        this.Content = content;
    }

    public static Journal MyJournal = new Journal("My Journal", "");

    static Journal() //allows for saved files to be seen after you close  the program and restart
    {
        if (File.Exists(JournalFilePath))
        {
            MyJournal.Content = File.ReadAllText(JournalFilePath);
        }
    }

    public static void CreateJournalEntry()
    {
        Console.WriteLine();
        Console.WriteLine("Journal what you love, what you hate, what’s in your head, what’s important.\nJournaling organizes your thoughts; allows you to see things in a concrete \nway that otherwise you might not see."+ "— Kay WalkingStick\n");
        Console.WriteLine(new string('-', 80));
        Console.WriteLine("");
        Console.WriteLine("Enter your journal entry. Submit an empty line to finish.");
        var lines = new List<string>();
        while (true)
        {
            var line = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(line))
            {
                break;
            }

            lines.Add(line);
        }

        if (lines.Count == 0)
        {
            ConsoleUI.ConsolePause("No content entered. Entry not saved.");
            return;
        }
        string content = string.Join(Environment.NewLine, lines);
        int journalWidth = 80; 
        string finalEntry = ConsoleUI.WrapText(content, journalWidth);
        string entry = "Date: " + DateTime.Now.ToString("D") + "\n" + finalEntry + "\n" + Environment.NewLine;
        Journal.MyJournal.Content += entry;
        File.AppendAllText(JournalFilePath, entry);
        ConsoleUI.ConsolePause("Journal entry saved successfully.");
    }

}

