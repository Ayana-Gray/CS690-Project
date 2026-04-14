namespace GoalProgressTracker;

using System;
using System.IO;

public class SetAReminder
{
    public string Name { get; }
    public string Content { get; set; }
    public SetAReminder(string name, string content)
    {
        this.Name = name;
        this.Content = content;
    }

    public static void SaveReminder(string filePath)
    {
        Console.WriteLine("Enter your reminder. Submit an empty line to finish.");

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
            ConsoleUI.ConsolePause("No content entered. Reminder not saved.");
            return;
        }

        string content = string.Join(Environment.NewLine, lines);

        try
        {
            // Overwrites the file each time
            File.WriteAllText(filePath, "Current Reminder(s): \n" + content + "\n" + Environment.NewLine);

            ConsoleUI.ConsolePause("Reminder saved successfully (previous content replaced).");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving reminder: {ex.Message}");
            ConsoleUI.ConsolePause("Press any key to continue...");
        }
    }

    public static void ViewReminder(string filePath)
    {
        if (File.Exists(filePath))
        {
            try
            {
                string[] entries = File.ReadAllLines(filePath);

                if (entries.Length == 0)
                {
                    Console.WriteLine("The file is empty.");
                }
                else
                {
                    
                    Console.WriteLine();
                    foreach (var entry in entries)
                    {
                        Console.WriteLine(entry);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine($"File '{filePath}' not found.");
        }
    }

}