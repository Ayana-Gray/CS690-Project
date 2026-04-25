# Deployment Document

## Project Overview
Goal Progress Tracker is a C# console application targeting .NET 10.

- Project file: FinalProject/GoalProgressTracker/ProgressTracker.csproj
- Entry point: FinalProject/GoalProgressTracker/Program.cs
- Solution file: FinalProject/FinalProject.slnx

## Prerequisites

1. OS: Windows, macOS, or Linux
2. .NET SDK: 10.0 (or the version required by the project target framework)
3. Git (optional, for source checkout)

Verify SDK:

```bash
dotnet --version
```

## Local Deployment (Run From Source)

1. Clone or download the repository.
    Run the following comand to clone it in your local

```bash
git clone https://github.com/Ayana-Gray/CS690-Project
```

2. Open a terminal in the repository root.
3. Move to the project folder:

```bash
cd FinalProject/GoalProgressTracker
```

4. Restore dependencies:

```bash
dotnet restore
```

5. Build the app:

```bash
dotnet build -c Release
```

6. Run the app:

```bash
dotnet run -c Release
```

## Publish a Deployable Build

From FinalProject/GoalProgressTracker:

```bash
dotnet publish -c Release -o ./publish
```

Published output will be in:

- FinalProject/GoalProgressTracker/publish

You can distribute this folder to another machine with the appropriate runtime.

## Data and Runtime Files

The application reads/writes files in the project directory, including:

- progressMetrics.json
- Journal.txt
- LanguageLearningReminders.txt
- HalfMarathonReminders.txt
- NovelCreationReminders.txt

When deploying, keep these files with the executable if you want existing data to carry over.


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
