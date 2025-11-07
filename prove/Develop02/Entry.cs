using System;

public class Entry
{
    public string _date;
    public string _prompt;
    public string _response;

    public Entry(string date, string prompt, string response)
    {
        _date = date;
        _prompt = prompt;
        _response = response;
    }

    public void Display()
    {
        Console.WriteLine($"{_date} - {_prompt}");
        Console.WriteLine($"{_response}\n");
    }

    public string FormatForFile()
    {
        // Using |~| as a separator unlikely to appear in normal text
        return $"{_date}|~|{_prompt}|~|{_response}";
    }

    public static Entry FromFileLine(string line)
    {
        string[] parts = line.Split("|~|");
        return new Entry(parts[0], parts[1], parts[2]);
    }
}
