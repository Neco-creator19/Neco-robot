using System;
using System.IO;
class RobotBrain
{
    // Variables များ (Class ရဲ့ အပြင်ဘက်မှာ သတ်မှတ်ပါ)
    static string[] myTasks = { "Review Neco's code", "Attend school", "Practice logic","Learning Physic",
    "learning other Knowledge", "Do homework" };
    static string[] necoTasks = { "Check battery", "Monitor system", "Optimize memory",
    "help Master Han","" };
    static int  batteryLevel = 100;
    
    static string  robotName = "My name is Neco.";
    static void Main() // ဒါက Program စတင်တဲ့နေရာ
    {
        bool isAuthorized = GreetUser();
        if (isAuthorized)
        {
            CheckBattery();
        RunLoop();
        ReadData();
        }
        else
        {
            Console.WriteLine("System shutting down...");
        }
    }
    static void CheckBattery()
            {
                if (batteryLevel < 30)
                {
                    Console.WriteLine("Battery is low! Saving state...");
            SaveData("Wrning: Battery Low!");
                }

            }
    static bool GreetUser()
    {
        // [နေရာ ၁: မှတ်ဉာဏ်များ]
        
        Console.WriteLine("Who create Me?");
        string creatorName = Console.ReadLine()!;

        if (creatorName == "Han")
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
    static void RunLoop()
    {
        // Status စစ်ဆေးခြင်း

        // [နေရာ ၂: အမိန့်ပေးစနစ် (Loop)]
        Console.WriteLine("System: " + robotName);
        bool isActive = true;
        while (isActive)
        {
            batteryLevel -= 5;
            Console.WriteLine($"Current Battery: {batteryLevel}%");
            
            if (batteryLevel < 30)
            {
                CheckBattery();
            }
            Console.WriteLine("\nNeco: How may I assist you? (Type 'exit' to quit.)");
            string cmd = Console.ReadLine()!;

            if (cmd == "exit")
            {
                isActive = false;
            }
            else
            {
                ProcessInput(cmd);
            }
        }
    }

    // [နေရာ ၄: လုပ်ဆောင်ချက်များ (Methods)]
    static void ProcessInput(string cmd)
    {
        switch (cmd.ToLower())
        {
            case "master":
                ListTasks(myTasks,"Master's Task List");break;
            case "neco":
            ListTasks(necoTasks, "Neco's Task List");break;
            case "battery":
        CheckBatteryStatus();break;
            default:
            Console.WriteLine("I do not understand that command, Master.🤖");
            Console.WriteLine("Available commands: 'master, 'neco', 'battery', 'exit'.");
            break;
        }
    }

    static void CheckBatteryStatus()
    {
        Random rnd = new Random();
        int batteryLevel = rnd.Next(0, 101);

        Console.WriteLine($"\n[System] Cerrent Battery: {batteryLevel}%");

        if (batteryLevel <= 20)
        Console.WriteLine("Warning: Recharge needed!");
        else if (batteryLevel < 50)
        Console.WriteLine("Status: Power is low.");
        else
        Console.WriteLine("Status: Power is optimal.");
    }
        static void ListTasks(string[]tasks, string title)
    {
        Console.WriteLine($"\n---{title} ---");
        for (int i = 0; i < tasks.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {tasks[i]}");
        }
    }
    static void SaveData(string content)
    {
        //data.txt file write
        File.WriteAllText("data.txt", content);
        Console.WriteLine("Data saved to file successfully");
    }

        static void ReadData()
    {
        if (File.Exists("data.txt"))
        {
            string content = File.ReadAllText("data.txt");
            Console.WriteLine("Robot's Memory: " + content);
        }
        else
        {
            Console.WriteLine("memory file not found!");
        }


    }
}