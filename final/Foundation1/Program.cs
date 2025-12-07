class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video v1 = new Video("How to Bake Bread", "Chef Tom", 480);
        v1.AddComment(new Comment("Sarah", "Great tutorial!"));
        v1.AddComment(new Comment("Mike", "I'm trying this today."));
        v1.AddComment(new Comment("Jess", "Perfect instructions."));
        videos.Add(v1);

        Video v2 = new Video("C# Polymorphism Explained", "CodeGuru", 900);
        v2.AddComment(new Comment("DevGuy", "Very clear explanation."));
        v2.AddComment(new Comment("Liam", "Thanks, helped a lot!"));
        v2.AddComment(new Comment("Anna", "Awesome."));
        videos.Add(v2);

        Video v3 = new Video("Top 10 Travel Destinations", "WanderWorld", 600);
        v3.AddComment(new Comment("Tina", "Adding these to my list."));
        v3.AddComment(new Comment("Sam", "Loved this!"));
        v3.AddComment(new Comment("Ty", "Great picks."));
        videos.Add(v3);

        foreach (Video v in videos)
        {
            Console.WriteLine($"{v.GetTitle()} by {v.GetAuthor()}");
            Console.WriteLine($"Length: {v.GetLength()} seconds");
            Console.WriteLine($"Comments ({v.GetCommentCount()}):");

            foreach (Comment c in v.GetComments())
            {
                Console.WriteLine($"- {c.GetName()}: {c.GetText()}");
            }

            Console.WriteLine();
        }
    }
}
