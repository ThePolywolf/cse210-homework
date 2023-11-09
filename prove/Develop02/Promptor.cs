using System;
using System.Reflection.Metadata;

class Promptor
{
    public readonly List<string> prompts = new List<string>
    {
        "What went well for you today? ",
        "What can you do better tomorrow? ",
        "What is something interesting that happened today? ",
        "What is something you were looking forawrd to today? How did it go? ",
        "What is something you are looking forward to tomorrow? ",
        "What is something unexpected that happened today? ",
        "What's the best thing that heppened to you today? ",
        "What is a compliment you will give someone today? "
    };

    public string GeneratePrompt()
    {
        Random random = new Random();
        int choice = random.Next(1, prompts.Count) - 1;

        return prompts[choice];
    }
}