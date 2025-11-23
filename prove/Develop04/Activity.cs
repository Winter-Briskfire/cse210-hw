using System;
using System.IO;
using System.Threading;

namespace MindfulnessProgram
{
    public abstract class Activity
    {
        private string _name;
        private string _description;
        private int _durationSeconds;

        protected Activity(string name, string description)
        {
            _name = name;
            _description = description;
        }

        public string Name => _name;
        public string Description => _description;
        public int DurationSeconds => _durationSeconds;

        public void SetDuration(int seconds)
        {
            if (seconds < 1) seconds = 1;
            _durationSeconds = seconds;
        }

        protected void DisplayStartingMessage()
        {
            Console.Clear();
            Console.WriteLine($"--- {Name} ---\n");
            Console.WriteLine(Description + "\n");
            Console.Write($"How long, in seconds, would you like for the {Name.ToLower()}? ");
        }

        protected void DisplayEndingMessage()
        {
            Console.WriteLine();
            Console.WriteLine("Well done!");
            Console.WriteLine($"You have completed the {Name} for {DurationSeconds} seconds.");
            Console.WriteLine();
            Spinner(2);
            Console.WriteLine();
        }

        protected void Spinner(int seconds)
        {
            string[] spin = { "|", "/", "-", "\\" };
            DateTime end = DateTime.Now.AddSeconds(seconds);
            int i = 0;
            while (DateTime.Now < end)
            {
                Console.Write(spin[i % spin.Length]);
                Thread.Sleep(250);
                Console.Write("\b \b");
                i++;
            }
        }

        protected void Countdown(int seconds)
        {
            for (int i = seconds; i >= 1; i--)
            {
                string s = i.ToString();
                Console.Write(s);
                Thread.Sleep(1000);
                for (int k = 0; k < s.Length; k++) Console.Write("\b \b");
            }
        }

        public void Run()
        {
            DisplayStartingMessage();

            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out int seconds) && seconds > 0)
                {
                    SetDuration(seconds);
                    break;
                }
                Console.Write("Enter a positive integer for seconds: ");
            }

            Console.WriteLine("\nGet ready...");
            Spinner(2);
            Console.WriteLine();

            PerformActivity();

            DisplayEndingMessage();
        }

        protected abstract void PerformActivity();
    }

    // Simple logger used by activities
    public static class ActivityLogger
    {
        private static readonly string LogFile = "mindfulness_log.txt";
        private static readonly object Locker = new object();

        public static void Log(string activityName, int durationSeconds, int itemsCount = -1)
        {
            try
            {
                lock (Locker)
                {
                    using (StreamWriter sw = new StreamWriter(LogFile, append: true))
                    {
                        string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        string line = $"{time} | {activityName} | duration: {durationSeconds}s";
                        if (itemsCount >= 0) line += $" | items: {itemsCount}";
                        sw.WriteLine(line);
                    }
                }
            }
            catch
            {
                // ignore logging errors
            }
        }
    }
}
