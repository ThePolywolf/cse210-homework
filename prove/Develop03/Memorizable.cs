using System.Diagnostics;

class Memorizable
{
    private Reference _reference;
    private List<Word> _words;
    private List<bool> _hidden;

    public override string ToString()
    {
        string result = _reference.ToString();

        for (int i = 0; i < _hidden.Count; i++)
        {
            bool isHidden = _hidden[i];
            Word word = _words[i];

            if (isHidden)
            {
                result += word.AsBlank();
            }
            else
            {
                result += word.AsWord();
            }
        }

        return result;
    }

    public bool IsAllHidden()
    {
        foreach (bool isHidden in _hidden)
        {
            if (!isHidden)
            {
                return false;
            }
        }

        return true;
    }

    public void HideWords(int number)
    {
        List<int> choices = new List<int>();

        // Add hidable indexes to a list
        for (int i = 0; i < _hidden.Count; i++)
        {
            // find falses (not already hidden)
            if (_hidden[i])
            {
                continue;
            }

            // add index to array
            choices.Add(i);
        }

        // set all to true if less the number
        if (choices.Count <= number)
        {
            Debug.WriteLine("Hiding Remaining Choices");

            foreach (int index in choices)
            {
                _hidden[index] = true;
            }

            return;
        }

        // else hide (number) words (set _hidden[index] to true)
        Random random = new Random();

        for (int i = 0; i < number; i++)
        {
            int selection = random.Next(choices.Count);
            int index = choices[selection];

            _hidden[index] = true;

            choices.RemoveAt(selection);
        }
    }

    public Memorizable(CompleteReference completeReference)
    {
        _reference = completeReference.Reference();
        _words = Word.DissembleScripture(completeReference.Scripture());

        _hidden = new List<bool>();

        for (int i = 0; i < _words.Count; i++)
        {
            _hidden.Add(false);
        }
    }

    public Memorizable(Reference reference, string scripture)
    {
        _reference = reference;
        _words = Word.DissemblePhrase(scripture);

        _hidden = new List<bool>();

        for (int i = 0; i < _words.Count; i++)
        {
            _hidden.Add(false);
        }
    }
}