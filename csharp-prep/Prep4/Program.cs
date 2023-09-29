using System;

class Program
{
    static void Main(string[] args)
    {
        // initialize list
        List<int> allNumbers = new List<int>();

        Console.WriteLine("Enter a list of numbers (integers), then type 0 when finished");

        // breaks on 0
        while (true)
        {
            // get input
            Console.Write("Enter a number: ");
            string response = Console.ReadLine();

            // try to cast to int
            if (!int.TryParse(response, out int integer))
            {
                Console.WriteLine($">>> {response} is not an integer");
                continue;
            }

            // check if number is 0
            if (integer == 0)
            {
                // make sure at least one number in the list before closing it
                if (allNumbers.Count == 0)
                {
                    Console.WriteLine(">>> There must be at least one number in the set before you close it");
                    continue;
                }

                break;
            }

            // else add it to the list
            allNumbers.Add(integer);
        }

        // start calculating values
        float sum = allNumbers.Sum();
        float average = sum / allNumbers.Count();
        float largestNumber = allNumbers.Max();
        
        // get smallest positive
        float smallestPositive = allNumbers[0];

        foreach (int number in allNumbers)
        {
            // smallest positive
            if (MathF.Abs(number) == number && number < smallestPositive)
            {
                smallestPositive = number;
            }
        }

        // sort list
        allNumbers.Sort();

        // write values
        Console.WriteLine($"The Sum of the set is: {sum}");
        Console.WriteLine($"The Average of the set is: {average}");
        Console.WriteLine($"The Largest number in the set is: {largestNumber}");
        
        if (MathF.Abs(smallestPositive) == smallestPositive)
        {
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }
        else
        {
            Console.WriteLine("There are no positive numbers in the set");
        }

        Console.WriteLine("The sorted list is: ");

        foreach (int number in allNumbers)
        {
            Console.WriteLine(number);
        }
    }
}