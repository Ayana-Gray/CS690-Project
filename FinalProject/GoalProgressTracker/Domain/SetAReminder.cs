using System.Net.Mime;

namespace GoalProgressTracker
{
    public class SetAReminder 
    {
        public string Name { get; }
        public string Content { get; set; }
        public string FilePath { get; } 

        public SetAReminder(string name, string content, string filePath) 
        {
            this.Name = name;
            this.Content = content;
            this.FilePath = filePath;
            
            if (File.Exists(FilePath)) {
                this.Content = File.ReadAllText(FilePath);
            }
        }
        public static SetAReminder LanguageLearning = new SetAReminder("Language Learning", "", "LanguageLearningReminders.txt");
        public static SetAReminder HalfMarathon = new SetAReminder("Half Marathon Training", "", "HalfMarathonTrainingReminders.txt");
        public static SetAReminder NovelCreation = new SetAReminder("Novel Creation", "", "NovelCreationReminders.txt");

        public void SaveAReminder()
        {
            Console.WriteLine($"Enter reminders for {Name} (Press Enter on an empty line to save):");
            
            List<string> lines = new List<string>();
            string line;
            
            while (!string.IsNullOrWhiteSpace(line = Console.ReadLine() ?? ""))
            {
                lines.Add(line);
            }
            if (lines.Count == 0) 
            { 
                ConsoleUI.ConsolePause("No content entered. Reminder not saved."); 
                return;
            }
            string entry = string.Join(Environment.NewLine, lines);
            int Width = 50; 
            string finalEntry = ConsoleUI.WrapText(entry, Width);
            string content = finalEntry + Environment.NewLine;
            this.Content = content;
            try
            {   
            File.WriteAllText(this.FilePath, this.Content);

            ConsoleUI.ConsolePause("Reminder saved successfully (previous content replaced).");
            }
            catch (Exception ex)
            {
            Console.WriteLine($"Error saving reminder: {ex.Message}");
            ConsoleUI.ConsolePause("Press any key to continue...");
            }
        }
    }
}       