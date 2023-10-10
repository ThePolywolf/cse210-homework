using System;

class Entry
{
    public string EntryDate;
    public string Prompt;
    public string Text;

    public Entry(string _prompt, string _text)
    {
        Prompt = _prompt;
        Text = _text;

        EntryDate = DateOnly.FromDateTime(DateTime.Now).ToString();
    }
}