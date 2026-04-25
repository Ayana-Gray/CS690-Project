# Development Documentation

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

Current journal/reminder behavior is implemented as static utility-style methods. This keeps logic small and direct for the project timeline.

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

