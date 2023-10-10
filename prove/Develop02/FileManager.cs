using System;
using System.IO;

class FileManager
{
    public const string journalFolder = "Journals/";
    public static string journalPath;
    public static string journal;

    public static string journalName { get { return journalPath; } }

    // checks if the file name exists
    public static bool FileExists(string fileName)
    {
        string path = journalFolder + fileName + ".json";
        return File.Exists(path);
    }

    // creates empty json file
    public static void CreateJournal(string journalName)
    {
        // replace journal contents
        journal = "";

        string path = journalFolder + journalName;

        // create file if it doesn't exist already
        if (!FileExists(journalName))
        {
            journalPath = journalName;
            path = path + ".json";
            File.WriteAllText(path, "");

            return;
        }

        // auto increment name until file doesn't exist
        int i = 0;
        while (true)
        {
            i++;

            if (FileExists(journalName + i.ToString()))
            {
                break;
            }
        }

        journalPath = journalName + i.ToString();
        path = path + i.ToString() + ".json";
        File.WriteAllText(path, "");
    }

    // gets all journal names
    public static List<string> GetAllJournals()
    {
        List<string> fileNames = Directory.GetFiles(journalFolder, "*.json").ToList<string>();

        // make sure each string is just the file name
        for (int i = 0; i < fileNames.Count; i++)
        {
            string fileName = fileNames[i];

            // remove folder name
            fileName = fileName.Replace(journalFolder, "");

            // remove .json
            fileName = fileName.Replace(".json", "");

            // replace string
            fileNames[i] = fileName;
        }

        return fileNames;
    }

    // opens specified journal
    public static void OpenJournal(string journalName)
    {
        // can't open journal if it doesn't exist
        if (!FileExists(journalName))
        {
            return;
        }

        // open the journal
        journalPath = journalName;

        string path = journalFolder + journalPath + ".json";
        journal = File.ReadAllText(path);
    }

    public static void SaveEntry(Entry newEntry)
    {
        // Dict will contain (Date: , Prompt: , and Text: )
        // save all of them as a single string
        string entry = $"\nDate: {newEntry.EntryDate} - Prompt: {newEntry.Prompt}\n";
        entry += $"{newEntry.Text}\n";

        // add string to the end of journal
        journal += entry;

        // saves journal to file
        string path = journalFolder + journalPath + ".json";
        File.WriteAllText(path, journal);
    }
}