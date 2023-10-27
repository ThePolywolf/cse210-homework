class YogaActivity : Activity
{
    private int _sequenceLength;
    private string[] _moves = new string[] {
        "Downward Dog - legs and hand on the ground in an upside-down V",
        "Child's Pose - Sit on the floor legs crossed and back straight",
        "Warrior 1 - Body forward with one leg bent and hands together above you",
        "Warrior 2 - Body forward with one leg bent and hand straight out to each side",
        "Tree Pose - Stand on one leg the other bent to the side and hand together above you",
        "Triangle Pose - Legs spread out and body bent to one side, arms reaching apart (one on foot, other on the sky)",
        "Plank Pose - feet together and hands together, keeping your body off the ground",
        "Seated Forward Bend - Sit down with your legs crossed and reach your body forward"
    };

    public YogaActivity(int sequenceLength = 4) : base(
        "Yoga Activity",
        "This activity will help you to release tension, and relax your body.",
        "I hope you now feel felaxed and refreshed!"
    )
    {
        _sequenceLength = sequenceLength;
    }

    public override void DoActivity()
    {
        base.DoActivity();

        SetDuration("How long do you want to do each move for? ");

        Spinner("Get Ready... ", 4);

        Console.WriteLine("");
        
        int currentMove = -1;

        for (int i = 0; i < _sequenceLength; i++)
        {
            currentMove = RandomMove(currentMove);

            Console.WriteLine($"\r{_moves[currentMove]}");
            TimingBar();
        }
    }

    private int RandomMove(int currentMove)
    {
        Random random = new Random();
        int move;

        do
        {
            move = random.Next(_moves.Length);
        } while (move == currentMove);

        return move;
    }

    private void TimingBar()
    {
        Console.Write("");

        for (int progress = 1; progress < _duration + 1; progress++)
        {
            Console.Write("\r[" + new string('-', progress) + new string(' ', _duration - progress) + "]");
            Thread.Sleep(1000);
        }
    }
}