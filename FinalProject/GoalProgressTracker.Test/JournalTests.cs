namespace GoalProgressTracker.Test;

using System;
using System.IO;
using Xunit;

[Collection("Sequential")]
public class JournalTests : IDisposable
{
    private readonly string testFilePath;

    public JournalTests()
    {
        
        testFilePath = "JournalTest.txt";
    }

    [Fact]
    public void JournalEntryTest()
    {
        
        var journal = Journal.MyJournal;
        string testInput = "This is a test journal entry. I typed it very long to ensure that it will need to be wrapped when displayed in the console.";
        int journalWidth = 10; 
        
        string wrappedContent = ConsoleUI.WrapText(testInput, journalWidth);
        string dateHeader = $"Date: {DateTime.Now:D}";
        string expectedFormat = $"{dateHeader}\n{wrappedContent}\n{Environment.NewLine}";

        
        journal.Content += expectedFormat;
        File.AppendAllText(testFilePath, expectedFormat);

        
        Assert.Contains(dateHeader, journal.Content);
        Assert.Contains(wrappedContent, journal.Content);
        Assert.Equal(expectedFormat, journal.Content); 
        Assert.True(File.Exists(testFilePath));
    }

    public void Dispose()
    {
        
        if (File.Exists(testFilePath))
        {
            File.Delete(testFilePath);
        }
    }
}