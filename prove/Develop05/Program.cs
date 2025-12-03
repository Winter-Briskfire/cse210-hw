using System;

class Program
{
    static void Main()
    {
        GoalManager manager = new GoalManager();
        int choice = 0;

        /*
         * EXTRA CREDIT:
         * Added leveling system (level increases every 1000 points)
         * Added status titles (Novice → Seeker → Crusader → Eternal Champion)
         * Added bonus "streak" system for daily EternalGoals
         */

        while (choice != 7)
        {
            manager.DisplayScore();

            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create new goal");
            Console.WriteLine("2. List goals");
            Console.WriteLine("3. Record event");
            Console.WriteLine("4. Save goals");
            Console.WriteLine("5. Load goals");
            Console.WriteLine("6. Clear screen");
            Console.WriteLine("7. Quit");

            Console.Write("Select an option: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    CreateGoal(manager);
                    break;

                case 2:
                    manager.ListGoals();
                    break;

                case 3:
                    manager.RecordEvent();
                    break;

                case 4:
                    Console.Write("Filename: ");
                    manager.SaveToFile(Console.ReadLine());
                    break;

                case 5:
                    Console.Write("Filename: ");
                    manager.LoadFromFile(Console.ReadLine());
                    break;

                case 6:
                    Console.Clear();
                    break;
            }
        }
    }

    static void CreateGoal(GoalManager manager)
    {
        Console.WriteLine("\nSelect goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Your choice: ");

        int type = int.Parse(Console.ReadLine());

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Description: ");
        string description = Console.ReadLine();

        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        if (type == 1)
        {
            manager.AddGoal(new SimpleGoal(name, description, points));
        }
        else if (type == 2)
        {
            manager.AddGoal(new EternalGoal(name, description, points));
        }
        else if (type == 3)
        {
            Console.Write("How many times to complete? ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("Bonus points: ");
            int bonus = int.Parse(Console.ReadLine());

            manager.AddGoal(new ChecklistGoal(name, description, points, target, bonus));
        }

        Console.WriteLine("Goal Added!\n");
    }
}
