// should be fine im using static since its not the main point of the assignment
using System.Text.Json;

class FileManager{
    private static string _filePath = "users/";
    private static string _username;

    // checks if the file name exists
    public static bool FileExists(string fileName)
    {
        string path = _filePath + fileName + ".json";
        return File.Exists(path);
    }

    public static List<string> AllUsers(){
        List<string> fileNames = Directory.GetFiles(_filePath, "*.json").ToList<string>();

        // make sure each string is just the file name
        for (int i = 0; i < fileNames.Count; i++)
        {
            string fileName = fileNames[i];

            // remove folder name
            fileName = fileName.Replace(_filePath, "");

            // remove .json
            fileName = fileName.Replace(".json", "");

            // replace string
            fileNames[i] = fileName;
        }

        return fileNames;
    }

    public static UserData LoadUser(string username){
        // can't open journal if it doesn't exist
        if (!FileExists(username))
        {
            return null;
        }

        // open the journal
        _username = username;
        string path = _filePath + _username + ".json";

        string jsonContent = File.ReadAllText(path);
        Dictionary<string, Dictionary<string, string>> data = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(jsonContent);

        return new UserData(data);
    }

    public static UserData NewUser(){
        Console.Write("New Username: ");
        string newUsername = Console.ReadLine();

        _username = newUsername;

        // initialize user save file
        Progression progression = new Progression();
        List<Goal> goals = new List<Goal>();
        UserData newData = new UserData(progression, goals);

        SaveData(newData);

        return new UserData(progression, goals);
    }

    // saves all data to json
    public static bool SaveData(UserData userData){
        // can only load user if we have one selected
        if (_username == null){
            return false;
        }

        // write to JSON
        string path = _filePath + _username + ".json";
        Dictionary<string, Dictionary<string, string>> data = userData.ToData();

        string jsonContent = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });

        File.WriteAllText(path, jsonContent);

        return true;
    }
}