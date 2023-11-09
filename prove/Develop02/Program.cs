class Program
{
    static void Main(string[] args)
    {
        FileManager fileManager = new FileManager();
        ConsoleTool consoleTool = new ConsoleTool();

        ConsoleTool.MenuMode menuMode = ConsoleTool.MenuMode.Journal;

        while (true)
        {
            if (menuMode == ConsoleTool.MenuMode.Journal)
            {
                menuMode = consoleTool.JournalSelect(fileManager);
                continue;
            }

            if (menuMode == ConsoleTool.MenuMode.Entry)
            {
                menuMode = consoleTool.EntrySelect(fileManager);
                continue;
            }

            if (menuMode == ConsoleTool.MenuMode.Quit)
            {
                Console.Clear();
                Console.WriteLine("Quitting...");
                break;
            }
        }

        Console.WriteLine("Quit Successful. Thank You.");
    }
}