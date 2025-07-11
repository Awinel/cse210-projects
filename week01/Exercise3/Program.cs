using System;

class Program
{
    static void Main(string[] args)
    {
        int guesses = 0;
        int guessNumber;
        string play = "yes";

        while (play == "yes")
        {

            Console.WriteLine("Welcome to the Guessing Game!");
            Console.WriteLine("I have selected a number between 1 and 10. Can you guess what it is?");
            Random number = new Random();
            int magicNumber = number.Next(1, 11);

            do
            {
                Console.Write("What is your guess? ");
                string guess = Console.ReadLine();
                guessNumber = int.Parse(guess);
                if (guessNumber > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else if (guessNumber < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }

                guesses++;

            } while (guessNumber != magicNumber);
            Console.WriteLine($"You guessed the number {magicNumber} in {guesses} tries.");
            Console.WriteLine("Thanks for playing!");

            Console.Write("Would you like to play again? (yes/no) ");
            play = Console.ReadLine();
        }
    }
}