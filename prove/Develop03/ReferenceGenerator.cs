class ReferenceGenerator
{
    private List<CompleteReference> _references;

    public ReferenceGenerator()
    {
        _references = new List<CompleteReference>();
    }

    public ReferenceGenerator AddReference(CompleteReference reference)
    {
        _references.Add(reference);

        return this;
    }

    public ReferenceGenerator AddReference(Reference reference, Scripture scripture)
    {
        _references.Add(new CompleteReference(reference, scripture));

        return this;
    }

    public CompleteReference RandomReference()
    {
        Random random = new Random();

        return _references[random.Next(_references.Count)];
    }
}