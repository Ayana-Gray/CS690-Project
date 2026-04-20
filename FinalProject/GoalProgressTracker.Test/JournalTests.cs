namespace GoalProgressTracker.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;  
using Xunit;

public class JournalTest
{
    [Fact]
    public void JournalEntryTest()
    {
        // Arrange
        Journal journal = new Journal("my Journal","");
        string entry = "This is a test journal. I wrote this line very long to see if it passes another test.";
        string JournalFilePath = "Journal.txt";
        string content = string.Join(Environment.NewLine, entry);
        int journalWidth = 10; 
        string finalEntry = ConsoleUI.WrapText(content, journalWidth);
        string entrytest = "Date: " + DateTime.Now.ToString("D") + "\n" + finalEntry + "\n" + Environment.NewLine;
        journal.Content += entrytest;
        File.AppendAllText(JournalFilePath, journal.Content);
        // Assert
        Assert.Equal(entrytest, journal.Content);
        Assert.Contains("Date: " + DateTime.Now.ToString("D"), journal.Content);
        Assert.True(File.Exists(JournalFilePath));
        
    }
}  

