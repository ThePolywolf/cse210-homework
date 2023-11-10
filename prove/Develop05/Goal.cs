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

    public static Goal FromData(Dictionary<string, string> data){
        string id = data["id"];

        if (id == "eternal"){
            return new EternalGoal(data);
        }

        if (id == "checklist"){
            return new ChecklistGoal(data);
        }

        if (id == "simple"){
            return new SimpleGoal(data);
        }

        Console.WriteLine("!!! Null id type");
        return null;
    }

    public static Goal NewGoal(){
        List<string> types = new List<string>{
            "Simple",
            "Eternal",
            "Checklist"
        };

        int i = 0;
        Console.WriteLine("New Goal:");
        foreach (string type in types){
            i++;
            Console.WriteLine($" {i} - {type}");
        }

        while (true){
            Console.Write("\nSelection: ");
            string response = Console.ReadLine();

            if (!int.TryParse(response, out int selection)){
                Console.WriteLine("> Must enter a number");
                continue;
            }

            if (selection == 1){
                return new SimpleGoal();
            }

            if (selection == 2){
                return new EternalGoal();
            }

            if (selection == 3){
                return new ChecklistGoal();
            }

            Console.WriteLine("> Enter a valid selection");
        }
    }
}