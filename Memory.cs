using System;
using System.IO;

public class Memory
{
    public static string userName = "";
    public static string memoryFile = "robot_memory.txt";
    
    public static void LoadUserName()
    {
        try
        {
            if
            (File.Exists(memoryFile))
            {
                    userName = File.ReadAllText(memoryFile).Trim();
            }
        }
        catch
        {
            Console.WriteLine("[Error] Could not access memory file.");
        }
        if
        (string.IsNullOrEmpty(userName))
        {
            Console.WriteLine("\n[System] Identify yourself, Master.");
            Console.Write("Name:");
            userName = Console.ReadLine()!;
            SaveUserName();
            Console.WriteLine($"\n[System] Initialization successful. Welcome, Master {userName}");
        }
        else
        {
            Console.WriteLine($"\n[System] Memory loaded. Greetings, Master {userName}. At your service.");
        }
    }

public static void SaveUserName()
    {
        File.WriteAllText(memoryFile, userName);
    }
}
