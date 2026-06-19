using System;
using System.IO;

public static class PathManager
{
    private static string BasePath 
    = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../ KnowledgeBase");

    public static string GetForbiddenFilePath()
    {
        return 
        Path.Combine(BasePath, "ForbiddenWords.txt");
    }

    public static string GetSynonymsFilePath()
    {
        return
        Path.Combine(BasePath, "SystemData", "Synonyms.txt");
    }
}