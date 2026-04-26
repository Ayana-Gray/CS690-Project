namespace GoalProgressTracker.Test;

using System;
using System.IO;
using System.Text;
using Xunit;

[Collection("Sequential")]
public class SetAReminderTests : IDisposable
{
    public readonly string testFilePath;
    public readonly SetAReminder setAReminderTest;

    public SetAReminderTests()
    {
        testFilePath = "TestReminders.txt";
        setAReminderTest = new SetAReminder("Test Goal", "", testFilePath);
    }

    [Fact]
    public void SaveARemindertest()
    {

        var input = new StringBuilder();
        input.AppendLine("Buy new training shoes.");
        input.AppendLine("Drink plenty of water.");
        input.AppendLine(); 
        input.AppendLine();

        using var Readstrings = new StringReader(input.ToString());
        Console.SetIn(Readstrings);

        setAReminderTest.SaveAReminder();

        Assert.True(File.Exists(testFilePath));
        
        string savedContent = File.ReadAllText(testFilePath);
        
        Assert.Contains("Buy new training shoes", savedContent);
        Assert.Contains("Drink plenty of water", savedContent);
        Assert.Equal(savedContent, setAReminderTest.Content);
    }
    public void Dispose()
    {
        var standardInput = new StreamReader(Console.OpenStandardInput());
        Console.SetIn(standardInput);

        if (File.Exists(testFilePath))
        {
            File.Delete(testFilePath);
        }
    }
    
}