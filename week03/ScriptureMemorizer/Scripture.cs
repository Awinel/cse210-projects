using System;
using System.Collections.Generic;
using System.Linq;

class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        string[] wordArray = text.Split(' ');

        foreach (string word in wordArray)
        {
            _words.Add(new Word(word));
        }
    }

    // This should return the reference + all words (hidden or visible)
    public string GetDisplayText()
    {
        string result = _reference.GetDisplayText();
        foreach (Word word in _words)
        {
            result += " " + word.GetDisplayText();
        }
        return result;
    }

    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();

        for (int i = 0; i < numberToHide; i++)
        {
            
            int randomIndex = random.Next(_words.Count);
            _words[randomIndex].Hide();
        }
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false; 
            }
        }
        return true;
    }


}