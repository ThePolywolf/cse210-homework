using System;

class Program
{
    static void Main(string[] args)
    {
        // initialize resume
        Resume resume = new Resume("Devon Miller");
        
        // intialize jobs
        Job job1 = new Job(
            "Junior Software Developer", 
            "Intel", 
            2011, 
            2018
        );
        
        Job job2 = new Job(
            "Senior Software Developer", 
            "Microsoft", 
            2018, 
            2020
        );

        Job job3 = new Job(
            "Chief Technical Officer",
            "Microsoft",
            2020
        );

        // add jobs
        resume.AddJob(job1).AddJob(job2).AddJob(job3);

        // write resume to console
        resume.WriteResume(true);
    }
}