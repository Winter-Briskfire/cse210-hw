using System;

class Program
{
    static void TestValues(int x, float y, double z)
    {
        Console.WriteLine($"The values are: {x}, {y}, {z}");
    }

    static void Main(string[] args)
    {
        bool done = false;

        while (!done)
        {
            Console.Write("Input your age: ");
            int age = int.Parse(Console.ReadLine());
            if (age >= 0 && age <= 125)
            {
                done = true;
                Console.WriteLine($"Super age: {age}");
            }
        }

        done = false;
        do
        {
            Console.Write("Input your age: ");
            int age = int.Parse(Console.ReadLine());
            if (age >= 0 && age <= 125)
            {
                done = true;
                Console.WriteLine($"Super age: {age}");
            }
        } while (!done);
    }
}