public class EternalGoal : Goal{
    public EternalGoal() {
        SetData("Eternal Goal");
    }

    public EternalGoal(Dictionary<string, string> data){
        _text = data["text"];
        _points = int.Parse(data["points"]);
        _remove = false;
    }

    public override int CompleteGoal()
    {
        return _points;
    }

    public override string ListGoal()
    {
        return $"({_points} pts) " + _text + " (Eternal)";
    }

    public override Dictionary<string, string> ToData()
    {
        return new Dictionary<string, string>{
            {"id", "eternal"},
            {"text", _text},
            {"points", $"{_points}"}
        };
    }
}