class CompleteReference
{
    private Reference _reference;
    private Scripture _scripture;

    public CompleteReference(Reference reference, Scripture scripture)
    {
        _reference = reference;
        _scripture = scripture;
    }

    public Reference Reference()
    {
        return _reference;
    }

    public Scripture Scripture()
    {
        return _scripture;
    }
}