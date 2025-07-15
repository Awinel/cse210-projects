using System;
using System.Collections.Generic;

public class MotivationalQuote
{
    private List<string> _quotes;
    private Random random;

    public MotivationalQuote()
    {
        random = new Random();
        _quotes = new List<string>
        {
            "The journey of a thousand miles begins with one step. - Lao Tzu",
            "What lies behind us and what lies before us are tiny matters compared to what lies within us. - Ralph Waldo Emerson",
            "The only way to do great work is to love what you do. - Steve Jobs",
            "Success is not final, failure is not fatal: it is the courage to continue that counts. - Winston Churchill",
            "Believe you can and you're halfway there. - Theodore Roosevelt",
            "The future belongs to those who believe in the beauty of their dreams. - Eleanor Roosevelt",
            "It is during our darkest moments that we must focus to see the light. - Aristotle",
            "Your limitation—it's only your imagination.",
            "Push yourself, because no one else is going to do it for you.",
            "Great things never come from comfort zones.",
            "Dream it. Wish it. Do it.",
            "Success doesn't just find you. You have to go out and get it.",
            "The harder you work for something, the greater you'll feel when you achieve it.",
            "Don't stop when you're tired. Stop when you're done.",
            "Wake up with determination. Go to bed with satisfaction."
        };
    }

    public string GetRandomQuote()
    {
        if (_quotes.Count == 0)
            return "Today is a new day full of possibilities!";
        
        int index = random.Next(_quotes.Count);
        return _quotes[index];
    }
}