namespace GoalProgressTracker;

using System.IO;


internal class DataManager
{

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
}