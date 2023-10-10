using System;
using System.ComponentModel;

class Program
{
    // determines what is running in the main loop
    public enum MenuMode
    {
        Journal,
        Entry,
        Quit
    }

    public static void AddSpacer()
    {
        Console.WriteLine("-------------------");
    }

    // journal mode
    public static MenuMode JournalSelect()
    {
        // clear console
        Console.Clear();
        Console.WriteLine("JOURNALS");
        AddSpacer();

        // auto create new journal if there are none
        if (FileManager.GetAllJournals().Count <= 0)
        {
            NewJournal();
            return MenuMode.Entry;
        }

        // get input
        Console.WriteLine($"Options:\n 1 - New Journal\n 2 - Load Journal\n 3 - Quit");
        Console.Write("Make a selection: ");
        string selection = Console.ReadLine();

        // change by input
        if (selection == "1")   // new Journal
        {
            NewJournal();
            return MenuMode.Entry;
        }
        
        if (selection == "2")   // open journal
        {
            OpenJournal();
            return MenuMode.Entry;
        }

        if (selection == "3")   // quit
        {
            return MenuMode.Quit;
        }

        Console.WriteLine("> Not a recognized command");
        return MenuMode.Journal;
    }

    // make new journal
    public static void NewJournal()
    {
        // clear console
        Console.Clear();
        Console.WriteLine("JOURNALS > NEW");
        AddSpacer();

        // get a new name
        Console.Write("Name your new Journal: ");
        string newName = Console.ReadLine();

        // create the journal
        FileManager.CreateJournal(newName);
    }

    // open pre-existing journal
    public static void OpenJournal()
    {
        // clear console
        Console.Clear();
        Console.WriteLine("JOURNALS > LOAD");
        AddSpacer();

        // display journal list
        Console.WriteLine("All current journals:");

        List<string> allJournals = FileManager.GetAllJournals();
        int count = 0;
        foreach (string journal in allJournals)
        {
            count++;
            Console.WriteLine($" {count.ToString()} - {journal}");
        }

        // get existing journal name
        string journalName;
        do
        {
            Console.Write("What journal are you opening? ");
            journalName = Console.ReadLine();

            // allow numerical input to select journal as well
            if (int.TryParse(journalName, out int journalNumber))
            {
                if (journalNumber != 0 && journalNumber <= allJournals.Count())
                {
                    journalName = allJournals[journalNumber - 1];
                }
            }
        } while (!FileManager.FileExists(journalName));

        // open the file
        FileManager.OpenJournal(journalName);
    }

    // entry menu options
    public static MenuMode EntrySelect()
    {
        // clear console
        Console.Clear();
        Console.WriteLine($"{FileManager.journalName} > ENTRIES");
        AddSpacer();

        // list options
        Console.WriteLine("Options:\n 1 - New Entry\n 2 - Load Entries\n 3 - Switch Journal\n 4 - Quit");
        Console.Write("Make a selection: ");
        string selection = Console.ReadLine();

        // handle cases
        if (selection == "1")
        {
            NewEntry();

            return MenuMode.Entry;
        }

        if (selection == "2")
        {
            LoadEntries();
            
            return MenuMode.Entry;
        }

        if (selection == "3")
        {
            return MenuMode.Journal;
        }

        if (selection == "4")
        {
            return MenuMode.Quit;
        }

        Console.WriteLine("> Not a recognized command");
        return MenuMode.Entry;
    }

    // creates a new entry
    public static void NewEntry()
    {
        // clear console
        Console.Clear();
        Console.WriteLine($"{FileManager.journalName} > ENTRIES > NEW");
        AddSpacer();

        Console.WriteLine("New Entry: ");

        // get prompt
        string prompt = Promptor.GeneratePrompt();
        Console.WriteLine("Prompt: " + prompt);

        // user input
        string userText = Console.ReadLine();

        // create entry object to pass to FileManager
        Entry entry = new Entry(prompt, userText);

        // save entry
        FileManager.SaveEntry(entry);
    }

    // load current entries
    public static void LoadEntries()
    {
        // clear console
        Console.Clear();
        Console.WriteLine($"{FileManager.journalName} > ENTRIES > LOAD");
        AddSpacer();

        // all current entries in a string already
        Console.WriteLine(FileManager.journal);

        // wait for input to continue
        Console.Write("Press ENTER to continue ");
        Console.ReadLine();
    }


    static void Main(string[] args)
    {
        MenuMode menuMode = MenuMode.Journal;

        while (true)
        {
            if (menuMode == MenuMode.Journal)
            {
                menuMode = Program.JournalSelect();
                continue;
            }

            if (menuMode == MenuMode.Entry)
            {
                menuMode = Program.EntrySelect();
                continue;
            }

            if (menuMode == MenuMode.Quit)
            {
                Console.Clear();
                Console.WriteLine("Quitting...");
                break;
            }
        }

        Console.WriteLine("Quit Successful. Thank You.");
    }
}