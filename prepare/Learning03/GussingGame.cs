using System;

namespace GuessingGame
{
    class Game
    {
        // writes guess commentary
        public static void GuessCommentary(int guess, int chosenNumber)
        {
            // see if guess is out of range
            if (guess < 1 || guess > 100)
            {
                Console.WriteLine("> The secret number is between 1 and 100");
                return;
            }

            // check if larger than guess
            if (chosenNumber > guess)
            {
                Console.WriteLine($"> Secret number is larger than {guess}");
                return;
            }

            // check if smaller than guess
            if (chosenNumber < guess)
            {
                Console.WriteLine($"> Secret number is smaller than {guess}");
                return;
            }

            // something has gone wrong if the code get to this point
            Console.WriteLine($"> {guess} seems to be an unhandled edge case. My bad.");
        }

        // writes post-game commentary
        public static void WriteCommentary(int totalGuesses)
        {
            // if each guess removes half the possibilities, then it should take the player 7
            // guesses max to guess the number (2^7 = 128, 128 > 100)
            if (totalGuesses == 1)
            {
                Console.WriteLine("Are you a GOD! How did you guess it in 1 attempt?!?!");
                return;
            }
            
            if (totalGuesses <= 4)
            {
                Console.WriteLine("Very well done! You did much better than the average player (:");
                return;
            }
            
            if (totalGuesses <= 7)
            {
                Console.WriteLine("Good Job!");
                return;
            }
            
            Console.WriteLine("Glad you figured it out, you really seemed to struggle with that one!");
        }
    }
}