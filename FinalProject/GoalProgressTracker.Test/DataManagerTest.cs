namespace GoalProgressTracker.Test;

using System;
using System.IO;
using Xunit;

[Collection("Sequential")]
public class DataManagerTest 
{
    [Fact]
    public void SaveDataTest()
    {
        
        string filePath = "test_data.txt";
        string data = "Test data for DataManager";

        
        DataManager.SaveData(filePath, data);

        
        Assert.True(File.Exists(filePath));
        string fileContent = File.ReadAllText(filePath);
        Assert.Equal(data, fileContent);

       
        File.Delete(filePath);
    }

    [Fact]
    public void LoadDataTest()
    {
        
        string filePath = "test_data.txt";
        string data = "This is some words for the test file.";
        File.WriteAllText(filePath, data);

       
        string loadedData = DataManager.LoadData(filePath);

        
        Assert.Equal(data, loadedData);
        File.Delete(filePath);
    }

    [Fact]
    public void LoadDataEmptyTest()
    {
        string filePath = "emptyfile.txt";
    try 
    {
        File.WriteAllText(filePath, string.Empty);
        string loadedData = DataManager.LoadData(filePath);
        Assert.Equal(string.Empty, loadedData);
    }
    finally 
    {
        if (File.Exists(filePath)) File.Delete(filePath);
    }
    }
   
    [Fact]
    public void SaveAndLoadMetricsData()
    {
        int originalVocabProgress = ProgressState.vocabularyWordsLearned.CurrentProgress;
        
        var mockMap = new Dictionary<string, string>
        {
           {"Vocabulary Words Learned", "100" }
        };

        try 
        {
            if (mockMap.TryGetValue("Vocabulary Words Learned", out var vocabValue) && 
                int.TryParse(vocabValue, out var vocabProgress))
            {
                ProgressState.vocabularyWordsLearned.SetProgress(vocabProgress);
            }

            Assert.Equal(100, ProgressState.vocabularyWordsLearned.CurrentProgress);
        }
        finally 
        {
            ProgressState.vocabularyWordsLearned.SetProgress(originalVocabProgress);
        }
    }
}

    
