using System;
using System.Net;

class Program
{
    static void Main(string[] args)
    {
        // Welcome Message
        WelcomeMessage();

        // Prompt name
        string userName = PromptForName();

        // Prompt number
        int favNumber = PrompForNumber();

        // Display results
        Respond(userName, favNumber);
    }

    static void WelcomeMessage()
    {
        Console.WriteLine("Welcome to the C# Program!");
    }

    static string PromptForName()
    {
        Console.Write("What is your name? ");
        return Console.ReadLine();
    }

    static int PrompForNumber()
    {
        while (true)
        {
            Console.Write("What is your favorite integer? ");
            string response = Console.ReadLine();

            if (int.TryParse(response, out int number))
            {
                return number;
            }

            Console.WriteLine($"> {response} isn't an integer.");
        }
    }

    static void Respond(string userName, int favNumber)
    {
        int numberSquared = favNumber * favNumber;

        Console.WriteLine($"Hello {userName}! Your favorite number squared is {numberSquared}.");
    }
}