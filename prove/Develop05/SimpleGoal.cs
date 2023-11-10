
public class SimpleGoal : Goal{
    public SimpleGoal() {
        SetData("Simple Goal");
    }

    public SimpleGoal(Dictionary<string, string> data){
        _text = data["text"];
        _points = int.Parse(data["points"]);
        _remove = false;
    }

    public override int CompleteGoal()
    {
        _remove = true;
        return _points;
    }

    public override string ListGoal()
    {
        return $"({_points} pts) " + _text;
    }

    public override Dictionary<string, string> ToData()
    {
        return new Dictionary<string, string>{
            {"id", "simple"},
            {"text", _text},
            {"points", $"{_points}"}
        };
    }
}