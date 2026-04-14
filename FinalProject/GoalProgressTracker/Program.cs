namespace GoalProgressTracker;

class Program
{ //static bool keepRunning = true;
    static void Main(string[] args)
    {
        ConsoleUI.InitializeMetrics();

         while (ConsoleUI.keepRunning)
        {
            ConsoleUI.MainMenu();
        }
        
        ConsoleUI.WriteSuccess("Goodbye! The program has exited.");
    }
}