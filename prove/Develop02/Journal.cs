using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(string prompt, string response)
    {
        string date = DateTime.Now.ToShortDateString();
        Entry entry = new Entry(date, prompt, response);
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries found.\n");
            return;
        }

        Console.WriteLine("\nYour Journal Entries:\n");
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine(entry.FormatForFile());
            }
        }
        Console.WriteLine("Journal saved successfully!\n");
    }

    public void LoadFromFile(string filename)
    {
        if (File.Exists(filename))
        {
            _entries.Clear();
            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                _entries.Add(Entry.FromFileLine(line));
            }
            Console.WriteLine("Journal loaded successfully!\n");
        }
        else
        {
            Console.WriteLine("File not found.\n");
        }
    }
}
