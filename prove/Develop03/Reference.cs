class Reference
{
    private string _document;
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;


    public Reference(string document, string book, int chapter, int verse)
    {
        _document = document;
        _book = book;
        _chapter = chapter;
        _startVerse = verse;
        _endVerse = 0;
    }

    public Reference(string document, string book, int chapter, int startVerse, int endVerse)
    {
        _document = document;
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;

        if (startVerse <= endVerse)
        {
            _endVerse = 0;
        }
    }

    public override string ToString()
    {
        string result;

        if (_startVerse > _endVerse)
        {
            result = $"({_document}) {_book} {_chapter}:{_startVerse}.";
        }
        else
        {
            result = $"({_document}) {_book} {_chapter}:{_startVerse}-{_endVerse}.";
        }

        return result;
    }
}