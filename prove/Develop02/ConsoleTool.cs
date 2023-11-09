class ConsoleTool{
    // determines what is running in the main loop
    public enum MenuMode
    {
        Journal,
        Entry,
        Quit
    }

    public ConsoleTool(){
        return;
    }
    
    public void AddSpacer()
    {
        Console.WriteLine("-------------------");
    }

    // journal mode
    public MenuMode JournalSelect(FileManager fileManager)
    {
        // clear console
        Console.Clear();
        Console.WriteLine("JOURNALS");
        AddSpacer();

        // auto create new journal if there are none
        if (fileManager.GetAllJournals().Count <= 0)
        {
            NewJournal(fileManager);
            return MenuMode.Entry;
        }

        // get input
        Console.WriteLine($"Options:\n 1 - New Journal\n 2 - Load Journal\n 3 - Quit");
        Console.Write("Make a selection: ");
        string selection = Console.ReadLine();

        // change by input
        if (selection == "1")   // new Journal
        {
            NewJournal(fileManager);
            return MenuMode.Entry;
        }
        
        if (selection == "2")   // open journal
        {
            OpenJournal(fileManager);
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
    public void NewJournal(FileManager fileManager)
    {
        // clear console
        Console.Clear();
        Console.WriteLine("JOURNALS > NEW");
        AddSpacer();

        // get a new name
        Console.Write("Name your new Journal: ");
        string newName = Console.ReadLine();

        // create the journal
        fileManager.CreateJournal(newName);
    }

    // open pre-existing journal
    public void OpenJournal(FileManager fileManager)
    {
        // clear console
        Console.Clear();
        Console.WriteLine("JOURNALS > LOAD");
        AddSpacer();

        // display journal list
        Console.WriteLine("All current journals:");

        List<string> allJournals = fileManager.GetAllJournals();
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
        } while (!fileManager.FileExists(journalName));

        // open the file
        fileManager.OpenJournal(journalName);
    }

    // entry menu options
    public MenuMode EntrySelect(FileManager fileManager)
    {
        // clear console
        Console.Clear();
        Console.WriteLine($"{fileManager.journalName} > ENTRIES");
        AddSpacer();

        // list options
        Console.WriteLine("Options:\n 1 - New Entry\n 2 - Load Entries\n 3 - Switch Journal\n 4 - Quit");
        Console.Write("Make a selection: ");
        string selection = Console.ReadLine();

        // handle cases
        if (selection == "1")
        {
            NewEntry(fileManager);

            return MenuMode.Entry;
        }

        if (selection == "2")
        {
            LoadEntries(fileManager);
            
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
    public void NewEntry(FileManager fileManager)
    {
        // clear console
        Console.Clear();
        Console.WriteLine($"{fileManager.journalName} > ENTRIES > NEW");
        AddSpacer();

        Console.WriteLine("New Entry: ");

        // get prompt
        Promptor promptor = new Promptor();
        string prompt = promptor.GeneratePrompt();
        Console.WriteLine("Prompt: " + prompt);

        // user input
        string userText = Console.ReadLine();

        // create entry object to pass to FileManager
        Entry entry = new Entry(prompt, userText);

        // save entry
        fileManager.SaveEntry(entry);
    }

    // load current entries
    public void LoadEntries(FileManager fileManager)
    {
        // clear console
        Console.Clear();
        Console.WriteLine($"{fileManager.journalName} > ENTRIES > LOAD");
        AddSpacer();

        // all current entries in a string already
        Console.WriteLine(fileManager.journal);

        // wait for input to continue
        Console.Write("Press ENTER to continue ");
        Console.ReadLine();
    }


}