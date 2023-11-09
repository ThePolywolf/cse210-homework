using System;

class Program
{
    static void Main(string[] args)
    {
        ReferenceScraper referenceScraper = new ReferenceScraper();

        while (true)
        {
            referenceScraper.ScrapeReference();
            CompleteReference completeReference = referenceScraper.Reference();

            Memorizable memorizable = new Memorizable(completeReference);
            memorizable.Memorize(3);

            Console.Write($"\nDo you want to memorize another scripture? (y/n) ");
            string response = Console.ReadLine();

            if (response == "y")
            {
                continue;
            }

            Dictionary<string, string> someDict = new Dictionary<string, string>();

            break;
        }
    }
}