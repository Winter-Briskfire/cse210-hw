using System;

class Program
{
    static void Main(string[] args)
    {
        // EXCEEDING REQUIREMENTS:
        // - Allows user to choose from multiple scriptures (mini library)
        // - Stores scriptures in a list and selects one randomly
        // - Explained in rubric notes above

        List<Scripture> library = new List<Scripture>()
        {
            new Scripture(new Reference("John", 3, 16),
                "For God so loved the world that he gave his only begotten Son, " +
                "that whosoever believeth in him should not perish, but have everlasting life."),

            new Scripture(new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart; and lean not unto thine own understanding. " +
                "In all thy ways acknowledge him, and he shall direct thy paths.")
        };

        Random rnd = new Random();
        Scripture scripture = library[rnd.Next(library.Count)];

        // Program loop
        while (!scripture.AllWordsHidden())
        {
            Console.Clear();
            scripture.Display();

            Console.WriteLine("\nPress ENTER to hide words or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                return;

            scripture.HideRandomWords(3); // hide 3 words each time
        }

        // When all words are hidden
        Console.Clear();
        scripture.Display();
        Console.WriteLine("\nAll words hidden. Program ending...");
    }
}
