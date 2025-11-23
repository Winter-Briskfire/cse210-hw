using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace MindfulnessProgram
{
    /// <summary>
    /// ListingActivity: user lists items for a prompt until time runs out.
    /// Also contains a bonus GratitudeActivity class (so the project remains 5 files).
    /// This class demonstrates non-blocking input using Console.KeyAvailable and logs counts.
    /// </summary>
    public class ListingActivity : Activity
    {
        private List<string> _prompts = new List<string>()
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        private Queue<string> _promptQueue;
        private Random _rng = new Random();

        public ListingActivity() : base("Listing Activity",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
        {
            _promptQueue = new Queue<string>(ShuffleList(_prompts));
        }

        private List<string> ShuffleList(List<string> source)
        {
            return source.OrderBy(x => _rng.Next()).ToList();
        }

        // Non-blocking read until Enter or timeout
        private string ReadLineWithTimeout(DateTime endTime)
        {
            StringBuilder buffer = new StringBuilder();
            while (DateTime.Now < endTime)
            {
                while (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(intercept: true);
                    if (key.Key == ConsoleKey.Enter)
                    {
                        Console.WriteLine();
                        return buffer.ToString();
                    }
                    else if (key.Key == ConsoleKey.Backspace)
                    {
                        if (buffer.Length > 0)
                        {
                            buffer.Length--;
                            Console.Write("\b \b");
                        }
                    }
                    else
                    {
                        buffer.Append(key.KeyChar);
                        Console.Write(key.KeyChar);
                    }
                }
                Thread.Sleep(40);
            }

            if (buffer.Length > 0)
            {
                Console.WriteLine();
                return buffer.ToString();
            }
            return null;
        }

        protected override void PerformActivity()
        {
            if (_promptQueue.Count == 0)
            {
                foreach (var p in ShuffleList(_prompts)) _promptQueue.Enqueue(p);
            }
            string prompt = _promptQueue.Dequeue();

            Console.WriteLine(prompt);
            Console.WriteLine();
            Console.WriteLine("You will have a short moment to think, then list items. Press Enter after each item.");
            Console.WriteLine();

            Console.Write("Thinking time: ");
            Countdown(5);
            Console.WriteLine();
            Console.WriteLine("Start listing now:");

            DateTime end = DateTime.Now.AddSeconds(DurationSeconds);
            List<string> items = new List<string>();

            while (DateTime.Now < end)
            {
                string entry = ReadLineWithTimeout(end);
                if (entry == null)
                {
                    // time expired
                    break;
                }

                if (!string.IsNullOrWhiteSpace(entry))
                {
                    items.Add(entry.Trim());
                }
            }

            Console.WriteLine();
            Console.WriteLine($"You listed {items.Count} item(s).");

            // Log listing activity with count
            ActivityLogger.Log(Name, DurationSeconds, items.Count);
        }
    }

    /// <summary>
    /// GratitudeActivity: Bonus activity implemented in the same file to keep project at five files.
    /// Simple listing focused on gratitude; saves the items to a gratitude file.
    /// </summary>
    public class GratitudeActivity : Activity
    {
        private readonly List<string> _seedPrompts = new List<string>()
        {
            "Name people you are grateful for.",
            "Name small things today that made you smile.",
            "Name experiences you're thankful for this year."
        };
        private Queue<string> _promptQueue;
        private Random _rng = new Random();

        public GratitudeActivity() : base("Gratitude Activity",
            "This bonus activity helps you list things you're grateful for. Items will be saved to gratitude_log.txt.")
        {
            _promptQueue = new Queue<string>(_seedPrompts.OrderBy(x => _rng.Next()));
        }

        protected override void PerformActivity()
        {
            if (_promptQueue.Count == 0)
            {
                foreach (var p in _seedPrompts.OrderBy(x => _rng.Next())) _promptQueue.Enqueue(p);
            }

            string prompt = _promptQueue.Dequeue();
            Console.WriteLine(prompt);
            Console.WriteLine();

            Console.Write("Thinking time: ");
            Countdown(5);
            Console.WriteLine();
            Console.WriteLine("Start listing now (press Enter after each item):");

            DateTime end = DateTime.Now.AddSeconds(DurationSeconds);
            List<string> items = new List<string>();

            while (DateTime.Now < end)
            {
                string entry = ReadLineWithTimeout(end);
                if (entry == null) break;
                if (!string.IsNullOrWhiteSpace(entry)) items.Add(entry.Trim());
            }

            Console.WriteLine();
            Console.WriteLine($"You listed {items.Count} gratitude item(s).");

            // Save gratitude items to a file
            try
            {
                SaveGratitudeItems(items);
                Console.WriteLine("Your gratitude items were saved to gratitude_log.txt");
            }
            catch
            {
                Console.WriteLine("Couldn't save gratitude items (file error).");
            }
        }

        // Helper similar to ListingActivity but duplicated here to avoid cross-file dependencies
        private string ReadLineWithTimeout(DateTime endTime)
        {
            StringBuilder buffer = new StringBuilder();
            while (DateTime.Now < endTime)
            {
                while (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(intercept: true);
                    if (key.Key == ConsoleKey.Enter)
                    {
                        Console.WriteLine();
                        return buffer.ToString();
                    }
                    else if (key.Key == ConsoleKey.Backspace)
                    {
                        if (buffer.Length > 0)
                        {
                            buffer.Length--;
                            Console.Write("\b \b");
                        }
                    }
                    else
                    {
                        buffer.Append(key.KeyChar);
                        Console.Write(key.KeyChar);
                    }
                }
                Thread.Sleep(40);
            }

            if (buffer.Length > 0)
            {
                Console.WriteLine();
                return buffer.ToString();
            }
            return null;
        }

        private void SaveGratitudeItems(List<string> items)
        {
            string file = "gratitude_log.txt";
            using (StreamWriter sw = new StreamWriter(file, append: true))
            {
                sw.WriteLine($"--- {DateTime.Now:yyyy-MM-dd HH:mm:ss} ---");
                foreach (var it in items)
                {
                    sw.WriteLine(it);
                }
            }
        }
    }
}
