using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Journal
{
    private List<Entry> entries;
    private List<string> prompts;

    public Journal()
    {
        entries = new List<Entry>();
        prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };
    }

    public string ChoosePrompt(){
        var random = new Random();
        return prompts[random.Next(prompts.Count)];
    }

    public void AddEntry(string prompt, string response)
    {
        Entry entry = new Entry(prompt, response);
        entries.Add(entry);
    }

    public void DisplayJournal()
    {
        foreach (var entry in entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveJournal(string filename)
    {
        string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filename);

        if (File.Exists(fullPath))
        {
            Console.Write($"The file '{filename}' already exists in the current directory. Do you want to overwrite it? (Y/N): ");
            string response = Console.ReadLine().ToUpper();
            if (response != "N")
            {
                Console.WriteLine("Operation canceled.");
                return;
            }
        }

        using (StreamWriter sw = new StreamWriter(filename))
        {
            foreach (var entry in entries)
            {
                sw.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
            }
        }
    }

    public void LoadJournal(string filename)
    {
        entries.Clear();
        string[] lines = File.ReadAllLines(filename);
        foreach (var line in lines)
        {
            var parts = line.Split('|');
            if (parts.Length == 3)
            {
                Entry entry = new Entry(parts[1], parts[2])
                {
                    Date = parts[0]
                };
                entries.Add(entry);
            }
        }
    }

    public void SaveJournalJson(string filename)
    {
        string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filename);

        if (File.Exists(fullPath))
        {
            Console.Write($"The file '{filename}' already exists. Do you want to overwrite it? (Y/N): ");
            string response = Console.ReadLine().ToUpper();
            if (response != "Y")
            {
                Console.WriteLine("Save operation canceled.");
                return;
            }
        }

        string jsonString = JsonSerializer.Serialize(entries, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(fullPath, jsonString);

        Console.WriteLine($"Journal saved successfully as JSON at '{fullPath}'.");
    }

    public void LoadJournalJson(string filename)
    {
        string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filename);

        if (File.Exists(fullPath))
        {
            string jsonString = File.ReadAllText(fullPath);
            entries = JsonSerializer.Deserialize<List<Entry>>(jsonString);

            Console.WriteLine($"Journal loaded successfully from '{fullPath}'.");
        }
        else
        {
            Console.WriteLine($"The file '{filename}' does not exist.");
        }
    }

}
