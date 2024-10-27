using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> goals = new List<Goal>();
    private const string GoalsFile = "goals.txt";
    private const string PointsFile = "points.txt";

    public void CreateGoal()
    {
        Console.WriteLine("Choose goal type:");
        Console.WriteLine("1. Simple");
        Console.WriteLine("2. Eternal");
        Console.WriteLine("3. Checklist");
        string type = Console.ReadLine();

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();

        if (goals.Exists(g => g.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
        {
            Console.WriteLine("Error: A goal with this name already exists.");
            return;
        }

        Console.Write("Enter goal points: ");
        int points = int.Parse(Console.ReadLine());

        switch (type)
        {
            case "1":
                goals.Add(new SimpleGoal(name, points));
                break;
            case "2":
                goals.Add(new EternalGoal(name, points));
                break;
            case "3":
                Console.Write("Enter target count: ");
                int targetCount = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points: ");
                int bonusPoints = int.Parse(Console.ReadLine());
                goals.Add(new ChecklistGoal(name, points, targetCount, bonusPoints));
                break;
            default:
                Console.WriteLine("Unknown goal type.");
                break;
        }
    }

    public void ListGoals()
    {
        foreach (var goal in goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    public void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter(GoalsFile))
        {
            foreach (var goal in goals)
            {
                writer.WriteLine(goal.ToFileString());
            }
        }
    }

    public void LoadGoals()
    {
        if (!File.Exists(GoalsFile)) return;

        using (StreamReader reader = new StreamReader(GoalsFile))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(",");
                string name = parts[0];
                string type = parts[1];
                int points = int.Parse(parts[2]);

                switch (type)
                {
                    case "Simple":
                        goals.Add(new SimpleGoal(name, points));
                        break;
                    case "Eternal":
                        goals.Add(new EternalGoal(name, points));
                        break;
                    case "Checklist":
                        int targetCount = int.Parse(parts[3]);
                        int bonusPoints = int.Parse(parts[4]);
                        goals.Add(new ChecklistGoal(name, points, targetCount, bonusPoints));
                        break;
                    default:
                        Console.WriteLine("Unknown goal type.");
                        break;
                }
            }
        }
    }

    public void RecordEvent()
    {
        Console.Write("Enter the name of the goal to record: ");
        string name = Console.ReadLine();
        Goal goal = goals.Find(g => g.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        if (goal != null)
        {
            goal.RecordEvent();
            SavePoints(goal.Points);
            Console.WriteLine($"Recorded event for: {goal.Name}");
            
            if (goal is SimpleGoal simpleGoal && simpleGoal.IsComplete)
            {
                goals.Remove(goal);
            }
            else if (goal is ChecklistGoal checklistGoal && checklistGoal.CurrentCount >= checklistGoal.TargetCount)
            {
                goals.Remove(goal);
            }
        }
        else
        {
            Console.WriteLine("Goal not found.");
        }
    }

    private void SavePoints(int points)
    {
        using (StreamWriter writer = new StreamWriter(PointsFile, true))
        {
            writer.WriteLine(points);
        }
    }

    public int CalculateTotalPoints()
    {
        int totalPoints = 0;

        if (File.Exists(PointsFile))
        {
            using (StreamReader reader = new StreamReader(PointsFile))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    totalPoints += int.Parse(line);
                }
            }
        }

        return totalPoints;
    }

    private string GetHeroByTier(Tier tier)
    {
        return tier switch
        {
            Tier.One => "Spider-Man",
            Tier.Two => "Black Widow",
            Tier.Three => "Hawkeye",
            Tier.Four => "Captain America",
            Tier.Five => "Iron Man",
            Tier.Six => "Thor",
            Tier.Seven => "Hulk",
            Tier.Eight => "Doctor Strange",
            Tier.Nine => "Scarlet Witch",
            Tier.Ten => "Captain Marvel",
            _ => "Unknown Hero"
        };
    }

    public Tier CalculateTier()
    {
        int totalPoints = CalculateTotalPoints();
        return totalPoints switch
        {
            < 100 => Tier.One,
            < 200 => Tier.Two,
            < 300 => Tier.Three,
            < 400 => Tier.Four,
            < 500 => Tier.Five,
            < 600 => Tier.Six,
            < 700 => Tier.Seven,
            < 800 => Tier.Eight,
            < 900 => Tier.Nine,
            _ => Tier.Ten
        };
    }

    public void ShowMenu()
    {
        while (true)
        {
            Console.Clear();
            Tier currentTier = CalculateTier();
            int totalPoints = CalculateTotalPoints();
            Console.WriteLine($"Current Tier: {currentTier} - {GetHeroByTier(currentTier)} (Points: {totalPoints})\n");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoals();
                    WaitForKeyPress();
                    break;
                case "3":
                    SaveGoals();
                    Console.WriteLine("Goals Saved!");
                    Thread.Sleep(7000);
                    break;
                case "4":
                    LoadGoals();
                    WaitForKeyPress();
                    break;
                case "5":
                    RecordEvent();
                    Console.WriteLine("Event Recorded!");
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    public void WaitForKeyPress()
    {
        Console.WriteLine("Press any key to return to the menu...");
        Console.ReadKey();
        Console.Clear();
    }
}
