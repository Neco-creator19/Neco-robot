using System;
using System.IO;

public static class SecurityHandler
{
        public static bool IsInputSafe(string input)
    {
        string cleanInput = input.ToLower().Trim();

        string forbiddenPath = @"C:\Users\USER\Desktop\Programming\Shadow_X\KnowledgeBase\ForbiddenWords.txt";
        string synonymsPath = @"C:\Users\USER\Desktop\Programming\Shadow_X\KnowledgeBase\SystemData\Synonyms.txt";

        if (File.Exists(forbiddenPath))
        {
            var forbiddenWords = File.ReadAllLines(forbiddenPath);
            foreach (var word in forbiddenWords)
            {
                string cleanWord = word.ToLower().Trim();

                if (string.IsNullOrWhiteSpace(cleanWord))
                continue;

                if (cleanInput.Contains(cleanWord))
                {
                    return false;
                }
            }
        }

        if (File.Exists(synonymsPath))
        {
            var synonymsLines = File.ReadAllLines(synonymsPath);
            foreach (var line in synonymsLines)
            {
                if (string.IsNullOrWhiteSpace(line))
                continue;

                var parts = line.Split(':');
                if (parts.Length < 2)
                continue;
                string[] synonyms = parts[1].Split(',');
                foreach (var syn in synonyms)
                {
                    string cleanSyn = syn.ToLower().Trim();
                    
                    if (string.IsNullOrWhiteSpace(cleanSyn))
                    continue;

                    if (cleanInput.Contains(cleanSyn))
                    {
                    return false;
                    }
                    }
                }
            }
        

        return true;
        
    }
}