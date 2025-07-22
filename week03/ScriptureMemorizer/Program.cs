using System;
using System.ComponentModel;

class Program
{
    static void Main(string[] args)
    {

        List<Scripture> scriptureLibrary = new List<Scripture>
        {
            new Scripture(new Reference("John", 3, 16), "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."),
            new Scripture(new Reference("Philippians", 4, 13), "I can do all this through him who gives me strength."),
            new Scripture(new Reference("1 Nephi", 3, 7), "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them."),
            
        };

        Random random = new Random();
        int randomIndex = random.Next(scriptureLibrary.Count);
        Scripture scripture = scriptureLibrary[randomIndex];

        Console.WriteLine($"Today's scripture is: {scripture.GetDisplayText()}");
        Console.WriteLine("Press any key to begin...");
        Console.ReadKey();
        
        
        while (!scripture.IsCompletelyHidden())
        {
            
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            
            // Prompt user
            Console.WriteLine("Press enter to continue or type 'quit' to finish:");
            string input = Console.ReadLine();
            
            // Check if user wants to quit
            if (input.ToLower() == "quit")
            {
                break;
            }
            
            // Hide some random words (try 3 at a time)
            scripture.HideRandomWords(3);
        }
        
        // Final display when all words are hidden
        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nCongratulations! You've completed the scripture!");
    }
}