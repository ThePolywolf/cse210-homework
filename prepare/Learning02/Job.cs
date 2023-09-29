class Job
{
    const int COLUMN_WIDTH = 42;
    public string _jobTitle;
    public string _company;
    public int _startDate;
    public int _endDate;

    // Constructor
    public Job(string jobTitle, string company, int startDate, int endDate = 0)
    {
        _jobTitle = jobTitle;
        _company = company;
        _startDate = startDate;
        _endDate = endDate;
    }

    // chooses which way to write the job to console
    public void WriteJob(string prefix = "", bool format = true)
    {
        if (format)
        {
            FormatWriteJob(prefix);
            return;
        }

        BasicWriteJob(prefix);
    }

    // writes job to console
    public void BasicWriteJob(string prefix = "")
    {
        // checks if end date is until current date
        string endDateString = $"{_endDate}";
        if (_endDate == 0)
        {
            endDateString = "Current";
        }

        Console.WriteLine($"{_jobTitle} ({_company}) {_startDate}-{endDateString}");
    }

    // writes job to console with pretty formatting
    public void FormatWriteJob(string prefix = "")
    {
        // checks if end date is until current date
        string endDateString = $"{_endDate}";
        if (_endDate == 0)
        {
            endDateString = "Current";
        }
        
        // creates columns to line up dates
        string beginningString = $"{prefix}{_jobTitle} ({_company})";
        string spacer = "";

        if (beginningString.Length < COLUMN_WIDTH)
        {
            spacer = new string(' ', COLUMN_WIDTH - beginningString.Length);
        }

        string date = $"{_startDate}-{endDateString}";

        // writes line to console
        Console.WriteLine($"{beginningString}{spacer} | {date}");
    }
}