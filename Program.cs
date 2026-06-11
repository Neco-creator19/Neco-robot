using System;

class Program
{
    static void Main(string[] args)
    {
        bool isAuthorized = GreetingHanler.GreetUser();

        if (isAuthorized)
        {
            RobotBrain.CheckBattery();

            RobotBrain.RunLoop();
            RobotBrain.ReadData();      
        }
        else
        {
            Console.WriteLine("System shutting down...");
        }
    }
}