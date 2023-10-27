class ReflectionActivity : Activity
{
    private int _asks;

    private string[] _prompts = new string[] {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };
    private string[] _questions = new string[] {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity(int asks = 3) : base(
        "Reflection Activity",
        "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.",
        "I hope that you now recognize your own resilience and strength in your life!"
    )
    {
        _asks = asks;
    }

    private string RandomPrompt()
    {
        Random random = new Random();
        return _prompts[random.Next(_prompts.Length)];
    }

    public override void DoActivity()
    {
        base.DoActivity();

        SetDuration("How long do you want to spend thinking per question? ");

        Spinner("Get Ready... ", 4);

        Console.WriteLine($"Think about the following prompt:\n{RandomPrompt()}\n\nPress ENTER when you are ready.");
        Console.ReadLine();

        Console.WriteLine("");

        List<string> questions = new List<string>();
        foreach (string question in _questions)
        {
            questions.Add(question);
        }

        Random random = new Random();

        for (int i = 0; i < _asks; i++)
        {
            int questionNumber = random.Next(questions.Count);
            string question = questions[questionNumber];
            questions.RemoveAt(questionNumber);

            Spinner(question, _duration);
        }

        Console.WriteLine("");
    }
}