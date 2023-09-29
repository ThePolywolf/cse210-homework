using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        // get numerical grade
        int numberGrade;

        while (true)
        {
            Console.Write("What is your current number grade? ");
            string response = Console.ReadLine();

            // make sure an integer grade was submitted
            if (!int.TryParse(response, out numberGrade))
            {
                Console.WriteLine(">>> You must enter an integer");
                continue;
            }

            // else break
            break;
        }

        // isolates ones place digit
        float onesDigit = numberGrade - MathF.Floor(numberGrade / 10) * 10;
        
        // gets letter sign
        string letterSign = "";

        if (onesDigit < 3)
        {
            letterSign = "-";
        }
        else if (onesDigit >= 7)
        {
            letterSign = "+";
        }

        // disaalow A+/F-/F+
        if (numberGrade >= 97 || numberGrade < 60)
        {
            letterSign = "";
        }

        // get letter grade
        string letterGrade = "F";

        if (numberGrade >= 90)
        {
            letterGrade = "A";
        }
        else if (numberGrade >= 80)
        {
            letterGrade = "B";
        }
        else if (numberGrade >= 70)
        {
            letterGrade = "C";
        }
        else if (numberGrade >= 60)
        {
            letterGrade = "D";
        }

        // write out letter grade
        Console.WriteLine($"At {numberGrade}%, your letter grade is: {letterGrade}{letterSign}");

        if (numberGrade >= 70)
        {
            Console.WriteLine("You are currently passing the course!");
        }
        else
        {
            int neededPoints = 70 - numberGrade;
            Console.WriteLine("You are not currently passing the course:");
            Console.WriteLine($"With a minimum score of 70 required, you need {neededPoints} more points to pass this course.");
        }
    }
}