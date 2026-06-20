using System;
using System.IO;

public class GreetingHandler
{
    public static void DisPlayGreeting()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("============================================");
        Console.WriteLine("Welcome to Neco AI System");
        Console.WriteLine("============================================");
        Console.ResetColor();    

        string configPath = @"C:\Users\USER\Desktop\Programming\Shadow_X\config.txt";
        string correctPassword = "";

        if (File.Exists(configPath))
        {
            correctPassword = File.ReadAllText(configPath).Trim();
        }

        else
        {
            correctPassword = "admin";
        }

    while (true)
    {

        Console.Write("Enter Password: ");
        string password = Console.ReadLine()!;

        if (password == correctPassword)
        {
            Console.WriteLine("[System] Access Granted.\n");
            break;
        }

        else
        {
            Console.WriteLine("[System] Incorrect Password! Access Denied. Please try again.\n");
            }
        }
    }

    public static void HandleResponse(string intent, string originalInput)
    {
        if (intent == "GREETING")
        {
            Console.WriteLine("[Neco] Hellow Master! How can I assist you today?");
        }

        else if (intent == "ASK_NAME")
        {
            Console.WriteLine("[Neco] I am Neco, your Shadow.");
        }

        else
        {
            Console.WriteLine($"[Neco] Processing: '{originalInput}'(This will be handled by local AI later).");
        }
    }
}