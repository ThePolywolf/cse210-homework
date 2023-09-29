using System;
using System.Net;
using GuessingGame;

class Program
{
    static void Main(string[] args)
    {
        // repeating game while running
        bool running = true;

        do
        {
            // get random number
            Random random = new Random();
            int chosenNumber = random.Next(1, 101);

            int guess;

            Console.WriteLine("There is a secret number between 1 and 100");

            // tracks guesses taken
            int guessCount = 0;
            int validGuessCount = 0;

            // breaks when guess is correct
            while (true)
            {
                // get guess
                Console.Write("What is your guess? ");
                string response = Console.ReadLine();

                // increments guess count
                guessCount++;

                // try to cast response to int to store in guess
                if (!int.TryParse(response, out guess))
                {
                    Console.WriteLine("> Your Guess must be an integer");
                    continue;
                }

                // valid guess if its a number, increment counter
                validGuessCount++;

                // break if guess is correct
                if (guess == chosenNumber)
                {
                    Console.WriteLine($"Correct! The number was {chosenNumber}!");
                    break;
                }

                // writes guess commentary otherwise
                Game.GuessCommentary(guess, chosenNumber);
            }

            // write how many guesses/attempts it took the player
            if (guessCount == validGuessCount)
            {
                Console.WriteLine($"It took you {guessCount} guesses to guess the secret number:");
            }
            else
            {
                Console.WriteLine($"It took you {guessCount} attempts and {validGuessCount} guesses to guess the secret number:");
            }

            // Writes out how well the player did
            Game.WriteCommentary(validGuessCount);

            // see if playing again
            Console.WriteLine("Play again? (y/n) ");
            string go_again = Console.ReadLine();

            if (go_again == "n" || go_again == "N")
            {
                running = false;
            }
            else
            {
                Console.WriteLine("Starting new game . . .");
            }
        } while (running);

        Console.WriteLine("Thanks for playing (:");
    }
}