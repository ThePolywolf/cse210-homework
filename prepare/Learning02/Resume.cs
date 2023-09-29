class Resume
{
    public string _name;
    public List<Job> _jobs;

    // constructor
    public Resume(string name)
    {
        _name = name;
        _jobs = new List<Job>();
    }

    // adds a job to resume allowing method chaining
    public Resume AddJob(Job job)
    {
        _jobs.Add(job);
        return this;
    }

    // writes the resume to the console
    public void WriteResume(bool format = true)
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");

        // 
        foreach (Job job in _jobs)
        {
            job.WriteJob(">>> ", format);
        }
    }
}