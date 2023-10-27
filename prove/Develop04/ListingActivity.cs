class ListingActivity : Activity
{
    private string[] _prompts = new string[] {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base(
        "Listing Activity",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area",
        "I hope you now can apreciate all these good things in your life!"
    )
    {
        return;
    }

    public override void DoActivity()
    {
        base.DoActivity();

        SetDuration("How much time do you want to spend writing your list? ");

        Console.WriteLine("");
        Spinner("Get Ready... ", 4);

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        Console.WriteLine($"\n{RandomPrompt()}");

        List<string> responses = new List<string>();
        while (true)
        {
            string response = Console.ReadLine();
            responses.Add(response);

            if (DateTime.Now >= endTime)
            {
                break;
            }
        }

        Console.WriteLine($"\nTime is up! You gave {responses.Count} responses.\n");
    }

    private string RandomPrompt()
    {
        Random random = new Random();
        return _prompts[random.Next(_prompts.Length)];
    }
}