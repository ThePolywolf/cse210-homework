// for serializing and saving data to a json
class UserData{
    private Progression _progression;
    private List<Goal> _goals;
    public UserData(Progression progression, List<Goal> goals){
        _progression = progression;
        _goals = goals;
    }

    public UserData(Dictionary<string, Dictionary<string, string>> data){
        Progression progression = new Progression(data["progression"]);
        List<Goal> goals = new List<Goal>();

        data.Remove("progression");

        foreach (KeyValuePair<string, Dictionary<string, string>> kvp in data){
            Goal newGoal = Goal.FromData(kvp.Value);
            goals.Add(newGoal);
        }

        _progression = progression;
        _goals = goals;
    }

    public Progression Progression(){
        return _progression;
    }

    public List<Goal> Goals(){
        return _goals;
    }

    public Dictionary<string, Dictionary<string, string>> ToData(){
        Dictionary<string, Dictionary<string, string>> data = new Dictionary<string, Dictionary<string, string>>();

        // progression data
        data["progression"] = _progression.ToData();

        // goal data
        int i = 0;
        foreach (Goal goal in _goals){
            data[$"{i}"] = goal.ToData();
            i++;
        }

        return data;
    }
}