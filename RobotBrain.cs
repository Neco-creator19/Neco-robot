using System;
using System.IO;

public class RobotBrain
{
    
    public static int batteryLevel = 100;
    static string robotName = "My name is Neco.";

    public static void CheckBattery()
    {
        Console.WriteLine($"Current Battery: {batteryLevel}%");
        if (batteryLevel < 20)
        {
            SaveData("Warning: Battery is Low!");
        }
    }

    public static void RunLoop()
    {
        Console.WriteLine("System: " + robotName);
        bool isActive = true;
        while (isActive)
        {Console.WriteLine($"Current Battery: {batteryLevel}%");
            if (batteryLevel < 30) CheckBattery();
            
            Console.WriteLine("\nNeco: How may I assist you? (Type 'exit' to quit.)");
            Console.WriteLine("\nNeco: I can say to you 'master', 'neco', 'battery'");

            string cmd = Console.ReadLine()!;
            if (cmd.ToLower() == "exit")
            {
            isActive = false;
            return;
            }

            batteryLevel -= 2;
            if (TaskHandler .IsBatteryEmpty(batteryLevel))
            {
                Console.WriteLine("Battery critical. System shutting down.");break;
            }

            TaskHandler.ProcessCommand(cmd, ref batteryLevel);
        }
    }

    
    public static void CheckBatteryStatus()
    {
        Random rnd = new Random();
        int b = rnd.Next(0, 101);
        Console.WriteLine($"\n[System] Current Battery: {b}%");
        if (b <= 20) Console.WriteLine("Warning: Recharge needed!");
        else if (b < 50) Console.WriteLine("Status: Power is low.");
        else Console.WriteLine("Status: Power is optimal.");
    }

    public static void SaveData(string content)
    {
        File.WriteAllText("data.txt", content);
        Console.WriteLine("Data saved to file successfully");
    }

    public  static void ReadData()
    {
        if (File.Exists("data.txt"))
        {
            string content = File.ReadAllText("data.txt");
            Console.WriteLine("Robot's Memory: " + content);
        }
        else Console.WriteLine("memory file not found!");
    }
}