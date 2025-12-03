using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void DisplayScore()
    {
        Console.WriteLine($"\nYour current score: {_score}\n");
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void ListGoals()
    {
        Console.WriteLine("\nYour Goals:");
        int i = 1;

        foreach (Goal g in _goals)
        {
            Console.WriteLine($"{i}. {g.GetStatus()} {g.GetName()} — {g.GetDescription()}");
            i++;
        }
    }

    public void RecordEvent()
    {
        ListGoals();

        Console.Write("\nWhich goal did you accomplish? ");
        int choice = int.Parse(Console.ReadLine()) - 1;

        int points = _goals[choice].RecordEvent();
        _score += points;

        Console.WriteLine($"You earned {points} points!");
    }

    // ------------------------
    // Save goals
    // ------------------------
    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);

            foreach (Goal g in _goals)
                writer.WriteLine(g.GetStringRepresentation());
        }
    }

    // ------------------------
    // Load goals
    // ------------------------
    public void LoadFromFile(string filename)
    {
        _goals.Clear();

        string[] lines = File.ReadAllLines(filename);
        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] parts = line.Split(":");
            string type = parts[0];
            string[] data = parts[1].Split("|");

            if (type == "SimpleGoal")
            {
                AddGoal(new SimpleGoal(
                    data[0], data[1],
                    int.Parse(data[2]),
                    bool.Parse(data[3])
                ));
            }
            else if (type == "EternalGoal")
            {
                AddGoal(new EternalGoal(
                    data[0], data[1],
                    int.Parse(data[2])
                ));
            }
            else if (type == "ChecklistGoal")
            {
                AddGoal(new ChecklistGoal(
                    data[0], data[1],
                    int.Parse(data[2]),
                    int.Parse(data[3]),
                    int.Parse(data[4]),
                    int.Parse(data[5])
                ));
            }
        }
    }
}
