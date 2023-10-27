class BreathingActivity : Activity
{
    private int _cycles;

    public BreathingActivity(int cycles = 6) : base(
        "Breathing Activity",
        "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.",
        "I hope that you feel relaxed from this breathing exercise!"
    )
    {
        _cycles = cycles;
    }

    public override void DoActivity()
    {
        base.DoActivity();

        SetDuration("How long do you want to breathe for each phase? ");

        Spinner("Get Ready... ", 4);

        Console.Write("\n");

        for (int cycle = 0; cycle < _cycles; cycle++)
        {
            for (int stage = 0; stage < 3; stage++)
            {
                string phrase = "";

                switch (stage) {
                    case 0:
                        phrase += "Breathe In ";
                        break;
                    case 1:
                        phrase += "Hold       ";
                        break;
                    case 2:
                        phrase += "Breathe Out";
                        break;
                }

                for (int progress = 0; progress < _duration; progress++)
                {
                    int totalProgress = progress + (stage * _duration);
                    string timing = TimingBar(totalProgress + 1);

                    Console.Write($"\r{phrase} {timing}");

                    Thread.Sleep(1000);
                }
            }
        }

        Console.WriteLine("\n");
    }

    private string TimingBar(int progress)
    {
        char primaryChar;
        char secondaryChar;

        if (progress < _duration)
        {
            // Breathe In   [---     ]
            primaryChar = '-';
            secondaryChar = ' ';
        }

        else if (progress < _duration * 2)
        {
            progress -= _duration;

            // Hold         [====----]
            primaryChar = '=';
            secondaryChar = '-';
        }

        else if (progress < _duration * 3)
        {
            progress = _duration * 3 - progress;

            // Breathe Out  [=====   ]
            primaryChar = '=';
            secondaryChar = ' ';
        }
        else
        {
            // empty [       ]
            return "[" + new string(' ', _duration) + "]";
        }

        return "[" + new string(primaryChar, progress) + new string(secondaryChar, _duration - progress) + "]";
    }
}