using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private List<string> _prompts;
    private Random random;

    public PromptGenerator()
    {
        random = new Random();
        _prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "Describe something that you would try to improve about yourself.",
        };
    }

    public string GetRandomPrompt()
    {
        if (_prompts.Count == 0)
            return "What's on your mind today?";
        
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}