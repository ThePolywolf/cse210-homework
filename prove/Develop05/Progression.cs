using System.ComponentModel.DataAnnotations;

class Progression{
    private int _points;
    private int _goalsCompleted;

    public Progression(){
        _points = 0;
        _goalsCompleted = 0;
    }

    public Progression(Dictionary<string, string> data){
        _points = int.Parse(data["points"]);
        _goalsCompleted = int.Parse(data["goals"]);
    }

    public int Points(){
        return _points;
    }

    public int CompletedGoals(){
        return _goalsCompleted;
    }

    public int CurrentLevelPoints(){
        int level = Level();

        return level * level;
    }

    public int NextLevelPoints(){
        return InverseLevelFunction(Level() + 1);
    }

    public int GoalProgress(){
        int currentLevel = InverseLevelFunction(Level());

        if (Level() == 1) {
            return _goalsCompleted - currentLevel + 1;
        }

        return Math.Max(_goalsCompleted - currentLevel, 0);
    }

    public double LevelCompletion(){
        return (double)GoalProgress() / (double)GoalsNeeded();
    }

    public int GoalsNeeded(){
        if (Level() == 1){
            return 4;
        }

        return NextLevelPoints() - InverseLevelFunction(Level());
    }

    public int Level(){
        int level = levelFunction(_goalsCompleted);
        return level;
    }

    private int levelFunction(int value){
        return (int)Math.Max(
            1, 
            Math.Ceiling(Math.Sqrt((double)value + 0.01)) - 1
        );
    }

    private int InverseLevelFunction(int value){
        return (int)Math.Max(
            1d,
            value * value
        );
    }

    public void AddPoints(int points){
        _points += points * Level();
    }

    public void IncrementGoals(int number = 1){
        _goalsCompleted += number;
    }

    public Dictionary<string, string> ToData(){
        return new Dictionary<string, string>{
            {"points", $"{_points}"},
            {"goals", $"{_goalsCompleted}"}
        };
    }
}