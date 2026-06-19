using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

public class KnowledgeHandler
{
    private static Dictionary<string, string> _knowledgeIndex =
    new Dictionary<string, string>();

    public static void InitializeIndex()
    {
        string rootPath = Path.Combine(Directory.GetCurrentDirectory(), "KnowledgeBase");
        if (!Directory.Exists(rootPath))return;

        string[] files =Directory.GetFiles(rootPath, "*.txt", SearchOption.AllDirectories);

        foreach (string file in files)
        {
            string[] lines = File.ReadAllLines(file);
            foreach (string line in lines)
            {
                if (!_knowledgeIndex.ContainsKey(line.ToLower()))
                {
                    _knowledgeIndex.Add(line.ToLower(),file);
                }
            }
        }

        Console.WriteLine($"[System] Indexed {_knowledgeIndex.Count} items.");
    }

    private static Dictionary<string, string> LoadSynonyms()
    {
        var synonyms = new Dictionary<string, string>();
        string path = Path.Combine("KnowledgeBase", "SystemData", "Synonyms.txt");

        if (File.Exists(path))
        {
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                if (line.Contains(":"))
                {
                    string[] parts = line.Split(':');
                    if (parts.Length == 2)
                    {
                        synonyms[parts[0].Trim().ToLower()] = parts[1].Trim().ToLower();
                        
                    }
                }
            }
        }

        return synonyms;
    }

    public static void SearchKnowledge(string query)
    {
        if (! SecurityHandler.IsInputSafe(query))
        {
            Console.WriteLine("[System] Search aborted: Security violation.");
            return;
        }
        
        var synonyms = LoadSynonyms();
        string expandedQuery = query.ToLower();

        string searchTarget = query;
        if (synonyms.ContainsKey(query))
        {
            searchTarget = query + "," + synonyms[query];
        }

        bool found = false;
        Console.WriteLine($"\n[Neco] searching for '{query}'...");

        string[] searchTerms = searchTarget.Split(',').Select(t => t.Trim()).ToArray();

        int matchCount = 0;

        foreach (var entry in _knowledgeIndex)
        {
            foreach (var term in searchTerms)
            {
                if (entry.Key.ToLower().Contains(term))
                {
                    Console.WriteLine($"-> Found in {entry.Key}");
                    found = true;
                    matchCount++;

                    if (matchCount >= 3)
                    {
                        Console.WriteLine("-> ... (more results truncated)");
                    break;
                    }
                }
            }
            if (matchCount >= 3)break;
        }

        if (!found)
        Console.WriteLine("[Neco] I cannot find information, Master.");
    }

    public static void CreateCategory(string path)
    {
        string fullPath = Path.Combine("KnowledgeBase", path);
        if (! Directory.Exists(fullPath))
        {
            Directory.CreateDirectory(fullPath);

            Console.WriteLine($"[System] Category '{path}' cteated, Master.");
        }
    }

    public static void ImportData(string categoryPath, string fileName, string content)
    {
        string fullFolderPath = Path.Combine("KnowledgeBase", categoryPath);
        if (! Directory.Exists(fullFolderPath))
        {
            Directory.CreateDirectory(fullFolderPath);

            Console.WriteLine($"[System] Created missing category: {categoryPath}");
        }

        string filePath = Path.Combine(fullFolderPath, fileName + ".txt");
        File.AppendAllText(filePath, content + Environment.NewLine);
        Console.WriteLine($"[System] Data saved to {fileName}.txt");

        InitializeIndex();
        Console.WriteLine("[System] Knowledge Index updated, Master.");
    }

    public static void Notify(string message)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"[Neco Notification] {message}");
        Console.ResetColor();
        }

    private static DateTime _lastCheckedTime = DateTime.Now.AddDays(-1);

    public static bool CheckForUpdates()
    {
        string rootPath = Path.Combine(Directory.GetCurrentDirectory(), "KnowledgeBase");

        if (!Directory.Exists(rootPath)) 
        return false;

        var files = Directory.GetFiles(rootPath, "*.txt", SearchOption.AllDirectories);

        foreach (var file in files)
        {
            if
            (File.GetLastWriteTime(file) > _lastCheckedTime)
            {
                return true;
            }
        }
        return false;
    }

    public static void DisplayNewInfo()
    {
        Console.WriteLine("[Neco] Here is the new information:");
        bool foundNew = false;

        string rootPath = Path.Combine(Directory.GetCurrentDirectory(), "KnowledgeBase");
        var files = Directory.GetFiles(rootPath, "*.txt", SearchOption.AllDirectories);

        foreach (var file in files)
        {
            if
            (File.GetLastAccessTime(file) > _lastCheckedTime)
            {
                Console.WriteLine($"- New update in: {Path.GetFullPath(file)}");
                foundNew = true;
            }
        }
        
        if (!foundNew)
        Console.WriteLine("- No new updates found.");

        _lastCheckedTime = DateTime.Now;
    }
}