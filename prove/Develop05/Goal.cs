public abstract class Goal{
    protected string _text;
    protected bool _remove;
    protected int _points;


    public abstract int CompleteGoal();

    public abstract string ListGoal();

    public abstract Dictionary<string, string> ToData();
    
    public bool DoRemove(){
        return _remove;
    }

    protected void SetData(string goalName){
        Console.Write($"What is the new {goalName}? ");
        _text = Console.ReadLine();

        while (true){
            Console.Write("How many points is the goal worth? ");

            if (int.TryParse(Console.ReadLine(), out int points)){
                if (points <= 0){
                    Console.WriteLine("> To few points");
                    continue;
                }

                _points = points;
                break;
            }

            Console.WriteLine("> Must enter an integer value");
        }

        _remove = false;
    }
}