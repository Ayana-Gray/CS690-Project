namespace GoalProgressTracker;

using System;
using System.IO;
using System.Collections.Generic;

public class Journal
{
    public string Name { get; }
    public string Content { get; set; }
    private const string JournalFilePath = "Journal.txt";

    
    public static Journal MyJournal { get; private set; }

    static Journal()
    {
       
        string existingContent = "";
        if (File.Exists(JournalFilePath))
        {
            existingContent = File.ReadAllText(JournalFilePath);
        }
        MyJournal = new Journal("My Journal", existingContent);
    }

    public Journal(string name, string content)
    {
        Name = name;
        Content = content;
    }

    public static void CreateJournalEntry()
    {
        Console.WriteLine("\nJournal what you love, what you hate, what’s in your head, what’s important.");
        Console.WriteLine("Journaling organizes your thoughts; allows you to see things in a concrete");
        Console.WriteLine("way that otherwise you might not see. — Kay WalkingStick\n");
        Console.WriteLine(new string('-', 80));
        Console.WriteLine("\nEnter your journal entry. Submit an empty line to finish.");

        var lines = new List<string>();
        while (true)
        {
            var line = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(line)) break;
            lines.Add(line);
        }

        if (lines.Count == 0)
        {
            ConsoleUI.ConsolePause("No content entered. Entry not saved.");
            return;
        }

        
        string rawContent = string.Join(Environment.NewLine, lines);
        int journalWidth = 80;
        string wrappedContent = ConsoleUI.WrapText(rawContent, journalWidth);
        
       
        string newEntry = $"Date: {DateTime.Now:D}\n{wrappedContent}\n{Environment.NewLine}";

        MyJournal.Content += newEntry;
        File.AppendAllText(JournalFilePath, newEntry);

        ConsoleUI.ConsolePause("Journal entry saved successfully.");
    }
}


