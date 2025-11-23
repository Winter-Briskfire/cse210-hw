using System;

namespace MindfulnessProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Mindfulness Program";
            var breathing = new BreathingActivity();
            var reflection = new ReflectionActivity();
            var listing = new ListingActivity();
            var gratitude = new GratitudeActivity();

            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Mindfulness Program");
                Console.WriteLine("-------------------");
                Console.WriteLine("1) Breathing Activity");
                Console.WriteLine("2) Reflection Activity");
                Console.WriteLine("3) Listing Activity");
                Console.WriteLine("4) Gratitude Activity (Bonus)");
                Console.WriteLine("5) Quit");
                Console.Write("Choice (1-5): ");

                string choice = Console.ReadLine()?.Trim();
                switch (choice)
                {
                    case "1":
                        breathing.Run();
                        ActivityLogger.Log(breathing.Name, breathing.DurationSeconds);
                        Pause();
                        break;
                    case "2":
                        reflection.Run();
                        ActivityLogger.Log(reflection.Name, reflection.DurationSeconds);
                        Pause();
                        break;
                    case "3":
                        listing.Run();
                        Pause();
                        break;
                    case "4":
                        gratitude.Run();
                        ActivityLogger.Log(gratitude.Name, gratitude.DurationSeconds);
                        Pause();
                        break;
                    case "5":
                        exit = true;
                        Console.WriteLine("Goodbye — breathe easy.");
                        System.Threading.Thread.Sleep(700);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Press a key...");
                        Console.ReadKey(true);
                        break;
                }
            }
        }

        private static void Pause()
        {
            Console.WriteLine();
            Console.WriteLine("Returning to menu...");
            System.Threading.Thread.Sleep(700);
        }
    }
}
