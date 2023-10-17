class Word
{
    private string _word;

    public Word(string word)
    {
        _word = word;
    }

    public string AsWord()
    {
        return $" {_word}";
    }

    public string AsBlank()
    {
        string blank = new string('_', _word.Length);

        return $" {blank}";
    }

    public static List<Word> DissemblePhrase(string phrase)
    {
        string[] rawWords = phrase.Split(" ");

        List<Word> result = new List<Word>();

        foreach (string rawWord in rawWords)
        {
            // skip empty strings
            if (rawWord.Length < 1)
            {
                continue;
            }

            Word word = new Word(rawWord);
            result.Add(word);
        }

        return result;
    }

    public static List<Word> DissembleScripture(Scripture scripture)
    {
        return DissemblePhrase(scripture.ToString());
    }
}