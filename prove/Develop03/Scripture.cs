class Scripture
{
    private string _verse;

    public Scripture(string verse)
    {
        _verse = verse;
    }

    public override string ToString()
    {
        return _verse;
    }
}