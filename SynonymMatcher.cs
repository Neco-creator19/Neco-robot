using System;
using System.IO;

public class SynnoymMatcher
{
    public static string CheckSynonyms(string userInput)
    {
        string synonymsPath = @"C:\Users\USER\Desktop\Programming\Shadow_X\KnowledgeBase\ForbiddenWords.txt";
        if (File.Exists(synonymsPath))
        {
            string content = File.ReadAllText(synonymsPath).ToLower();

            string[] words = content.Split(',');
            foreach (string word in words)
            {
                string trimmedWord = word.Trim();

                if (!string.IsNullOrEmpty(trimmedWord) && userInput.ToLower().Contains(trimmedWord))
                {
                    return trimmedWord;
                }
            }
        }

        return "NO_SYNONYM";
    }
}