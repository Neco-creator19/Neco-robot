using System;

public class GreetingHanler
{
    public static bool GreetUser()
    {
        Console.WriteLine("Please enter your name:");
        string name = Console.ReadLine()!;
        Console.WriteLine("Master, I pledge my loyalty.🤖");

        Console.WriteLine($"Welcome, {name}!");
                return true;
    }
}