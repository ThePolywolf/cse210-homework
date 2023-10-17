using System;

class Program
{
    static void Main(string[] args)
    {
        ReferenceGenerator referenceGenerator = new ReferenceGenerator();

        // Create possible references
        referenceGenerator.AddReference(
            new Reference("Book of Mormon", "1 Nephi", 3, 7),
            new Scripture("I will go and do the things which the Lord hath commanded.")
        ).AddReference(
            new Reference("Book of Mormon", "Alma", 7, 11, 13),
            new Scripture("And he shall go forth, suffering pains and afflictions and temptations of every kind.")
        ).AddReference(
            new Reference("New Testemant", "Luke", 24, 36, 39),
            new Scripture("For a spirit hath not flesh and bones, as ye see me have.")
        ).AddReference(
            new Reference("Old Testemant", "Psalm", 24, 3, 4),
            new Scripture("Who shall stand in his holy place? He that hath clean hands, and a pure heart.")
        ).AddReference(
            new Reference("D&C", "Section", 88, 118),
            new Scripture("Seek learning, even by study and also by faith.")
        );

        while (true)
        {
            CompleteReference completeReference = referenceGenerator.RandomReference();

            MemorizeSripture(completeReference);

            Console.Write($"\nDo you want to memorize another scripture? (y/n) ");
            string response = Console.ReadLine();

            if (response == "y")
            {
                continue;
            }

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