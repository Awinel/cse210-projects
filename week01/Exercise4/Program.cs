using System;

using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {


        string inputNumber;
        int input;
        int sum = 0;
        float average = 0;
        int max = 0;
        List<int> numbers = new List<int>();
        do
        {
            Console.Write("Enter a list of numbers, type 0 when finished: ");
            inputNumber = Console.ReadLine();
            input = int.Parse(inputNumber);
            if (input != 0)
            {
                numbers.Add(input);
            }
        } while (inputNumber != "0");

        foreach (int number in numbers)
        {
            sum += number;
            if (number > max)
            {
                max = number;
            }
        }

        if (numbers.Count > 0)
        {
            average = ((float)sum) / numbers.Count;
        }

        Console.WriteLine($"The sum is {sum}");
        Console.WriteLine($"The average is {average}");
        Console.WriteLine($"The larger number is {max}");




    }
}