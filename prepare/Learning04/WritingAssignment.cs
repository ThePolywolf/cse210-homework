class WritingAssignment : Assignment
{
    private string _title;

    public WritingAssignment(string studentName, string topic, string title) : base(studentName, topic)
    {
        _title = title;
    }

    public string GetWritingInformation()
    {
        // I know I could just return _title by itself but made it this for expandability later (:
        return $"{_title}";
    }
}