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

## Code Style and Refactor Guidance

Preferred short-term approach:

1. Keep architecture stable before deadline.
2. Prioritize readability and bug fixes over major redesign.
3. Remove dead code quickly when found.
4. Keep methods focused and small where practical.

Refactor priorities that are safe before submission:

1. Remove unused fields, constructors, and comments.
2. Deduplicate repeated input-reading logic only when low risk.
3. Improve naming clarity and user-facing messages.
4. Add small guard clauses for invalid input.

## Testing Approach

Given timeline, use practical manual test scripts:

1. Smoke test all main menu paths.
2. Verify save/load behavior for metrics.
3. Verify journal write/read flow.
4. Verify each reminder file write/read flow.
5. Verify invalid menu input handling.

Optional automated tests can be added later if time remains.

## Risks and Mitigations

1. Risk: Breaking menu flow during late refactors.
- Mitigation: Freeze menu structure and do incremental edits.

2. Risk: Data file format changes near deadline.
- Mitigation: Keep current file format stable until submission.

3. Risk: Regression in persistence logic.
- Mitigation: Run end-to-end manual tests after each persistence change.

## Suggested Next Improvements (Post-Deadline)

1. Introduce models for journal entries/reminders if advanced features are needed.
2. Add unit tests for metric serialization and validation.
3. Move file paths into centralized constants.
4. Add lightweight logging for save/load errors.
