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


        // Status စစ်ဆေးခြင်း

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
        switch (cmd.ToLower())
        {
            case "master":
                ListTasks(myTasks,"Master's Task List");break;
            case "neco":
            ListTasks(necoTasks, "Neco's Task List");break;
            case "battery":
        CheckBatteryStatus();break;
            default:
            Console.WriteLine("I do not understand that command, Master.🤖");break;
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
}