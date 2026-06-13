using System;

class Program
{
    static void Main(string[] args)
    {
       Memory.LoadUserName();

       if
       (GreetingHandler.GreetUser())
        {
            Console.WriteLine("\n[System] Initialization successful. System Online.");
        
        while (true)
        {
            Console.WriteLine("\n-------------------------------------------------");

            Console.WriteLine("Master, what is your command? (task / attack / exit)");

            string mood = Console.ReadLine()!.ToLower();

            if (mood == "exit")
            {
                Console.WriteLine("System shutting down. Goodbye, Master.");
                break;
            }
            if (mood == "attack")
            {
                Console.WriteLine("Enter target action:");

                string cmd = Console.ReadLine()!;

                RuleHandler.EvaluateAction(cmd);
            }
            else

            if (mood == "task")
                    {
                        while (true)
                        {
                            Console.WriteLine("\n[Task Mood] Command: (neco / master / battery / exit)");

                            string cmd = Console.ReadLine()!.ToLower();

                            if (cmd == "exit")
                            break;

                            TaskHandler.ProcessCommand(cmd, ref RobotBrain.batteryLevel);
                        }
                    }
                }
            }
                else
                {
                    Console.WriteLine("[Critical] Authentication failed. Access Denied.");
                }
            }
        }