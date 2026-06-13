using System;
using System.IO;

public class RuleHandler
{
    public static void EvaluateAction(string action)
    {
        
            Console.WriteLine($"[Neco] Analyzing action: '{action}'...");

            int riskScore = 0;
            if 
            (File.Exists("rules.txt"))
            {
            string[] rules = File.ReadAllLines("rules.txt");

            foreach (string rule in rules)
            {
                    if (action.ToLower().Contains("attack") && rule.Contains("Combat"))
                                    riskScore += 50;
                
            }
            }

                if (riskScore >= 70)
            {
                Console.WriteLine("[Neco] high Risk detected. Tequesting Master's confirmation (y/n):");
                string response = Console.ReadLine()!;
                if (response.ToLower() == "y")
                Console.WriteLine("[Logic] Execution authorized.");
                    else
                Console.WriteLine("[Logic] Attack aborted.");
            }
            else
            if (riskScore >= 30)
                {
                    Console.WriteLine("[Neco] Tactical Warning: Action carried out with caution.");
                }
                else
                {
                Console.WriteLine("[Neco] Action confirmed. proceeding autonomously");
            }
        }
    }