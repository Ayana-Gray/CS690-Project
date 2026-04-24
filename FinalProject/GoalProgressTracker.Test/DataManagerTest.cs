namespace GoalProgressTracker.Test;

using System;
using System.IO;
using Xunit;


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
        File.WriteAllText(filePath, string.Empty);
        string loadedData = DataManager.LoadData(filePath);
        Assert.Equal(string.Empty, loadedData);
    }
}