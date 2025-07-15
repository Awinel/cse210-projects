using System;

public class Program
{
    public static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGen = new PromptGenerator();
        MotivationalQuote quoteGen = new MotivationalQuote();
        bool running = true;

        // Display welcome message with motivational quote
        Console.WriteLine("Welcome to your Journal!");
        Console.WriteLine();
        Console.WriteLine(quoteGen.GetRandomQuote());
        Console.WriteLine();

        while (running)
        {
            Console.WriteLine("\nPlease choose an option:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display all entries");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Exit");
            Console.Write("Choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteNewEntry(journal, promptGen);
                    break;
                case "2":
                    journal.DisplayAll();
                    break;
                case "3":
                    Console.Write("Enter filename to save: ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    break;
                case "4":
                    Console.Write("Enter filename to load: ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    break;
                case "5":
                    running = false;
                    Console.WriteLine("Thank you for using your journal!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    private static void WriteNewEntry(Journal journal, PromptGenerator promptGen)
    {
        string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
        string prompt = promptGen.GetRandomPrompt();
        
        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Your response: ");
        string entryText = Console.ReadLine();

        Entry newEntry = new Entry(currentDate, prompt, entryText);
        journal.AddEntry(newEntry);
        
        Console.WriteLine("Entry added successfully!");
    }
}