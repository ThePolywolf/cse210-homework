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

            MemorizeSripture(completeReference);

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

    static public void MemorizeSripture(CompleteReference completeReference)
    {
        // generate references
        Memorizable memorizable = new Memorizable(completeReference);

        while (true)
        {
            Console.Clear();
            Console.WriteLine(memorizable.ToString());

            if (memorizable.IsAllHidden())
            {
                Console.Write($"\nCongrats on learning the scripture! Press ENTER to continue ");
                Console.ReadLine();

                break;
            }
            else
            {
                Console.Write($"\nPress ENTER to hide some words: ");
                Console.ReadLine();

                memorizable.HideWords(3);

            }
        }
    }
}