using System;
using System.IO;

class RobotBrain
{
    
    static string[] myTasks = { "Review Neco's code", "Attend school", "Practice logic", "Learning Physic", 
    "learning other Knowledge", "Do homework" };
    static string[] necoTasks = { "Check battery", "Monitor system", "Optimize memory", "help Master Han" };
    static int batteryLevel = 100;
    static string robotName = "My name is Neco.";

    public static void CheckBattery()
    {
        if (batteryLevel < 30)
        {
            Console.WriteLine("Battery is low! Saving state...");
            SaveData("Warning: Battery Low!");
        }
    }

    public static bool GreetUser()
    {
        Console.WriteLine("Password");
        string creatorName = Console.ReadLine()!;
        if (creatorName == "ne135")
        {
            Console.WriteLine("Thank you My Creator " + creatorName + ".");
            Console.WriteLine("Master, I pledge my loyalty. 🤖");
            return true;
        }
        else
        {
            Console.WriteLine("Identity verification failed.");
            return false;
        }
    }

    public static void RunLoop()
    {
        Console.WriteLine("System: " + robotName);
        bool isActive = true;
        while (isActive)
        {
            batteryLevel -= 5;
            if (TaskHandler .IsBatteryEmpty(batteryLevel))
            {
                break;
            }

            Console.WriteLine($"Current Battery: {batteryLevel}%");
            if (batteryLevel < 30) CheckBattery();
            
            Console.WriteLine("\nNeco: How may I assist you? (Type 'exit' to quit.)");
            Console.WriteLine("\nNeco: You can ask me about this 'master', 'neco', 'battery'");

            string cmd = Console.ReadLine()!;
            if (cmd.ToLower() == "exit")
            {
            isActive = false;
            return;
            }
            TaskHandler.ProcessCommand(cmd, ref batteryLevel);
        }
    }

    
    static void CheckBatteryStatus()
    {
        Random rnd = new Random();
        int b = rnd.Next(0, 101);
        Console.WriteLine($"\n[System] Current Battery: {b}%");
        if (b <= 20) Console.WriteLine("Warning: Recharge needed!");
        else if (b < 50) Console.WriteLine("Status: Power is low.");
        else Console.WriteLine("Status: Power is optimal.");
    }

    static void SaveData(string content)
    {
        File.WriteAllText("data.txt", content);
        Console.WriteLine("Data saved to file successfully");
    }

    public static void ReadData()
    {
        if (File.Exists("data.txt"))
        {
            string content = File.ReadAllText("data.txt");
            Console.WriteLine("Robot's Memory: " + content);
        }
        else Console.WriteLine("memory file not found!");
    }
}