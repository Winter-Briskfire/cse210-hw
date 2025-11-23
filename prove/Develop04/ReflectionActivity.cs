using System;
using System.Collections.Generic;
using System.Linq;

namespace MindfulnessProgram
{
    public class ReflectionActivity : Activity
    {
        private readonly List<string> _prompts = new List<string>()
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private readonly List<string> _questions = new List<string>()
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        private Queue<string> _promptQueue;
        private Queue<string> _questionQueue;
        private Random _rng = new Random();

        public ReflectionActivity() : base("Reflection Activity",
            "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
        {
            _promptQueue = new Queue<string>(_prompts.OrderBy(x => _rng.Next()));
            _questionQueue = new Queue<string>(_questions.OrderBy(x => _rng.Next()));
        }

        protected override void PerformActivity()
        {
            if (_promptQueue.Count == 0)
                foreach (var p in _prompts.OrderBy(x => _rng.Next())) _promptQueue.Enqueue(p);

            string prompt = _promptQueue.Dequeue();
            Console.WriteLine(prompt);
            Console.WriteLine("When you have something in mind, press Enter to continue.");
            Console.ReadLine();
            Console.WriteLine();

            DateTime end = DateTime.Now.AddSeconds(DurationSeconds);

            while (DateTime.Now < end)
            {
                if (_questionQueue.Count == 0)
                    foreach (var q in _questions.OrderBy(x => _rng.Next())) _questionQueue.Enqueue(q);

                string question = _questionQueue.Dequeue();
                Console.WriteLine(question);

                int reflectSec = 7;
                int timeLeft = (int)Math.Ceiling((end - DateTime.Now).TotalSeconds);
                if (timeLeft <= 0) break;
                if (timeLeft < reflectSec) reflectSec = Math.Max(1, timeLeft);

                Spinner(reflectSec);
                Console.WriteLine();
            }
        }
    }
}
