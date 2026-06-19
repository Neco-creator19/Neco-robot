using System;

class Program
{
    static void Main(string[] args)
    {
        InitializationSystem();
        RunMainLoop();
    }

    static void InitializationSystem()
    {
        KnowledgeHandler.InitializeIndex();
        Memory.LoadUserName();
        if (GreetingHandler.GreetUser())
        {
            Console.WriteLine("\n[System] Initialization successful. System Online.");
        }
    }

    static void RunMainLoop()
    {
        bool hasNewInfo = false;
        while (true)
        {
            if (!hasNewInfo && KnowledgeHandler.CheckForUpdates())
            {
                hasNewInfo = true;

                Console.WriteLine("\n[Neco] Master, I have discovered new information. Use 'review' to see it.");
            }

            Console.Write("\nMaster:");
            string input = Console.ReadLine()!;

            if (string.IsNullOrWhiteSpace(input))
            continue;

            if (input.ToLower() == "exit")break;

            if (input.ToLower() == "review")
            {
                if (hasNewInfo)
                {
                    Console.WriteLine("[Neco] Displaying new information...");

                    KnowledgeHandler.DisplayNewInfo();
                    hasNewInfo = false;
                }
                else
                {
                    Console.WriteLine("[Neco] No new information at the moment, Master.");
                }
                continue;
            }

            if (!SecurityHandler.IsInputSafe(input))
            {
                Console.WriteLine("[System] Command blocked for safety.");
                continue;
            }

            string query = input.ToLower().Replace("what is", "").Trim();
            KnowledgeHandler.SearchKnowledge(query);
        }
    }
}