using System;

class Program
{
    static void Main(string[] args)
    {
        GreetingHandler.DisPlayGreeting();

        InitializationSystem();
        RunMainLoop();
    }

    static void InitializationSystem()
    {
        KnowledgeHandler.InitializeIndex();
        Memory.LoadUserName();
    }

    static void RunMainLoop()
    {
        while (true)
        {
            Console.Write("Master> ");
            string input = Console.ReadLine()!;

            if (!SecurityHandler.IsInputSafe(input))
            {
                continue; 
            }

            string intent = IntentHandler.AnalyzeIntent(input);

            if (intent == "EXIT")
            {
                Console.WriteLine("[Neco] Goodbye, Master!");
                break; 
            }

            GreetingHandler.HandleResponse(intent, input);
        }
    }


}