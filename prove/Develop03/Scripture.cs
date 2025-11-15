using System;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;

        _words = text.Split(" ")
                     .Select(w => new Word(w))
                     .ToList();
    }

    public void Display()
    {
        Console.WriteLine(_reference.GetDisplayText());
        Console.WriteLine();

        foreach (var word in _words)
        {
            Console.Write(word.GetDisplayText() + " ");
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        Random rnd = new Random();

        for (int i = 0; i < numberToHide; i++)
        {
            int index = rnd.Next(_words.Count);
            _words[index].Hide();  // Basic requirement: may hide already hidden words
        }
    }

    public bool AllWordsHidden()
    {
        return _words.All(w => w.IsHidden());
    }
}
