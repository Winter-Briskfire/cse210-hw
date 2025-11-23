using System;
using System.Threading;

namespace MindfulnessProgram
{
    public class BreathingActivity : Activity
    {
        public BreathingActivity() : base("Breathing Activity",
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
        {
        }

        protected override void PerformActivity()
        {
            DateTime end = DateTime.Now.AddSeconds(DurationSeconds);
            bool inhale = true;

            while (DateTime.Now < end)
            {
                int timeLeft = (int)Math.Ceiling((end - DateTime.Now).TotalSeconds);
                int breathSec = Math.Min(4, Math.Max(1, timeLeft));

                if (inhale)
                {
                    Console.WriteLine("Breathe in...");
                    SimpleBarAnimation(breathSec, growing: true);
                }
                else
                {
                    Console.WriteLine("Breathe out...");
                    SimpleBarAnimation(breathSec, growing: false);
                }

                inhale = !inhale;
                Console.WriteLine();
            }
        }

        private void SimpleBarAnimation(int seconds, bool growing)
        {
            int width = 12;
            for (int s = 0; s < seconds; s++)
            {
                int bars = growing
                    ? (int)Math.Round(((double)(s + 1) / seconds) * width)
                    : (int)Math.Round(((double)(seconds - s - 1) / seconds) * width);

                if (bars < 0) bars = 0;
                if (bars > width) bars = width;

                Console.Write("[");
                Console.Write(new string('#', bars));
                Console.Write(new string(' ', width - bars));
                Console.Write("]");
                Thread.Sleep(1000);

                // erase exactly width+2 characters: [,bars,spaces,]
                for (int i = 0; i < width + 2; i++) Console.Write("\b \b");
            }
        }
    }
}
