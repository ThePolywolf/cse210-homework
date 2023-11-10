public class ChecklistGoal : Goal{
    private int _targetCompletions;
    private int _completions;

    public ChecklistGoal() {
        SetData("Eternal Goal");

        while (true){
            Console.Write("How many times deos this goal need to be completed? ");

            if (int.TryParse(Console.ReadLine(), out int target)){
                // require a greater-than-one target value else it should be a simple goal 
                if (target <= 1){
                    Console.WriteLine("> Enter a higher value");
                    continue;
                }
                
                _targetCompletions = target;
                break;
            }

            Console.WriteLine("> Must enter an integer value");
        }

        _completions = 0;
    }

    public ChecklistGoal(Dictionary<string, string> data){
        _text = data["text"];
        _points = int.Parse(data["points"]);
        _targetCompletions = int.Parse(data["target"]);
        _completions = int.Parse(data["completions"]);
        _remove = false;
    }

    public override int CompleteGoal()
    {
        _completions += 1;

        if (_completions >= _targetCompletions){
            _remove = true;
            return _points;
        }

        return 0;
    }

    public override string ListGoal()
    {
        return $"({_points} pts) " + _text + $" ({_completions}/{_targetCompletions})";
    }

    public override Dictionary<string, string> ToData()
    {
        return new Dictionary<string, string>{
            {"id", "checklist"},
            {"text", _text},
            {"points", $"{_points}"},
            {"target", $"{_targetCompletions}"},
            {"completions", $"{_completions}"}
        };
    }
}