class Program
{
    static void Main(string[] args)
    {
        Address address = new Address("789 Center St", "Denver", "CO", "USA");

        Event lecture = new Lecture(
            "Tech Talk",
            "Future of AI",
            "April 10, 2025",
            "6:00 PM",
            address,
            "Dr. Smith",
            200);

        Event reception = new Reception(
            "Company Mixer",
            "Networking event",
            "May 5, 2025",
            "7:00 PM",
            address,
            "rsvp@company.com");

        Event outdoor = new OutdoorGathering(
            "Community Picnic",
            "Family-friendly event",
            "June 1, 2025",
            "12:00 PM",
            address,
            "Sunny");

        List<Event> events = new List<Event> { lecture, reception, outdoor };

        foreach (Event e in events)
        {
            Console.WriteLine(e.GetStandardDetails());
            Console.WriteLine();
            Console.WriteLine(e.GetFullDetails());
            Console.WriteLine();
            Console.WriteLine(e.GetShortDescription());
            Console.WriteLine("\n------------------\n");
        }
    }
}
