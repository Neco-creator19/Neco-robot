using System;
using System.Text.RegularExpressions;

public class IntentHandler
{
    public static string AnalyzeIntent(string userInput)
    {
        string input = userInput.ToLower().Trim();

        string greetingPattern = @"\b(hi|hello|hey|yo|mingalaba)\b";

        string namePattern = @"\b(name|who are you)\b";

        string exitPattern = @"\b(exit|quit|bye|close)\b";

        if (Regex.IsMatch(input, greetingPattern))
        {
            return "GREETING";
        }

        else if (Regex.IsMatch(input, namePattern))
        {
            return "ASK_NAME";
        }

        else if (Regex.IsMatch(input, exitPattern))
        {
            return "EXIT";
        }

        return "UNKNOWN";
    }
}