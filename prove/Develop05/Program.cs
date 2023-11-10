using System;

class Program
{
    public enum Page{
        User,
        Goals,
        Quit
    }

    private static Progression progression;
    private static List<Goal> goals;

    static void Main(string[] args)
    {
        Page page = Page.User;

        while (true){
            FileManager.SaveData(new UserData(progression, goals));

            Console.Clear();

            if (page == Page.User){
                page = SelectUser();
            }

            else if (page == Page.Goals){
                WriteProgress();
                page = SelectGoal();
            }

            else if (page == Page.Quit){
                break;
            }

            else{
                Console.WriteLine("Unknown Page");
                page = Page.User;
            }
        }

        Console.Clear();
        Console.WriteLine("Program Quit");
    }

    static Page SelectUser(){
        List<string> users = FileManager.AllUsers();
        if (users.Count <= 0){
            FileManager.NewUser();
            return Page.Goals;
        }

        // options
        Console.WriteLine("Users: ");
        foreach (string user in users){
            Console.WriteLine($" - {user}");
        }
        Console.WriteLine("\n + New User");
        Console.WriteLine(" q Quit Program\n");

        // user input
        while (true){
            Console.Write("Selection: ");
            string response = Console.ReadLine();

            UserData newData;

            if (response == "+"){
                newData = FileManager.NewUser();
                progression = newData.Progression();
                goals = newData.Goals();

                return Page.Goals;
            }

            if (response == "q"){
                return Page.Quit;
            }

            newData = FileManager.LoadUser(response);
            if (newData != null){
                progression = newData.Progression();
                goals = newData.Goals();

                return Page.Goals;
            }

            Console.WriteLine($"> {response} is not a valid selection");
        }
    }

    static Page SelectGoal(){
        if (goals.Count <= 0){
            goals.Add(Goal.NewGoal());
            return Page.Goals;
        }

        int i = 0;
        Console.WriteLine("Goals:");
        foreach (Goal goal in goals){
            i++;
            Console.WriteLine($" {i} - {goal.ListGoal()}");
        }
        Console.WriteLine("\n + New Goal");
        Console.WriteLine(" b Back to User Selection");
        Console.WriteLine(" q Quit Program");

        while (true){
            Console.Write("Selection: ");
            string response = Console.ReadLine();

            if (response == "+"){
                Goal newGoal = Goal.NewGoal();
                goals.Add(newGoal);

                return Page.Goals;
            }

            if (response == "b"){
                return Page.User;
            }

            if (response == "q"){
                return Page.Quit;
            }

            if (!int.TryParse(response, out int selection)){
                Console.WriteLine("> Must enter a number of '+'");
                continue;
            }

            Goal goal;
            try {
                goal = goals[selection - 1];
            }
            catch {
                Console.WriteLine("> Invalid selection (outside of range)");
                continue;
            }

            int points = goal.CompleteGoal();
            if (points > 0){
                progression.AddPoints(points);
                progression.IncrementGoals();
            }

            if (goal.DoRemove()){
                goals.RemoveAt(selection - 1);
            }

            return Page.Goals;
        }
    }

    public static void WriteProgress(){
        Console.WriteLine($"Points: {progression.Points()} (x{progression.Level()} multiplier)");

        int totalGoals = progression.CompletedGoals();
        int goalProgress = progression.GoalProgress();
        int goalsNeeded = progression.GoalsNeeded();
        int completion = (int)Math.Floor(progression.LevelCompletion() * 10);

        string completionBar = "~" + new string('|', completion) + new string('.', 10 - completion) + "~";

        Console.WriteLine($"Level {progression.Level()}: {completionBar} ({goalProgress}/{goalsNeeded}, {totalGoals} Goals)\n");
    }
}