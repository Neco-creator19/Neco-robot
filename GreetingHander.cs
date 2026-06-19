using System;

public class GreetingHandler
{
    public static bool GreetUser()
    {
        string name = Memory.userName;

        string passwordFile = "config.txt";
        string correctPassword = File.ReadAllText(passwordFile).Trim();

        Console.WriteLine("Enter Password:");
        string passwordInput = Console.ReadLine()!;

        if (passwordInput == correctPassword)

        {
        Console.WriteLine($"Master {name}, I am online and updates.How can i help you today? ");
                return true;
            }
            else
            {
            Console.WriteLine("Identity verification failed. Shutting down.");
            return false;
            }
        }
    }