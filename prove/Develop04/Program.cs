using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Options:\n 1) Breathing\n 2) Reflection\n 3) Lists\n 4) Yoga\nENTER to Quit");
            
            string option = Console.ReadLine();

            // quit on non-integer response
            if (!int.TryParse(option, out int numberSelection))
            {
                break;
            }

            Activity activity;

            if (numberSelection == 1)
            {
                activity = new BreathingActivity();
            }

            else if (numberSelection == 2)
            {
                activity = new ReflectionActivity();
            }

            else if (numberSelection == 3)
            {
                activity = new ListingActivity();
            }

            else if (numberSelection == 4)
            {
                activity = new YogaActivity();
            }
            else
            {
                break;
            }

            activity.DoActivity();
            activity.EndActivity();

            EnterToContinue();
        }
    }

    static void EnterToContinue()
    {
        Console.WriteLine("Press ENTER to continue ");
        Console.ReadLine();
    }
}