using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Journal
{
    private List<Entry> _entries;

    public Journal()
    {
        _entries = new List<Entry>();
    }

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries found in the journal.");
            return;
        }

        Console.WriteLine("=== Journal Entries ===");
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        try
        {
            string jsonString = JsonSerializer.Serialize(_entries, new JsonSerializerOptions 
            { 
                WriteIndented = true 
            });
            File.WriteAllText(filename, jsonString);
            Console.WriteLine($"Journal saved to {filename}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving file: {ex.Message}");
        }
    }

    public void LoadFromFile(string filename)
    {
        try
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine($"File {filename} not found.");
                return;
            }

            string jsonString = File.ReadAllText(filename);
            var loadedEntries = JsonSerializer.Deserialize<List<Entry>>(jsonString);
            
            if (loadedEntries != null)
            {
                _entries = loadedEntries;
                Console.WriteLine($"Journal loaded from {filename}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading file: {ex.Message}");
        }
    }
}