## Project Overview
Goal Progress Tracker is a C# console application targeting .NET 10.

- Project file: FinalProject/GoalProgressTracker/ProgressTracker.csproj
- Entry point: FinalProject/GoalProgressTracker/Program.cs
- Solution file: FinalProject/FinalProject.slnx

## Prerequisites

1. OS: Windows, macOS, or Linux
2. .NET SDK: 10.0 (Install NET SDK Version 10 from the official page [NET SDK](https://dotnet.microsoft.com/en-us/download))
3. Git (Install Git from the official page [Git](https://git-scm.com/))

Verify SDK:

```bash
dotnet --version
```

## Local Deployment

1. Clone Repository or download the latest Release.
- Run the following command to clone it in your local
```bash
git clone https://github.com/Ayana-Gray/CS690-Project
```
   *Now type this to get it to run:

```bash
cd FinalProject
cd GoalProgressTracker
dotnet run
```

- Or you can obtain the latest release at:

```bash
https://github.com/Ayana-Gray/CS690-Project/releases/tag/v1.0.0
```
   * Download the executable called GoalProgressTracker.zip

   * Unzip it in your Local

   * In your terminal type:
```bash
cd Downloads
cd GoalProgressTracker 
dotnet GoalProgressTracker.dll
```

## Data and Runtime Files

The application reads/writes files in the project directory, including:

- progressMetrics.json
- Journal.txt
- LanguageLearningReminders.txt
- HalfMarathonReminders.txt
- NovelCreationReminders.txt

When deploying, keep these files with the executable if you want existing data to carry over.

## Environment Configuration

No environment variables are required for default operation.

## Basic Verification Checklist

After deployment, verify:

1. App starts and Main Menu appears.
2. You can create a journal entry and view it.
3. You can save and view reminders for all three goal categories.
4. Progress updates persist in progressMetrics.json.

## Troubleshooting

1. dotnet not found:
- Install the .NET SDK and restart terminal.

2. Build fails due to target framework:
- Ensure installed SDK supports net10.0.

3. Data not persisting:
- Confirm app has write permission in its working directory.
- Confirm data files are not read-only.

4. File-not-found messages for reminders/journal:
- Run once from project directory to create expected files.
