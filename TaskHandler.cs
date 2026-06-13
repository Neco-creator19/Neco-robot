using System;
using System.IO;

public class TaskHandler
{
    public static string[] myTasks =
    { "Review Neco's code", "Attend school", "Practice logic", "Learning physic", "Learning engineering",
     "Learning help skill", "Do homework" };
     public static string[] necoTasks =
     { "Check battery","Monitor ystem", "Optimize", "Save data", "Be a master Han's Shadow",
      "Help master Han" };

    public static void ProcessCommand(string command, ref int batteryLevel)
    {
        switch (command.ToLower())
        {
            case "master":
                ListTasks(myTasks,"Master's Tasks List");
                break;
            
            case "neco":
                ListTasks(necoTasks,"Neco's Tasks List");
                break;

            case "battery":
                CheckBattery(batteryLevel);
                break;

                default:

            Console.WriteLine("Command not recognize.");
            Console.WriteLine("Available command: 'master', 'neco', 'battery', 'exit'");
            break;
        }
    }
    public static void
    CheckBattery(int batteryLevel)
    {

        Console.WriteLine($"[System] Current battery Level: {batteryLevel}%");
                if (batteryLevel < 20)
        Console.WriteLine("Warning: Recharge needed!");

                else if (batteryLevel < 50)
        Console.WriteLine("Status: Power is low.");
        
                else
        Console.WriteLine("Status: Power is optimal.");
    }
    public static void
ListTasks(string[] tasks, string title)
    {
        Console.WriteLine($"\n--- {title} ---");
    
        for (int i = 0; i < tasks.Length; i++)
    {
        Console.WriteLine($"- {i + 1}. {tasks[i]}");
        }
    }

    public static bool
    IsBatteryEmpty(int batteryLevel)
    {
        if (batteryLevel <= 0)
        {
    Console.WriteLine("\n[Critical] battery empty! Shutting down");
                return true;
        }
                return false;
    }
}