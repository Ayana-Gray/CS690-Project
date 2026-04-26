# Development Document

## Purpose
This document describes architecture, structure, coding approach, and maintenance practices for Goal Progress Tracker.

## Tech Stack

- Language: C#
- Platform: .NET 10 console application
- Serialization: System.Text.Json
- Data storage: Local text and JSON files

## Project Structure

- FinalProject/GoalProgressTracker/Program.cs: Application startup
- FinalProject/GoalProgressTracker/ConsoleUI.cs: Menu flow and user interaction
- FinalProject/GoalProgressTracker/Domain: Domain model and domain behavior
- FinalProject/GoalProgressTracker/Services: Goal-specific service logic
- FinalProject/GoalProgressTracker/DataManager.cs: JSON/text persistence helper
- FinalProject/GoalProgressTracker/ScheduleTemplates.cs: Static schedule data
- FinalProject/GoalProgressTracker/Files.cs: Text files
- FinalProject/GoalProgressTracker/Menus.cs: Strings used for Menus
- FinalProject/GoalProgressTracker/DailyTask.cs: Daily Task methods for Homepages
- FinalProject/GoalProgressTracker/ProgressState.cs: Holds current values in memory while program is running

## Core Flow

1. Program starts and calls ConsoleUI.InitializeMetrics().
2. Main loop runs until exit flag changes.
3. Menu routes user to goal modules, journal, or reminders.
4. Changes persist to local files.

## Data Model Notes

Key domain entities include:

- Goal
- ProgressMetric
- Milestone
- Journal behavior
- Reminder behavior

Current journal/reminder behavior is implemented as static utility-style methods. This keeps logic small and direct for the project 

## Persistence Strategy

1. Structured metric data:
- Stored in progressMetrics.json
- Serialized/deserialized with System.Text.Json

2. Freeform text data:
- Journal and reminders stored in .txt files
- Read/write operations use System.IO APIs

This mixed strategy is intentional:

- JSON for structured progress values
- TXT for human-readable notes

## Build and Run

From FinalProject/GoalProgressTracker:

```bash
dotnet restore
dotnet build
dotnet run
```

## SDKs & Tools
1. Install NET SDK Version 10 from the official page [NET SDK](https://dotnet.microsoft.com/en-us/download) 
2. Install Git from the official page [Git](https://git-scm.com)


## Clone the repository in your local
1. Run the following command to clone it in your local
2. git clone https://github.com/Ayana-Gray/CS690-Project

## Testing
1. cd FinalProject 
2. cd GoalProgressTracker
3. Run the test command: dotnet test 
4. If the tests pass, you are safely in the development environment.

## Running
1. cd FinalProject
2. cd GoalProgressTracker
3. dotnet run

## Development
Please follow the steps In order to contribute to the project, you must follow these steps.
This repository is protected so you cannot commit directly into the main branch.

1. Create a branch
2. Work on your revision
3. Test locally 
4. Commit/push your branch
5. Create a pull request

## Making A Release
1. Inside the solution directory called: FinalProject
2. Type "dotnet publish"
3. Copy/paste 'Journal.txt', 'progressMetrics.json', 'LanguageLearningReminders.txt', 'HalfMarathonReminders.txt', 'NovelCreationReminders.txt' file to the publish folder noted in the output of the command 
(Program Automatically makes these files as well)
4. zip -r GoalProgressTracker.zip * to create the zip file of the executables
5. Create a new release in GitHub with the appropriate version number and notes

## Code Style and Refactor Guidance

1. Keep architecture stable.
2. Prioritize readability and bug fixes over major redesign.
3. Remove dead code quickly when found.
4. Deduplicate repeated input-reading logic only when low risk.
5. Improve naming clarity and user-facing messages.
6. Add small guard clauses for invalid input.

## Testing Approach

1. Test all main menu paths.
2. Verify save/load behavior for metrics.
3. Verify journal write/read flow.
4. Verify each reminder file write/read flow.
5. Verify invalid menu input handling.



