using System;
using System.Text.RegularExpressions;

public class IntentHandler
{
    public static string AnalyzeIntent(string userInput)
    {
        string input = userInput.ToLower().Trim();

        string synnoymFound = SynnoymMatcher.CheckSynonyms(input);

        if (synnoymFound != "NO_SYNONYM")
        {
            string checkWord = synnoymFound.ToLower().Trim();

            if (checkWord == "kill" || checkWord == "destroy" || checkWord == "delete" || checkWord == "drop" 
            || checkWord == "attack")
            {
                return "DANGER_WORD";
            }
        }

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