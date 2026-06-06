using System;

class RobotBrain
{
    // Variables များ (Class ရဲ့ အပြင်ဘက်မှာ သတ်မှတ်ပါ)
    static string[] myTasks = { "Review Neco's code", "Attend school", "Practice logic", "Do homework" };
    static string[] necoTasks = { "Check battery", "Monitor system", "Optimize memory" };

    static void Main() // ဒါက Program စတင်တဲ့နေရာ
    {
        // [နေရာ ၁: မှတ်ဉာဏ်များ]
        string robotName = "My name is Neco.";
        Console.WriteLine("Who create Me?");
        string creatorName = Console.ReadLine()!;

        if (creatorName == "Han")
        {
            Console.WriteLine("Thank you My Creator " + creatorName + ".");
            Console.WriteLine("Master, I pledge my loyalty. 🤖");
        }
        else
        {
            Console.WriteLine("Identity verification failed.");
            return; // မှားရင် ပိတ်လိုက်မယ်
        }

        Console.WriteLine("How much battery is left?");
        int batteryLevel = int.Parse(Console.ReadLine()!);

        // Status စစ်ဆေးခြင်း
        CheckBatteryStatus(batteryLevel);

        // [နေရာ ၂: အမိန့်ပေးစနစ် (Loop)]
        Console.WriteLine("System: " + robotName);
        bool isActive = true;
        while (isActive)
        {
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
        switch (cmd)
        {
            case "Master1": Console.WriteLine("Master's First Task - " + myTasks[0]); break;
            case "Master2": Console.WriteLine("Master's Second Task - " + myTasks[1]); break;
            case "Master3": Console.WriteLine("Master's Third Task - " + myTasks[2]);break;
            case "Master4": Console.WriteLine("Master's Fourth Task - " + myTasks[3]);break; 
            case "Neco1": Console.WriteLine("Neco's First Task - " + necoTasks[0]); break;
            case "Neco2": Console.WriteLine("Neco;s Second Task - " + necoTasks[1]);break;
            case "Neco3": Console.WriteLine("Neco's Third Task - " + necoTasks[2]);break;  
            default: Console.WriteLine("I do not understand that command, Master.🤖"); break;
        }
    }

    static void CheckBatteryStatus(int level)
    {
        Console.WriteLine(" My current Battery Level: " + level + "%");
        if (level >= 50) Console.WriteLine("Neco Status: Power is high.");
        else if (level <= 20) Console.WriteLine("Neco Status: Warning: Recharge needed!");
        else Console.WriteLine("Neco Status: Power is low.");
    }
}