namespace GoalProgressTracker;

class Program
{ //static bool keepRunning = true;
    static void Main(string[] args)
    {
        DataManager.InitializeMetrics();

        while (ConsoleUI.keepRunning)
        {
            
            ConsoleUI.MainMenu();
        }
        
        Console.WriteLine("Goodbye! The program has exited.");
    }
}