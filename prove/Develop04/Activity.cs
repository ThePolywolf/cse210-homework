using System.Threading;

class Activity
{
    private string _activityName;
    private string _introMessage;
    private string _outroMessage;
    protected int _duration;
    
    private string[] _spinnerAnimation = new string[] {
        "|",
        "/",
        "-",
        "\\"
    };

    public Activity(string activityName, string introMessage, string outroMessage)
    {
        _activityName = activityName;
        _introMessage = introMessage;
        _outroMessage = outroMessage;
    }

    protected void SetDuration(string message)
    {
        Console.Write(message);
        while (true)
        {
            string response = Console.ReadLine();

            if (int.TryParse(response, out int duration))
            {
                _duration = duration;
                return;
            }

            Console.WriteLine("> Response must be an integer number");
        }
    }

    public virtual void DoActivity()
    {
        Console.Clear();

        Spinner($"Welcome to the {_activityName} ", 1.5f);
        
        Console.WriteLine($"\n{_introMessage}");

        Spinner("", 3.5f);
    }

    public virtual void EndActivity()
    {
        Spinner(_outroMessage);
    }

    protected void Spinner(string message, float waitTime = 1f)
    {
        Console.Write("");

        for (int progress = 0; progress < waitTime * 8; progress++)
        {
            string spinner = _spinnerAnimation[progress % 4];

            Console.Write($"\r{message} {spinner}");

            // wait 1/8 of a second
            Thread.Sleep(125);
        }

        Console.WriteLine($"\r{message}  ");
    }
}