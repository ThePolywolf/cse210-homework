using System.Net;
using HtmlAgilityPack;

class ReferenceScraper
{
    private CompleteReference _reference;

    public void ScrapeReference()
    {
        string documentName = "Book of Mormon";
        string BOMLink = "https://www.gutenberg.org/cache/epub/17/pg17-images.html";

        HtmlWeb web = new HtmlWeb();
        HtmlDocument document = web.Load(BOMLink);

        Random random = new Random();

        // choose a book
        HtmlNodeCollection books = document.DocumentNode.SelectNodes("//div[contains(@class, 'chapter')]");
        HtmlNode book = books[random.Next(books.Count)];

        // get book name
        HtmlNodeCollection h3Tags = book.SelectNodes(".//h2");
        string bookName = h3Tags[0].InnerText;

        // choose a verse
        HtmlNodeCollection verses = book.SelectNodes(".//p");
        // first <p> tag is book heading text
        HtmlNode verseHtml = verses[random.Next(verses.Count - 1) + 1];

        // break verse into its chapter and number
        string verse = verseHtml.InnerText;
        verse = verse.Replace("\n", " ").Replace("\r", " ");
        // remove two spaces in front
        verse = verse.Substring(2);
        // verse structure:
        // 1:10 And he also....
        // chapter:verseNumber verse here... 
        string[] dissembledVerse = verse.Split(" ");
        string referenceString = dissembledVerse[0];
        string[] referenceData = referenceString.Split(":");

        int chapterNumber = int.Parse(referenceData[0]);
        int verseNumber = int.Parse(referenceData[1]);

        // reconstruct verse without numbers at beginning
        string ressembledVerse = "";
        for (int i = 1; i < dissembledVerse.Length; i++)
        {
            ressembledVerse += $"{dissembledVerse[i]} ";
        }

        // create complete reference
        Reference reference = new Reference(documentName, bookName, chapterNumber, verseNumber);
        Scripture scripture = new Scripture(ressembledVerse);
        CompleteReference completeReference = new CompleteReference(reference, scripture);

        // save complete reference
        _reference = completeReference;
    }


    public CompleteReference Reference()
    {
        return _reference;
    }
}