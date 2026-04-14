# User Guide

## What This App Does
Goal Progress Tracker helps you manage progress across three personal goals and supporting activities:

1. Language Learning
2. Half Marathon Training
3. Novel Creation

It also includes:

- Journal entry tracking
- Goal-specific reminders
- Progress metrics and progress reports

## Starting the Application

1. Open terminal in FinalProject/GoalProgressTracker
2. Run:

```bash
dotnet run
```

3. Wait for the Main Menu prompt.

## Main Menu Navigation

From the Main Menu, select:

1. Language Learning
2. Half Marathon Training
3. Novel Creation
4. Journal
5. Set A Reminder
6. Exit

Type the number for your selection and press Enter.

## Language Learning

From this menu you can:

1. View the Language Learning homepage
2. View schedule information
3. Record progress
4. View progress report

Progress values are stored and reused when you run the app again.

## Half Marathon Training

From this menu you can:

1. View training homepage
2. See schedule and current training week context
3. Record running progress
4. View progress report

## Novel Creation

From this menu you can:

1. View novel creation homepage
2. Record writing/phase progress
3. View progress report

## Journal

Journal options let you:

1. Create Journal Entry
2. View Journal Entries

How journal entry input works:

1. Enter one or more lines.
2. Submit a blank line to finish.
3. Entry is saved to Journal.txt.

## Set A Reminder

Reminder options are goal-specific:

1. Language Learning reminder
2. Half Marathon reminder
3. Novel Creation reminder

How reminder input works:

1. Existing reminder is displayed first.
2. Enter one or more lines.
3. Submit a blank line to finish.
4. Reminder file is updated.

## Data Files

Your progress and notes are stored in local files:

- progressMetrics.json
- Journal.txt
- LanguageLearningReminders.txt
- HalfMarathonReminders.txt
- NovelCreationReminders.txt

## Tips For Best Use

1. Update progress immediately after finishing daily tasks.
2. Keep reminders short and specific.
3. Use the journal for blockers, wins, and weekly reflections.
4. Review progress reports weekly.

## Common Issues

1. Nothing saves:
- Ensure you have write permission in the project folder.

2. Unexpected menu behavior:
- Enter only valid menu numbers shown on screen.

3. Lost context across runs:
- Confirm you are launching from the same folder where data files exist.
